using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class ProductionForm : Form
    {
        // Data model
        public class ProductionOrder
        {
            public string ProductionOrderID { get; set; }
            public string CustomerOrder { get; set; }
            public string Product { get; set; }
            public int Quantity { get; set; }
            public DateTime ScheduledDate { get; set; }
            public string Status { get; set; }
        }

        private List<ProductionOrder> productionOrders = new List<ProductionOrder>();

        public ProductionForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            // button3 for delete if needed

            LoadSampleData();
            BindDataGrid();
        }

        private void LoadSampleData()
        {
            productionOrders.Add(new ProductionOrder
            {
                ProductionOrderID = "PO001",
                CustomerOrder = "CO001",
                Product = "Widget X",
                Quantity = 100,
                ScheduledDate = DateTime.Today.AddDays(2),
                Status = "Scheduled"
            });
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productionOrders
                .Select(p => new
                {
                    p.ProductionOrderID,
                    p.CustomerOrder,
                    p.Product,
                    p.Quantity,
                    ScheduledDate = p.ScheduledDate.ToShortDateString(),
                    p.Status
                }).ToList();
        }

        // ADD
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detailForm = new ProductionDetailForm())
            {
                detailForm.Text = "Add Production Order";
                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    var newOrder = new ProductionOrder
                    {
                        ProductionOrderID = detailForm.ProductionOrderID,
                        CustomerOrder = detailForm.CustomerOrder,
                        Product = detailForm.Product,
                        Quantity = detailForm.Quantity,
                        ScheduledDate = detailForm.ScheduledDate,
                        Status = detailForm.Status
                    };
                    productionOrders.Add(newOrder);
                    BindDataGrid();
                }
            }
        }

        // EDIT
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a production order to edit.");
                return;
            }

            int idx = dataGridView1.SelectedRows[0].Index;
            var order = productionOrders[idx];

            using (var detailForm = new ProductionDetailForm())
            {
                detailForm.Text = "Edit Production Order";
                detailForm.SetFields(
                    order.ProductionOrderID,
                    order.CustomerOrder,
                    order.Product,
                    order.Quantity.ToString(),
                    order.ScheduledDate,
                    order.Status);

                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    order.ProductionOrderID = detailForm.ProductionOrderID;
                    order.CustomerOrder = detailForm.CustomerOrder;
                    order.Product = detailForm.Product;
                    order.Quantity = detailForm.Quantity;
                    order.ScheduledDate = detailForm.ScheduledDate;
                    order.Status = detailForm.Status;
                    BindDataGrid();
                }
            }
        }
    }
}
