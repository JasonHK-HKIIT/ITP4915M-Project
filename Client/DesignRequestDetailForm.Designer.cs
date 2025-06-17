namespace Client
{
    partial class DesignRequestDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.SaveButton = new Button();
            this.CancelButton = new Button();
            this.SpecificationsField = new TextBox();
            this.AssignedManagerField = new ComboBox();
            this.CustomerField = new ComboBox();
            this.label4 = new Label();
            this.label5 = new Label();
            this.RequestDateField = new DateTimePicker();
            this.label6 = new Label();
            this.ConsultantFeeField = new TextBox();
            this.label7 = new Label();
            this.StatusField = new ComboBox();
            this.label8 = new Label();
            this.ApprovalDateField = new DateTimePicker();
            this.label9 = new Label();
            this.ApprovedByField = new ComboBox();
            this.RequestIdField = new TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(71, 53);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 585);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(141, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assigned Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(49, 151);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(104, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Specifications";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(559, 714);
            this.SaveButton.Margin = new Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(96, 29);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += this.SaveButton_Click;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new Point(676, 714);
            this.CancelButton.Margin = new Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(96, 29);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // SpecificationsField
            // 
            this.SpecificationsField.Location = new Point(159, 151);
            this.SpecificationsField.Margin = new Padding(4);
            this.SpecificationsField.Multiline = true;
            this.SpecificationsField.Name = "SpecificationsField";
            this.SpecificationsField.Size = new Size(628, 242);
            this.SpecificationsField.TabIndex = 13;
            // 
            // AssignedManagerField
            // 
            this.AssignedManagerField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AssignedManagerField.FormattingEnabled = true;
            this.AssignedManagerField.Location = new Point(159, 581);
            this.AssignedManagerField.Margin = new Padding(4);
            this.AssignedManagerField.Name = "AssignedManagerField";
            this.AssignedManagerField.Size = new Size(154, 27);
            this.AssignedManagerField.TabIndex = 14;
            // 
            // CustomerField
            // 
            this.CustomerField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CustomerField.FormattingEnabled = true;
            this.CustomerField.Location = new Point(159, 49);
            this.CustomerField.Margin = new Padding(4);
            this.CustomerField.Name = "CustomerField";
            this.CustomerField.Size = new Size(154, 27);
            this.CustomerField.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(71, 18);
            this.label4.Name = "label4";
            this.label4.Size = new Size(85, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Request ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(54, 99);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(102, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Request Date";
            // 
            // RequestDateField
            // 
            this.RequestDateField.Location = new Point(159, 99);
            this.RequestDateField.Margin = new Padding(4);
            this.RequestDateField.Name = "RequestDateField";
            this.RequestDateField.Size = new Size(256, 27);
            this.RequestDateField.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(36, 413);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(112, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Consultant Fee";
            // 
            // ConsultantFeeField
            // 
            this.ConsultantFeeField.Location = new Point(161, 413);
            this.ConsultantFeeField.Margin = new Padding(4);
            this.ConsultantFeeField.Name = "ConsultantFeeField";
            this.ConsultantFeeField.Size = new Size(190, 27);
            this.ConsultantFeeField.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new Point(96, 472);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(52, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "Status";
            // 
            // StatusField
            // 
            this.StatusField.FormattingEnabled = true;
            this.StatusField.Location = new Point(162, 472);
            this.StatusField.Margin = new Padding(4);
            this.StatusField.Name = "StatusField";
            this.StatusField.Size = new Size(154, 27);
            this.StatusField.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new Point(36, 527);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(108, 19);
            this.label8.TabIndex = 24;
            this.label8.Text = "Approval Date";
            // 
            // ApprovalDateField
            // 
            this.ApprovalDateField.Location = new Point(161, 527);
            this.ApprovalDateField.Margin = new Padding(4);
            this.ApprovalDateField.Name = "ApprovalDateField";
            this.ApprovalDateField.Size = new Size(256, 27);
            this.ApprovalDateField.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new Point(54, 637);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(95, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "ApprovedBy";
            // 
            // ApprovedByField
            // 
            this.ApprovedByField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ApprovedByField.FormattingEnabled = true;
            this.ApprovedByField.Location = new Point(159, 633);
            this.ApprovedByField.Margin = new Padding(4);
            this.ApprovedByField.Name = "ApprovedByField";
            this.ApprovedByField.Size = new Size(154, 27);
            this.ApprovedByField.TabIndex = 27;
            // 
            // RequestIdField
            // 
            this.RequestIdField.Location = new Point(162, 15);
            this.RequestIdField.Name = "RequestIdField";
            this.RequestIdField.ReadOnly = true;
            this.RequestIdField.Size = new Size(125, 27);
            this.RequestIdField.TabIndex = 28;
            // 
            // DesignRequestDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(807, 761);
            this.Controls.Add(this.RequestIdField);
            this.Controls.Add(this.ApprovedByField);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ApprovalDateField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.StatusField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ConsultantFeeField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RequestDateField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CustomerField);
            this.Controls.Add(this.AssignedManagerField);
            this.Controls.Add(this.SpecificationsField);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4);
            this.Name = "DesignRequestDetailForm";
            this.Text = "DesignRequestDetailForm";
            this.Load += this.DesignRequestDetailForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button SaveButton;
        private Button CancelButton;
        private TextBox SpecificationsField;
        private ComboBox AssignedManagerField;
        private ComboBox CustomerField;
        private Label label4;
        private Label label5;
        private DateTimePicker RequestDateField;
        private Label label6;
        private TextBox ConsultantFeeField;
        private Label label7;
        private ComboBox StatusField;
        private Label label8;
        private DateTimePicker ApprovalDateField;
        private Label label9;
        private ComboBox ApprovedByField;
        private TextBox RequestIdField;
    }
}