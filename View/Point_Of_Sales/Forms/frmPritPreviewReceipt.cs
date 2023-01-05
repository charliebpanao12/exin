using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXIN.View.Point_Of_Sales.Reports;

namespace EXIN.Point_Of_Sales
{
    public partial class frmPritPreviewReceipt : Form
    {
        public frmPritPreviewReceipt()
        {
            InitializeComponent();
        }

        private void frmPritPreviewReceipt_Load(object sender, EventArgs e)
        {
            // Declaring Variables
            var varDataTable = new DataTable();

            // Preparing the columns of varDataTable
            #region varDataTable
            varDataTable.Columns.Add("DataColumn1");
            varDataTable.Columns.Add("DataColumn2");
            varDataTable.Columns.Add("DataColumn3");
            varDataTable.Columns.Add("DataColumn4");
            varDataTable.Columns.Add("DataColumn5");
            varDataTable.Columns.Add("DataColumn6");
            varDataTable.Columns.Add("DataColumn7");
            varDataTable.Columns.Add("DataColumn8");
            varDataTable.Columns.Add("DataColumn9");
            varDataTable.Columns.Add("DataColumn10");
            varDataTable.Columns.Add("DataColumn11");
            varDataTable.Columns.Add("DataColumn12");
            varDataTable.Columns.Add("DataColumn13");
            varDataTable.Columns.Add("DataColumn14");
            varDataTable.Columns.Add("DataColumn15");
            varDataTable.Columns.Add("DataColumn16");
            varDataTable.Columns.Add("DataColumn17");
            varDataTable.Columns.Add("DataColumn18");
            varDataTable.Columns.Add("DataColumn19");
            varDataTable.Columns.Add("DataColumn20");
            varDataTable.Columns.Add("DataColumn21");
            varDataTable.Columns.Add("DataColumn22");
            varDataTable.Columns.Add("DataColumn23");
            varDataTable.Columns.Add("DataColumn24");
            varDataTable.Columns.Add("DataColumn25");
            varDataTable.Columns.Add("DataColumn26");
            varDataTable.Columns.Add("DataColumn27");
            varDataTable.Columns.Add("DataColumn28");
            varDataTable.Columns.Add("DataColumn29");
            varDataTable.Columns.Add("DataColumn30");
            varDataTable.Columns.Add("DataColumn31");
            varDataTable.Columns.Add("DataColumn32");
            varDataTable.Columns.Add("DataColumn33");
            varDataTable.Columns.Add("DataColumn34");
            varDataTable.Columns.Add("DataColumn35");
            varDataTable.Columns.Add("DataColumn36");
            varDataTable.Columns.Add("DataColumn37");
            varDataTable.Columns.Add("DataColumn38");
            varDataTable.Columns.Add("DataColumn39");
            varDataTable.Columns.Add("DataColumn40");
            varDataTable.Columns.Add("DataColumn41");
            varDataTable.Columns.Add("DataColumn42");
            varDataTable.Columns.Add("DataColumn43");
            varDataTable.Columns.Add("DataColumn44");
            varDataTable.Columns.Add("DataColumn45");
            varDataTable.Columns.Add("DataColumn46");
            varDataTable.Columns.Add("DataColumn47");
            varDataTable.Columns.Add("DataColumn48");
            varDataTable.Columns.Add("DataColumn49");
            varDataTable.Columns.Add("DataColumn50");
            #endregion;

            // Fetch data from the database
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_inventory_products_masterlist ORDER BY product_id ASC;", Conns.mySqlconn);     // Create a query command
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
                    // Fill the data for the varDataTable
                    varDataTable.Rows.Add(
                                    "" + Conns.mySqlDataReader["product_id"].ToString(),
                                    "" + Conns.mySqlDataReader["item_name"].ToString(),
                                    "" + Conns.mySqlDataReader["selling_price"].ToString(),
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "");
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Preparing for printing
            CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //reportDocument.Load(Application.StartupPath + "/Resources/Point_Of_Sales/CrystalReport1.rpt");
            reportDocument = new CrystalReport1();
            reportDocument.SetDataSource(varDataTable);

            // Setting Parameters
            reportDocument.SetParameterValue("parCompanyName", "This is my Company");
            reportDocument.SetParameterValue("parFooter", "This is my footer");

            // Print-preview the document
            reportViewer.ReportSource = reportDocument;
            reportViewer.Zoom(100);
        }
    }
}
