namespace Client
{
    partial class ServiceCaseDetailForm
    {
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
            labelCustomer = new Label();
            comboBoxCustomer = new ComboBox();
            labelOrder = new Label();
            comboBoxOrder = new ComboBox();
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
            labelAssignedStaff = new Label();
            comboBoxAssignedStaff = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            maskedTextBoxCaseID = new MaskedTextBox();
            SuspendLayout();
            // 
            // labelCaseID
            // 
            labelCaseID.AutoSize = true;
            labelCaseID.Location = new Point(105, 18);
            labelCaseID.Name = "labelCaseID";
            labelCaseID.Size = new Size(74, 23);
            labelCaseID.TabIndex = 0;
            labelCaseID.Text = "Case ID";
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Location = new Point(78, 52);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(93, 23);
            labelCustomer.TabIndex = 2;
            labelCustomer.Text = "Customer";
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomer.Location = new Point(258, 52);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(200, 31);
            comboBoxCustomer.TabIndex = 3;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Location = new Point(45, 101);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(148, 23);
            labelOrder.TabIndex = 4;
            labelOrder.Text = "Customer Order";
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrder.Location = new Point(258, 98);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(200, 31);
            comboBoxOrder.TabIndex = 5;
            // 
            // labelCaseDate
            // 
            labelCaseDate.AutoSize = true;
            labelCaseDate.Location = new Point(92, 154);
            labelCaseDate.Name = "labelCaseDate";
            labelCaseDate.Size = new Size(96, 23);
            labelCaseDate.TabIndex = 6;
            labelCaseDate.Text = "Case Date";
            // 
            // dateTimePickerCaseDate
            // 
            dateTimePickerCaseDate.Format = DateTimePickerFormat.Short;
            dateTimePickerCaseDate.Location = new Point(258, 148);
            dateTimePickerCaseDate.Name = "dateTimePickerCaseDate";
            dateTimePickerCaseDate.Size = new Size(200, 30);
            dateTimePickerCaseDate.TabIndex = 7;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(84, 201);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(108, 23);
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
            labelStatus.Size = new Size(63, 23);
            labelStatus.TabIndex = 10;
            labelStatus.Text = "Status";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.Location = new Point(258, 296);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(200, 31);
            comboBoxStatus.TabIndex = 11;
            // 
            // labelResolution
            // 
            labelResolution.AutoSize = true;
            labelResolution.Location = new Point(88, 352);
            labelResolution.Name = "labelResolution";
            labelResolution.Size = new Size(101, 23);
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
            labelCaseType.Size = new Size(95, 23);
            labelCaseType.TabIndex = 14;
            labelCaseType.Text = "Case Type";
            // 
            // comboBoxCaseType
            // 
            comboBoxCaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaseType.Location = new Point(258, 450);
            comboBoxCaseType.Name = "comboBoxCaseType";
            comboBoxCaseType.Size = new Size(200, 31);
            comboBoxCaseType.TabIndex = 15;
            // 
            // labelAssignedStaff
            // 
            labelAssignedStaff.AutoSize = true;
            labelAssignedStaff.Location = new Point(55, 525);
            labelAssignedStaff.Name = "labelAssignedStaff";
            labelAssignedStaff.Size = new Size(130, 23);
            labelAssignedStaff.TabIndex = 16;
            labelAssignedStaff.Text = "Assigned Staff";
            // 
            // comboBoxAssignedStaff
            // 
            comboBoxAssignedStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAssignedStaff.Location = new Point(258, 517);
            comboBoxAssignedStaff.Name = "comboBoxAssignedStaff";
            comboBoxAssignedStaff.Size = new Size(200, 31);
            comboBoxAssignedStaff.TabIndex = 17;
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
            // maskedTextBoxCaseID
            // 
            maskedTextBoxCaseID.Location = new Point(258, 10);
            maskedTextBoxCaseID.Mask = "CASE000";
            maskedTextBoxCaseID.Name = "maskedTextBoxCaseID";
            maskedTextBoxCaseID.Size = new Size(200, 30);
            maskedTextBoxCaseID.TabIndex = 1;
            maskedTextBoxCaseID.Text = "CA";
            maskedTextBoxCaseID.TextMaskFormat = MaskFormat.IncludePrompt;
            // 
            // ServiceCaseDetailForm
            // 
            ClientSize = new Size(713, 627);
            Controls.Add(maskedTextBoxCaseID);
            Controls.Add(labelCaseID);
            Controls.Add(labelCustomer);
            Controls.Add(comboBoxCustomer);
            Controls.Add(labelOrder);
            Controls.Add(comboBoxOrder);
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
            Controls.Add(labelAssignedStaff);
            Controls.Add(comboBoxAssignedStaff);
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
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCaseID;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.ComboBox comboBoxOrder;
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
        private System.Windows.Forms.Label labelAssignedStaff;
        private System.Windows.Forms.ComboBox comboBoxAssignedStaff;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
