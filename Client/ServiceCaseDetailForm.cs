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
    public partial class ServiceCaseDetailForm : Form
    {
        public ServiceCaseDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void SetFields(string caseID, string customer, string order, string caseType, string status, string assignedTo)
        {
            comboBox1.Text = caseID;
            comboBox2.Text = customer;
            textBox1.Text = order;
            textBox2.Text = caseType;
            comboBox3.Text = status;
            comboBox4.Text = assignedTo;
        }

        public string CaseID => comboBox1.Text;
        public string Customer => comboBox2.Text;
        public string Order => textBox1.Text;
        public string CaseType => textBox2.Text;
        public string Status => comboBox3.Text;
        public string AssignedTo => comboBox4.Text;
    }

}
