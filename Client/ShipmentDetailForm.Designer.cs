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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            label7 = new Label();
            dateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 38);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 23);
            label1.TabIndex = 0;
            label1.Text = "ShipmentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 89);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(162, 23);
            label2.TabIndex = 1;
            label2.Text = "CustomerOrderID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 135);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 23);
            label3.TabIndex = 2;
            label3.Text = "Carrier";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 187);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(154, 23);
            label4.TabIndex = 3;
            label4.Text = "TrackingNumber";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 239);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(133, 23);
            label5.TabIndex = 4;
            label5.Text = "ShipmentDate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(103, 290);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 23);
            label6.TabIndex = 5;
            label6.Text = "Status";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(203, 35);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(392, 30);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(203, 86);
            textBox2.Margin = new Padding(5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(392, 30);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(203, 135);
            textBox3.Margin = new Padding(5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(392, 30);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(203, 184);
            textBox4.Margin = new Padding(5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(392, 30);
            textBox4.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(203, 233);
            dateTimePicker1.Margin = new Padding(5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(392, 30);
            dateTimePicker1.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(new object[] { "Preparing", "In Transit", "Delivered" });
            comboBox1.Location = new Point(203, 282);
            comboBox1.Margin = new Padding(5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(392, 31);
            comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(538, 430);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(118, 35);
            button1.TabIndex = 12;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(695, 430);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(118, 35);
            button2.TabIndex = 13;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 349);
            label7.Name = "label7";
            label7.Size = new Size(93, 23);
            label7.TabIndex = 14;
            label7.Text = "IssueDate";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(203, 343);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(392, 30);
            dateTimePicker2.TabIndex = 15;
            // 
            // ShipmentDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 498);
            Controls.Add(dateTimePicker2);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "ShipmentDetailForm";
            Text = "ShipmentDetailForm";
            Load += ShipmentDetailForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Label label7;
        private DateTimePicker dateTimePicker2;
    }
}
