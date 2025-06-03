using System;
using System.Windows.Forms;

namespace Client
{
    public partial class ProductDetailForm : Form
    {
        public ProductDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };    // Save
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };// Cancel
        }

        // Use this to prefill for Edit
        public void SetFields(string linkedDesignRequest, string productName, string productType, string unitPrice, string specifications)
        {
            comboBox1.Text = linkedDesignRequest;
            textBox2.Text = productName;
            textBox3.Text = productType;
            textBox4.Text = unitPrice;
            textBox5.Text = specifications;
        }

        // Use these to retrieve data after Save
        public string LinkedDesignRequest => comboBox1.Text;
        public string ProductName => textBox2.Text;
        public string ProductType => textBox3.Text;
        public string UnitPrice => textBox4.Text;
        public string Specifications => textBox5.Text;
    }
}
