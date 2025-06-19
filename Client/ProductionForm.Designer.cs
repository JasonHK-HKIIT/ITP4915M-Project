namespace Client
{
    partial class ProductionForm
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
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.dataGridView1 = new DataGridView();
            this.button2 = new Button();
            this.button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(16, 24);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(258, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input production order ID to search:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(16, 61);
            this.textBox1.Margin = new Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(229, 27);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new Point(353, 59);
            this.button1.Margin = new Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(155, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Production Order";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 121);
            this.dataGridView1.Margin = new Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(1566, 541);
            this.dataGridView1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new Point(542, 59);
            this.button2.Margin = new Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(155, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Edit Selected";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new Point(731, 59);
            this.button3.Margin = new Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new Size(155, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete Selected";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ProductionForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1573, 677);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "ProductionForm";
            this.Text = "ProductionForm";
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
    }
}
