using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class ServiceCaseDetailForm : Form
    {
        public ServiceCaseDetailForm()
        {
            InitializeComponent();
            buttonSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // --- Customer ComboBox ---
            using (var cmd = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerID";
                comboBoxCustomer.DataSource = dt;
            }

            // --- Customer Order ComboBox ---
            UpdateOrdersList();

            // --- Assigned Staff ComboBox ---
            using (var cmd = new MySqlCommand("SELECT UserID, Name FROM User", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxAssignedStaff.DisplayMember = "Name";
                comboBoxAssignedStaff.ValueMember = "UserID";
                comboBoxAssignedStaff.DataSource = dt;
                comboBoxAssignedStaff.SelectedValue = Program.User.UserId;
            }

            comboBoxStatus.SelectedIndex = 0; // Default to first item
            comboBoxCaseType.SelectedIndex = 0; // Default to first item
        }

        private void ServiceCaseDetailForm_Load(object sender, EventArgs e)
        {
        }

        // Expose properties for each field
        public string CaseID => maskedTextBoxCaseID.Text;
        public string CustomerID => comboBoxCustomer.SelectedValue?.ToString() ?? "";
        public string CustomerOrderID => comboBoxOrder.SelectedValue?.ToString() ?? "";
        public DateTime CaseDate => dateTimePickerCaseDate.Value;
        public string Description => textBoxDescription.Text.Trim();
        public string Status => comboBoxStatus.Text.Trim();
        public string Resolution => textBoxResolution.Text.Trim();
        public string CaseType => comboBoxCaseType.Text.Trim();
        public string AssignedStaffID => comboBoxAssignedStaff.SelectedValue?.ToString() ?? "";

        // SetFields for editing existing records
        public void SetFields(
            string caseId, string customerId, string customerOrderId, DateTime caseDate,
            string description, string status, string resolution, string caseType, string assignedStaffId)
        {
            maskedTextBoxCaseID.Text = caseId;
            comboBoxCustomer.SelectedValue = customerId;
            UpdateOrdersList();
            comboBoxOrder.SelectedValue = customerOrderId;
            dateTimePickerCaseDate.Value = caseDate;
            textBoxDescription.Text = description;
            comboBoxStatus.SelectedItem = status;
            textBoxResolution.Text = resolution;
            comboBoxCaseType.SelectedItem = caseType;
            comboBoxAssignedStaff.SelectedValue = assignedStaffId;
        }

        private void UpdateOrdersList()
        {
            var command = new MySqlCommand("SELECT CustomerOrderID, ProductName FROM CustomerOrder LEFT JOIN Quotation ON CustomerOrder.QuotationID = Quotation.QuotationID LEFT JOIN Product ON Quotation.ProductID = Product.ProductID WHERE CustomerOrder.CustomerID = ?Customer", Program.Connection);
            command.Parameters.AddWithValue("?Customer", comboBoxCustomer.SelectedValue);

            var reader = command.ExecuteReader();
            var dict = new Dictionary<string, string>();
            while (reader.Read())
            {
                dict.Add(reader.GetString("CustomerOrderID"), $"{reader["CustomerOrderID"]} - {reader["ProductName"]}");
            }
            reader.Close();

            if (dict.Count > 0)
            {
                comboBoxOrder.ValueMember = "Key";
                comboBoxOrder.DisplayMember = "Value";
                comboBoxOrder.DataSource = new BindingSource(dict, null);
            }
            else
            {
                comboBoxOrder.DataSource = null; // Clear if no quotations found
            }
        }

        private void comboBoxCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateOrdersList();
        }
    }
}
