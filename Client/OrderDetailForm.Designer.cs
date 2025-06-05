namespace Client
{
    partial class OrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxOrderID;
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
            this.textBoxOrderID = new System.Windows.Forms.TextBox();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.comboBoxQuotation = new System.Windows.Forms.ComboBox();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDeadline = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxDeposit = new System.Windows.Forms.TextBox();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.comboBoxPaymentStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderType = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();

            var labelOrderID = new System.Windows.Forms.Label();
            var labelCustomer = new System.Windows.Forms.Label();
            var labelQuotation = new System.Windows.Forms.Label();
            var labelOrderDate = new System.Windows.Forms.Label();
            var labelDeadline = new System.Windows.Forms.Label();
            var labelStatus = new System.Windows.Forms.Label();
            var labelDeposit = new System.Windows.Forms.Label();
            var labelBalance = new System.Windows.Forms.Label();
            var labelTotalAmount = new System.Windows.Forms.Label();
            var labelPaymentStatus = new System.Windows.Forms.Label();
            var labelOrderType = new System.Windows.Forms.Label();

            // 
            // labelOrderID
            // 
            labelOrderID.AutoSize = true;
            labelOrderID.Location = new System.Drawing.Point(40, 20);
            labelOrderID.Name = "labelOrderID";
            labelOrderID.Size = new System.Drawing.Size(68, 13);
            labelOrderID.Text = "Order ID:";
            // 
            // textBoxOrderID
            // 
            this.textBoxOrderID.Location = new System.Drawing.Point(150, 17);
            this.textBoxOrderID.Name = "textBoxOrderID";
            this.textBoxOrderID.Size = new System.Drawing.Size(180, 20);

            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Location = new System.Drawing.Point(40, 50);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new System.Drawing.Size(57, 13);
            labelCustomer.Text = "Customer:";

            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.Location = new System.Drawing.Point(150, 47);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(180, 21);

            // 
            // labelQuotation
            // 
            labelQuotation.AutoSize = true;
            labelQuotation.Location = new System.Drawing.Point(40, 80);
            labelQuotation.Name = "labelQuotation";
            labelQuotation.Size = new System.Drawing.Size(59, 13);
            labelQuotation.Text = "Quotation:";

            // 
            // comboBoxQuotation
            // 
            this.comboBoxQuotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuotation.Location = new System.Drawing.Point(150, 77);
            this.comboBoxQuotation.Name = "comboBoxQuotation";
            this.comboBoxQuotation.Size = new System.Drawing.Size(180, 21);

            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new System.Drawing.Point(40, 110);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new System.Drawing.Size(61, 13);
            labelOrderDate.Text = "Order Date:";

            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(150, 107);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(180, 20);

            // 
            // labelDeadline
            // 
            labelDeadline.AutoSize = true;
            labelDeadline.Location = new System.Drawing.Point(40, 140);
            labelDeadline.Name = "labelDeadline";
            labelDeadline.Size = new System.Drawing.Size(52, 13);
            labelDeadline.Text = "Deadline:";

            // 
            // dateTimePickerDeadline
            // 
            this.dateTimePickerDeadline.Location = new System.Drawing.Point(150, 137);
            this.dateTimePickerDeadline.Name = "dateTimePickerDeadline";
            this.dateTimePickerDeadline.Size = new System.Drawing.Size(180, 20);

            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new System.Drawing.Point(40, 170);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(40, 13);
            labelStatus.Text = "Status:";

            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Location = new System.Drawing.Point(150, 167);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(180, 21);

            // 
            // labelDeposit
            // 
            labelDeposit.AutoSize = true;
            labelDeposit.Location = new System.Drawing.Point(40, 200);
            labelDeposit.Name = "labelDeposit";
            labelDeposit.Size = new System.Drawing.Size(49, 13);
            labelDeposit.Text = "Deposit:";

            // 
            // textBoxDeposit
            // 
            this.textBoxDeposit.Location = new System.Drawing.Point(150, 197);
            this.textBoxDeposit.Name = "textBoxDeposit";
            this.textBoxDeposit.Size = new System.Drawing.Size(180, 20);

            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Location = new System.Drawing.Point(40, 230);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new System.Drawing.Size(49, 13);
            labelBalance.Text = "Balance:";

            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Location = new System.Drawing.Point(150, 227);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(180, 20);

            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.Location = new System.Drawing.Point(40, 260);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new System.Drawing.Size(74, 13);
            labelTotalAmount.Text = "Total Amount:";

            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Location = new System.Drawing.Point(150, 257);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(180, 20);

            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.AutoSize = true;
            labelPaymentStatus.Location = new System.Drawing.Point(40, 290);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new System.Drawing.Size(86, 13);
            labelPaymentStatus.Text = "Payment Status:";

            // 
            // comboBoxPaymentStatus
            // 
            this.comboBoxPaymentStatus.Location = new System.Drawing.Point(150, 287);
            this.comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            this.comboBoxPaymentStatus.Size = new System.Drawing.Size(180, 21);

            // 
            // labelOrderType
            // 
            labelOrderType.AutoSize = true;
            labelOrderType.Location = new System.Drawing.Point(40, 320);
            labelOrderType.Name = "labelOrderType";
            labelOrderType.Size = new System.Drawing.Size(63, 13);
            labelOrderType.Text = "Order Type:";

            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.Location = new System.Drawing.Point(150, 317);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new System.Drawing.Size(180, 21);

            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(150, 360);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 28);
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;

            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(250, 360);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 28);
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;

            // 
            // CustomerOrderDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 410);
            this.Controls.Add(labelOrderID);
            this.Controls.Add(this.textBoxOrderID);
            this.Controls.Add(labelCustomer);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(labelQuotation);
            this.Controls.Add(this.comboBoxQuotation);
            this.Controls.Add(labelOrderDate);
            this.Controls.Add(this.dateTimePickerOrderDate);
            this.Controls.Add(labelDeadline);
            this.Controls.Add(this.dateTimePickerDeadline);
            this.Controls.Add(labelStatus);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(labelDeposit);
            this.Controls.Add(this.textBoxDeposit);
            this.Controls.Add(labelBalance);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(labelTotalAmount);
            this.Controls.Add(this.textBoxTotalAmount);
            this.Controls.Add(labelPaymentStatus);
            this.Controls.Add(this.comboBoxPaymentStatus);
            this.Controls.Add(labelOrderType);
            this.Controls.Add(this.comboBoxOrderType);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);

            this.Name = "CustomerOrderDetailForm";
            this.Text = "Customer Order Details";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
    }
}
