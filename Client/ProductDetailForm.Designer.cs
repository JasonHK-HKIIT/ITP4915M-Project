namespace Client
{
    partial class ProductDetailForm
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
            this.label4 = new Label();
            this.label5 = new Label();
            this.SaveButton = new Button();
            this.CancelButton = new Button();
            this.NameField = new TextBox();
            this.TypeField = new TextBox();
            this.SpecificationsField = new TextBox();
            this.DesignRequestField = new ComboBox();
            this.UnitPriceField = new NumericUpDown();
            this.label6 = new Label();
            this.ProductIdField = new TextBox();
            ((System.ComponentModel.ISupportInitialize)this.UnitPriceField).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 49);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(170, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linked Design Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(73, 84);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(110, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(82, 119);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(101, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(107, 152);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(76, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Unit Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(79, 187);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(104, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Specifications";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(601, 353);
            this.SaveButton.Margin = new Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(97, 29);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += this.SaveButton_Click;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new Point(706, 353);
            this.CancelButton.Margin = new Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(97, 29);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // NameField
            // 
            this.NameField.Location = new Point(191, 81);
            this.NameField.Margin = new Padding(4);
            this.NameField.Name = "NameField";
            this.NameField.Size = new Size(240, 27);
            this.NameField.TabIndex = 13;
            // 
            // TypeField
            // 
            this.TypeField.Location = new Point(191, 116);
            this.TypeField.Margin = new Padding(4);
            this.TypeField.Name = "TypeField";
            this.TypeField.Size = new Size(240, 27);
            this.TypeField.TabIndex = 14;
            // 
            // SpecificationsField
            // 
            this.SpecificationsField.Location = new Point(191, 184);
            this.SpecificationsField.Margin = new Padding(4);
            this.SpecificationsField.Multiline = true;
            this.SpecificationsField.Name = "SpecificationsField";
            this.SpecificationsField.Size = new Size(612, 161);
            this.SpecificationsField.TabIndex = 16;
            // 
            // DesignRequestField
            // 
            this.DesignRequestField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DesignRequestField.FormattingEnabled = true;
            this.DesignRequestField.Location = new Point(191, 46);
            this.DesignRequestField.Margin = new Padding(4);
            this.DesignRequestField.Name = "DesignRequestField";
            this.DesignRequestField.Size = new Size(407, 27);
            this.DesignRequestField.TabIndex = 17;
            // 
            // UnitPriceField
            // 
            this.UnitPriceField.DecimalPlaces = 2;
            this.UnitPriceField.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.UnitPriceField.Location = new Point(191, 150);
            this.UnitPriceField.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.UnitPriceField.Name = "UnitPriceField";
            this.UnitPriceField.Size = new Size(95, 27);
            this.UnitPriceField.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(100, 15);
            this.label6.Name = "label6";
            this.label6.Size = new Size(83, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Product ID";
            // 
            // ProductIdField
            // 
            this.ProductIdField.Location = new Point(191, 12);
            this.ProductIdField.Name = "ProductIdField";
            this.ProductIdField.ReadOnly = true;
            this.ProductIdField.Size = new Size(125, 27);
            this.ProductIdField.TabIndex = 21;
            // 
            // ProductDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(818, 396);
            this.Controls.Add(this.ProductIdField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UnitPriceField);
            this.Controls.Add(this.DesignRequestField);
            this.Controls.Add(this.SpecificationsField);
            this.Controls.Add(this.TypeField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDetailForm";
            this.Text = "ProductDetailForm";
            this.Load += this.ProductDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.UnitPriceField).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button SaveButton;
        private Button CancelButton;
        private TextBox NameField;
        private TextBox TypeField;
        private TextBox textBox4;
        private TextBox SpecificationsField;
        private ComboBox DesignRequestField;
        private NumericUpDown UnitPriceField;
        private Label label6;
        private TextBox ProductIdField;
    }
}