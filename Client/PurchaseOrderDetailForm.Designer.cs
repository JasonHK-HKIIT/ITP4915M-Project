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
            labelPOID = new Label();
            labelSupplier = new Label();
            comboBoxSupplier = new ComboBox();
            labelOrderDate = new Label();
            dateTimePickerOrder = new DateTimePicker();
            labelDeliveryDate = new Label();
            dateTimePickerDelivery = new DateTimePicker();
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelLineItems = new Label();
            dataGridViewLineItems = new DataGridView();
            buttonAddLine = new Button();
            buttonDeleteLine = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            maskedTextBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineItems).BeginInit();
            SuspendLayout();
            // 
            // labelPOID
            // 
            labelPOID.AutoSize = true;
            labelPOID.Location = new Point(31, 22);
            labelPOID.Name = "labelPOID";
            labelPOID.Size = new Size(40, 15);
            labelPOID.TabIndex = 0;
            labelPOID.Text = "PO ID:";
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Location = new Point(31, 59);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(53, 15);
            labelSupplier.TabIndex = 2;
            labelSupplier.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupplier.FormattingEnabled = true;
            comboBoxSupplier.Location = new Point(132, 55);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(220, 23);
            comboBoxSupplier.TabIndex = 3;
            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new Point(31, 95);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(67, 15);
            labelOrderDate.TabIndex = 4;
            labelOrderDate.Text = "Order Date:";
            // 
            // dateTimePickerOrder
            // 
            dateTimePickerOrder.Location = new Point(132, 93);
            dateTimePickerOrder.Name = "dateTimePickerOrder";
            dateTimePickerOrder.Size = new Size(220, 23);
            dateTimePickerOrder.TabIndex = 5;
            // 
            // labelDeliveryDate
            // 
            labelDeliveryDate.AutoSize = true;
            labelDeliveryDate.Location = new Point(31, 131);
            labelDeliveryDate.Name = "labelDeliveryDate";
            labelDeliveryDate.Size = new Size(79, 15);
            labelDeliveryDate.TabIndex = 6;
            labelDeliveryDate.Text = "Delivery Date:";
            // 
            // dateTimePickerDelivery
            // 
            dateTimePickerDelivery.Location = new Point(132, 128);
            dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            dateTimePickerDelivery.Size = new Size(220, 23);
            dateTimePickerDelivery.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(31, 166);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(42, 15);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Pending", "Approved", "Processing", "Partial Completed", "Completed", "Cancelled" });
            comboBoxStatus.Location = new Point(132, 164);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(220, 23);
            comboBoxStatus.TabIndex = 9;
            // 
            // labelLineItems
            // 
            labelLineItems.AutoSize = true;
            labelLineItems.Location = new Point(31, 211);
            labelLineItems.Name = "labelLineItems";
            labelLineItems.Size = new Size(120, 15);
            labelLineItems.TabIndex = 12;
            labelLineItems.Text = "Line Items (Materials)";
            // 
            // dataGridViewLineItems
            // 
            dataGridViewLineItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLineItems.Location = new Point(31, 229);
            dataGridViewLineItems.Name = "dataGridViewLineItems";
            dataGridViewLineItems.RowHeadersWidth = 51;
            dataGridViewLineItems.RowTemplate.Height = 24;
            dataGridViewLineItems.Size = new Size(482, 140);
            dataGridViewLineItems.TabIndex = 13;
            // 
            // buttonAddLine
            // 
            buttonAddLine.Location = new Point(31, 375);
            buttonAddLine.Name = "buttonAddLine";
            buttonAddLine.Size = new Size(88, 26);
            buttonAddLine.TabIndex = 14;
            buttonAddLine.Text = "Add Line";
            buttonAddLine.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteLine
            // 
            buttonDeleteLine.Location = new Point(125, 375);
            buttonDeleteLine.Name = "buttonDeleteLine";
            buttonDeleteLine.Size = new Size(88, 26);
            buttonDeleteLine.TabIndex = 15;
            buttonDeleteLine.Text = "Delete Line";
            buttonDeleteLine.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(335, 412);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(78, 30);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(435, 412);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(78, 30);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(132, 20);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Size = new Size(220, 23);
            maskedTextBox1.TabIndex = 18;
            // 
            // PurchaseOrderDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 454);
            Controls.Add(maskedTextBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonDeleteLine);
            Controls.Add(buttonAddLine);
            Controls.Add(dataGridViewLineItems);
            Controls.Add(labelLineItems);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(dateTimePickerDelivery);
            Controls.Add(labelDeliveryDate);
            Controls.Add(dateTimePickerOrder);
            Controls.Add(labelOrderDate);
            Controls.Add(comboBoxSupplier);
            Controls.Add(labelSupplier);
            Controls.Add(labelPOID);
            Name = "PurchaseOrderDetailForm";
            Text = "PurchaseOrderDetailForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox maskedTextBox1;
    }
}
