namespace Client
{
    partial class PurchaseOrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelPOID;
        private System.Windows.Forms.TextBox textBoxPOID;
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
            this.labelPOID = new System.Windows.Forms.Label();
            this.textBoxPOID = new System.Windows.Forms.TextBox();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.dateTimePickerOrder = new System.Windows.Forms.DateTimePicker();
            this.labelDeliveryDate = new System.Windows.Forms.Label();
            this.dateTimePickerDelivery = new System.Windows.Forms.DateTimePicker();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelPOStatus = new System.Windows.Forms.Label();
            this.comboBoxPOStatus = new System.Windows.Forms.ComboBox();
            this.labelLineItems = new System.Windows.Forms.Label();
            this.dataGridViewLineItems = new System.Windows.Forms.DataGridView();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.buttonDeleteLine = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineItems)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPOID
            // 
            this.labelPOID.AutoSize = true;
            this.labelPOID.Location = new System.Drawing.Point(35, 24);
            this.labelPOID.Name = "labelPOID";
            this.labelPOID.Size = new System.Drawing.Size(46, 17);
            this.labelPOID.TabIndex = 0;
            this.labelPOID.Text = "PO ID:";
            // 
            // textBoxPOID
            // 
            this.textBoxPOID.Location = new System.Drawing.Point(150, 21);
            this.textBoxPOID.Name = "textBoxPOID";
            this.textBoxPOID.Size = new System.Drawing.Size(250, 22);
            this.textBoxPOID.TabIndex = 1;
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Location = new System.Drawing.Point(35, 62);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(61, 17);
            this.labelSupplier.TabIndex = 2;
            this.labelSupplier.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(150, 59);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(250, 24);
            this.comboBoxSupplier.TabIndex = 3;
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new System.Drawing.Point(35, 102);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(80, 17);
            this.labelOrderDate.TabIndex = 4;
            this.labelOrderDate.Text = "Order Date:";
            // 
            // dateTimePickerOrder
            // 
            this.dateTimePickerOrder.Location = new System.Drawing.Point(150, 99);
            this.dateTimePickerOrder.Name = "dateTimePickerOrder";
            this.dateTimePickerOrder.Size = new System.Drawing.Size(250, 22);
            this.dateTimePickerOrder.TabIndex = 5;
            // 
            // labelDeliveryDate
            // 
            this.labelDeliveryDate.AutoSize = true;
            this.labelDeliveryDate.Location = new System.Drawing.Point(35, 140);
            this.labelDeliveryDate.Name = "labelDeliveryDate";
            this.labelDeliveryDate.Size = new System.Drawing.Size(97, 17);
            this.labelDeliveryDate.TabIndex = 6;
            this.labelDeliveryDate.Text = "Delivery Date:";
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Location = new System.Drawing.Point(150, 137);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new System.Drawing.Size(250, 22);
            this.dateTimePickerDelivery.TabIndex = 7;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(35, 178);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(52, 17);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(150, 175);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(250, 24);
            this.comboBoxStatus.TabIndex = 9;
            // 
            // labelPOStatus
            // 
            this.labelPOStatus.AutoSize = true;
            this.labelPOStatus.Location = new System.Drawing.Point(35, 216);
            this.labelPOStatus.Name = "labelPOStatus";
            this.labelPOStatus.Size = new System.Drawing.Size(73, 17);
            this.labelPOStatus.TabIndex = 10;
            this.labelPOStatus.Text = "PO Status:";
            // 
            // comboBoxPOStatus
            // 
            this.comboBoxPOStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPOStatus.FormattingEnabled = true;
            this.comboBoxPOStatus.Location = new System.Drawing.Point(150, 213);
            this.comboBoxPOStatus.Name = "comboBoxPOStatus";
            this.comboBoxPOStatus.Size = new System.Drawing.Size(250, 24);
            this.comboBoxPOStatus.TabIndex = 11;
            // 
            // labelLineItems
            // 
            this.labelLineItems.AutoSize = true;
            this.labelLineItems.Location = new System.Drawing.Point(35, 254);
            this.labelLineItems.Name = "labelLineItems";
            this.labelLineItems.Size = new System.Drawing.Size(137, 17);
            this.labelLineItems.TabIndex = 12;
            this.labelLineItems.Text = "Line Items (Materials)";
            // 
            // dataGridViewLineItems
            // 
            this.dataGridViewLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineItems.Location = new System.Drawing.Point(38, 274);
            this.dataGridViewLineItems.Name = "dataGridViewLineItems";
            this.dataGridViewLineItems.RowHeadersWidth = 51;
            this.dataGridViewLineItems.RowTemplate.Height = 24;
            this.dataGridViewLineItems.Size = new System.Drawing.Size(550, 150);
            this.dataGridViewLineItems.TabIndex = 13;
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Location = new System.Drawing.Point(38, 430);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(100, 28);
            this.buttonAddLine.TabIndex = 14;
            this.buttonAddLine.Text = "Add Line";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteLine
            // 
            this.buttonDeleteLine.Location = new System.Drawing.Point(144, 430);
            this.buttonDeleteLine.Name = "buttonDeleteLine";
            this.buttonDeleteLine.Size = new System.Drawing.Size(100, 28);
            this.buttonDeleteLine.TabIndex = 15;
            this.buttonDeleteLine.Text = "Delete Line";
            this.buttonDeleteLine.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(388, 480);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 32);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(498, 480);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 32);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // PurchaseOrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 534);
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
            this.Controls.Add(this.textBoxPOID);
            this.Controls.Add(this.labelPOID);
            this.Name = "PurchaseOrderDetailForm";
            this.Text = "PurchaseOrderDetailForm";
            this.Load += new System.EventHandler(this.PurchaseOrderDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
