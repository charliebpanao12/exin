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
    public partial class frmSettings_ChartOfAccounts_New : Form
    {
        public static String addViewEdit;
        public static int zcaID;
        public static int zcaGLSL;

        public frmSettings_ChartOfAccounts_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtGLCode.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtGLAccount.BorderColor = Global.themeColor1;
            txtGLAccount.FocusedState.BorderColor = Global.themeColor2;
            txtGLAccount.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtGLSLCode.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtGLSLAccount.BorderColor = Global.themeColor1;
            txtGLSLAccount.FocusedState.BorderColor = Global.themeColor2;
            txtGLSLAccount.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtExpandedAccount.BorderColor = Global.themeColor1;
            txtExpandedAccount.FocusedState.BorderColor = Global.themeColor2;
            txtExpandedAccount.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboExpandedAccount.BorderColor = Global.themeColor1;
            cboExpandedAccount.FocusedState.BorderColor = Global.themeColor2;
            cboExpandedAccount.HoverState.BorderColor = Global.themeColor2;

            // Controls - Toggle Switch
            toggleSelectAll.CheckedState.FillColor = Global.themeColor1;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_ChartOfAccounts_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            // Preloader - Ready
            var loader = new WaitFormFunc();
            loader.ShowSmall(); // Preloader - Start 

            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboExpandedAccount, "ExpandedAccountDesc", "SELECT DISTINCT ExpandedAccountDesc FROM tbl_expandedpnlaccounts ORDER BY ExpandedAccountDesc ASC", "N/A");

            loadBusinessCategory();

            if (addViewEdit == "View" || addViewEdit == "Edit")
            {
                numtxtGLSLCode.Enabled = false;
                loadDetails();

                if (addViewEdit == "View")
                {
                    btnSave.Enabled = false;
                }
                else if (addViewEdit == "Edit")
                {
                    lblWarning.Visible = true;
                }
            }

            // Preloader - Close
            loader.CloseSmall();
        }

        private void clearFields()
        {
            numtxtGLCode.Value = 0;
            txtGLAccount.Text = "";
            numtxtGLSLCode.Value = 0;
            txtGLSLAccount.Text = "";
            txtExpandedAccount.Text = "0";
            cboExpandedAccount.Text = "";

            toggleSelectAll.Checked = false;
            panelContainer_BusinessCategory.Controls.Clear();
        }

        private void loadBusinessCategory()
        {
            panelContainer_BusinessCategory.Controls.Clear(); // Clear the container first            

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.Category_Code, t1.Category_Name, t2.user_id FROM " +
                "(SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t1 " +
                "LEFT JOIN (SELECT user_id, category_code FROM tbl_users_credentials_business_units WHERE user_id="+ Global.userID + ") AS t2 ON t1.Category_Code=t2.category_code " +
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

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.Category_Code, t1.GLSL, t1.GL_Account, t1.GL, t1.SL_Account, t1.ExpandedAccounts, t1.ExpandedAccountDesc, t1.Status FROM " +
                "(SELECT ID, Category_Code, GLSL, GL_Account, GL, SL_Account, ExpandedAccounts, ExpandedAccountDesc, Status FROM tbl_chartofaccounts WHERE GLSL=" + zcaGLSL + ") AS t1 " +
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
                    numtxtGLCode.Value = Convert.ToInt32(Conns.mySqlDataReader["GL"].ToString());
                    txtGLAccount.Text = Conns.mySqlDataReader["GL_Account"].ToString();
                    numtxtGLSLCode.Value = Convert.ToInt32(Conns.mySqlDataReader["GLSL"].ToString());
                    txtGLSLAccount.Text = Conns.mySqlDataReader["SL_Account"].ToString();
                    txtExpandedAccount.Text = Conns.mySqlDataReader["ExpandedAccounts"].ToString();
                    cboExpandedAccount.Text = Conns.mySqlDataReader["ExpandedAccountDesc"].ToString();

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
                                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT Category_Code, GLSL, Status FROM tbl_transaction WHERE Category_Code='"+ userControl_BusinessCategoryCode + "' AND GLSL=" + numtxtGLSLCode.Value + " AND Status='Active' LIMIT 1;");
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

        private void toggleSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void toggleSelectAll_Click(object sender, EventArgs e)
        {
            toggleOptionsOnOff(panelContainer_BusinessCategory, toggleSelectAll);
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

        private void cboExpandedAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpandedAccount.Text = classGlobalFunctions.getComboBoxDetails("ExpandedAccounts", "SELECT ExpandedAccounts FROM tbl_expandedpnlaccounts WHERE ExpandedAccountDesc='" + cboExpandedAccount.Text.Trim() + "' LIMIT 1");
        }

        private void numtxtGLSLCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //numtxtGLCode.Value = Convert.ToInt32(numtxtGLSLCode.Value.ToString().Substring(0, 3));
                numtxtGLCode.Value = numtxtGLSLCode.Value;
                if (numtxtGLCode.Value.ToString().Length > 3)
                {
                    numtxtGLCode.Value = Convert.ToInt32(numtxtGLCode.Value.ToString().Substring(0, 3));
                }
            }
            catch
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (numtxtGLCode.Value == 0)
            {
                new classMsgBox().showMsgError("Please input GL code!");
                Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (numtxtGLSLCode.Value == 0)
            {
                new classMsgBox().showMsgError("Please input GLSL code!");
                Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtGLAccount.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input GL Account!");
                Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtGLSLAccount.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input GLSL Account!");
                Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_chartofaccounts WHERE GLSL=" + numtxtGLSLCode.Value + " LIMIT 1;");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The GLSL Code already exists in the database!");
                    Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }

                recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_chartofaccounts WHERE SL_Account='" + txtGLSLAccount.Text.Trim() + "' LIMIT 1;");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The GLSL Account already exists in the database!");
                    Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front                 
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
                Application.OpenForms["frmSettings_ChartOfAccounts_New"].Activate(); // Bring the parent form to the front 
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                String timeStamp = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToShortTimeString();

                if (addViewEdit == "Add")
                {                    
                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                    for (var i = panelContainer_BusinessCategory.Controls.Count - 1; i >= 0; i--)
                    {
                        if (panelContainer_BusinessCategory.Controls[i] is ucSettings_SelectionItems_BusinessCategory)
                        {
                            ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer_BusinessCategory.Controls[i] as ucSettings_SelectionItems_BusinessCategory;

                            if (ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked == true)
                            {
                                Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_chartofaccounts(Category_Code, GLSL, GL_Account, GL, SL_Account, ExpandedAccounts, ExpandedAccountDesc, Added_By, Added_Date, Status, Remarks) " +
                                    "VALUES (@Category_Code, @GLSL, @GL_Account, @GL, @SL_Account, @ExpandedAccounts, @ExpandedAccountDesc, @Added_By, @Added_Date, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                                Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                Conns2.mySqlCmd.Parameters.AddWithValue("GLSL", numtxtGLSLCode.Value);
                                Conns2.mySqlCmd.Parameters.AddWithValue("GL_Account", txtGLAccount.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("GL", numtxtGLCode.Value);
                                Conns2.mySqlCmd.Parameters.AddWithValue("SL_Account", txtGLSLAccount.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccounts", txtExpandedAccount.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccountDesc", cboExpandedAccount.Text.Trim());  
                                Conns2.mySqlCmd.Parameters.AddWithValue("Added_By", Global.displayName);
                                Conns2.mySqlCmd.Parameters.AddWithValue("Added_Date", timeStamp);
                                Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                                Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                Conns2.mySqlDataReader.Close();
                            }
                        }
                    }
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    
                    new classMsgBox().showMsgSuccessful("Record has been saved");
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
                                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_chartofaccounts SET GL_Account=@GL_Account, SL_Account=@SL_Account, ExpandedAccounts=@ExpandedAccounts, ExpandedAccountDesc=@ExpandedAccountDesc, Edited_By=@Edited_By, Edited_Date=@Edited_Date, Status=@Status WHERE Category_Code=@Category_Code AND GLSL=@GLSL;", Conns2.mySqlconn);     // Create a query command                    
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GLSL", numtxtGLSLCode.Value);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GL_Account", txtGLAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("SL_Account", txtGLSLAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccounts", txtExpandedAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccountDesc", cboExpandedAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Edited_By", Global.displayName);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Edited_Date", timeStamp);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                    Conns2.mySqlDataReader.Close();
                                }
                                else
                                {
                                    // Update the existing record
                                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_chartofaccounts SET GL_Account=@GL_Account, SL_Account=@SL_Account, ExpandedAccounts=@ExpandedAccounts, ExpandedAccountDesc=@ExpandedAccountDesc, Deleted_By=@Deleted_By, Deleted_Date=@Deleted_Date, Status=@Status WHERE Category_Code=@Category_Code AND GLSL=@GLSL;", Conns2.mySqlconn);     // Create a query command                    
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GLSL", numtxtGLSLCode.Value);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GL_Account", txtGLAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("SL_Account", txtGLSLAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccounts", txtExpandedAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccountDesc", cboExpandedAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Deleted_By", Global.displayName);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Deleted_Date", timeStamp);
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
                                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_chartofaccounts(Category_Code, GLSL, GL_Account, GL, SL_Account, ExpandedAccounts, ExpandedAccountDesc, Added_By, Added_Date, Status, Remarks) " +
                                    "VALUES (@Category_Code, @GLSL, @GL_Account, @GL, @SL_Account, @ExpandedAccounts, @ExpandedAccountDesc, @Added_By, @Added_Date, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GLSL", numtxtGLSLCode.Value);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GL_Account", txtGLAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("GL", numtxtGLCode.Value);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("SL_Account", txtGLSLAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccounts", txtExpandedAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccountDesc", cboExpandedAccount.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Added_By", Global.displayName);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Added_Date", timeStamp);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                    Conns2.mySqlDataReader.Close();
                                }
                            }
                        }
                    }
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database

                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_ChartOfAccounts ucSettings_ChartOfAccounts = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_ChartOfAccounts;
                ucSettings_ChartOfAccounts.loadChartOfAccounts();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
