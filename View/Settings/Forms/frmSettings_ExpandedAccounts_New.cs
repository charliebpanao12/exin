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
    public partial class frmSettings_ExpandedAccounts_New : Form
    {
        public static String addViewEdit;
        public static int expandedAccountID;
        public static int expandedAccountCode;

        public frmSettings_ExpandedAccounts_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtExpandedAccountCode.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtExpandedAccountDesc.BorderColor = Global.themeColor1;
            txtExpandedAccountDesc.FocusedState.BorderColor = Global.themeColor2;
            txtExpandedAccountDesc.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_ExpandedAccounts_New_Load(object sender, EventArgs e)
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
            numtxtExpandedAccountCode.Value = 0;
            txtExpandedAccountDesc.Text = "";
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.ExpandedAccounts, t1.ExpandedAccountDesc FROM " +
                "(SELECT ID, ExpandedAccounts, ExpandedAccountDesc FROM tbl_expandedpnlaccounts WHERE ID=" + expandedAccountID + ") AS t1 " +
                "LIMIT 1;", Conns.mySqlconn);     // Create a query command
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
                    numtxtExpandedAccountCode.Value = Convert.ToInt32(Conns.mySqlDataReader["ExpandedAccounts"].ToString());
                    txtExpandedAccountDesc.Text = Conns.mySqlDataReader["ExpandedAccountDesc"].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (numtxtExpandedAccountCode.Value == 0)
            {
                new classMsgBox().showMsgError("Please input expanded account code");
                Application.OpenForms["frmSettings_ExpandedAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtExpandedAccountDesc.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input expanded account description");
                Application.OpenForms["frmSettings_ExpandedAccounts_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_expandedpnlaccounts WHERE ExpandedAccounts=" + numtxtExpandedAccountCode.Value + ";");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The expanded account code already exists in the database");
                    Application.OpenForms["frmSettings_ExpandedAccounts_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (expandedAccountCode != numtxtExpandedAccountCode.Value) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_expandedpnlaccounts WHERE ExpandedAccounts=" + numtxtExpandedAccountCode.Value + ";");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The expanded account code already exists in the database");
                        Application.OpenForms["frmSettings_ExpandedAccounts_New"].Activate(); // Bring the parent form to the front                 
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
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_expandedpnlaccounts(ExpandedAccounts, ExpandedAccountDesc) " +
                        "VALUES (@ExpandedAccounts, @ExpandedAccountDesc);", Conns2.mySqlconn);     // Create a query command                    
                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccounts", numtxtExpandedAccountCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccountDesc", txtExpandedAccountDesc.Text.Trim());
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been saved");
                }
                else if (addViewEdit == "Edit")
                {
                    // Update the existing records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_expandedpnlaccounts SET ExpandedAccounts=@ExpandedAccounts, ExpandedAccountDesc=@ExpandedAccountDesc WHERE ID=@ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("ID", expandedAccountID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccounts", numtxtExpandedAccountCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("ExpandedAccountDesc", txtExpandedAccountDesc.Text.Trim());
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_ExpandedAccounts ucSettings_ExpandedAccounts = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_ExpandedAccounts;
                ucSettings_ExpandedAccounts.loadExpandedAccounts();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
