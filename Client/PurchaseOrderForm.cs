using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class PurchaseOrderForm : Form
    {
        // Data model for Purchase Order
        public class PurchaseOrder
        {
            public string PONumber { get; set; }
            public string Supplier { get; set; }
            public DateTime PODate { get; set; }
            public string Status { get; set; }
        }

        private List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();

        public PurchaseOrderForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;   // "Add Purchase Order"
            button2.Click += ButtonEdit_Click;  // "Edit Selected"
            // button3 ("View PO Lines") can be wired for additional detail if needed

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = purchaseOrders.Select(po => new
            {
                po.PONumber,
                po.Supplier,
                PODate = po.PODate.ToShortDateString(),
                po.Status
            }).ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Add Purchase Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    purchaseOrders.Add(new PurchaseOrder
                    {
                        PONumber = detail.PONumber,
                        Supplier = detail.Supplier,
                        PODate = detail.PODate,
                        Status = detail.Status
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase order to edit.");
                return;
            }
            int idx = dataGridView1.SelectedRows[0].Index;
            var po = purchaseOrders[idx];
            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Edit Purchase Order";
                detail.SetFields(po.PONumber, po.Supplier, po.PODate, po.Status);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    po.PONumber = detail.PONumber;
                    po.Supplier = detail.Supplier;
                    po.PODate = detail.PODate;
                    po.Status = detail.Status;
                    BindDataGrid();
                }
            }
        }
    }
}
