namespace Client
{
    partial class QuotationDetailForm
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
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationDetailForm));
            Label label2;
            Label label3;
            Label label5;
            Label label6;
            Label QuotationDateLabel;
            this.ProductField = new ComboBox();
            this.CustomerField = new ComboBox();
            this.SaveButton = new Button();
            this.CancelButton = new Button();
            this.QuantityField = new NumericUpDown();
            this.ValidityPeriodField = new DateTimePicker();
            this.QuotationDateField = new DateTimePicker();
            this.StatusField = new ComboBox();
            this.label4 = new Label();
            this.QuotationIdField = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            QuotationDateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)this.QuantityField).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // QuotationDateLabel
            // 
            resources.ApplyResources(QuotationDateLabel, "QuotationDateLabel");
            QuotationDateLabel.Name = "QuotationDateLabel";
            // 
            // ProductField
            // 
            this.ProductField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ProductField.FormattingEnabled = true;
            resources.ApplyResources(this.ProductField, "ProductField");
            this.ProductField.Name = "ProductField";
            // 
            // CustomerField
            // 
            this.CustomerField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CustomerField.FormattingEnabled = true;
            resources.ApplyResources(this.CustomerField, "CustomerField");
            this.CustomerField.Name = "CustomerField";
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += this.SaveButton_Click;
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // QuantityField
            // 
            resources.ApplyResources(this.QuantityField, "QuantityField");
            this.QuantityField.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            this.QuantityField.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.QuantityField.Name = "QuantityField";
            this.QuantityField.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ValidityPeriodField
            // 
            resources.ApplyResources(this.ValidityPeriodField, "ValidityPeriodField");
            this.ValidityPeriodField.Name = "ValidityPeriodField";
            // 
            // QuotationDateField
            // 
            resources.ApplyResources(this.QuotationDateField, "QuotationDateField");
            this.QuotationDateField.Name = "QuotationDateField";
            // 
            // StatusField
            // 
            this.StatusField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.StatusField.FormattingEnabled = true;
            this.StatusField.Items.AddRange(new object[] { resources.GetString("StatusField.Items"), resources.GetString("StatusField.Items1"), resources.GetString("StatusField.Items2") });
            resources.ApplyResources(this.StatusField, "StatusField");
            this.StatusField.Name = "StatusField";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // QuotationIdField
            // 
            resources.ApplyResources(this.QuotationIdField, "QuotationIdField");
            this.QuotationIdField.Name = "QuotationIdField";
            this.QuotationIdField.ReadOnly = true;
            // 
            // QuotationDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.QuotationIdField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusField);
            this.Controls.Add(this.QuotationDateField);
            this.Controls.Add(QuotationDateLabel);
            this.Controls.Add(this.ValidityPeriodField);
            this.Controls.Add(this.QuantityField);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CustomerField);
            this.Controls.Add(this.ProductField);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuotationDetailForm";
            this.Load += this.QuotationDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.QuantityField).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private ComboBox ProductField;
        private ComboBox CustomerField;
        private Button SaveButton;
        private Button CancelButton;
        private NumericUpDown QuantityField;
        private DateTimePicker ValidityPeriodField;
        private Label QuotationDateLabel;
        private DateTimePicker QuotationDateField;
        private ComboBox StatusField;
        private Label label4;
        private TextBox QuotationIdField;
    }
}