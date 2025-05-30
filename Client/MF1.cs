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
    public partial class MF1 : Form
    {
        public MF1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void MF1_Load(object sender, EventArgs e)
        {

        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Only allow one CustomerForm open at a time
            foreach (Form child in this.MdiChildren)
            {
                if (child is CustomerForm)
                {
                    child.Activate();
                    return;
                }
            }
            var customerForm = new CustomerForm();
            customerForm.MdiParent = this;
            customerForm.Show();
        }
    }
}
