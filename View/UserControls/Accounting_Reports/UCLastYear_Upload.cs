using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScrollBars = System.Windows.Forms.ScrollBars;

namespace EXIN
{
    public partial class UCLastYear_Upload : UserControl
    {


        string busUnitName;
        string busUnit;
        string busUQuery;
        int userId;
        string SQLStatement;

        int lastYearUnitCode;
        int lastYearAccountClassCode;

        int lastYearFltrUnitCode;
        string queryFltrUnitCode;

        string lastYearFlterUnitName;

        int lastYearFltrAccountClassCode;
        string queryFltrAccountClassCode;

        DateTime fltrDateFrom;
        DateTime fltrDateTo;

        string queryFlterDateFrom;
        string queryFlterDateTo;


        MySqlConnect ConnAll = new MySqlConnect();
        LastYearData LastYearConn = new LastYearData();


        public UCLastYear_Upload()
        {
            InitializeComponent();
            btnCheckUncheck.Hide();
            btnCancel.Hide();


            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Last Year Data Setup";
        }


        private void UCLastYear_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("Select Last Year Parameters then click Apply to run Last Year Summary", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtpToDate.Value = DateTime.Now;
            dtpLastYearDate.Value = DateTime.Now;
        }

        /***********************READ DATA**********************/
        public void readLastYearData()
        {

            dgvLastYear.ColumnCount = 6;
            dgvLastYear.Columns[0].Name = "No.";
            dgvLastYear.Columns[1].Name = "Last Year Date";
            dgvLastYear.Columns[2].Name = "Store";
            dgvLastYear.Columns[3].Name = "Last Year Amount";
            dgvLastYear.Columns[4].Name = "Account";
            dgvLastYear.Columns[5].Name = "User";


            dgvLastYear.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvLastYear.Columns[3].DefaultCellStyle.Format = "n2";


            dgvLastYear.Columns[0].Frozen = false;
            dgvLastYear.Columns[1].Frozen = false;
            dgvLastYear.Columns[2].Frozen = false;
            dgvLastYear.Columns[3].Frozen = false;
            dgvLastYear.Columns[4].Frozen = false;
            dgvLastYear.Columns[5].Frozen = false;


            dgvLastYear.Columns[0].Width = 50;
            dgvLastYear.Columns[1].Width = 115;
            dgvLastYear.Columns[2].Width = 175;
            dgvLastYear.Columns[3].Width = 125;
            dgvLastYear.Columns[4].Width = 220;
            dgvLastYear.Columns[5].Width = 125;

            //SELECTION MODE

            dgvLastYear.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLastYear.MultiSelect = false;

            SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id, tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,
            tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name
            FROM `tbl_lastyear_upload`
            LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
            LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON 
            tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts
            LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
            ORDER BY tbl_units.Unit_Name, tbl_lastyear_upload.LastYear_Date, tbl_lastyear_upload.AccountClass_Code ASC";


            LastYearConn.mysqlQuery = SQLStatement;

            LastYearConn.retrieveLastYear(dgvLastYear);


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


        public void fillAccountClassCode()
        {
            //LOOP THRU cmbClass


            userId = ConnAll.myAccount;


            SQLStatement = @"SELECT `ExpandedAccounts`, `ExpandedAccountDesc` FROM `tbl_expandedpnlaccounts`
                                       ORDER BY `ExpandedAccounts` ASC ;";

            MySqlCommand mySqlCmd = new MySqlCommand(SQLStatement, ConnAll.mySqlconn); ;
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            ConnAll.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbAccountClass.Items.Add(row[1].ToString());

            }

            cmbAccountClass.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }

        }


        private void cmbBusUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            busUnit = "";

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



