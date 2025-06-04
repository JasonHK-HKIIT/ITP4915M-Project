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
            this.textBox3 = new TextBox();
            this.comboBox1 = new ComboBox();
            this.CustomerField = new ComboBox();
            this.RequestIdField = new MaskedTextBox();
            this.label4 = new Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(77, 49);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(13, 84);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(141, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assigned Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(48, 119);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(104, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Specifications";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(588, 366);
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
            this.CancelButton.Location = new Point(692, 366);
            this.CancelButton.Margin = new Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(96, 29);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(160, 116);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(628, 242);
            this.textBox3.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(162, 81);
            this.comboBox1.Margin = new Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(154, 27);
            this.comboBox1.TabIndex = 14;
            // 
            // CustomerField
            // 
            this.CustomerField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CustomerField.FormattingEnabled = true;
            this.CustomerField.Location = new Point(162, 46);
            this.CustomerField.Margin = new Padding(4);
            this.CustomerField.Name = "CustomerField";
            this.CustomerField.Size = new Size(154, 27);
            this.CustomerField.TabIndex = 15;
            // 
            // RequestIdField
            // 
            this.RequestIdField.Location = new Point(162, 12);
            this.RequestIdField.Mask = "REQ000";
            this.RequestIdField.Name = "RequestIdField";
            this.RequestIdField.Size = new Size(125, 27);
            this.RequestIdField.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(71, 15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(85, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Request ID";
            // 
            // DesignRequestDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(807, 415);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RequestIdField);
            this.Controls.Add(this.CustomerField);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
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
        private TextBox textBox3;
        private ComboBox comboBox1;
        private ComboBox CustomerField;
        private MaskedTextBox RequestIdField;
        private Label label4;
    }
}