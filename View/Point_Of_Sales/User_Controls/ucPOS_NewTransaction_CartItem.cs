using System;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_NewTransaction_CartItem : UserControl
    {
        public string itemCode;
        public string itemName;
        public string itemUoM;
        public double itemLandingCost;
        public double itemUnitCost;
        public double itemPrice;
        public double itemQuantity = 1;
        public string notes;

        public Boolean deleteMe = false;

        public ucPOS_NewTransaction_CartItem()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {

        }

        private void ucPOS_NewTransaction_CartItem_Load(object sender, EventArgs e)
        {
            lblItemName.Text = itemName;
            txtQuantity.Text = itemQuantity + " " + itemUoM;
        }

        public void addQuantity()
        {
            itemQuantity++;
            txtQuantity.Text = itemQuantity + " " + itemUoM;
        }

        public void deductQuantity()
        {
            itemQuantity--;
            if (itemQuantity <= 0)
            {
                itemQuantity = 1;
            }
            txtQuantity.Text = itemQuantity + " " + itemUoM;
        }

        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            addQuantity();
        }

        private void btnDeductQuantity_Click(object sender, EventArgs e)
        {
            deductQuantity();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            deleteMe = true;

            var targetForm = Application.OpenForms.OfType<frmPOS_ParentContainer>().Single();
            ucPOS_NewTransaction ucPOS_NewTransaction = targetForm.Controls["panelContainer"].Controls["ucPOS_NewTransaction"] as ucPOS_NewTransaction;
            ucPOS_NewTransaction.deleteItem();
        }
    }
}
