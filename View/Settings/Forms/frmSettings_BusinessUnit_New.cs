using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_BusinessUnit_New : Form
    {
        public static String addViewEdit;
        public static int businessUnitID;
        public static int businessUnitCode;
        public static String businessUnitName;

        public frmSettings_BusinessUnit_New()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel Title
            panelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - TextBox
            txtBusinessCategoryCode.BorderColor = Global.themeColor1;
            txtBusinessCategoryCode.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessCategoryCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboBusinessCategory.BorderColor = Global.themeColor1;
            cboBusinessCategory.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessCategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCorporationCode.BorderColor = Global.themeColor1;
            txtCorporationCode.FocusedState.BorderColor = Global.themeColor2;
            txtCorporationCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboCorporation.BorderColor = Global.themeColor1;
            cboCorporation.FocusedState.BorderColor = Global.themeColor2;
            cboCorporation.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtBusinessUnitCode.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtBusinessUnitName.BorderColor = Global.themeColor1;
            txtBusinessUnitName.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessUnitName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtTIN.BorderColor = Global.themeColor1;
            txtTIN.FocusedState.BorderColor = Global.themeColor2;
            txtTIN.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtAddress.BorderColor = Global.themeColor1;
            txtAddress.FocusedState.BorderColor = Global.themeColor2;
            txtAddress.HoverState.BorderColor = Global.themeColor2;

            // Controls - DateTimePicker
            dtpDateOpened.FillColor = Global.themeColor1;
            dtpDateOpened.BorderColor = Global.themeColor1;
            dtpDateOpened.CustomFormat = "MMMM dd, yyyy";

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmSettings_BusinessUnit_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory, "Category_Name", "SELECT DISTINCT Category_Name FROM tbl_category WHERE Status='Active' ORDER BY Category_Name ASC", "Blank");
            classGlobalFunctions.loadComboBoxItems(cboCorporation, "Corp_Name", "SELECT DISTINCT Corp_Name FROM tbl_corporations WHERE Status='Active' ORDER BY Corp_Name ASC", "Blank");

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
            txtBusinessCategoryCode.Text = "";
            cboBusinessCategory.Text = "";
            txtCorporationCode.Text = "";
            cboCorporation.Text = "";
            numtxtBusinessUnitCode.Value = 0;
            txtBusinessUnitName.Text = "";
            txtTIN.Text = "";
            txtAddress.Text = "";
            dtpDateOpened.Value = DateTime.Now;
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.Category_Code, t1.Corp_Code, t1.Unit_Code, t1.Unit_Name, t1.Unit_TIN, t1.Unit_Address, t1.Date_Open, t2.Category_Name, t3.Corp_Name FROM " +
                "(SELECT ID, Category_Code, Corp_Code, Unit_Code, Unit_Name, Unit_TIN, Unit_Address, Date_Open FROM tbl_units WHERE ID=" + businessUnitID + ") AS t1 " +
                "LEFT JOIN (SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t2 ON t1.Category_Code=t2.Category_Code " +
                "LEFT JOIN (SELECT Corp_Code, Corp_Name FROM tbl_corporations WHERE Status='Active') AS t3 ON t1.Corp_Code=t3.Corp_Code " +
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
                    businessUnitCode = Convert.ToInt32(Conns.mySqlDataReader["Unit_Code"].ToString());
                    businessUnitName = Conns.mySqlDataReader["Unit_Name"].ToString();
                    txtBusinessCategoryCode.Text = Conns.mySqlDataReader["Category_Code"].ToString();
                    cboBusinessCategory.Text = Conns.mySqlDataReader["Category_Name"].ToString();
                    txtCorporationCode.Text = Conns.mySqlDataReader["Corp_Code"].ToString();
                    cboCorporation.Text = Conns.mySqlDataReader["Corp_Name"].ToString();
                    numtxtBusinessUnitCode.Value = Convert.ToInt32(Conns.mySqlDataReader["Unit_Code"].ToString());
                    txtBusinessUnitName.Text = Conns.mySqlDataReader["Unit_Name"].ToString();
                    txtTIN.Text = Conns.mySqlDataReader["Unit_TIN"].ToString();
                    txtAddress.Text = Conns.mySqlDataReader["Unit_Address"].ToString();
                    dtpDateOpened.Value = Convert.ToDateTime(Conns.mySqlDataReader["Date_Open"].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void cboBusinessCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusinessCategoryCode.Text = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory.Text + "' AND Status='Active' LIMIT 1");
        }

        private void cboCorporation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCorporationCode.Text = classGlobalFunctions.getComboBoxDetails("Corp_Code", "SELECT Corp_Code FROM tbl_corporations WHERE Corp_Name='" + cboCorporation.Text + "' AND Status='Active' LIMIT 1");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtBusinessCategoryCode.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select business category");
                Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtCorporationCode.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select corporation");
                Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (numtxtBusinessUnitCode.Value == 0)
            {
                new classMsgBox().showMsgError("Please input business unit code");
                Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtBusinessUnitName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input business unit name");
                Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_units WHERE Unit_Code=" + numtxtBusinessUnitCode.Value + " AND Status='Active';");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The business unit code already exists in the database");
                    Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
                Boolean recordExist2 = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_units WHERE Unit_Name='" + txtBusinessUnitName.Text.Trim() + "' AND Status='Active';");
                if (recordExist2 == true)
                {
                    new classMsgBox().showMsgError("The business unit name already exists in the database");
                    Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (businessUnitCode != numtxtBusinessUnitCode.Value) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_units WHERE Unit_Code=" + numtxtBusinessUnitCode.Value + " AND Status='Active';");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The business unit code already exists in the database");
                        Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front                 
                        return;
                    }
                }
                if (businessUnitName != txtBusinessUnitName.Text.Trim()) // Validate if the main information has been edited
                {
                    Boolean recordExist2 = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_units WHERE Unit_Name='" + txtBusinessUnitName.Text.Trim() + "' AND Status='Active';");
                    if (recordExist2 == true)
                    {
                        new classMsgBox().showMsgError("The business unit name already exists in the database");
                        Application.OpenForms["frmSettings_BusinessUnit_New"].Activate(); // Bring the parent form to the front                 
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
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_units(Category_Code, Corp_Code, Unit_Code, Unit_Name, Unit_TIN, Unit_Address, Status, Remarks, Date_Open) " +
                        "VALUES (@Category_Code, @Corp_Code, @Unit_Code, @Unit_Name, @Unit_TIN, @Unit_Address, @Status, @Remarks, @Date_Open);", Conns2.mySqlconn);     // Create a query command                    
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtBusinessCategoryCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Code", txtCorporationCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Code", numtxtBusinessUnitCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Name", txtBusinessUnitName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_TIN", txtTIN.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Address", txtAddress.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                    Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                    Conns2.mySqlCmd.Parameters.AddWithValue("Date_Open", dtpDateOpened.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been saved");
                }
                else if (addViewEdit == "Edit")
                {
                    // Update the existing records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_units SET Category_Code=@Category_Code, Corp_Code=@Corp_Code, Unit_Code=@Unit_Code, Unit_Name=@Unit_Name, Unit_TIN=@Unit_TIN, Unit_Address=@Unit_Address, Date_Open=@Date_Open WHERE ID=@ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("ID", businessUnitID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtBusinessCategoryCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Corp_Code", txtCorporationCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Code", numtxtBusinessUnitCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Name", txtBusinessUnitName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_TIN", txtTIN.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Address", txtAddress.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Date_Open", dtpDateOpened.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_BusinessUnits ucSettings_BusinessUnits = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_BusinessUnits;
                ucSettings_BusinessUnits.loadBusinessUnits();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
