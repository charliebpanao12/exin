using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EXIN.View;
using EXIN.Inventory_System;

namespace EXIN.Inventory_System
{
    public partial class ucInventory_CustomerPurchaseOrder_CartItem : UserControl
    {

        public int productID;
        public string barcode;
        public string sku;
        public string itemname;
        public string unitOfMeasure;
        public double orderquantity;
        public double unitPrice;
        public double sellingPrice;
        public double discount;
        public double totalAmount;
        public int TransactionID;
        public string AddorEditorEditProduct;
        public Boolean deleteMe;

        public ucInventory_CustomerPurchaseOrder_CartItem()
        {
            InitializeComponent();
        }

        private void ucInventory_InventoryIn_CartItem_Load(object sender, EventArgs e)
        {
                lblProductName.Text = itemname;
                txtQuantity.Text = "" + orderquantity;
        }

        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            orderquantity = Convert.ToDouble(txtQuantity.Text) + 1;
            txtQuantity.Text = "" + orderquantity;

        }

        private void btnDeductQuantity_Click(object sender, EventArgs e)
        {
            orderquantity = Convert.ToDouble(txtQuantity.Text) - 1;
            txtQuantity.Text = "" + orderquantity;

            if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                txtQuantity.Text = "0";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            deleteMe = true;
            var targetForm = Application.OpenForms.OfType<frmInventory_CustomerPurchaseOrder_AddNewTransaction>().Single();
            targetForm.deleteItem();
        }
    }
}
