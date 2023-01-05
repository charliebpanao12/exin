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
using EXIN.Tools;

namespace EXIN.Fixed_Assets_Management_System
{
    public partial class frmFixedAssets_ParentContainer : Form
    {

        string clickedMenu = "";

        public frmFixedAssets_ParentContainer()
        {
            InitializeComponent();

            _obj = this; //Initialize frmParentContainer for Docking of UserControls

            // Sidebar | Main Menu
            pnlSideBar.FillColor = Global.themeColor1;
            pnlSideBar.FillColor2 = Global.themeColor1;
            pnlSideBar.FillColor3 = Global.themeColor2;
            pnlSideBar.FillColor4 = Global.themeColor2;

            // Tile Button
            btnMenuHome.CheckedState.FillColor = Global.themeColor2;
            btnMasterlist.CheckedState.FillColor = Global.themeColor2;
            btnMenuSettings.CheckedState.FillColor = Global.themeColor2;

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

        }

        private void frmFixedAssets_ParentContainer_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("Resources/General/Logo.png");

            panelMainContainer.Dock = DockStyle.Fill; 
            panelMainContainer.Dock = DockStyle.Fill;
        }

        public static frmFixedAssets_ParentContainer _obj;

        public static frmFixedAssets_ParentContainer Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmFixedAssets_ParentContainer();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            //if (panelMenu1.Visible == false)
            //{
            //    transitionMenuTwo.Show(panelMenu1);
            //    panelMenu1.BringToFront();
            //}
            //else
            //{
            //    transitionMenuTwo.Hide(panelMenu1);
            //}
        }

        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            control_Docking.ClearUserControls(frmFixedAssets_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_FixedAssets (new ucMasterlist()); // Loads the target user control in docked mode
            //transitionMenuTwo.Hide(panelMenu1); // Hides the menu
        }

        private void btnToolBox_Click(object sender, EventArgs e)
        {
            control_Docking.ClearUserControls(frmFixedAssets_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_FixedAssets(new ucToolBox()); // Loads the target user control in docked mode
            //transitionMenuTwo.Hide(panelMenu1); // Hides the menu
        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            clickedMenu = "Home";
            resetMenu();
            btnMenuHome.Checked = true;
        }

        private void btnMasterlist_Click(object sender, EventArgs e)
        {
            clickedMenu = "Employee List";
            resetMenu();
            btnMasterlist.Checked = true;

            control_Docking.ClearUserControls(frmFixedAssets_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_FixedAssets(new ucMasterlist()); // Loads the target user control in docked mode
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            clickedMenu = "Settings";
            resetMenu();
            btnMenuSettings.Checked = true;
        }

        private void resetMenu()
        {
            btnMenuHome.Checked = false;
            btnMasterlist.Checked = false;
            btnMenuSettings.Checked = false;
        }
    }
}
