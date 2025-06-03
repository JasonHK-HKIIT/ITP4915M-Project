using System;
using System.Windows.Forms;

namespace Client
{
    public partial class OrderDetailForm : Form
    {
        public OrderDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };    // Save
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };// Cancel
        }

        // Fill fields for Edit
        public void SetFields(string customer, string quotation, DateTime date, decimal deposit, decimal balance, decimal total, string status, string payment, string type)
        {
            comboBox2.Text = customer;
            comboBox1.Text = quotation;
            dateTimePicker1.Value = date;
            textBox1.Text = deposit.ToString();
            textBox6.Text = balance.ToString();
            textBox2.Text = total.ToString();
            textBox3.Text = status;
            textBox4.Text = payment;
            textBox5.Text = type;
        }

        // Expose values for Add/Edit
        public string Customer => comboBox2.Text;
        public string Quotation => comboBox1.Text;
        public DateTime OrderDate => dateTimePicker1.Value;
        public decimal Deposit => decimal.TryParse(textBox1.Text, out var v) ? v : 0;
        public decimal Balance => decimal.TryParse(textBox6.Text, out var v) ? v : 0;
        public decimal TotalAmount => decimal.TryParse(textBox2.Text, out var v) ? v : 0;
        public string Status => textBox3.Text;
        public string PaymentStatus => textBox4.Text;
        public string OrderType => textBox5.Text;
    }
}
