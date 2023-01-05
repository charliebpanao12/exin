using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_BusinessCategory_New : Form
    {
        public static String addViewEdit;
        public static int businessCategoryID;
        public static String businessCategoryCode;
        public static String businessCategoryName;

        public frmSettings_BusinessCategory_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCategoryCode.BorderColor = Global.themeColor1;
            txtCategoryCode.FocusedState.BorderColor = Global.themeColor2;
            txtCategoryCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCategoryName.BorderColor = Global.themeColor1;
            txtCategoryName.FocusedState.BorderColor = Global.themeColor2;
            txtCategoryName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtDescription.BorderColor = Global.themeColor1;
            txtDescription.FocusedState.BorderColor = Global.themeColor2;
            txtDescription.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtPrintColor1.BorderColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numtxtPrintColor2.BorderColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numtxtPrintColor3.BorderColor = Global.themeColor1;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        public void frmSettings_BusinessCategory_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            if (addViewEdit == "View" || addViewEdit == "Edit")
            {
                loadDetails();
                if (addViewEdit == "View")
                {
                    btnSave.Enabled = false;
                }
            }
        }

        private void clearFields()
        {
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
            numtxtPrintColor1.Value = 0;
            numtxtPrintColor2.Value = 0;
            numtxtPrintColor3.Value = 0;
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_category WHERE ID=" + businessCategoryID + ";", Conns.mySqlconn);     // Create a query command
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
                    businessCategoryCode = Conns.mySqlDataReader["Category_Code"].ToString();
                    businessCategoryName = Conns.mySqlDataReader["Category_Name"].ToString();
                    txtCategoryCode.Text = Conns.mySqlDataReader["Category_Code"].ToString();
                    txtCategoryName.Text = Conns.mySqlDataReader["Category_Name"].ToString();
                    txtDescription.Text = Conns.mySqlDataReader["Category_Description"].ToString();
                    numtxtPrintColor1.Value = Convert.ToInt32(Conns.mySqlDataReader["Print_Color1"].ToString());
                    numtxtPrintColor2.Value = Convert.ToInt32(Conns.mySqlDataReader["Print_Color2"].ToString());
                    numtxtPrintColor3.Value = Convert.ToInt32(Conns.mySqlDataReader["Print_Color3"].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtCategoryCode.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input business category code");
                Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtCategoryName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input business category name");
                Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_category WHERE Category_Code='" + txtCategoryCode.Text.Trim() + "' AND Status='Active';");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The business category code already exists in the database");
                    Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
                Boolean recordExist2 = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_category WHERE Category_Name='" + txtCategoryName.Text.Trim() + "' AND Status='Active';");
                if (recordExist2 == true)
                {
                    new classMsgBox().showMsgError("The business category name already exists in the database");
                    Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (businessCategoryCode != txtCategoryCode.Text.Trim()) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_category WHERE Category_Code='" + txtCategoryCode.Text.Trim() + "' AND Status='Active';");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The business category code already exists in the database");
                        Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front                 
                        return;
                    }
                }
                if (businessCategoryName != txtCategoryName.Text.Trim()) // Validate if the main information has been edited
                {
                    Boolean recordExist2 = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_category WHERE Category_Name='" + txtCategoryName.Text.Trim() + "' AND Status='Active';");
                    if (recordExist2 == true)
                    {
                        new classMsgBox().showMsgError("The business category name already exists in the database");
                        Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front                 
                        return;
                    }
                }
            }

            // Validate if the record already exists
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_category WHERE Category_Code='" + txtCategoryCode.Text.Trim() + "' OR Category_Name='" + txtCategoryName.Text.Trim() + "' AND Status='Active';", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader
            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found
            if (addViewEdit == "Add")
            {
                if (numRows > 0)
                {
                    Conns.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgError("The business category code or name already exists in the database");
                    Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (numRows > 1)
                {
                    Conns.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgError("The business category code or name already exists in the database");
                    Application.OpenForms["frmSettings_BusinessCategory_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                if (addViewEdit == "Add")
                {
                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_category(Category_Code, Category_Name, Category_Description, Print_Color1, Print_Color2, Print_Color3, Status, Remarks) " +
                        "VALUES (@Category_Code, @Category_Name, @Category_Description, @Print_Color1, @Print_Color2, @Print_Color3, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtCategoryCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Name", txtCategoryName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Description", txtDescription.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Print_Color1", numtxtPrintColor1.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Print_Color2", numtxtPrintColor2.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Print_Color3", numtxtPrintColor3.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                    Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been saved");
                }
                else if (addViewEdit == "Edit")
                {
                    // Update the existing records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_category SET Category_Code=@Category_Code, Category_Name=@Category_Name, Category_Description=@Category_Description, Print_Color1=@Print_Color1, Print_Color2=@Print_Color2, Print_Color3=@Print_Color3 WHERE ID=@ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("ID", businessCategoryID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtCategoryCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Name", txtCategoryName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Description", txtDescription.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Print_Color1", numtxtPrintColor1.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Print_Color2", numtxtPrintColor2.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Print_Color3", numtxtPrintColor3.Value);
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_BusinessCategories ucSettings_BusinessCategories = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_BusinessCategories;
                ucSettings_BusinessCategories.loadBusinessCategories();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
