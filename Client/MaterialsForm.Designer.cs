namespace Client
{
    partial class MaterialsForm
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
            this.SearchField = new TextBox();
            this.NewButton = new Button();
            this.EditButton = new Button();
            this.MaterialsView = new DataGridView();
            this.label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)this.MaterialsView).BeginInit();
            this.SuspendLayout();
            // 
            // SearchField
            // 
            this.SearchField.Location = new Point(74, 14);
            this.SearchField.Name = "SearchField";
            this.SearchField.Size = new Size(244, 27);
            this.SearchField.TabIndex = 0;
            this.SearchField.KeyDown += this.SearchField_KeyDown;
            // 
            // NewButton
            // 
            this.NewButton.Location = new Point(833, 12);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new Size(94, 29);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += this.NewButton_Click;
            // 
            // EditButton
            // 
            this.EditButton.Location = new Point(933, 12);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new Size(94, 29);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += this.EditButton_Click;
            // 
            // MaterialsView
            // 
            this.MaterialsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaterialsView.Location = new Point(12, 47);
            this.MaterialsView.MultiSelect = false;
            this.MaterialsView.Name = "MaterialsView";
            this.MaterialsView.ReadOnly = true;
            this.MaterialsView.RowHeadersWidth = 51;
            this.MaterialsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MaterialsView.Size = new Size(1015, 534);
            this.MaterialsView.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new Size(56, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // MaterialsForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1039, 593);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaterialsView);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.SearchField);
            this.Name = "MaterialsForm";
            this.Text = "MaterialsForm";
            this.Load += this.MaterialsForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.MaterialsView).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox SearchField;
        private Button NewButton;
        private Button EditButton;
        private DataGridView MaterialsView;
        private Label label1;
    }
}