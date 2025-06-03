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

            button1.Click += ButtonAdd_Click;    // Add Customer
            button2.Click += ButtonEdit_Click;   // Edit Customer
            button3.Click += ButtonDelete_Click; // Delete Customer
            textBox1.KeyUp += textBox1_KeyUp;    // Search by phone

            LoadData();
        }

        // Load customers (filtered by phone if entered)
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    "SELECT CustomerID, CustomerName AS Name, CustomerPhoneNo AS Phone, Address FROM Customer",
                    Program.Connection
                );
            }
            else
            {
                command = new MySqlCommand(
                    "SELECT CustomerID, CustomerName AS Name, CustomerPhoneNo AS Phone, Address FROM Customer WHERE CustomerPhoneNo LIKE @phone",
                    Program.Connection
                );
                command.Parameters.AddWithValue("@phone", "%" + query + "%");
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

        // Add new customer
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new CustomerDetailForm())
            {
                detail.Text = "Add Customer";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        "INSERT INTO Customer (CustomerID, CustomerName, CustomerPhoneNo, Address) VALUES (@id, @name, @phone, @address)",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.CustomerID);
                        command.Parameters.AddWithValue("@name", detail.CustomerName);
                        command.Parameters.AddWithValue("@phone", detail.CustomerPhone);
                        command.Parameters.AddWithValue("@address", detail.CustomerAddress);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        // Edit existing customer
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string originalId = dataGridView1.SelectedRows[0].Cells["CustomerID"].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            string phone = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
            string address = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();

            using (var detail = new CustomerDetailForm())
            {
                detail.Text = "Edit Customer";
                detail.SetFields(originalId, name, phone, address);

                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        "UPDATE Customer SET CustomerID=@id, CustomerName=@name, CustomerPhoneNo=@phone, Address=@address WHERE CustomerID=@originalId",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.CustomerID);
                        command.Parameters.AddWithValue("@name", detail.CustomerName);
                        command.Parameters.AddWithValue("@phone", detail.CustomerPhone);
                        command.Parameters.AddWithValue("@address", detail.CustomerAddress);
                        command.Parameters.AddWithValue("@originalId", originalId);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        // Delete customer
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

            using (var command = new MySqlCommand(
                "DELETE FROM Customer WHERE CustomerID=@id", Program.Connection))
            {
                command.Parameters.AddWithValue("@id", customerId);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
