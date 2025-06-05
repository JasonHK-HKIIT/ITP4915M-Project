using System;
using System.Windows.Forms;

namespace Client
{
    public partial class CustomerDetailForm : Form
    {
        public CustomerDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void SetFields(string id, string name, string phone, string address)
        {
            maskedTextBox1.Text = id;     // Use MaskedTextBox for CustomerID
            textBox2.Text = name;
            textBox3.Text = phone;
            textBox4.Text = address;
        }

        private void CustomerDetailForm_Load(object sender, EventArgs e)
        {

        }

        public string CustomerID => maskedTextBox1.Text;
        public string CustomerName => textBox2.Text;
        public string CustomerPhone => textBox3.Text;
        public string CustomerAddress => textBox4.Text;
    }
}
