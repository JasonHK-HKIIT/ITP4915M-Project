using System.Windows.Forms;
using System;

namespace SmileSunshineToy
{
    partial class DeliveryNoteForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDeliveryNoteID, lblCustomerOrderID, lblDeliveryDate, lblCarrier, lblTrackingNumber, lblStatus;
        private TextBox txtDeliveryNoteID, txtCustomerOrderID, txtCarrier, txtTrackingNumber, txtStatus;
        private DateTimePicker dtpDeliveryDate;
        private Button btnGenerate, btnSearchOrder, btnClose;

        private void InitializeComponent()
        {
            this.lblDeliveryNoteID = new System.Windows.Forms.Label();
            this.lblCustomerOrderID = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.lblTrackingNumber = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtDeliveryNoteID = new System.Windows.Forms.TextBox();
            this.txtCustomerOrderID = new System.Windows.Forms.TextBox();
            this.txtCarrier = new System.Windows.Forms.TextBox();
            this.txtTrackingNumber = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSearchOrder = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDeliveryNoteID
            // 
            this.lblDeliveryNoteID.Location = new System.Drawing.Point(30, 30);
            this.lblDeliveryNoteID.Name = "lblDeliveryNoteID";
            this.lblDeliveryNoteID.Size = new System.Drawing.Size(100, 23);
            this.lblDeliveryNoteID.TabIndex = 0;
            this.lblDeliveryNoteID.Text = "Delivery Note ID:";
            // 
            // lblCustomerOrderID
            // 
            this.lblCustomerOrderID.Location = new System.Drawing.Point(30, 60);
            this.lblCustomerOrderID.Name = "lblCustomerOrderID";
            this.lblCustomerOrderID.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerOrderID.TabIndex = 2;
            this.lblCustomerOrderID.Text = "Customer Order ID:";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.Location = new System.Drawing.Point(30, 90);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(100, 23);
            this.lblDeliveryDate.TabIndex = 4;
            this.lblDeliveryDate.Text = "Delivery Date:";
            // 
            // lblCarrier
            // 
            this.lblCarrier.Location = new System.Drawing.Point(30, 120);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(100, 23);
            this.lblCarrier.TabIndex = 6;
            this.lblCarrier.Text = "Carrier:";
            // 
            // lblTrackingNumber
            // 
            this.lblTrackingNumber.Location = new System.Drawing.Point(30, 150);
            this.lblTrackingNumber.Name = "lblTrackingNumber";
            this.lblTrackingNumber.Size = new System.Drawing.Size(100, 23);
            this.lblTrackingNumber.TabIndex = 8;
            this.lblTrackingNumber.Text = "Tracking Number:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(30, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // txtDeliveryNoteID
            // 
            this.txtDeliveryNoteID.Location = new System.Drawing.Point(160, 27);
            this.txtDeliveryNoteID.Name = "txtDeliveryNoteID";
            this.txtDeliveryNoteID.Size = new System.Drawing.Size(100, 29);
            this.txtDeliveryNoteID.TabIndex = 1;
            // 
            // txtCustomerOrderID
            // 
            this.txtCustomerOrderID.Location = new System.Drawing.Point(160, 57);
            this.txtCustomerOrderID.Name = "txtCustomerOrderID";
            this.txtCustomerOrderID.Size = new System.Drawing.Size(100, 29);
            this.txtCustomerOrderID.TabIndex = 3;
            // 
            // txtCarrier
            // 
            this.txtCarrier.Location = new System.Drawing.Point(160, 117);
            this.txtCarrier.Name = "txtCarrier";
            this.txtCarrier.Size = new System.Drawing.Size(100, 29);
            this.txtCarrier.TabIndex = 7;
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Location = new System.Drawing.Point(160, 147);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(100, 29);
            this.txtTrackingNumber.TabIndex = 9;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(160, 177);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 29);
            this.txtStatus.TabIndex = 11;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(160, 87);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(200, 29);
            this.dtpDeliveryDate.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(30, 220);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(85, 23);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.Location = new System.Drawing.Point(320, 55);
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSearchOrder.TabIndex = 12;
            this.btnSearchOrder.Text = "Search Order";
            this.btnSearchOrder.Click += new System.EventHandler(this.btnSearchOrder_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(140, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DeliveryNoteForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 270);
            this.Controls.Add(this.lblDeliveryNoteID);
            this.Controls.Add(this.txtDeliveryNoteID);
            this.Controls.Add(this.lblCustomerOrderID);
            this.Controls.Add(this.txtCustomerOrderID);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.lblCarrier);
            this.Controls.Add(this.txtCarrier);
            this.Controls.Add(this.lblTrackingNumber);
            this.Controls.Add(this.txtTrackingNumber);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnSearchOrder);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClose);
            this.Name = "DeliveryNoteForm";
            this.Text = "Generate Delivery Note";
            this.Load += new System.EventHandler(this.DeliveryNoteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
