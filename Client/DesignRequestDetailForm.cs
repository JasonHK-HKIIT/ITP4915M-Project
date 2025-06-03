using System;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestDetailForm : Form
    {
        public DesignRequestDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };    // Save
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };// Cancel
        }

        // For Edit
        public void SetFields(string customer, string manager, string specs)
        {
            comboBox2.Text = customer;
            comboBox1.Text = manager;
            textBox3.Text = specs;
        }

        // For Add/Edit
        public string Customer => comboBox2.Text;
        public string AssignedManager => comboBox1.Text;
        public string Specifications => textBox3.Text;
    }
}
