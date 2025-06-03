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
                    CustomerField.SelectedValue = reader["CustomerID"].ToString();
                    comboBox1.SelectedValue = reader["AssignedManagerID"].ToString();
                    textBox3.Text = reader["Specifications"].ToString();
                }
                reader.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
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
