using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class ServiceCaseDetailForm : Form
    {
        // These models are for populating the dropdowns, you can adjust as needed
        public class Customer { public string CustomerID { get; set; } public string CustomerName { get; set; } }
        public class Order { public string CustomerOrderID { get; set; } }
        public class Worker { public string WorkerID { get; set; } public string Name { get; set; } }

        // Constructor
        public ServiceCaseDetailForm(
            List<Customer> customers,
            List<Order> orders,
            List<Worker> workers,
            string[] statusOptions = null,
            string[] caseTypeOptions = null)
        {
            InitializeComponent();

            // Populate combo boxes
            comboBoxCustomerID.DataSource = customers;
            comboBoxCustomerID.DisplayMember = "CustomerName";
            comboBoxCustomerID.ValueMember = "CustomerID";

            comboBoxCustomerOrderID.DataSource = orders;
            comboBoxCustomerOrderID.DisplayMember = "CustomerOrderID";
            comboBoxCustomerOrderID.ValueMember = "CustomerOrderID";

            comboBoxAssignedStaffID.DataSource = workers;
            comboBoxAssignedStaffID.DisplayMember = "Name";
            comboBoxAssignedStaffID.ValueMember = "WorkerID";

            comboBoxStatus.Items.AddRange(statusOptions ?? new string[] { "Open", "In Progress", "Resolved", "Closed" });
            comboBoxCaseType.Items.AddRange(caseTypeOptions ?? new string[] { "Complaint", "Inquiry", "Return", "Request" });

            // Optional: Set default selection
            comboBoxStatus.SelectedIndex = 0;
            comboBoxCaseType.SelectedIndex = 0;
        }

        // Expose properties for all fields (get/set from outside)
        public string CaseID
        {
            get => textBoxCaseID.Text.Trim();
            set => textBoxCaseID.Text = value;
        }
        public string CustomerID
        {
            get => comboBoxCustomerID.SelectedValue?.ToString();
            set => comboBoxCustomerID.SelectedValue = value;
        }
        public string CustomerOrderID
        {
            get => comboBoxCustomerOrderID.SelectedValue?.ToString();
            set => comboBoxCustomerOrderID.SelectedValue = value;
        }
        public DateTime CaseDate
        {
            get => dateTimePickerCaseDate.Value.Date;
            set => dateTimePickerCaseDate.Value = value;
        }
        public string Description
        {
            get => textBoxDescription.Text.Trim();
            set => textBoxDescription.Text = value;
        }
        public string Status
        {
            get => comboBoxStatus.SelectedItem?.ToString();
            set => comboBoxStatus.SelectedItem = value;
        }
        public string Resolution
        {
            get => textBoxResolution.Text.Trim();
            set => textBoxResolution.Text = value;
        }
        public string CaseType
        {
            get => comboBoxCaseType.SelectedItem?.ToString();
            set => comboBoxCaseType.SelectedItem = value;
        }
        public string AssignedStaffID
        {
            get => comboBoxAssignedStaffID.SelectedValue?.ToString();
            set => comboBoxAssignedStaffID.SelectedValue = value;
        }

        // Save Button
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Validate and save logic here
            if (string.IsNullOrWhiteSpace(CaseID))
            {
                MessageBox.Show("Case ID cannot be empty.");
                return;
            }
            // Add more validation as needed

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cancel Button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
