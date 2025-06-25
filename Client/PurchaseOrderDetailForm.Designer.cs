namespace Client
{
    partial class PurchaseOrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelPOID;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrder;
        private System.Windows.Forms.Label labelDeliveryDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelivery;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelPOStatus;
        private System.Windows.Forms.ComboBox comboBoxPOStatus;
        private System.Windows.Forms.Label labelLineItems;
        private System.Windows.Forms.DataGridView dataGridViewLineItems;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button buttonDeleteLine;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

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

        private void InitializeComponent()
        {
            this.labelPOID = new Label();
            this.labelSupplier = new Label();
            this.comboBoxSupplier = new ComboBox();
            this.labelOrderDate = new Label();
            this.dateTimePickerOrder = new DateTimePicker();
            this.labelDeliveryDate = new Label();
            this.dateTimePickerDelivery = new DateTimePicker();
            this.labelStatus = new Label();
            this.comboBoxStatus = new ComboBox();
            this.labelPOStatus = new Label();
            this.comboBoxPOStatus = new ComboBox();
            this.labelLineItems = new Label();
            this.dataGridViewLineItems = new DataGridView();
            this.buttonAddLine = new Button();
            this.buttonDeleteLine = new Button();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.maskedTextBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewLineItems).BeginInit();
            this.SuspendLayout();
            // 
            // labelPOID
            // 
            this.labelPOID.AutoSize = true;
            this.labelPOID.Location = new Point(40, 28);
            this.labelPOID.Margin = new Padding(4, 0, 4, 0);
            this.labelPOID.Name = "labelPOID";
            this.labelPOID.Size = new Size(52, 19);
            this.labelPOID.TabIndex = 0;
            this.labelPOID.Text = "PO ID:";
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Location = new Point(40, 74);
            this.labelSupplier.Margin = new Padding(4, 0, 4, 0);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new Size(70, 19);
            this.labelSupplier.TabIndex = 2;
            this.labelSupplier.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new Point(169, 69);
            this.comboBoxSupplier.Margin = new Padding(4);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new Size(281, 27);
            this.comboBoxSupplier.TabIndex = 3;
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new Point(40, 121);
            this.labelOrderDate.Margin = new Padding(4, 0, 4, 0);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new Size(90, 19);
            this.labelOrderDate.TabIndex = 4;
            this.labelOrderDate.Text = "Order Date:";
            // 
            // dateTimePickerOrder
            // 
            this.dateTimePickerOrder.Location = new Point(169, 118);
            this.dateTimePickerOrder.Margin = new Padding(4);
            this.dateTimePickerOrder.Name = "dateTimePickerOrder";
            this.dateTimePickerOrder.Size = new Size(281, 27);
            this.dateTimePickerOrder.TabIndex = 5;
            // 
            // labelDeliveryDate
            // 
            this.labelDeliveryDate.AutoSize = true;
            this.labelDeliveryDate.Location = new Point(40, 166);
            this.labelDeliveryDate.Margin = new Padding(4, 0, 4, 0);
            this.labelDeliveryDate.Name = "labelDeliveryDate";
            this.labelDeliveryDate.Size = new Size(105, 19);
            this.labelDeliveryDate.TabIndex = 6;
            this.labelDeliveryDate.Text = "Delivery Date:";
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Location = new Point(169, 162);
            this.dateTimePickerDelivery.Margin = new Padding(4);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new Size(281, 27);
            this.dateTimePickerDelivery.TabIndex = 7;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new Point(40, 211);
            this.labelStatus.Margin = new Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new Size(55, 19);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] { "Pending", "Approved", "Shipped", "Delivered", "Cancelled", "Ordered" });
            this.comboBoxStatus.Location = new Point(169, 207);
            this.comboBoxStatus.Margin = new Padding(4);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new Size(281, 27);
            this.comboBoxStatus.TabIndex = 9;
            // 
            // labelPOStatus
            // 
            this.labelPOStatus.AutoSize = true;
            this.labelPOStatus.Location = new Point(40, 256);
            this.labelPOStatus.Margin = new Padding(4, 0, 4, 0);
            this.labelPOStatus.Name = "labelPOStatus";
            this.labelPOStatus.Size = new Size(80, 19);
            this.labelPOStatus.TabIndex = 10;
            this.labelPOStatus.Text = "PO Status:";
            // 
            // comboBoxPOStatus
            // 
            this.comboBoxPOStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPOStatus.FormattingEnabled = true;
            this.comboBoxPOStatus.Items.AddRange(new object[] { "Processing", "In Transit" });
            this.comboBoxPOStatus.Location = new Point(169, 254);
            this.comboBoxPOStatus.Margin = new Padding(4);
            this.comboBoxPOStatus.Name = "comboBoxPOStatus";
            this.comboBoxPOStatus.Size = new Size(281, 27);
            this.comboBoxPOStatus.TabIndex = 11;
            // 
            // labelLineItems
            // 
            this.labelLineItems.AutoSize = true;
            this.labelLineItems.Location = new Point(40, 302);
            this.labelLineItems.Margin = new Padding(4, 0, 4, 0);
            this.labelLineItems.Name = "labelLineItems";
            this.labelLineItems.Size = new Size(158, 19);
            this.labelLineItems.TabIndex = 12;
            this.labelLineItems.Text = "Line Items (Materials)";
            // 
            // dataGridViewLineItems
            // 
            this.dataGridViewLineItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineItems.Location = new Point(43, 325);
            this.dataGridViewLineItems.Margin = new Padding(4);
            this.dataGridViewLineItems.Name = "dataGridViewLineItems";
            this.dataGridViewLineItems.RowHeadersWidth = 51;
            this.dataGridViewLineItems.RowTemplate.Height = 24;
            this.dataGridViewLineItems.Size = new Size(619, 178);
            this.dataGridViewLineItems.TabIndex = 13;
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Location = new Point(43, 511);
            this.buttonAddLine.Margin = new Padding(4);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new Size(113, 33);
            this.buttonAddLine.TabIndex = 14;
            this.buttonAddLine.Text = "Add Line";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteLine
            // 
            this.buttonDeleteLine.Location = new Point(162, 511);
            this.buttonDeleteLine.Margin = new Padding(4);
            this.buttonDeleteLine.Name = "buttonDeleteLine";
            this.buttonDeleteLine.Size = new Size(113, 33);
            this.buttonDeleteLine.TabIndex = 15;
            this.buttonDeleteLine.Text = "Delete Line";
            this.buttonDeleteLine.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new Point(437, 570);
            this.buttonSave.Margin = new Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new Size(101, 38);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new Point(560, 570);
            this.buttonCancel.Margin = new Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(101, 38);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new Point(169, 25);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new Size(281, 27);
            this.maskedTextBox1.TabIndex = 18;
            // 
            // PurchaseOrderDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(713, 634);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDeleteLine);
            this.Controls.Add(this.buttonAddLine);
            this.Controls.Add(this.dataGridViewLineItems);
            this.Controls.Add(this.labelLineItems);
            this.Controls.Add(this.comboBoxPOStatus);
            this.Controls.Add(this.labelPOStatus);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.dateTimePickerDelivery);
            this.Controls.Add(this.labelDeliveryDate);
            this.Controls.Add(this.dateTimePickerOrder);
            this.Controls.Add(this.labelOrderDate);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.labelSupplier);
            this.Controls.Add(this.labelPOID);
            this.Margin = new Padding(4);
            this.Name = "PurchaseOrderDetailForm";
            this.Text = "PurchaseOrderDetailForm";
      
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewLineItems).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox maskedTextBox1;
    }
}
