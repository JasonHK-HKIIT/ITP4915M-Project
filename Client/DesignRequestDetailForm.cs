using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestDetailForm : Form
    {
        private bool isEditMode;

        private string RequestId;

        public DesignRequestDetailForm()
        {
            isEditMode = false;

            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };    // Save
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };// Cancel
        }

        public DesignRequestDetailForm(string requestId) : this()
        {
            isEditMode = true;
            this.RequestId = requestId;
        }

        // For Edit
        public void SetFields(string customer, string manager, string specs)
        {
            CustomerComboBox.Text = customer;
            comboBox1.Text = manager;
            textBox3.Text = specs;
        }

        private void DesignRequestDetailForm_Load(object sender, EventArgs e)
        {
            var customersCcommand = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection);
            var customersAdapter = new MySqlDataAdapter(customersCcommand);
            var customersTable = new DataTable();
            customersAdapter.Fill(customersTable);
            CustomerComboBox.ValueMember = "CustomerID";
            CustomerComboBox.DisplayMember = "CustomerName";
            CustomerComboBox.DataSource = customersTable;

            if (isEditMode)
            {
                var command = new MySqlCommand("SELECT * FROM ProductDesignRequest WHERE DesignRequestID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", RequestId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CustomerComboBox.SelectedValue = reader["CustomerID"].ToString();
                    comboBox1.Text = reader["AssignedManagerID"].ToString();
                    textBox3.Text = reader["Specifications"].ToString();
                }
                reader.Close();
            }
        }

        // For Add/Edit
        public string Customer => CustomerComboBox.Text;
        public string AssignedManager => comboBox1.Text;
        public string Specifications => textBox3.Text;
    }
}
