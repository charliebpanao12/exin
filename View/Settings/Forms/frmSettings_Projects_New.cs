using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class frmSettings_Projects_New : Form
    {
        public static String addViewEdit;
        public static int projectID;
        public static int projectCode;

        public frmSettings_Projects_New()
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
            txtBusinessUnitCode.BorderColor = Global.themeColor1;
            txtBusinessUnitCode.FocusedState.BorderColor = Global.themeColor2;
            txtBusinessUnitCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboBusinessUnit.BorderColor = Global.themeColor1;
            cboBusinessUnit.FocusedState.BorderColor = Global.themeColor2;
            cboBusinessUnit.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numtxtProjectCode.BorderColor = Global.themeColor1;

            // Controls - TextBox
            txtProjectName.BorderColor = Global.themeColor1;
            txtProjectName.FocusedState.BorderColor = Global.themeColor2;
            txtProjectName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtNotes.BorderColor = Global.themeColor1;
            txtNotes.FocusedState.BorderColor = Global.themeColor2;
            txtNotes.HoverState.BorderColor = Global.themeColor2;

            // Controls - DateTimePicker
            dtpStartDate.FillColor = Global.themeColor1;
            dtpStartDate.BorderColor = Global.themeColor1;
            dtpStartDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpEndDate.FillColor = Global.themeColor1;
            dtpEndDate.BorderColor = Global.themeColor1;
            dtpEndDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        public void frmSettings_Projects_New_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            lblTitle.Text += " (" + addViewEdit + ")";

            // Load the ComboBox items
            classGlobalFunctions.loadComboBoxItems(cboBusinessCategory, "Category_Name", "SELECT DISTINCT Category_Name FROM tbl_category WHERE Status='Active' ORDER BY Category_Name ASC", "Blank");

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
            txtBusinessUnitCode.Text = "";
            cboBusinessUnit.Text = "";
            numtxtProjectCode.Value = 0;
            txtProjectName.Text = "";
            txtNotes.Text = "";
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.ID, t1.Category_Code, t1.Unit_Code, t1.Project_Code, t1.Project_Name, t1.Project_Notes, t1.Start_Date, t1.End_Date, t2.Category_Name, t3.Unit_Name FROM " +
                "(SELECT ID, Category_Code, Unit_Code, Project_Code, Project_Name, Project_Notes, Start_Date, End_Date FROM tbl_projects WHERE ID=" + projectID + ") AS t1 " +
                "LEFT JOIN (SELECT Category_Code, Category_Name FROM tbl_category WHERE Status='Active') AS t2 ON t1.Category_Code=t2.Category_Code " +
                "LEFT JOIN (SELECT Unit_Code, Unit_Name FROM tbl_units WHERE Status='Active') AS t3 ON t1.Unit_Code=t3.Unit_Code " +
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
                    projectCode = Convert.ToInt32(Conns.mySqlDataReader["Project_Code"].ToString());
                    txtBusinessCategoryCode.Text = Conns.mySqlDataReader["Category_Code"].ToString();
                    cboBusinessCategory.Text = Conns.mySqlDataReader["Category_Name"].ToString();
                    txtBusinessUnitCode.Text = Conns.mySqlDataReader["Unit_Code"].ToString();
                    cboBusinessUnit.Text = Conns.mySqlDataReader["Unit_Name"].ToString();
                    numtxtProjectCode.Value = Convert.ToInt32(Conns.mySqlDataReader["Project_Code"].ToString());
                    txtProjectName.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                    txtNotes.Text = Conns.mySqlDataReader["Project_Notes"].ToString();
                    dtpStartDate.Value = Convert.ToDateTime(Conns.mySqlDataReader["Start_Date"].ToString());
                    dtpEndDate.Value = Convert.ToDateTime(Conns.mySqlDataReader["End_Date"].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void cboBusinessCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusinessCategoryCode.Text = classGlobalFunctions.getComboBoxDetails("Category_Code", "SELECT Category_Code FROM tbl_category WHERE Category_Name='" + cboBusinessCategory.Text + "' AND Status='Active' LIMIT 1");
            classGlobalFunctions.loadComboBoxItems(cboBusinessUnit, "Unit_Name", "SELECT DISTINCT Unit_Name FROM tbl_units WHERE Category_Code='" + txtBusinessCategoryCode.Text.Trim() + "' AND Status='Active' ORDER BY Unit_Name ASC", "Blank");
            txtBusinessUnitCode.Text = "";
            cboBusinessUnit.Text = "";
        }

        private void cboBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusinessUnitCode.Text = classGlobalFunctions.getComboBoxDetails("Unit_Code", "SELECT Unit_Code FROM tbl_units WHERE Unit_Name='" + cboBusinessUnit.Text + "' AND Status='Active' LIMIT 1");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validations
            if (txtBusinessCategoryCode.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select business category");
                Application.OpenForms["frmSettings_Projects_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtBusinessUnitCode.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please select business unit");
                Application.OpenForms["frmSettings_Projects_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (numtxtProjectCode.Value == 0)
            {
                new classMsgBox().showMsgError("Please input project code");
                Application.OpenForms["frmSettings_Projects_New"].Activate(); // Bring the parent form to the front  
                return;
            }
            // Validations
            if (txtProjectName.Text.Trim() == "")
            {
                new classMsgBox().showMsgError("Please input project name");
                Application.OpenForms["frmSettings_Projects_New"].Activate(); // Bring the parent form to the front  
                return;
            }

            // Validate if the record already exists
            if (addViewEdit == "Add")
            {
                Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_projects WHERE Project_Code=" + numtxtProjectCode.Value + " AND Status='Active' LIMIT 1;");
                if (recordExist == true)
                {
                    new classMsgBox().showMsgError("The project code already exists in the database");
                    Application.OpenForms["frmSettings_Projects_New"].Activate(); // Bring the parent form to the front                 
                    return;
                }
            }
            else if (addViewEdit == "Edit")
            {
                if (projectCode != numtxtProjectCode.Value) // Validate if the main information has been edited
                {
                    Boolean recordExist = classGlobalFunctions.validateRecordExistence("SELECT * FROM tbl_projects WHERE Project_Code=" + numtxtProjectCode.Value + " AND Status='Active';");
                    if (recordExist == true)
                    {
                        new classMsgBox().showMsgError("The project code already exists in the database");
                        Application.OpenForms["frmSettings_Projects_New"].Activate(); // Bring the parent form to the front                 
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
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_projects(Category_Code, Unit_Code, Project_Code, Project_Name, Project_Notes, Start_Date, End_Date, Duration_Date, Status, Remarks) " +
                        "VALUES (@Category_Code, @Unit_Code, @Project_Code, @Project_Name, @Project_Notes, @Start_Date, @End_Date, @Duration_Date, @Status, @Remarks);", Conns2.mySqlconn);     // Create a query command                    
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtBusinessCategoryCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Code", txtBusinessUnitCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Project_Code", numtxtProjectCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Project_Name", txtProjectName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Project_Notes", txtNotes.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Start_Date", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlCmd.Parameters.AddWithValue("End_Date", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlCmd.Parameters.AddWithValue("Duration_Date", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                    Conns2.mySqlCmd.Parameters.AddWithValue("Remarks", "Not yet sync");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been saved");
                }
                else if (addViewEdit == "Edit")
                {
                    // Update the existing records
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("UPDATE tbl_projects SET Category_Code=@Category_Code, Unit_Code=@Unit_Code, Project_Code=@Project_Code, Project_Name=@Project_Name, Project_Notes=@Project_Notes, Start_Date=@Start_Date, End_Date=@End_Date, Duration_Date=@Duration_Date WHERE ID=@ID;", Conns2.mySqlconn);     // Create a query command
                    Conns2.mySqlCmd.Parameters.AddWithValue("ID", projectID);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Category_Code", txtBusinessCategoryCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Unit_Code", txtBusinessUnitCode.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Project_Code", numtxtProjectCode.Value);
                    Conns2.mySqlCmd.Parameters.AddWithValue("Project_Name", txtProjectName.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Project_Notes", txtNotes.Text.Trim());
                    Conns2.mySqlCmd.Parameters.AddWithValue("Start_Date", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlCmd.Parameters.AddWithValue("End_Date", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlCmd.Parameters.AddWithValue("Duration_Date", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                    new classMsgBox().showMsgSuccessful("Record has been updated");
                }

                this.Hide();

                // Reload the records to the datagrid
                var targetForm = Application.OpenForms.OfType<frmSettings>().Single();
                ucSettings_Projects ucSettings_Projects = targetForm.Controls["panelContainer"].Controls[0] as ucSettings_Projects;
                ucSettings_Projects.loadProjectList();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}