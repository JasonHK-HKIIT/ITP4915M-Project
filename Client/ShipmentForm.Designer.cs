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
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.dataGridView1 = new DataGridView();
            this.button2 = new Button();
            this.button3 = new Button();
            this.buttonGenerateNote = new Button(); 

            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new Size(205, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Shipment ID to search:";

            // textBox1
            this.textBox1.Location = new Point(16, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(229, 27);
            this.textBox1.TabIndex = 1;

            // button1 - Add
            this.button1.Location = new Point(353, 59);
            this.button1.Name = "button1";
            this.button1.Size = new Size(155, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Shipment";
            this.button1.UseVisualStyleBackColor = true;

            // button2 - Edit
            this.button2.Location = new Point(542, 59);
            this.button2.Name = "button2";
            this.button2.Size = new Size(155, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Edit Selected";
            this.button2.UseVisualStyleBackColor = true;

            // button3 - Delete
            this.button3.Location = new Point(731, 59);
            this.button3.Name = "button3";
            this.button3.Size = new Size(155, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete Selected";
            this.button3.UseVisualStyleBackColor = true;

            // buttonGenerateNote
            this.buttonGenerateNote.Location = new Point(920, 59);
            this.buttonGenerateNote.Name = "buttonGenerateNote";
            this.buttonGenerateNote.Size = new Size(190, 29);
            this.buttonGenerateNote.TabIndex = 6;
            this.buttonGenerateNote.Text = "Generate Delivery Note";
            this.buttonGenerateNote.UseVisualStyleBackColor = true;
            this.buttonGenerateNote.Click += this.buttonGenerateNote_Click;

            // dataGridView1
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(1566, 541);
            this.dataGridView1.TabIndex = 3;

            // ShipmentForm
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1573, 677);
            this.Controls.Add(this.buttonGenerateNote);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ShipmentForm";
            this.Text = "ShipmentForm";
            this.Load += this.ShipmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
