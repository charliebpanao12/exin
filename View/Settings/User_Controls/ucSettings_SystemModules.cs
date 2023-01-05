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
    public partial class ucSettings_SystemModules : UserControl
    {
        public ucSettings_SystemModules()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Controls - Button 1
            btnSave.FillColor = Global.themeColor1;
            btnSave.HoverState.FillColor = Global.themeColor2;
            btnSave.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Toggle Switch
            toggleAccountingSystem.CheckedState.FillColor = Global.themeColor1;
            toggleVoucheringSystem.CheckedState.FillColor = Global.themeColor1;
            toggleSalesCollection.CheckedState.FillColor = Global.themeColor1;
            toggleBillingCollection.CheckedState.FillColor = Global.themeColor1;
            toggleInventorySystem.CheckedState.FillColor = Global.themeColor1;
            togglePayrollSystem.CheckedState.FillColor = Global.themeColor1;
            togglePointOfSales.CheckedState.FillColor = Global.themeColor1;
            toggleFixedAssetsManagement.CheckedState.FillColor = Global.themeColor1;
        }

        private void ucSettings_SystemModules_Load(object sender, EventArgs e)
        {
            loadSystemModules();
        }

        private void clearFields()
        {
            toggleAccountingSystem.Checked = false;
            toggleVoucheringSystem.Checked = false;
            toggleSalesCollection.Checked = false;
            toggleBillingCollection.Checked = false;
            toggleInventorySystem.Checked = false;
            togglePayrollSystem.Checked = false;
            togglePointOfSales.Checked = false;
            toggleFixedAssetsManagement.Checked = false;
        }

        private void loadSystemModules()
        {
            clearFields();  // Clear the records first

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_system_modules", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            if (numRows > 0)
            {
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    if (Conns.mySqlDataReader["system_module"].ToString() == "Accounting System")
                    {
                        toggleAccountingSystem.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Vouchering System")
                    {
                        toggleVoucheringSystem.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Sales & Collection")
                    {
                        toggleSalesCollection.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Billing & Collection")
                    {
                        toggleBillingCollection.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Inventory System")
                    {
                        toggleInventorySystem.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Payroll System")
                    {
                        togglePayrollSystem.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Point of Sales")
                    {
                        togglePointOfSales.Checked = true;
                    }
                    else if (Conns.mySqlDataReader["system_module"].ToString() == "Fixed Assets Management")
                    {
                        toggleFixedAssetsManagement.Checked = true;
                    }

                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                // Truncate the records from the database
                MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                Conns.mySqlCmd = new MySqlCommand("DELETE FROM tbl_system_modules", Conns.mySqlconn);     // Create a query command
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                Conns.closeConnection();    // !Important ->> Close the connection from the database

                // Insert the new records

                // Accounting System
                if (toggleAccountingSystem.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Accounting System");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Vouchering System
                if (toggleVoucheringSystem.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Vouchering System");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Sales & Collection
                if (toggleSalesCollection.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Sales & Collection");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Billing & Collection
                if (toggleBillingCollection.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Billing & Collection");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Inventory System
                if (toggleInventorySystem.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Inventory System");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Payroll System
                if (togglePayrollSystem.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Payroll System");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Point of Sales
                if (togglePointOfSales.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Point of Sales");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }
                // Fixed Assets Management
                if (toggleFixedAssetsManagement.Checked == true)
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("INSERT INTO tbl_system_modules (system_module) " +
                       "VALUES (@system_module);", Conns2.mySqlconn);     // Create a query command
                    // Add Command Parameters
                    Conns2.mySqlCmd.Parameters.AddWithValue("system_module", "Fixed Assets Management");
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database
                }

                // Successful Message
                new classMsgBox().showMsgSuccessful("Record has been updated!");
                loadSystemModules();

                // Reload the system modules in the main form
                var mainForm = Application.OpenForms.OfType<frmMain>().Single();
                mainForm.loadSystemModules();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }
    }
}
