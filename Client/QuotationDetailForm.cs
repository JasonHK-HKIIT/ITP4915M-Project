using System;
using System.Windows.Forms;

namespace Client
{
    public partial class QuotationDetailForm : Form
    {
        public QuotationDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        // Set fields for Edit
        public void SetFields(string customer, string product, int quantity, string validity, string status)
        {
            comboBox2.Text = customer;
            comboBox1.Text = product;
            textBox1.Text = quantity.ToString();
            textBox2.Text = validity;
            textBox3.Text = status;
        }

        // Expose properties for Add/Edit
        public string Customer => comboBox2.Text;
        public string Product => comboBox1.Text;
        public int Quantity => int.TryParse(textBox1.Text, out int v) ? v : 0;
        public string Validity => textBox2.Text;
        public string Status => textBox3.Text;
    }
}
