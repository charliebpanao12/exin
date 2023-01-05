using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_SystemFeatures : UserControl
    {
        int featureID;

        public ucSettings_SystemFeatures()
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
            cboSystemModule.BorderColor = Global.themeColor1;
            cboSystemModule.FocusedState.BorderColor = Global.themeColor2;
            cboSystemModule.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboOption02.BorderColor = Global.themeColor1;
            cboOption02.FocusedState.BorderColor = Global.themeColor2;
            cboOption02.HoverState.BorderColor = Global.themeColor2;
            #endregion
        }

        public void ucSettings_SystemFeatures_Load(object sender, EventArgs e)
        {
            clearFields();
            loadSystemFeatures();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            cboSystemModule.Text = "All";
        }

        public void loadSystemFeatures()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            featureID = 0;

            String filterSystemModule;
            String filterSystemFeature;

            if (cboSystemModule.Text == "All")
            {
                filterSystemModule = "";
            }
            else
            {
                filterSystemModule = cboSystemModule.Text;
            }

            filterSystemFeature = txtSearch.Text.Trim();

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_settings_list_of_system_features WHERE system_module LIKE '" + filterSystemModule + "%' AND (category LIKE '%" + filterSystemFeature + "%' OR feature_description LIKE '%" + filterSystemFeature + "%') ORDER BY system_order ASC, category_order ASC, feature_order ASC;", Conns.mySqlconn);     // Create a query command
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
                        Conns.mySqlDataReader["system_order"].ToString(),
                        Conns.mySqlDataReader["system_module"].ToString(),
                        Conns.mySqlDataReader["category_order"].ToString(),
                        Conns.mySqlDataReader["category"].ToString(),
                        Conns.mySqlDataReader["feature_order"].ToString(),
                        Conns.mySqlDataReader["feature_description"].ToString());

                    i++;
                }
                //dgvRecords.AutoResizeColumns();
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Preloader - Close
            loader.CloseSmall();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearFields();
            loadSystemFeatures();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadSystemFeatures();
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
            loadSystemFeatures();
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSettings_SystemFeatures_New frmSettings_SystemFeatures_New = new frmSettings_SystemFeatures_New();
            frmSettings_SystemFeatures_New.addViewEdit = "Add";
            frmSettings_SystemFeatures_New.ShowDialog();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                featureID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[0].Value);    // Get the ID of the record

                if (e.ColumnIndex == 1) // View the details
                {
                    frmSettings_SystemFeatures_New frmSettings_SystemFeatures_New = new frmSettings_SystemFeatures_New();
                    frmSettings_SystemFeatures_New.addViewEdit = "View";
                    frmSettings_SystemFeatures_New.featureID = featureID;
                    frmSettings_SystemFeatures_New.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Show confirmation box
                    new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    if (Global.msgConfirmation == true)
                    {
                        // Delete the record from the database
                        MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                        Conns.mySqlCmd = new MySqlCommand("DELETE FROM tbl_settings_list_of_system_features WHERE ID=" + featureID + ";", Conns.mySqlconn);     // Create a query command
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns.closeConnection();    // !Important ->> Close the connection from the database

                        new classMsgBox().showMsgSuccessful("Record has been deleted!");
                        loadSystemFeatures();
                    }
                    Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    frmSettings_SystemFeatures_New frmSettings_SystemFeatures_New = new frmSettings_SystemFeatures_New();
                    frmSettings_SystemFeatures_New.addViewEdit = "Edit";
                    frmSettings_SystemFeatures_New.featureID = featureID;
                    frmSettings_SystemFeatures_New.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
