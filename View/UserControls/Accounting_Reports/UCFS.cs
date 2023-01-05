using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCFS : UserControl
    {
        int page_1 = 0;
        int dataperPage = 20;

        static int one = 1;
        static int two = 2;
        static int three = 3;

        string strSearch;
        string searchContent;

        string busUnitName;
        string busUnit;
        string projectCode;
        string costCenterCode;
        string busUQuery;
        string COAName;
        string COACode;
        string SupplierCode;
        string SupplierName;
        int userId;
        string SQLStatement;
        string activePage;
        string categoryCode;


        DateTime DateFrom;
        DateTime DateTo;

        string queryDateFrom;
        string queryDateTo;


        MySqlConnect ConnAll = new MySqlConnect();
        FS FSConn = new FS();


        public UCFS()
        {
            InitializeComponent();
            prgPreloader.Hide();
        }

        Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper hScrollHelper;

        private void UCSOA_Load(object sender, EventArgs e)
        {
            hScrollHelper = new Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper(dgvSOA, gunaHScrollBar1, true);
            hScrollHelper.UpdateScrollBar();

            grpFilter.Hide();

            fillBusUnit();



            //readSOAData();
        }

        /***********************READ DATA**********************/
        public void readSOAData()
        {

            this.Invoke((MethodInvoker)delegate
            {
                SetPreloader(true);

                populateFilterCodes();

                //Initialize Dates

                DateFrom = dtpFrom.Value;
                DateTo = dtpTo.Value;

                queryDateFrom = DateFrom.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                queryDateTo = DateTo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);


                //DATAGRIDVIEW PROPERTIES

                dgvSOA.ColumnCount = 11;
                dgvSOA.Columns[0].Name = "Date";
                dgvSOA.Columns[1].Name = "Vchr_Type";
                dgvSOA.Columns[2].Name = "Vchr_No";
                dgvSOA.Columns[3].Name = "GLSL";
                dgvSOA.Columns[4].Name = "Amount";
                dgvSOA.Columns[5].Name = "Particulars";
                dgvSOA.Columns[6].Name = "Bus_Unit";
                dgvSOA.Columns[7].Name = "Check No.";
                dgvSOA.Columns[8].Name = "Supplier";
                dgvSOA.Columns[9].Name = "User";


                dgvSOA.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgvSOA.Columns[4].DefaultCellStyle.Format = "n2";


                dgvSOA.Columns[0].Frozen = false;
                dgvSOA.Columns[1].Frozen = false;
                dgvSOA.Columns[2].Frozen = false;
                dgvSOA.Columns[3].Frozen = false;
                dgvSOA.Columns[4].Frozen = false;
                dgvSOA.Columns[5].Frozen = false;
                dgvSOA.Columns[6].Frozen = false;
                dgvSOA.Columns[7].Frozen = false;
                dgvSOA.Columns[8].Frozen = false;
                dgvSOA.Columns[9].Frozen = false;

                dgvSOA.Columns[0].Width = 100;
                dgvSOA.Columns[1].Width = 50;
                dgvSOA.Columns[2].Width = 100;
                dgvSOA.Columns[3].Width = 100;
                dgvSOA.Columns[4].Width = 100;
                dgvSOA.Columns[5].Width = 100;
                dgvSOA.Columns[6].Width = 100;
                dgvSOA.Columns[7].Width = 100;
                dgvSOA.Columns[8].Width = 125;
                dgvSOA.Columns[9].Width = 100;

                //dgvChecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //SELECTION MODE

                dgvSOA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSOA.MultiSelect = false;


                //Filter based on Dropdown







                if (strSearch == "" || strSearch == null)
                {

                    if (busUnit != null && COACode == null && SupplierCode == null)
                    {


                        SQLStatement = @"SELECT `Ref_Date`, `Voucher_Type`, if(`Voucher_No`='',`Particulars`,`Voucher_No`), `GLSL`, `Amount`, 
                                                `Particulars`, `Unit_Code`,if(`Ref_No`='','-',`Ref_No`), 
                                                if(Payee_Code='','-',tbl_data.Supplier_Name), `Prepared_by`
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN(SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM
                                                tbl_suppliers) tbl_data
                                                ON
                                                tbl_transaction.Payee_Code = tbl_data.Supplier_Code
                                                WHERE Unit_Code = " + "'" + busUnit + "'" +
                                                "AND `Ref_Date` >= " + "'" + queryDateFrom + "'" +
                                                "AND `Ref_Date` <= " + "'" + queryDateTo + "'" +
                                                "AND `Status` = 'Active' " +
                                                "ORDER BY `Ref_Date` DESC;";


                        FSConn.mysqlQuery = SQLStatement;

                        FSConn.retrieveSOA(dgvSOA);
                    }
                    else if (busUnit != null && COACode != null && SupplierCode == null)
                    {


                        SQLStatement = @"SELECT `Ref_Date`, `Voucher_Type`, if(`Voucher_No`='',`Particulars`,`Voucher_No`), `GLSL`, `Amount`, 
                                                `Particulars`, `Unit_Code`,if(`Ref_No`='','-',`Ref_No`), 
                                                if(Payee_Code='','-',tbl_data.Supplier_Name), `Prepared_by`
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN(SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM
                                                tbl_suppliers) tbl_data
                                                ON
                                                tbl_transaction.Payee_Code = tbl_data.Supplier_Code
                                                WHERE Unit_Code = " + "'" + busUnit + "'" +
                                            "AND `GLSL` = " + "'" + COACode + "'" +
                                            "AND `Ref_Date` >= " + "'" + queryDateFrom + "'" +
                                            "AND `Ref_Date` <= " + "'" + queryDateTo + "'" +
                                            "AND `Status` = 'Active' " +
                                            "ORDER BY `Ref_Date` DESC;";


                        FSConn.mysqlQuery = SQLStatement;

                        FSConn.retrieveSOA(dgvSOA);
                    }
                    else if (busUnit != null && COACode == null && SupplierCode != null)
                    {


                        SQLStatement = @"SELECT `Ref_Date`, `Voucher_Type`, if(`Voucher_No`='',`Particulars`,`Voucher_No`), `GLSL`, `Amount`, 
                                                `Particulars`, `Unit_Code`,if(`Ref_No`='','-',`Ref_No`), 
                                                if(Payee_Code='','-',tbl_data.Supplier_Name) as supplierName, `Prepared_by`
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN(SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM
                                                tbl_suppliers) tbl_data
                                                ON
                                                tbl_transaction.Payee_Code = tbl_data.Supplier_Code
                                                WHERE Unit_Code = " + "'" + busUnit + "'" +
                                                "AND tbl_data.Supplier_Code = " + "'" + SupplierCode + "'" +
                                                "AND `Ref_Date` >= " + "'" + queryDateFrom + "'" +
                                                "AND `Ref_Date` <= " + "'" + queryDateTo + "'" +
                                                "AND `Status` = 'Active' " +
                                                "ORDER BY `Ref_Date` DESC;";



                        FSConn.mysqlQuery = SQLStatement;

                        FSConn.retrieveSOA(dgvSOA);
                    }
                    else if (busUnit == null && COACode == null && SupplierCode == null)
                    {


                        SQLStatement = @"SELECT `Ref_Date`, `Voucher_Type`, if(`Voucher_No`='',`Particulars`,`Voucher_No`), `GLSL`, `Amount`, 
                                                `Particulars`, `Unit_Code`,if(`Ref_No`='','-',`Ref_No`), 
                                                if(Payee_Code='','-',tbl_data.Supplier_Name) as supplierName, `Prepared_by`
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN(SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM
                                                tbl_suppliers) tbl_data
                                                ON
                                                tbl_transaction.Payee_Code = tbl_data.Supplier_Code
                                                WHERE `Ref_Date` >= " + "'" + queryDateFrom + "'" +
                                                "AND `Ref_Date` <= " + "'" + queryDateTo + "'" +
                                                "AND `Status` = 'Active' " +
                                                "ORDER BY `Ref_Date` DESC;";



                        FSConn.mysqlQuery = SQLStatement;

                        FSConn.retrieveSOA(dgvSOA);
                    }



                }
                else //WITHJSEARCH VALUE
                {


                    MessageBox.Show("Enter Search Data");


                }
            });



            SetPreloader(false);


        }

        public void readAllData()
        {
            this.Invoke((MethodInvoker)delegate
            {
                SetPreloader(true);

                populateFilterCodes();

                //Initialize Dates

                DateFrom = dtpFrom.Value;
                DateTo = dtpTo.Value;

                queryDateFrom = DateFrom.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                queryDateTo = DateTo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);


                //DATAGRIDVIEW PROPERTIES

                dgvSOA.ColumnCount = 11;
                dgvSOA.Columns[0].Name = "Date";
                dgvSOA.Columns[1].Name = "Vchr_Type";
                dgvSOA.Columns[2].Name = "Vchr_No";
                dgvSOA.Columns[3].Name = "GLSL";
                dgvSOA.Columns[4].Name = "Amount";
                dgvSOA.Columns[5].Name = "Particulars";
                dgvSOA.Columns[6].Name = "Bus_Unit";
                dgvSOA.Columns[7].Name = "Check No.";
                dgvSOA.Columns[8].Name = "Supplier";
                dgvSOA.Columns[9].Name = "User";


                dgvSOA.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgvSOA.Columns[4].DefaultCellStyle.Format = "n2";


                dgvSOA.Columns[0].Frozen = false;
                dgvSOA.Columns[1].Frozen = false;
                dgvSOA.Columns[2].Frozen = false;
                dgvSOA.Columns[3].Frozen = false;
                dgvSOA.Columns[4].Frozen = false;
                dgvSOA.Columns[5].Frozen = false;
                dgvSOA.Columns[6].Frozen = false;
                dgvSOA.Columns[7].Frozen = false;
                dgvSOA.Columns[8].Frozen = false;
                dgvSOA.Columns[9].Frozen = false;

                dgvSOA.Columns[0].Width = 100;
                dgvSOA.Columns[1].Width = 50;
                dgvSOA.Columns[2].Width = 100;
                dgvSOA.Columns[3].Width = 100;
                dgvSOA.Columns[4].Width = 100;
                dgvSOA.Columns[5].Width = 100;
                dgvSOA.Columns[6].Width = 100;
                dgvSOA.Columns[7].Width = 100;
                dgvSOA.Columns[8].Width = 125;
                dgvSOA.Columns[9].Width = 100;

                //dgvChecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //SELECTION MODE

                dgvSOA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSOA.MultiSelect = false;


                //Filter based on Dropdown







                if (strSearch == "" || strSearch == null)
                {

                    if (busUnit != null && COACode == null && SupplierCode == null)
                    {


                        SQLStatement = @"SELECT `Ref_Date`, `Voucher_Type`, if(`Voucher_No`='',`Particulars`,`Voucher_No`), `GLSL`, `Amount`, 
                                                `Particulars`, `Unit_Code`,if(`Ref_No`='','-',`Ref_No`), 
                                                if(Payee_Code='','-',tbl_data.Supplier_Name), `Prepared_by`
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN(SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM
                                                tbl_suppliers) tbl_data
                                                ON
                                                tbl_transaction.Payee_Code = tbl_data.Supplier_Code
                                                WHERE Unit_Code = " + "'" + busUnit + "'" +
                                                      "AND `Ref_Date` >= " + "'" + queryDateFrom + "'" +
                                                      "AND `Ref_Date` <= " + "'" + queryDateTo + "'" +
                                                      "AND `Status` = 'Active' " +
                                                      "ORDER BY `Ref_Date` DESC;";


                        FSConn.mysqlQuery = SQLStatement;

                        FSConn.retrieveSOA(dgvSOA);
                    }
                    else if (busUnit != null && COACode != null && SupplierCode == null)
                    {


                        SQLStatement = @"SELECT `Ref_Date`, `Voucher_Type`, if(`Voucher_No`='',`Particulars`,`Voucher_No`), `GLSL`, `Amount`, 
                                                `Particulars`, `Unit_Code`,if(`Ref_No`='','-',`Ref_No`), 
                                                if(Payee_Code='','-',tbl_data.Supplier_Name), `Prepared_by`
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN(SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM
                                                tbl_suppliers) tbl_data
                                                ON
                                                tbl_transaction.Payee_Code = tbl_data.Supplier_Code
                                                WHERE Unit_Code = " + "'" + busUnit + "'" +
                                                "AND `GLSL` = " + "'" + COACode + "'" +
                                                "AND `Ref_Date` >= " + "'" + queryDateFrom + "'" +
                                                "AND `Ref_Date` <= " + "'" + queryDateTo + "'" +
                                                "AND `Status` = 'Active' " +
                                                "ORDER BY `Ref_Date` DESC;";


                        FSConn.mysqlQuery = SQLStatement;

                        FSConn.retrieveSOA(dgvSOA);
                    }

                }
                else //WITHJSEARCH VALUE
                {


                    MessageBox.Show("Enter Search Data");


                }
            });



            SetPreloader(false);



        }


        private void sumStatement()
        {
            if (strSearch != null)
            {

                SQLStatement = "SELECT FORMAT(SUM(Amount),2) FROM tbl_transaction " +
                                "WHERE (`Transaction_Date` LIKE  " + "'%" + searchContent + "%'" + "AND Unit_Code LIKE " + "'%" + busUnit + "%'" + "AND GLSL LIKE " + "'%" + COACode + "%'" + "AND Project_Code LIKE " + "'%" + projectCode + "%'" + "AND CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + ")"
                                + " OR (`Voucher_Type` LIKE " + "'%" + searchContent + "%'" + "AND Unit_Code LIKE " + "'%" + busUnit + "%'" + "AND GLSL LIKE " + "'%" + COACode + "%'" + "AND Project_Code LIKE " + "'%" + projectCode + "%'" + "AND CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + ")"
                                + " OR (`Voucher_No` LIKE " + "'%" + searchContent + "%'" + "AND Unit_Code LIKE " + "'%" + busUnit + "%'" + "AND GLSL LIKE " + "'%" + COACode + "%'" + "AND Project_Code LIKE " + "'%" + projectCode + "%'" + "AND CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + ")"
                                + " OR (`Amount` LIKE " + "'%" + searchContent + "%'" + "AND Unit_Code LIKE " + "'%" + busUnit + "%'" + "AND GLSL LIKE " + "'%" + COACode + "%'" + "AND Project_Code LIKE " + "'%" + projectCode + "%'" + "AND CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + ")"
                                + " OR (`Particulars` LIKE " + "'%" + searchContent + "%'" + "AND Unit_Code LIKE " + "'%" + busUnit + "%'" + "AND GLSL LIKE " + "'%" + COACode + "%'" + "AND Project_Code LIKE " + "'%" + projectCode + "%'" + "AND CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + ")"
                                + " ORDER BY `Transaction_Date` DESC, `ID` ASC";

            }

            FSConn.mysqlQuery = SQLStatement;

            FSConn.SumSL(txtTotal);
        }

        /***************COMBOBOX FILL*********************/

        public void fillBusUnit()
        {
            //LOOP THRU cmbBusUnit



            userId = ConnAll.myAccount;


            busUQuery = @"SELECT Unit_Code, Unit_Name, User_ID FROM (SELECT tbl_credentials_units.Unit_Code,
                                tbl_units.Unit_Name, tbl_credentials_units.User_ID 
                                FROM tbl_credentials_units INNER JOIN tbl_units ON tbl_credentials_units.Unit_Code = tbl_units.Unit_Code) sub
                                WHERE User_ID = " + userId +
                                " ORDER BY Unit_Name ASC;";


            MySqlCommand mySqlCmd = new MySqlCommand(busUQuery, ConnAll.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            ConnAll.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbBusUnit.Items.Add(row[1].ToString());
            }

        }

        public void fillChartOfAccounts()
        {
            //Set up Brand

            FS FSCategoryCode = new FS();
            FSCategoryCode.mysqlQuery = @"SELECT `Category_Code`                                            
                                            FROM `tbl_units` WHERE `Unit_Code` = '" + busUnit + "'";


            FSCategoryCode.fetchCategoryCode();

            categoryCode = FSCategoryCode.categoryCode;



            cmbCOA.Items.Clear();

            /*********Setup  Chart of Accounts***********/

            if (categoryCode != null)
            {

                //LOOP THRU cmbCostCenter


                MySqlCommand mySqlCmd = new MySqlCommand(@"SELECT `GL`, `GLSL`,`GL_Account`,`SL_Account` 
                                                            FROM `tbl_chartofaccounts` WHERE `Category_Code` = '" + categoryCode + "'"
                                                            + " ORDER BY GL,GLSL", ConnAll.mySqlconn);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);


                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    cmbCOA.Items.Add(row[3].ToString());
                }
            }

        }

        public void fillSupplierCode()
        {
            cmbSupplier.Items.Clear();


            //LOOP THRU cmbSupplier


            MySqlCommand mySqlCmd = new MySqlCommand("SELECT DISTINCT `Supplier_Code`, `Supplier_Name` FROM `tbl_suppliers`  " +
                "ORDER BY `Supplier_Name` ASC", ConnAll.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbSupplier.Items.Add(row[1].ToString());
            }
        }

        private void cmbBusUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
            populateFilterCodes();
            fillChartOfAccounts();
            fillSupplierCode();
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            cmbCOA.Items.Clear();
            cmbSupplier.Items.Clear();

            busUnit = null;
            projectCode = null;
            costCenterCode = null;
            COACode = null;
            SupplierCode = null;

        }

        /*************************FETCH COMBO BOX CODES*****************/

        private void populateFilterCodes()
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


            //Get Chart of Account Code

            MySqlCommand COACmd = new MySqlCommand("SELECT `GLSL`, `SL_Account` FROM `tbl_chartofaccounts`  " +
                "WHERE SL_Account = @GLSL  " +
                "ORDER BY `GL` ASC", ConnAll.mySqlconn);
            COACmd.Parameters.AddWithValue("@GLSL", cmbCOA.Text);
            MySqlDataAdapter COAAdapter = new MySqlDataAdapter();
            COAAdapter.SelectCommand = COACmd;
            System.Data.DataTable COADataTable = new System.Data.DataTable();
            COAAdapter.Fill(COADataTable);

            foreach (DataRow row in COADataTable.Rows)
            {
                COACode = row[0].ToString();
            }

            ConnAll.closeConnection();

            //Get Supplier Code

            MySqlCommand SupplierCmd = new MySqlCommand("SELECT `Supplier_Code` FROM `tbl_suppliers`  WHERE Supplier_Name = @Supplier", ConnAll.mySqlconn);
            SupplierCmd.Parameters.AddWithValue("@Supplier", cmbSupplier.Text);
            MySqlDataAdapter SupplierAdapter = new MySqlDataAdapter();
            SupplierAdapter.SelectCommand = SupplierCmd;
            System.Data.DataTable SupplierDataTable = new System.Data.DataTable();
            SupplierAdapter.Fill(SupplierDataTable);

            foreach (DataRow row in SupplierDataTable.Rows)
            {
                SupplierCode = row[0].ToString();
            }

            ConnAll.closeConnection();


        }

        /**************************EXCEL EXPORT***********************/

        private void replaceDgvString()
        {


            //for (int rowCnt = 0; rowCnt != dgvSOA.Rows.Count; rowCnt++)
            //{

            //    for (int colCnt = 0; colCnt != 10; colCnt++)
            //    {
            //      var cellValue = dgvSOA.Rows[rowCnt].Cells[colCnt].Value.ToString();
            //      cellValue = Regex.Replace(cellValue, @"\t|\n|\r|[,]", "");
            //      MessageBox.Show(cellValue);
            //    }

            //}



            //foreach (Guna2DataGridView row in dgvSOA.Rows)
            //{

            //    //for (int i = 0; i != 10 ; i++)
            //    //{

            //        //MessageBox.Show(row[0, 0].ToString());
            //        //RowStyle[].Value = Regex.Replace(c.Value.ToString(), @"\t|\n|\r|[,]", "");
            //        //MessageBox.Show(c.Value.ToString());

            //    //}
            //}
        }


        private void ExportCSV()
        {
            //readAllData();
            //replaceDgvString();

            if (dgvSOA.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";

                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dgvSOA.Columns.Count;
                            string columnNames = "";
                            int rowCount = dgvSOA.Rows.Count;

                            var outputCsv = new string[rowCount + 1];

                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvSOA.Columns[i].HeaderText + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvSOA.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < columnCount - 1; j++)
                                {
                                    var cellValue = dgvSOA.Rows[i - 1].Cells[j].Value.ToString();
                                    //MessageBox.Show(cellValue.ToString());
                                    cellValue = Regex.Replace(cellValue, @"\t|\n|\r|[,]", "");
                                    outputCsv[i] += cellValue + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            readSOAData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            gunaTransition1.Show(grpFilter);
            grpFilter.BringToFront();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            cmbCOA.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            gunaTransition1.Hide(grpFilter);
        }


        private void SetPreloader(bool displayLoader)
        {
            this.Invoke((MethodInvoker)delegate
            {

                if (displayLoader)
                {
                    prgPreloader.Show();
                    prgPreloader.BringToFront();
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    System.Windows.Forms.Application.DoEvents();

                }
                else
                {
                    prgPreloader.Hide();
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    System.Windows.Forms.Application.DoEvents();

                }
            });
        }


        private void btnApplyFilter_Click(object sender, EventArgs e)
        {

            try
            {
                Thread threadInput = new Thread(readSOAData);
                threadInput.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //gunaTransition1.Hide(grpFilter);
            grpFilter.Hide();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }

        private void totalStatement()
        {
            int sum = 0;
            for (int i = 0; i < dgvSOA.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvSOA.Rows[i].Cells[4].Value);
            }
            txtTotal.Text = sum.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            readSOAData();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            strSearch = txtSearch.Text;
            searchContent = txtSearch.Text;
        }
    }
}
