namespace Client
{
    partial class InventoryDetailForm
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
            this.comboBox1 = new ComboBox();
            this.comboBox2 = new ComboBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.label5 = new Label();
            this.textBox1 = new NumericUpDown();
            this.textBox2 = new NumericUpDown();
            this.textBox3 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.textBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.textBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.textBox3).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(77, 39);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(96, 80);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(64, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(90, 117);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(69, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(55, 158);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(106, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reorder Point";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] { "WH001", "WH002", "WH003" });
            this.comboBox1.Location = new Point(215, 33);
            this.comboBox1.Margin = new Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(322, 27);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.Location = new Point(215, 73);
            this.comboBox2.Margin = new Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(322, 27);
            this.comboBox2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new Point(446, 260);
            this.button1.Margin = new Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(96, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(561, 260);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(96, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(10, 204);
            this.label5.Name = "label5";
            this.label5.Size = new Size(151, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "MinimumStockLevel";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(215, 115);
            this.textBox1.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(322, 27);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new Point(215, 156);
            this.textBox2.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(322, 27);
            this.textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(215, 202);
            this.textBox3.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(322, 27);
            this.textBox3.TabIndex = 14;
            // 
            // InventoryDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(676, 319);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4);
            this.Name = "InventoryDetailForm";
            this.Text = "InventoryDetailForm";
            this.Load += this.InventoryDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.textBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.textBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.textBox3).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private Label label5;
        private NumericUpDown textBox1;
        private NumericUpDown textBox2;
        private NumericUpDown textBox3;
    }
}
