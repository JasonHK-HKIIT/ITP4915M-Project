namespace Client
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox SearchField;
        private Button NewButton;
        private DataGridView dataGridView1;
        private Button EditButton;
        private Button button3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.SearchField = new TextBox();
            this.NewButton = new Button();
            this.dataGridView1 = new DataGridView();
            this.EditButton = new Button();
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
            this.label1.Size = new Size(188, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input username to search:";
            // 
            // SearchField
            // 
            this.SearchField.Location = new Point(16, 61);
            this.SearchField.Margin = new Padding(4);
            this.SearchField.Name = "SearchField";
            this.SearchField.Size = new Size(229, 27);
            this.SearchField.TabIndex = 1;
            this.SearchField.KeyUp += this.SearchField_KeyUp;
            // 
            // NewButton
            // 
            this.NewButton.Location = new Point(353, 59);
            this.NewButton.Margin = new Padding(4);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new Size(155, 29);
            this.NewButton.TabIndex = 2;
            this.NewButton.Text = "Add User";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += this.NewButton_Click;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 121);
            this.dataGridView1.Margin = new Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(1566, 541);
            this.dataGridView1.TabIndex = 3;
            // 
            // EditButton
            // 
            this.EditButton.Location = new Point(542, 59);
            this.EditButton.Margin = new Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new Size(155, 29);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Edit Selected";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += this.EditButton_Click;
            // 
            // button3
            // 
            this.button3.Location = new Point(731, 59);
            this.button3.Margin = new Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new Size(155, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete Selected";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1574, 677);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.SearchField);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += this.AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
