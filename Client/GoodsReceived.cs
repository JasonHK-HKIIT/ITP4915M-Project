using System;
using System.Windows.Forms;

namespace Client
{
    public partial class GoodsReceivedForm : Form
    {
        public GoodsReceivedForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goods received record saved.");
        }

        private void btnSearchPO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search for purchase order.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoodsReceivedForm_Load(object sender, EventArgs e)
        {

        }
    }
}
