namespace Client
{
    partial class ServiceCaseDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            labelCaseID = new Label();
            labelCustomerID = new Label();
            comboBoxCustomerID = new ComboBox();
            labelCustomerOrderID = new Label();
            comboBoxCustomerOrderID = new ComboBox();
            labelCaseDate = new Label();
            dateTimePickerCaseDate = new DateTimePicker();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelResolution = new Label();
            textBoxResolution = new TextBox();
            labelCaseType = new Label();
            comboBoxCaseType = new ComboBox();
            labelAssignedStaffID = new Label();
            comboBoxAssignedStaffID = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            maskedTextBox1 = new MaskedTextBox();
            SuspendLayout();
            // 
            // labelCaseID
            // 
            labelCaseID.AutoSize = true;
            labelCaseID.Location = new Point(105, 18);
            labelCaseID.Name = "labelCaseID";
            labelCaseID.Size = new Size(46, 15);
            labelCaseID.TabIndex = 0;
            labelCaseID.Text = "Case ID";
            // 
            // labelCustomerID
            // 
            labelCustomerID.AutoSize = true;
            labelCustomerID.Location = new Point(78, 52);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(73, 15);
            labelCustomerID.TabIndex = 2;
            labelCustomerID.Text = "Customer ID";
            // 
            // comboBoxCustomerID
            // 
            comboBoxCustomerID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerID.Location = new Point(258, 52);
            comboBoxCustomerID.Name = "comboBoxCustomerID";
            comboBoxCustomerID.Size = new Size(200, 23);
            comboBoxCustomerID.TabIndex = 3;
            // 
            // labelCustomerOrderID
            // 
            labelCustomerOrderID.AutoSize = true;
            labelCustomerOrderID.Location = new Point(45, 101);
            labelCustomerOrderID.Name = "labelCustomerOrderID";
            labelCustomerOrderID.Size = new Size(106, 15);
            labelCustomerOrderID.TabIndex = 4;
            labelCustomerOrderID.Text = "Customer Order ID";
            // 
            // comboBoxCustomerOrderID
            // 
            comboBoxCustomerOrderID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerOrderID.Location = new Point(258, 98);
            comboBoxCustomerOrderID.Name = "comboBoxCustomerOrderID";
            comboBoxCustomerOrderID.Size = new Size(200, 23);
            comboBoxCustomerOrderID.TabIndex = 5;
            // 
            // labelCaseDate
            // 
            labelCaseDate.AutoSize = true;
            labelCaseDate.Location = new Point(92, 154);
            labelCaseDate.Name = "labelCaseDate";
            labelCaseDate.Size = new Size(59, 15);
            labelCaseDate.TabIndex = 6;
            labelCaseDate.Text = "Case Date";
            // 
            // dateTimePickerCaseDate
            // 
            dateTimePickerCaseDate.Format = DateTimePickerFormat.Short;
            dateTimePickerCaseDate.Location = new Point(258, 148);
            dateTimePickerCaseDate.Name = "dateTimePickerCaseDate";
            dateTimePickerCaseDate.Size = new Size(200, 23);
            dateTimePickerCaseDate.TabIndex = 7;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(84, 201);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(67, 15);
            labelDescription.TabIndex = 8;
            labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(258, 198);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(415, 80);
            textBoxDescription.TabIndex = 9;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(112, 304);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(39, 15);
            labelStatus.TabIndex = 10;
            labelStatus.Text = "Status";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.Location = new Point(258, 296);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(200, 23);
            comboBoxStatus.TabIndex = 11;
            // 
            // labelResolution
            // 
            labelResolution.AutoSize = true;
            labelResolution.Location = new Point(88, 352);
            labelResolution.Name = "labelResolution";
            labelResolution.Size = new Size(63, 15);
            labelResolution.TabIndex = 12;
            labelResolution.Text = "Resolution";
            // 
            // textBoxResolution
            // 
            textBoxResolution.Location = new Point(258, 352);
            textBoxResolution.Multiline = true;
            textBoxResolution.Name = "textBoxResolution";
            textBoxResolution.Size = new Size(415, 80);
            textBoxResolution.TabIndex = 13;
            // 
            // labelCaseType
            // 
            labelCaseType.AutoSize = true;
            labelCaseType.Location = new Point(91, 453);
            labelCaseType.Name = "labelCaseType";
            labelCaseType.Size = new Size(60, 15);
            labelCaseType.TabIndex = 14;
            labelCaseType.Text = "Case Type";
            // 
            // comboBoxCaseType
            // 
            comboBoxCaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaseType.Location = new Point(258, 450);
            comboBoxCaseType.Name = "comboBoxCaseType";
            comboBoxCaseType.Size = new Size(200, 23);
            comboBoxCaseType.TabIndex = 15;
            // 
            // labelAssignedStaffID
            // 
            labelAssignedStaffID.AutoSize = true;
            labelAssignedStaffID.Location = new Point(55, 525);
            labelAssignedStaffID.Name = "labelAssignedStaffID";
            labelAssignedStaffID.Size = new Size(96, 15);
            labelAssignedStaffID.TabIndex = 16;
            labelAssignedStaffID.Text = "Assigned Staff ID";
            // 
            // comboBoxAssignedStaffID
            // 
            comboBoxAssignedStaffID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAssignedStaffID.Location = new Point(258, 517);
            comboBoxAssignedStaffID.Name = "comboBoxAssignedStaffID";
            comboBoxAssignedStaffID.Size = new Size(200, 23);
            comboBoxAssignedStaffID.TabIndex = 17;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(452, 569);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(90, 30);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(592, 569);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(90, 30);
            buttonCancel.TabIndex = 19;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(258, 10);
            maskedTextBox1.Mask = "CASE000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(200, 23);
            maskedTextBox1.TabIndex = 20;
            // 
            // ServiceCaseDetailForm
            // 
            ClientSize = new Size(713, 627);
            Controls.Add(maskedTextBox1);
            Controls.Add(labelCaseID);
            Controls.Add(labelCustomerID);
            Controls.Add(comboBoxCustomerID);
            Controls.Add(labelCustomerOrderID);
            Controls.Add(comboBoxCustomerOrderID);
            Controls.Add(labelCaseDate);
            Controls.Add(dateTimePickerCaseDate);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelStatus);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelResolution);
            Controls.Add(textBoxResolution);
            Controls.Add(labelCaseType);
            Controls.Add(comboBoxCaseType);
            Controls.Add(labelAssignedStaffID);
            Controls.Add(comboBoxAssignedStaffID);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Name = "ServiceCaseDetailForm";
            Text = "Customer Service Case Detail";
            Load += ServiceCaseDetailForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelCaseID;
        private System.Windows.Forms.Label labelCustomerID;
        private System.Windows.Forms.ComboBox comboBoxCustomerID;
        private System.Windows.Forms.Label labelCustomerOrderID;
        private System.Windows.Forms.ComboBox comboBoxCustomerOrderID;
        private System.Windows.Forms.Label labelCaseDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerCaseDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.TextBox textBoxResolution;
        private System.Windows.Forms.Label labelCaseType;
        private System.Windows.Forms.ComboBox comboBoxCaseType;
        private System.Windows.Forms.Label labelAssignedStaffID;
        private System.Windows.Forms.ComboBox comboBoxAssignedStaffID;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private MaskedTextBox maskedTextBox1;
    }
}

