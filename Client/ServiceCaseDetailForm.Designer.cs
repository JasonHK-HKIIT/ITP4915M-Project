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
            this.labelCaseID = new Label();
            this.labelCustomer = new Label();
            this.comboBoxCustomer = new ComboBox();
            this.labelOrder = new Label();
            this.comboBoxOrder = new ComboBox();
            this.labelCaseDate = new Label();
            this.dateTimePickerCaseDate = new DateTimePicker();
            this.labelDescription = new Label();
            this.textBoxDescription = new TextBox();
            this.labelStatus = new Label();
            this.comboBoxStatus = new ComboBox();
            this.labelResolution = new Label();
            this.textBoxResolution = new TextBox();
            this.labelCaseType = new Label();
            this.comboBoxCaseType = new ComboBox();
            this.labelAssignedStaff = new Label();
            this.comboBoxAssignedStaff = new ComboBox();
            this.buttonSave = new Button();
            this.buttonCancel = new Button();
            this.maskedTextBoxCaseID = new TextBox();
            this.SuspendLayout();
            // 
            // labelCaseID
            // 
            this.labelCaseID.AutoSize = true;
            this.labelCaseID.Location = new Point(105, 18);
            this.labelCaseID.Name = "labelCaseID";
            this.labelCaseID.Size = new Size(61, 19);
            this.labelCaseID.TabIndex = 0;
            this.labelCaseID.Text = "Case ID";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new Point(92, 55);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new Size(77, 19);
            this.labelCustomer.TabIndex = 2;
            this.labelCustomer.Text = "Customer";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.Location = new Point(195, 52);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new Size(200, 27);
            this.comboBoxCustomer.TabIndex = 3;
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Location = new Point(59, 101);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new Size(123, 19);
            this.labelOrder.TabIndex = 4;
            this.labelOrder.Text = "Customer Order";
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOrder.Location = new Point(195, 101);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new Size(200, 27);
            this.comboBoxOrder.TabIndex = 5;
            // 
            // labelCaseDate
            // 
            this.labelCaseDate.AutoSize = true;
            this.labelCaseDate.Location = new Point(92, 154);
            this.labelCaseDate.Name = "labelCaseDate";
            this.labelCaseDate.Size = new Size(78, 19);
            this.labelCaseDate.TabIndex = 6;
            this.labelCaseDate.Text = "Case Date";
            // 
            // dateTimePickerCaseDate
            // 
            this.dateTimePickerCaseDate.Format = DateTimePickerFormat.Short;
            this.dateTimePickerCaseDate.Location = new Point(195, 146);
            this.dateTimePickerCaseDate.Name = "dateTimePickerCaseDate";
            this.dateTimePickerCaseDate.Size = new Size(200, 27);
            this.dateTimePickerCaseDate.TabIndex = 7;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new Point(84, 198);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new Size(88, 19);
            this.labelDescription.TabIndex = 8;
            this.labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new Point(195, 198);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new Size(415, 80);
            this.textBoxDescription.TabIndex = 9;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new Point(112, 296);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new Size(52, 19);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Status";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Location = new Point(195, 296);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new Size(200, 27);
            this.comboBoxStatus.TabIndex = 11;
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new Point(92, 352);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new Size(83, 19);
            this.labelResolution.TabIndex = 12;
            this.labelResolution.Text = "Resolution";
            // 
            // textBoxResolution
            // 
            this.textBoxResolution.Location = new Point(195, 352);
            this.textBoxResolution.Multiline = true;
            this.textBoxResolution.Name = "textBoxResolution";
            this.textBoxResolution.Size = new Size(415, 80);
            this.textBoxResolution.TabIndex = 13;
            // 
            // labelCaseType
            // 
            this.labelCaseType.AutoSize = true;
            this.labelCaseType.Location = new Point(95, 450);
            this.labelCaseType.Name = "labelCaseType";
            this.labelCaseType.Size = new Size(79, 19);
            this.labelCaseType.TabIndex = 14;
            this.labelCaseType.Text = "Case Type";
            // 
            // comboBoxCaseType
            // 
            this.comboBoxCaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCaseType.Location = new Point(195, 447);
            this.comboBoxCaseType.Name = "comboBoxCaseType";
            this.comboBoxCaseType.Size = new Size(200, 27);
            this.comboBoxCaseType.TabIndex = 15;
            // 
            // labelAssignedStaff
            // 
            this.labelAssignedStaff.AutoSize = true;
            this.labelAssignedStaff.Location = new Point(73, 525);
            this.labelAssignedStaff.Name = "labelAssignedStaff";
            this.labelAssignedStaff.Size = new Size(110, 19);
            this.labelAssignedStaff.TabIndex = 16;
            this.labelAssignedStaff.Text = "Assigned Staff";
            // 
            // comboBoxAssignedStaff
            // 
            this.comboBoxAssignedStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxAssignedStaff.Location = new Point(195, 522);
            this.comboBoxAssignedStaff.Name = "comboBoxAssignedStaff";
            this.comboBoxAssignedStaff.Size = new Size(200, 27);
            this.comboBoxAssignedStaff.TabIndex = 17;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new Point(452, 569);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new Size(90, 30);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new Point(592, 569);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(90, 30);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxCaseID
            // 
            this.maskedTextBoxCaseID.Location = new Point(195, 15);
            this.maskedTextBoxCaseID.Name = "maskedTextBoxCaseID";
            this.maskedTextBoxCaseID.ReadOnly = true;
            this.maskedTextBoxCaseID.Size = new Size(200, 27);
            this.maskedTextBoxCaseID.TabIndex = 20;
            // 
            // ServiceCaseDetailForm
            // 
            this.ClientSize = new Size(713, 627);
            this.Controls.Add(this.maskedTextBoxCaseID);
            this.Controls.Add(this.labelCaseID);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.labelOrder);
            this.Controls.Add(this.comboBoxOrder);
            this.Controls.Add(this.labelCaseDate);
            this.Controls.Add(this.dateTimePickerCaseDate);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.textBoxResolution);
            this.Controls.Add(this.labelCaseType);
            this.Controls.Add(this.comboBoxCaseType);
            this.Controls.Add(this.labelAssignedStaff);
            this.Controls.Add(this.comboBoxAssignedStaff);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ServiceCaseDetailForm";
            this.Text = "Customer Service Case Detail";
            this.Load += this.ServiceCaseDetailForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelCaseID;
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
        private TextBox maskedTextBoxCaseID;
    }
}
