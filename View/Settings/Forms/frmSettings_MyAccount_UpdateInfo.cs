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
    public partial class frmSettings_MyAccount_UpdateInfo : Form
    {
        public static int userID;

        public frmSettings_MyAccount_UpdateInfo()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCurrentPassword.BorderColor = Global.themeColor1;
            txtCurrentPassword.FocusedState.BorderColor = Global.themeColor2;
            txtCurrentPassword.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtNewPassword.BorderColor = Global.themeColor1;
            txtNewPassword.FocusedState.BorderColor = Global.themeColor2;
            txtNewPassword.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_MyAccount_UpdateInfo_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtCurrentPassword.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input current password");
                Application.OpenForms["frmSettings_MyAccount_UpdateInfo"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtNewPassword.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input new password");
                Application.OpenForms["frmSettings_MyAccount_UpdateInfo"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate current password
            Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_users WHERE User_ID=" + userID + " AND User_Password='"+ txtCurrentPassword.Text.Trim() +"';");
            if (recordExist != true)
            {
                new classMsgBox().showMsgError("Current password is incorrect!");
                Application.OpenForms["frmSettings_MyAccount_UpdateInfo"].Activate(); // Bring the parent form to the front                 
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                // Update the existing records
                MySqlConnect Conns = new MySqlConnect();    // Connect to the database 
                Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_users SET User_Password=@User_Password WHERE User_ID=@User_ID;", Conns.mySqlconn);     // Create a query command
                Conns.mySqlCmd.Parameters.AddWithValue("User_ID", userID);
                Conns.mySqlCmd.Parameters.AddWithValue("User_Password", txtNewPassword.Text.Trim());
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                Conns.closeConnection();    // !Important ->> Close the connection from the database
                new classMsgBox().showMsgSuccessful("Record has been updated");

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_MyAccount ucSettings_MyAccount = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_MyAccount;
                ucSettings_MyAccount.loadAccountDetails();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
