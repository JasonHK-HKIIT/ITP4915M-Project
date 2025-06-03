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
            this.button1 = new Button();
            this.button2 = new Button();
            this.NameField = new TextBox();
            this.TypeField = new TextBox();
            this.SpecificationsField = new TextBox();
            this.DesignRequestField = new ComboBox();
            this.UnitPriceField = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.UnitPriceField).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 16);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(170, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linked Design Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(73, 51);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(110, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(82, 86);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(101, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(107, 119);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(76, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Unit Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(79, 154);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(104, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Specifications";
            // 
            // button1
            // 
            this.button1.Location = new Point(601, 320);
            this.button1.Margin = new Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(97, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(706, 320);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(97, 29);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // NameField
            // 
            this.NameField.Location = new Point(191, 48);
            this.NameField.Margin = new Padding(4);
            this.NameField.Name = "NameField";
            this.NameField.Size = new Size(240, 27);
            this.NameField.TabIndex = 13;
            // 
            // TypeField
            // 
            this.TypeField.Location = new Point(191, 83);
            this.TypeField.Margin = new Padding(4);
            this.TypeField.Name = "TypeField";
            this.TypeField.Size = new Size(240, 27);
            this.TypeField.TabIndex = 14;
            // 
            // SpecificationsField
            // 
            this.SpecificationsField.Location = new Point(191, 151);
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
            this.DesignRequestField.Location = new Point(191, 13);
            this.DesignRequestField.Margin = new Padding(4);
            this.DesignRequestField.Name = "DesignRequestField";
            this.DesignRequestField.Size = new Size(407, 27);
            this.DesignRequestField.TabIndex = 17;
            // 
            // UnitPriceField
            // 
            this.UnitPriceField.DecimalPlaces = 2;
            this.UnitPriceField.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.UnitPriceField.Location = new Point(191, 117);
            this.UnitPriceField.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.UnitPriceField.Name = "UnitPriceField";
            this.UnitPriceField.Size = new Size(95, 27);
            this.UnitPriceField.TabIndex = 18;
            // 
            // ProductDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(818, 362);
            this.Controls.Add(this.UnitPriceField);
            this.Controls.Add(this.DesignRequestField);
            this.Controls.Add(this.SpecificationsField);
            this.Controls.Add(this.TypeField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private Button button1;
        private Button button2;
        private TextBox NameField;
        private TextBox TypeField;
        private TextBox textBox4;
        private TextBox SpecificationsField;
        private ComboBox DesignRequestField;
        private NumericUpDown UnitPriceField;
    }
}