using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_SystemFeatures_New : Form
    {
        public static String addViewEdit;
        public static int featureID;

        public frmSettings_SystemFeatures_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            //numtxtSystemOrder.BorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboSystemModule.BorderColor = Global.themeColor1;
            cboSystemModule.FocusedState.BorderColor = Global.themeColor2;
            cboSystemModule.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtCategoryOrder.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtCategory.BorderColor = Global.themeColor1;
            txtCategory.FocusedState.BorderColor = Global.themeColor2;
            txtCategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtFeatureOrder.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtFeatureDescription.BorderColor = Global.themeColor1;
            txtFeatureDescription.FocusedState.BorderColor = Global.themeColor2;
            txtFeatureDescription.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_SystemFeatures_New_Load(object sender, EventArgs e)
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
            numtxtSystemOrder.Value = 0;
            cboSystemModule.Text = "";
            numtxtCategoryOrder.Value = 0;
            txtCategory.Text = "";
            numtxtFeatureOrder.Value = 0;
            txtFeatureDescription.Text = "";
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_settings_list_of_system_features WHERE ID=" + featureID + ";", Conns.mySqlconn);     // Create a query command
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
                    numtxtSystemOrder.Value = Convert.ToInt32(Conns.mySqlDataReader["system_order"].ToString());
                    cboSystemModule.Text = Conns.mySqlDataReader["system_module"].ToString();
                    numtxtCategoryOrder.Value = Convert.ToInt32(Conns.mySqlDataReader["category_order"].ToString());
                    txtCategory.Text = Conns.mySqlDataReader["category"].ToString();
                    numtxtFeatureOrder.Value = Convert.ToInt32(Conns.mySqlDataReader["feature_order"].ToString());
                    txtFeatureDescription.Text = Conns.mySqlDataReader["feature_description"].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (cboSystemModule.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select System Module");
                Application.OpenForms["frmSettings_SystemFeatures_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtCategory.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input Category");
                Application.OpenForms["frmSettings_SystemFeatures_New"].Activate(); // Bring the parent form to the front 
                return;
            }
            // Validations
            if (txtFeatureDescription.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input Feature Description");
                Application.OpenForms["frmSettings_SystemFeatures_New"].Activate(); // Bring the parent form to the front
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                if (addViewEdit == "Add")
                {
                    // Insert the new records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_settings_list_of_system_features(system_order, system_module, category_order, category, feature_order, feature_description) " +
                        "VALUES (@system_order, @system_module, @category_order, @category, @feature_order, @feature_description);", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_order", numtxtSystemOrder.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", cboSystemModule.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("category_order", numtxtCategoryOrder.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("category", txtCategory.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("feature_order", numtxtFeatureOrder.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("feature_description", txtFeatureDescription.Text.Trim());
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been saved");
                }
                else if (addViewEdit == "Edit")
                {
                    // Update the existing records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_settings_list_of_system_features SET system_order=@system_order, system_module=@system_module, category_order=@category_order, category=@category, feature_order=@feature_order, feature_description=@feature_description WHERE ID=@ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("ID", featureID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_order", numtxtSystemOrder.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", cboSystemModule.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("category_order", numtxtCategoryOrder.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("category", txtCategory.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("feature_order", numtxtFeatureOrder.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("feature_description", txtFeatureDescription.Text.Trim());
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_SystemFeatures ucSettings_SystemFeatures = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_SystemFeatures;
                ucSettings_SystemFeatures.loadSystemFeatures();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cboSystemModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSystemModule.Text == "System Settings")
            {
                numtxtSystemOrder.Value = 100000;
            }
            else if (cboSystemModule.Text == "Accounting System")
            {
                numtxtSystemOrder.Value = 200000;
            }
            else if (cboSystemModule.Text == "Vouchering System")
            {
                numtxtSystemOrder.Value = 300000;
            }
            else if (cboSystemModule.Text == "Sales & Collection")
            {
                numtxtSystemOrder.Value = 400000;
            }
            else if (cboSystemModule.Text == "Billing & Collection")
            {
                numtxtSystemOrder.Value = 500000;
            }
            else if (cboSystemModule.Text == "Inventory System")
            {
                numtxtSystemOrder.Value = 600000;
            }
            else if (cboSystemModule.Text == "Payroll System")
            {
                numtxtSystemOrder.Value = 700000;
            }
            else if (cboSystemModule.Text == "Point of Sales")
            {
                numtxtSystemOrder.Value = 800000;
            }
            else if (cboSystemModule.Text == "Fixed Assets Management")
            {
                numtxtSystemOrder.Value = 900000;
            }
        }
    }
}
