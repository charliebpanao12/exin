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
    public partial class ucSettings_ExpandedAccounts : UserControl
    {
        int expandedAccountID;
        int expandedAccountCode;

        public ucSettings_ExpandedAccounts()
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
            cboRecordStatus.BorderColor = Global.themeColor1;
            cboRecordStatus.FocusedState.BorderColor = Global.themeColor2;
            cboRecordStatus.HoverState.BorderColor = Global.themeColor2;

            #endregion
        }

        private void ucSettings_ExpandedAccounts_Load(object sender, EventArgs e)
        {
            clearFields();
            loadExpandedAccounts();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            cboRecordStatus.Text = "Active";
        }

        public void loadExpandedAccounts()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            expandedAccountID = 0;

            String filterExpandedAccount;
            String filterRecordStatus;

            filterExpandedAccount = txtSearch.Text.Trim();
            filterRecordStatus = cboRecordStatus.Text.Trim();

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_expandedpnlaccounts WHERE (ExpandedAccounts LIKE '%" + filterExpandedAccount + "%' OR ExpandedAccountDesc LIKE '%" + filterExpandedAccount + "%') ORDER BY ExpandedAccounts ASC;", Conns.mySqlconn);     // Create a query command
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
                        clview.Image = Viewicon,
                        cledit.Image = Deleteicon,
                        cldelete.Image = Editicon,
                        Conns.mySqlDataReader["ExpandedAccounts"].ToString(),
                        Conns.mySqlDataReader["ExpandedAccountDesc"].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Preloader - Close
            loader.CloseSmall();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            clearFields();
            loadExpandedAccounts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadExpandedAccounts();
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
            loadExpandedAccounts();
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSettings_ExpandedAccounts_New frmSettings_ExpandedAccounts_New = new frmSettings_ExpandedAccounts_New();
            frmSettings_ExpandedAccounts_New.addViewEdit = "Add";
            frmSettings_ExpandedAccounts_New.ShowDialog();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                expandedAccountID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[0].Value);    // Get the ID of the record
                expandedAccountCode = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);    // Get the ID of the record

                if (e.ColumnIndex == 1) // View the details
                {
                    frmSettings_ExpandedAccounts_New frmSettings_ExpandedAccounts_New = new frmSettings_ExpandedAccounts_New();
                    frmSettings_ExpandedAccounts_New.addViewEdit = "View";
                    frmSettings_ExpandedAccounts_New.expandedAccountID = expandedAccountID;
                    frmSettings_ExpandedAccounts_New.expandedAccountCode = expandedAccountCode;
                    frmSettings_ExpandedAccounts_New.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Show confirmation box
                    new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    if (Global.msgConfirmation == true)
                    {
                        // Delete the record from the database
                        MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                        Conns.mySqlCmd = new MySqlCommand("DELETE FROM tbl_expandedpnlaccounts WHERE ID=" + expandedAccountID + ";", Conns.mySqlconn);     // Create a query command
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns.closeConnection();    // !Important ->> Close the connection from the database

                        new classMsgBox().showMsgSuccessful("Record has been deleted!");
                        loadExpandedAccounts();
                    }
                    Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    frmSettings_ExpandedAccounts_New frmSettings_ExpandedAccounts_New = new frmSettings_ExpandedAccounts_New();
                    frmSettings_ExpandedAccounts_New.addViewEdit = "Edit";
                    frmSettings_ExpandedAccounts_New.expandedAccountID = expandedAccountID;
                    frmSettings_ExpandedAccounts_New.expandedAccountCode = expandedAccountCode;
                    frmSettings_ExpandedAccounts_New.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
