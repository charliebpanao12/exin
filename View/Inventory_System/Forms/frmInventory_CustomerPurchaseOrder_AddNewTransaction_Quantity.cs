using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXIN.Controller;

namespace EXIN.Inventory_System
{
    public partial class frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity : Form
    {
        public frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity()
        {
            InitializeComponent();
            // Panel with Datagrid
            guna2PanelTitle.CustomBorderColor = Global.themeColor1;
       
        }

        private void frmInventory_Products_NewItem_Quantity_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