            ConnAll.closeConnection();


        }

        /**************************EXCEL EXPORT***********************/

        private void replaceDgvString()
        {
            bool fileError = false;

            foreach (DataGridViewRow row in dgvLastYear.Rows)
            {

                foreach (DataGridViewCell c in row.Cells)
                {

                    if (c.Value is string)
                    {
                        c.Value = Regex.Replace(c.Value.ToString(), @"\t|\n|\r|[,]", "");
                    }
                    else
                    {
                        continue;
                    }

                }
            }
        }


        private void ExportCSV()
        {
            readFlterLastYearData();
            replaceDgvString();

            if (dgvLastYear.Rows.Count > 0)
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
                            int columnCount = dgvLastYear.Columns.Count - 2;
                            string columnNames = "";
                            int rowCount = dgvLastYear.Rows.Count;

                            var outputCsv = new string[rowCount + 1];

                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvLastYear.Columns[i].HeaderText + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvLastYear.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvLastYear.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
            readFlterLastYearData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;


        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }


        private void totalStatement()
        {



        }



        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            readFlterLastYearData();
        }


        private void retrieveLastYearCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbBusUnit.Text + "'";

            LastYearConn.mysqlQuery = SQLStatement;

            LastYearConn.retrieveUnitCodeNo();

            lastYearUnitCode = LastYearConn.lastYearUnitCode;


            //Retrieve ExpandedClassCode


            SQLStatement = "SELECT `ExpandedAccounts` FROM `tbl_expandedpnlaccounts` WHERE `ExpandedAccountDesc` = " + "'" + cmbAccountClass.Text + "'";

            LastYearConn.mysqlQuery = SQLStatement;

            LastYearConn.retrieveAccountClassCodeNo();

            lastYearAccountClassCode = LastYearConn.lastYearAccountClassCode;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (lblTransId.Text == "ID")
                {
                    MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dataUpdate = MessageBox.Show("Update data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dataUpdate == DialogResult.No)
                {
                    return;
                }

                retrieveLastYearCodes();
                //string strconn = "Server=localhost; User Id=root; Password=SQLAdmin; Database=nbvmaydb;port=3306;Convert Zero Datetime=True";

                string strconn = LastYearConn.mysqlConnString;

                MySqlConnection conn = new MySqlConnection(strconn);
                conn.Open();


                string DummySQL = "UPDATE `tbl_lastyear_upload` SET `LastYear_Date` = @LastYearDate,`Unit_Code` = @busUnit," +
                     "`Amount` = @Amount,`AccountClass_Code` = @lastYearClass,`User_Code` = @user WHERE `Trans_Id` = @TransId";

                MySqlCommand cmdMySQL = new MySqlCommand(DummySQL, conn);

                cmdMySQL.Parameters.AddWithValue("@TransId", Convert.ToInt32(lblTransId.Text));
                cmdMySQL.Parameters.AddWithValue("@LastYearDate", Convert.ToDateTime(dtpLastYearDate.Text));
                cmdMySQL.Parameters.AddWithValue("@busUnit", lastYearUnitCode);
                cmdMySQL.Parameters.AddWithValue("@Amount", Convert.ToDouble(txtLastYearAmount.Text));
                cmdMySQL.Parameters.AddWithValue("@lastYearClass", lastYearAccountClassCode);
                cmdMySQL.Parameters.AddWithValue("@user", ConnAll.myAccount);

                cmdMySQL.ExecuteNonQuery();

                ConnAll.Alert("Data was updated successfully", frmAlert.alertTypeEnum.Success);

                conn.Close();
                conn.Dispose();
            }

            catch (Exception ex)
            {
                LastYearConn.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

            LastYearConn.lastYearUnitCode = 0;
            LastYearConn.lastYearAccountClassCode = 0;


            readFlterLastYearData();
        }

        private void txtBudgetAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLastYearAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtLastYearAmount.Text));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void cmbBusUnit_DropDown(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();
            fillBusUnit();
        }

        private void cmbAccountClass_DropDown(object sender, EventArgs e)
        {
            cmbAccountClass.Items.Clear();
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
            fillAccountClassCode();
        }


        /***************COMBOBOX FILL*********************/

        public void fillFilterBusUnit()
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
                cmbfltrBusUnit.Items.Add(row[1].ToString());
            }

            cmbfltrBusUnit.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }

        }


        private void cmbfltrBusUnit_DropDown(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();
            fillFilterBusUnit();
        }


        public void fillFltrAccountClass()
        {


            //Get Account Class Code

            MySqlCommand ConnAccountClassCmd = new MySqlCommand("SELECT `ExpandedAccounts`, `ExpandedAccountDesc` FROM `tbl_expandedpnlaccounts`", ConnAll.mySqlconn);
            MySqlDataAdapter ConnAccountClassAdapter = new MySqlDataAdapter();
            ConnAccountClassAdapter.SelectCommand = ConnAccountClassCmd;
            System.Data.DataTable AccountClassDataTable = new System.Data.DataTable();
            ConnAccountClassAdapter.Fill(AccountClassDataTable);


            foreach (DataRow row in AccountClassDataTable.Rows)
            {
                cmbfltrAccountClass.Items.Add(row[1].ToString());
            }

            cmbfltrAccountClass.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }


        }

        private void cmbfltrAccountClass_DropDown(object sender, EventArgs e)
        {
            cmbfltrAccountClass.Items.Clear();
            lastYearFlterUnitName = cmbfltrBusUnit.GetItemText(cmbfltrBusUnit.SelectedItem);
            fillFltrAccountClass();
        }

        private void btnResetBusUnit_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();
            cmbAccountClass.Items.Clear();

            txtLastYearAmount.Text = "0.00";

            lblTransId.Text = "lblTransId";


        }

        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();
            cmbfltrAccountClass.Items.Clear();

            LastYearConn.lastYearUnitCode = 0;
            LastYearConn.lastYearAccountClassCode = 0;
        }


        private void retrieveFltrBudgetCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbfltrBusUnit.Text + "'";

            LastYearConn.mysqlQuery = SQLStatement;

            LastYearConn.retrieveUnitCodeNo();

            lastYearFltrUnitCode = LastYearConn.lastYearUnitCode;


            //Retrieve BudgetAccountClassCode


            SQLStatement = "SELECT `ExpandedAccounts` FROM `tbl_expandedpnlaccounts` WHERE `ExpandedAccountDesc` = " + "'" + cmbfltrAccountClass.Text + "'";

            LastYearConn.mysqlQuery = SQLStatement;

            LastYearConn.retrieveAccountClassCodeNo();

            lastYearFltrAccountClassCode = LastYearConn.lastYearAccountClassCode;

        }


        /***********************READ DATA**********************/
        public void readFlterLastYearData()
        {
            var loader = new WaitFormFunc();

            loader.ShowSmall();

            //DATAGRIDVIEW PROPERTIES

            fltrDateFrom = dtpFromDate.Value;
            fltrDateTo = dtpToDate.Value;

            int userIdFlterd = ConnAll.myAccount;


            queryFlterDateFrom = fltrDateFrom.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            queryFlterDateTo = fltrDateTo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            retrieveFltrBudgetCodes();

            queryFltrAccountClassCode = lastYearFltrAccountClassCode.ToString();
            queryFltrUnitCode = lastYearFltrUnitCode.ToString();


            dgvLastYear.ColumnCount = 6;
            dgvLastYear.Columns[0].Name = "No.";
            dgvLastYear.Columns[1].Name = "Last Year Date";
            dgvLastYear.Columns[2].Name = "BusUnit";
            dgvLastYear.Columns[3].Name = "Last Year Amount";
            dgvLastYear.Columns[4].Name = "Account Class";
            dgvLastYear.Columns[5].Name = "User";


            dgvLastYear.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvLastYear.Columns[3].DefaultCellStyle.Format = "n2";


            dgvLastYear.Columns[0].Frozen = false;
            dgvLastYear.Columns[1].Frozen = false;
            dgvLastYear.Columns[2].Frozen = false;
            dgvLastYear.Columns[3].Frozen = false;
            dgvLastYear.Columns[4].Frozen = false;
            dgvLastYear.Columns[5].Frozen = false;




            //dgvSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvLastYear.Columns[0].Width = 90;
            dgvLastYear.Columns[1].Width = 130;
            dgvLastYear.Columns[2].Width = 130;
            dgvLastYear.Columns[3].Width = 135;
            dgvLastYear.Columns[4].Width = 180;
            dgvLastYear.Columns[5].Width = 130;



            //SELECTION MODE

            dgvLastYear.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLastYear.MultiSelect = false;



            if (queryFltrUnitCode != "0" && queryFltrAccountClassCode == "0" && !tglUserFilter.Checked)

            {
                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                      + "WHERE tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                      " AND tbl_lastyear_upload.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                      " ORDER BY tbl_lastyear_upload.Trans_Id";




            }
            else if (queryFltrUnitCode == "0" && queryFltrAccountClassCode != "0" && !tglUserFilter.Checked)
            {

                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                      + "WHERE tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                      " AND tbl_lastyear_upload.AccountClass_Code = " + "'" + queryFltrAccountClassCode + "'" +
                                      " ORDER BY tbl_lastyear_upload.Trans_Id";



            }
            else if (queryFltrUnitCode != "0" && queryFltrAccountClassCode != "0" && !tglUserFilter.Checked)
            {




                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " AND tbl_lastyear_upload.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                        " AND tbl_lastyear_upload.AccountClass_Code = " + "'" + queryFltrAccountClassCode + "'" +
                                        " ORDER BY tbl_lastyear_upload.Trans_Id";


            }

            else if (queryFltrUnitCode != "0" && queryFltrAccountClassCode == "0" && tglUserFilter.Checked)
            {


                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " AND tbl_lastyear_upload.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                         "AND User_Code = " + userIdFlterd +
                                        " ORDER BY tbl_lastyear_upload.Trans_Id";


            }

            else if (queryFltrUnitCode != "0" && queryFltrAccountClassCode != "0" && tglUserFilter.Checked)
            {


                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " AND tbl_lastyear_upload.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                        " AND tbl_lastyear_upload.AccountClass_Code = " + "'" + queryFltrAccountClassCode + "'" +
                                        "AND User_Code = " + userIdFlterd +
                                        " ORDER BY tbl_lastyear_upload.Trans_Id";


            }


            else if (queryFltrUnitCode == "0" && queryFltrAccountClassCode == "0" && tglUserFilter.Checked)
            {

                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                        + "WHERE tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                        "AND User_Code = " + userIdFlterd +
                        " ORDER BY tbl_lastyear_upload.Trans_Id";


            }


            else
            {

                SQLStatement = @"SELECT tbl_lastyear_upload.Trans_Id,tbl_lastyear_upload.LastYear_Date,tbl_units.Unit_Name,tbl_lastyear_upload.Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_lastyear_upload.Unit_Code, tbl_lastyear_upload.AccountClass_Code
                                        FROM `tbl_lastyear_upload`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_lastyear_upload.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_lastyear_upload.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_lastyear_upload.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE  tbl_lastyear_upload.LastYear_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " ORDER BY  tbl_lastyear_upload.Trans_Id";



            }



            LastYearConn.mysqlQuery = SQLStatement;

            LastYearConn.retrieveLastYear(dgvLastYear);

            loader.CloseSmall();
        }

        private void btnBudgetFlter_Click(object sender, EventArgs e)
        {
            readFlterLastYearData();
        }


        public void DeleteDGVRows(string idn)
        {
            LastYearData MySqlConn = new LastYearData();
            MySqlConn.mysqlQuery = "DELETE FROM `tbl_lastyear_upload` WHERE `Trans_Id` = @no";


            MySqlConn.lastYearDelete(Convert.ToInt32(idn));


            LastYearConn.lastYearUnitCode = 0;
            LastYearConn.lastYearAccountClassCode = 0;

        }


        private void btnBatchDelete_Click(object sender, EventArgs e)
        {



            if (btnBatchDelete.Text == "Batch Delete")
            {
                btnLastYearFlter.Enabled = false;

                DataGridViewCheckBoxColumn dchek = new DataGridViewCheckBoxColumn();
                dchek.HeaderText = "Select";
                dgvLastYear.Columns.Insert(0, dchek);

                btnBatchDelete.Text = "Delete Selected";
                btnBatchDelete.FillColor = Color.FromArgb(255, 164, 91);


                foreach (DataGridViewRow row in dgvLastYear.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                }

                btnCheckUncheck.Show();
                btnCancel.Show();
            }
            else
            {
                string deleteId;

                DialogResult dataDelete = MessageBox.Show("Are you sure you want to delete this data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dataDelete == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvLastYear.Rows)
                    {

                        deleteId = row.Cells[1].Value.ToString();



                        if ((bool)row.Cells[0].Value == true)
                        {
                            DeleteDGVRows(deleteId);
                        }

                    }

                    ConnAll.Alert("Selected data was deleted successfully", frmAlert.alertTypeEnum.Success);

                    dgvLastYear.Columns.RemoveAt(0);

                    btnBatchDelete.Text = "Batch Delete";

                    btnLastYearFlter.Enabled = true;

                    btnCheckUncheck.Hide();
                    btnCancel.Hide();

                    readFlterLastYearData();
                }

            }
        }

        private void btnCheckUncheck_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCheckUncheck.CheckState == CheckState.Unchecked)
            {

                foreach (DataGridViewRow row in dgvLastYear.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = false;
                }

                //MessageBox.Show("unchecked");
            }
            else
            {
                foreach (DataGridViewRow row in dgvLastYear.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                }

                //MessageBox.Show("checked");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvLastYear.Columns.RemoveAt(0);

            btnBatchDelete.Text = "Batch Delete";
            btnBatchDelete.FillColor = Color.FromArgb(0, 106, 113);

            btnLastYearFlter.Enabled = true;

            btnCheckUncheck.Hide();
            btnCancel.Hide();

            readFlterLastYearData();
        }

        private void dgvLastYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //Update Column
            {
                cmbBusUnit.Items.Clear();
                cmbBusUnit.Items.Add(dgvLastYear.SelectedRows[0].Cells[2].Value.ToString());
                cmbBusUnit.SelectedIndex = 0;

                cmbAccountClass.Items.Clear();
                cmbAccountClass.Items.Add(dgvLastYear.SelectedRows[0].Cells[4].Value.ToString());
                cmbAccountClass.SelectedIndex = 0;

                txtLastYearAmount.Text = dgvLastYear.SelectedRows[0].Cells[3].Value.ToString();
                try
                {
                    txtLastYearAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtLastYearAmount.Text));
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                dtpLastYearDate.Value = Convert.ToDateTime(dgvLastYear.SelectedRows[0].Cells[1].Value.ToString());

                lblTransId.Text = dgvLastYear.SelectedRows[0].Cells[0].Value.ToString();

                MessageBox.Show("Edit data on fields provided above", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.ColumnIndex == 7)
            {
                MySqlConnect MySqlConn = new MySqlConnect();
                MySqlConn.mysqlQuery = "DELETE FROM `tbl_lastyear_upload` WHERE `Trans_Id` = @no";

                DialogResult dataDelete = MessageBox.Show("Are you sure you want to delete this data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dataDelete == DialogResult.Yes)
                {
                    lblTransId.Text = dgvLastYear.SelectedRows[0].Cells[0].Value.ToString();
                    MySqlConn.delete(Convert.ToInt32(lblTransId.Text));
                }


                LastYearConn.lastYearUnitCode = 0;
                LastYearConn.lastYearAccountClassCode = 0;

                readFlterLastYearData();
            }
        }

        private void dgvLastYear_MouseHover(object sender, EventArgs e)
        {
            dgvLastYear.ScrollBars = ScrollBars.Both;
        }

        private void dgvLastYear_MouseLeave(object sender, EventArgs e)
        {
            dgvLastYear.ScrollBars = ScrollBars.None;
        }
    }
}
