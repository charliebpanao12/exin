using EXIN.Controller;
using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace EXIN.SalesCollection_System
{
    public partial class frmSalesCollection_ParentContainer : Form
    {
        public frmSalesCollection_ParentContainer()
        {
            InitializeComponent();

            _obj = this; //Initialize frmParentContainer for Docking of UserControls

            // Maximize the window once opened
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // Avoid covering the taskbar when the window has been maximized
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmSalesCollection_ParentContainer_Load(object sender, System.EventArgs e)
        {
            panelMainContainer.Dock = DockStyle.Fill;
        }

        #region dockController
        public static frmSalesCollection_ParentContainer _obj;

        public static frmSalesCollection_ParentContainer Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmSalesCollection_ParentContainer();
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

        #region MainMenu
        private void btnHome_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Home()); // Loads the target user control in docked mode

            transitionMenuTwo.Hide(panelList);
            transitionMenuTwo.Hide(panelTransactions);
            transitionMenuTwo.Hide(panelReports);
            transitionMenuTwo.Hide(panelSettings);
        }

        private void btnList_Click(object sender, System.EventArgs e)
        {
            if (panelList.Visible == false)
            {
                //transitionMenuTwo.Hide(panelList);
                transitionMenuTwo.Hide(panelTransactions);
                transitionMenuTwo.Hide(panelReports);
                transitionMenuTwo.Hide(panelSettings);

                transitionMenuTwo.Show(panelList);
                panelList.BringToFront();
            }
            else
            {
                transitionMenuTwo.Hide(panelList);
            }
        }

        private void btnTransactions_Click(object sender, System.EventArgs e)
        {
            if (panelTransactions.Visible == false)
            {
                transitionMenuTwo.Hide(panelList);
                //transitionMenuTwo.Hide(panelTransactions);
                transitionMenuTwo.Hide(panelReports);
                transitionMenuTwo.Hide(panelSettings);

                transitionMenuTwo.Show(panelTransactions);
                panelTransactions.BringToFront();
            }
            else
            {
                transitionMenuTwo.Hide(panelTransactions);
            }
        }

        private void btnReports_Click(object sender, System.EventArgs e)
        {
            if (panelReports.Visible == false)
            {
                transitionMenuTwo.Hide(panelList);
                transitionMenuTwo.Hide(panelTransactions);
                //transitionMenuTwo.Hide(panelReports);
                transitionMenuTwo.Hide(panelSettings);

                transitionMenuTwo.Show(panelReports);
                panelReports.BringToFront();
            }
            else
            {
                transitionMenuTwo.Hide(panelReports);
            }
        }

        private void btnSettings_Click(object sender, System.EventArgs e)
        {
            if (panelSettings.Visible == false)
            {
                transitionMenuTwo.Hide(panelList);
                transitionMenuTwo.Hide(panelTransactions);
                transitionMenuTwo.Hide(panelReports);
                //transitionMenuTwo.Hide(panelSettings);

                transitionMenuTwo.Show(panelSettings);
                panelSettings.BringToFront();
            }
            else
            {
                transitionMenuTwo.Hide(panelSettings);
            }
        }
        #endregion

        #region SubMenu_List
        private void btnList_GC_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_List_GCAccounts()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelList); // Hides the menu
        }

        private void btnList_DSR_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_List_DSRAccounts()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelList); // Hides the menu
        }
        #endregion

        #region SubMenu_Transactions
        private void btnTransactions_DSR_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Transactions_DSRRecords()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelTransactions); // Hides the menu
        }

        private void btnTransactions_GC_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Transactions_GCRecords()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelTransactions); // Hides the menu
        }

        private void btnTransactions_Collection_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Transactions_Collection()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelTransactions); // Hides the menu
        }

        private void btnTransactions_Logs_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Transactions_Logs()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelTransactions); // Hides the menu
        }
        #endregion

        #region SubMenu_Reports
        private void btnReports_SalesCert_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Reports_SalesCertificate()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelReports); // Hides the menu
        }
        #endregion

        #region SubMenu_Settings
        private void btnSettings_Defaults_Click(object sender, System.EventArgs e)
        {
            control_Docking.ClearUserControls(frmSalesCollection_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_SalesCollection(new ucSalesCollection_Settings_Defaults()); // Loads the target user control in docked mode
            transitionMenuTwo.Hide(panelSettings); // Hides the menu
        }
        #endregion





    }
}
