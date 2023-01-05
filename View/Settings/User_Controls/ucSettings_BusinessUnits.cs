using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_BusinessUnits : UserControl
    {
        int businessUnitID;

        public ucSettings_BusinessUnits()
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
            cboBusinessCategory.BorderColor = Global.themeColor1;
            cboBusinessCategory.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessCategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboCorporation.BorderColor = Global.themeColor1;
            cboCorporation.FocusedState.BorderColor = Global.themeColor2;
            cboCorporation.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboRecordStatus.BorderColor = Global.themeColor1;
            cboRecordStatus.FocusedState.BorderColor = Global.themeColor2;
            cboRecordStatus.HoverState.BorderColor = Global.themeColor2;
            #endregion
        }

        private void ucSettings_BusinessUnits_Load(object sender, EventArgs e)
        {
            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory, "Category_Name", "SELECT DISTINCT Category_Name FROM tbl_category WHERE Status='Active' ORDER BY Category_Name ASC", "All");
            classGlobalFunctions.loadComboBoxItems(cboCorporation, "Corp_Name", "SELECT DISTINCT Corp_Name FROM tbl_corporations WHERE Status='Active' ORDER BY Corp_Name ASC", "All");

            clearFields();
            loadBusinessUnits();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            cboBusinessCategory.Text = "All";
            cboCorporation.Text = "All";
            cboRecordStatus.Text = "Active";
        }

        public void loadBusinessUnits()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            businessUnitID = 0;

            String filterBusinessCategory;
            String filterCorporation;
            String filterBusinessUnit;
            String filterRecordStatus;

            filterBusinessCategory = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory.Text + "' AND Status='Active' LIMIT 1");
            filterCorporation = classGlobalFunctions.getComboBoxDetails("Corp_Code", "SELECT Corp_Code FROM tbl_corporations WHERE Corp_Name='" + cboCorporation.Text + "' AND Status='Active' LIMIT 1");
            filterBusinessUnit = txtSearch.Text.Trim();
            filterRecordStatus = cboRecordStatus.Text.Trim();

            if (cboBusinessCategory.Text == "All")
            {
                filterBusinessCategory = "";
            }

            if (cboCorporation.Text == "All")
            {
                filterCorporation = "";
            }

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_units WHERE Category_Code LIKE '" + filterBusinessCategory + "%' AND Corp_Code LIKE '" + filterCorporation + "%' AND (Unit_Name LIKE '%" + filterBusinessUnit + "%' OR Unit_Address LIKE '%" + filterBusinessUnit + "%') AND Status LIKE '" + filterRecordStatus + "%' ORDER BY Unit_Code ASC", Conns.mySqlconn);     // Create a query command
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
                        Conns.mySqlDataReader["Category_Code"].ToString(),
                        Conns.mySqlDataReader["Corp_Code"].ToString(),
                        Conns.mySqlDataReader["Unit_Code"].ToString(),
                        Conns.mySqlDataReader["Unit_Name"].ToString(),
                        Conns.mySqlDataReader["Unit_TIN"].ToString(),
                        Conns.mySqlDataReader["Unit_Address"].ToString(),
                        Conns.mySqlDataReader["Region_Name"].ToString(),
                        Conns.mySqlDataReader["Area_Name"].ToString(),
                        Conns.mySqlDataReader["Notes"].ToString(),
                        Conns.mySqlDataReader["MD"].ToString(),
                        Conns.mySqlDataReader["GM"].ToString(),
                        Conns.mySqlDataReader["BP"].ToString(),
                        Conns.mySqlDataReader["Date_Open"].ToString(),
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
            loadBusinessUnits();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadBusinessUnits();
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
            loadBusinessUnits();
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSettings_BusinessUnit_New frmSettings_BusinessUnit_New = new frmSettings_BusinessUnit_New();
            frmSettings_BusinessUnit_New.addViewEdit = "Add";
            frmSettings_BusinessUnit_New.ShowDialog();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                businessUnitID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[0].Value);    // Get the ID of the record

                if (e.ColumnIndex == 1) // View the details
                {
                    frmSettings_BusinessUnit_New frmSettings_BusinessUnit_New = new frmSettings_BusinessUnit_New();
                    frmSettings_BusinessUnit_New.addViewEdit = "View";
                    frmSettings_BusinessUnit_New.businessUnitID = businessUnitID;
                    frmSettings_BusinessUnit_New.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Show confirmation box
                    new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    if (Global.msgConfirmation == true)
                    {
                        // Delete the record from the database
                        MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                        Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_units SET Status='Deleted' WHERE ID=" + businessUnitID + ";", Conns.mySqlconn);     // Create a query command
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns.closeConnection();    // !Important ->> Close the connection from the database

                        new classMsgBox().showMsgSuccessful("Record has been deleted!");
                        loadBusinessUnits();
                    }
                    Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    frmSettings_BusinessUnit_New frmSettings_BusinessUnit_New = new frmSettings_BusinessUnit_New();
                    frmSettings_BusinessUnit_New.addViewEdit = "Edit";
                    frmSettings_BusinessUnit_New.businessUnitID = businessUnitID;
                    frmSettings_BusinessUnit_New.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
