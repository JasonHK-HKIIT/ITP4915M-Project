using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class InventoryForm : Form
    {
        public class InventoryRecord
        {
            public string Warehouse { get; set; }
            public string Product { get; set; }
            public int Quantity { get; set; }
            public int ReorderPoint { get; set; }
        }

        private List<InventoryRecord> inventory = new List<InventoryRecord>();

        public InventoryForm()
        {
            InitializeComponent();
            button1.Click += ButtonUpdate_Click; // "Update Inventory"
            button2.Click += ButtonAdd_Click;    // "Add Product"
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inventory.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new InventoryDetailForm())
            {
                detail.Text = "Add Product to Warehouse";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    inventory.Add(new InventoryRecord
                    {
                        Warehouse = detail.Warehouse,
                        Product = detail.Product,
                        Quantity = detail.Quantity,
                        ReorderPoint = detail.ReorderPoint
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var rec = inventory[idx];
            using (var detail = new InventoryDetailForm())
            {
                detail.Text = "Update Inventory";
                detail.SetFields(rec.Warehouse, rec.Product, rec.Quantity, rec.ReorderPoint);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    rec.Warehouse = detail.Warehouse;
                    rec.Product = detail.Product;
                    rec.Quantity = detail.Quantity;
                    rec.ReorderPoint = detail.ReorderPoint;
                    BindDataGrid();
                }
            }
        }
    }

}
