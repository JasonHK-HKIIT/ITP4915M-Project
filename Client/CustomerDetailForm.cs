using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = phone;
            textBox4.Text = address;
        }
        public string CustomerID => textBox1.Text;
        public string CustomerName => textBox2.Text;
        public string CustomerPhone => textBox3.Text;
        public string CustomerAddress => textBox4.Text;
    }

}
