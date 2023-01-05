using EXIN.Controller;
using EXIN.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using EXIN.Point_Of_Sales;

namespace EXIN
{
    public partial class frmMain : Form
    {
        int enabledModules = 0;

        public frmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            // Logo
            this.Icon = new Icon("Resources/General/Logo.ico");

            // Version Control
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            lblVersionControl.Text = version;

            // Background Image
            panelContainer.BackgroundImage = Image.FromFile("Resources/Main/Background.png");

            InitializeThemes();
            loadSystemModules();
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
            btnAccountingSystem.FillColor = Global.themeColor1;
            btnAccountingSystem.FillColor2 = Global.themeColor2;
            btnAccountingSystem.BorderColor = Global.themeColor1;
            btnAccountingSystem.HoverState.FillColor = Global.themeColor2;

            btnVoucheringSystem.FillColor = Global.themeColor1;
            btnVoucheringSystem.FillColor2 = Global.themeColor2;
            btnVoucheringSystem.BorderColor = Global.themeColor1;
            btnVoucheringSystem.HoverState.FillColor = Global.themeColor2;

            btnSalesCollection.FillColor = Global.themeColor1;
            btnSalesCollection.FillColor2 = Global.themeColor2;
            btnSalesCollection.BorderColor = Global.themeColor1;
            btnSalesCollection.HoverState.FillColor = Global.themeColor2;

            btnBillingCollection.FillColor = Global.themeColor1;
            btnBillingCollection.FillColor2 = Global.themeColor2;
            btnBillingCollection.BorderColor = Global.themeColor1;
            btnBillingCollection.HoverState.FillColor = Global.themeColor2;

            btnInventorySystem.FillColor = Global.themeColor1;
            btnInventorySystem.FillColor2 = Global.themeColor2;
            btnInventorySystem.BorderColor = Global.themeColor1;
            btnInventorySystem.HoverState.FillColor = Global.themeColor2;

            btnPayrollSystem.FillColor = Global.themeColor1;
            btnPayrollSystem.FillColor2 = Global.themeColor2;
            btnPayrollSystem.BorderColor = Global.themeColor1;
            btnPayrollSystem.HoverState.FillColor = Global.themeColor2;

            btnPointOfSales.FillColor = Global.themeColor1;
            btnPointOfSales.FillColor2 = Global.themeColor2;
            btnPointOfSales.BorderColor = Global.themeColor1;
            btnPointOfSales.HoverState.FillColor = Global.themeColor2;

            btnFixedAssets.FillColor = Global.themeColor1;
            btnFixedAssets.FillColor2 = Global.themeColor2;
            btnFixedAssets.BorderColor = Global.themeColor1;
            btnFixedAssets.HoverState.FillColor = Global.themeColor2;
        }

