using EXIN.Controller;
using EXIN.Tools;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Payroll_System
{
    public partial class frmPayroll_ParentContainer : Form
    {

        string clickedMenu = "";

        public frmPayroll_ParentContainer()
        {
            InitializeComponent();

            // Logo
            this.Icon = new Icon("Resources/General/Logo.ico");

            _obj = this; //Initialize frmParentContainer for Docking of UserControls

            // Sidebar | Main Menu
            panelSideBar.FillColor = Global.themeColor1;
            panelSideBar.FillColor2 = Global.themeColor1;
            panelSideBar.FillColor3 = Global.themeColor2;
            panelSideBar.FillColor4 = Global.themeColor2;

            // Sidebar | Sub Menu
            panelSubMenu_Settings.FillColor = Global.themeColor1;
            panelSubMenu_Settings.FillColor2 = Global.themeColor1;
            panelSubMenu_Settings.FillColor3 = Global.themeColor1;
            panelSubMenu_Settings.FillColor4 = Global.themeColor2;

            // Sidebar | Sub Menu
            panelSubMenu_Others.FillColor = Global.themeColor1;
            panelSubMenu_Others.FillColor2 = Global.themeColor1;
            panelSubMenu_Others.FillColor3 = Global.themeColor1;
            panelSubMenu_Others.FillColor4 = Global.themeColor1;

            // Tile Button
            btnMenuHome.CheckedState.FillColor = Global.themeColor2;
            btnMenuEmployeeList.CheckedState.FillColor = Global.themeColor2;
            btnMenuAttendance.CheckedState.FillColor = Global.themeColor2;
            btnMenuOvertime.CheckedState.FillColor = Global.themeColor2;
            btnMenuAdjustments.CheckedState.FillColor = Global.themeColor2;
            btnMenuDeductions.CheckedState.FillColor = Global.themeColor2;
            btnMenuPayrollSummary.CheckedState.FillColor = Global.themeColor2;
            btnMenuOthers.CheckedState.FillColor = Global.themeColor2;
            btnMenuSettings.CheckedState.FillColor = Global.themeColor2;

            // Maximize the window once opened
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // Avoid covering the taskbar when the window has been maximized
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmPayroll_ParentContainer_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("Resources/General/Logo.png");

            panelMainContainer.Dock = DockStyle.Fill;
        }

        #region dockController
        public static frmPayroll_ParentContainer _obj;

        public static frmPayroll_ParentContainer Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmPayroll_ParentContainer();
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

        #region resetMenu
        private void resetMenu()
        {
            btnMenuHome.Checked = false;
            btnMenuEmployeeList.Checked = false;
            btnMenuAttendance.Checked = false;
            btnMenuOvertime.Checked = false;
            btnMenuAdjustments.Checked = false;
            btnMenuDeductions.Checked = false;
            btnMenuPayrollSummary.Checked = false;
            btnMenuOthers.Checked = false;
            btnMenuSettings.Checked = false;
        }
        #endregion

        #region hideAllSubMenu
        private void hideAllSubMenu()
        {
            if (clickedMenu == "Home")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Employee List")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Attendance")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Overtime")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Adjustments")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Deductions")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Payroll Summary")
            {
                panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Other Menu")
            {
                //panelSubMenu_Others.Visible = false;
                panelSubMenu_Settings.Visible = false;
            }
            else if (clickedMenu == "Settings")
            {
                panelSubMenu_Others.Visible = false;
                //panelSubMenu_Settings.Visible = false;
            }
        }
        #endregion

        private void btnSubMenu_ToolBox_Click(object sender, EventArgs e)
        {
            transitionMenu.Hide(panelSubMenu_Others); // Hides the menu
            control_Docking.ClearUserControls(frmPayroll_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_PayrollSystem(new ucToolBox()); // Loads the target user control in docked mode            
        }
        private void btnSubMenu_SampleRecords_Click(object sender, EventArgs e)
        {
            transitionMenu.Hide(panelSubMenu_Others); // Hides the menu
            control_Docking.ClearUserControls(frmPayroll_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_PayrollSystem(new UCUsers()); // Loads the target user control in docked mode            
        }
        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            clickedMenu = "Home";
            resetMenu();
            hideAllSubMenu();
            btnMenuHome.Checked = true;
        }

        private void btnMenuEmployeeList_Click(object sender, EventArgs e)
        {
            clickedMenu = "Employee List";
            resetMenu();
            hideAllSubMenu();
            btnMenuEmployeeList.Checked = true;

            control_Docking.ClearUserControls(frmPayroll_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_PayrollSystem(new ucPayroll_EmployeeList()); // Loads the target user control in docked mode
        }

        private void btnMenuAttendance_Click(object sender, EventArgs e)
        {
            clickedMenu = "Attendance";
            resetMenu();
            hideAllSubMenu();

            btnMenuAttendance.Checked = true;
        }

        private void btnMenuOvertime_Click(object sender, EventArgs e)
        {
            clickedMenu = "Overtime";
            resetMenu();
            hideAllSubMenu();
            btnMenuOvertime.Checked = true;
        }

        private void btnMenuAdjustments_Click(object sender, EventArgs e)
        {
            clickedMenu = "Adjustments";
            resetMenu();
            hideAllSubMenu();
            btnMenuAdjustments.Checked = true;
        }

        private void btnMenuDeductions_Click(object sender, EventArgs e)
        {
            clickedMenu = "Deductions";
            resetMenu();
            hideAllSubMenu();
            btnMenuDeductions.Checked = true;
        }

        private void btnMenuPayrollSummary_Click(object sender, EventArgs e)
        {
            clickedMenu = "Payroll Summary";
            resetMenu();
            hideAllSubMenu();
            btnMenuPayrollSummary.Checked = true;
        }

        private void btnMenuOthers_Click(object sender, EventArgs e)
        {
            clickedMenu = "Other Menu";
            resetMenu();
            hideAllSubMenu();
            btnMenuOthers.Checked = true;

            // Transition Menu
            if (panelSubMenu_Others.Visible == false)
            {
                transitionMenu.Show(panelSubMenu_Others);
                panelSubMenu_Others.BringToFront();
            }
            else
            {
                transitionMenu.Hide(panelSubMenu_Others);
            }
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            clickedMenu = "Settings";
            resetMenu();
            hideAllSubMenu();
            btnMenuSettings.Checked = true;

            // Transition Menu
            if (panelSubMenu_Settings.Visible == false)
            {
                transitionMenu.Show(panelSubMenu_Settings);
                panelSubMenu_Settings.BringToFront();
            }
            else
            {
                transitionMenu.Hide(panelSubMenu_Settings);
            }
        }
    }
}
