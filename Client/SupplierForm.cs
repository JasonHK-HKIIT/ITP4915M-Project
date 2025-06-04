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
            button1.Click += ButtonAdd_Click;    // Add Supplier
            button2.Click += ButtonEdit_Click;   // Edit Supplier
            button3.Click += ButtonDelete_Click; // Delete Supplier
            textBox1.KeyUp += textBox1_KeyUp;    // Search
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
                    "SELECT SupplierID, SupplierName AS Name, ContactPerson AS Contact FROM Supplier",
                    Program.Connection);
            }
            else
            {
                command = new MySqlCommand(
                    "SELECT SupplierID, SupplierName AS Name, ContactPerson AS Contact FROM Supplier WHERE SupplierID LIKE @q OR SupplierName LIKE @q",
                    Program.Connection);
                command.Parameters.AddWithValue("@q", "%" + query + "%");
            }

            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
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
                        "INSERT INTO Supplier (SupplierID, SupplierName, ContactPerson) VALUES (@id, @name, @contact)",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.SupplierID);
                        command.Parameters.AddWithValue("@name", detail.SupplierName);
                        command.Parameters.AddWithValue("@contact", detail.Contact);

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

            string originalId = dataGridView1.SelectedRows[0].Cells["SupplierID"].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            string contact = dataGridView1.SelectedRows[0].Cells["Contact"].Value.ToString();

            using (var detail = new SupplierDetailForm())
            {
                detail.Text = "Edit Supplier";
                detail.SetFields(originalId, name, contact);

                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        "UPDATE Supplier SET SupplierID=@id, SupplierName=@name, ContactPerson=@contact WHERE SupplierID=@originalId",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.SupplierID);
                        command.Parameters.AddWithValue("@name", detail.SupplierName);
                        command.Parameters.AddWithValue("@contact", detail.Contact);
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
    }
}
