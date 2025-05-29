using System;
using System.Windows.Forms;

namespace SmileSunshineToy
{
    public partial class DeliveryNoteForm : Form
    {
        public DeliveryNoteForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delivery note generated.");
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search for order.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeliveryNoteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
