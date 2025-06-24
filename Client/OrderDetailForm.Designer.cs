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
            this.comboBoxCustomer = new ComboBox();
            this.comboBoxQuotation = new ComboBox();
            this.dateTimePickerOrderDate = new DateTimePicker();
            this.dateTimePickerDeadline = new DateTimePicker();
            this.comboBoxStatus = new ComboBox();
            this.comboBoxPaymentStatus = new ComboBox();
            this.comboBoxOrderType = new ComboBox();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.labelOrderID = new Label();
            this.labelCustomer = new Label();
            this.labelQuotation = new Label();
            this.labelOrderDate = new Label();
            this.labelDeadline = new Label();
            this.labelStatus = new Label();
            this.labelDeposit = new Label();
            this.labelBalance = new Label();
            this.labelTotalAmount = new Label();
            this.labelPaymentStatus = new Label();
            this.labelOrderType = new Label();
            this.maskedTextBox1 = new TextBox();
            this.textBoxDeposit = new NumericUpDown();
            this.textBoxBalance = new NumericUpDown();
            this.textBoxTotalAmount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.textBoxDeposit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.textBoxBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.textBoxTotalAmount).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.Location = new Point(209, 55);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new Size(268, 27);
            this.comboBoxCustomer.TabIndex = 3;
            this.comboBoxCustomer.SelectionChangeCommitted += this.comboBoxCustomer_SelectionChangeCommitted;
            // 
            // comboBoxQuotation
            // 
            this.comboBoxQuotation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxQuotation.Location = new Point(209, 98);
            this.comboBoxQuotation.Name = "comboBoxQuotation";
            this.comboBoxQuotation.Size = new Size(268, 27);
            this.comboBoxQuotation.TabIndex = 5;
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new Point(209, 143);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new Size(268, 27);
            this.dateTimePickerOrderDate.TabIndex = 7;
            // 
            // dateTimePickerDeadline
            // 
            this.dateTimePickerDeadline.Location = new Point(209, 188);
            this.dateTimePickerDeadline.Name = "dateTimePickerDeadline";
            this.dateTimePickerDeadline.Size = new Size(268, 27);
            this.dateTimePickerDeadline.TabIndex = 9;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Items.AddRange(new object[] { "Pending", "Confirmed", "Completed", "Cancelled" });
            this.comboBoxStatus.Location = new Point(209, 233);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new Size(268, 27);
            this.comboBoxStatus.TabIndex = 11;
            // 
            // comboBoxPaymentStatus
            // 
            this.comboBoxPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPaymentStatus.Items.AddRange(new object[] { "Unpaid", "Partial", "Paid" });
            this.comboBoxPaymentStatus.Location = new Point(209, 427);
            this.comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            this.comboBoxPaymentStatus.Size = new Size(268, 27);
            this.comboBoxPaymentStatus.TabIndex = 19;
            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOrderType.Items.AddRange(new object[] { "Normal", "Express", "Bulk" });
            this.comboBoxOrderType.Location = new Point(209, 477);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new Size(268, 27);
            this.comboBoxOrderType.TabIndex = 21;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new Point(421, 534);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new Size(80, 28);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new Point(535, 534);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(80, 28);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelOrderID
            // 
            this.labelOrderID.AutoSize = true;
            this.labelOrderID.Location = new Point(83, 19);
            this.labelOrderID.Name = "labelOrderID";
            this.labelOrderID.Size = new Size(73, 19);
            this.labelOrderID.TabIndex = 0;
            this.labelOrderID.Text = "Order ID:";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new Point(74, 58);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new Size(80, 19);
            this.labelCustomer.TabIndex = 2;
            this.labelCustomer.Text = "Customer:";
            // 
            // labelQuotation
            // 
            this.labelQuotation.AutoSize = true;
            this.labelQuotation.Location = new Point(69, 106);
            this.labelQuotation.Name = "labelQuotation";
            this.labelQuotation.Size = new Size(82, 19);
            this.labelQuotation.TabIndex = 4;
            this.labelQuotation.Text = "Quotation:";
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new Point(66, 149);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new Size(90, 19);
            this.labelOrderDate.TabIndex = 6;
            this.labelOrderDate.Text = "Order Date:";
            // 
            // labelDeadline
            // 
            this.labelDeadline.AutoSize = true;
            this.labelDeadline.Location = new Point(77, 194);
            this.labelDeadline.Name = "labelDeadline";
            this.labelDeadline.Size = new Size(74, 19);
            this.labelDeadline.TabIndex = 8;
            this.labelDeadline.Text = "Deadline:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new Point(88, 241);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new Size(55, 19);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Status:";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Location = new Point(80, 289);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new Size(65, 19);
            this.labelDeposit.TabIndex = 12;
            this.labelDeposit.Text = "Deposit:";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new Point(79, 335);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new Size(65, 19);
            this.labelBalance.TabIndex = 14;
            this.labelBalance.Text = "Balance:";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Location = new Point(47, 381);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new Size(106, 19);
            this.labelTotalAmount.TabIndex = 16;
            this.labelTotalAmount.Text = "Total Amount:";
            // 
            // labelPaymentStatus
            // 
            this.labelPaymentStatus.AutoSize = true;
            this.labelPaymentStatus.Location = new Point(38, 435);
            this.labelPaymentStatus.Name = "labelPaymentStatus";
            this.labelPaymentStatus.Size = new Size(120, 19);
            this.labelPaymentStatus.TabIndex = 18;
            this.labelPaymentStatus.Text = "Payment Status:";
            // 
            // labelOrderType
            // 
            this.labelOrderType.AutoSize = true;
            this.labelOrderType.Location = new Point(62, 485);
            this.labelOrderType.Name = "labelOrderType";
            this.labelOrderType.Size = new Size(91, 19);
            this.labelOrderType.TabIndex = 20;
            this.labelOrderType.Text = "Order Type:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new Point(209, 16);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new Size(268, 27);
            this.maskedTextBox1.TabIndex = 24;
            // 
            // textBoxDeposit
            // 
            this.textBoxDeposit.DecimalPlaces = 2;
            this.textBoxDeposit.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.textBoxDeposit.Location = new Point(209, 287);
            this.textBoxDeposit.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            this.textBoxDeposit.Name = "textBoxDeposit";
            this.textBoxDeposit.Size = new Size(268, 27);
            this.textBoxDeposit.TabIndex = 25;
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.DecimalPlaces = 2;
            this.textBoxBalance.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.textBoxBalance.Location = new Point(209, 333);
            this.textBoxBalance.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new Size(268, 27);
            this.textBoxBalance.TabIndex = 26;
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.DecimalPlaces = 2;
            this.textBoxTotalAmount.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.textBoxTotalAmount.Location = new Point(209, 379);
            this.textBoxTotalAmount.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new Size(268, 27);
            this.textBoxTotalAmount.TabIndex = 27;
            // 
            // OrderDetailForm
            // 
            this.ClientSize = new Size(637, 592);
            this.Controls.Add(this.textBoxTotalAmount);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.textBoxDeposit);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.labelOrderID);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.labelQuotation);
            this.Controls.Add(this.comboBoxQuotation);
            this.Controls.Add(this.labelOrderDate);
            this.Controls.Add(this.dateTimePickerOrderDate);
            this.Controls.Add(this.labelDeadline);
            this.Controls.Add(this.dateTimePickerDeadline);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.labelTotalAmount);
            this.Controls.Add(this.labelPaymentStatus);
            this.Controls.Add(this.comboBoxPaymentStatus);
            this.Controls.Add(this.labelOrderType);
            this.Controls.Add(this.comboBoxOrderType);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Customer Order Details";
            this.Load += this.OrderDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.textBoxDeposit).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.textBoxBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.textBoxTotalAmount).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private TextBox maskedTextBox1;
        private NumericUpDown textBoxDeposit;
        private NumericUpDown textBoxBalance;
        private NumericUpDown textBoxTotalAmount;
    }
}
