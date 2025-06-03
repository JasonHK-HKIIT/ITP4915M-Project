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
            this.button1 = new Button();
            this.button2 = new Button();
            this.textBox3 = new TextBox();
            this.comboBox1 = new ComboBox();
            this.CustomerComboBox = new ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 16);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(13, 51);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(141, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assigned Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(47, 176);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(104, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Specifications";
            // 
            // button1
            // 
            this.button1.Location = new Point(727, 444);
            this.button1.Margin = new Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(97, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(844, 444);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(97, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(311, 176);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(627, 242);
            this.textBox3.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(162, 48);
            this.comboBox1.Margin = new Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(155, 27);
            this.comboBox1.TabIndex = 14;
            // 
            // CustomerComboBox
            // 
            this.CustomerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CustomerComboBox.FormattingEnabled = true;
            this.CustomerComboBox.Location = new Point(162, 13);
            this.CustomerComboBox.Margin = new Padding(4);
            this.CustomerComboBox.Name = "CustomerComboBox";
            this.CustomerComboBox.Size = new Size(155, 27);
            this.CustomerComboBox.TabIndex = 15;
            // 
            // DesignRequestDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(990, 501);
            this.Controls.Add(this.CustomerComboBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private ComboBox CustomerComboBox;
    }
}