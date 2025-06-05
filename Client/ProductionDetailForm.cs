using System;
using System.Windows.Forms;

namespace Client
{
    public partial class ProductionDetailForm : Form
    {
        public ProductionDetailForm()
        {
            InitializeComponent();
            button1.Click += ButtonSave_Click;   // Save
            button2.Click += ButtonCancel_Click; // Cancel
        }

        // For editing: Fill fields
        public void SetFields(string id, string customerOrder, string product, int quantity, DateTime scheduledDate, string status)
        {
            maskedTextBox1.Text = id;
            textBox2.Text = customerOrder;
            textBox3.Text = product;
            textBox4.Text = quantity.ToString();
            dateTimePicker1.Value = scheduledDate;
            comboBox1.Text = status;
        }

        // For retrieving values after OK
        public string ProductionOrderID => maskedTextBox1.Text;
        public string CustomerOrderID => textBox2.Text;
        public string ProductID => textBox3.Text;
        public int Quantity => int.TryParse(textBox4.Text, out int q) ? q : 0;
        public DateTime ScheduledDate => dateTimePicker1.Value;
        public string Status => comboBox1.Text;

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ProductionDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
