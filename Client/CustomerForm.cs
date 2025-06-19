using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();

            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            button3.Click += ButtonDelete_Click;
            textBox1.KeyUp += TextBoxSearch_KeyUp;

            LoadData();
        }

        // Load customers based on search input
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            string sql = @"
                SELECT CustomerID, CustomerName AS Name, CustomerPhoneNo AS Phone, Address 
                FROM Customer";

            if (!string.IsNullOrEmpty(query))
            {
                sql += " WHERE CustomerID LIKE @q OR CustomerName LIKE @q OR CustomerPhoneNo LIKE @q";
            }

            using var command = new MySqlCommand(sql, Program.Connection);
            if (!string.IsNullOrEmpty(query))
            {
                command.Parameters.AddWithValue("@q", $"%{query}%");
            }

            using var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using var detail = new CustomerDetailForm { Text = "Add Customer" };
            if (detail.ShowDialog() != DialogResult.OK) return;

            var lastIdCommand = new MySqlCommand("SELECT CustomerID FROM Customer ORDER BY CustomerID DESC LIMIT 1", Program.Connection);
            var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "CUST000";
            var nextId = int.Parse(lastIdString.Substring(4)) + 1;

            using var command = new MySqlCommand(
                "INSERT INTO Customer (CustomerID, CustomerName, CustomerPhoneNo, Address) VALUES (@id, @name, @phone, @address)",
                Program.Connection);
            command.Parameters.AddWithValue("@id", $"CUST{nextId.ToString().PadLeft(3, '0')}");
            command.Parameters.AddWithValue("@name", detail.CustomerName);
            command.Parameters.AddWithValue("@phone", detail.CustomerPhone);
            command.Parameters.AddWithValue("@address", detail.CustomerAddress);

            try
            {
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string originalId = row.Cells["CustomerID"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();
            string phone = row.Cells["Phone"].Value.ToString();
            string address = row.Cells["Address"].Value.ToString();

            using var detail = new CustomerDetailForm { Text = "Edit Customer" };
            detail.SetFields(originalId, name, phone, address);

            if (detail.ShowDialog() != DialogResult.OK) return;

            using var command = new MySqlCommand(
                "UPDATE Customer SET CustomerID=@id, CustomerName=@name, CustomerPhoneNo=@phone, Address=@address WHERE CustomerID=@originalId",
                Program.Connection);
            command.Parameters.AddWithValue("@id", detail.CustomerID);
            command.Parameters.AddWithValue("@name", detail.CustomerName);
            command.Parameters.AddWithValue("@phone", detail.CustomerPhone);
            command.Parameters.AddWithValue("@address", detail.CustomerAddress);
            command.Parameters.AddWithValue("@originalId", originalId);

            try
            {
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string customerId = dataGridView1.SelectedRows[0].Cells["CustomerID"].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using var command = new MySqlCommand("DELETE FROM Customer WHERE CustomerID=@id", Program.Connection);
            command.Parameters.AddWithValue("@id", customerId);

            try
            {
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
