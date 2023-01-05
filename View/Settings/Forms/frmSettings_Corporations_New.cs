using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_Corporations_New : Form
    {
        public static String addViewEdit;
        public static int corpID;
        public static int corpCode;
        public static String corpName;

        public frmSettings_Corporations_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtCorpCode.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtCorpName.BorderColor = Global.themeColor1;
            txtCorpName.FocusedState.BorderColor = Global.themeColor2;
            txtCorpName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtAddress.BorderColor = Global.themeColor1;
            txtAddress.FocusedState.BorderColor = Global.themeColor2;
            txtAddress.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtTIN.BorderColor = Global.themeColor1;
            txtTIN.FocusedState.BorderColor = Global.themeColor2;
            txtTIN.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        public void frmSettings_Corporations_New_Load(object sender, EventArgs e)
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
            numtxtCorpCode.Value = 0;
            txtCorpName.Text = "";
            txtAddress.Text = "";
            txtTIN.Text = "";
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_corporations WHERE ID=" + corpID + ";", Conns.mySqlconn);     // Create a query command
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
                    corpCode = Convert.ToInt32(Conns.mySqlDataReader["Corp_Code"].ToString());
                    corpName = Conns.mySqlDataReader["Corp_Name"].ToString();
                    numtxtCorpCode.Value = Convert.ToInt32(Conns.mySqlDataReader["Corp_Code"].ToString());
                    txtCorpName.Text = Conns.mySqlDataReader["Corp_Name"].ToString();
                    txtAddress.Text = Conns.mySqlDataReader["Corp_Address"].ToString();
                    txtTIN.Text = Conns.mySqlDataReader["Corp_TIN"].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (numtxtCorpCode.Value == 0)
            {
                new classMsgBox().showMsgError("Please input corporation code");
                Application.OpenForms["frmSettings_Corporations_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtCorpName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input corporation name");
                Application.OpenForms["frmSettings_Corporations_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_corporations WHERE Corp_Code=" + numtxtCorpCode.Value + " AND Status='Active';");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The corporation code already exists in the database");
                    Application.OpenForms["frmSettings_Corporations_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
                Boolean recordExist2 = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_corporations WHERE Corp_Name='" + txtCorpName.Text.Trim() + "' AND Status='Active';");
                if (recordExist2 == true)
                {
                    new classMsgBox().showMsgError("The corporation name already exists in the database");
                    Application.OpenForms["frmSettings_Corporations_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (corpCode != numtxtCorpCode.Value) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_corporations WHERE Corp_Code=" + numtxtCorpCode.Value + " AND Status='Active';");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The corporation code already exists in the database");
                        Application.OpenForms["frmSettings_Corporations_New"].Activate(); // Bring the parent form to the front                 
                        return;
                    }
                }
                if (corpName != txtCorpName.Text.Trim()) // Validate if the main information has been edited
                {
                    Boolean recordExist2 = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_corporations WHERE Corp_Name='" + txtCorpName.Text.Trim() + "' AND Status='Active';");
                    if (recordExist2 == true)
                    {
                        new classMsgBox().showMsgError("The corporation name already exists in the database");
                        Application.OpenForms["frmSettings_Corporations_New"].Activate(); // Bring the parent form to the front                 
                        return;
                    }
                }
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                if (addViewEdit == "Add")
                {
                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_corporations(Corp_Code, Corp_Name, Corp_Address, Corp_TIN, Status, Remarks) " +
                        "VALUES (@Corp_Code, @Corp_Name, @Corp_Address, @Corp_TIN, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Code", numtxtCorpCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Name", txtCorpName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Address", txtAddress.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_TIN", txtTIN.Text.Trim());
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
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_corporations SET Corp_Code=@Corp_Code, Corp_Name=@Corp_Name, Corp_Address=@Corp_Address, Corp_TIN=@Corp_TIN WHERE ID=@ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("ID", corpID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Code", numtxtCorpCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Name", txtCorpName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Address", txtAddress.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_TIN", txtTIN.Text.Trim());
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_Corporations ucSettings_Corporations = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_Corporations;
                ucSettings_Corporations.loadCorporations();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
