// DeliveryNoteForm.Designer.cs
namespace Client
{
    partial class DeliveryNoteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDeliveryID;
        private System.Windows.Forms.TextBox txtIssueDate;
        private System.Windows.Forms.TextBox txtShipDate;
        private System.Windows.Forms.TextBox txtCarrier;
        private System.Windows.Forms.TextBox txtTracking;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DataGridView dgvDeliveredItems;
        private System.Windows.Forms.Label lblDeliveryID;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblShipDate;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.Label lblTracking;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtDeliveryID = new TextBox();
            txtIssueDate = new TextBox();
            txtShipDate = new TextBox();
            txtCarrier = new TextBox();
            txtTracking = new TextBox();
            txtStatus = new TextBox();
            txtCustomerName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            dgvDeliveredItems = new DataGridView();
            lblDeliveryID = new Label();
            lblIssueDate = new Label();
            lblShipDate = new Label();
            lblCarrier = new Label();
            lblTracking = new Label();
            lblStatus = new Label();
            lblCustomerName = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lblShipmentID = new Label();
            txtShipmentID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDeliveredItems).BeginInit();
            SuspendLayout();
            // 
            // txtDeliveryID
            // 
            txtDeliveryID.Location = new Point(150, 44);
            txtDeliveryID.Name = "txtDeliveryID";
            txtDeliveryID.ReadOnly = true;
            txtDeliveryID.Size = new Size(147, 23);
            txtDeliveryID.TabIndex = 9;
            // 
            // txtIssueDate
            // 
            txtIssueDate.Location = new Point(150, 78);
            txtIssueDate.Name = "txtIssueDate";
            txtIssueDate.ReadOnly = true;
            txtIssueDate.Size = new Size(147, 23);
            txtIssueDate.TabIndex = 10;
            // 
            // txtShipDate
            // 
            txtShipDate.Location = new Point(150, 112);
            txtShipDate.Name = "txtShipDate";
            txtShipDate.ReadOnly = true;
            txtShipDate.Size = new Size(147, 23);
            txtShipDate.TabIndex = 11;
            // 
            // txtCarrier
            // 
            txtCarrier.Location = new Point(150, 153);
            txtCarrier.Name = "txtCarrier";
            txtCarrier.ReadOnly = true;
            txtCarrier.Size = new Size(147, 23);
            txtCarrier.TabIndex = 12;
            // 
            // txtTracking
            // 
            txtTracking.Location = new Point(150, 193);
            txtTracking.Name = "txtTracking";
            txtTracking.ReadOnly = true;
            txtTracking.Size = new Size(147, 23);
            txtTracking.TabIndex = 13;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(450, 47);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(171, 23);
            txtStatus.TabIndex = 14;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(450, 81);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Size = new Size(171, 23);
            txtCustomerName.TabIndex = 15;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(450, 115);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(171, 23);
            txtPhone.TabIndex = 16;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(450, 156);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(300, 60);
            txtAddress.TabIndex = 17;
            // 
            // dgvDeliveredItems
            // 
            dgvDeliveredItems.AllowUserToAddRows = false;
            dgvDeliveredItems.AllowUserToDeleteRows = false;
            dgvDeliveredItems.Location = new Point(20, 245);
            dgvDeliveredItems.Name = "dgvDeliveredItems";
            dgvDeliveredItems.ReadOnly = true;
            dgvDeliveredItems.Size = new Size(740, 180);
            dgvDeliveredItems.TabIndex = 18;
            // 
            // lblDeliveryID
            // 
            lblDeliveryID.Location = new Point(20, 47);
            lblDeliveryID.Name = "lblDeliveryID";
            lblDeliveryID.Size = new Size(100, 23);
            lblDeliveryID.TabIndex = 0;
            lblDeliveryID.Text = "Delivery Note ID:";
            lblDeliveryID.TextAlign = ContentAlignment.TopRight;
            // 
            // lblIssueDate
            // 
            lblIssueDate.Location = new Point(20, 81);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(100, 23);
            lblIssueDate.TabIndex = 1;
            lblIssueDate.Text = "Issue Date:";
            lblIssueDate.TextAlign = ContentAlignment.TopRight;
            // 
            // lblShipDate
            // 
            lblShipDate.Location = new Point(20, 118);
            lblShipDate.Name = "lblShipDate";
            lblShipDate.Size = new Size(100, 23);
            lblShipDate.TabIndex = 2;
            lblShipDate.Text = "Shipment Date:";
            lblShipDate.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCarrier
            // 
            lblCarrier.Location = new Point(20, 156);
            lblCarrier.Name = "lblCarrier";
            lblCarrier.Size = new Size(100, 23);
            lblCarrier.TabIndex = 3;
            lblCarrier.Text = "Carrier:";
            lblCarrier.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTracking
            // 
            lblTracking.Location = new Point(20, 193);
            lblTracking.Name = "lblTracking";
            lblTracking.Size = new Size(100, 23);
            lblTracking.TabIndex = 4;
            lblTracking.Text = "Tracking Number:";
            lblTracking.TextAlign = ContentAlignment.TopRight;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(329, 47);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";
            lblStatus.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Location = new Point(329, 81);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(100, 23);
            lblCustomerName.TabIndex = 6;
            lblCustomerName.Text = "Customer Name:";
            lblCustomerName.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(329, 118);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Phone:";
            lblPhone.TextAlign = ContentAlignment.TopRight;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(329, 156);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Address:";
            lblAddress.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 536);
            label1.Name = "label1";
            label1.Size = new Size(249, 15);
            label1.TabIndex = 19;
            label1.Text = "Customer Signature:   _________________________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(522, 536);
            label2.Name = "label2";
            label2.Size = new Size(185, 15);
            label2.TabIndex = 20;
            label2.Text = "Date:  _____________________________";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 565);
            label3.Name = "label3";
            label3.Size = new Size(228, 15);
            label3.TabIndex = 21;
            label3.Text = "Driver Signature:   _________________________";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(522, 565);
            label4.Name = "label4";
            label4.Size = new Size(185, 15);
            label4.TabIndex = 22;
            label4.Text = "Date:  _____________________________";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 227);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 23;
            label5.Text = "Delivered Item:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(312, 9);
            label6.Name = "label6";
            label6.Size = new Size(134, 25);
            label6.TabIndex = 24;
            label6.Text = "Delivery Note";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 440);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 25;
            label7.Text = "Remarks:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(20, 458);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(740, 62);
            richTextBox1.TabIndex = 26;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(48, 616);
            button1.Name = "button1";
            button1.Size = new Size(84, 23);
            button1.TabIndex = 27;
            button1.Text = "Print";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(189, 616);
            button2.Name = "button2";
            button2.Size = new Size(84, 23);
            button2.TabIndex = 28;
            button2.Text = "Export PDF";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(329, 616);
            button3.Name = "button3";
            button3.Size = new Size(84, 23);
            button3.TabIndex = 29;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            // 
            // lblShipmentID
            // 
            lblShipmentID.AutoSize = true;
            lblShipmentID.Location = new Point(470, 16);
            lblShipmentID.Name = "lblShipmentID";
            lblShipmentID.Size = new Size(75, 15);
            lblShipmentID.TabIndex = 30;
            lblShipmentID.Text = "Shipment ID:";
            // 
            // txtShipmentID
            // 
            txtShipmentID.Location = new Point(551, 11);
            txtShipmentID.Name = "txtShipmentID";
            txtShipmentID.ReadOnly = true;
            txtShipmentID.Size = new Size(100, 23);
            txtShipmentID.TabIndex = 31;
            // 
            // DeliveryNoteForm
            // 
            ClientSize = new Size(800, 664);
            Controls.Add(txtShipmentID);
            Controls.Add(lblShipmentID);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDeliveryID);
            Controls.Add(lblIssueDate);
            Controls.Add(lblShipDate);
            Controls.Add(lblCarrier);
            Controls.Add(lblTracking);
            Controls.Add(lblStatus);
            Controls.Add(lblCustomerName);
            Controls.Add(lblPhone);
            Controls.Add(lblAddress);
            Controls.Add(txtDeliveryID);
            Controls.Add(txtIssueDate);
            Controls.Add(txtShipDate);
            Controls.Add(txtCarrier);
            Controls.Add(txtTracking);
            Controls.Add(txtStatus);
            Controls.Add(txtCustomerName);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(dgvDeliveredItems);
            Name = "DeliveryNoteForm";
            Text = "Delivery Note";
            ((System.ComponentModel.ISupportInitialize)dgvDeliveredItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lblShipmentID;
        private TextBox txtShipmentID;
    }
}