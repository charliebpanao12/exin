using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Data;
using EXIN.Controller;

namespace EXIN.Settings
{
    public partial class ucSettings_MyAccount : UserControl
    {
        public ucSettings_MyAccount()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
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
            txtUserRole.BorderColor = Global.themeColor1;
            txtUserRole.FocusedState.BorderColor = Global.themeColor2;
            txtUserRole.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 1
            btnSave.FillColor = Global.themeColor1;
            btnSave.HoverState.FillColor = Global.themeColor2;
            btnSave.HoverState.ForeColor = Global.themeForeColor;
        }

        private void ucSettings_MyAccount_Load(object sender, EventArgs e)
        {
            loadAccountDetails();
        }

        public void loadAccountDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE User_ID=" + Global.userID + " LIMIT 1;", Conns.mySqlconn);     // Create a query command
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
                    txtUserRole.Text = Conns.mySqlDataReader["User_Role"].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "My Account", "Update Password") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSettings_MyAccount_UpdateInfo frmSettings_MyAccount_UpdateInfo = new frmSettings_MyAccount_UpdateInfo();
            frmSettings_MyAccount_UpdateInfo.userID = Global.userID;
            frmSettings_MyAccount_UpdateInfo.ShowDialog();
        }
    }
}
