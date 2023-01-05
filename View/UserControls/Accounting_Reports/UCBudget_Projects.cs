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
    public partial class UCBudget_Projects : UserControl
    {
        string strSearch;
        string searchContent;

        string busUnitName;
        string busUnit;
        string busUQuery;
        int userId;
        string SQLStatement;

        int budgetUnitCode;
        int budgetAccountClassCode;

        int budgetFltrUnitCode;
        string queryFltrUnitCode;

        string busFlterUnitName;

        int budgetFltrAccountClassCode;
        string queryFltrAccountClassCode;

        DateTime fltrDateFrom;
        DateTime fltrDateTo;

        string queryFlterDateFrom;
        string queryFlterDateTo;


        MySqlConnect ConnAll = new MySqlConnect();
        Budget BudgetConn = new Budget();


        public UCBudget_Projects()
        {
            InitializeComponent();
            btnCheckUncheck.Hide();
            btnCancel.Hide();

            dtpToDate.Value = DateTime.Now;
            dtpBudgetDate.Value = DateTime.Now;

            frmController.Instance.PnlTitle.Hide();
            guna2Transition2.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Budget Setup";


        }


        private void UCBudget_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("Select Budget Parameters then click Apply to run Budget Summary", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /***********************READ DATA**********************/
        public void readBudgetData()
        {

            //vScrollHelper = new Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper(dgvBudget, gunaVScrollBar1, true);
            //vScrollHelper.UpdateScrollBar();

            dgvBudget.ColumnCount = 6;
            dgvBudget.Columns[0].Name = "No.";
            dgvBudget.Columns[1].Name = "Budget Date";
            dgvBudget.Columns[2].Name = "Store";
            dgvBudget.Columns[3].Name = "Budget Amount";
            dgvBudget.Columns[4].Name = "Account";
            dgvBudget.Columns[5].Name = "User";


            dgvBudget.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvBudget.Columns[3].DefaultCellStyle.Format = "n2";


            dgvBudget.Columns[0].Frozen = false;
            dgvBudget.Columns[1].Frozen = false;
            dgvBudget.Columns[2].Frozen = false;
            dgvBudget.Columns[3].Frozen = false;
            dgvBudget.Columns[4].Frozen = false;
            dgvBudget.Columns[5].Frozen = false;

            //dgvSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvBudget.Columns[0].Width = 50;
            dgvBudget.Columns[1].Width = 115;
            dgvBudget.Columns[2].Width = 175;
            dgvBudget.Columns[3].Width = 125;
            dgvBudget.Columns[4].Width = 220;
            dgvBudget.Columns[5].Width = 125;

            //SELECTION MODE

            dgvBudget.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBudget.MultiSelect = false;

            SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id, tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,
            tbl_budget_accountclass.Budget_Amount,tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name
            FROM tbl_budget_accountclass
            LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
            LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON 
            tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts
            LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
            ORDER BY tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Date,tbl_budget_accountclass.AccountClass_Code ASC";


            BudgetConn.mysqlQuery = SQLStatement;

            BudgetConn.retrieveBudget(dgvBudget);
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

        public void fillProject()
        {
            //cmbProject.Items.Clear();

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




            //LOOP THRU cmbProject


            //MySqlCommand mySqlCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Unit_Code` = @Unit_Code " +
            //    "ORDER BY `Project_Name` ASC", ConnAll.mySqlconn);
            //mySqlCmd.Parameters.AddWithValue("@Unit_Code", busUnit);
            //MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            //mySqlAdapter.SelectCommand = mySqlCmd;
            //System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            //mySqlAdapter.Fill(mySqlDataTable);



            //foreach (DataRow row in mySqlDataTable.Rows)
            //{
            //    cmbProject.Items.Add(row[1].ToString());
            //}


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
            fillProject();
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            //cmbProject.Items.Clear();
            // cmbCostCenter.Items.Clear();
            //cmbProject.SelectedIndex = -1;

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



            //Get Project Code


            //MySqlCommand ProjectCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Project_Name` = @Project " +
            //    "ORDER BY `Project_Name` ASC", ConnAll.mySqlconn);
            //ProjectCmd.Parameters.AddWithValue("@Project", cmbProject.Text);
            //MySqlDataAdapter ProjectAdapter = new MySqlDataAdapter();
            //ProjectAdapter.SelectCommand = ProjectCmd;
            //System.Data.DataTable ProjectDataTable = new System.Data.DataTable();
            //ProjectAdapter.Fill(ProjectDataTable);

            //foreach (DataRow row in ProjectDataTable.Rows)
            //{
            //    projectCode = row[0].ToString();
            //}


            //Get Cost Center Code



            //    MySqlCommand CostCenterCmd = new MySqlCommand("SELECT `CostCenter_Code`,`CostCenter_Name` FROM `tbl_costcenter` " +
            //        "WHERE CostCenter_Name = @CostCenter  " +
            //        "ORDER BY `CostCenter_Name` ASC", ConnAll.mySqlconn);
            //CostCenterCmd.Parameters.AddWithValue("@CostCenter", cmbCostCenter.Text);
            //MySqlDataAdapter CostCenterAdapter = new MySqlDataAdapter();
            //CostCenterAdapter.SelectCommand = CostCenterCmd;
            //System.Data.DataTable CostCenterDataTable = new System.Data.DataTable();
            //CostCenterAdapter.Fill(CostCenterDataTable);

            //foreach (DataRow row in CostCenterDataTable.Rows)
            //{
            //    costCenterCode = row[0].ToString();
            //}


            //Get Chart of Account Code

            //MySqlCommand COACmd = new MySqlCommand("SELECT `GL`, `GL_Account` FROM `tbl_chartofaccounts`  " +
            //    "WHERE GL_Account = @GL  " +
            //    "ORDER BY `GL` ASC", ConnAll.mySqlconn);
            //COACmd.Parameters.AddWithValue("@GL", cmbProject.Text);
            //MySqlDataAdapter COAAdapter = new MySqlDataAdapter();
            //COAAdapter.SelectCommand = COACmd;
            //System.Data.DataTable COADataTable = new System.Data.DataTable();
            //COAAdapter.Fill(COADataTable);

            //foreach (DataRow row in COADataTable.Rows)
            //{
            //    //COACode = row[0].ToString();
            //}

            ConnAll.closeConnection();


        }

        /**************************EXCEL EXPORT***********************/

        private void replaceDgvString()
        {
            bool fileError = false;

            foreach (DataGridViewRow row in dgvBudget.Rows)
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
            readBudgetData();
            replaceDgvString();

            if (dgvBudget.Rows.Count > 0)
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
                            int columnCount = dgvBudget.Columns.Count - 2;
                            string columnNames = "";
                            int rowCount = dgvBudget.Rows.Count;

                            var outputCsv = new string[rowCount + 1];

                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvBudget.Columns[i].HeaderText + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvBudget.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvBudget.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
            readBudgetData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            //cmbProject.SelectedIndex = -1;
            //cmbCostCenter.SelectedIndex = -1;
            //cmbProject.SelectedIndex = -1;

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            //populateFilterCodes();
            //readBudgetData();
            //totalStatement();

            //pnlFilter.Hide();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }


        private void totalStatement()
        {
            //int sum = 0;
            //for (int i = 0; i < dgvBudget.Rows.Count; ++i)
            //{
            //    sum += Convert.ToInt32(dgvBudget.Rows[i].Cells[1].Value);
            //}
            //txtTotal.Text = sum.ToString("0,0.00", CultureInfo.InvariantCulture);


        }

        private void btnAddBudget_Click(object sender, EventArgs e)
        {
            frmBudgetSetup frmBudget = new frmBudgetSetup();
            frmBudget.ShowDialog();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            readBudgetData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //pnlFilter.Show();
        }


        private void UCBudget_Projects_Move(object sender, EventArgs e)
        {
            readBudgetData();
        }



        private void retrieveBudgetCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbBusUnit.Text + "'";

            BudgetConn.mysqlQuery = SQLStatement;

            BudgetConn.retrieveCodeNo();

            budgetUnitCode = BudgetConn.budgetUnitCode;


            //Retrieve ExpandedClassCode


            SQLStatement = "SELECT `ExpandedAccounts` FROM `tbl_expandedpnlaccounts` WHERE `ExpandedAccountDesc` = " + "'" + cmbAccountClass.Text + "'";

            BudgetConn.mysqlQuery = SQLStatement;

            BudgetConn.retrieveCodeNo();

            budgetAccountClassCode = BudgetConn.budgetUnitCode;
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

                retrieveBudgetCodes();

                //string strconn = "Server=localhost; User Id=root; Password=SQLAdmin; Database=nbvmaydb;port=3306;Convert Zero Datetime=True";

                string strconn = BudgetConn.mysqlConnString;

                MySqlConnection conn = new MySqlConnection(strconn);
                conn.Open();


                string DummySQL = "UPDATE `tbl_budget_accountclass` SET `Budget_Date` = @BudgetDate,`Unit_Code` = @busUnit," +
                     "`Project_Code` = @Project,`Budget_Amount` = @budgetAmount,`AccountClass_Code` = @budgetClass,`User_Code` = @user WHERE `Trans_Id` = @TransId";

                MySqlCommand cmdMySQL = new MySqlCommand(DummySQL, conn);

                cmdMySQL.Parameters.AddWithValue("@TransId", Convert.ToInt32(lblTransId.Text));
                cmdMySQL.Parameters.AddWithValue("@BudgetDate", Convert.ToDateTime(dtpBudgetDate.Text));
                cmdMySQL.Parameters.AddWithValue("@busUnit", budgetUnitCode);
                cmdMySQL.Parameters.AddWithValue("@Project", 0);
                cmdMySQL.Parameters.AddWithValue("@budgetAmount", Convert.ToDouble(txtBudgetAmount.Text));
                cmdMySQL.Parameters.AddWithValue("@budgetClass", budgetAccountClassCode);
                cmdMySQL.Parameters.AddWithValue("@user", ConnAll.myAccount);

                cmdMySQL.ExecuteNonQuery();

                ConnAll.Alert("Data was updated successfully", frmAlert.alertTypeEnum.Success);

                conn.Close();
                conn.Dispose();
            }

            catch (Exception ex)
            {
                BudgetConn.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }




            BudgetConn.budgetUnitCode = 0;
            BudgetConn.budgetAccountClassCode = 0;

            readFlterBudgetData();
        }

        private void txtBudgetAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBudgetAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtBudgetAmount.Text));
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
            busFlterUnitName = cmbfltrBusUnit.GetItemText(cmbfltrBusUnit.SelectedItem);
            fillFltrAccountClass();
        }

        private void btnResetBusUnit_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();
            cmbAccountClass.Items.Clear();

            txtBudgetAmount.Text = "0.00";

            lblTransId.Text = "lblTransId";


        }

        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();
            cmbfltrAccountClass.Items.Clear();

            BudgetConn.budgetUnitCode = 0;
            BudgetConn.budgetAccountClassCode = 0;
        }


        private void retrieveFltrBudgetCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbfltrBusUnit.Text + "'";

            BudgetConn.mysqlQuery = SQLStatement;

            BudgetConn.retrieveUnitCodeNo();

            budgetFltrUnitCode = BudgetConn.budgetUnitCode;


            //Retrieve BudgetAccountClassCode


            SQLStatement = "SELECT `ExpandedAccounts` FROM `tbl_expandedpnlaccounts` WHERE `ExpandedAccountDesc` = " + "'" + cmbfltrAccountClass.Text + "'";

            BudgetConn.mysqlQuery = SQLStatement;

            BudgetConn.retrieveAccountClassCodeNo();

            budgetFltrAccountClassCode = BudgetConn.budgetAccountClassCode;

        }


        /***********************READ DATA**********************/
        public void readFlterBudgetData()
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

            queryFltrAccountClassCode = budgetFltrAccountClassCode.ToString();
            queryFltrUnitCode = budgetFltrUnitCode.ToString();


            dgvBudget.ColumnCount = 6;
            dgvBudget.Columns[0].Name = "No.";
            dgvBudget.Columns[1].Name = "Budget Date";
            dgvBudget.Columns[2].Name = "BusUnit";
            dgvBudget.Columns[3].Name = "Budget Amount";
            dgvBudget.Columns[4].Name = "Budget Class";
            dgvBudget.Columns[5].Name = "User";


            dgvBudget.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvBudget.Columns[3].DefaultCellStyle.Format = "n2";


            dgvBudget.Columns[0].Frozen = false;
            dgvBudget.Columns[1].Frozen = false;
            dgvBudget.Columns[2].Frozen = false;
            dgvBudget.Columns[3].Frozen = false;
            dgvBudget.Columns[4].Frozen = false;
            dgvBudget.Columns[5].Frozen = false;




            //dgvSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvBudget.Columns[0].Width = 90;
            dgvBudget.Columns[1].Width = 130;
            dgvBudget.Columns[2].Width = 130;
            dgvBudget.Columns[3].Width = 135;
            dgvBudget.Columns[4].Width = 180;
            dgvBudget.Columns[5].Width = 130;



            //SELECTION MODE

            dgvBudget.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBudget.MultiSelect = false;



            if (queryFltrUnitCode != "0" && queryFltrAccountClassCode == "0" && !tglUserFilter.Checked)

            {


                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                      + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                      " AND tbl_budget_accountclass.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                      " ORDER BY tbl_budget_accountclass.Trans_Id";




            }
            else if (queryFltrUnitCode == "0" && queryFltrAccountClassCode != "0" && !tglUserFilter.Checked)
            {


                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                      + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                      " AND tbl_budget_accountclass.AccountClass_Code = " + "'" + queryFltrAccountClassCode + "'" +
                                      " ORDER BY tbl_budget_accountclass.Trans_Id";



            }
            else if (queryFltrUnitCode != "0" && queryFltrAccountClassCode != "0" && !tglUserFilter.Checked)
            {



                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " AND tbl_budget_accountclass.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                        " AND tbl_budget_accountclass.AccountClass_Code = " + "'" + queryFltrAccountClassCode + "'" +
                                        " ORDER BY tbl_budget_accountclass.Trans_Id";


            }

            else if (queryFltrUnitCode != "0" && queryFltrAccountClassCode != "0" && tglUserFilter.Checked)
            {




                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " AND tbl_budget_accountclass.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                        " AND tbl_budget_accountclass.AccountClass_Code = " + "'" + queryFltrAccountClassCode + "'" +
                                        "AND User_Code = " + userIdFlterd +
                                        " ORDER BY tbl_budget_accountclass.Trans_Id";


            }

            else if (queryFltrUnitCode != "0" && queryFltrAccountClassCode == "0" && tglUserFilter.Checked)
            {


                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        " AND tbl_budget_accountclass.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                        "AND User_Code = " + userIdFlterd +
                                        " ORDER BY tbl_budget_accountclass.Trans_Id";


            }


            else if (queryFltrUnitCode == "0" && queryFltrAccountClassCode == "0" && tglUserFilter.Checked)
            {




                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                        + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                        "AND User_Code = " + userIdFlterd +
                                        " ORDER BY tbl_budget_accountclass.Trans_Id";


            }

            else
            {


                SQLStatement = @"SELECT tbl_budget_accountclass.Trans_Id,tbl_budget_accountclass.Budget_Date,tbl_units.Unit_Name,tbl_budget_accountclass.Budget_Amount, tbl_expandedpnlaccounts.ExpandedAccountDesc, tbl_users.User_Name,
                                        tbl_budget_accountclass.Unit_Code, tbl_budget_accountclass.AccountClass_Code
                                        FROM tbl_budget_accountclass
                                        LEFT OUTER JOIN `tbl_units` ON tbl_budget_accountclass.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_budget_accountclass.User_Code = tbl_users.User_ID
                                        LEFT OUTER JOIN `tbl_expandedpnlaccounts` ON tbl_budget_accountclass.AccountClass_Code = tbl_expandedpnlaccounts.ExpandedAccounts "
                                + "WHERE tbl_budget_accountclass.Budget_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                " ORDER BY tbl_budget_accountclass.Trans_Id";





            }



            BudgetConn.mysqlQuery = SQLStatement;

            BudgetConn.retrieveBudget(dgvBudget);

            loader.CloseSmall();

        }

        private void btnBudgetFlter_Click(object sender, EventArgs e)
        {
            readFlterBudgetData();
        }


        public void DeleteDGVRows(string idn)
        {
            Budget MySqlConn = new Budget();
            MySqlConn.mysqlQuery = "DELETE FROM `tbl_budget_accountclass` WHERE `Trans_Id` = @no";


            MySqlConn.budgetDelete(Convert.ToInt32(idn));


            BudgetConn.budgetUnitCode = 0;
            BudgetConn.budgetAccountClassCode = 0;

        }


        private void btnBatchDelete_Click(object sender, EventArgs e)
        {



            if (btnBatchDelete.Text == "Batch Delete")
            {
                btnBudgetFlter.Enabled = false;

                DataGridViewCheckBoxColumn dchek = new DataGridViewCheckBoxColumn();
                dchek.HeaderText = "Select";
                dgvBudget.Columns.Insert(0, dchek);

                btnBatchDelete.Text = "Delete Selected";
                btnBatchDelete.FillColor = Color.FromArgb(255, 164, 91);


                foreach (DataGridViewRow row in dgvBudget.Rows)
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
                    foreach (DataGridViewRow row in dgvBudget.Rows)
                    {

                        deleteId = row.Cells[1].Value.ToString();



                        if ((bool)row.Cells[0].Value == true)
                        {
                            DeleteDGVRows(deleteId);
                        }

                    }

                    ConnAll.Alert("Selected data was deleted successfully", frmAlert.alertTypeEnum.Success);

                    dgvBudget.Columns.RemoveAt(0);

                    btnBatchDelete.Text = "Batch Delete";

                    btnBudgetFlter.Enabled = true;

                    btnCheckUncheck.Hide();
                    btnCancel.Hide();

                    readFlterBudgetData();
                }

            }

        }

        private void btnCheckUncheck_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCheckUncheck.CheckState == CheckState.Unchecked)
            {

                foreach (DataGridViewRow row in dgvBudget.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = false;
                }

                //MessageBox.Show("unchecked");
            }
            else
            {
                foreach (DataGridViewRow row in dgvBudget.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                }

                //MessageBox.Show("checked");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvBudget.Columns.RemoveAt(0);

            btnBatchDelete.Text = "Batch Delete";
            btnBatchDelete.FillColor = Color.FromArgb(0, 106, 113);

            btnCheckUncheck.Hide();
            btnCancel.Hide();

            btnBudgetFlter.Enabled = true;

            readFlterBudgetData();
        }

        private void dgvBudget_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //Update Column
            {
                cmbBusUnit.Items.Clear();
                cmbBusUnit.Items.Add(dgvBudget.SelectedRows[0].Cells[2].Value.ToString());
                cmbBusUnit.SelectedIndex = 0;

                cmbAccountClass.Items.Clear();
                cmbAccountClass.Items.Add(dgvBudget.SelectedRows[0].Cells[4].Value.ToString());
                cmbAccountClass.SelectedIndex = 0;

                txtBudgetAmount.Text = dgvBudget.SelectedRows[0].Cells[3].Value.ToString();
                try
                {
                    txtBudgetAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtBudgetAmount.Text));
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                dtpBudgetDate.Value = Convert.ToDateTime(dgvBudget.SelectedRows[0].Cells[1].Value.ToString());

                lblTransId.Text = dgvBudget.SelectedRows[0].Cells[0].Value.ToString();

                MessageBox.Show("Edit data on fields provided above", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.ColumnIndex == 7)
            {
                MySqlConnect MySqlConn = new MySqlConnect();
                MySqlConn.mysqlQuery = "DELETE FROM `tbl_budget_accountclass` WHERE `Trans_Id` = @no";

                DialogResult dataDelete = MessageBox.Show("Are you sure you want to delete this data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dataDelete == DialogResult.Yes)
                {
                    lblTransId.Text = dgvBudget.SelectedRows[0].Cells[0].Value.ToString();
                    MySqlConn.delete(Convert.ToInt32(lblTransId.Text));
                }


                BudgetConn.budgetUnitCode = 0;
                BudgetConn.budgetAccountClassCode = 0;

                readFlterBudgetData();
            }
        }

        private void dgvBudget_MouseHover(object sender, EventArgs e)
        {
            dgvBudget.ScrollBars = ScrollBars.Both;
        }

        private void dgvBudget_MouseLeave(object sender, EventArgs e)
        {
            dgvBudget.ScrollBars = ScrollBars.None;
        }
    }
}
