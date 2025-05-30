namespace Client
{
    partial class DesignRequestForm
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(171, 15);
            label1.TabIndex = 6;
            label1.Text = "Input supplier phone to search:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1218, 427);
            dataGridView1.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 23);
            textBox1.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(267, 47);
            button3.Name = "button3";
            button3.Size = new Size(121, 23);
            button3.TabIndex = 10;
            button3.Text = "Add Request";
            button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(431, 48);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 11;
            button1.Text = "Edit Selected";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(590, 48);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 12;
            button2.Text = "Approve Selected";
            button2.UseVisualStyleBackColor = true;
            // 
            // DesignRequestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 534);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "DesignRequestForm";
            Text = "DesignRequestForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button button3;
        private Button button1;
        private Button button2;
    }
}