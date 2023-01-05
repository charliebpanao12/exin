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
    public partial class frmSettings_CostCenter_New : Form
    {
        public static String addViewEdit;
        public static int costCenterID;
        public static int costCenterCode;
        public static String costCenterName;

        public frmSettings_CostCenter_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCostCenterCode.BorderColor = Global.themeColor1;
            txtCostCenterCode.FocusedState.BorderColor = Global.themeColor2;
            txtCostCenterCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCostCenterName.BorderColor = Global.themeColor1;
            txtCostCenterName.FocusedState.BorderColor = Global.themeColor2;
            txtCostCenterName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtNotes.BorderColor = Global.themeColor1;
            txtNotes.FocusedState.BorderColor = Global.themeColor2;
            txtNotes.HoverState.BorderColor = Global.themeColor2;

            // Controls - Toggle Switch
            toggleSelectAll.CheckedState.FillColor = Global.themeColor1;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_CostCenter_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            // Preloader - Ready
            var loader = new WaitFormFunc();
            loader.ShowSmall(); // Preloader - Start

            loadBusinessCategory();

            if (addViewEdit == "View" || addViewEdit == "Edit")
            {
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
            txtCostCenterCode.Text = "Automatic";
            txtCostCenterName.Text = "";
            txtNotes.Text = "";

            toggleSelectAll.Checked = false;
            panelContainer_BusinessCategory.Controls.Clear();
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

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.Category_Code, t1.CostCenter_Code, t1.CostCenter_Name, t1.CostCenter_Notes, t1.Status FROM " +
                "(SELECT ID, Category_Code, CostCenter_Code, CostCenter_Name, CostCenter_Notes, Status FROM tbl_costcenter WHERE CostCenter_Code=" + costCenterCode + ") AS t1 " +
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
                    txtCostCenterCode.Text = Conns.mySqlDataReader["CostCenter_Code"].ToString();
                    txtCostCenterName.Text = Conns.mySqlDataReader["CostCenter_Name"].ToString();
                    txtNotes.Text = Conns.mySqlDataReader["CostCenter_Notes"].ToString();

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
                                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT Category_Code, CostCenter_Code, Status FROM tbl_transaction WHERE Category_Code='" + userControl_BusinessCategoryCode + "' AND CostCenter_Code=" + Convert.ToInt32(txtCostCenterCode.Text.Trim()) + " AND Status='Active' LIMIT 1;");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtCostCenterName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input cost center name!");
                Application.OpenForms["frmSettings_CostCenter_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_costcenter WHERE CostCenter_Name='" + txtCostCenterName.Text.Trim() + "' LIMIT 1;");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The cost center name already exists in the database!");
                    Application.OpenForms["frmSettings_CostCenter_New"].Activate(); // Bring the parent form to the front                 
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
                Application.OpenForms["frmSettings_CostCenter_New"].Activate(); // Bring the parent form to the front 
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
                    txtCostCenterCode.Text = classGlobalFunctions.generateNewID(80001, "CostCenter_Code", "SELECT CostCenter_Code FROM tbl_costcenter ORDER BY CostCenter_Code DESC LIMIT 1;").ToString();

                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                    for (var i = panelContainer_BusinessCategory.Controls.Count - 1; i >= 0; i--)
                    {
                        if (panelContainer_BusinessCategory.Controls[i] is ucSettings_SelectionItems_BusinessCategory)
                        {
                            ucSettings_SelectionItems_BusinessCategory ucSettings_SelectionItems_BusinessCategory = panelContainer_BusinessCategory.Controls[i] as ucSettings_SelectionItems_BusinessCategory;

                            if (ucSettings_SelectionItems_BusinessCategory.toggleControl.Checked == true)
                            {
                                Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_costcenter(Category_Code, CostCenter_Code, CostCenter_Name, CostCenter_Notes, Status, Remarks) " +
                                    "VALUES (@Category_Code, @CostCenter_Code, @CostCenter_Name, @CostCenter_Notes, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                                Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Code", txtCostCenterCode.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Name", txtCostCenterName.Text.Trim());
                                Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Notes", txtNotes.Text.Trim());
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
                                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_costcenter SET CostCenter_Name=@CostCenter_Name, CostCenter_Notes=@CostCenter_Notes, Status=@Status WHERE Category_Code=@Category_Code AND CostCenter_Code=@CostCenter_Code;", Conns2.mySqlconn);     // Create a query command
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Code", txtCostCenterCode.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Name", txtCostCenterName.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Notes", txtNotes.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                                    Conns2.mySqlDataReader.Close();
                                }
                                else
                                {
                                    // Update the existing record
                                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_costcenter SET CostCenter_Name=@CostCenter_Name, CostCenter_Notes=@CostCenter_Notes, Status=@Status WHERE Category_Code=@Category_Code AND CostCenter_Code=@CostCenter_Code;", Conns2.mySqlconn);     // Create a query command
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Code", txtCostCenterCode.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Name", txtCostCenterName.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Notes", txtNotes.Text.Trim());
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
                                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_costcenter(Category_Code, CostCenter_Code, CostCenter_Name, CostCenter_Notes, Status, Remarks) " +
                                    "VALUES (@Category_Code, @CostCenter_Code, @CostCenter_Name, @CostCenter_Notes, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", ucSettings_SelectionItems_BusinessCategory.categoryCode);
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Code", txtCostCenterCode.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Name", txtCostCenterName.Text.Trim());
                                    Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Notes", txtNotes.Text.Trim());
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
                ucSettings_CostCenter ucSettings_CostCenter = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_CostCenter;
                ucSettings_CostCenter.loadCostCenterList();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
