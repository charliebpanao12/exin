using System;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_NewTransaction_CartItem_2 : UserControl
    {
        public string itemCode;
        public string itemName;
        public string itemUoM;
        public double itemLandingCost;
        public double itemUnitCost;
        public double itemPrice;
        public double itemQuantity;
        public string notes;

        public ucPOS_NewTransaction_CartItem_2()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {

        }

        private void ucPOS_NewTransaction_CartItem_2_Load(object sender, EventArgs e)
        {
            lblItemName.Text = itemName;
            lblQuantity.Text = itemQuantity + " " + itemUoM;
            lblSellingPrice.Text = "" + itemPrice.ToString("N2");
            lblAmount.Text = "" + (itemPrice * itemQuantity).ToString("N2");
        }
    }
}
