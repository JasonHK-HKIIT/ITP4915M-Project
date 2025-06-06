namespace Client
{
    partial class OrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.ComboBox comboBoxQuotation;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeadline;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxDeposit;
        private System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.ComboBox comboBoxPaymentStatus;
        private System.Windows.Forms.ComboBox comboBoxOrderType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

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
            comboBoxCustomer = new ComboBox();
            comboBoxQuotation = new ComboBox();
            dateTimePickerOrderDate = new DateTimePicker();
            dateTimePickerDeadline = new DateTimePicker();
            comboBoxStatus = new ComboBox();
            textBoxDeposit = new TextBox();
            textBoxBalance = new TextBox();
            textBoxTotalAmount = new TextBox();
            comboBoxPaymentStatus = new ComboBox();
            comboBoxOrderType = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            labelOrderID = new Label();
            labelCustomer = new Label();
            labelQuotation = new Label();
            labelOrderDate = new Label();
            labelDeadline = new Label();
            labelStatus = new Label();
            labelDeposit = new Label();
            labelBalance = new Label();
            labelTotalAmount = new Label();
            labelPaymentStatus = new Label();
            labelOrderType = new Label();
            maskedTextBox1 = new MaskedTextBox();
            SuspendLayout();
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomer.Location = new Point(209, 55);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(268, 23);
            comboBoxCustomer.TabIndex = 3;
            // 
            // comboBoxQuotation
            // 
            comboBoxQuotation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQuotation.Location = new Point(209, 98);
            comboBoxQuotation.Name = "comboBoxQuotation";
            comboBoxQuotation.Size = new Size(268, 23);
            comboBoxQuotation.TabIndex = 5;
            // 
            // dateTimePickerOrderDate
            // 
            dateTimePickerOrderDate.Location = new Point(209, 143);
            dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            dateTimePickerOrderDate.Size = new Size(268, 23);
            dateTimePickerOrderDate.TabIndex = 7;
            // 
            // dateTimePickerDeadline
            // 
            dateTimePickerDeadline.Location = new Point(209, 188);
            dateTimePickerDeadline.Name = "dateTimePickerDeadline";
            dateTimePickerDeadline.Size = new Size(268, 23);
            dateTimePickerDeadline.TabIndex = 9;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.Location = new Point(209, 233);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(268, 23);
            comboBoxStatus.TabIndex = 11;
            // 
            // textBoxDeposit
            // 
            textBoxDeposit.Location = new Point(209, 281);
            textBoxDeposit.Name = "textBoxDeposit";
            textBoxDeposit.Size = new Size(268, 23);
            textBoxDeposit.TabIndex = 13;
            // 
            // textBoxBalance
            // 
            textBoxBalance.Location = new Point(209, 332);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.Size = new Size(268, 23);
            textBoxBalance.TabIndex = 15;
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.Location = new Point(209, 378);
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.Size = new Size(268, 23);
            textBoxTotalAmount.TabIndex = 17;
            // 
            // comboBoxPaymentStatus
            // 
            comboBoxPaymentStatus.Location = new Point(209, 427);
            comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            comboBoxPaymentStatus.Size = new Size(268, 23);
            comboBoxPaymentStatus.TabIndex = 19;
            // 
            // comboBoxOrderType
            // 
            comboBoxOrderType.Location = new Point(209, 477);
            comboBoxOrderType.Name = "comboBoxOrderType";
            comboBoxOrderType.Size = new Size(268, 23);
            comboBoxOrderType.TabIndex = 21;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(421, 534);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(80, 28);
            buttonSave.TabIndex = 22;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(535, 534);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(80, 28);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelOrderID
            // 
            labelOrderID.AutoSize = true;
            labelOrderID.Location = new Point(83, 19);
            labelOrderID.Name = "labelOrderID";
            labelOrderID.Size = new Size(54, 15);
            labelOrderID.TabIndex = 0;
            labelOrderID.Text = "Order ID:";
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Location = new Point(74, 58);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(62, 15);
            labelCustomer.TabIndex = 2;
            labelCustomer.Text = "Customer:";
            // 
            // labelQuotation
            // 
            labelQuotation.AutoSize = true;
            labelQuotation.Location = new Point(69, 106);
            labelQuotation.Name = "labelQuotation";
            labelQuotation.Size = new Size(64, 15);
            labelQuotation.TabIndex = 4;
            labelQuotation.Text = "Quotation:";
            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new Point(66, 149);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(67, 15);
            labelOrderDate.TabIndex = 6;
            labelOrderDate.Text = "Order Date:";
            // 
            // labelDeadline
            // 
            labelDeadline.AutoSize = true;
            labelDeadline.Location = new Point(77, 194);
            labelDeadline.Name = "labelDeadline";
            labelDeadline.Size = new Size(56, 15);
            labelDeadline.TabIndex = 8;
            labelDeadline.Text = "Deadline:";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(88, 241);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(42, 15);
            labelStatus.TabIndex = 10;
            labelStatus.Text = "Status:";
            // 
            // labelDeposit
            // 
            labelDeposit.AutoSize = true;
            labelDeposit.Location = new Point(80, 289);
            labelDeposit.Name = "labelDeposit";
            labelDeposit.Size = new Size(50, 15);
            labelDeposit.TabIndex = 12;
            labelDeposit.Text = "Deposit:";
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Location = new Point(79, 335);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(51, 15);
            labelBalance.TabIndex = 14;
            labelBalance.Text = "Balance:";
            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.Location = new Point(47, 381);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new Size(83, 15);
            labelTotalAmount.TabIndex = 16;
            labelTotalAmount.Text = "Total Amount:";
            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.AutoSize = true;
            labelPaymentStatus.Location = new Point(38, 435);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new Size(92, 15);
            labelPaymentStatus.TabIndex = 18;
            labelPaymentStatus.Text = "Payment Status:";
            // 
            // labelOrderType
            // 
            labelOrderType.AutoSize = true;
            labelOrderType.Location = new Point(62, 485);
            labelOrderType.Name = "labelOrderType";
            labelOrderType.Size = new Size(68, 15);
            labelOrderType.TabIndex = 20;
            labelOrderType.Text = "Order Type:";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(209, 12);
            maskedTextBox1.Mask = "ORD000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(268, 23);
            maskedTextBox1.TabIndex = 24;
            // 
            // OrderDetailForm
            // 
            ClientSize = new Size(637, 592);
            Controls.Add(maskedTextBox1);
            Controls.Add(labelOrderID);
            Controls.Add(labelCustomer);
            Controls.Add(comboBoxCustomer);
            Controls.Add(labelQuotation);
            Controls.Add(comboBoxQuotation);
            Controls.Add(labelOrderDate);
            Controls.Add(dateTimePickerOrderDate);
            Controls.Add(labelDeadline);
            Controls.Add(dateTimePickerDeadline);
            Controls.Add(labelStatus);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelDeposit);
            Controls.Add(textBoxDeposit);
            Controls.Add(labelBalance);
            Controls.Add(textBoxBalance);
            Controls.Add(labelTotalAmount);
            Controls.Add(textBoxTotalAmount);
            Controls.Add(labelPaymentStatus);
            Controls.Add(comboBoxPaymentStatus);
            Controls.Add(labelOrderType);
            Controls.Add(comboBoxOrderType);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Order Details";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label labelOrderID;
        private Label labelCustomer;
        private Label labelQuotation;
        private Label labelOrderDate;
        private Label labelDeadline;
        private Label labelStatus;
        private Label labelDeposit;
        private Label labelBalance;
        private Label labelTotalAmount;
        private Label labelPaymentStatus;
        private Label labelOrderType;
        private MaskedTextBox maskedTextBox1;
    }
}
