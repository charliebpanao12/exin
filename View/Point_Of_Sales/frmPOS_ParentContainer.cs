using EXIN.Controller;
using EXIN.View.Point_Of_Sales.Reports;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class frmPOS_ParentContainer : Form
    {
        public frmPOS_ParentContainer()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeThemes();
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

        }

        public void frmPOS_ParentContainer_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // Uncovers the taskbar when the window is maximized
            this.WindowState = FormWindowState.Maximized;

            lblDisplayName.Text = Global.displayName;
            lblUserLevel.Text = Global.userLevel;

            btnHome_Click(e, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Show confirmation box
            new classMsgBox().showMsgLogout("Do you want to exit this window?");
            if (Global.msgConfirmation == true)
            {
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                this.Hide();
            }
            Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ucPOS_Home ucPOS_Home = new ucPOS_Home();
            ucPOS_Home.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucPOS_Home);
        }

        private void btnTransactionRecords_Click(object sender, EventArgs e)
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            // Preloader - Start
            loader.ShowSmall();

            panelContainer.Controls.Clear();
            ucPOS_TransactionRecords ucPOS_TransactionRecords = new ucPOS_TransactionRecords();
            ucPOS_TransactionRecords.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucPOS_TransactionRecords);

            // Preloader - Close
            loader.CloseSmall();
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ucPOS_NewTransaction ucPOS_NewTransaction = new ucPOS_NewTransaction();
            ucPOS_NewTransaction.Dock = DockStyle.Fill;
            ucPOS_NewTransaction.addViewEdit = "Add";
            panelContainer.Controls.Add(ucPOS_NewTransaction);
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Declaring Variables
                var varDataTable = new DataTable();

                // Preparing the columns of varDataTable
                #region varDataTable
                varDataTable.Columns.Add("DataColumn1");
                varDataTable.Columns.Add("DataColumn2");
                varDataTable.Columns.Add("DataColumn3");
                varDataTable.Columns.Add("DataColumn4");
                varDataTable.Columns.Add("DataColumn5");
                varDataTable.Columns.Add("DataColumn6");
                varDataTable.Columns.Add("DataColumn7");
                varDataTable.Columns.Add("DataColumn8");
                varDataTable.Columns.Add("DataColumn9");
                varDataTable.Columns.Add("DataColumn10");
                varDataTable.Columns.Add("DataColumn11");
                varDataTable.Columns.Add("DataColumn12");
                varDataTable.Columns.Add("DataColumn13");
                varDataTable.Columns.Add("DataColumn14");
                varDataTable.Columns.Add("DataColumn15");
                varDataTable.Columns.Add("DataColumn16");
                varDataTable.Columns.Add("DataColumn17");
                varDataTable.Columns.Add("DataColumn18");
                varDataTable.Columns.Add("DataColumn19");
                varDataTable.Columns.Add("DataColumn20");
                varDataTable.Columns.Add("DataColumn21");
                varDataTable.Columns.Add("DataColumn22");
                varDataTable.Columns.Add("DataColumn23");
                varDataTable.Columns.Add("DataColumn24");
                varDataTable.Columns.Add("DataColumn25");
                varDataTable.Columns.Add("DataColumn26");
                varDataTable.Columns.Add("DataColumn27");
                varDataTable.Columns.Add("DataColumn28");
                varDataTable.Columns.Add("DataColumn29");
                varDataTable.Columns.Add("DataColumn30");
                varDataTable.Columns.Add("DataColumn31");
                varDataTable.Columns.Add("DataColumn32");
                varDataTable.Columns.Add("DataColumn33");
                varDataTable.Columns.Add("DataColumn34");
                varDataTable.Columns.Add("DataColumn35");
                varDataTable.Columns.Add("DataColumn36");
                varDataTable.Columns.Add("DataColumn37");
                varDataTable.Columns.Add("DataColumn38");
                varDataTable.Columns.Add("DataColumn39");
                varDataTable.Columns.Add("DataColumn40");
                varDataTable.Columns.Add("DataColumn41");
                varDataTable.Columns.Add("DataColumn42");
                varDataTable.Columns.Add("DataColumn43");
                varDataTable.Columns.Add("DataColumn44");
                varDataTable.Columns.Add("DataColumn45");
                varDataTable.Columns.Add("DataColumn46");
                varDataTable.Columns.Add("DataColumn47");
                varDataTable.Columns.Add("DataColumn48");
                varDataTable.Columns.Add("DataColumn49");
                varDataTable.Columns.Add("DataColumn50");
                #endregion;

                // Preparing for printing
                CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                reportDocument = new crptPOS_XReading();
                reportDocument.SetDataSource(varDataTable);

                // Printing the document
                reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }
        }

        private void btnZReading_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Declaring Variables
                var varDataTable = new DataTable();

                // Preparing the columns of varDataTable
                #region varDataTable
                varDataTable.Columns.Add("DataColumn1");
                varDataTable.Columns.Add("DataColumn2");
                varDataTable.Columns.Add("DataColumn3");
                varDataTable.Columns.Add("DataColumn4");
                varDataTable.Columns.Add("DataColumn5");
                varDataTable.Columns.Add("DataColumn6");
                varDataTable.Columns.Add("DataColumn7");
                varDataTable.Columns.Add("DataColumn8");
                varDataTable.Columns.Add("DataColumn9");
                varDataTable.Columns.Add("DataColumn10");
                varDataTable.Columns.Add("DataColumn11");
                varDataTable.Columns.Add("DataColumn12");
                varDataTable.Columns.Add("DataColumn13");
                varDataTable.Columns.Add("DataColumn14");
                varDataTable.Columns.Add("DataColumn15");
                varDataTable.Columns.Add("DataColumn16");
                varDataTable.Columns.Add("DataColumn17");
                varDataTable.Columns.Add("DataColumn18");
                varDataTable.Columns.Add("DataColumn19");
                varDataTable.Columns.Add("DataColumn20");
                varDataTable.Columns.Add("DataColumn21");
                varDataTable.Columns.Add("DataColumn22");
                varDataTable.Columns.Add("DataColumn23");
                varDataTable.Columns.Add("DataColumn24");
                varDataTable.Columns.Add("DataColumn25");
                varDataTable.Columns.Add("DataColumn26");
                varDataTable.Columns.Add("DataColumn27");
                varDataTable.Columns.Add("DataColumn28");
                varDataTable.Columns.Add("DataColumn29");
                varDataTable.Columns.Add("DataColumn30");
                varDataTable.Columns.Add("DataColumn31");
                varDataTable.Columns.Add("DataColumn32");
                varDataTable.Columns.Add("DataColumn33");
                varDataTable.Columns.Add("DataColumn34");
                varDataTable.Columns.Add("DataColumn35");
                varDataTable.Columns.Add("DataColumn36");
                varDataTable.Columns.Add("DataColumn37");
                varDataTable.Columns.Add("DataColumn38");
                varDataTable.Columns.Add("DataColumn39");
                varDataTable.Columns.Add("DataColumn40");
                varDataTable.Columns.Add("DataColumn41");
                varDataTable.Columns.Add("DataColumn42");
                varDataTable.Columns.Add("DataColumn43");
                varDataTable.Columns.Add("DataColumn44");
                varDataTable.Columns.Add("DataColumn45");
                varDataTable.Columns.Add("DataColumn46");
                varDataTable.Columns.Add("DataColumn47");
                varDataTable.Columns.Add("DataColumn48");
                varDataTable.Columns.Add("DataColumn49");
                varDataTable.Columns.Add("DataColumn50");
                #endregion;

                // Preparing for printing
                CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                reportDocument = new crptPOS_ZReading();
                reportDocument.SetDataSource(varDataTable);

                // Printing the document
                reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }
        }
    }
}
