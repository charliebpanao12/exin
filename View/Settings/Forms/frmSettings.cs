using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings : Form
    {

        public frmSettings()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeThemes();

            // My Account
            btnMenuMyAccount.Visible = true;

            // Preferences
            btnMenuPreferences.Visible = true;

            // System Modules
            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support")
            {
                btnMenuSystemModules.Visible = true;
            }

            // System Features
            if (Global.userLevel == "EXIN Developer")
            {
                btnMenuSystemFeatures.Visible = true;
            }

            // Corporations
            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support")
            {
                btnMenuCorporations.Visible = true;
            }

            // Business Categories
            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support")
            {
                btnMenuBusinessCategories.Visible = true;
            }

            // Business Units
            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support")
            {
                btnMenuBusinessUnits.Visible = true;
            }

            // User Accounts
            btnMenuUserAccounts.Visible = true;

            // Chart of Accounts
            btnMenuChartOfAccounts.Visible = true;

            // Supplier / Payee List
            btnMenuSupplierList.Visible = true;

            // Projects
            btnMenuProjects.Visible = true;

            // Cost Center
            btnMenuCostCenter.Visible = true;

            // Account Class
            btnMenuAccountClass.Visible = true;

            // Expanded Accounts
            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support")
            {
                btnMenuExpandedAccounts.Visible = true;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        public void InitializeThemes()
        {
            //panelSideBar.FillColor = Global.themeColor1;
            //panelSideBar.FillColor2 = Global.themeColor1;
            //panelSideBar.FillColor3 = Global.themeColor1;
            //panelSideBar.FillColor4 = Global.themeColor1;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            lblDisplayName.Text = Global.displayName;
            lblUserLevel.Text = Global.userLevel;

            // Load the 'My Profile' tab
            panelContainer.Controls.Clear();
            ucSettings_MyAccount ucSettings_MyAccount = new ucSettings_MyAccount();
            ucSettings_MyAccount.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_MyAccount);
        }

        private void navigateMenu(Guna.UI2.WinForms.Guna2TileButton menuButton)
        {
            for (var i = panelSideBar.Controls.Count - 1; i >= 0; i--)
            {
                if (panelSideBar.Controls[i] is Guna.UI2.WinForms.Guna2TileButton)
                {
                    Guna.UI2.WinForms.Guna2TileButton gunaTileButton = panelSideBar.Controls[i] as Guna.UI2.WinForms.Guna2TileButton;
                    gunaTileButton.Checked = false;
                }
            }
            menuButton.Checked = true;
        }

        private void btnMenuMyAccount_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuMyAccount);
            panelContainer.Controls.Clear();
            ucSettings_MyAccount ucSettings_MyAccount = new ucSettings_MyAccount();
            ucSettings_MyAccount.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_MyAccount);
        }

        private void btnMenuPreferences_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuPreferences);
            panelContainer.Controls.Clear();
            ucSettings_Preferences ucSettings_Preferences = new ucSettings_Preferences();
            ucSettings_Preferences.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_Preferences);
        }

        private void btnMenuSystemModules_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuSystemModules);
            panelContainer.Controls.Clear();
            ucSettings_SystemModules ucSettings_SystemModules = new ucSettings_SystemModules();
            ucSettings_SystemModules.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_SystemModules);
        }

        private void btnMenuSystemFeatures_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuSystemFeatures);
            panelContainer.Controls.Clear();
            ucSettings_SystemFeatures ucSettings_SystemFeatures = new ucSettings_SystemFeatures();
            ucSettings_SystemFeatures.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_SystemFeatures);
        }

        private void btnMenuCorporations_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuCorporations);
            panelContainer.Controls.Clear();
            ucSettings_Corporations ucSettings_Corporations = new ucSettings_Corporations();
            ucSettings_Corporations.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_Corporations);
        }

        private void btnMenuBusinessCategories_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuBusinessCategories);
            panelContainer.Controls.Clear();
            ucSettings_BusinessCategories ucSettings_BusinessCategories = new ucSettings_BusinessCategories();
            ucSettings_BusinessCategories.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_BusinessCategories);
        }

        private void btnMenuBusinessUnits_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuBusinessUnits);
            panelContainer.Controls.Clear();
            ucSettings_BusinessUnits ucSettings_BusinessUnits = new ucSettings_BusinessUnits();
            ucSettings_BusinessUnits.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_BusinessUnits);
        }

        private void btnMenuUserAccounts_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuUserAccounts);
            panelContainer.Controls.Clear();

            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "User Accounts", "View") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            ucSettings_UserAccounts ucSettings_UserAccounts = new ucSettings_UserAccounts();
            ucSettings_UserAccounts.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_UserAccounts);
        }

        private void btnMenuChartOfAccounts_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuChartOfAccounts);
            panelContainer.Controls.Clear();

            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Chart of Accounts", "View") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            ucSettings_ChartOfAccounts ucSettings_ChartOfAccounts = new ucSettings_ChartOfAccounts();
            ucSettings_ChartOfAccounts.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_ChartOfAccounts);
        }

        private void btnMenuSupplierList_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuSupplierList);
            panelContainer.Controls.Clear();

            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Supplier List", "View") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            ucSettings_SupplierList ucSettings_SupplierList = new ucSettings_SupplierList();
            ucSettings_SupplierList.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_SupplierList);
        }

        private void btnMenuExpandedAccounts_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuExpandedAccounts);
            panelContainer.Controls.Clear();

            ucSettings_ExpandedAccounts ucSettings_ExpandedAccounts = new ucSettings_ExpandedAccounts();
            ucSettings_ExpandedAccounts.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_ExpandedAccounts);
        }

        private void btnMenuProjects_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuProjects);
            panelContainer.Controls.Clear();

            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Projects", "View") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            ucSettings_Projects ucSettings_Projects = new ucSettings_Projects();
            ucSettings_Projects.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_Projects);
        }

        private void btnMenuCostCenter_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuCostCenter);
            panelContainer.Controls.Clear();

            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Cost Center", "View") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            ucSettings_CostCenter ucSettings_CostCenter = new ucSettings_CostCenter();
            ucSettings_CostCenter.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_CostCenter);
        }

        private void btnMenuAccountClass_Click(object sender, EventArgs e)
        {
            navigateMenu(btnMenuAccountClass);
            panelContainer.Controls.Clear();

            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Account Class", "View") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            ucSettings_AccountClass ucSettings_AccountClass = new ucSettings_AccountClass();
            ucSettings_AccountClass.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucSettings_AccountClass);
        }
    }
}
