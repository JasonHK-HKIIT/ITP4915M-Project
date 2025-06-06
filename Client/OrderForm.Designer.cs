namespace Client
{
    partial class OrderForm
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
            label1 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 29);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(217, 23);
            label1.TabIndex = 8;
            label1.Text = "Input order ID to search:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 77);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 30);
            textBox1.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(492, 77);
            button3.Margin = new Padding(5, 5, 5, 5);
            button3.Name = "button3";
            button3.Size = new Size(190, 35);
            button3.TabIndex = 12;
            button3.Text = "Add Order";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(740, 77);
            button2.Margin = new Padding(5, 5, 5, 5);
            button2.Name = "button2";
            button2.Size = new Size(190, 35);
            button2.TabIndex = 13;
            button2.Text = "Edit Selected";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 146);
            dataGridView1.Margin = new Padding(5, 5, 5, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1914, 655);
            dataGridView1.TabIndex = 14;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 819);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "OrderForm";
            Text = "OrderForm";
            Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
        private DataGridView dataGridView1;
    }
}