using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class OrderDetailForm : Form
    {
        public OrderDetailForm()
        {
            InitializeComponent();
            buttonSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        // Set fields for Edit mode
        public void SetFields(
            string orderId, string customerId, string quotationId, DateTime orderDate, DateTime deadline,
            string status, decimal deposit, decimal balance, decimal total, string paymentStatus, string orderType)
        {
            maskedTextBox1.Text = orderId; // CHANGED
            comboBoxCustomer.SelectedValue = customerId;
            UpdateQuotationsList(); // Ensure quotations are updated based on selected customer

            comboBoxQuotation.SelectedValue = quotationId;
            dateTimePickerOrderDate.Value = orderDate;
            dateTimePickerDeadline.Value = deadline;
            comboBoxStatus.SelectedItem = status;
            textBoxDeposit.Value = deposit;
            textBoxBalance.Value = balance;
            textBoxTotalAmount.Value = total;
            comboBoxPaymentStatus.SelectedItem = paymentStatus;
            comboBoxOrderType.SelectedItem = orderType;
        }

        private void UpdateQuotationsList()
        {
            var command = new MySqlCommand("SELECT QuotationID, ProductName FROM Quotation LEFT JOIN Product ON Quotation.ProductID = Product.ProductID WHERE CustomerID = ?Customer", Program.Connection);
            command.Parameters.AddWithValue("?Customer", comboBoxCustomer.SelectedValue);

            var reader = command.ExecuteReader();
            var dict = new Dictionary<string, string>();
            while (reader.Read())
            {
                dict.Add(reader.GetString("QuotationID"), $"{reader["QuotationID"]} - {reader["ProductName"]}");
            }
            reader.Close();
            
            if (dict.Count > 0)
            {
                comboBoxQuotation.ValueMember = "Key";
                comboBoxQuotation.DisplayMember = "Value";
                comboBoxQuotation.DataSource = new BindingSource(dict, null);
            }
            else
            {
                comboBoxQuotation.DataSource = null; // Clear if no quotations found
            }
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            // Fill Customer ComboBox
            using (var cmd = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxCustomer.DataSource = dt;
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerID";
            }

            UpdateQuotationsList(); // Initial load of quotations

            comboBoxOrderType.SelectedIndex = 0;
            comboBoxPaymentStatus.SelectedIndex = 0;
            comboBoxStatus.SelectedIndex = 0;
        }

        private void comboBoxCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateQuotationsList();
        }

        // Expose properties for reading input
        public string OrderID => maskedTextBox1.Text.Trim(); // CHANGED
        public string CustomerID => comboBoxCustomer.SelectedValue?.ToString() ?? "";
        public string QuotationID => comboBoxQuotation.SelectedValue?.ToString() ?? "";
        public DateTime OrderDate => dateTimePickerOrderDate.Value;
        public DateTime Deadline => dateTimePickerDeadline.Value;
        public string Status => (string)comboBoxStatus.SelectedItem;
        public decimal DepositPaid => textBoxDeposit.Value;
        public decimal BalanceDue => textBoxBalance.Value;
        public decimal TotalAmount => textBoxTotalAmount.Value;
        public string PaymentStatus => (string)comboBoxPaymentStatus.SelectedItem;
        public string OrderType => (string)comboBoxOrderType.SelectedItem;
    }
}
