using System.Windows.Forms;
using System;

namespace Client
{
    partial class GoodsReceivedForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGoodsReceivedID, lblPurchaseOrderID, lblReceivedDate, lblWarehouseID, lblMaterialList;
        private TextBox txtGoodsReceivedID, txtPurchaseOrderID, txtWarehouseID;
        private DateTimePicker dtpReceivedDate;
        private Button btnSave, btnSearchPO, btnClose;
        private DataGridView dgvMaterialList;

        private void InitializeComponent()
        {
            this.lblGoodsReceivedID = new System.Windows.Forms.Label();
            this.lblPurchaseOrderID = new System.Windows.Forms.Label();
            this.lblReceivedDate = new System.Windows.Forms.Label();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.lblMaterialList = new System.Windows.Forms.Label();
            this.txtGoodsReceivedID = new System.Windows.Forms.TextBox();
            this.txtPurchaseOrderID = new System.Windows.Forms.TextBox();
            this.txtWarehouseID = new System.Windows.Forms.TextBox();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearchPO = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvMaterialList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialList)).BeginInit();
            this.SuspendLayout();

            this.lblGoodsReceivedID.Location = new System.Drawing.Point(30, 30);
            this.lblGoodsReceivedID.Name = "lblGoodsReceivedID";
            this.lblGoodsReceivedID.Size = new System.Drawing.Size(100, 23);
            this.lblGoodsReceivedID.TabIndex = 0;
            this.lblGoodsReceivedID.Text = "Goods Received ID:";
 
            this.lblPurchaseOrderID.Location = new System.Drawing.Point(30, 60);
            this.lblPurchaseOrderID.Name = "lblPurchaseOrderID";
            this.lblPurchaseOrderID.Size = new System.Drawing.Size(100, 23);
            this.lblPurchaseOrderID.TabIndex = 2;
            this.lblPurchaseOrderID.Text = "Purchase Order ID:";
 
            this.lblReceivedDate.Location = new System.Drawing.Point(30, 90);
            this.lblReceivedDate.Name = "lblReceivedDate";
            this.lblReceivedDate.Size = new System.Drawing.Size(100, 23);
            this.lblReceivedDate.TabIndex = 4;
            this.lblReceivedDate.Text = "Received Date:";
 
            this.lblWarehouseID.Location = new System.Drawing.Point(30, 120);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(100, 23);
            this.lblWarehouseID.TabIndex = 6;
            this.lblWarehouseID.Text = "Warehouse ID:";

            this.lblMaterialList.Location = new System.Drawing.Point(30, 160);
            this.lblMaterialList.Name = "lblMaterialList";
            this.lblMaterialList.Size = new System.Drawing.Size(100, 23);
            this.lblMaterialList.TabIndex = 8;
            this.lblMaterialList.Text = "Materials Received:";
    
            this.txtGoodsReceivedID.Location = new System.Drawing.Point(170, 27);
            this.txtGoodsReceivedID.Name = "txtGoodsReceivedID";
            this.txtGoodsReceivedID.Size = new System.Drawing.Size(100, 29);
            this.txtGoodsReceivedID.TabIndex = 1;
         
            this.txtPurchaseOrderID.Location = new System.Drawing.Point(170, 57);
            this.txtPurchaseOrderID.Name = "txtPurchaseOrderID";
            this.txtPurchaseOrderID.Size = new System.Drawing.Size(100, 29);
            this.txtPurchaseOrderID.TabIndex = 3;
           
            this.txtWarehouseID.Location = new System.Drawing.Point(170, 117);
            this.txtWarehouseID.Name = "txtWarehouseID";
            this.txtWarehouseID.Size = new System.Drawing.Size(100, 29);
            this.txtWarehouseID.TabIndex = 7;
           
            this.dtpReceivedDate.Location = new System.Drawing.Point(170, 87);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size(200, 29);
            this.dtpReceivedDate.TabIndex = 5;
            
            this.btnSave.Location = new System.Drawing.Point(30, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
           
            this.btnSearchPO.Location = new System.Drawing.Point(350, 55);
            this.btnSearchPO.Name = "btnSearchPO";
            this.btnSearchPO.Size = new System.Drawing.Size(75, 23);
            this.btnSearchPO.TabIndex = 10;
            this.btnSearchPO.Text = "Search PO";
            this.btnSearchPO.Click += new System.EventHandler(this.btnSearchPO_Click);
            
            this.btnClose.Location = new System.Drawing.Point(120, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            this.dgvMaterialList.ColumnHeadersHeight = 34;
            this.dgvMaterialList.Location = new System.Drawing.Point(30, 190);
            this.dgvMaterialList.Name = "dgvMaterialList";
            this.dgvMaterialList.ReadOnly = true;
            this.dgvMaterialList.RowHeadersWidth = 62;
            this.dgvMaterialList.Size = new System.Drawing.Size(420, 120);
            this.dgvMaterialList.TabIndex = 9;
            
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.lblGoodsReceivedID);
            this.Controls.Add(this.txtGoodsReceivedID);
            this.Controls.Add(this.lblPurchaseOrderID);
            this.Controls.Add(this.txtPurchaseOrderID);
            this.Controls.Add(this.lblReceivedDate);
            this.Controls.Add(this.dtpReceivedDate);
            this.Controls.Add(this.lblWarehouseID);
            this.Controls.Add(this.txtWarehouseID);
            this.Controls.Add(this.lblMaterialList);
            this.Controls.Add(this.dgvMaterialList);
            this.Controls.Add(this.btnSearchPO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Name = "GoodsReceivedForm";
            this.Text = "Goods Received";
            this.Load += new System.EventHandler(this.GoodsReceivedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
