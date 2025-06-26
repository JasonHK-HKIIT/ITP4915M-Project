namespace Client
{
    partial class MaterialInventoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            btn_refresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 29);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(412, 23);
            label1.TabIndex = 0;
            label1.Text = "Input (Material ID) / (Material Name) to search:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 74);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 30);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(431, 72);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(190, 35);
            button1.TabIndex = 2;
            button1.Text = "Update Inventory";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 146);
            dataGridView1.Margin = new Padding(5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1914, 655);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(663, 72);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(190, 35);
            button2.TabIndex = 4;
            button2.Text = "Add Material";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(897, 74);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(190, 35);
            button3.TabIndex = 5;
            button3.Text = "Delete Material";
            button3.UseVisualStyleBackColor = true;
            // 
            // btn_refresh
            // 
            btn_refresh.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            btn_refresh.Location = new Point(1109, 74);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(40, 38);
            btn_refresh.TabIndex = 6;
            btn_refresh.Text = "⟳";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += button4_Click;
            // 
            // MaterialInventoryForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1923, 819);
            Controls.Add(btn_refresh);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "MaterialInventoryForm";
            Text = "Material Inventory Form";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button button3;
        private Button btn_refresh;
    }
}
