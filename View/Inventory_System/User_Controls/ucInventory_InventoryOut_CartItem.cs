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
    public partial class ucInventory_InventoryOut_CartItem : UserControl
    {
        public int productID;
        public string barcode;
        public string sku;
        public string productName;
        public string unitOfMeasure;
        public double quantity;
        public double unitPrice;
        public double sellingPrice;
        public double discount;
        public double totalAmount;
        public int TransactionID;
        public string AddorEditorEditProduct;
        public Boolean deleteMe;

        public ucInventory_InventoryOut_CartItem()
        {
            InitializeComponent();
        }

        private void ucInventory_InventoryIn_CartItem_Load(object sender, EventArgs e)
        {
                lblProductName.Text = productName;
                txtQuantity.Text = "" + quantity;
        }

        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            quantity = Convert.ToDouble(txtQuantity.Text) + 1;
            txtQuantity.Text = "" + quantity;

        }

        private void btnDeductQuantity_Click(object sender, EventArgs e)
        {
            quantity = Convert.ToDouble(txtQuantity.Text) - 1;
            txtQuantity.Text = "" + quantity;

            if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                txtQuantity.Text = "0";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            deleteMe = true;
            var targetForm = Application.OpenForms.OfType<frmInventory_InventoryOut_AddNewTransaction>().Single();
            targetForm.deleteItem();
        }
    }
}
