using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class MF1 : Form
    {
        public MF1()
        {
            InitializeComponent();
        }

        private void MF1_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            var loginForm = new LoginForm();
            loginForm.ShowDialog();

            if (loginForm.DialogResult == DialogResult.OK)
            {
                this.Visible = true;
                Program.User = loginForm.User;

                // Apply font style
                Font font;
                try { font = new Font("Helvetica", 10); }
                catch { font = new Font("Segoe UI", 10); }
                ApplyFont(this, font);

                // Set background image
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is MdiClient client)
                    {
                        client.BackgroundImage = Properties.Resources.Background;
                        client.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = font;
                if (ctrl.HasChildren)
                    ApplyFont(ctrl, font);
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Sales & Marketing Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is CustomerForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var customerForm = new CustomerForm();
            customerForm.MdiParent = this;
            customerForm.Show();
        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Sales & Marketing Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is CustomerForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var customerForm = new CustomerForm();
            customerForm.MdiParent = this;
            customerForm.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Production Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is SupplierForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var supplierForm = new SupplierForm();
            supplierForm.MdiParent = this;
            supplierForm.Show();
        }

        private void customerOrdersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Sales & Marketing Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is OrderForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var orderForm = new OrderForm();
            orderForm.MdiParent = this;
            orderForm.Show();
        }

        private void serviceCasesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Customer Service Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is ServiceCaseForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var serviceCaseForm = new ServiceCaseForm();
            serviceCaseForm.MdiParent = this;
            serviceCaseForm.Show();
        }

        private void productDesignRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "R&D Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is DesignRequestForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var designRequestForm = new DesignRequestForm();
            designRequestForm.MdiParent = this;
            designRequestForm.Show();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "R&D Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is ProductForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var productForm = new ProductForm();
            productForm.MdiParent = this;
            productForm.Show();
        }

        private void quotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Sales & Marketing Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is QuotationForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var quotationForm = new QuotationForm();
            quotationForm.MdiParent = this;
            quotationForm.Show();
        }

        private void productionOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Production Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is ProductionForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var productionForm = new ProductionForm();
            productionForm.MdiParent = this;
            productionForm.Show();
        }

        private void shipmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Production Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is ShipmentForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var shipmentForm = new ShipmentForm();
            shipmentForm.MdiParent = this;
            shipmentForm.Show();
        }

        private void inventoryControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Supply Chain Management Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is InventoryForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var inventoryForm = new InventoryForm();
            inventoryForm.MdiParent = this;
            inventoryForm.Show();
        }

        private void adminUserManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role != "Admin")
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is AdminForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var adminForm = new AdminForm();
            adminForm.MdiParent = this;
            adminForm.Show();
        }

        private void purchaseOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.User.Role != "Supply Chain Management Department") && (Program.User.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var child in this.MdiChildren)
            {
                if (child is PurchaseOrderForm)
                {
                    child.MdiParent = this;
                    child.Focus();
                    return;
                }
            }

            var purchaseOrderForm = new PurchaseOrderForm();
            purchaseOrderForm.MdiParent = this;
            purchaseOrderForm.Show();
        }

        private void MF1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.User == null) return;

            if (MessageBox.Show("Are you sure to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Program.User = null;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
