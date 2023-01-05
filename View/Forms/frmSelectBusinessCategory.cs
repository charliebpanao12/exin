using EXIN.Controller;
using EXIN.Fixed_Assets_Management_System;
using EXIN.Inventory_System;
using EXIN.Payroll_System;
using EXIN.Point_Of_Sales;
using EXIN.SalesCollection_System;
using EXIN.Voucher_System;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmSelectBusinessCategory : Form
    {
        static string varSystemModule = "";
        static string varBusinessCategoryCode = "";
        static string varBusinessCategoryName = "";
        static string varBusinessUnitCode = "";
        static string varBusinessUnitName = "";
        static string varBusinessUnitAddress = "";
        static string varBusinessUnitTIN = "";
        static string varBusinessUnitBusinessType = "";
        static string varCorpCode = "";
        static string varCorpName = "";

        public frmSelectBusinessCategory(String systemModule)
        {
            InitializeComponent();

            varSystemModule = systemModule;

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Group
            grpUnit.ForeColor = Global.themeColor1;
            grpUnit.CustomBorderColor = Global.themeColor1;

            // Controls - Button 3
            btnSelect.FillColor = Global.themeColor1;
            btnSelect.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;

            // Controls - ComboBox
            cboBusinessCategory.BorderColor = Global.themeColor1;
            cboBusinessCategory.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessCategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboBusinessUnit.BorderColor = Global.themeColor1;
            cboBusinessUnit.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessUnit.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboType.BorderColor = Global.themeColor1;
            cboType.FocusedState.BorderColor = Global.themeColor2;
            cboType.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtBusinessCategoryCode.BorderColor = Global.themeColor1;
            txtBusinessCategoryCode.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessCategoryCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtBusinessUnitCode.BorderColor = Global.themeColor1;
            txtBusinessUnitCode.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessUnitCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtBusinessType.BorderColor = Global.themeColor1;
            txtBusinessType.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessType.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtTINNo.BorderColor = Global.themeColor1;
            txtTINNo.FocusedState.BorderColor = Global.themeColor2;
            txtTINNo.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtAddress.BorderColor = Global.themeColor1;
            txtAddress.FocusedState.BorderColor = Global.themeColor2;
            txtAddress.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCorporation.BorderColor = Global.themeColor1;
            txtCorporation.FocusedState.BorderColor = Global.themeColor2;
            txtCorporation.HoverState.BorderColor = Global.themeColor2;
        }

        private void frmSelectBusinessCategory_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();

            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory, "Category_Name", "SELECT t1.category_code, t2.Category_Name FROM " +
                "(SELECT category_code FROM tbl_users_credentials_business_units WHERE user_id=" + Global.userID + ") AS t1 " +
                "LEFT JOIN (SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t2 ON t1.category_code=t2.Category_Code " +
                "GROUP BY t2.Category_Name ORDER BY t2.Category_Name ASC;", "Blank");
        }

        private void clearFields()
        {
            cboBusinessCategory.Text = "";
            cboBusinessUnit.Text = "";
            txtBusinessCategoryCode.Text = "";
            txtBusinessUnitCode.Text = "";
            txtBusinessType.Text = "";
            txtTINNo.Text = "";
            txtAddress.Text = "";
            txtCorporation.Text = "";
            picLogo.Image = Image.FromFile("Resources/General/BusinessUnit_Logo/Default.png");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (txtBusinessCategoryCode.Text.Trim() == "" || txtBusinessUnitCode.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select business unit before you proceed");
                Application.OpenForms["frmPOS_MainMenu"].Activate(); // Bring the parent form to the front
                return;
            }

            this.Hide();

            if (varSystemModule == "Accounting System")
            {
                // Prepare the global variables for selected business category
                Global.accountingBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.accountingBusinessCategoryName = "" + varBusinessCategoryName;
                Global.accountingBusinessUnitCode = "" + varBusinessUnitCode;
                Global.accountingBusinessUnitName = "" + varBusinessUnitName;
                Global.accountingBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.accountingBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.accountingBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.accountingCorpCode = "" + varCorpCode;
                Global.accountingCorpName = "" + varCorpName;

                // Show the parent form
                frmController frmController = new frmController();
                frmController.Show();
            }
            else if (varSystemModule == "Vouchering System")
            {
                // Prepare the global variables for selected business category
                Global.voucheringBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.voucheringBusinessCategoryName = "" + varBusinessCategoryName;
                Global.voucheringBusinessUnitCode = "" + varBusinessUnitCode;
                Global.voucheringBusinessUnitName = "" + varBusinessUnitName;
                Global.voucheringBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.voucheringBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.voucheringBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.voucheringCorpCode = "" + varCorpCode;
                Global.voucheringCorpName = "" + varCorpName;

                // Show the parent form
                frmVoucher_ParentContainer frmVoucher_ParentContainer = new frmVoucher_ParentContainer();                
                frmVoucher_ParentContainer.Show();
            }
            else if (varSystemModule == "Billing & Collection")
            {
                // Prepare the global variables for selected business category
                Global.billingCollectionBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.billingCollectionBusinessCategoryName = "" + varBusinessCategoryName;
                Global.billingCollectionBusinessUnitCode = "" + varBusinessUnitCode;
                Global.billingCollectionBusinessUnitName = "" + varBusinessUnitName;
                Global.billingCollectionBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.billingCollectionBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.billingCollectionBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.billingCollectionCorpCode = "" + varCorpCode;
                Global.billingCollectionCorpName = "" + varCorpName;

                // Show the parent form
                frmSalesCollection_ParentContainer frmSalesCollection_ParentContainer = new frmSalesCollection_ParentContainer();
                frmSalesCollection_ParentContainer.Show();
            }
            else if (varSystemModule == "Sales & Collection")
            {
                // Prepare the global variables for selected business category
                Global.salesCollectionBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.salesCollectionBusinessCategoryName = "" + varBusinessCategoryName;
                Global.salesCollectionBusinessUnitCode = "" + varBusinessUnitCode;
                Global.salesCollectionBusinessUnitName = "" + varBusinessUnitName;
                Global.salesCollectionBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.salesCollectionBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.salesCollectionBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.salesCollectionCorpCode = "" + varCorpCode;
                Global.salesCollectionCorpName = "" + varCorpName;

                // Show the parent form
                frmSalesCollection_ParentContainer frmSalesCollection_ParentContainer = new frmSalesCollection_ParentContainer();
                frmSalesCollection_ParentContainer.Show();
            }
            else if (varSystemModule == "Inventory System")
            {
                // Prepare the global variables for selected business category
                Global.inventoryBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.inventoryBusinessCategoryName = "" + varBusinessCategoryName;
                Global.inventoryBusinessUnitCode = "" + varBusinessUnitCode;
                Global.inventoryBusinessUnitName = "" + varBusinessUnitName;
                Global.inventoryBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.inventoryBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.inventoryBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.inventoryCorpCode = "" + varCorpCode;
                Global.inventoryCorpName = "" + varCorpName;

                // Show the parent form
                frmInventory_ParentContainer frmInventory_ParentContainer = new frmInventory_ParentContainer();
                frmInventory_ParentContainer.Show();
            }
            else if (varSystemModule == "Payroll System")
            {
                // Prepare the global variables for selected business category
                Global.payrollBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.payrollBusinessCategoryName = "" + varBusinessCategoryName;
                Global.payrollBusinessUnitCode = "" + varBusinessUnitCode;
                Global.payrollBusinessUnitName = "" + varBusinessUnitName;
                Global.payrollBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.payrollBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.payrollBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.payrollCorpCode = "" + varCorpCode;
                Global.payrollCorpName = "" + varCorpName;

                // Show the parent form
                frmPayroll_ParentContainer frmPayroll_ParentContainer = new frmPayroll_ParentContainer();
                frmPayroll_ParentContainer.Show();
            }
            else if (varSystemModule == "Point of Sales")
            {
                // Prepare the global variables for selected business category
                Global.posBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.posBusinessCategoryName = "" + varBusinessCategoryName;
                Global.posBusinessUnitCode = "" + varBusinessUnitCode;
                Global.posBusinessUnitName = "" + varBusinessUnitName;
                Global.posBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.posBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.posBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.posCorpCode = "" + varCorpCode;
                Global.posCorpName = "" + varCorpName;

                // Show the parent form
                frmPOS_ParentContainer frmPOS_ParentContainer = new frmPOS_ParentContainer();
                frmPOS_ParentContainer.Show();
            }
            else if (varSystemModule == "Fixed Assets Management")
            {
                // Prepare the global variables for selected business category
                Global.fixedAssetsBusinessCategoryCode = "" + varBusinessCategoryCode;
                Global.fixedAssetsBusinessCategoryName = "" + varBusinessCategoryName;
                Global.fixedAssetsBusinessUnitCode = "" + varBusinessUnitCode;
                Global.fixedAssetsBusinessUnitName = "" + varBusinessUnitName;
                Global.fixedAssetsBusinessUnitAddress = "" + varBusinessUnitAddress;
                Global.fixedAssetsBusinessUnitTIN = "" + varBusinessUnitTIN;
                Global.fixedAssetsBusinessUnitBusinessType = "" + varBusinessUnitBusinessType;
                Global.fixedAssetsCorpCode = "" + varCorpCode;
                Global.fixedAssetsCorpName = "" + varCorpName;

                // Show the parent form
                frmFixedAssets_ParentContainer frmFixedAssets_ParentContainer = new frmFixedAssets_ParentContainer();
                frmFixedAssets_ParentContainer.Show();
            }

            // Minimize the main form
            var targetForm = Application.OpenForms.OfType<frmMain>().Single();
            targetForm.WindowState = FormWindowState.Minimized;
        }

        private void cboBusinessCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusinessCategoryCode.Text = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory.Text + "' AND Status='Active' LIMIT 1");
            classGlobalFunctions.loadComboBoxItems(cboBusinessUnit, "Unit_Name", "SELECT t1.unit_code, t2.Unit_Name FROM " +
                "(SELECT unit_code FROM tbl_users_credentials_business_units WHERE Category_Code='" + txtBusinessCategoryCode.Text.Trim() + "' AND user_id=" + Global.userID + ") AS t1 " +
                "LEFT JOIN (SELECT Unit_Code, Unit_Name FROM tbl_units) AS t2 ON t1.unit_code=t2.Unit_Code " +
                "GROUP BY t2.Unit_Name ORDER BY t2.Unit_Name ASC", "Blank");
            cboBusinessUnit.Text = "";
            txtBusinessUnitCode.Text = "";
            txtBusinessType.Text = "";
            txtTINNo.Text = "";
            txtAddress.Text = "";
            txtCorporation.Text = "";
            picLogo.Image = Image.FromFile("Resources/General/BusinessUnit_Logo/Default.png");
        }

        private void cboBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.Category_Code, t1.Corp_Code, t1.Unit_Code, t1.Unit_Name, t1.Unit_TIN, t1.Unit_Address, t1.Business_Type, t2.Category_Name, t3.Corp_Name FROM " +
                "(SELECT Category_Code, Corp_Code, Unit_Code, Unit_Name, Unit_TIN, Unit_Address, Business_Type FROM tbl_units WHERE Unit_Name='" + cboBusinessUnit.Text + "' AND Status='Active' LIMIT 1) AS t1 " +
                "LEFT JOIN (SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t2 ON t1.Category_Code=t2.Category_Code " +
                "LEFT JOIN (SELECT Corp_Code, Corp_Name FROM tbl_corporations WHERE Status='Active') AS t3 ON t1.Corp_Code=t3.Corp_Code;", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            if (numRows > 0)
            {
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Get the records
                {
                    varBusinessCategoryCode = "" + Conns.mySqlDataReader["Category_Code"].ToString();
                    varBusinessCategoryName = "" + Conns.mySqlDataReader["Category_Name"].ToString();
                    varBusinessUnitCode = "" + Conns.mySqlDataReader["Unit_Code"].ToString();
                    varBusinessUnitName = "" + Conns.mySqlDataReader["Unit_Name"].ToString();
                    varBusinessUnitAddress = "" + Conns.mySqlDataReader["Unit_Address"].ToString();
                    varBusinessUnitTIN = "" + Conns.mySqlDataReader["Unit_TIN"].ToString();
                    varBusinessUnitBusinessType = "" + Conns.mySqlDataReader["Business_Type"].ToString();
                    varCorpCode = "" + Conns.mySqlDataReader["Corp_Code"].ToString();
                    varCorpName = "" + Conns.mySqlDataReader["Corp_Name"].ToString();

                    txtBusinessUnitCode.Text = "" + Conns.mySqlDataReader["Unit_Code"].ToString();
                    txtBusinessType.Text = "" + Conns.mySqlDataReader["Business_Type"].ToString();
                    txtTINNo.Text = "" + Conns.mySqlDataReader["Unit_TIN"].ToString();
                    txtAddress.Text = "" + Conns.mySqlDataReader["Unit_Address"].ToString();
                    txtCorporation.Text = "" + Conns.mySqlDataReader["Corp_Name"].ToString();
                    try
                    {
                        picLogo.Image = Image.FromFile("Resources/General/BusinessUnit_Logo/" + txtBusinessCategoryCode.Text + "_" + txtBusinessUnitCode.Text + ".png");
                    }
                    catch
                    {

                    }

                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Business Category Code: " + Global.posBusinessCategoryCode);
            MessageBox.Show("Business Category Name: " + Global.posBusinessCategoryName);
            MessageBox.Show("Business Unit Code: " + Global.posBusinessUnitCode);
            MessageBox.Show("Business Unit Name: " + Global.posBusinessUnitName);
            MessageBox.Show("Business Unit Address: " + Global.posBusinessUnitAddress);
            MessageBox.Show("Business Unit TIN: " + Global.posBusinessUnitTIN);
            MessageBox.Show("Business Unit Business Type: " + Global.posBusinessUnitBusinessType);
            MessageBox.Show("Business Corp Code: " + Global.posCorpCode);
            MessageBox.Show("Business Corp Name: " + Global.posCorpName);
        }
    }
}
