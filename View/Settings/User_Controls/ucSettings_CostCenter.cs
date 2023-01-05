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
    public partial class ucSettings_CostCenter : UserControl
    {
        int costCenterID;
        int costCenterCode;
        string costCenterName;

        public ucSettings_CostCenter()
        {
            InitializeComponent();

            InitializeThemes();

            // Batch Duplicate
            if (Global.userLevel == "EXIN Developer" || Global.userLevel == "EXIN Support")
            {
                btnBatchDuplicate.Visible = true;
            }
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

            // Controls - Button 1
            btnBatchDuplicate.FillColor = Global.themeColor1;
            btnBatchDuplicate.HoverState.FillColor = Global.themeColor2;
            btnBatchDuplicate.HoverState.ForeColor = Global.themeForeColor;

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboBusinessCategory.BorderColor = Global.themeColor1;
            cboBusinessCategory.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessCategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboRecordStatus.BorderColor = Global.themeColor1;
            cboRecordStatus.FocusedState.BorderColor = Global.themeColor2;
            cboRecordStatus.HoverState.BorderColor = Global.themeColor2;
            #endregion
        }

        private void ucSettings_CostCenter_Load(object sender, EventArgs e)
        {
            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory, "Category_Name", "SELECT DISTINCT Category_Name FROM tbl_category WHERE Status='Active' ORDER BY Category_Name ASC", "All");

            clearFields();
            loadCostCenterList();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            cboBusinessCategory.Text = "All";
            cboRecordStatus.Text = "Active";
        }

        public void loadCostCenterList()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            costCenterID = 0;
            costCenterCode = 0;
            costCenterName = "";

            String filterBusinessCategory;
            String filterCostCenter;
            String filterRecordStatus;

            filterBusinessCategory = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory.Text + "' AND Status='Active' LIMIT 1");
            filterCostCenter = txtSearch.Text.Trim();
            filterRecordStatus = cboRecordStatus.Text.Trim();

            if (cboBusinessCategory.Text == "All")
            {
                filterBusinessCategory = "";
            }

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_costcenter WHERE Category_Code LIKE '" + filterBusinessCategory + "%' AND (CostCenter_Code LIKE '%" + filterCostCenter + "%' OR CostCenter_Name LIKE '%" + filterCostCenter + "%') AND Status LIKE '" + filterRecordStatus + "%' GROUP BY CostCenter_Code ORDER BY CostCenter_Code ASC LIMIT 100", Conns.mySqlconn);     // Create a query command
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
                        Conns.mySqlDataReader["CostCenter_Code"].ToString(),
                        Conns.mySqlDataReader["CostCenter_Name"].ToString(),
                        Conns.mySqlDataReader["CostCenter_Notes"].ToString(),
                        Conns.mySqlDataReader["Status"].ToString());
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
            loadCostCenterList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadCostCenterList();
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
            loadCostCenterList();
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Cost Center", "Add") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            frmSettings_CostCenter_New frmSettings_CostCenter_New = new frmSettings_CostCenter_New();
            frmSettings_CostCenter_New.addViewEdit = "Add";
            frmSettings_CostCenter_New.ShowDialog();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                costCenterID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[0].Value);    // Get the details of the record
                costCenterCode = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);    // Get the details of the record
                costCenterName = dgvRecords.Rows[e.RowIndex].Cells[5].Value.ToString();    // Get the details of the record

                if (e.ColumnIndex == 1) // View the details
                {
                    // Access Validation
                    if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Cost Center", "View") == false) // Validate if the user has access to a certain system feature
                    {
                        new classMsgBox().showMsgError("Access Denied!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                        return;
                    }

                    frmSettings_CostCenter_New frmSettings_CostCenter_New = new frmSettings_CostCenter_New();
                    frmSettings_CostCenter_New.addViewEdit = "View";
                    frmSettings_CostCenter_New.costCenterID = costCenterID;
                    frmSettings_CostCenter_New.costCenterCode = costCenterCode;
                    frmSettings_CostCenter_New.costCenterName = costCenterName;
                    frmSettings_CostCenter_New.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Access Validation
                    if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Cost Center", "Delete") == false) // Validate if the user has access to a certain system feature
                    {
                        new classMsgBox().showMsgError("Access Denied!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                        return;
                    }

                    // Vadlidate if this record has been used in transactions
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_transaction WHERE CostCenter_Code=" + costCenterCode + " AND Status='Active' LIMIT 1;");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("This record cannot be deleted because it has an active transaction in the database!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front                 
                        return;
                    }

                    // Show confirmation box
                    new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    if (Global.msgConfirmation == true)
                    {
                        // Delete the record from the database
                        MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                        Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_costcenter SET Status='Deleted' WHERE CostCenter_Code=" + costCenterCode + ";", Conns.mySqlconn);     // Create a query command
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns.closeConnection();    // !Important ->> Close the connection from the database

                        new classMsgBox().showMsgSuccessful("Record has been deleted!");
                        loadCostCenterList();
                    }
                    Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    // Access Validation
                    if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Cost Center", "Edit") == false) // Validate if the user has access to a certain system feature
                    {
                        new classMsgBox().showMsgError("Access Denied!");
                        Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                        return;
                    }

                    frmSettings_CostCenter_New frmSettings_CostCenter_New = new frmSettings_CostCenter_New();
                    frmSettings_CostCenter_New.addViewEdit = "Edit";
                    frmSettings_CostCenter_New.costCenterID = costCenterID;
                    frmSettings_CostCenter_New.costCenterCode = costCenterCode;
                    frmSettings_CostCenter_New.costCenterName = costCenterName;
                    frmSettings_CostCenter_New.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnBatchDuplicate_Click(object sender, EventArgs e)
        {
            frmSettings_CostCenter_BatchDuplicate frmSettings_CostCenter_BatchDuplicate = new frmSettings_CostCenter_BatchDuplicate();
            frmSettings_CostCenter_BatchDuplicate.ShowDialog();
        }
    }
}
