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
using Guna.UI2.WinForms;

namespace EXIN.Inventory_System
{
    public partial class frmInventory_ParentContainer : Form
    {
        string clickedMenu = "";

        public frmInventory_ParentContainer()
        {
            InitializeComponent();

            // Logo
            this.Icon = new Icon("Resources/General/Logo.ico");


            // Tile Button
            btnMenuHome.CheckedState.FillColor = Global.themeColor2;
            btnProduct.CheckedState.FillColor = Global.themeColor2;
            btnInventoryIn.CheckedState.FillColor = Global.themeColor2;
            btnInventoryOut.CheckedState.FillColor = Global.themeColor2;
            btnPurchaseOrder.CheckedState.FillColor = Global.themeColor2;
            btnCustomerPO.CheckedState.FillColor = Global.themeColor2;
            // Sidebar | Main Menu
            panelSideBar.FillColor = Global.themeColor1;
            panelSideBar.FillColor2 = Global.themeColor1;
            panelSideBar.FillColor3 = Global.themeColor2;
            panelSideBar.FillColor4 = Global.themeColor2;

            _obj = this; //Initialize frmParentContainer for Docking of UserControls


            // Maximize the window once opened
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // Avoid covering the taskbar when the window has been maximized
            this.WindowState = FormWindowState.Maximized;

        }
        #region resetMenu
        private void resetMenu()
        {
            btnMenuHome.Checked = false;
            btnProduct.Checked = false;
            btnInventoryIn.Checked = false;
            btnInventoryOut.Checked = false;
            btnPurchaseOrder.Checked = false;
            btnCustomerPO.Checked = false;
        }
        #endregion

        #region dockController
        public static frmInventory_ParentContainer _obj;

        public static frmInventory_ParentContainer Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmInventory_ParentContainer();
                }
                return _obj;
            }
        }

        public Guna2Panel panelContainer2
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        classControl_Docking control_Docking = new classControl_Docking(); //Declare Control_Docking Class         
        #endregion

        
        private void frmInventory_ParentContainer_Load(object sender, EventArgs e)
        {
            panelMainContainer.Dock = DockStyle.Fill;
            picLogo.Image = Image.FromFile("Resources/General/Logo.png");
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            clickedMenu = "Product";
            resetMenu();
            btnProduct.Checked = true;
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_Products()); // Loads the target user control in docked mode
            
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            clickedMenu = "Inventory In";
            resetMenu();
            btnInventoryIn.Checked = true;
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_InventoryIn()); // Loads the target user control in docked mode
           
        }

        private void btnInventoryOut_Click_1(object sender, EventArgs e)
        {
            clickedMenu = "Inventory Out";
            resetMenu();
            btnInventoryOut.Checked = true;
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_InventoryOut()); // Loads the target user control in docked mode
           
        }

        private void btnMenuHome_Click_1(object sender, EventArgs e)
        {
            clickedMenu = "Home";
            resetMenu();
            btnMenuHome.Checked = true;
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_Home()); // Loads the target user control in docked mode
        }

        private void btnPurchaseOrder_Click_1(object sender, EventArgs e)
        {
            clickedMenu = "Purchase Order";
            resetMenu();
            btnPurchaseOrder.Checked = true;
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_PurchaseOrder()); // Loads the target user control in docked mode
        }

        private void btnCustomerPO_Click(object sender, EventArgs e)
        {
            clickedMenu = "Customer PO";
            resetMenu();
            btnCustomerPO.Checked = true;
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_CustomerPurchaseOrder()); // Loads the target user control in docked mode
        }
    }
    
}

