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
    public partial class PurchaseOrderDetailForm : Form
    {
        public PurchaseOrderDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void SetFields(string poNumber, string supplier, DateTime poDate, string status)
        {
            textBox1.Text = poNumber;
            comboBox1.Text = supplier;
            dateTimePicker1.Value = poDate;
            comboBox2.Text = status;
        }

        public string PONumber => textBox1.Text;
        public string Supplier => comboBox1.Text;
        public DateTime PODate => dateTimePicker1.Value;
        public string Status => comboBox2.Text;
    }

}
