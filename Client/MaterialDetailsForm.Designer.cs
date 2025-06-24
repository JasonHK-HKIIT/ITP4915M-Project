namespace Client
{
    partial class MaterialDetailsForm
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
            this.MaterialIdField = new TextBox();
            this.label2 = new Label();
            this.NameField = new TextBox();
            this.DescriptionField = new TextBox();
            this.label3 = new Label();
            this.QuantityPerUnitField = new NumericUpDown();
            this.label4 = new Label();
            this.SaveButton = new Button();
            this.CancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)this.QuantityPerUnitField).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material ID";
            // 
            // MaterialIdField
            // 
            this.MaterialIdField.Location = new Point(115, 12);
            this.MaterialIdField.Name = "MaterialIdField";
            this.MaterialIdField.ReadOnly = true;
            this.MaterialIdField.Size = new Size(268, 27);
            this.MaterialIdField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(58, 48);
            this.label2.Name = "label2";
            this.label2.Size = new Size(51, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // NameField
            // 
            this.NameField.Location = new Point(115, 45);
            this.NameField.Name = "NameField";
            this.NameField.Size = new Size(268, 27);
            this.NameField.TabIndex = 3;
            // 
            // DescriptionField
            // 
            this.DescriptionField.Location = new Point(115, 78);
            this.DescriptionField.Name = "DescriptionField";
            this.DescriptionField.Size = new Size(268, 27);
            this.DescriptionField.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new Size(88, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // QuantityPerUnitField
            // 
            this.QuantityPerUnitField.DecimalPlaces = 2;
            this.QuantityPerUnitField.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.QuantityPerUnitField.Location = new Point(115, 111);
            this.QuantityPerUnitField.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            this.QuantityPerUnitField.Name = "QuantityPerUnitField";
            this.QuantityPerUnitField.Size = new Size(268, 27);
            this.QuantityPerUnitField.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new Size(97, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Qty. per Unit";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(189, 144);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(94, 29);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += this.SaveButton_Click;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new Point(289, 144);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(94, 29);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // MaterialDetailsForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(395, 184);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QuantityPerUnitField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DescriptionField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaterialIdField);
            this.Controls.Add(this.label1);
            this.Name = "MaterialDetailsForm";
            this.Text = "MaterialDetailsForm";
            this.Load += this.MaterialDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.QuantityPerUnitField).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox MaterialIdField;
        private Label label2;
        private TextBox NameField;
        private TextBox DescriptionField;
        private Label label3;
        private NumericUpDown QuantityPerUnitField;
        private Label label4;
        private Button SaveButton;
        private Button CancelButton;
    }
}