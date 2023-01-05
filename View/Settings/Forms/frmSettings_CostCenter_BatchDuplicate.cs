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
    public partial class frmSettings_CostCenter_BatchDuplicate : Form
    {
        public frmSettings_CostCenter_BatchDuplicate()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtBusinessCategoryCode_From.BorderColor = Global.themeColor1;
            txtBusinessCategoryCode_From.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessCategoryCode_From.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboBusinessCategory_From.BorderColor = Global.themeColor1;
            cboBusinessCategory_From.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessCategory_From.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtBusinessCategoryCode_To.BorderColor = Global.themeColor1;
            txtBusinessCategoryCode_To.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessCategoryCode_To.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboBusinessCategory_To.BorderColor = Global.themeColor1;
            cboBusinessCategory_To.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessCategory_To.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_CostCenter_BatchDuplicate_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();

            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory_From, "Category_Name", "SELECT t1.category_code, t2.Category_Name FROM " +
                "(SELECT category_code FROM tbl_users_credentials_business_units WHERE user_id=" + Global.userID + ") AS t1 " +
                "LEFT JOIN (SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t2 ON t1.category_code=t2.Category_Code " +
                "GROUP BY t2.Category_Name ORDER BY t2.Category_Name ASC;", "Blank");
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory_To, "Category_Name", "SELECT t1.category_code, t2.Category_Name FROM " +
                "(SELECT category_code FROM tbl_users_credentials_business_units WHERE user_id=" + Global.userID + ") AS t1 " +
                "LEFT JOIN (SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t2 ON t1.category_code=t2.Category_Code " +
                "GROUP BY t2.Category_Name ORDER BY t2.Category_Name ASC;", "Blank");
        }

        private void clearFields()
        {
            txtBusinessCategoryCode_From.Text = "";
            cboBusinessCategory_From.Text = "";
            txtBusinessCategoryCode_To.Text = "";
            cboBusinessCategory_To.Text = "";
        }

        private void cboBusinessCategory_From_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusinessCategoryCode_From.Text = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory_From.Text + "' AND Status='Active' LIMIT 1");
        }

        private void cboBusinessCategory_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusinessCategoryCode_To.Text = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory_To.Text + "' AND Status='Active' LIMIT 1");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtBusinessCategoryCode_From.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select an item from the dropdown!");
                Application.OpenForms["frmSettings_CostCenter_BatchDuplicate"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtBusinessCategoryCode_To.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select an item from the dropdown!");
                Application.OpenForms["frmSettings_CostCenter_BatchDuplicate"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtBusinessCategoryCode_From.Text.Trim() == txtBusinessCategoryCode_To.Text.Trim())
            {
                new classMsgBox().showMsgError("Selected items must not be equal!");
                Application.OpenForms["frmSettings_CostCenter_BatchDuplicate"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the source for duplicating records is not empty
            Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_costcenter WHERE Category_Code='" + txtBusinessCategoryCode_From.Text.Trim() + "' LIMIT 1;");
            if (recordExist == false)
            {
                new classMsgBox().showMsgError("The source business category must contain record(s) before you can proceed!");
                Application.OpenForms["frmSettings_CostCenter_BatchDuplicate"].Activate(); // Bring the parent form to the front                 
                return;
            }

            // Validate if the target business category contains any record
            recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_costcenter WHERE Category_Code='" + txtBusinessCategoryCode_To.Text.Trim() + "' LIMIT 1;");
            if (recordExist == true)
            {
                new classMsgBox().showMsgError("The target business category must not contain any record before you can proceed!");
                Application.OpenForms["frmSettings_CostCenter_BatchDuplicate"].Activate(); // Bring the parent form to the front                 
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                // Preloader - Ready
                var loader = new WaitFormFunc();
                loader.ShowSmall(); // Preloader - Start 

                Application.OpenForms["frmSettings_CostCenter_BatchDuplicate"].Activate(); // Bring the parent form to the front

                String timeStamp = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToShortTimeString();

                // Get the records first from the database before duplicating to the target business category
                MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_costcenter WHERE Category_Code='" + txtBusinessCategoryCode_From.Text.Trim() + "'", Conns.mySqlconn);     // Create a query command
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

                DataTable mySqlDataTable = new DataTable(); // Create Data Table
                mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
                int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

                if (numRows > 0)
                {
                    int i = 1;
                    Conns.mySqlDataReader.Close();  // Close the Data Reader
                    Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database
                    while (Conns.mySqlDataReader.Read())    // Get the records
                    {
                        // Insert new record
                        Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_costcenter(Category_Code, CostCenter_Code, CostCenter_Name, CostCenter_Notes, Status, Remarks) " +
                        "VALUES (@Category_Code, @CostCenter_Code, @CostCenter_Name, @CostCenter_Notes, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                        Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtBusinessCategoryCode_To.Text.Trim());
                        Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Code", Conns.mySqlDataReader["CostCenter_Code"].ToString());
                        Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Name", Conns.mySqlDataReader["CostCenter_Name"].ToString());
                        Conns2.mySqlCmd.Parameters.AddWithValue("CostCenter_Notes", Conns.mySqlDataReader["CostCenter_Notes"].ToString());
                        Conns2.mySqlCmd.Parameters.AddWithValue("Status", Conns.mySqlDataReader["Status"].ToString());
                        Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", Conns.mySqlDataReader["Remarks"].ToString());
                        Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns2.mySqlDataReader.Close();

                        i++;
                    }
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                Conns.closeConnection();    // !Important ->> Close the connection from the database

                // Preloader - Close
                loader.CloseSmall();

                new classMsgBox().showMsgSuccessful("Record has been saved");

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
