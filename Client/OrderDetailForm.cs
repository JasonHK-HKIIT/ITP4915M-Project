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
            this.Load += CustomerOrderDetailForm_Load;
        }

        private void CustomerOrderDetailForm_Load(object sender, EventArgs e)
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

            // Fill Quotation ComboBox
            using (var cmd = new MySqlCommand("SELECT QuotationID FROM Quotation", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxQuotation.DataSource = dt;
                comboBoxQuotation.DisplayMember = "QuotationID";
                comboBoxQuotation.ValueMember = "QuotationID";
            }

            // You can replace with data-driven values if you store these in a reference/status table
            comboBoxStatus.Items.AddRange(new[] { "Confirmed", "Pending", "Cancelled", "Completed" });
            comboBoxPaymentStatus.Items.AddRange(new[] { "Paid", "Unpaid", "Partial" });
            comboBoxOrderType.Items.AddRange(new[] { "Normal", "Express", "Bulk" });
        }

        // Set fields for Edit mode
        public void SetFields(
            string orderId, string customerId, string quotationId, DateTime orderDate, DateTime deadline,
            string status, decimal deposit, decimal balance, decimal total, string paymentStatus, string orderType)
        {
            textBoxOrderID.Text = orderId;
            comboBoxCustomer.SelectedValue = customerId;
            comboBoxQuotation.SelectedValue = quotationId;
            dateTimePickerOrderDate.Value = orderDate;
            dateTimePickerDeadline.Value = deadline;
            comboBoxStatus.Text = status;
            textBoxDeposit.Text = deposit.ToString("0.##");
            textBoxBalance.Text = balance.ToString("0.##");
            textBoxTotalAmount.Text = total.ToString("0.##");
            comboBoxPaymentStatus.Text = paymentStatus;
            comboBoxOrderType.Text = orderType;
        }

        // Expose properties for reading input
        public string OrderID => textBoxOrderID.Text.Trim();
        public string CustomerID => comboBoxCustomer.SelectedValue?.ToString() ?? "";
        public string QuotationID => comboBoxQuotation.SelectedValue?.ToString() ?? "";
        public DateTime OrderDate => dateTimePickerOrderDate.Value;
        public DateTime Deadline => dateTimePickerDeadline.Value;
        public string Status => comboBoxStatus.Text.Trim();
        public decimal DepositPaid => decimal.TryParse(textBoxDeposit.Text, out var v) ? v : 0;
        public decimal BalanceDue => decimal.TryParse(textBoxBalance.Text, out var v) ? v : 0;
        public decimal TotalAmount => decimal.TryParse(textBoxTotalAmount.Text, out var v) ? v : 0;
        public string PaymentStatus => comboBoxPaymentStatus.Text.Trim();
        public string OrderType => comboBoxOrderType.Text.Trim();
    }
}
