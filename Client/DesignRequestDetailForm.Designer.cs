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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            SpecificationsField = new TextBox();
            AssignedManagerField = new ComboBox();
            CustomerField = new ComboBox();
            RequestIdField = new MaskedTextBox();
            label4 = new Label();
            label5 = new Label();
            RequestDateField = new DateTimePicker();
            label6 = new Label();
            ConsultantFeeField = new TextBox();
            label7 = new Label();
            StatusField = new ComboBox();
            label8 = new Label();
            ApprovalDateField = new DateTimePicker();
            label9 = new Label();
            ApprovedByField = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 42);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Customer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 462);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Assigned Manager";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 119);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 2;
            label3.Text = "Specifications";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(435, 564);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 9;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(526, 564);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 10;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SpecificationsField
            // 
            SpecificationsField.Location = new Point(124, 119);
            SpecificationsField.Multiline = true;
            SpecificationsField.Name = "SpecificationsField";
            SpecificationsField.Size = new Size(489, 192);
            SpecificationsField.TabIndex = 13;
            // 
            // AssignedManagerField
            // 
            AssignedManagerField.DropDownStyle = ComboBoxStyle.DropDownList;
            AssignedManagerField.FormattingEnabled = true;
            AssignedManagerField.Location = new Point(124, 459);
            AssignedManagerField.Name = "AssignedManagerField";
            AssignedManagerField.Size = new Size(121, 23);
            AssignedManagerField.TabIndex = 14;
            // 
            // CustomerField
            // 
            CustomerField.DropDownStyle = ComboBoxStyle.DropDownList;
            CustomerField.FormattingEnabled = true;
            CustomerField.Location = new Point(124, 39);
            CustomerField.Name = "CustomerField";
            CustomerField.Size = new Size(121, 23);
            CustomerField.TabIndex = 15;
            // 
            // RequestIdField
            // 
            RequestIdField.Location = new Point(124, 11);
            RequestIdField.Margin = new Padding(2);
            RequestIdField.Mask = "REQ000";
            RequestIdField.Name = "RequestIdField";
            RequestIdField.Size = new Size(98, 23);
            RequestIdField.TabIndex = 16;
            RequestIdField.MaskInputRejected += RequestIdField_MaskInputRejected;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 14);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 17;
            label4.Text = "Request ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 78);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 18;
            label5.Text = "Request Date";
            // 
            // RequestDateField
            // 
            RequestDateField.Location = new Point(124, 78);
            RequestDateField.Name = "RequestDateField";
            RequestDateField.Size = new Size(200, 23);
            RequestDateField.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 326);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 20;
            label6.Text = "Consultant Fee";
            // 
            // ConsultantFeeField
            // 
            ConsultantFeeField.Location = new Point(125, 326);
            ConsultantFeeField.Name = "ConsultantFeeField";
            ConsultantFeeField.Size = new Size(149, 23);
            ConsultantFeeField.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(75, 373);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 22;
            label7.Text = "Status";
            // 
            // StatusField
            // 
            StatusField.FormattingEnabled = true;
            StatusField.Location = new Point(126, 373);
            StatusField.Name = "StatusField";
            StatusField.Size = new Size(121, 23);
            StatusField.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 416);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 24;
            label8.Text = "Approval Date";
            // 
            // ApprovalDateField
            // 
            ApprovalDateField.Location = new Point(125, 416);
            ApprovalDateField.Name = "ApprovalDateField";
            ApprovalDateField.Size = new Size(200, 23);
            ApprovalDateField.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(42, 503);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 26;
            label9.Text = "ApprovedBy";
            // 
            // ApprovedByField
            // 
            ApprovedByField.DropDownStyle = ComboBoxStyle.DropDownList;
            ApprovedByField.FormattingEnabled = true;
            ApprovedByField.Location = new Point(124, 500);
            ApprovedByField.Name = "ApprovedByField";
            ApprovedByField.Size = new Size(121, 23);
            ApprovedByField.TabIndex = 27;
            // 
            // DesignRequestDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 601);
            Controls.Add(ApprovedByField);
            Controls.Add(label9);
            Controls.Add(ApprovalDateField);
            Controls.Add(label8);
            Controls.Add(StatusField);
            Controls.Add(label7);
            Controls.Add(ConsultantFeeField);
            Controls.Add(label6);
            Controls.Add(RequestDateField);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(RequestIdField);
            Controls.Add(CustomerField);
            Controls.Add(AssignedManagerField);
            Controls.Add(SpecificationsField);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DesignRequestDetailForm";
            Text = "DesignRequestDetailForm";
            Load += DesignRequestDetailForm_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private MaskedTextBox RequestIdField;
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
    }
}