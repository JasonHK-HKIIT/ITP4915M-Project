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
            this.Load += ServiceCaseDetailForm_Load;
        }

        private void ServiceCaseDetailForm_Load(object sender, EventArgs e)
        {
            // --- Customer ComboBox ---
            using (var cmd = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxCustomer.DataSource = dt;
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerID";
            }

            // --- Customer Order ComboBox ---
            using (var cmd = new MySqlCommand("SELECT CustomerOrderID FROM CustomerOrder", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxOrder.DataSource = dt;
                comboBoxOrder.DisplayMember = "CustomerOrderID";
                comboBoxOrder.ValueMember = "CustomerOrderID";
            }

            // --- Assigned Staff ComboBox ---
            using (var cmd = new MySqlCommand("SELECT UserID, Name FROM User", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxAssignedStaff.DataSource = dt;
                comboBoxAssignedStaff.DisplayMember = "Name";
                comboBoxAssignedStaff.ValueMember = "UserID";
            }

            // --- Status/CaseType options (you may load these from DB instead) ---
            comboBoxStatus.Items.AddRange(new[] { "Open", "In Progress", "Resolved", "Closed" });
            comboBoxCaseType.Items.AddRange(new[] { "Complaint", "Inquiry", "Return", "Request" });
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
            comboBoxOrder.SelectedValue = customerOrderId;
            dateTimePickerCaseDate.Value = caseDate;
            textBoxDescription.Text = description;
            comboBoxStatus.Text = status;
            textBoxResolution.Text = resolution;
            comboBoxCaseType.Text = caseType;
            comboBoxAssignedStaff.SelectedValue = assignedStaffId;
        }
    }
}
