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
    public partial class InventoryDetailForm : Form
    {
        public InventoryDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void SetFields(string warehouse, string product, int qty, int reorder,int min)
        {
            comboBox1.Text = warehouse;
            comboBox2.Text = product;
            textBox1.Text = qty.ToString();
            textBox2.Text = reorder.ToString();
            textBox3.Text = min.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string Warehouse => comboBox1.Text;
        public string Product => comboBox2.Text;
        public int Quantity => int.TryParse(textBox1.Text, out int q) ? q : 0;
        public int ReorderPoint => int.TryParse(textBox2.Text, out int r) ? r : 0;
        public int MinimumStock => int.TryParse(textBox3.Text, out int min) ? min : 0;
    }

}