        public void frmMain_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();
            //guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnAccountingSystem_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Accounting System", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Accounting System");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnVoucheringSystem_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Vouchering System", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Vouchering System");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnBillingCollection_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Billing & Collection", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Billing & Collection");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnSalesCollection_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Sales & Collection", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Sales & Collection");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnInventorySystem_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Inventory System", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Inventory System");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnPayrollSystem_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Payroll System", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Payroll System");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnPointOfSales_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Point of Sales", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Point of Sales");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnFixedAssets_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "Fixed Assets Management", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSelectBusinessCategory frmSelectBusinessCategory = new frmSelectBusinessCategory("Fixed Assets Management");
            frmSelectBusinessCategory.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Main Window", "Main Window") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmMain"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSettings frmSettings = new frmSettings();
            frmSettings.ShowDialog();
        }

        public void loadSystemModules()
        {
            hideAllModules();  // Hide all the modules

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_system_modules", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            if (numRows > 0)
            {
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    if (Conns.mySqlDataReader["system_module"].ToString() == "Accounting System")
                    {
                        panelAccountingSystem.Visible = true;
                        panelAccountingSystem.Left = getLeftPosition(numRows, i);
                        panelAccountingSystem.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Vouchering System")
                    {
                        panelVoucheringSystem.Visible = true;
                        panelVoucheringSystem.Left = getLeftPosition(numRows, i);
                        panelVoucheringSystem.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Sales & Collection")
                    {
                        panelSalesCollection.Visible = true;
                        panelSalesCollection.Left = getLeftPosition(numRows, i);
                        panelSalesCollection.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Billing & Collection")
                    {
                        panelBillingCollection.Visible = true;
                        panelBillingCollection.Left = getLeftPosition(numRows, i);
                        panelBillingCollection.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Inventory System")
                    {
                        panelInventorySystem.Visible = true;
                        panelInventorySystem.Left = getLeftPosition(numRows, i);
                        panelInventorySystem.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Payroll System")
                    {
                        panelPayrollSystem.Visible = true;
                        panelPayrollSystem.Left = getLeftPosition(numRows, i);
                        panelPayrollSystem.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Point of Sales")
                    {
                        panelPointOfSales.Visible = true;
                        panelPointOfSales.Left = getLeftPosition(numRows, i);
                        panelPointOfSales.Top = getTopPosition(numRows, i);
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Fixed Assets Management")
                    {
                        panelFixedAssetsManagement.Visible = true;
                        panelFixedAssetsManagement.Left = getLeftPosition(numRows, i);
                        panelFixedAssetsManagement.Top = getTopPosition(numRows, i);
                    }
                    i++;
                }
            }

            Conns.closeConnection();    // !Important ->> Close the connection from the database
            //panelModulesContainer.Height = (143 * enabledModules) - 10;
        }

        private void hideAllModules()
        {
            panelAccountingSystem.Visible = false;
            panelVoucheringSystem.Visible = false;
            panelSalesCollection.Visible = false;
            panelBillingCollection.Visible = false;
            panelInventorySystem.Visible = false;
            panelPayrollSystem.Visible = false;
            panelPointOfSales.Visible = false;
            panelFixedAssetsManagement.Visible = false;
        }

        public int getLeftPosition(int numRows, int currentRow)
        {
            int result = 0;
            if (numRows == 1)
            {
                if (currentRow == 1)
                {
                    result = 313;
                }
            }
            else if (numRows == 2)
            {
                if (currentRow == 1)
                {
                    result = 151;
                }
                else if (currentRow == 2)
                {
                    result = 475;
                }
            }
            else if (numRows == 3)
            {
                if (currentRow == 1)
                {
                    result = 102;
                }
                else if (currentRow == 2)
                {
                    result = 313;
                }
                else if (currentRow == 3)
                {
                    result = 524;
                }
            }
            else if (numRows == 4)
            {
                if (currentRow == 1)
                {
                    result = 15;
                }
                else if (currentRow == 2)
                {
                    result = 214;
                }
                else if (currentRow == 3)
                {
                    result = 413;
                }
                else if (currentRow == 4)
                {
                    result = 612;
                }
            }
            else if (numRows == 5)
            {
                if (currentRow == 1)
                {
                    result = 194;
                }
                else if (currentRow == 2)
                {
                    result = 423;
                }
                else if (currentRow == 3)
                {
                    result = 81;
                }
                else if (currentRow == 4)
                {
                    result = 308;
                }
                else if (currentRow == 5)
                {
                    result = 535;
                }
            }
            else if (numRows == 6)
            {
                if (currentRow == 1)
                {
                    result = 81;
                }
                else if (currentRow == 2)
                {
                    result = 308;
                }
                else if (currentRow == 3)
                {
                    result = 535;
                }
                else if (currentRow == 4)
                {
                    result = 81;
                }
                else if (currentRow == 5)
                {
                    result = 308;
                }
                else if (currentRow == 6)
                {
                    result = 535;
                }
            }
            else if (numRows == 7)
            {
                if (currentRow == 1)
                {
                    result = 114;
                }
                else if (currentRow == 2)
                {
                    result = 313;
                }
                else if (currentRow == 3)
                {
                    result = 512;
                }
                else if (currentRow == 4)
                {
                    result = 15;
                }
                else if (currentRow == 5)
                {
                    result = 214;
                }
                else if (currentRow == 6)
                {
                    result = 413;
                }
                else if (currentRow == 7)
                {
                    result = 612;
                }
            }
            else if (numRows == 8)
            {
                if (currentRow == 1)
                {
                    result = 15;
                }
                else if (currentRow == 2)
                {
                    result = 214;
                }
                else if (currentRow == 3)
                {
                    result = 413;
                }
                else if (currentRow == 4)
                {
                    result = 612;
                }
                else if (currentRow == 5)
                {
                    result = 15;
                }
                else if (currentRow == 6)
                {
                    result = 214;
                }
                else if (currentRow == 7)
                {
                    result = 413;
                }
                else if (currentRow == 8)
                {
                    result = 612;
                }
            }
            return result;
        }

        public int getTopPosition(int numRows, int currentRow)
        {
            int result = 0;
            if (numRows == 1)
            {
                if (currentRow == 1)
                {
                    result = 105;
                }
            }
            else if (numRows == 2)
            {
                if (currentRow == 1)
                {
                    result = 105;
                }
                else if (currentRow == 2)
                {
                    result = 105;
                }
            }
            else if (numRows == 3)
            {
                if (currentRow == 1)
                {
                    result = 105;
                }
                else if (currentRow == 2)
                {
                    result = 105;
                }
                else if (currentRow == 3)
                {
                    result = 105;
                }
            }
            else if (numRows == 4)
            {
                if (currentRow == 1)
                {
                    result = 105;
                }
                else if (currentRow == 2)
                {
                    result = 105;
                }
                else if (currentRow == 3)
                {
                    result = 105;
                }
                else if (currentRow == 4)
                {
                    result = 105;
                }
            }
            else if (numRows == 5)
            {
                if (currentRow == 1)
                {
                    result = 12;
                }
                else if (currentRow == 2)
                {
                    result = 12;
                }
                else if (currentRow == 3)
                {
                    result = 202;
                }
                else if (currentRow == 4)
                {
                    result = 202;
                }
                else if (currentRow == 5)
                {
                    result = 202;
                }
            }
            else if (numRows == 6)
            {
                if (currentRow == 1)
                {
                    result = 10;
                }
                else if (currentRow == 2)
                {
                    result = 10;
                }
                else if (currentRow == 3)
                {
                    result = 10;
                }
                else if (currentRow == 4)
                {
                    result = 202;
                }
                else if (currentRow == 5)
                {
                    result = 202;
                }
                else if (currentRow == 6)
                {
                    result = 202;
                }
            }
            else if (numRows == 7)
            {
                if (currentRow == 1)
                {
                    result = 10;
                }
                else if (currentRow == 2)
                {
                    result = 10;
                }
                else if (currentRow == 3)
                {
                    result = 10;
                }
                else if (currentRow == 4)
                {
                    result = 202;
                }
                else if (currentRow == 5)
                {
                    result = 202;
                }
                else if (currentRow == 6)
                {
                    result = 202;
                }
                else if (currentRow == 7)
                {
                    result = 202;
                }
            }
            else if (numRows == 8)
            {
                if (currentRow == 1)
                {
                    result = 12;
                }
                else if (currentRow == 2)
                {
                    result = 12;
                }
                else if (currentRow == 3)
                {
                    result = 12;
                }
                else if (currentRow == 4)
                {
                    result = 12;
                }
                else if (currentRow == 5)
                {
                    result = 202;
                }
                else if (currentRow == 6)
                {
                    result = 202;
                }
                else if (currentRow == 7)
                {
                    result = 202;
                }
                else if (currentRow == 8)
                {
                    result = 202;
                }
            }
            return result;
        }

        private void btnShowDummyForm_Click(object sender, EventArgs e)
        {
            frmPritPreviewReceipt frmPritPreviewReceipt = new frmPritPreviewReceipt();
            frmPritPreviewReceipt.ShowDialog();

            //frmDummy frmDummy = new frmDummy();
            //frmDummy.Show();
        }

        //Enable double buffering for all the controls
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams handleparam = base.CreateParams;
        //        handleparam.ExStyle |= 0x02000000;
        //        return handleparam;
        //    }
        //}

    }
}
