using EXIN.Controller.Settings;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace EXIN
{
    public partial class UCExcelMenu : UserControl
    {
        public UCExcelMenu()
        {
            InitializeComponent();

            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Accounting Reports";
        }

        string busUnitName;
        string busUnit;
        string projectCode;
        string costCenterCode;
        string busUQuery;
        string categoryCode;
        int userId;

        DateTime dateCurrentMo;
        DateTime datePrevMo;
        DateTime dateYearBeg;
        DateTime datePrevYear;
        DateTime dateDec;
        DateTime dateConsoYE;
        DateTime dateLastLastYr;


        string queryCurrentMo;
        string queryPrevMo;
        string queryYearBeg;
        string queryMoBeg;
        string queryPrevYear;
        string queryConsoYE;
        string queryLastLastYr;


        string stringDec;

        int ExinOps;


        FS FSConnAll = new FS();
        MySqlConnect ConnAll = new MySqlConnect();

        //Preloader

        private void SetPreloader(bool displayLoader)
        {


            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {

                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {

                    this.Cursor = System.Windows.Forms.Cursors.Default;
                });
            }
        }

        private void UCExcelMenu_Load(object sender, EventArgs e)
        {
            fillBusUnit();
            dpkAcctgPeriod.Value = DateTime.Today;


        }

        public void fillBusUnit()
        {
            //LOOP THRU cmbBusUnit


            MySqlConnect MySqlConn = new MySqlConnect();

            userId = MySqlConn.myAccount;


            busUQuery = @"SELECT Unit_Code, Unit_Name, User_ID FROM (SELECT tbl_credentials_units.Unit_Code,
                                tbl_units.Unit_Name, tbl_credentials_units.User_ID 
                                FROM tbl_credentials_units INNER JOIN tbl_units ON tbl_credentials_units.Unit_Code = tbl_units.Unit_Code) sub
                                WHERE User_ID = " + userId +
                                " ORDER BY Unit_Name ASC;";


            MySqlCommand mySqlCmd = new MySqlCommand(busUQuery, MySqlConn.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            MySqlConn.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbBusUnit.Items.Add(row[1].ToString());
            }

        }

        public void fillProject()
        {
            cmbProject.Items.Clear();

            //Get BusUnit Code
            MySqlConnect ConnBusUnit = new MySqlConnect();
            MySqlCommand ConnBusUnitCmd = new MySqlCommand("SELECT `Unit_Code` FROM `tbl_units` WHERE `Unit_Name` = @Unit_Name", ConnBusUnit.mySqlconn);
            ConnBusUnitCmd.Parameters.AddWithValue("@Unit_Name", busUnitName);
            MySqlDataAdapter ConnBusUnitAdapter = new MySqlDataAdapter();
            ConnBusUnitAdapter.SelectCommand = ConnBusUnitCmd;
            System.Data.DataTable BusUnitDataTable = new System.Data.DataTable();
            ConnBusUnitAdapter.Fill(BusUnitDataTable);


            foreach (DataRow row in BusUnitDataTable.Rows)
            {
                busUnit = row[0].ToString();
            }

            ConnBusUnit.closeConnection();


            //LOOP THRU cmbProject

            MySqlConnect MySqlConn = new MySqlConnect();
            MySqlCommand mySqlCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Unit_Code` = @Unit_Code " +
                "ORDER BY `Project_Name` ASC", MySqlConn.mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@Unit_Code", busUnit);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            MySqlConn.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbProject.Items.Add(row[1].ToString());
            }


        }

        public void fillCostCenter()
        {
            cmbCostCenter.Items.Clear();


            //LOOP THRU cmbCostCenter

            MySqlConnect MySqlConn = new MySqlConnect();
            MySqlCommand mySqlCmd = new MySqlCommand("SELECT `CostCenter_Code`,`CostCenter_Name` FROM `tbl_costcenter`  " +
                "ORDER BY `CostCenter_Name` ASC", MySqlConn.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            MySqlConn.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbCostCenter.Items.Add(row[1].ToString());
            }


        }

        private void cmbBusUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
            fillProject();
            fillCostCenter();
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            cmbProject.Items.Clear();
            cmbCostCenter.Items.Clear();

            busUnit = "";
            projectCode = "";
            costCenterCode = "";
        }

        private void dpkAcctgPeriod_ValueChanged(object sender, EventArgs e)
        {
            dateCurrentMo = dpkAcctgPeriod.Value;
            datePrevMo = dateCurrentMo.AddMonths(-1);
            datePrevMo = new DateTime(datePrevMo.Year, datePrevMo.Month, DateTime.DaysInMonth(datePrevMo.Year, datePrevMo.Month));
            dateYearBeg = new DateTime(dateCurrentMo.Year, 1, 1);
            datePrevYear = dateYearBeg.AddYears(-1);
            dateConsoYE = new DateTime(dateCurrentMo.Year, 12, 31);
            dateLastLastYr = datePrevYear.AddYears(-1);

            txtCurrent.Text = dateCurrentMo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            txtPrevMonth.Text = datePrevMo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            txtYearBeg.Text = dateYearBeg.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            queryCurrentMo = dateCurrentMo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryPrevMo = datePrevMo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryYearBeg = dateYearBeg.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryMoBeg = datePrevMo.AddDays(1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryPrevYear = datePrevYear.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryConsoYE = dateConsoYE.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryLastLastYr = dateLastLastYr.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            stringDec = datePrevMo.Month.ToString();

        }


        private void populateFilterCodes()
        {
            this.Invoke((MethodInvoker)delegate
            {
                //Get BusUnit Code

                MySqlCommand ConnBusUnitCmd = new MySqlCommand("SELECT `Unit_Code` FROM `tbl_units` WHERE `Unit_Name` = @Unit_Name", ConnAll.mySqlconn);
                ConnBusUnitCmd.Parameters.AddWithValue("@Unit_Name", busUnitName);
                MySqlDataAdapter ConnBusUnitAdapter = new MySqlDataAdapter();
                ConnBusUnitAdapter.SelectCommand = ConnBusUnitCmd;
                System.Data.DataTable BusUnitDataTable = new System.Data.DataTable();
                ConnBusUnitAdapter.Fill(BusUnitDataTable);


                foreach (DataRow row in BusUnitDataTable.Rows)
                {
                    busUnit = row[0].ToString();
                }



                //Get Project Code


                MySqlCommand ProjectCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Project_Name` = @Project " +
                    "ORDER BY `Project_Name` ASC", ConnAll.mySqlconn);
                ProjectCmd.Parameters.AddWithValue("@Project", cmbProject.Text);
                MySqlDataAdapter ProjectAdapter = new MySqlDataAdapter();
                ProjectAdapter.SelectCommand = ProjectCmd;
                System.Data.DataTable ProjectDataTable = new System.Data.DataTable();
                ProjectAdapter.Fill(ProjectDataTable);

                foreach (DataRow row in ProjectDataTable.Rows)
                {
                    projectCode = row[0].ToString();
                }



                //Get Cost Center Code


                MySqlCommand mySqlCmd = new MySqlCommand("SELECT `CostCenter_Code`,`CostCenter_Name` FROM `tbl_costcenter` " +
                    "WHERE CostCenter_Name = @CostCenter  " +
                    "ORDER BY `CostCenter_Name` ASC", ConnAll.mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@CostCenter", cmbCostCenter.Text);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    costCenterCode = row[0].ToString();
                }


            });

        }


        public void fetchExcelCSV()
        {
            //Preloader Start
            SetPreloader(true);

            populateFilterCodes();





            string EXINExcelPath = @"C:\EXINReleases";
            string UploadPath = @"C:\EXINReleases\Uploads";
            string csvLastMo = "LastMonth.csv";
            string csvCurrentMo = "CurrentMonth.csv";
            string csvMonthBeg = "MonthBeg.csv";
            string csvYearBeg = "YearBeg.csv";
            string csvLastYear = "LastYear.csv";
            string csvTarget = "Target.csv";
            string csvZCA = "ChartOfAccounts.csv";
            string csvLastYearExpanded = "LastYearExpanded.csv";
            string csvOperatingDays = "OperatingDays.csv";
            string csvUnitCodeandName = "UnitCodeandName.csv";



            bool fileError = false;

            if (!Directory.Exists(EXINExcelPath))
            {
                // Try to create the directory.
                DirectoryInfo EXINdi = Directory.CreateDirectory(EXINExcelPath);
                MessageBox.Show("EXIN excel file directory was created successfully");
            }

            if (!Directory.Exists(UploadPath))
            {
                // Try to create the directory.
                DirectoryInfo Uploadsdi = Directory.CreateDirectory(UploadPath);
                MessageBox.Show("Uploads directory was created successfully");
            }

            string[] EXINfiles = Directory.GetFiles(EXINExcelPath);

            foreach (string file in EXINfiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

            string[] files = Directory.GetFiles(UploadPath);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }


            /*********Setup  LastMonth Cost***********/
            this.Invoke((MethodInvoker)delegate
            {
                FS FSCategoryCode = new FS();
                FSCategoryCode.mysqlQuery = @"SELECT `Category_Code`                                            
                                            FROM `tbl_units` WHERE `Unit_Code` = '" + busUnit + "'";


                FSCategoryCode.fetchCategoryCode();

                categoryCode = FSCategoryCode.categoryCode;




                if (stringDec != "12")
                {
                    if (categoryCode == null)
                    {

                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                    FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                    WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                         + " WHERE Transaction_Date between " + "'" + queryYearBeg + "'" + " AND " + "'" + queryPrevMo + "'" +
                                         "AND tbl_transaction.Status = 'Active' " +
                                         "AND Amount <> 0 " +
                                          "AND Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                          "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                          "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                         " ORDER BY ID ASC";
                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastMo, 9);
                    }
                    else
                    {
                        if (busUnit != null && projectCode == null && costCenterCode == null)
                        {
                            FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                    FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                    WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                   + " WHERE Transaction_Date between " + "'" + queryYearBeg + "'" + " AND " + "'" + queryPrevMo + "'" +
                                   "AND tbl_transaction.Status = 'Active' " +
                                    "AND Unit_Code = " + busUnit +
                                   " ORDER BY ID ASC";

                            FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastMo, 9);
                        }

                        else if (busUnit != null && projectCode != null && costCenterCode == null)
                        {
                            FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                    FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                    WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                               + " WHERE Transaction_Date between " + "'" + queryYearBeg + "'" + " AND " + "'" + queryPrevMo + "'" +
                               "AND tbl_transaction.Status = 'Active' " +
                                "AND Unit_Code = " + busUnit +
                                " AND tbl_transaction.Project_Code = " + projectCode +
                               " ORDER BY ID ASC";

                            FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastMo, 9);
                        }

                        else if (busUnit != null && projectCode != null && costCenterCode != null)
                        {
                            FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                    FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                    WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                               + " WHERE Transaction_Date between " + "'" + queryYearBeg + "'" + " AND " + "'" + queryPrevMo + "'" +
                               "AND tbl_transaction.Status = 'Active' " +
                                "AND Unit_Code = " + busUnit +
                                " AND tbl_transaction.Project_Code = " + projectCode +
                                " AND tbl_transaction.Project_Code = " + costCenterCode +
                               " ORDER BY ID ASC";

                            FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastMo, 9);


                        }
                        else if (busUnit == null && projectCode == null && costCenterCode == null)
                        {
                            FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                    FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                    WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                       + " WHERE Transaction_Date between " + "'" + queryYearBeg + "'" + " AND " + "'" + queryPrevMo + "'" +
                                       "AND tbl_transaction.Status = 'Active' " +
                                        "AND Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                        "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                        "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                       " ORDER BY ID ASC";
                            FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastMo, 9);
                        }

                        else
                        {
                            MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }



                    }

                }


                /*********Setup  CurrentMonth***********/


                if (categoryCode == null)
                {


                    FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                FROM `tbl_transaction` LEFT OUTER JOIN(SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                          + " WHERE Transaction_Date > " + "'" + queryPrevMo + "'" +
                                          " AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                                          "AND tbl_transaction.Status = 'Active' " +
                                          "AND Amount <> 0 " +
                                          "AND Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                          " AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                          " AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                          " ORDER BY ID ASC";

                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvCurrentMo, 9);

                }
                else
                {
                    if (busUnit != null && projectCode == null && costCenterCode == null)
                    {


                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                         + " WHERE Transaction_Date > " + "'" + queryPrevMo + "'" +
                         " AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                         "AND tbl_transaction.Status = 'Active' " +
                         "AND Unit_Code = " + busUnit +
                         " ORDER BY ID ASC";

                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvCurrentMo, 9);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode == null)
                    {
                        MessageBox.Show("Project");

                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                             + " WHERE Transaction_Date > " + "'" + queryPrevMo + "'" +
                                             " AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                                             "AND tbl_transaction.Status = 'Active' " +
                                             "AND Unit_Code = " + busUnit +
                                             " AND tbl_transaction.Project_Code = " + projectCode +
                                             " ORDER BY ID ASC";

                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvCurrentMo, 9);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode != null)
                    {
                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                         + " WHERE Transaction_Date > " + "'" + queryPrevMo + "'" +
                                         " AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                                         "AND tbl_transaction.Status = 'Active' " +
                                         "AND Unit_Code = " + busUnit +
                                         " AND tbl_transaction.Project_Code = " + projectCode +
                                         " AND tbl_transaction.CostCenter_Code = " + costCenterCode +
                                         " ORDER BY ID ASC";

                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvCurrentMo, 9);
                    }

                    else if (busUnit == null && projectCode == null && costCenterCode == null)
                    {
                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, Amount,Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                FROM `tbl_transaction` LEFT OUTER JOIN(SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                       + " WHERE Transaction_Date > " + "'" + queryPrevMo + "'" +
                                       " AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                                       "AND tbl_transaction.Status = 'Active' " +
                                       "AND Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                       " AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                       " AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                       " ORDER BY ID ASC";

                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvCurrentMo, 9);

                    }

                    else
                    {
                        MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }




                }



                /*********Set up Month Beg***********/



                if (categoryCode == null)
                {

                    FSConnAll.mysqlQuery = "SELECT '" + queryMoBeg + "'" + @"AS Date,'TbBegMo' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) AS GL
                                                            FROM tbl_transaction" +
                                                            " WHERE tbl_transaction.Transaction_Date <= " + "'" + queryPrevMo + "'" +
                                                             "AND Amount <> 0 " +
                                                            "AND tbl_transaction.Status = 'Active' " +
                                                            " GROUP BY GLSL;";


                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvMonthBeg, 8);


                }
                else
                {
                    if (busUnit != null && projectCode == null && costCenterCode == null)
                    {



                        FSConnAll.mysqlQuery = "SELECT '" + queryMoBeg + "'" + @"AS Date,'TbBegMo' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) AS GL
                                                            FROM tbl_transaction" +
                                                                " WHERE tbl_transaction.Transaction_Date <= " + "'" + queryPrevMo + "'" +
                                                                "AND tbl_transaction.Status = 'Active' " +
                                                                "AND tbl_transaction.Unit_Code = " + busUnit +
                                                                " GROUP BY GLSL;";


                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvMonthBeg, 8);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode == null)
                    {



                        FSConnAll.mysqlQuery = "SELECT '" + queryMoBeg + "'" + @"AS Date,'TbBegMo' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) AS GL
                                                            FROM tbl_transaction" +
                                                                " WHERE tbl_transaction.Transaction_Date <= " + "'" + queryPrevMo + "'" +
                                                                "AND tbl_transaction.Status = 'Active' " +
                                                                "AND tbl_transaction.Unit_Code = " + busUnit +
                                                                " AND tbl_transaction.Project_Code = " + projectCode +
                                                                " GROUP BY GLSL;";


                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvMonthBeg, 8);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode != null)
                    {

                        FSConnAll.mysqlQuery = "SELECT '" + queryMoBeg + "'" + @"AS Date,'TbBegMo' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) AS GL
                                                            FROM tbl_transaction" +
                                                                " WHERE tbl_transaction.Transaction_Date <= " + "'" + queryPrevMo + "'" +
                                                                "AND tbl_transaction.Status = 'Active' " +
                                                                "AND tbl_transaction.Unit_Code = " + busUnit +
                                                                " AND tbl_transaction.Project_Code = " + projectCode +
                                                                " AND tbl_transaction.CostCenter_Code = " + costCenterCode +
                                                                 " GROUP BY GLSL;";


                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvMonthBeg, 8);
                    }
                    else
                    {
                        MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }



                }





                /*********Set up Year Beg***********/



                if (categoryCode == null)
                {
                    FSConnAll.mysqlQuery = "SELECT '" + queryYearBeg + "'" + @"AS Date,'TbBegYr' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) 
                                                            FROM tbl_transaction" +
                                                            " WHERE tbl_transaction.Transaction_Date < " + "'" + queryYearBeg + "'" +
                                                            "AND tbl_transaction.Status = 'Active' " +
                                                             "AND Amount <> 0 " +
                                                            " GROUP BY GLSL;";


                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvYearBeg, 8);
                }
                else
                {
                    if (busUnit != null && projectCode == null && costCenterCode == null)
                    {

                        FSConnAll.mysqlQuery = "SELECT '" + queryYearBeg + "'" + @"AS Date,'TbBegYr' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) 
                                                            FROM tbl_transaction" +
                                                                " WHERE tbl_transaction.Transaction_Date < " + "'" + queryYearBeg + "'" +
                                                                "AND tbl_transaction.Status = 'Active' " +
                                                                "AND tbl_transaction.Unit_Code = " + busUnit +
                                                                " GROUP BY GLSL;";


                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvYearBeg, 8);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode == null)
                    {


                        FSConnAll.mysqlQuery = "SELECT '" + queryYearBeg + "'" + @"AS Date,'TbBegYr' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) 
                                                            FROM tbl_transaction" +
                                                                " WHERE tbl_transaction.Transaction_Date < " + "'" + queryYearBeg + "'" +
                                                                "AND tbl_transaction.Status = 'Active' " +
                                                                "AND tbl_transaction.Unit_Code = " + busUnit +
                                                                " AND tbl_transaction.Project_Code = " + projectCode +
                                                                " GROUP BY GLSL;";


                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvYearBeg, 8);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode != null)
                    {


                        FSConnAll.mysqlQuery = "SELECT '" + queryYearBeg + "'" + @"AS Date,'TbBegYr' AS Reference, GLSL, SUM(Amount) AS 'Debit(Credit)', '', '', '',LEFT(GLSL,3) 
                                                            FROM tbl_transaction" +
                                                                " WHERE tbl_transaction.Transaction_Date < " + "'" + queryYearBeg + "'" +
                                                                "AND tbl_transaction.Status = 'Active' " +
                                                                "AND tbl_transaction.Unit_Code = " + busUnit +
                                                                " AND tbl_transaction.Project_Code = " + projectCode +
                                                                " AND tbl_transaction.CostCenter_Code = " + costCenterCode +
                                                                " GROUP BY GLSL;";


                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvYearBeg, 8);
                    }
                    else
                    {
                        MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }



                }





                /*********Set up Last Year***********/


                if (categoryCode == null)
                {
                    FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, SUM(Amount),Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                            FROM `tbl_transaction` LEFT OUTER JOIN(SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                            WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                                            + " WHERE Transaction_Date >= " + "'" + queryPrevYear + "'" +
                                                           " AND Transaction_Date < " + "'" + queryYearBeg + "'" +
                                                           "AND tbl_transaction.Status = 'Active' " +
                                                            "AND Amount <> 0 " +
                                                           "AND Unit_Code = " + "'%" + busUnit + "%'" +
                                                           " AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                                           " AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                                           " GROUP BY GLSL, Transaction_Date ORDER BY Transaction_Date ASC";



                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYear, 9);
                }
                else
                {

                    if (busUnit != null && projectCode == null && costCenterCode == null)
                    {

                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, SUM(Amount),Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                             FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                             WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                             + " WHERE Transaction_Date >= " + "'" + queryPrevYear + "'" +
                                            " AND Transaction_Date < " + "'" + queryYearBeg + "'" +
                                            "AND tbl_transaction.Status = 'Active' " +
                                            "AND Unit_Code = " + busUnit +
                                            " GROUP BY GLSL, Transaction_Date ORDER BY Transaction_Date ASC";



                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYear, 9);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode == null)
                    {


                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, SUM(Amount),Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                             FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                             WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                              + " WHERE Transaction_Date >= " + "'" + queryPrevYear + "'" +
                                             " AND Transaction_Date < " + "'" + queryYearBeg + "'" +
                                             "AND tbl_transaction.Status = 'Active' " +
                                             "AND Unit_Code = " + busUnit +
                                             " AND tbl_transaction.Project_Code = " + projectCode +
                                             " GROUP BY GLSL, Transaction_Date ORDER BY Transaction_Date ASC";



                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYear, 9);
                    }

                    else if (busUnit != null && projectCode != null && costCenterCode != null)
                    {


                        FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, if(Voucher_No = '', Particulars, Voucher_No), tbl_transaction.GLSL, SUM(Amount),Item_Description,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts
                                                             FROM `tbl_transaction` LEFT OUTER JOIN (SELECT `GLSL`,`ExpandedAccounts` FROM `tbl_chartofaccounts` 
                                                             WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + ") Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                             + " WHERE Transaction_Date >= " + "'" + queryPrevYear + "'" +
                                            " AND Transaction_Date < " + "'" + queryYearBeg + "'" +
                                            "AND tbl_transaction.Status = 'Active' " +
                                            "AND Unit_Code = " + busUnit +
                                            " AND tbl_transaction.Project_Code = " + projectCode +
                                            " AND tbl_transaction.CostCenter_Code = " + costCenterCode +
                                            " GROUP BY GLSL, Transaction_Date ORDER BY Transaction_Date ASC";



                        FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYear, 9);
                    }
                    else
                    {
                        MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }

                /*********Set up Target***********/

                if (busUnit != null && projectCode == null && costCenterCode == null)
                {

                    FSConnAll.mysqlQuery = @"SELECT tbl_budget_accountclass.Budget_Date,tbl_budget_accountclass.AccountClass_Code,tbl_expandedpnlaccounts.ExpandedAccountDesc,
                                                    tbl_budget_accountclass.Budget_Amount 
                                                    FROM tbl_budget_accountclass LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON  
                                                    tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts"
                              + " WHERE tbl_budget_accountclass.Budget_Date >= " + "'" + queryYearBeg + "'" +
                              " AND tbl_budget_accountclass.Budget_Date <= " + "'" + queryCurrentMo + "'" +
                               "AND tbl_budget_accountclass.Unit_Code = " + busUnit +
                              @" ORDER BY  tbl_budget_accountclass.Budget_Date ASC;";


                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvTarget, 4);

                }
                else
                {


                    FSConnAll.mysqlQuery = @"SELECT tbl_budget_accountclass.Budget_Date,tbl_budget_accountclass.AccountClass_Code,tbl_expandedpnlaccounts.ExpandedAccountDesc,
                                                    tbl_budget_accountclass.Budget_Amount 
                                                    FROM tbl_budget_accountclass LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON  
                                                    tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts"
                       + " WHERE tbl_budget_accountclass.Budget_Date >= " + "'" + queryYearBeg + "'" +
                       " AND tbl_budget_accountclass.Budget_Date <= " + "'" + queryCurrentMo + "'" +
                       @" ORDER BY  tbl_budget_accountclass.Budget_Date ASC;";



                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvTarget, 4);

                }

                /*********Set up Last Year Expanded***********/

                if (busUnit != null && projectCode == null && costCenterCode == null)
                {
                    FSConnAll.mysqlQuery = @"SELECT tbl_lastyear_upload.LastYear_Date,tbl_lastyear_upload.AccountClass_Code,tbl_expandedpnlaccounts.ExpandedAccountDesc,
                                                    tbl_lastyear_upload.Amount 
                                                    FROM tbl_lastyear_upload LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON  
                                                    tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts"
                                                    + " WHERE tbl_lastyear_upload.LastYear_Date >= " + "'" + queryPrevYear + "'" +
                                                    " AND tbl_lastyear_upload.LastYear_Date < " + "'" + queryYearBeg + "'" +
                                                   "AND tbl_lastyear_upload.Unit_Code = " + busUnit +
                                                  @" ORDER BY  tbl_lastyear_upload.LastYear_Date ASC;";

                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYearExpanded, 4);

                }
                else
                {
                    FSConnAll.mysqlQuery = @"SELECT tbl_lastyear_upload.LastYear_Date,tbl_lastyear_upload.AccountClass_Code,tbl_expandedpnlaccounts.ExpandedAccountDesc,
                                                    tbl_lastyear_upload.Amount 
                                                    FROM tbl_lastyear_upload LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON  
                                                    tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts"
                                                     + " WHERE tbl_lastyear_upload.LastYear_Date >= " + "'" + queryPrevYear + "'" +
                                                     " AND tbl_lastyear_upload.LastYear_Date < " + "'" + queryYearBeg + "'" +
                                                     @" ORDER BY  tbl_lastyear_upload.LastYear_Date ASC;";

                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYearExpanded, 4);

                }

                /*********Operation Days***********/



                if (busUnit != null && projectCode != null && costCenterCode != null)
                {
                    FSConnAll.mysqlQuery = @"SELECT Trans_Id, Op_Date, Unit_Code,
                                                    MonOpDays,User
                                                    FROM tbl_opdays "
                                                    + " WHERE Op_Date >= " + "'" + queryPrevYear + "'" +
                                                    " AND Op_Date <= " + "'" + queryCurrentMo + "'" +
                                                     " AND Unit_Code = " + busUnit +
                                                    @" ORDER BY Op_Date ASC;";


                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvOperatingDays, 5);
                }
                else
                {

                    FSConnAll.mysqlQuery = @"SELECT Trans_Id, Op_Date, Unit_Code,
                                                    MonOpDays,User
                                                    FROM tbl_opdays "
                                                    + " WHERE Op_Date >= " + "'" + queryPrevYear + "'" +
                                                    " AND OP_Date <= " + "'" + queryCurrentMo + "'" +
                                                    @" ORDER BY Op_Date ASC;";


                    FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvOperatingDays, 5);


                }

                /*********BusUnit***********/

                FSConnAll.mysqlQuery = @"SELECT Unit_Code, Unit_Name FROM tbl_units
                                                    WHERE Unit_Code = " + busUnit;


                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvUnitCodeandName, 2);



                /*********Setup  Chart of Accounts***********/

                if (categoryCode == null)
                {
                    FS FSConnzCA = new FS();
                    FSConnzCA.mysqlQuery = @"SELECT GL, GLSL, MAX(GL_Account), MAX(SL_Account), ' ', ' ', ' ', ExpandedAccounts, MAX(ExpandedAccountDesc)
                                            FROM  `tbl_chartofaccounts` WHERE `Category_Code` LIKE '%" + categoryCode + "%'"
                                            + " GROUP BY GLSL"
                                            + " ORDER BY GL,GLSL";

                    FSConnzCA.fetchCSVTransactions(UploadPath + "\\" + csvZCA, 9);
                }
                else
                {
                    FS FSConnzCA = new FS();
                    FSConnzCA.mysqlQuery = @"SELECT `GL`, `GLSL`,`GL_Account`,`SL_Account`,' ',' ',' ',`ExpandedAccounts`,`ExpandedAccountDesc`                                         
                                                            FROM `tbl_chartofaccounts` WHERE `Category_Code` = '" + categoryCode + "'"
                                                            + " ORDER BY GL,GLSL";
                    FSConnzCA.fetchCSVTransactions(UploadPath + "\\" + csvZCA, 9);
                }




            }); //End of Method Invoker

            /**************OPEN MAIN EXCEL FILE*******************/



            //Excel.Application excel = new Excel.Application();
            //excel.Visible = false;



            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkTaxCredentials(902);

            ExinOps = Conn.ExinOps;


            var fileHandler = new FileHandler();

            if (ExinOps == 1)
            {
                // exportToExcel("EXIN-Excel Ops.xlsb", "EXIN-II-Excel Ops.xlsb");
                fileHandler.copyExcelFile("EXIN-Excel Ops.xlsb", "EXIN-II-Excel Ops.xlsb");

            }
            else
            {
                //exportToExcel("EXIN-Excel.xlsb", "EXIN-II-Excel.xlsb");
                fileHandler.copyExcelFile("EXIN-Excel.xlsb", "EXIN-II-Excel.xlsb");
            }

            Process[] excelProcesses = Process.GetProcessesByName("excel");
            foreach (Process p in excelProcesses)
            {
                if (string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    p.Kill();
                }
            }


            //    SetPreloader(false);

            //MessageBox.Show("Excel Templates Exported at C:\\EXINReleases", "File Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("explorer.exe", @"c:\EXINReleases");
        }


        private void exportToExcel(string rawFile, string fileName)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = false;
            Workbook workbook = excel.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + rawFile);
            Worksheet TMSheet = (Worksheet)workbook.Sheets["TM"];
            TMSheet.Select();
            TMSheet.Unprotect();

            Range currentMoRange;
            Range prevMoRange;
            Range begYearRange;
            Range projectNameRange;
            Range projectCodeRange;
            Range costCenterNameRange;
            Range busUnitNameRange;
            Range busUnitCodeRange;

            currentMoRange = (Range)TMSheet.Cells[10, 4];
            currentMoRange.Value = txtCurrent.Text;

            prevMoRange = (Range)TMSheet.Cells[10, 6];
            prevMoRange.Value = txtPrevMonth.Text;

            begYearRange = (Range)TMSheet.Cells[10, 8];
            begYearRange.Value = txtYearBeg.Text;

            this.Invoke((MethodInvoker)delegate
            {
                busUnitNameRange = (Range)TMSheet.Cells[6, 3];
                busUnitNameRange.Value = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);

                busUnitCodeRange = (Range)TMSheet.Cells[7, 3];
                busUnitCodeRange.Value = busUnit;

                //projectNameRange = (Range)TMSheet.Cells[6, 3];
                //projectNameRange.Value = cmbProject.GetItemText(cmbProject.SelectedItem);

                //projectCodeRange = (Range)TMSheet.Cells[7, 3];
                //projectCodeRange.Value = projectCode;

                //costCenterNameRange = (Range)TMSheet.Cells[7, 3];
                //costCenterNameRange.Value = cmbCostCenter.GetItemText(cmbCostCenter.SelectedItem);
            });



            workbook.SaveAs(@"C:\EXINReleases\" + fileName);


            //excel.Visible = true;
            //excel.WindowState = XlWindowState.xlMaximized;


            //Excel CleanUp

            GC.Collect();
            GC.WaitForPendingFinalizers();



            Marshal.FinalReleaseComObject(TMSheet);
            Marshal.FinalReleaseComObject(currentMoRange);
            Marshal.FinalReleaseComObject(prevMoRange);
            Marshal.FinalReleaseComObject(begYearRange);

            workbook.Close(Type.Missing, Type.Missing, Type.Missing);

            Marshal.FinalReleaseComObject(workbook);


            excel.Quit();

            Marshal.FinalReleaseComObject(excel);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fetchExcelCSV();
        }

        private void btnCommi_Click(object sender, EventArgs e)
        {

            string EXINExcelPath = @"C:\EXINReleases";
            string UploadPath = @"C:\EXINReleases\Uploads";
            bool fileError = false;

            if (!Directory.Exists(EXINExcelPath))
            {
                // Try to create the directory.
                DirectoryInfo EXINdi = Directory.CreateDirectory(EXINExcelPath);
                MessageBox.Show("EXIN excel file directory was created successfully");
            }

            if (!Directory.Exists(UploadPath))
            {
                // Try to create the directory.
                DirectoryInfo Uploadsdi = Directory.CreateDirectory(UploadPath);
                MessageBox.Show("Uploads directory was created successfully");
            }

            string[] EXINfiles = Directory.GetFiles(EXINExcelPath);

            foreach (string file in EXINfiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

            string[] files = Directory.GetFiles(UploadPath);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }


            Excel.Application excel = new Excel.Application();
            excel.Visible = false;


            Workbook workbook = excel.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "Commi Upload Template.xlsm");

            workbook.SaveAs(@"C:\EXINReleases\Commi Upload Template.xlsm");

            //Excel CleanUp

            GC.Collect();
            GC.WaitForPendingFinalizers();

            workbook.Close(Type.Missing, Type.Missing, Type.Missing);

            Marshal.FinalReleaseComObject(workbook);

            excel.Quit();

            Marshal.FinalReleaseComObject(excel);

            Process[] excelProcesses = Process.GetProcessesByName("excel");
            foreach (Process p in excelProcesses)
            {
                if (string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    p.Kill();
                }
            }

            MessageBox.Show("Commi Upload Template exported at C:\\EXINReleases", "File Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("explorer.exe", @"c:\EXINReleases");
        }


        public void fetchExcelDashBoard()
        {
            //Preloader Start
            SetPreloader(true);

            populateFilterCodes();


            string EXINExcelPath = @"C:\EXINReleases";
            string UploadPath = @"C:\EXINReleases\Uploads";
            string csvCurrentMo = "CurrentMonth.csv"; //YTD
            string csvLastYear = "LastYear.csv";
            string csvTarget = "Target.csv";
            string csvzSBU = "zSBU.csv";


            bool fileError = false;

            if (!Directory.Exists(EXINExcelPath))
            {
                // Try to create the directory.
                DirectoryInfo EXINdi = Directory.CreateDirectory(EXINExcelPath);
                MessageBox.Show("EXIN excel file directory was created successfully");
            }

            if (!Directory.Exists(UploadPath))
            {
                // Try to create the directory.
                DirectoryInfo Uploadsdi = Directory.CreateDirectory(UploadPath);
                MessageBox.Show("Uploads directory was created successfully");
            }

            string[] EXINfiles = Directory.GetFiles(EXINExcelPath);

            foreach (string file in EXINfiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

            string[] files = Directory.GetFiles(UploadPath);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }



            this.Invoke((MethodInvoker)delegate
            {
                FS FSCategoryCode = new FS();
                FSCategoryCode.mysqlQuery = @"SELECT `Category_Code`                                            
                                            FROM `tbl_units` WHERE `Unit_Code` = '" + busUnit + "'";


                FSCategoryCode.fetchCategoryCode();

                categoryCode = FSCategoryCode.categoryCode;

                /*********Setup  Current YTD***********/



                FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, Voucher_No, tbl_transaction.GLSL, SUM(Amount),Particulars,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts, Unit_Code
                                                FROM `tbl_transaction` LEFT OUTER JOIN(SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                          + " WHERE Transaction_Date >= " + "'" + queryYearBeg + "'" +
                                          " AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                                          "AND tbl_transaction.Status = 'Active' " +
                                          "AND Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                          "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                          "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                          "GROUP BY tbl_transaction.Unit_Code ,tbl_transaction.GLSL, Transaction_Date ORDER BY Transaction_Date ASC";

                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvCurrentMo, 10);




                /*********Set up Last Year***********/



                FSConnAll.mysqlQuery = @"SELECT Voucher_Type, Transaction_Date, Voucher_No, tbl_transaction.GLSL, SUM(Amount),Particulars,'',LEFT(tbl_transaction.GLSL,3), Chart.ExpandedAccounts, Unit_Code
                                                            FROM `tbl_transaction` LEFT OUTER JOIN(SELECT `GLSL`,MAX(`ExpandedAccounts`) AS ExpandedAccounts FROM `tbl_chartofaccounts` 
                                                            WHERE `Category_Code` LIKE '%" + categoryCode + "%'" + " GROUP BY `GLSL`) Chart ON tbl_transaction.GLSL = Chart.GLSL"
                                                        + " WHERE Transaction_Date >= " + "'" + queryPrevYear + "'" +
                                                       " AND Transaction_Date < " + "'" + queryYearBeg + "'" +
                                                       "AND tbl_transaction.Status = 'Active' " +
                                                       "AND Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                                       "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                                       "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" +
                                                        "GROUP BY tbl_transaction.Unit_Code ,tbl_transaction.GLSL, Transaction_Date ORDER BY Transaction_Date ASC";



                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYear, 10);


                /*********Set up Target***********/


                FSConnAll.mysqlQuery = @"SELECT tbl_budget_accountclass.Budget_Date,tbl_budget_accountclass.AccountClass_Code,tbl_expandedpnlaccounts.ExpandedAccountDesc,
                                                    tbl_budget_accountclass.Budget_Amount, tbl_budget_accountclass.Unit_Code 
                                                    FROM tbl_budget_accountclass LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON  
                                                    tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts"
                                                    + " WHERE tbl_budget_accountclass.Budget_Date >= " + "'" + queryYearBeg + "'" +
                                                    " AND tbl_budget_accountclass.Budget_Date <= " + "'" + queryCurrentMo + "'" +
                                                     "AND tbl_budget_accountclass.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                                    @" ORDER BY  tbl_budget_accountclass.Budget_Date ASC;";




                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvTarget, 5);


                /*********Dashboard SBU's***********/


                FSConnAll.mysqlQuery = @"SELECT tbl_units.Unit_Code, tbl_units.Unit_Name, tbl_units.Date_Open, tbl_units.Region_Name, 
                                                    tbl_units.Area_Name,tbl_units.Category_Code, tbl_corporations.Corp_Name 
                                                    FROM tbl_units 
                                                    LEFT OUTER JOIN tbl_corporations ON tbl_units.Corp_Code = tbl_corporations.Corp_Code";



                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvzSBU, 7);




            }); //End of Method Invoker

            /**************OPEN MAIN EXCEL FILE*******************/

            Excel.Application excel = new Excel.Application();
            excel.Visible = false;


            Workbook workbook = excel.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "PnL-Dashboard.xlsm");




            //Worksheet TMSheet = (Worksheet)workbook.Sheets["TM"];
            //TMSheet.Select();
            //TMSheet.Unprotect();

            //Range currentMoRange;
            //Range prevMoRange;
            //Range begYearRange;
            //Range projectNameRange;
            //Range costCenterNameRange;
            //Range busUnitNameRange;
            //Range busUnitCodeRange;

            //currentMoRange = (Range)TMSheet.Cells[10, 4];
            //currentMoRange.Value = txtCurrent.Text;

            //prevMoRange = (Range)TMSheet.Cells[10, 6];
            //prevMoRange.Value = txtPrevMonth.Text;

            //begYearRange = (Range)TMSheet.Cells[10, 8];
            //begYearRange.Value = txtYearBeg.Text;

            //this.Invoke((MethodInvoker)delegate
            //{
            //    busUnitNameRange = (Range)TMSheet.Cells[6, 3];
            //    busUnitNameRange.Value = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);

            //    busUnitCodeRange = (Range)TMSheet.Cells[7, 3];
            //    busUnitCodeRange.Value = busUnit;

            //    //projectNameRange = (Range)TMSheet.Cells[6, 3];
            //    //projectNameRange.Value = cmbProject.GetItemText(cmbProject.SelectedItem);

            //    //costCenterNameRange = (Range)TMSheet.Cells[7, 3];
            //    //costCenterNameRange.Value = cmbCostCenter.GetItemText(cmbCostCenter.SelectedItem);
            //});



            workbook.SaveAs(@"C:\EXINReleases\PnL-Dashboard.xlsm");


            //excel.Visible = true;
            //excel.WindowState = XlWindowState.xlMaximized;


            //Excel CleanUp

            GC.Collect();
            GC.WaitForPendingFinalizers();



            //Marshal.FinalReleaseComObject(TMSheet);
            //Marshal.FinalReleaseComObject(currentMoRange);
            //Marshal.FinalReleaseComObject(prevMoRange);
            //Marshal.FinalReleaseComObject(begYearRange);

            workbook.Close(Type.Missing, Type.Missing, Type.Missing);

            Marshal.FinalReleaseComObject(workbook);

            excel.Quit();

            Marshal.FinalReleaseComObject(excel);

            Process[] excelProcesses = Process.GetProcessesByName("excel");
            foreach (Process p in excelProcesses)
            {
                if (string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    p.Kill();
                }
            }


            SetPreloader(false);

            MessageBox.Show("Excel Template Exported at C:\\EXINReleases", "File Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("explorer.exe", @"c:\EXINReleases");



        }


        private void fetchPNLConso()
        {
            SetPreloader(true);

            populateFilterCodes();


            string EXINExcelPath = @"C:\EXINReleases";
            string UploadPath = @"C:\EXINReleases\Uploads";

            string csvActualDataUnitCorpBrand = "ActualDataUnitCorpBrand.csv";
            string csvBudgetDataUnitCorpBrand = "BudgetDataUnitCorpBrand.csv";
            string csvLastYearDataUnitCorpBrand = "LastYearDataUnitCorpBrand.csv";
            string csvOPDaysDataUnitCorpBrand = "OPDaysDataUnitCorpBrand.csv";
            string csvOPDaysLastYearDataUnitCorpBrand = "OPDaysLastYearDataUnitCorpBrand.csv";
            string csvOPDaysLastLyDataUnitCorpBrand = "OPDaysLastLyDataUnitCorpBrand.csv";
            string csvTargetLyDataUnitCorpBrand = "TargetLyDataUnitCorpBrand.csv";
            string csvLastLyDataUnitCorpBrand = "LastLyDataUnitCorpBrand.csv";


            bool fileError = false;

            if (!Directory.Exists(EXINExcelPath))
            {
                // Try to create the directory.
                DirectoryInfo EXINdi = Directory.CreateDirectory(EXINExcelPath);
                MessageBox.Show("EXIN excel file directory was created successfully");
            }

            if (!Directory.Exists(UploadPath))
            {
                // Try to create the directory.
                DirectoryInfo Uploadsdi = Directory.CreateDirectory(UploadPath);
                MessageBox.Show("Uploads directory was created successfully");
            }

            string[] EXINfiles = Directory.GetFiles(EXINExcelPath);

            foreach (string file in EXINfiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

            string[] files = Directory.GetFiles(UploadPath);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

            this.Invoke((MethodInvoker)delegate
            {
                /*********Setup Actual Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT DISTINCT
                                                        Month(tbl_transaction.Transaction_Date) AS MonthNow,
                                                        tbl_transaction.Unit_Code,
                                                        tbl_units_conso .Unit_Name,
                                                        Chart.ExpandedAccounts,
                                                        SUM(`Amount`) AS `Amount`,
                                                        tbl_units_conso .Corp_Code,
                                                        tbl_units_conso .Corp_Name,
                                                        tbl_units_conso .Category_Code,
                                                        tbl_units_conso .Category_Name
                                                        FROM `tbl_transaction`
                                                        LEFT OUTER JOIN(
                                                        SELECT DISTINCT GLSL, ExpandedAccounts
                                                        FROM tbl_chartofaccounts WHERE ExpandedAccounts <> 0) Chart
                                                        ON tbl_transaction.GLSL = Chart.GLSL
                                                        LEFT OUTER JOIN (
                                                        SELECT DISTINCT 
	                                                        tbl_units.Unit_Code,
                                                            tbl_units.Unit_Name,
                                                            tbl_units.Corp_Code,
                                                            tbl_corporations.Corp_Name,
                                                            tbl_units.Category_Code,
                                                            tbl_category.Category_Name
                                                        FROM tbl_units
                                                        LEFT OUTER JOIN tbl_corporations
                                                        ON tbl_units.Corp_Code = tbl_corporations.Corp_Code
                                                        LEFT OUTER JOIN tbl_category
                                                        ON tbl_units.Category_Code = tbl_category.Category_Code
                                                        ) tbl_units_conso 
                                                        ON tbl_transaction.Unit_Code = tbl_units_conso.Unit_Code
                                                        WHERE tbl_transaction.Status = 'Active'
                                                        AND Transaction_Date >= " + "'" + queryYearBeg + "'" +
                                                        "AND Transaction_Date <= " + "'" + queryCurrentMo + "'" +
                                                        @" AND Amount <> 0
                                                        AND ExpandedAccounts <> 0
                                                        GROUP BY MonthNow, Unit_Code, Chart.ExpandedAccounts
                                                        ORDER BY MonthNow, Unit_Name;";




                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvActualDataUnitCorpBrand, 9);


                /*********Setup Budget Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT DISTINCT
                                                    Month(tbl_budget_accountclass.Budget_Date) AS MonthNow,
                                                    tbl_budget_accountclass.Unit_Code,
                                                    tbl_units_conso.Unit_Name,
                                                    tbl_budget_accountclass.AccountClass_Code,
                                                    SUM(`Budget_Amount`) AS `Amount`,
                                                    tbl_units_conso.Corp_Code,
                                                    tbl_units_conso.Corp_Name,
                                                    tbl_units_conso.Category_Code,
                                                    tbl_units_conso.Category_Name
                                                    FROM `tbl_budget_accountclass`
                                                    LEFT OUTER JOIN (
                                                    SELECT DISTINCT 
	                                                    tbl_units.Unit_Code,
                                                        tbl_units.Unit_Name,
                                                        tbl_units.Corp_Code,
                                                        tbl_corporations.Corp_Name,
                                                        tbl_units.Category_Code,
                                                        tbl_category.Category_Name
                                                    FROM tbl_units
                                                    LEFT OUTER JOIN tbl_corporations
                                                    ON tbl_units.Corp_Code = tbl_corporations.Corp_Code
                                                    LEFT OUTER JOIN tbl_category
                                                    ON tbl_units.Category_Code = tbl_category.Category_Code
                                                    ) tbl_units_conso 
                                                    ON  tbl_budget_accountclass.Unit_Code = tbl_units_conso.Unit_Code
                                                    WHERE Budget_Date >=  " + "'" + queryYearBeg + "'" +
                                                    "AND Budget_Date <= " + "'" + queryConsoYE + "'" +
                                                    @" AND Budget_Amount <> 0
                                                    GROUP BY MonthNow, Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                                    ORDER BY MonthNow, Unit_Name;";




                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvBudgetDataUnitCorpBrand, 9);

                /*********Setup  Target Last Year Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT DISTINCT
                                                    Month(tbl_budget_accountclass.Budget_Date) AS MonthNow,
                                                    tbl_budget_accountclass.Unit_Code,
                                                    tbl_units_conso.Unit_Name,
                                                    tbl_budget_accountclass.AccountClass_Code,
                                                    SUM(`Budget_Amount`) AS `Amount`,
                                                    tbl_units_conso.Corp_Code,
                                                    tbl_units_conso.Corp_Name,
                                                    tbl_units_conso.Category_Code,
                                                    tbl_units_conso.Category_Name
                                                    FROM `tbl_budget_accountclass`
                                                    LEFT OUTER JOIN (
                                                    SELECT DISTINCT 
	                                                    tbl_units.Unit_Code,
                                                        tbl_units.Unit_Name,
                                                        tbl_units.Corp_Code,
                                                        tbl_corporations.Corp_Name,
                                                        tbl_units.Category_Code,
                                                        tbl_category.Category_Name
                                                    FROM tbl_units
                                                    LEFT OUTER JOIN tbl_corporations
                                                    ON tbl_units.Corp_Code = tbl_corporations.Corp_Code
                                                    LEFT OUTER JOIN tbl_category
                                                    ON tbl_units.Category_Code = tbl_category.Category_Code
                                                    ) tbl_units_conso 
                                                    ON  tbl_budget_accountclass.Unit_Code = tbl_units_conso.Unit_Code
                                                    WHERE Budget_Date >=  " + "'" + queryPrevYear + "'" +
                                                    "AND Budget_Date <= " + "'" + queryYearBeg + "'" +
                                                    @" AND Budget_Amount <> 0
                                                    GROUP BY MonthNow, Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                                    ORDER BY MonthNow, Unit_Name;";




                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvTargetLyDataUnitCorpBrand, 9);

                /*********Setup LastYear Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT DISTINCT
                                                    Month(tbl_lastyear_upload.LastYear_Date) AS MonthNow,
                                                    tbl_lastyear_upload.Unit_Code,
                                                    tbl_units_conso.Unit_Name,
                                                    tbl_lastyear_upload.AccountClass_Code,
                                                    SUM(`Amount`) AS `Amount`,
                                                    tbl_units_conso.Corp_Code,
                                                    tbl_units_conso.Corp_Name,
                                                    tbl_units_conso.Category_Code,
                                                    tbl_units_conso.Category_Name
                                                    FROM `tbl_lastyear_upload`
                                                    LEFT OUTER JOIN (
                                                    SELECT DISTINCT 
	                                                    tbl_units.Unit_Code,
                                                        tbl_units.Unit_Name,
                                                        tbl_units.Corp_Code,
                                                        tbl_corporations.Corp_Name,
                                                        tbl_units.Category_Code,
                                                        tbl_category.Category_Name
                                                    FROM tbl_units
                                                    LEFT OUTER JOIN tbl_corporations
                                                    ON tbl_units.Corp_Code = tbl_corporations.Corp_Code
                                                    LEFT OUTER JOIN tbl_category
                                                    ON tbl_units.Category_Code = tbl_category.Category_Code
                                                    ) tbl_units_conso 
                                                    ON  tbl_lastyear_upload.Unit_Code = tbl_units_conso.Unit_Code
                                                    WHERE LastYear_Date >=  " + "'" + queryPrevYear + "'" +
                                                    "AND LastYear_Date < " + "'" + queryYearBeg + "'" +
                                                   @" AND Amount <> 0
                                                    GROUP BY MonthNow, Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                                    ORDER BY MonthNow, Unit_Name;";




                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastYearDataUnitCorpBrand, 9);

                /*********Setup Last Last Year Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT DISTINCT
                                                    Month(tbl_lastyear_upload.LastYear_Date) AS MonthNow,
                                                    tbl_lastyear_upload.Unit_Code,
                                                    tbl_units_conso.Unit_Name,
                                                    tbl_lastyear_upload.AccountClass_Code,
                                                    SUM(`Amount`) AS `Amount`,
                                                    tbl_units_conso.Corp_Code,
                                                    tbl_units_conso.Corp_Name,
                                                    tbl_units_conso.Category_Code,
                                                    tbl_units_conso.Category_Name
                                                    FROM `tbl_lastyear_upload`
                                                    LEFT OUTER JOIN (
                                                    SELECT DISTINCT 
	                                                    tbl_units.Unit_Code,
                                                        tbl_units.Unit_Name,
                                                        tbl_units.Corp_Code,
                                                        tbl_corporations.Corp_Name,
                                                        tbl_units.Category_Code,
                                                        tbl_category.Category_Name
                                                    FROM tbl_units
                                                    LEFT OUTER JOIN tbl_corporations
                                                    ON tbl_units.Corp_Code = tbl_corporations.Corp_Code
                                                    LEFT OUTER JOIN tbl_category
                                                    ON tbl_units.Category_Code = tbl_category.Category_Code
                                                    ) tbl_units_conso 
                                                    ON  tbl_lastyear_upload.Unit_Code = tbl_units_conso.Unit_Code
                                                    WHERE LastYear_Date >=  " + "'" + queryLastLastYr + "'" +
                                                    "AND LastYear_Date < " + "'" + queryPrevYear + "'" +
                                                   @" AND Amount <> 0
                                                    GROUP BY MonthNow, Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                                    ORDER BY MonthNow, Unit_Name;";




                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvLastLyDataUnitCorpBrand, 9);


                /*********Setup Actual OpDays Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT Month(Op_Date), Unit_Code, MonOpDays FROM tbl_opdays
                                                     WHERE OP_Date >=  " + "'" + queryYearBeg + "'" +
                                                     "AND OP_Date <= " + "'" + queryCurrentMo + "'";

                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvOPDaysDataUnitCorpBrand, 3);

                /*********Setup Last Year OpDays Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT Month(Op_Date), Unit_Code, MonOpDays FROM tbl_opdays
                                                     WHERE OP_Date >=  " + "'" + queryPrevYear + "'" +
                                                     "AND OP_Date < " + "'" + queryYearBeg + "'";

                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvOPDaysLastYearDataUnitCorpBrand, 3);


                /*********Setup Last Last Year OpDays Per Branch per Corp per Brand***********/


                FSConnAll.mysqlQuery = @"SELECT Month(Op_Date), Unit_Code, MonOpDays FROM tbl_opdays
                                                     WHERE OP_Date >=  " + "'" + queryLastLastYr + "'" +
                                                     "AND OP_Date < " + "'" + queryPrevYear + "'";

                FSConnAll.fetchCSVTransactions(UploadPath + "\\" + csvOPDaysLastLyDataUnitCorpBrand, 3);


            });

            //Copy excel template to Exin Releases

            var fileHandler = new FileHandler();
            fileHandler.copyExcelFile("PNL Consolidated.xlsb", "Consolidated PNL.xlsb");


            //Excel.Application excel = new Excel.Application();
            //excel.Visible = false;


            //Workbook workbookSecond = excel.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "PNL Consolidated.xlsb");
            //workbookSecond.SaveAs(@"C:\EXINReleases\Consolidated PNL.xlsb");

            ////Excel CleanUp

            //GC.Collect();
            //GC.WaitForPendingFinalizers();


            //workbookSecond.Close(Type.Missing, Type.Missing, Type.Missing);

            //Marshal.FinalReleaseComObject(workbookSecond);

            ////Close all Excel Instances

            //excel.Quit();

            //Marshal.FinalReleaseComObject(excel);

            //SetPreloader(false);

            ////MessageBox.Show("Excel Template Exported at C:\\EXINReleases", "File Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("explorer.exe", @"c:\EXINReleases");


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var loader = new WaitFormFunc();
            loader.Show();

            fetchExcelCSV();

            this.Cursor = Cursors.Default;

            loader.Close();
        }

        private void btnConso_Click(object sender, EventArgs e)
        {
            var loader = new WaitFormFunc();
            loader.Show();

            fetchPNLConso();


            this.Cursor = Cursors.Default;

            loader.Close();
        }
    }
}
