namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new MenuStrip();
            this.menuItemProduct = new ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new ToolStripMenuItem();
            this.suppliersManagementToolStripMenuItem = new ToolStripMenuItem();
            this.dispatchToolStripMenuItem = new ToolStripMenuItem();
            this.MenuItemGoodRecieved = new ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new Size(20, 20);
            this.menu.Items.AddRange(new ToolStripItem[] { this.menuItemProduct, this.dispatchToolStripMenuItem, this.maintenanceToolStripMenuItem });
            this.menu.Location = new Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = ToolStripRenderMode.System;
            this.menu.Size = new Size(800, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemProduct
            // 
            this.menuItemProduct.Name = "menuItemProduct";
            this.menuItemProduct.Size = new Size(78, 24);
            this.menuItemProduct.Text = "Product";
            this.menuItemProduct.Click += this.MenuItemProduct_Click;
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.suppliersManagementToolStripMenuItem });
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new Size(112, 24);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // suppliersManagementToolStripMenuItem
            // 
            this.suppliersManagementToolStripMenuItem.Name = "suppliersManagementToolStripMenuItem";
            this.suppliersManagementToolStripMenuItem.Size = new Size(254, 26);
            this.suppliersManagementToolStripMenuItem.Text = "Suppliers Management";
            // 
            // dispatchToolStripMenuItem
            // 
            this.dispatchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.MenuItemGoodRecieved });
            this.dispatchToolStripMenuItem.Name = "dispatchToolStripMenuItem";
            this.dispatchToolStripMenuItem.Size = new Size(83, 24);
            this.dispatchToolStripMenuItem.Text = "Dispatch";
            // 
            // MenuItemGoodRecieved
            // 
            this.MenuItemGoodRecieved.Name = "MenuItemGoodRecieved";
            this.MenuItemGoodRecieved.Size = new Size(224, 26);
            this.MenuItemGoodRecieved.Text = "Good Recieved";
            this.MenuItemGoodRecieved.Click += this.MenuItemGoodRecieved_Click;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.menu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Smile & Sunshine Toy";
            this.WindowState = FormWindowState.Maximized;
            this.Load += this.MainForm_Load;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem maintenanceToolStripMenuItem;
        private ToolStripMenuItem suppliersManagementToolStripMenuItem;
        private ToolStripMenuItem menuItemProduct;
        private ToolStripMenuItem dispatchToolStripMenuItem;
        private ToolStripMenuItem MenuItemGoodRecieved;
    }
}