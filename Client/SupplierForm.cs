using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;      // Add Supplier
            button2.Click += ButtonEdit_Click;     // Edit Supplier
            button3.Click += ButtonDelete_Click;   // Delete Supplier
            button4.Click += ButtonToggleActive_Click; // Activate/Deactivate Selected
            textBox1.KeyUp += textBox1_KeyUp;      // Search
            LoadData();
        }

        // Load suppliers, optionally filter by search
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    @"SELECT SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address, Country, Status, CreatedAt 
                      FROM Supplier",
                    Program.Connection);
            }
            else
            {
                command = new MySqlCommand(
                    @"SELECT SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address, Country, Status, CreatedAt 
                      FROM Supplier
                      WHERE SupplierID LIKE @q OR SupplierName LIKE @q OR ContactPerson LIKE @q OR PhoneNumber LIKE @q OR Country LIKE @q",
                    Program.Connection);
                command.Parameters.AddWithValue("@q", "%" + query + "%");
            }

            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();

            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Search on Enter key
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        // Add new supplier
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new SupplierDetailForm())
            {
                detail.Text = "Add Supplier";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"INSERT INTO Supplier 
                            (SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address, Country, Status) 
                          VALUES 
                            (@id, @name, @contact, @phone, @email, @address, @country, @status)",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.SupplierID);
                        command.Parameters.AddWithValue("@name", detail.SupplierName);
                        command.Parameters.AddWithValue("@contact", detail.ContactPerson);
                        command.Parameters.AddWithValue("@phone", detail.PhoneNumber);
                        command.Parameters.AddWithValue("@email", detail.Email);
                        command.Parameters.AddWithValue("@address", detail.Address);
                        command.Parameters.AddWithValue("@country", detail.Country);
                        command.Parameters.AddWithValue("@status", detail.Status);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        // Edit existing supplier
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string originalId = row.Cells["SupplierID"].Value.ToString();

            using (var detail = new SupplierDetailForm())
            {
                detail.Text = "Edit Supplier";
                detail.SetFields(
                    row.Cells["SupplierID"].Value?.ToString(),
                    row.Cells["SupplierName"].Value?.ToString(),
                    row.Cells["ContactPerson"].Value?.ToString(),
                    row.Cells["PhoneNumber"].Value?.ToString(),
                    row.Cells["Email"].Value?.ToString(),
                    row.Cells["Address"].Value?.ToString(),
                    row.Cells["Country"].Value?.ToString(),
                    row.Cells["Status"].Value?.ToString()
                );

                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"UPDATE Supplier SET 
                            SupplierID=@id, 
                            SupplierName=@name, 
                            ContactPerson=@contact, 
                            PhoneNumber=@phone, 
                            Email=@email, 
                            Address=@address, 
                            Country=@country,
                            Status=@status
                          WHERE SupplierID=@originalId",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.SupplierID);
                        command.Parameters.AddWithValue("@name", detail.SupplierName);
                        command.Parameters.AddWithValue("@contact", detail.ContactPerson);
                        command.Parameters.AddWithValue("@phone", detail.PhoneNumber);
                        command.Parameters.AddWithValue("@email", detail.Email);
                        command.Parameters.AddWithValue("@address", detail.Address);
                        command.Parameters.AddWithValue("@country", detail.Country);
                        command.Parameters.AddWithValue("@status", detail.Status);
                        command.Parameters.AddWithValue("@originalId", originalId);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        // Activate/Deactivate selected supplier
        private void ButtonToggleActive_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to activate/deactivate.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var row = dataGridView1.SelectedRows[0];
            string supplierId = row.Cells["SupplierID"].Value.ToString();
            string currentStatus = row.Cells["Status"].Value.ToString();
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";

            using (var command = new MySqlCommand(
                "UPDATE Supplier SET Status=@status WHERE SupplierID=@id", Program.Connection))
            {
                command.Parameters.AddWithValue("@status", newStatus);
                command.Parameters.AddWithValue("@id", supplierId);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating supplier status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadData();
        }

        // Delete supplier
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string supplierId = dataGridView1.SelectedRows[0].Cells["SupplierID"].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var command = new MySqlCommand(
                "DELETE FROM Supplier WHERE SupplierID=@id", Program.Connection))
            {
                command.Parameters.AddWithValue("@id", supplierId);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadData();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {

        }
    }
}
