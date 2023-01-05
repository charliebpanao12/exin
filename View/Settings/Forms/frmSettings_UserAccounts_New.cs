using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_UserAccounts_New : Form
    {
        public static String addViewEdit;
        public static int userID;
        public static string userName;
        public static string userDisplayName;

        public frmSettings_UserAccounts_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtUserID.BorderColor = Global.themeColor1;
            txtUserID.FocusedState.BorderColor = Global.themeColor2;
            txtUserID.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtUserName.BorderColor = Global.themeColor1;
            txtUserName.FocusedState.BorderColor = Global.themeColor2;
            txtUserName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtPassword.BorderColor = Global.themeColor1;
            txtPassword.FocusedState.BorderColor = Global.themeColor2;
            txtPassword.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtFirstName.BorderColor = Global.themeColor1;
            txtFirstName.FocusedState.BorderColor = Global.themeColor2;
            txtFirstName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtLastName.BorderColor = Global.themeColor1;
            txtLastName.FocusedState.BorderColor = Global.themeColor2;
            txtLastName.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboUserRole.BorderColor = Global.themeColor1;
            cboUserRole.FocusedState.BorderColor = Global.themeColor2;
            cboUserRole.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtNotes.BorderColor = Global.themeColor1;
            txtNotes.FocusedState.BorderColor = Global.themeColor2;
            txtNotes.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_UserAccounts_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            if (Global.userLevel == "EXIN Developer")
            {
                // Load the ComboBox items
                classGlobalFunctions.loadComboBoxItems(cboUserRole, "User_Role", "SELECT DISTINCT User_Role FROM tbl_users WHERE Status='Active' ORDER BY User_Role ASC", "Others");
            }
            else if (Global.userLevel == "EXIN Support")
            {
                // Load the ComboBox items
                classGlobalFunctions.loadComboBoxItems(cboUserRole, "User_Role", "SELECT DISTINCT User_Role FROM tbl_users WHERE User_Role<>'EXIN Developer' AND Status='Active' ORDER BY User_Role ASC", "Others");
            }
            else
            {
                // Load the ComboBox items
                classGlobalFunctions.loadComboBoxItems(cboUserRole, "User_Role", "SELECT DISTINCT User_Role FROM tbl_users WHERE (User_Role<>'EXIN Developer' AND User_Role<>'EXIN Support') AND Status='Active' ORDER BY User_Role ASC", "Others");
            }


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
            txtUserID.Text = "Automatic";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cboUserRole.Text = "";
            txtNotes.Text = "";
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE User_ID=" + userID + " LIMIT 1;", Conns.mySqlconn);     // Create a query command
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
                    txtUserID.Text = Conns.mySqlDataReader["User_ID"].ToString();
                    txtUserName.Text = Conns.mySqlDataReader["User_Name"].ToString();
                    txtPassword.Text = Conns.mySqlDataReader["User_Password"].ToString();
                    txtFirstName.Text = Conns.mySqlDataReader["First_Name"].ToString();
                    txtLastName.Text = Conns.mySqlDataReader["Last_Name"].ToString();
                    cboUserRole.Text = Conns.mySqlDataReader["User_Role"].ToString();
                    txtNotes.Text = Conns.mySqlDataReader["Notes"].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtUserName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input user name");
                Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtPassword.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input user password");
                Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtFirstName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input first name");
                Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtLastName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input last name");
                Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (cboUserRole.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input user role");
                Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (cboUserRole2.Visible == true)
            {
                if (cboUserRole2.Text.Trim() == "")
                {
                    new classMsgBox().showMsgError("Please input user role");
                    Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                    return;
                }
            }

            // Validate the user role - New user account must not receive a role of 'EXIN Developer' or 'EXIN Support' if the logged user is not an EXIN Developer or an EXIN Support
            if (Global.userLevel != "EXIN Developer" && Global.userLevel != "EXIN Support")
            {
                if (cboUserRole2.Text.Trim() == "EXIN Developer" || cboUserRole2.Text.Trim() == "EXIN Support")
                {
                    new classMsgBox().showMsgError("Please input another user role");
                    Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                    return;
                }
            }
            else if (Global.userLevel != "EXIN Developer")
            {
                if (cboUserRole2.Text.Trim() == "EXIN Developer")
                {
                    new classMsgBox().showMsgError("Please input another user role");
                    Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front  
                    return;
                }
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_users WHERE User_Name='" + txtUserName.Text.Trim() + "' AND Status='Active';");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The user name is not available!");
                    Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }

                recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_users WHERE CONCAT(First_Name, ' ', Last_Name)='" + txtFirstName.Text.Trim() + ' ' + txtLastName.Text.Trim() + "' AND Status='Active';");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The name " + txtFirstName.Text.Trim() + ' ' + txtLastName.Text.Trim() + " already exists!");
                    Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (userName != "" + txtUserName.Text.Trim()) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_users WHERE User_Name='" + txtUserName.Text.Trim() + "' AND Status='Active';");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The user name is not available!");
                        Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front                 
                        return;
                    }
                }

                if (userDisplayName != txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim()) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_users WHERE CONCAT(First_Name, ' ', Last_Name)='" + txtFirstName.Text.Trim() + ' ' + txtLastName.Text.Trim() + "' AND Status='Active';");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The name " + txtFirstName.Text.Trim() + ' ' + txtLastName.Text.Trim() + " already exists!");
                        Application.OpenForms["frmSettings_UserAccounts_New"].Activate(); // Bring the parent form to the front                 
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
                    // Generate New User ID
                    userID = classGlobalFunctions.generateNewID(70001, "User_ID", "SELECT User_ID FROM tbl_users ORDER BY User_ID DESC LIMIT 1;");

                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_users(User_ID, User_Name, User_Password, First_Name, Last_Name, User_Role, Notes, Status, Remarks, preference_theme_style, preference_theme_color_1, preference_theme_color_2, preference_theme_color_3, preference_theme_color_4) " +
                        "VALUES (@User_ID, @User_Name, @User_Password, @First_Name, @Last_Name, @User_Role, @Notes, @Status, @Remarks, @preference_theme_style, @preference_theme_color_1, @preference_theme_color_2, @preference_theme_color_3, @preference_theme_color_4);", Conns2.mySqlconn);     // Create a query command                    
                    Conns2.mySqlCmd.Parameters.AddWithValue("User_ID", userID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("User_Name", txtUserName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("User_Password", txtPassword.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("First_Name", txtFirstName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Last_Name", txtLastName.Text.Trim());
                    if (cboUserRole2.Visible == true)
                    {
                        Conns2.mySqlCmd.Parameters.AddWithValue("User_Role", cboUserRole2.Text.Trim());
                    }
                    else
                    {
                        Conns2.mySqlCmd.Parameters.AddWithValue("User_Role", cboUserRole.Text.Trim());
                    }
                    Conns2.mySqlCmd.Parameters.AddWithValue("Notes", txtNotes.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                    Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                    Conns2.mySqlCmd.Parameters.AddWithValue("preference_theme_style", "Theme 1");
                    Conns2.mySqlCmd.Parameters.AddWithValue("preference_theme_color_1", "25, 100, 80");
                    Conns2.mySqlCmd.Parameters.AddWithValue("preference_theme_color_2", "32, 197, 183");
                    Conns2.mySqlCmd.Parameters.AddWithValue("preference_theme_color_3", "24, 151, 143");
                    Conns2.mySqlCmd.Parameters.AddWithValue("preference_theme_color_4", "84, 186, 185");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been saved");
                }
                else if (addViewEdit == "Edit")
                {
                    // Update the existing records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_users SET User_Name=@User_Name, User_Password=@User_Password, First_Name=@First_Name, Last_Name=@Last_Name, User_Role=@User_Role, Notes=@Notes WHERE User_ID=@User_ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("User_ID", userID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("User_Name", txtUserName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("User_Password", txtPassword.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("First_Name", txtFirstName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Last_Name", txtLastName.Text.Trim());
                    if (cboUserRole2.Visible == true)
                    {
                        Conns2.mySqlCmd.Parameters.AddWithValue("User_Role", cboUserRole2.Text.Trim());
                    }
                    else
                    {
                        Conns2.mySqlCmd.Parameters.AddWithValue("User_Role", cboUserRole.Text.Trim());
                    }
                    Conns2.mySqlCmd.Parameters.AddWithValue("Notes", txtNotes.Text.Trim());
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_UserAccounts ucSettings_UserAccounts = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_UserAccounts;
                ucSettings_UserAccounts.loadUserAccounts();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cboUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUserRole.Text == "<< Others >>")
            {
                cboUserRole2.Visible = true;
                cboUserRole2.Text = "";
            }
            else
            {
                cboUserRole2.Visible = false;
                cboUserRole2.Text = "";
            }
        }
    }
}
