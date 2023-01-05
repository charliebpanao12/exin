using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace EXIN.Controller
{
    public static class classValidateCredentials
    {
        public static Boolean validateCredentials(int userID, string systemModule, string systemCategory, string systemFeature)
        {
            Boolean result = false;

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users_credentials_system_features WHERE user_id=" + userID + " AND system_module='" + systemModule + "' AND category='" + systemCategory + "' AND feature_description='" + systemFeature + "';", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            if (numRows > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Conns.closeConnection();    // !Important ->> Close the connection from the database

            return result;
        }
    }
}
