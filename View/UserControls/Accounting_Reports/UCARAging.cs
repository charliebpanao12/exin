using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCARAging : UserControl
    {



        int userId;
        string SQLStatement;


        string queryBusUnitCode;
        string busUnitName;

        string queryClearingCode;

        DateTime DateFrom;
        DateTime DateTo;

        string queryDateFrom;
        string queryDateTo;

        ARAging ARConn = new ARAging();


        public UCARAging()
        {
            InitializeComponent();
            btnCheckUncheck.Hide();
            btnCancel.Hide();
            pnlFilter.Hide();
            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = DateTime.Now;
            prgPreloader.Hide();
        }


        private void UCARAging_Load(object sender, EventArgs e)
        {


        }


        /***************COMBOBOX FILL*********************/

        public void fillCmbBusUnit()
        {
            //LOOP THRU cmbBusUnit



            userId = ARConn.myAccount;


            SQLStatement = @"SELECT Unit_Code, Unit_Name, User_ID FROM (SELECT tbl_credentials_units.Unit_Code,
                                tbl_units.Unit_Name, tbl_credentials_units.User_ID 
                                FROM tbl_credentials_units INNER JOIN tbl_units ON tbl_credentials_units.Unit_Code = tbl_units.Unit_Code) sub
                                WHERE User_ID = " + userId +
                                " ORDER BY Unit_Name ASC;";


            MySqlCommand mySqlCmd = new MySqlCommand(SQLStatement, ARConn.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            ARConn.closeConnection();


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


        /*************************FETCH COMBO BOX CODES*****************/


        private void populateCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbfltrBusUnit.Text + "'";

            ARConn.mysqlQuery = SQLStatement;

            ARConn.retrieveUnitCodeNo();


        }



        /***********************READ DATA**********************/
        public void readARAging()
        {



            this.Invoke((MethodInvoker)delegate
            {

                SetPreloader(true);

                //DATAGRIDVIEW PROPERTIES
                txtBranchName.Text = cmbfltrBusUnit.Text;
                txtClearingStatus.Text = cmbClearingStatus.Text;

                populateCodes(); //populate business unit querycode

                queryBusUnitCode = ARConn.UnitCode;
                queryClearingCode = cmbClearingStatus.Text;

                DateFrom = dtpFromDate.Value;
                DateTo = dtpToDate.Value;

                queryDateFrom = DateFrom.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                queryDateTo = DateTo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                dgvARAging.ColumnCount = 9;
                dgvARAging.Columns[0].Name = "No.";
                dgvARAging.Columns[1].Name = "Transaction Date";
                dgvARAging.Columns[2].Name = "Voucher No";
                dgvARAging.Columns[3].Name = "GLSL";
                dgvARAging.Columns[4].Name = "Amount";
                dgvARAging.Columns[5].Name = "GL";
                dgvARAging.Columns[6].Name = "Description";
                dgvARAging.Columns[7].Name = "Status";
                dgvARAging.Columns[8].Name = "Clearing Date";

                dgvARAging.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgvARAging.Columns[4].DefaultCellStyle.Format = "n2";


                dgvARAging.Columns[0].Frozen = false;
                dgvARAging.Columns[1].Frozen = false;
                dgvARAging.Columns[2].Frozen = false;
                dgvARAging.Columns[3].Frozen = false;
                dgvARAging.Columns[4].Frozen = false;
                dgvARAging.Columns[5].Frozen = false;
                dgvARAging.Columns[6].Frozen = false;
                dgvARAging.Columns[7].Frozen = false;
                dgvARAging.Columns[8].Frozen = false;

                SetPreloader(true);

                //SELECTION MODE

                dgvARAging.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvARAging.MultiSelect = false;

                if (queryBusUnitCode != null && queryClearingCode != "")

                {
                    SQLStatement = @"SELECT ID, Transaction_Date, if(Voucher_No = '',Particulars , Voucher_No) As Ref, 
                                                GLSL, Amount, LEFT(GLSL,3) As GL, Item_Description,
                                                tbl_ar_aging.clearing_status, tbl_ar_aging.clearing_date
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN tbl_ar_aging
                                                ON tbl_transaction.ID = tbl_ar_aging.entry_code
                                                WHERE LEFT(GLSL,3) >= 120
                                                AND LEFT(GLSL,3) <= 121
                                                AND Status = 'Active'
                                                AND Amount <> 0
                                                AND Transaction_Date BETWEEN " + "'" + queryDateFrom + "' AND " + "'" + queryDateTo + "'" +
                                          " AND Unit_Code = " + "'" + queryBusUnitCode + "'" +
                                          " AND tbl_ar_aging.clearing_status = " + "'" + queryClearingCode + "'" +
                                          " ORDER BY ID";

                    ARConn.mysqlQuery = SQLStatement;

                    ARConn.retrieveData(dgvARAging);
                }
                else if (queryBusUnitCode != null && queryClearingCode == "")
                {

                    SQLStatement = @"SELECT ID, Transaction_Date, if(Voucher_No = '',Particulars , Voucher_No) As Ref, 
                                                GLSL, Amount, LEFT(GLSL,3) As GL, Item_Description,
                                                tbl_ar_aging.clearing_status, tbl_ar_aging.clearing_date
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN tbl_ar_aging
                                                ON tbl_transaction.ID = tbl_ar_aging.entry_code
                                                WHERE LEFT(GLSL,3) >= 120
                                                AND LEFT(GLSL,3) <= 121
                                                AND Status = 'Active'
                                                AND Amount <> 0
                                                AND Transaction_Date BETWEEN " + "'" + queryDateFrom + "' AND " + "'" + queryDateTo + "'" +
                                             " AND Unit_Code = " + "'" + queryBusUnitCode + "'" +
                                             " ORDER BY ID";

                    ARConn.mysqlQuery = SQLStatement;

                    ARConn.retrieveData(dgvARAging);

                }
                else if (queryBusUnitCode == null && queryClearingCode != "")
                {

                    SQLStatement = @"SELECT ID, Transaction_Date, if(Voucher_No = '',Particulars , Voucher_No) As Ref, 
                                                GLSL, Amount, LEFT(GLSL,3) As GL, Item_Description,
                                                tbl_ar_aging.clearing_status, tbl_ar_aging.clearing_date
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN tbl_ar_aging
                                                ON tbl_transaction.ID = tbl_ar_aging.entry_code
                                                WHERE LEFT(GLSL,3) >= 120
                                                AND LEFT(GLSL,3) <= 121
                                                AND Status = 'Active'
                                                AND Amount <> 0
                                                AND Transaction_Date BETWEEN " + "'" + queryDateFrom + "' AND " + "'" + queryDateTo + "'" +
                                           " AND tbl_ar_aging.clearing_status = " + "'" + queryClearingCode + "'" +
                                           " ORDER BY ID";

                    ARConn.mysqlQuery = SQLStatement;

                    ARConn.retrieveData(dgvARAging);
                }

                else
                {
                    SQLStatement = @"SELECT ID, Transaction_Date, if(Voucher_No = '',Particulars , Voucher_No) As Ref, 
                                                GLSL, Amount, LEFT(GLSL,3) As GL, Item_Description,
                                                tbl_ar_aging.clearing_status, tbl_ar_aging.clearing_date
                                                FROM tbl_transaction
                                                LEFT OUTER JOIN tbl_ar_aging
                                                ON tbl_transaction.ID = tbl_ar_aging.entry_code
                                                WHERE LEFT(GLSL,3) >= 120
                                                AND LEFT(GLSL,3) <= 121
                                                AND Status = 'Active'
                                                AND Amount <> 0
                                                AND Transaction_Date BETWEEN " + "'" + queryDateFrom + "' AND " + "'" + queryDateTo + "'" +
                                         " ORDER BY ID";

                    ARConn.mysqlQuery = SQLStatement;

                    ARConn.retrieveData(dgvARAging);
                }




                cmbfltrBusUnit.SelectedIndex = -1;
                ARConn.UnitCode = null;
                cmbClearingStatus.SelectedIndex = -1;

                SetPreloader(false);

            });
        }

        /**************************EXCEL EXPORT***********************/

        private void replaceDgvString()
        {
            bool fileError = false;

            foreach (DataGridViewRow row in dgvARAging.Rows)
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
            readARAging();
            replaceDgvString();

            if (dgvARAging.Rows.Count > 0)
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
                            int columnCount = dgvARAging.Columns.Count - 2;
                            string columnNames = "";
                            int rowCount = dgvARAging.Rows.Count;

                            var outputCsv = new string[rowCount + 1];

                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvARAging.Columns[i].HeaderText + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvARAging.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvARAging.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
            readARAging();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            readARAging();
        }


        private void dgvARAging_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //Update Column
            {
                cmbfltrBusUnit.Items.Clear();
                cmbfltrBusUnit.Items.Add(dgvARAging.SelectedRows[0].Cells[2].Value.ToString());
                cmbfltrBusUnit.SelectedIndex = 0;

                //dtpLastYearDate.Value = Convert.ToDateTime(dgvARAging.SelectedRows[0].Cells[1].Value.ToString());

                lblTransId.Text = dgvARAging.SelectedRows[0].Cells[0].Value.ToString();

                MessageBox.Show("Edit data on fields provided above", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.ColumnIndex == 7)
            {
                MySqlConnect MySqlConn = new MySqlConnect();
                MySqlConn.mysqlQuery = "DELETE FROM `tbl_lastyear_upload` WHERE `Trans_Id` = @no";

                DialogResult dataDelete = MessageBox.Show("Are you sure you want to delete this data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dataDelete == DialogResult.Yes)
                {
                    lblTransId.Text = dgvARAging.SelectedRows[0].Cells[0].Value.ToString();
                    MySqlConn.delete(Convert.ToInt32(lblTransId.Text));
                }


                //ARConn.UnitCode = 0;

                readARAging();
            }
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

                //retrieveCodes();

                string strconn = ARConn.mysqlConnString;

                MySqlConnection conn = new MySqlConnection(strconn);
                conn.Open();


                string DummySQL = "UPDATE `tbl_lastyear_upload` SET `LastYear_Date` = @LastYearDate,`Unit_Code` = @busUnit," +
                     "`Amount` = @Amount,`AccountClass_Code` = @lastYearClass,`User_Code` = @user WHERE `Trans_Id` = @TransId";

                MySqlCommand cmdMySQL = new MySqlCommand(DummySQL, conn);

                cmdMySQL.Parameters.AddWithValue("@TransId", Convert.ToInt32(lblTransId.Text));
                cmdMySQL.Parameters.AddWithValue("@busUnit", queryBusUnitCode);
                cmdMySQL.Parameters.AddWithValue("@user", ARConn.myAccount);

                cmdMySQL.ExecuteNonQuery();

                ARConn.Alert("Data was updated successfully", frmAlert.alertTypeEnum.Success);

                conn.Close();
                conn.Dispose();
            }

            catch (Exception ex)
            {
                ARConn.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

            //ARConn.UnitCode = 0;

            readARAging();
        }





        private void cmbfltrBusUnit_DropDown(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();
            fillCmbBusUnit();
        }


        private void btnResetBusUnit_Click_1(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();

            lblTransId.Text = "lblTransId";


        }

        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();
            cmbfltrBusUnit.SelectedIndex = -1;
            ARConn.UnitCode = null;
            cmbClearingStatus.SelectedIndex = -1;
            guna2Transition1.Hide(pnlFilter);
        }



        private void btnFilterAgingReport_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(readARAging);
                threadInput.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            pnlFilter.Hide();
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



        public void DeleteDGVRows(string idn)
        {
            LastYearData MySqlConn = new LastYearData();
            MySqlConn.mysqlQuery = "DELETE FROM `tbl_lastyear_upload` WHERE `Trans_Id` = @no";


            MySqlConn.lastYearDelete(Convert.ToInt32(idn));


            //ARConn.UnitCode= 0;

        }


        private void btnBatchDelete_Click(object sender, EventArgs e)
        {



            if (btnBatchDelete.Text == "Batch Delete")
            {
                btnFilter.Enabled = false;

                DataGridViewCheckBoxColumn dchek = new DataGridViewCheckBoxColumn();
                dchek.HeaderText = "Select";
                dgvARAging.Columns.Insert(0, dchek);

                btnBatchDelete.Text = "Delete Selected";
                btnBatchDelete.FillColor = Color.FromArgb(255, 164, 91);


                foreach (DataGridViewRow row in dgvARAging.Rows)
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
                    foreach (DataGridViewRow row in dgvARAging.Rows)
                    {

                        deleteId = row.Cells[1].Value.ToString();



                        if ((bool)row.Cells[0].Value == true)
                        {
                            DeleteDGVRows(deleteId);
                        }

                    }

                    ARConn.Alert("Selected data was deleted successfully", frmAlert.alertTypeEnum.Success);

                    dgvARAging.Columns.RemoveAt(0);

                    btnBatchDelete.Text = "Batch Delete";

                    btnFilter.Enabled = true;

                    btnCheckUncheck.Hide();
                    btnCancel.Hide();

                    readARAging();
                }

            }
        }

        private void btnCheckUncheck_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCheckUncheck.CheckState == CheckState.Unchecked)
            {

                foreach (DataGridViewRow row in dgvARAging.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = false;
                }

                //MessageBox.Show("unchecked");
            }
            else
            {
                foreach (DataGridViewRow row in dgvARAging.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                }

                //MessageBox.Show("checked");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvARAging.Columns.RemoveAt(0);

            btnBatchDelete.Text = "Batch Delete";

            btnFilter.Enabled = true;

            btnCheckUncheck.Hide();
            btnCancel.Hide();

            readARAging();
        }

        private void btnShowFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Show();
            pnlFilter.BringToFront();
        }

        private void dgvARAging_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9) //Update Column
            {

                DialogResult clearVoucher = MessageBox.Show("Clear this Accounts Receivable?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (clearVoucher == DialogResult.No)
                {
                    return;
                }


                try
                {

                    ARConn.mysqlQuery = @"INSERT INTO `tbl_ar_aging`(entry_code,clearing_status,clearing_date,user_code,delete_status)
                                                                   VALUES(@voucherNo,@clearingStatus,@clearingDate,@userCode,@deleteStatus)";

                    MessageBox.Show("Cleared");


                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

            }
        }





    }
}
