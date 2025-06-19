namespace Client
{
    partial class ShipmentDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.textBox3 = new TextBox();
            this.textBox4 = new TextBox();
            this.dateTimePicker1 = new DateTimePicker();
            this.comboBox1 = new ComboBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.label7 = new Label();
            this.dateTimePicker2 = new DateTimePicker();
            this.textBox2 = new ComboBox();
            this.maskedTextBox1 = new TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(49, 31);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(91, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ShipmentID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 74);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(134, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "CustomerOrderID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(84, 112);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(57, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Carrier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(14, 154);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(127, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "TrackingNumber";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(31, 197);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(108, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "ShipmentDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(84, 240);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(52, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(166, 112);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(321, 27);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Point(166, 152);
            this.textBox4.Margin = new Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(321, 27);
            this.textBox4.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new Point(166, 192);
            this.dateTimePicker1.Margin = new Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(321, 27);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] { "Pending", "Shipped", "Delivered" });
            this.comboBox1.Location = new Point(166, 233);
            this.comboBox1.Margin = new Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(321, 27);
            this.comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new Point(440, 355);
            this.button1.Margin = new Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(97, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(569, 355);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(97, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new Point(60, 288);
            this.label7.Margin = new Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(76, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "IssueDate";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new Point(166, 283);
            this.dateTimePicker2.Margin = new Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(321, 27);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.textBox2.FormattingEnabled = true;
            this.textBox2.Location = new Point(166, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(321, 27);
            this.textBox2.TabIndex = 17;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new Point(166, 28);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new Size(321, 27);
            this.maskedTextBox1.TabIndex = 18;
            // 
            // ShipmentDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(677, 411);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4);
            this.Name = "ShipmentDetailForm";
            this.Text = "ShipmentDetailForm";
            this.Load += this.ShipmentDetailForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Label label7;
        private DateTimePicker dateTimePicker2;
        private ComboBox textBox2;
        private TextBox maskedTextBox1;
    }
}
