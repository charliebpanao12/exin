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
using MySql.Data.MySqlClient;

namespace EXIN.Settings
{
    public partial class frmSettings_SupplierList_New : Form
    {
        public static String addViewEdit;
        public static int supplierID;
        public static int supplierCode;
        public static String supplierName;

        public frmSettings_SupplierList_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtSupplierCode.BorderColor = Global.themeColor1;
            txtSupplierCode.FocusedState.BorderColor = Global.themeColor2;
            txtSupplierCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtSupplierName.BorderColor = Global.themeColor1;
            txtSupplierName.FocusedState.BorderColor = Global.themeColor2;
            txtSupplierName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtTIN.BorderColor = Global.themeColor1;
            txtTIN.FocusedState.BorderColor = Global.themeColor2;
            txtTIN.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtAddress.BorderColor = Global.themeColor1;
            txtAddress.FocusedState.BorderColor = Global.themeColor2;
            txtAddress.HoverState.BorderColor = Global.themeColor2;

            // Controls - Toggle Switch
            toggleSelectAll.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleSelectAll_WTax.CheckedState.FillColor = Global.themeColor1;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_SupplierList_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            // Preloader - Ready
            var loader = new WaitFormFunc();
            loader.ShowSmall(); // Preloader - Start

            loadBusinessCategory();
            loadWTAXReference();

            if (addViewEdit == "View" || addViewEdit == "Edit")
            {
                loadDetails();
                loadDetails_WTax();

                if (addViewEdit == "View")
                {
                    btnSave.Enabled = false;
                }
            }

            // Preloader - Close
            loader.CloseSmall();
        }

        private void clearFields()
        {
            txtSupplierCode.Text = "Automatic";
            txtSupplierName.Text = "";
            txtTIN.Text = "";
            txtAddress.Text = "";

            toggleSelectAll.Checked = false;
            panelContainer_BusinessCategory.Controls.Clear();
            panelContainer_WTax.Controls.Clear();
        }

