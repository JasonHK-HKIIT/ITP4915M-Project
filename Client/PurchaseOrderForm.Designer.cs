namespace Client
{
    partial class PurchaseOrderForm
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(185, 15);
            label1.TabIndex = 0;
            label1.Text = "Input purchase order ID to search:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(274, 47);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 2;
            button1.Text = "Add Purchase Order";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1218, 427);
            dataGridView1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(422, 47);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 4;
            button2.Text = "Edit Selected";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PurchaseOrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 534);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "PurchaseOrderForm";
            Text = "PurchaseOrderForm";
            Load += PurchaseOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
