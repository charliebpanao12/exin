using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_BusinessCategories : UserControl
    {
        int businessCategoryID;

        public ucSettings_BusinessCategories()
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

        private void ucSettings_BusinessCategories_Load(object sender, EventArgs e)
        {
            clearFields();
            loadBusinessCategories();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            cboRecordStatus.Text = "Active";
        }

        public void loadBusinessCategories()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            businessCategoryID = 0;

            String filterBusinessCategory;
            String filterRecordStatus;

            filterBusinessCategory = txtSearch.Text.Trim();
            filterRecordStatus = cboRecordStatus.Text.Trim();

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_category WHERE (Category_Code LIKE '%" + filterBusinessCategory + "%' OR Category_Name LIKE '%" + filterBusinessCategory + "%') AND Status LIKE '" + filterRecordStatus + "%'", Conns.mySqlconn);     // Create a query command
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
                        Conns.mySqlDataReader["Category_Name"].ToString(),
                        Conns.mySqlDataReader["Category_Description"].ToString(),
                        Conns.mySqlDataReader["Print_Color1"].ToString(),
                        Conns.mySqlDataReader["Print_Color2"].ToString(),
                        Conns.mySqlDataReader["Print_Color3"].ToString(),
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
            loadBusinessCategories();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadBusinessCategories();
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
            loadBusinessCategories();
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSettings_BusinessCategory_New frmSettings_BusinessCategory_New = new frmSettings_BusinessCategory_New();
            frmSettings_BusinessCategory_New.addViewEdit = "Add";
            frmSettings_BusinessCategory_New.ShowDialog();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                businessCategoryID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[0].Value);    // Get the ID of the record

                if (e.ColumnIndex == 1) // View the details
                {
                    frmSettings_BusinessCategory_New frmSettings_BusinessCategory_New = new frmSettings_BusinessCategory_New();
                    frmSettings_BusinessCategory_New.addViewEdit = "View";
                    frmSettings_BusinessCategory_New.businessCategoryID = businessCategoryID;
                    frmSettings_BusinessCategory_New.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Show confirmation box
                    new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    if (Global.msgConfirmation == true)
                    {
                        // Delete the record from the database
                        MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                        Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_category SET Status='Deleted' WHERE ID=" + businessCategoryID + ";", Conns.mySqlconn);     // Create a query command
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns.closeConnection();    // !Important ->> Close the connection from the database

                        new classMsgBox().showMsgSuccessful("Record has been deleted!");
                        loadBusinessCategories();
                    }
                    Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    frmSettings_BusinessCategory_New frmSettings_BusinessCategory_New = new frmSettings_BusinessCategory_New();
                    frmSettings_BusinessCategory_New.addViewEdit = "Edit";
                    frmSettings_BusinessCategory_New.businessCategoryID = businessCategoryID;
                    frmSettings_BusinessCategory_New.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
