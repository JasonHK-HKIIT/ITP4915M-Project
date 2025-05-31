namespace Client
{
    partial class ServiceCaseDetailForm
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 43);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 0;
            label1.Text = "CaseID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 94);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 1;
            label2.Text = "Customer";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 144);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 23);
            label3.TabIndex = 2;
            label3.Text = "Order";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 189);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(95, 23);
            label4.TabIndex = 3;
            label4.Text = "Case Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 238);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(63, 23);
            label5.TabIndex = 4;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 285);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(112, 23);
            label6.TabIndex = 5;
            label6.Text = "Assigned To";
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(176, 35);
            comboBox1.Margin = new Padding(5, 5, 5, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(392, 31);
            comboBox1.TabIndex = 6;
            // 
            // comboBox2
            // 
            comboBox2.Location = new Point(176, 86);
            comboBox2.Margin = new Padding(5, 5, 5, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(392, 31);
            comboBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(176, 137);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(392, 30);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(176, 186);
            textBox2.Margin = new Padding(5, 5, 5, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(392, 30);
            textBox2.TabIndex = 9;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.AddRange(new object[] { "Open", "In Progress", "Closed" });
            comboBox3.Location = new Point(176, 235);
            comboBox3.Margin = new Padding(5, 5, 5, 5);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(392, 31);
            comboBox3.TabIndex = 10;
            // 
            // comboBox4
            // 
            comboBox4.Location = new Point(176, 282);
            comboBox4.Margin = new Padding(5, 5, 5, 5);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(392, 31);
            comboBox4.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(545, 345);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(118, 35);
            button1.TabIndex = 12;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(674, 345);
            button2.Margin = new Padding(5, 5, 5, 5);
            button2.Name = "button2";
            button2.Size = new Size(118, 35);
            button2.TabIndex = 13;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // ServiceCaseDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 414);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "ServiceCaseDetailForm";
            Text = "ServiceCaseDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Button button1;
        private Button button2;
    }
}
