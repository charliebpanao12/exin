using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Controller
{
    public class classGlobalFunctions
    {
        public static void getPreferences_ThemeStyle(int userID)
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_users WHERE User_ID=" + userID + " LIMIT 1", Conns.mySqlconn);     // Create a query command
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
                    Global.themeStyle = "" + Conns.mySqlDataReader["preference_theme_style"].ToString();
                    Global.themeColor1 = convertToColor("" + Conns.mySqlDataReader["preference_theme_color_1"].ToString());
                    Global.themeColor2 = convertToColor("" + Conns.mySqlDataReader["preference_theme_color_2"].ToString());
                    Global.themeColor3 = convertToColor("" + Conns.mySqlDataReader["preference_theme_color_3"].ToString());
                    Global.themeColor4 = convertToColor("" + Conns.mySqlDataReader["preference_theme_color_4"].ToString());
                }

                i++;
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        public static Color convertToColor(string varStringColor)
        {
            Color convertedColor;

            //This gives us an array of 3 strings each representing a number in text form.
            string[] stringColor = varStringColor.Split(',');

            //converts the array of 3 strings in to an array of 3 ints.
            int[] splitInts = stringColor.Select(item => int.Parse(item)).ToArray();

            //takes each element of the array of 3 and passes it in to the correct slot
            convertedColor = Color.FromArgb(splitInts[0], splitInts[1], splitInts[2]);

            return convertedColor;
        }

        public static void loadComboBoxItems(ComboBox targetComboBox, string columnName, string query, String additionalOption)
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            targetComboBox.Items.Clear();    // Clear the records from datagrid
            if (additionalOption == "Blank")
            {

            }
            else if (additionalOption == "N/A")
            {
                targetComboBox.Items.Add("N/A");
            }
            else if (additionalOption == "All")
            {
                targetComboBox.Items.Add("All");
            }
            else if (additionalOption == "Others")
            {
                targetComboBox.Items.Add("<< Others >>");
            }

            if (numRows > 0)
            {
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Get the records
                {
                    targetComboBox.Items.Add("" + Conns.mySqlDataReader[columnName].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        public static string getComboBoxDetails(string columnName, string query)
        {
            String result = "";

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
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
                    result = "" + Conns.mySqlDataReader[columnName].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            return result;
        }

        public static string getReferenceDetails(string columnName, string query)
        {
            String result = "";

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
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
                    result = "" + Conns.mySqlDataReader[columnName].ToString();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            return result;
        }

        public static Boolean validateRecordExistence(string query)
        {
            Boolean result = false;

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader
            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found            

            if (numRows > 0)
            {
                result = true;
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            return result;
        }

        public static int generateNewID(int startOfSeries, string columnName, string query)
        {
            int result = startOfSeries;

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
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
                    result = Convert.ToInt32(Conns.mySqlDataReader[columnName].ToString()) + 1;
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            return result;
        }
    }
}
