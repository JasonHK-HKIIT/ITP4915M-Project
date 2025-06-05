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
            labelPOID = new Label();
            textBoxPOID = new TextBox();
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
            // textBoxPOID
            // 
            textBoxPOID.Location = new Point(131, 20);
            textBoxPOID.Name = "textBoxPOID";
            textBoxPOID.Size = new Size(219, 23);
            textBoxPOID.TabIndex = 1;
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Location = new Point(31, 58);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(53, 15);
            labelSupplier.TabIndex = 2;
            labelSupplier.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupplier.FormattingEnabled = true;
            comboBoxSupplier.Location = new Point(131, 55);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(219, 23);
            comboBoxSupplier.TabIndex = 3;
            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new Point(31, 96);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(67, 15);
            labelOrderDate.TabIndex = 4;
            labelOrderDate.Text = "Order Date:";
            // 
            // dateTimePickerOrder
            // 
            dateTimePickerOrder.Location = new Point(131, 93);
            dateTimePickerOrder.Name = "dateTimePickerOrder";
            dateTimePickerOrder.Size = new Size(219, 23);
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
            dateTimePickerDelivery.Location = new Point(131, 128);
            dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            dateTimePickerDelivery.Size = new Size(219, 23);
            dateTimePickerDelivery.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(31, 167);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(42, 15);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(131, 164);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(219, 23);
            comboBoxStatus.TabIndex = 9;
            // 
            // labelPOStatus
            // 
            labelPOStatus.AutoSize = true;
            labelPOStatus.Location = new Point(31, 202);
            labelPOStatus.Name = "labelPOStatus";
            labelPOStatus.Size = new Size(61, 15);
            labelPOStatus.TabIndex = 10;
            labelPOStatus.Text = "PO Status:";
            // 
            // comboBoxPOStatus
            // 
            comboBoxPOStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPOStatus.FormattingEnabled = true;
            comboBoxPOStatus.Location = new Point(131, 200);
            comboBoxPOStatus.Name = "comboBoxPOStatus";
            comboBoxPOStatus.Size = new Size(219, 23);
            comboBoxPOStatus.TabIndex = 11;
            // 
            // labelLineItems
            // 
            labelLineItems.AutoSize = true;
            labelLineItems.Location = new Point(31, 238);
            labelLineItems.Name = "labelLineItems";
            labelLineItems.Size = new Size(120, 15);
            labelLineItems.TabIndex = 12;
            labelLineItems.Text = "Line Items (Materials)";
            // 
            // dataGridViewLineItems
            // 
            dataGridViewLineItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLineItems.Location = new Point(33, 257);
            dataGridViewLineItems.Name = "dataGridViewLineItems";
            dataGridViewLineItems.RowHeadersWidth = 51;
            dataGridViewLineItems.RowTemplate.Height = 24;
            dataGridViewLineItems.Size = new Size(481, 141);
            dataGridViewLineItems.TabIndex = 13;
            // 
            // buttonAddLine
            // 
            buttonAddLine.Location = new Point(33, 403);
            buttonAddLine.Name = "buttonAddLine";
            buttonAddLine.Size = new Size(88, 26);
            buttonAddLine.TabIndex = 14;
            buttonAddLine.Text = "Add Line";
            buttonAddLine.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteLine
            // 
            buttonDeleteLine.Location = new Point(126, 403);
            buttonDeleteLine.Name = "buttonDeleteLine";
            buttonDeleteLine.Size = new Size(88, 26);
            buttonDeleteLine.TabIndex = 15;
            buttonDeleteLine.Text = "Delete Line";
            buttonDeleteLine.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(340, 450);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(79, 30);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(436, 450);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(79, 30);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // PurchaseOrderDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 501);
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
            Controls.Add(textBoxPOID);
            Controls.Add(labelPOID);
            Name = "PurchaseOrderDetailForm";
            Text = "PurchaseOrderDetailForm";
            Load += PurchaseOrderDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
