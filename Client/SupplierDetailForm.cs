using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class SupplierDetailForm : Form
    {
        public SupplierDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Active");
            comboBox1.Items.Add("Inactive");
            comboBox1.SelectedIndex = 0;

        }
        public void SetFields(
    string id,
    string name,
    string contact,
    string phone,
    string email,
    string address,
    string country,
    string status
)
        {
            maskedTextBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = contact;
            textBox4.Text = phone;
            textBox5.Text = email;
            textBox6.Text = address;
            textBox7.Text = country;
            comboBox1.Text = status;
        }

        private void SupplierDetailForm_Load(object sender, EventArgs e)
        {
         
        }

        // Properties to retrieve form data
        public string SupplierID => maskedTextBox1.Text;
        public string SupplierName => textBox2.Text;
        public string ContactPerson => textBox3.Text;
        public string PhoneNumber => textBox4.Text;
        public string Email => textBox5.Text;
        public string Address => textBox6.Text;
        public string Country => textBox7.Text;
        public string Status => comboBox1.Text;


    }
}
