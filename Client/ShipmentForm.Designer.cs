namespace Client
{
    partial class ShipmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button buttonGenerateNote; 

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
            buttonGenerateNote = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(436, 15);
            label1.TabIndex = 0;
            label1.Text = "Input (ShipmentID) / (CustomerOrderID) / (Carrier) / (TrackingNumber) to search:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 48);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(275, 47);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 2;
            button1.Text = "Add Shipment";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 96);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1218, 427);
            dataGridView1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(422, 47);
            button2.Margin = new Padding(2, 2, 2, 2);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 4;
            button2.Text = "Edit Selected";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(569, 47);
            button3.Margin = new Padding(2, 2, 2, 2);
            button3.Name = "button3";
            button3.Size = new Size(121, 23);
            button3.TabIndex = 5;
            button3.Text = "Delete Selected";
            button3.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateNote
            // 
            buttonGenerateNote.Location = new Point(716, 47);
            buttonGenerateNote.Margin = new Padding(2, 2, 2, 2);
            buttonGenerateNote.Name = "buttonGenerateNote";
            buttonGenerateNote.Size = new Size(148, 23);
            buttonGenerateNote.TabIndex = 6;
            buttonGenerateNote.Text = "Generate Delivery Note";
            buttonGenerateNote.UseVisualStyleBackColor = true;
            buttonGenerateNote.Click += buttonGenerateNote_Click;
            // 
            // ShipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 534);
            Controls.Add(buttonGenerateNote);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ShipmentForm";
            Text = "ShipmentForm";
            Load += ShipmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
