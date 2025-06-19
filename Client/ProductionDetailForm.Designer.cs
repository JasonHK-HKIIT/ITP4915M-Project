namespace Client
{
    partial class ProductionDetailForm
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
            this.label6 = new Label();
            this.textBox3 = new TextBox();
            this.dateTimePicker1 = new DateTimePicker();
            this.comboBox1 = new ComboBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.textBox4 = new NumericUpDown();
            this.textBox2 = new ComboBox();
            this.maskedTextBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)this.textBox4).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(29, 33);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(143, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ProductionOrderID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(38, 74);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(134, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "CustomerOrderID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(104, 115);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(64, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(99, 156);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(69, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(52, 200);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(119, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Scheduled Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(117, 237);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(52, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(193, 112);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new Size(321, 27);
            this.textBox3.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new Point(193, 192);
            this.dateTimePicker1.Margin = new Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(321, 27);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] { "Scheduled", "In Progress", "Completed" });
            this.comboBox1.Location = new Point(193, 233);
            this.comboBox1.Margin = new Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(321, 27);
            this.comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new Point(446, 285);
            this.button1.Margin = new Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(97, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(551, 285);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(97, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Point(193, 154);
            this.textBox4.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(321, 27);
            this.textBox4.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.textBox2.FormattingEnabled = true;
            this.textBox2.Location = new Point(193, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(321, 27);
            this.textBox2.TabIndex = 16;
            this.textBox2.SelectedIndexChanged += this.textBox2_SelectedIndexChanged;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new Point(193, 30);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new Size(321, 27);
            this.maskedTextBox1.TabIndex = 17;
            // 
            // ProductionDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(677, 342);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4);
            this.Name = "ProductionDetailForm";
            this.Text = "ProductionDetailForm";
            this.Load += this.ProductionDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.textBox4).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private NumericUpDown textBox4;
        private ComboBox textBox2;
        private TextBox maskedTextBox1;
    }
}
