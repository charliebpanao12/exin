using EXIN.Model.Accounting_Reports;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace EXIN.Controller.Accounting_Report
{


    public class ctrlFillComboBoxes : MySqlConnect
    {

        public void getBusUnitsName(ComboBox combobox)
        {
            var conn = new MySqlConnect();


            query = mdlComboBoxes.mdlBusUnitNames;


            var cmd = new MySqlCommand(query, conn.mySqlconn);

            cmd.Parameters.AddWithValue("@userId", conn.myAccount);

            var adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);



            foreach (DataRow row in dataTable.Rows)
            {
                combobox.Items.Add(row[1].ToString());
            }

            combobox.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }

            conn.closeConnection();
        }

        public void getPNLAccountName(ComboBox combobox)
        {
            var conn = new MySqlConnect();


            query = mdlComboBoxes.mdlPNLAccounts;


            var cmd = new MySqlCommand(query, conn.mySqlconn);

            var adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);



            foreach (DataRow row in dataTable.Rows)
            {
                combobox.Items.Add(row[1].ToString());
            }

            combobox.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }

            conn.closeConnection();
        }

        public void getBrandName(ComboBox combobox)
        {
            var conn = new MySqlConnect();


            query = mdlComboBoxes.mdlBrandName;


            var cmd = new MySqlCommand(query, conn.mySqlconn);

            var adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);



            foreach (DataRow row in dataTable.Rows)
            {
                combobox.Items.Add(row[1].ToString());
            }

            combobox.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }

            conn.closeConnection();
        }

        public void getUnitCode(string UnitName, Guna2HtmlLabel label)
        {
            var conn = new MySqlConnect();


            query = mdlComboBoxes.mdlUnitCode;


            var cmd = new MySqlCommand(query, conn.mySqlconn);

            cmd.Parameters.AddWithValue("@Unit_Name", UnitName);

            var adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);



            foreach (DataRow row in dataTable.Rows)
            {
                label.Text = row[0].ToString();
            }

            conn.closeConnection();
        }

        public void getBrandCode(string BrandName, Guna2HtmlLabel label)
        {
            var conn = new MySqlConnect();


            query = mdlComboBoxes.mdlBrandCode;


            var cmd = new MySqlCommand(query, conn.mySqlconn);

            cmd.Parameters.AddWithValue("@Brand_Name", BrandName);

            var adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);



            foreach (DataRow row in dataTable.Rows)
            {
                label.Text = row[0].ToString();
            }

            conn.closeConnection();
        }

        public void getPNLCode(string PNLName, Guna2HtmlLabel label)
        {
            var conn = new MySqlConnect();


            query = mdlComboBoxes.mdlPNLCode;


            var cmd = new MySqlCommand(query, conn.mySqlconn);

            cmd.Parameters.AddWithValue("@PNLCode_Name", PNLName);

            var adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            var dataTable = new DataTable();
            adapter.Fill(dataTable);



            foreach (DataRow row in dataTable.Rows)
            {
                label.Text = row[0].ToString();
            }

            conn.closeConnection();
        }

    }
}
