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
    public partial class SupplierDetailForm : Form
    {
        public SupplierDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }
        public void SetFields(string id, string name, string contact)
        {
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = contact;
        }
        public string SupplierID => textBox1.Text;
        public string SupplierName => textBox2.Text;
        public string Contact => textBox3.Text;
    }

}
