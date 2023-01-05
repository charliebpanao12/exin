using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_UserCredentials : Form
    {
        public static int userID;
        public static String displayName;

        public frmSettings_UserCredentials()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            guna2PanelTitle.CustomBorderColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleSystemSettings.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleBusinessUnits.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleAccountingSystem.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleVoucheringSystem.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleBillingCollection.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleSalesCollection.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleInventorySystem.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            togglePayrollSystem.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            togglePointOfSales.CheckedState.FillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleFixedAssetsManagement.CheckedState.FillColor = Global.themeColor1;

            // Controls - Filter - ComboBox
            cboUserList1.BorderColor = Global.themeColor1;
            cboUserList1.FocusedState.BorderColor = Global.themeColor2;
            cboUserList1.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList2.BorderColor = Global.themeColor1;
            cboUserList2.FocusedState.BorderColor = Global.themeColor2;
            cboUserList2.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList3.BorderColor = Global.themeColor1;
            cboUserList3.FocusedState.BorderColor = Global.themeColor2;
            cboUserList3.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList4.BorderColor = Global.themeColor1;
            cboUserList4.FocusedState.BorderColor = Global.themeColor2;
            cboUserList4.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList5.BorderColor = Global.themeColor1;
            cboUserList5.FocusedState.BorderColor = Global.themeColor2;
            cboUserList5.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList6.BorderColor = Global.themeColor1;
            cboUserList6.FocusedState.BorderColor = Global.themeColor2;
            cboUserList6.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList7.BorderColor = Global.themeColor1;
            cboUserList7.FocusedState.BorderColor = Global.themeColor2;
            cboUserList7.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList8.BorderColor = Global.themeColor1;
            cboUserList8.FocusedState.BorderColor = Global.themeColor2;
            cboUserList8.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList9.BorderColor = Global.themeColor1;
            cboUserList9.FocusedState.BorderColor = Global.themeColor2;
            cboUserList9.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserList10.BorderColor = Global.themeColor1;
            cboUserList10.FocusedState.BorderColor = Global.themeColor2;
            cboUserList10.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 1
            btnSave.FillColor = Global.themeColor1;
            btnSave.HoverState.FillColor = Global.themeColor2;
            btnSave.HoverState.ForeColor = Global.themeForeColor;
        }

        private void frmSettings_UserCredentials_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            // Preloader - Ready
            var loader = new WaitFormFunc();

            // Preloader - Start 
            loader.ShowSmall();

            lblUserID.Text = "" + userID;
            lblDisplayName.Text = displayName;

            loadBusinessUnits();
            loadUserCredentials_BusinessUnits(panelContainer_BusinessUnits, "SELECT * FROM tbl_users_credentials_business_units WHERE user_id=" + userID + " ORDER BY category_code DESC, unit_code DESC;");

            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support") // Retrict other user to give access to chart of accounts for other users
            {
                loadSystemFeatures(panelContainer_SystemSettings, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='System Settings' ORDER BY category_order DESC, feature_order DESC;");
            }
            else
            {
                loadSystemFeatures(panelContainer_SystemSettings, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='System Settings' AND " +
                    "CONCAT(category, ' ', feature_description)<>'Chart of Accounts Add' AND " +
                    "CONCAT(category, ' ', feature_description)<>'Chart of Accounts Edit' AND " +
                    "CONCAT(category, ' ', feature_description)<>'Chart of Accounts Delete' ORDER BY category_order DESC, feature_order DESC;");
            }
            loadSystemFeatures(panelContainer_AccountingSystem, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Accounting System' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_VoucherSystem, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Vouchering System' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_SalesCollection, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Sales & Collection' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_BillingCollection, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Billing & Collection' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_InventorySystem, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Inventory System' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_PayrollSystem, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Payroll System' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_PointOfSales, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Point of Sales' ORDER BY category_order DESC, feature_order DESC;");
            loadSystemFeatures(panelContainer_FixedAssetsManagenment, "SELECT * FROM tbl_settings_list_of_system_features WHERE system_module='Fixed Assets Management' ORDER BY category_order DESC, feature_order DESC;");

            loadUserCredentials_SystemFetures(panelContainer_SystemSettings, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='System Settings';");
            loadUserCredentials_SystemFetures(panelContainer_AccountingSystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Accounting System';");
            loadUserCredentials_SystemFetures(panelContainer_VoucherSystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Vouchering System';");
            loadUserCredentials_SystemFetures(panelContainer_SalesCollection, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Sales & Collection';");
            loadUserCredentials_SystemFetures(panelContainer_BillingCollection, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Billing & Collection';");
            loadUserCredentials_SystemFetures(panelContainer_InventorySystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Inventory System';");
            loadUserCredentials_SystemFetures(panelContainer_PayrollSystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Payroll System';");
            loadUserCredentials_SystemFetures(panelContainer_PointOfSales, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Point of Sales';");
            loadUserCredentials_SystemFetures(panelContainer_FixedAssetsManagenment, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='Fixed Assets Management';");

            loadUserList();

            // Preloader - Close
            loader.CloseSmall();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void loadBusinessUnits()
        {
            panelContainer_BusinessUnits.Controls.Clear(); // Clear the container first            

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.Category_Code, t1.Unit_Code, t1.Unit_Name FROM " +
                "(SELECT Category_Code, Unit_Code, Unit_Name FROM tbl_units WHERE Status='Active') AS t1 " +
                "ORDER BY t1.Category_Code DESC, t1.Unit_Name DESC;", Conns.mySqlconn);     // Create a query command
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
                    ucSettings_UserCredentials_BusinessUnits ucSettings_UserCredentials_BusinessUnits = new ucSettings_UserCredentials_BusinessUnits();
                    ucSettings_UserCredentials_BusinessUnits.Dock = DockStyle.Top;
                    ucSettings_UserCredentials_BusinessUnits.categoryCode = Conns.mySqlDataReader["Category_Code"].ToString();
                    ucSettings_UserCredentials_BusinessUnits.unitCode = Conns.mySqlDataReader["Unit_Code"].ToString();
                    ucSettings_UserCredentials_BusinessUnits.unitName = Conns.mySqlDataReader["Unit_Name"].ToString();
                    panelContainer_BusinessUnits.Controls.Add(ucSettings_UserCredentials_BusinessUnits);
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadUserCredentials_BusinessUnits(Panel panelContainer, String query)
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
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
                    string userAccess_CategoryCode = Conns.mySqlDataReader["category_code"].ToString();
                    string userAccess_UnitCode = Conns.mySqlDataReader["unit_code"].ToString();

                    // Toggle on-off the status of system feature
                    for (var j = panelContainer.Controls.Count - 1; j >= 0; j--)
                    {
                        if (panelContainer.Controls[j] is ucSettings_UserCredentials_BusinessUnits)
                        {
                            ucSettings_UserCredentials_BusinessUnits ucSettings_UserCredentials_BusinessUnits = panelContainer.Controls[j] as ucSettings_UserCredentials_BusinessUnits;
                            string userControl_CategoryCode = ucSettings_UserCredentials_BusinessUnits.categoryCode;
                            string userControlUnitCode = ucSettings_UserCredentials_BusinessUnits.unitCode;

                            if (userAccess_CategoryCode == userControl_CategoryCode && userAccess_UnitCode == userControlUnitCode)
                            {
                                ucSettings_UserCredentials_BusinessUnits.toggleControl.Checked = true;
                            }
                        }
                    }

                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadSystemFeatures(Panel panelContainer, String query)
        {
            panelContainer.Controls.Clear(); // Clear the container first            

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
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
                    ucSettings_UserCredentials_SystemFeatures ucSettings_UserCredentials_SystemFeatures = new ucSettings_UserCredentials_SystemFeatures();
                    ucSettings_UserCredentials_SystemFeatures.Dock = DockStyle.Top;
                    ucSettings_UserCredentials_SystemFeatures.systemModule = Conns.mySqlDataReader["system_module"].ToString();
                    ucSettings_UserCredentials_SystemFeatures.category = Conns.mySqlDataReader["category"].ToString();
                    ucSettings_UserCredentials_SystemFeatures.systemFeature = Conns.mySqlDataReader["feature_description"].ToString();
                    panelContainer.Controls.Add(ucSettings_UserCredentials_SystemFeatures);
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadUserCredentials_SystemFetures(Panel panelContainer, String query)
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
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
                    string userAccess_SystemModule = Conns.mySqlDataReader["system_module"].ToString();
                    string userAccess_Category = Conns.mySqlDataReader["category"].ToString();
                    string userAccess_SystemFeature = Conns.mySqlDataReader["feature_description"].ToString();

                    // Toggle on-off the status of system feature              
                    for (var j = panelContainer.Controls.Count - 1; j >= 0; j--)
                    {
                        if (panelContainer.Controls[j] is ucSettings_UserCredentials_SystemFeatures)
                        {
                            ucSettings_UserCredentials_SystemFeatures ucSettings_UserCredentials_SystemFeatures = panelContainer.Controls[j] as ucSettings_UserCredentials_SystemFeatures;
                            string userControl_SystemModule = ucSettings_UserCredentials_SystemFeatures.systemModule;
                            string userControl_Category = ucSettings_UserCredentials_SystemFeatures.category;
                            string userControl_SystemFeature = ucSettings_UserCredentials_SystemFeatures.systemFeature;

                            if (userAccess_SystemModule == userControl_SystemModule && userAccess_Category == userControl_Category && userAccess_SystemFeature == userControl_SystemFeature)
                            {
                                ucSettings_UserCredentials_SystemFeatures.toggleControl.Checked = true;
                            }
                        }
                    }

                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void loadUserList()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            if (Global.userLevel == "EXIN Developer")
            {
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE Status='Active' ORDER BY First_Name, Last_Name ASC;", Conns.mySqlconn);     // Create a query command
            }
            else if (Global.userLevel == "EXIN Support")
            {
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE User_Role<>'EXIN Developer' AND Status='Active' ORDER BY First_Name, Last_Name ASC;", Conns.mySqlconn);     // Create a query command
            }
            else
            {
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE User_Role<>'EXIN Developer' AND User_Role<>'EXIN Support' AND Status='Active' ORDER BY First_Name, Last_Name ASC;", Conns.mySqlconn);     // Create a query command
            }

            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader
            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            cboUserList1.Items.Clear();    // Clear the records from the control
            cboUserList2.Items.Clear();    // Clear the records from the control
            cboUserList3.Items.Clear();    // Clear the records from the control
            cboUserList4.Items.Clear();    // Clear the records from the control
            cboUserList5.Items.Clear();    // Clear the records from the control
            cboUserList6.Items.Clear();    // Clear the records from the control
            cboUserList7.Items.Clear();    // Clear the records from the control
            cboUserList8.Items.Clear();    // Clear the records from the control
            cboUserList9.Items.Clear();    // Clear the records from the control
            cboUserList10.Items.Clear();    // Clear the records from the control

            if (numRows > 0)
            {
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    cboUserList1.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList2.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList3.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList4.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList5.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList6.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList7.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList8.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList9.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    cboUserList10.Items.Add(Conns.mySqlDataReader["First_Name"].ToString() + " " + Conns.mySqlDataReader["Last_Name"].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "User Accounts", "Assign Credentials") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings_UserCredentials"].Activate(); // Bring the parent form to the front
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                // Delete all existing credentials of the user before updating his/her credentials
                MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                Conns.mySqlCmd = new MySqlCommand("DELETE FROM tbl_users_credentials_system_features WHERE user_id=" + userID + ";", Conns.mySqlconn);     // Create a query command
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command                
                Conns.closeConnection();    // !Important ->> Close the connection from the database

                // Delete all existing credentials of the user before updating his/her credentials
                MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                Conns2.mySqlCmd = new MySqlCommand("DELETE FROM tbl_users_credentials_business_units WHERE user_id=" + userID + ";", Conns2.mySqlconn);     // Create a query command
                Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command                
                Conns2.closeConnection();    // !Important ->> Close the connection from the database

                // Insert all the credentials of the user to the database             
                saveUserCredentials_BusinessUnit(panelContainer_BusinessUnits);

                saveUserCredentials_SystemFeatures(panelContainer_SystemSettings);
                saveUserCredentials_SystemFeatures(panelContainer_AccountingSystem);
                saveUserCredentials_SystemFeatures(panelContainer_VoucherSystem);
                saveUserCredentials_SystemFeatures(panelContainer_SalesCollection);
                saveUserCredentials_SystemFeatures(panelContainer_BillingCollection);
                saveUserCredentials_SystemFeatures(panelContainer_InventorySystem);
                saveUserCredentials_SystemFeatures(panelContainer_PayrollSystem);
                saveUserCredentials_SystemFeatures(panelContainer_PointOfSales);
                saveUserCredentials_SystemFeatures(panelContainer_FixedAssetsManagenment);

                new classMsgBox().showMsgSuccessful("Record has been updated");
                this.Hide();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front 
        }

        private void saveUserCredentials_BusinessUnit(Panel panelContainer)
        {
            for (var i = panelContainer.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer.Controls[i] is ucSettings_UserCredentials_BusinessUnits)
                {
                    ucSettings_UserCredentials_BusinessUnits ucSettings_UserCredentials_BusinessUnits = panelContainer.Controls[i] as ucSettings_UserCredentials_BusinessUnits;

                    if (ucSettings_UserCredentials_BusinessUnits.toggleControl.Checked == true)
                    {
                        MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                        Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_users_credentials_business_units(user_id, category_code, unit_code) " +
                           "VALUES (@user_id, @category_code, @unit_code);", Conns2.mySqlconn);                // Create a query command
                        Conns2.mySqlCmd.Parameters.AddWithValue("user_id", userID);                                                 // Add Command Parameters
                        Conns2.mySqlCmd.Parameters.AddWithValue("category_code", ucSettings_UserCredentials_BusinessUnits.categoryCode);          // Add Command Parameters
                        Conns2.mySqlCmd.Parameters.AddWithValue("unit_code", ucSettings_UserCredentials_BusinessUnits.unitCode);                   // Add Command Parameters
                        Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    }
                }
            }
        }

        private void saveUserCredentials_SystemFeatures(Panel panelContainer)
        {
            for (var i = panelContainer.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer.Controls[i] is ucSettings_UserCredentials_SystemFeatures)
                {
                    ucSettings_UserCredentials_SystemFeatures ucSettings_UserCredentials_SystemFeatures = panelContainer.Controls[i] as ucSettings_UserCredentials_SystemFeatures;

                    if (ucSettings_UserCredentials_SystemFeatures.toggleControl.Checked == true)
                    {
                        MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                        Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_users_credentials_system_features(user_id, system_module, category, feature_description) " +
                           "VALUES (@user_id, @system_module, @category, @feature_description);", Conns2.mySqlconn);                // Create a query command
                        Conns2.mySqlCmd.Parameters.AddWithValue("user_id", userID);                                                 // Add Command Parameters
                        Conns2.mySqlCmd.Parameters.AddWithValue("system_module", ucSettings_UserCredentials_SystemFeatures.systemModule);          // Add Command Parameters
                        Conns2.mySqlCmd.Parameters.AddWithValue("category", ucSettings_UserCredentials_SystemFeatures.category);                   // Add Command Parameters
                        Conns2.mySqlCmd.Parameters.AddWithValue("feature_description", ucSettings_UserCredentials_SystemFeatures.systemFeature);   // Add Command Parameters
                        Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    }
                }
            }
        }

        private void toggleSystemSettings_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_SystemSettings, toggleSystemSettings);
        }

        private void toggleBusinessUnits_CheckedChanged(object sender, EventArgs e)
        {
            Boolean toggleValue = false;
            if (toggleBusinessUnits.Checked == true)
            {
                toggleValue = true;
            }
            else if (toggleBusinessUnits.Checked == false)
            {
                toggleValue = false;
            }

            for (var i = panelContainer_BusinessUnits.Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer_BusinessUnits.Controls[i] is ucSettings_UserCredentials_BusinessUnits)
                {
                    ucSettings_UserCredentials_BusinessUnits ucSettings_UserCredentials_BusinessUnits = panelContainer_BusinessUnits.Controls[i] as ucSettings_UserCredentials_BusinessUnits;
                    ucSettings_UserCredentials_BusinessUnits.toggleControl.Checked = toggleValue;
                }
            }
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
                if (panelContainer.Controls[i] is ucSettings_UserCredentials_SystemFeatures)
                {
                    ucSettings_UserCredentials_SystemFeatures ucSettings_UserCredentials_SystemFeatures = panelContainer.Controls[i] as ucSettings_UserCredentials_SystemFeatures;
                    ucSettings_UserCredentials_SystemFeatures.toggleControl.Checked = toggleValue;
                }
            }
        }

        private void toggleAccountingSystem_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_AccountingSystem, toggleAccountingSystem);
        }

        private void toggleVoucheringSystem_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_VoucherSystem, toggleVoucheringSystem);
        }

        private void toggleBillingCollection_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_BillingCollection, toggleBillingCollection);
        }

        private void toggleSalesCollection_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_SalesCollection, toggleSalesCollection);
        }

        private void toggleInventorySystem_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_InventorySystem, toggleInventorySystem);
        }

        private void togglePayrollSystem_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_PayrollSystem, togglePayrollSystem);
        }

        private void togglePointOfSales_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_PointOfSales, togglePointOfSales);
        }

        private void toggleFixedAssetsManagement_CheckedChanged(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_FixedAssetsManagenment, toggleFixedAssetsManagement);
        }


        private void copyUserCredentialsFromAUser(String userDisplayName)
        {
            int targetUserID = Convert.ToInt32(classGlobalFunctions.getReferenceDetails("User_ID", "SELECT User_ID FROM tbl_users WHERE CONCAT(First_Name, ' ', Last_Name)='" + userDisplayName + "' AND Status='Active' LIMIT 1"));
            cboUserList1.Text = userDisplayName;
            cboUserList2.Text = userDisplayName;
            cboUserList3.Text = userDisplayName;
            cboUserList4.Text = userDisplayName;
            cboUserList5.Text = userDisplayName;
            cboUserList6.Text = userDisplayName;
            cboUserList7.Text = userDisplayName;
            cboUserList8.Text = userDisplayName;
            cboUserList9.Text = userDisplayName;
            cboUserList10.Text = userDisplayName;

            // Toggle-Off all features
            toggleSystemSettings.Checked = false;
            toggleBusinessUnits.Checked = false;
            toggleAccountingSystem.Checked = false;
            toggleVoucheringSystem.Checked = false;
            toggleBillingCollection.Checked = false;
            toggleSalesCollection.Checked = false;
            toggleInventorySystem.Checked = false;
            togglePayrollSystem.Checked = false;
            togglePointOfSales.Checked = false;
            toggleFixedAssetsManagement.Checked = false;

            // Toggle-on the features based on the credentials of the selected user
            loadUserCredentials_BusinessUnits(panelContainer_BusinessUnits, "SELECT * FROM tbl_users_credentials_business_units WHERE user_id=" + targetUserID + " ORDER BY category_code DESC, unit_code DESC;");
            loadUserCredentials_SystemFetures(panelContainer_SystemSettings, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='System Settings';");
            loadUserCredentials_SystemFetures(panelContainer_AccountingSystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Accounting System';");
            loadUserCredentials_SystemFetures(panelContainer_VoucherSystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Vouchering System';");
            loadUserCredentials_SystemFetures(panelContainer_SalesCollection, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Sales & Collection';");
            loadUserCredentials_SystemFetures(panelContainer_BillingCollection, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Billing & Collection';");
            loadUserCredentials_SystemFetures(panelContainer_InventorySystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Inventory System';");
            loadUserCredentials_SystemFetures(panelContainer_PayrollSystem, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Payroll System';");
            loadUserCredentials_SystemFetures(panelContainer_PointOfSales, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Point of Sales';");
            loadUserCredentials_SystemFetures(panelContainer_FixedAssetsManagenment, "SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + targetUserID + " AND system_module='Fixed Assets Management';");
        }

        private void cboUserList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList1.Text.Trim());
        }

        private void cboUserList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList2.Text.Trim());
        }

        private void cboUserList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList3.Text.Trim());
        }

        private void cboUserList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList4.Text.Trim());
        }

        private void cboUserList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList5.Text.Trim());
        }

        private void cboUserList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList6.Text.Trim());
        }

        private void cboUserList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList7.Text.Trim());
        }

        private void cboUserList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList8.Text.Trim());
        }

        private void cboUserList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList9.Text.Trim());
        }

        private void cboUserList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyUserCredentialsFromAUser(cboUserList10.Text.Trim());
        }
    }
}
