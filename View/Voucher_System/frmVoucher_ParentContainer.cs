using EXIN.Controller;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class frmVoucher_ParentContainer : Form
    {
        public frmVoucher_ParentContainer()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeThemes();

            // Maximize the window once opened
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // Avoid covering the taskbar when the window has been maximized
            this.WindowState = FormWindowState.Maximized;
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
            // Sidebar | Main Menu
            panelSideBar.FillColor = Global.themeColor1;
            panelSideBar.FillColor2 = Global.themeColor1;
            panelSideBar.FillColor3 = Global.themeColor2;
            panelSideBar.FillColor4 = Global.themeColor2;

            // Sidebar | Sub Menu - Transactions
            panelSubMenu_Transactions.FillColor = Global.themeColor1;
            panelSubMenu_Transactions.FillColor2 = Global.themeColor1;
            panelSubMenu_Transactions.FillColor3 = Global.themeColor1;
            panelSubMenu_Transactions.FillColor4 = Global.themeColor2;

            // Sidebar | Sub Menu - Reports
            panelSubMenu_Reports.FillColor = Global.themeColor1;
            panelSubMenu_Reports.FillColor2 = Global.themeColor1;
            panelSubMenu_Reports.FillColor3 = Global.themeColor1;
            panelSubMenu_Reports.FillColor4 = Global.themeColor2;

            // Sidebar | Sub Menu - Settings
            panelSubMenu_Settings.FillColor = Global.themeColor1;
            panelSubMenu_Settings.FillColor2 = Global.themeColor1;
            panelSubMenu_Settings.FillColor3 = Global.themeColor1;
            panelSubMenu_Settings.FillColor4 = Global.themeColor2;

            // Tile Button
            btnMenuHome.CheckedState.FillColor = Global.themeColor2;
            btnMenuRecords.CheckedState.FillColor = Global.themeColor2;
            btnMenuTransactions.CheckedState.FillColor = Global.themeColor2;
            btnMenuReports.CheckedState.FillColor = Global.themeColor2;
            btnMenuSystemLogs.CheckedState.FillColor = Global.themeColor2;
            btnMenuSettings.CheckedState.FillColor = Global.themeColor2;
        }

        private void frmVoucher_ParentContainer_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            picLogo.Image = Image.FromFile("Resources/General/Logo.png");

            lblDisplayName.Text = Global.displayName;
            lblUserLevel.Text = Global.userLevel;

            panelContainer.Dock = DockStyle.Fill;

            // Load the Home tab
            panelContainer.Controls.Clear();
            ucVoucher_Home ucVoucher_Home = new ucVoucher_Home();
            ucVoucher_Home.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Home);
        }

        private void navigateMenu(Guna.UI2.WinForms.Guna2TileButton menuButton)
        {
            for (var i = panelMainMenu.Controls.Count - 1; i >= 0; i--)
            {
                if (panelMainMenu.Controls[i] is Guna.UI2.WinForms.Guna2TileButton)
                {
                    Guna.UI2.WinForms.Guna2TileButton gunaTileButton = panelMainMenu.Controls[i] as Guna.UI2.WinForms.Guna2TileButton;
                    gunaTileButton.Checked = false;
                }
            }
            menuButton.Checked = true;
        }

        private void hideAllSubMenu(String subMenu)
        {
            if (subMenu != "panelSubMenu_Transactions")
            {
                // Transition Menu
                if (panelSubMenu_Transactions.Visible == true)
                {
                    transitionMenu.Hide(panelSubMenu_Transactions);
                }
            }

            if (subMenu != "panelSubMenu_Reports")
            {
                // Transition Menu
                if (panelSubMenu_Reports.Visible == true)
                {
                    transitionMenu.Hide(panelSubMenu_Reports);
                }
            }

            if (subMenu != "panelSubMenu_Settings")
            {
                // Transition Menu
                if (panelSubMenu_Settings.Visible == true)
                {
                    transitionMenu.Hide(panelSubMenu_Settings);
                }
            }            
        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuHome);
            panelContainer.Controls.Clear();
            ucVoucher_Home ucVoucher_Home = new ucVoucher_Home();
            ucVoucher_Home.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Home);
        }

        private void btnMenuRecords_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuRecords);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_ViewRecords ucVoucher_Transactions_ViewRecords = new ucVoucher_Transactions_ViewRecords();
            ucVoucher_Transactions_ViewRecords.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_ViewRecords);
        }

        private void btnMenuTransactions_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("panelSubMenu_Transactions");
            // Transition Menu
            if (panelSubMenu_Transactions.Visible == false)
            {
                transitionMenu.Show(panelSubMenu_Transactions);
                panelSubMenu_Transactions.BringToFront();
            }
            else
            {
                transitionMenu.Hide(panelSubMenu_Transactions);
            }
        }

        private void btnMenuReports_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("panelSubMenu_Reports");
            // Transition Menu
            if (panelSubMenu_Reports.Visible == false)
            {
                transitionMenu.Show(panelSubMenu_Reports);
                panelSubMenu_Reports.BringToFront();
            }
            else
            {
                transitionMenu.Hide(panelSubMenu_Reports);
            }
        }

        private void btnMenuSystemLogs_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSystemLogs);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_Logs ucVoucher_Transactions_Logs = new ucVoucher_Transactions_Logs();
            ucVoucher_Transactions_Logs.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_Logs);
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("panelSubMenu_Settings");
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

        #region Transactions
        private void btnSubMenu_Transactions_CV_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuTransactions);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_CreateEdit ucVoucher_Transactions_CreateEdit = new ucVoucher_Transactions_CreateEdit();
            ucVoucher_Transactions_CreateEdit.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_CreateEdit);
        }

        private void btnSubMenu_Transactions_JV_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuTransactions);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_CreateEdit ucVoucher_Transactions_CreateEdit = new ucVoucher_Transactions_CreateEdit();
            ucVoucher_Transactions_CreateEdit.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_CreateEdit);
        }

        private void btnSubMenu_Transactions_PCV_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuTransactions);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_CreateEdit ucVoucher_Transactions_CreateEdit = new ucVoucher_Transactions_CreateEdit();
            ucVoucher_Transactions_CreateEdit.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_CreateEdit);
        }

        private void btnSubMenu_Transactions_PCF_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuTransactions);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_PCF ucVoucher_Transactions_PCF = new ucVoucher_Transactions_PCF();
            ucVoucher_Transactions_PCF.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_PCF);
        }

        private void btnSubMenu_Transactions_UploadRecords_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuTransactions);
            panelContainer.Controls.Clear();
            ucVoucher_Transactions_UploadRecords ucVoucher_Transactions_UploadRecords = new ucVoucher_Transactions_UploadRecords();
            ucVoucher_Transactions_UploadRecords.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Transactions_UploadRecords);
        }
        #endregion

        #region Reports
        private void btnSubMenu_Reports_Wtax_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuReports);
            panelContainer.Controls.Clear();
            ucVoucher_Reports_Wtax ucVoucher_Reports_Wtax = new ucVoucher_Reports_Wtax();
            ucVoucher_Reports_Wtax.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Reports_Wtax);
        }

        private void btnSubMenu_Reports_VatInput_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuReports);
            panelContainer.Controls.Clear();
            ucVoucher_Reports_VatInput ucVoucher_Reports_VatInput = new ucVoucher_Reports_VatInput();
            ucVoucher_Reports_VatInput.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Reports_VatInput);
        }

        private void btnSubMenu_Reports_ARAging_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuReports);
            panelContainer.Controls.Clear();
            ucVoucher_Reports_ARAging ucVoucher_Reports_ARAging = new ucVoucher_Reports_ARAging();
            ucVoucher_Reports_ARAging.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Reports_ARAging);
        }

        private void btnSubMenu_Reports_APAging_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuReports);
            panelContainer.Controls.Clear();
            ucVoucher_Reports_APAging ucVoucher_Reports_APAging = new ucVoucher_Reports_APAging();
            ucVoucher_Reports_APAging.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Reports_APAging);
        }
        #endregion

        #region Settings
        private void btnSubMenu_Settings_CheckPrintSetup_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSettings);
            panelContainer.Controls.Clear();
            ucVoucher_Settings_CheckPrint ucVoucher_Settings_CheckPrint = new ucVoucher_Settings_CheckPrint();
            ucVoucher_Settings_CheckPrint.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Settings_CheckPrint);
        }

        private void btnSubMenu_Settings_DefaultEntries_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSettings);
            panelContainer.Controls.Clear();
            ucVoucher_Settings_DefaultEntries ucVoucher_Settings_DefaultEntries = new ucVoucher_Settings_DefaultEntries();
            ucVoucher_Settings_DefaultEntries.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Settings_DefaultEntries);
        }

        private void btnSubMenu_Settings_ClosingEntries_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSettings);
            panelContainer.Controls.Clear();
            ucVoucher_Settings_ClosingEntries ucVoucher_Settings_ClosingEntries = new ucVoucher_Settings_ClosingEntries();
            ucVoucher_Settings_ClosingEntries.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Settings_ClosingEntries);
        }

        private void btnSubMenu_Settings_ClosingDate_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSettings);
            panelContainer.Controls.Clear();
            ucVoucher_Settings_ClosingDate ucVoucher_Settings_ClosingDate = new ucVoucher_Settings_ClosingDate();
            ucVoucher_Settings_ClosingDate.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Settings_ClosingDate);
        }

        private void btnSubMenu_Settings_Approvers_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSettings);
            panelContainer.Controls.Clear();
            ucVoucher_Settings_Approvers ucVoucher_Settings_Approvers = new ucVoucher_Settings_Approvers();
            ucVoucher_Settings_Approvers.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Settings_Approvers);
        }

        private void btnSubMenu_List_Signatories_Click(object sender, EventArgs e)
        {
            hideAllSubMenu("");
            navigateMenu(btnMenuSettings);
            panelContainer.Controls.Clear();
            ucVoucher_Settings_Signatories ucVoucher_Settings_Signatories = new ucVoucher_Settings_Signatories();
            ucVoucher_Settings_Signatories.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucVoucher_Settings_Signatories);
        }
        #endregion
    }
}
