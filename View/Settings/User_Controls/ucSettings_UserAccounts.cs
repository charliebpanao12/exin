using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_UserAccounts : UserControl
    {
        public static int userID;
        public static string userName;
        public static String displayName;

        public ucSettings_UserAccounts()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox 3
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 1
            btnAdd.FillColor = Global.themeColor1;
            btnAdd.HoverState.FillColor = Global.themeColor2;
            btnAdd.HoverState.ForeColor = Global.themeForeColor;

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUserRole.BorderColor = Global.themeColor1;
            cboUserRole.FocusedState.BorderColor = Global.themeColor2;
            cboUserRole.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboRecordStatus.BorderColor = Global.themeColor1;
            cboRecordStatus.FocusedState.BorderColor = Global.themeColor2;
            cboRecordStatus.HoverState.BorderColor = Global.themeColor2;
            #endregion
        }

        private void ucSettings_UserAccounts_Load(object sender, EventArgs e)
        {
            if (Global.userLevel == "EXIN Developer")
            {
                // Load the ComboBox items
                classGlobalFunctions.loadComboBoxItems(cboUserRole, "User_Role", "SELECT DISTINCT User_Role FROM tbl_users WHERE Status='Active' ORDER BY User_Role ASC", "All");
            }
            else if (Global.userLevel == "EXIN Support")
            {
                // Load the ComboBox items
                classGlobalFunctions.loadComboBoxItems(cboUserRole, "User_Role", "SELECT DISTINCT User_Role FROM tbl_users WHERE User_Role<>'EXIN Developer' AND Status='Active' ORDER BY User_Role ASC", "All");
            }
            else
            {
                // Load the ComboBox items
                classGlobalFunctions.loadComboBoxItems(cboUserRole, "User_Role", "SELECT DISTINCT User_Role FROM tbl_users WHERE (User_Role<>'EXIN Developer' AND User_Role<>'EXIN Support') AND Status='Active' ORDER BY User_Role ASC", "All");
            }

            clearFields();
            loadUserAccounts();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            cboUserRole.Text = "All";
            cboRecordStatus.Text = "Active";
        }

        public void loadUserAccounts()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            userID = 0; // Reset the selected userID to zero

            String filterUserRole;
            String filterUserAccounts;
            String filterRecordStatus;

            filterUserRole = cboUserRole.Text.Trim();
            filterUserAccounts = txtSearch.Text.Trim();
            filterRecordStatus = cboRecordStatus.Text.Trim();

            if (cboUserRole.Text == "All")
            {
                filterUserRole = "";
            }

            Image CredentialsIcon = Image.FromFile("Resources/General/Datagrid_Images/credentials.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            if (Global.userLevel == "EXIN Developer")
            {
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE (User_ID LIKE '" + filterUserAccounts + "%' OR User_Name LIKE '" + filterUserAccounts + "%' OR First_Name LIKE '" + filterUserAccounts + "%' OR Last_Name LIKE '" + filterUserAccounts + "%') AND User_Role LIKE '" + filterUserRole + "%' AND Status LIKE '" + filterRecordStatus + "%' ORDER BY User_ID ASC;", Conns.mySqlconn);     // Create a query command
            }
            else if (Global.userLevel == "EXIN Support")
            {
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE (User_ID LIKE '" + filterUserAccounts + "%' OR User_Name LIKE '" + filterUserAccounts + "%' OR First_Name LIKE '" + filterUserAccounts + "%' OR Last_Name LIKE '" + filterUserAccounts + "%') AND User_Role LIKE '" + filterUserRole + "%' AND User_Role<>'EXIN Developer' AND Status LIKE '" + filterRecordStatus + "%' ORDER BY User_ID ASC;", Conns.mySqlconn);     // Create a query command
            }
            else
            {
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE (User_ID LIKE '" + filterUserAccounts + "%' OR User_Name LIKE '" + filterUserAccounts + "%' OR First_Name LIKE '" + filterUserAccounts + "%' OR Last_Name LIKE '" + filterUserAccounts + "%') AND User_Role LIKE '" + filterUserRole + "%' AND User_Role<>'EXIN Developer' AND User_Role<>'EXIN Support' AND Status LIKE '" + filterRecordStatus + "%' ORDER BY User_ID ASC;", Conns.mySqlconn);     // Create a query command
            }

            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader
            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            dgvRecords.Rows.Clear();    // Clear the records from datagrid
            lblNumRows.Text = "Count: " + numRows;

            if (numRows > 0)
            {
                if (numRows > 5)    // Preloader - Start 
                { loader.ShowSmall(); }

                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    dgvRecords.Rows.Add(Conns.mySqlDataReader["ID"].ToString(),
                        clCredentials.Image = CredentialsIcon,
                        cledit.Image = Deleteicon,
                        cldelete.Image = Editicon,
                        Conns.mySqlDataReader["User_ID"].ToString(),
                        Conns.mySqlDataReader["User_Name"].ToString(),
                        "•••",
                        Conns.mySqlDataReader["First_Name"].ToString(),
                        Conns.mySqlDataReader["Middle_Initial"].ToString(),
                        Conns.mySqlDataReader["Last_Name"].ToString(),
                        Conns.mySqlDataReader["User_Role"].ToString(),
                        Conns.mySqlDataReader["Notes"].ToString(),
                        Conns.mySqlDataReader["Status"].ToString());

                    i++;
                }
                //dgvRecords.AutoResizeColumns();
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Preloader - Close
            loader.CloseSmall();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            clearFields();
            loadUserAccounts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadUserAccounts();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Show(panelFilter);
            panelFilter.BringToFront();
        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            loadUserAccounts();
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "User Accounts", "Add") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSettings_UserAccounts_New frmSettings_UserAccounts_New = new frmSettings_UserAccounts_New();
            frmSettings_UserAccounts_New.addViewEdit = "Add";
            frmSettings_UserAccounts_New.ShowDialog();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);
                userName = dgvRecords.Rows[e.RowIndex].Cells[5].Value.ToString();
                displayName = "" + dgvRecords.Rows[e.RowIndex].Cells[7].Value + " " + dgvRecords.Rows[e.RowIndex].Cells[9].Value;

                if (e.ColumnIndex == 1) // Set User Credentials
                {
                    // Access Validation
                    if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "User Accounts", "View Credentials") == false) // Validate if the user has access to a certain system feature
                    {
                        new classMsgBox().showMsgError("Access Denied!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                        return;
                    }

                    frmSettings_UserCredentials frmSettings_UserCredentials = new frmSettings_UserCredentials();
                    frmSettings_UserCredentials.userID = userID;
                    frmSettings_UserCredentials.displayName = displayName;
                    frmSettings_UserCredentials.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Access Validation
                    if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "User Accounts", "Delete") == false) // Validate if the user has access to a certain system feature
                    {
                        new classMsgBox().showMsgError("Access Denied!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                        return;
                    }

                    // Show confirmation box
                    new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    if (Global.msgConfirmation == true)
                    {
                        // Delete the record from the database
                        MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                        Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_users SET Status='Deleted' WHERE User_ID=" + userID + ";", Conns.mySqlconn);     // Create a query command
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns.closeConnection();    // !Important ->> Close the connection from the database

                        new classMsgBox().showMsgSuccessful("Record has been deleted!");
                        loadUserAccounts();
                    }
                    Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    // Access Validation
                    if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "User Accounts", "Edit") == false) // Validate if the user has access to a certain system feature
                    {
                        new classMsgBox().showMsgError("Access Denied!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                        return;
                    }

                    frmSettings_UserAccounts_New frmSettings_UserAccounts_New = new frmSettings_UserAccounts_New();
                    frmSettings_UserAccounts_New.addViewEdit = "Edit";
                    frmSettings_UserAccounts_New.userID = userID;
                    frmSettings_UserAccounts_New.userName = userName;
                    frmSettings_UserAccounts_New.userDisplayName = displayName;
                    frmSettings_UserAccounts_New.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
