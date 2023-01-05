using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_NewTransaction_Item : UserControl
    {
        public string itemCode;
        public string itemName;
        public string itemUoM;
        public double itemLandingCost;
        public double itemUnitCost;
        public double itemPrice;

        public ucPOS_NewTransaction_Item()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {

        }

        private void ucPOS_NewTransaction_Item_Load(object sender, EventArgs e)
        {
            try
            {
                picItemPicture.Image = Image.FromFile("Resources/Point_Of_Sales/Item_Pictures/" + itemCode + ".jpg");
            }
            catch
            {
                picItemPicture.Image = Image.FromFile("Resources/Point_Of_Sales/00000.png");
            }
            lblItemCode.Text = "ID: " + itemCode;
            lblItemName.Text = itemName;
            lblPrice.Text = "₱ " + itemPrice.ToString("N2");
        }

        private void picItemPicture_Click(object sender, EventArgs e)
        {
            addToCart();
        }

        private void lblItemName_Click(object sender, EventArgs e)
        {
            addToCart();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            addToCart();
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {
            addToCart();
        }

        private void panelItemContainer_Click(object sender, EventArgs e)
        {
            addToCart();
        }

        private void addToCart()
        {
            var targetForm = Application.OpenForms.OfType<frmPOS_ParentContainer>().Single();

            // Validate if the selected item is already in the cart
            Boolean itemExist = false;
            for (var i = targetForm.Controls["panelContainer"].Controls["ucPOS_NewTransaction"].Controls["panelCart"].Controls["panelCartItems"].Controls.Count - 1; i >= 0; i--)
            {
                if (targetForm.Controls["panelContainer"].Controls["ucPOS_NewTransaction"].Controls["panelCart"].Controls["panelCartItems"].Controls[i] is ucPOS_NewTransaction_CartItem)
                {
                    ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = targetForm.Controls["panelContainer"].Controls["ucPOS_NewTransaction"].Controls["panelCart"].Controls["panelCartItems"].Controls[i] as ucPOS_NewTransaction_CartItem;
                    if (itemCode == ucPOS_NewTransaction_CartItem.itemCode)
                    {
                        ucPOS_NewTransaction_CartItem.addQuantity();
                        itemExist = true;
                        break;
                    }
                }
            }

            if (itemExist == false)
            {
                ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = new ucPOS_NewTransaction_CartItem();
                ucPOS_NewTransaction_CartItem.Dock = DockStyle.Top;
                ucPOS_NewTransaction_CartItem.itemCode = itemCode;
                ucPOS_NewTransaction_CartItem.itemName = itemName;
                ucPOS_NewTransaction_CartItem.itemUoM = itemUoM;
                ucPOS_NewTransaction_CartItem.itemLandingCost = itemLandingCost;
                ucPOS_NewTransaction_CartItem.itemUnitCost = itemUnitCost;
                ucPOS_NewTransaction_CartItem.itemPrice = itemPrice;
                targetForm.Controls["panelContainer"].Controls["ucPOS_NewTransaction"].Controls["panelCart"].Controls["panelCartItems"].Controls.Add(ucPOS_NewTransaction_CartItem);
                ucPOS_NewTransaction_CartItem.BringToFront();
            }
        }

        private void panelItemContainer_MouseDown(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.FromArgb(237, 242, 251);
        }

        private void panelItemContainer_MouseUp(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.White;
        }

        private void picItemPicture_MouseDown(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.FromArgb(237, 242, 251);
        }

        private void picItemPicture_MouseUp(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.White;
        }

        private void lblItemName_MouseDown(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.FromArgb(237, 242, 251);
        }

        private void lblItemName_MouseUp(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.White;
        }

        private void lblItemCode_MouseDown(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.FromArgb(237, 242, 251);
        }

        private void lblItemCode_MouseUp(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.White;
        }

        private void lblPrice_MouseDown(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.FromArgb(237, 242, 251);
        }

        private void lblPrice_MouseUp(object sender, MouseEventArgs e)
        {
            panelItemContainer.FillColor = Color.White;
        }
    }
}
