using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestDetailForm : Form
    {
        private readonly bool IsEditMode = false;

        private readonly string RequestId;

        public DesignRequestDetailForm()
        {
            InitializeComponent();
        }

        public DesignRequestDetailForm(string requestId) : this()
        {
            IsEditMode = true;
            this.RequestId = requestId;
        }

        private void DesignRequestDetailForm_Load(object sender, EventArgs e)
        {
            var customersCcommand = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection);
            var customersAdapter = new MySqlDataAdapter(customersCcommand);
            var customersTable = new DataTable();
            customersAdapter.Fill(customersTable);
            CustomerField.ValueMember = "CustomerID";
            CustomerField.DisplayMember = "CustomerName";
            CustomerField.DataSource = customersTable;

            var managersCommand = new MySqlCommand("SELECT WorkerID, Name FROM Worker", Program.Connection);
            var managersAdapter = new MySqlDataAdapter(managersCommand);
            var managersTable = new DataTable();
            managersAdapter.Fill(managersTable);
            comboBox1.ValueMember = "WorkerID";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = managersTable;

            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT * FROM ProductDesignRequest WHERE DesignRequestID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", RequestId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    RequestIdField.Text = (string) reader["DesignRequestID"];
                    CustomerField.SelectedValue = reader["CustomerID"];
                    comboBox1.SelectedValue = reader["AssignedManagerID"];
                    textBox3.Text = (string) reader["Specifications"];
                }
                reader.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEditMode)
                {
                    var command = new MySqlCommand("UPDATE ProductDesignRequest SET CustomerID = ?customer, AssignedManagerID = ?manager, Specifications = ?specifications WHERE DesignRequestID = ?id", Program.Connection);
                    command.Parameters.AddWithValue("?id", RequestId);
                    command.Parameters.AddWithValue("?customer", CustomerField.SelectedValue);
                    command.Parameters.AddWithValue("?manager", comboBox1.SelectedValue);
                    command.Parameters.AddWithValue("?specifications", textBox3.Text);
                    command.ExecuteNonQuery();
                }
                else
                {
                    var command = new MySqlCommand("INSERT INTO ProductDesignRequest (DesignRequestID, CustomerID, AssignedManagerID, Specifications, RequestDate, Status) VALUES (?requestId, ?customer, ?manager, ?specifications, ?requestDate, ?status)", Program.Connection);
                    command.Parameters.AddWithValue("?requestId", RequestIdField.Text);
                    command.Parameters.AddWithValue("?customer", CustomerField.SelectedValue);
                    command.Parameters.AddWithValue("?manager", comboBox1.SelectedValue);
                    command.Parameters.AddWithValue("?specifications", textBox3.Text);
                    command.Parameters.AddWithValue("?requestDate", DateTime.Now);
                    command.Parameters.AddWithValue("?status", "Pending");
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error saving design request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
