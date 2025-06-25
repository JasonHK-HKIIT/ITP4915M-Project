namespace Client
{
    partial class MaterialInventoryDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxWarehouseID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMaterialID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMinStock = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownReorder = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReorder)).BeginInit();
            this.SuspendLayout();

            // Label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.Text = "Warehouse ID";

            // ComboBoxWarehouseID
            this.comboBoxWarehouseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarehouseID.FormattingEnabled = true;
            this.comboBoxWarehouseID.Location = new System.Drawing.Point(150, 27);
            this.comboBoxWarehouseID.Name = "comboBoxWarehouseID";
            this.comboBoxWarehouseID.Size = new System.Drawing.Size(150, 21);

            // Label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.Text = "Material ID";

            // ComboBoxMaterialID
            this.comboBoxMaterialID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaterialID.FormattingEnabled = true;
            this.comboBoxMaterialID.Location = new System.Drawing.Point(150, 57);
            this.comboBoxMaterialID.Name = "comboBoxMaterialID";
            this.comboBoxMaterialID.Size = new System.Drawing.Size(150, 21);

            // Label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.Text = "Quantity in Stock";

            // NumericUpDownQuantity
            this.numericUpDownQuantity.Location = new System.Drawing.Point(150, 87);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(150, 20);

            // Label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.Text = "Minimum Stock Lv";

            // NumericUpDownMinStock
            this.numericUpDownMinStock.Location = new System.Drawing.Point(150, 117);
            this.numericUpDownMinStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numericUpDownMinStock.Name = "numericUpDownMinStock";
            this.numericUpDownMinStock.Size = new System.Drawing.Size(150, 20);

            // Label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.Text = "Reorder Point";

            // NumericUpDownReorder
            this.numericUpDownReorder.Location = new System.Drawing.Point(150, 147);
            this.numericUpDownReorder.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numericUpDownReorder.Name = "numericUpDownReorder";
            this.numericUpDownReorder.Size = new System.Drawing.Size(150, 20);

            // ButtonSave
            this.buttonSave.Location = new System.Drawing.Point(50, 190);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // ButtonCancel
            this.buttonCancel.Location = new System.Drawing.Point(180, 190);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // MaterialInventoryDetailForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 250);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxWarehouseID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMaterialID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownMinStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownReorder);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "MaterialInventoryDetailForm";
            this.Text = "Material Inventory Details";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxWarehouseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMaterialID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMinStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownReorder;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