        private void loadBusinessCategory()
        {
            panelContainer_BusinessCategory.Controls.Clear(); // Clear the container first            

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.Category_Code, t1.Category_Name, t2.user_id FROM " +
                "(SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t1 " +
                "LEFT JOIN (SELECT user_id, category_code FROM tbl_users_credentials_business_units WHERE user_id=" + Global.userID + ") AS t2 ON t1.Category_Code=t2.category_code " +
                "GROUP BY t1.Category_Code ORDER BY t1.Category_Code ASC;", Conns.mySqlconn);     // Create a query command
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
                    ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = new ucSettings_SelectionItems_BusinessCategory();
                    ucSettings_SelectionItems_BusinessCategory.Dock = DockStyle.Top;
                    ucSettings_SelectionItems_BusinessCategory.categoryCode = Conns.mySqlDataReader["Category_Code"].ToString();
                    ucSettings_SelectionItems_BusinessCategory.categoryName = Conns.mySqlDataReader["Category_Name"].ToString();
                    ucSettings_SelectionItems_BusinessCategory.verifyUserID = "" + Conns.mySqlDataReader["user_id"].ToString();
                    panelContainer_BusinessCategory.Controls.Add(ucSettings_SelectionItems_BusinessCategory);
                    ucSettings_SelectionItems_BusinessCategory.BringToFront();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadWTAXReference()
        {
            panelContainer_WTax.Controls.Clear(); // Clear the container first            

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ATC, t1.Title, t1.Percentage FROM " +
                "(SELECT ATC, Title, Description, Percentage FROM tbl_wtax) AS t1 " +
                "ORDER BY t1.ATC ASC;", Conns.mySqlconn);     // Create a query command
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
                    ucSettings_SupplierList_WTaxReference ucSettings_SupplierList_WTaxReference = new ucSettings_SupplierList_WTaxReference();
                    ucSettings_SupplierList_WTaxReference.Dock = DockStyle.Top;
                    ucSettings_SupplierList_WTaxReference.atcCode = Conns.mySqlDataReader["ATC"].ToString();
                    ucSettings_SupplierList_WTaxReference.atcTitle = Conns.mySqlDataReader["Title"].ToString();
                    ucSettings_SupplierList_WTaxReference.atcPercentage = Convert.ToDouble(Conns.mySqlDataReader["Percentage"].ToString());
                    panelContainer_WTax.Controls.Add(ucSettings_SupplierList_WTaxReference);
                    ucSettings_SupplierList_WTaxReference.BringToFront();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.Category_Code, t1.Supplier_Code, t1.Supplier_Name, t1.Supplier_TIN, t1.Supplier_Address, t1.Supplier_Notes, t1.Supplier_Notes2, t1.Status FROM " +
                "(SELECT ID, Category_Code, Supplier_Code, Supplier_Name, Supplier_TIN, Supplier_Address, Supplier_Notes, Supplier_Notes2, Status FROM tbl_suppliers WHERE Supplier_Code=" + supplierCode + ") AS t1 " +
                ";", Conns.mySqlconn);     // Create a query command
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
                    txtSupplierCode.Text = Conns.mySqlDataReader["Supplier_Code"].ToString();
                    txtSupplierName.Text = Conns.mySqlDataReader["Supplier_Name"].ToString();
                    txtTIN.Text = Conns.mySqlDataReader["Supplier_TIN"].ToString();
                    txtAddress.Text = Conns.mySqlDataReader["Supplier_Address"].ToString();

                    // Toggle on-off the status             
                    for (var j = panelContainer_BusinessCategory.Controls.Count - 1; j >= 0; j--)
                    {
                        if (panelContainer_BusinessCategory.Controls[j] is ucSettings_SelectionItems_BusinessCategory)
                        {
                            ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer_BusinessCategory.Controls[j] as ucSettings_SelectionItems_BusinessCategory;
                            string userControl_BusinessCategoryCode = ucSettings_SelectionItems_BusinessCategory.categoryCode;

                            if (Conns.mySqlDataReader["Category_Code"].ToString() == userControl_BusinessCategoryCode)
                            {
                                // Tag the record as already existing for this business category
                                ucSettings_SelectionItems_BusinessCategory.alreadyExisting = true;

                                // Validate if the record is active or deleted
                                if (Conns.mySqlDataReader["Status"].ToString() == "Active")
                                {
                                    ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked = true;
                                }

                                // Validate if there is an active transaction for this GLSL and Business Category
                                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT Category_Code, Supplier_Code, Status FROM tbl_transaction WHERE Category_Code='" + userControl_BusinessCategoryCode + "' AND Supplier_Code=" + Convert.ToInt32(txtSupplierCode.Text.Trim()) + " AND Status='Active' LIMIT 1;");
                                if (recordExist == true)
                                {
                                    ucSettings_SelectionItems_BusinessCategory.locked = true;
                                    ucSettings_SelectionItems_BusinessCategory.lblLocked.Visible = true;
                                }
                            }
                        }
                    }
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadDetails_WTax()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.Supplier_Code, t1.WTax_Reference FROM " +
                "(SELECT ID, Supplier_Code, WTax_Reference FROM tbl_suppliers_wtax_reference WHERE Supplier_Code=" + supplierCode + ") AS t1 " +
                ";", Conns.mySqlconn);     // Create a query command
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
                    // Toggle on-off the status             
                    for (var j = panelContainer_WTax.Controls.Count - 1; j >= 0; j--)
                    {
                        if (panelContainer_WTax.Controls[j] is ucSettings_SupplierList_WTaxReference)
                        {
                            ucSettings_SupplierList_WTaxReference ucSettings_SupplierList_WTaxReference = panelContainer_WTax.Controls[j] as ucSettings_SupplierList_WTaxReference;
                            string userControl_atcCode = ucSettings_SupplierList_WTaxReference.atcCode;

                            if (Conns.mySqlDataReader["WTax_Reference"].ToString() == userControl_atcCode)
                            {
                                ucSettings_SupplierList_WTaxReference.toggleControl.Checked = true;
                            }
                        }
                    }
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void toggleSelectAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleSelectAll_Click(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_BusinessCategory, toggleSelectAll);
        }

        private void toggleSelectAll_WTax_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleSelectAll_WTax_Click(object sender, EventArgs e)
        {
            toggleOptionsOnOff_WTax(panelContainer_WTax, toggleSelectAll_WTax);
        }

        private void toggleOptionsOnOff(Panel panelContainer, Guna.UI2.WinForms.Guna2ToggleSwitch toggleSwitch)
        {
            Boolean toggleValue = false;
            if (toggleSwitch.Checked == true)
            {
                toggleValue = true;
            }
            else if (toggleSwitch.Checked == false)
            {
                toggleValue = false;
            }

            for (var i = panelContainer.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer.Controls[i] is ucSettings_SelectionItems_BusinessCategory)
                {
                    ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer.Controls[i] as ucSettings_SelectionItems_BusinessCategory;
                    if (ucSettings_SelectionItems_BusinessCategory.lblNoAccess.Visible == false && ucSettings_SelectionItems_BusinessCategory.locked == false) // "Locked" and "No Access" tags won't change the toggle status
                    {
                        ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked = toggleValue;
                    }
                }
            }
        }

        private void toggleOptionsOnOff_WTax(Panel panelContainer, Guna.UI2.WinForms.Guna2ToggleSwitch toggleSwitch)
        {
            Boolean toggleValue = false;
            if (toggleSwitch.Checked == true)
            {
                toggleValue = true;
            }
            else if (toggleSwitch.Checked == false)
            {
                toggleValue = false;
            }

            for (var i = panelContainer.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer.Controls[i] is ucSettings_SupplierList_WTaxReference)
                {
                    ucSettings_SupplierList_WTaxReference ucSettings_SupplierList_WTaxReference = panelContainer.Controls[i] as ucSettings_SupplierList_WTaxReference;
                    if (ucSettings_SupplierList_WTaxReference.lblNoAccess.Visible == false && ucSettings_SupplierList_WTaxReference.locked == false) // "Locked" and "No Access" tags won't change the toggle status
                    {
                        ucSettings_SupplierList_WTaxReference.toggleControl.Checked = toggleValue;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtSupplierName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input supplier/payee name!");
                Application.OpenForms["frmSettings_SupplierList_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_suppliers WHERE Supplier_Name='" + txtSupplierName.Text.Trim() + "' LIMIT 1;");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The supplier name already exists in the database!");
                    Application.OpenForms["frmSettings_SupplierList_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {

            }

            // Validate if there are selected business category
            int selectedItems = 0;
            for (var i = panelContainer_BusinessCategory.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer_BusinessCategory.Controls[i] is ucSettings_SelectionItems_BusinessCategory)
                {
                    ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer_BusinessCategory.Controls[i] as ucSettings_SelectionItems_BusinessCategory;
                    if (ucSettings_SelectionItems_BusinessCategory.lblNoAccess.Visible == false)
                    {
                        if (ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked == true)
                        {
                            selectedItems++;
                            break;
                        }
                    }
                }
            }
            if (selectedItems == 0)
            {
                new classMsgBox().showMsgError("There are no selected business category!");
                Application.OpenForms["frmSettings_SupplierList_New"].Activate(); // Bring the parent form to the front 
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                String timeStamp = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToShortTimeString();

                if (addViewEdit == "Add")
                {
                    // Generate New ID
                    txtSupplierCode.Text = classGlobalFunctions.generateNewID(301, "Supplier_Code", "SELECT Supplier_Code FROM tbl_suppliers ORDER BY Supplier_Code DESC LIMIT 1;").ToString();

                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                    for (var i = panelContainer_BusinessCategory.Controls.Count - 1; i >= 0; i--)
                    {
                        if (panelContainer_BusinessCategory.Controls[i] is ucSettings_SelectionItems_BusinessCategory)
                        {
                            ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer_BusinessCategory.Controls[i] as ucSettings_SelectionItems_BusinessCategory;

                            if (ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked == true)
                            {
                                Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_suppliers(Category_Code, Supplier_Code, Supplier_Name, Supplier_TIN, Supplier_Address, Supplier_Notes, Status, Remarks) " +
                                    "VALUES (@Category_Code, @Supplier_Code, @Supplier_Name, @Supplier_TIN, @Supplier_Address, @Supplier_Notes, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                                Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Code", txtSupplierCode.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Name", txtSupplierName.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_TIN", txtTIN.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Address", txtAddress.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Notes", "");
                                Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                                Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                Conns2.mySqlDataReader.Close();
                            }
                        }
                    }
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                else if (addViewEdit == "Edit")
                {
                    // Loop  the records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                    for (var i = panelContainer_BusinessCategory.Controls.Count - 1; i >= 0; i--)
                    {
                        if (panelContainer_BusinessCategory.Controls[i] is ucSettings_SelectionItems_BusinessCategory)
                        {
                            ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer_BusinessCategory.Controls[i] as ucSettings_SelectionItems_BusinessCategory;

                            if (ucSettings_SelectionItems_BusinessCategory.alreadyExisting == true)
                            {
                                if (ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked == true)
                                {
                                    // Update the existing record
                                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_suppliers SET Supplier_Name=@Supplier_Name, Supplier_TIN=@Supplier_TIN, Supplier_Address=@Supplier_Address, Supplier_Notes=@Supplier_Notes, Status=@Status WHERE Category_Code=@Category_Code AND Supplier_Code=@Supplier_Code;", Conns2.mySqlconn);     // Create a query command
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Code", txtSupplierCode.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Name", txtSupplierName.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_TIN", txtTIN.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Address", txtAddress.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Notes", "");
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                    Conns2.mySqlDataReader.Close();
                                }
                                else
                                {
                                    // Update the existing record
                                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_suppliers SET Supplier_Name=@Supplier_Name, Supplier_TIN=@Supplier_TIN, Supplier_Address=@Supplier_Address, Supplier_Notes=@Supplier_Notes, Status=@Status WHERE Category_Code=@Category_Code AND Supplier_Code=@Supplier_Code;", Conns2.mySqlconn);     // Create a query command
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Code", txtSupplierCode.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Name", txtSupplierName.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_TIN", txtTIN.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Address", txtAddress.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Notes", "");
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Deleted");
                                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                    Conns2.mySqlDataReader.Close();
                                }
                            }
                            else if (ucSettings_SelectionItems_BusinessCategory.alreadyExisting == false)
                            {
                                if (ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked == true)
                                {
                                    // Insert new record
                                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_suppliers(Category_Code, Supplier_Code, Supplier_Name, Supplier_TIN, Supplier_Address, Supplier_Notes, Status, Remarks) " +
                                    "VALUES (@Category_Code, @Supplier_Code, @Supplier_Name, @Supplier_TIN, @Supplier_Address, @Supplier_Notes, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Code", txtSupplierCode.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Name", txtSupplierName.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_TIN", txtTIN.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Address", txtAddress.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Supplier_Notes", "");
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                    Conns2.mySqlDataReader.Close();
                                }
                            }
                        }
                    }
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }

                // Truncate the WTax Reference
                MySqlConnect Conns3 = new MySqlConnect();    // Connect to the database
                Conns3.mySqlCmd = new MySqlCommand("DELETE FROM tbl_suppliers_wtax_reference WHERE Supplier_Code="+ txtSupplierCode.Text.Trim() +";", Conns3.mySqlconn);     // Create a query command
                Conns3.mySqlDataReader = Conns3.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                Conns3.mySqlDataReader.Close();
                Conns3.closeConnection();    // !Important ->> Close the connection from the database

                // Insert the new WTax Reference
                MySqlConnect Conns4 = new MySqlConnect();    // Connect to the database
                for (var i = panelContainer_WTax.Controls.Count - 1; i >= 0; i--)
                {
                    if (panelContainer_WTax.Controls[i] is ucSettings_SupplierList_WTaxReference)
                    {
                        ucSettings_SupplierList_WTaxReference ucSettings_SupplierList_WTaxReference = panelContainer_WTax.Controls[i] as ucSettings_SupplierList_WTaxReference;
                        if (ucSettings_SupplierList_WTaxReference.toggleControl.Checked == true)
                        {
                            Conns4.mySqlCmd = new MySqlCommand("INSERT INTO tbl_suppliers_wtax_reference(Supplier_Code, WTax_Reference) " +
                            "VALUES(@Supplier_Code, @WTax_Reference);", Conns4.mySqlconn);     // Create a query command
                            Conns4.mySqlCmd.Parameters.AddWithValue("Supplier_Code", txtSupplierCode.Text.Trim());
                            Conns4.mySqlCmd.Parameters.AddWithValue("WTax_Reference", ucSettings_SupplierList_WTaxReference.atcCode);
                            Conns4.mySqlDataReader = Conns4.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                            Conns4.mySqlDataReader.Close();
                        }
                    }
                }
                Conns4.closeConnection();    // !Important ->> Close the connection from the database


                new classMsgBox().showMsgSuccessful("Record has been saved");

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_SupplierList ucSettings_SupplierList = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_SupplierList;
                ucSettings_SupplierList.loadSupplierList();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
