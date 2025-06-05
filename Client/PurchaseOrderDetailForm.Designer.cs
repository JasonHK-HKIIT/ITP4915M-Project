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
            labelPOID = new Label();
            labelSupplier = new Label();
            comboBoxSupplier = new ComboBox();
            labelOrderDate = new Label();
            dateTimePickerOrder = new DateTimePicker();
            labelDeliveryDate = new Label();
            dateTimePickerDelivery = new DateTimePicker();
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelPOStatus = new Label();
            comboBoxPOStatus = new ComboBox();
            labelLineItems = new Label();
            dataGridViewLineItems = new DataGridView();
            buttonAddLine = new Button();
            buttonDeleteLine = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            maskedTextBox1 = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineItems).BeginInit();
            SuspendLayout();
            // 
            // labelPOID
            // 
            labelPOID.AutoSize = true;
            labelPOID.Location = new Point(49, 34);
            labelPOID.Margin = new Padding(5, 0, 5, 0);
            labelPOID.Name = "labelPOID";
            labelPOID.Size = new Size(64, 23);
            labelPOID.TabIndex = 0;
            labelPOID.Text = "PO ID:";
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Location = new Point(49, 89);
            labelSupplier.Margin = new Padding(5, 0, 5, 0);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(84, 23);
            labelSupplier.TabIndex = 2;
            labelSupplier.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupplier.FormattingEnabled = true;
            comboBoxSupplier.Location = new Point(206, 84);
            comboBoxSupplier.Margin = new Padding(5, 5, 5, 5);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(342, 31);
            comboBoxSupplier.TabIndex = 3;
            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new Point(49, 147);
            labelOrderDate.Margin = new Padding(5, 0, 5, 0);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(110, 23);
            labelOrderDate.TabIndex = 4;
            labelOrderDate.Text = "Order Date:";
            // 
            // dateTimePickerOrder
            // 
            dateTimePickerOrder.Location = new Point(206, 143);
            dateTimePickerOrder.Margin = new Padding(5, 5, 5, 5);
            dateTimePickerOrder.Name = "dateTimePickerOrder";
            dateTimePickerOrder.Size = new Size(342, 30);
            dateTimePickerOrder.TabIndex = 5;
            // 
            // labelDeliveryDate
            // 
            labelDeliveryDate.AutoSize = true;
            labelDeliveryDate.Location = new Point(49, 201);
            labelDeliveryDate.Margin = new Padding(5, 0, 5, 0);
            labelDeliveryDate.Name = "labelDeliveryDate";
            labelDeliveryDate.Size = new Size(129, 23);
            labelDeliveryDate.TabIndex = 6;
            labelDeliveryDate.Text = "Delivery Date:";
            // 
            // dateTimePickerDelivery
            // 
            dateTimePickerDelivery.Location = new Point(206, 196);
            dateTimePickerDelivery.Margin = new Padding(5, 5, 5, 5);
            dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            dateTimePickerDelivery.Size = new Size(342, 30);
            dateTimePickerDelivery.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(49, 256);
            labelStatus.Margin = new Padding(5, 0, 5, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(67, 23);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(206, 251);
            comboBoxStatus.Margin = new Padding(5, 5, 5, 5);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(342, 31);
            comboBoxStatus.TabIndex = 9;
            // 
            // labelPOStatus
            // 
            labelPOStatus.AutoSize = true;
            labelPOStatus.Location = new Point(49, 310);
            labelPOStatus.Margin = new Padding(5, 0, 5, 0);
            labelPOStatus.Name = "labelPOStatus";
            labelPOStatus.Size = new Size(98, 23);
            labelPOStatus.TabIndex = 10;
            labelPOStatus.Text = "PO Status:";
            // 
            // comboBoxPOStatus
            // 
            comboBoxPOStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPOStatus.FormattingEnabled = true;
            comboBoxPOStatus.Location = new Point(206, 307);
            comboBoxPOStatus.Margin = new Padding(5, 5, 5, 5);
            comboBoxPOStatus.Name = "comboBoxPOStatus";
            comboBoxPOStatus.Size = new Size(342, 31);
            comboBoxPOStatus.TabIndex = 11;
            // 
            // labelLineItems
            // 
            labelLineItems.AutoSize = true;
            labelLineItems.Location = new Point(49, 365);
            labelLineItems.Margin = new Padding(5, 0, 5, 0);
            labelLineItems.Name = "labelLineItems";
            labelLineItems.Size = new Size(193, 23);
            labelLineItems.TabIndex = 12;
            labelLineItems.Text = "Line Items (Materials)";
            // 
            // dataGridViewLineItems
            // 
            dataGridViewLineItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLineItems.Location = new Point(52, 394);
            dataGridViewLineItems.Margin = new Padding(5, 5, 5, 5);
            dataGridViewLineItems.Name = "dataGridViewLineItems";
            dataGridViewLineItems.RowHeadersWidth = 51;
            dataGridViewLineItems.RowTemplate.Height = 24;
            dataGridViewLineItems.Size = new Size(756, 216);
            dataGridViewLineItems.TabIndex = 13;
            // 
            // buttonAddLine
            // 
            buttonAddLine.Location = new Point(52, 618);
            buttonAddLine.Margin = new Padding(5, 5, 5, 5);
            buttonAddLine.Name = "buttonAddLine";
            buttonAddLine.Size = new Size(138, 40);
            buttonAddLine.TabIndex = 14;
            buttonAddLine.Text = "Add Line";
            buttonAddLine.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteLine
            // 
            buttonDeleteLine.Location = new Point(198, 618);
            buttonDeleteLine.Margin = new Padding(5, 5, 5, 5);
            buttonDeleteLine.Name = "buttonDeleteLine";
            buttonDeleteLine.Size = new Size(138, 40);
            buttonDeleteLine.TabIndex = 15;
            buttonDeleteLine.Text = "Delete Line";
            buttonDeleteLine.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(534, 690);
            buttonSave.Margin = new Padding(5, 5, 5, 5);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(124, 46);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(685, 690);
            buttonCancel.Margin = new Padding(5, 5, 5, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(124, 46);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(206, 27);
            maskedTextBox1.Mask = "PUR000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(342, 30);
            maskedTextBox1.TabIndex = 18;
            // 
            // PurchaseOrderDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 768);
            Controls.Add(maskedTextBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonDeleteLine);
            Controls.Add(buttonAddLine);
            Controls.Add(dataGridViewLineItems);
            Controls.Add(labelLineItems);
            Controls.Add(comboBoxPOStatus);
            Controls.Add(labelPOStatus);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(dateTimePickerDelivery);
            Controls.Add(labelDeliveryDate);
            Controls.Add(dateTimePickerOrder);
            Controls.Add(labelOrderDate);
            Controls.Add(comboBoxSupplier);
            Controls.Add(labelSupplier);
            Controls.Add(labelPOID);
            Margin = new Padding(5, 5, 5, 5);
            Name = "PurchaseOrderDetailForm";
            Text = "PurchaseOrderDetailForm";
            Load += PurchaseOrderDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBox1;
    }
}
