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
    public partial class ShipmentDetailForm : Form
    {
        public ShipmentDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void SetFields(string id, string order, string carrier, string tracking, DateTime date, string status,DateTime issueDate)
        {
            textBox1.Text = id;
            textBox2.Text = order;
            textBox3.Text = carrier;
            textBox4.Text = tracking;
            dateTimePicker1.Value = date;
            comboBox1.Text = status;
            dateTimePicker2.Value = issueDate;
        }

        private void ShipmentDetailForm_Load(object sender, EventArgs e)
        {

        }

        public string ShipmentID => textBox1.Text;
        public string CustomerOrderID => textBox2.Text;
        public string Carrier => textBox3.Text;
        public string TrackingNumber => textBox4.Text;
        public DateTime ShipmentDate => dateTimePicker1.Value;
        public string Status => comboBox1.Text;
        public DateTime IssueDate => dateTimePicker2.Value;
    }
}