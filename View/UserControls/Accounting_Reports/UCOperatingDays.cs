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
    public partial class UCOperatingDays : UserControl
    {


        string busUnitName;
        string busUnit;
        string busUQuery;
        int userId;
        string SQLStatement;

        int opnDaysUnitCode;
        int opnDaysAccountClassCode;

        int opnDaysFltrUnitCode;
        string queryFltrUnitCode;

        string opnDaysFlterUnitName;

        int opnDaysFltrAccountClassCode;
        string queryFltrAccountClassCode;

        DateTime fltrDateFrom;
        DateTime fltrDateTo;

        string queryFlterDateFrom;
        string queryFlterDateTo;


        MySqlConnect ConnAll = new MySqlConnect();
        opnDaysData opnDaysConn = new opnDaysData();


        public UCOperatingDays()
        {
            InitializeComponent();
            btnCheckUncheck.Hide();
            btnCancel.Hide();
            btnUpdate.Enabled = false;
            dtpToDate.Value = DateTime.Now;


            frmController.Instance.PnlTitle.Hide();
            guna2Transition2.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Operating Period Setup";
        }


        private void UCopnDays_Load(object sender, EventArgs e)
        {
            dtpopnDaysDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = DateTime.Now;
        }

        /***********************READ DATA**********************/
        public void readopnDaysData()
        {

            dgvopnDays.ColumnCount = 5;
            dgvopnDays.Columns[0].Name = "No.";
            dgvopnDays.Columns[1].Name = "Period";
            dgvopnDays.Columns[2].Name = "Store";
            dgvopnDays.Columns[3].Name = "Mon Opn Days";
            dgvopnDays.Columns[4].Name = "User";


            dgvopnDays.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            //dgvopnDays.Columns[3].DefaultCellStyle.Format = "n2";


            dgvopnDays.Columns[0].Frozen = false;
            dgvopnDays.Columns[1].Frozen = false;
            dgvopnDays.Columns[2].Frozen = false;
            dgvopnDays.Columns[3].Frozen = false;
            dgvopnDays.Columns[4].Frozen = false;



            dgvopnDays.Columns[0].Width = 80;
            dgvopnDays.Columns[1].Width = 80;
            dgvopnDays.Columns[2].Width = 120;
            dgvopnDays.Columns[3].Width = 80;
            dgvopnDays.Columns[4].Width = 80;


            //SELECTION MODE

            dgvopnDays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvopnDays.MultiSelect = false;

            SQLStatement = @"SELECT tbl_opdays.Trans_Id, tbl_opdays.Op_Date,tbl_units.Unit_Name,
            tbl_opdays.MonOpDays,  tbl_users.User_Name
            FROM `tbl_opdays`
            LEFT OUTER JOIN `tbl_units` ON tbl_opdays.Unit_Code = tbl_units.Unit_Code
            LEFT OUTER JOIN `tbl_users` ON tbl_opdays.User = tbl_users.User_ID
            ORDER BY tbl_units.Unit_Name, tbl_opdays.Op_Date ASC";


            opnDaysConn.mysqlQuery = SQLStatement;

            opnDaysConn.retrieveopnDays(dgvopnDays);


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

            foreach (DataGridViewRow row in dgvopnDays.Rows)
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
            readFlteropnDaysData();
            replaceDgvString();

            if (dgvopnDays.Rows.Count > 0)
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
                            int columnCount = dgvopnDays.Columns.Count - 2;
                            string columnNames = "";
                            int rowCount = dgvopnDays.Rows.Count;

                            var outputCsv = new string[rowCount + 1];

                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvopnDays.Columns[i].HeaderText + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvopnDays.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvopnDays.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
            readFlteropnDaysData();
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
            readFlteropnDaysData();
        }

        private void retrieveopnDaysCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbBusUnit.Text + "'";

            opnDaysConn.mysqlQuery = SQLStatement;

            opnDaysConn.retrieveUnitCodeNo();

            opnDaysUnitCode = opnDaysConn.opnDaysUnitCode;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {


            if (btnUpdate.Text == "Update")
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

                    retrieveopnDaysCodes();

                    string strconn = opnDaysConn.mysqlConnString;

                    MySqlConnection conn = new MySqlConnection(strconn);
                    conn.Open();


                    string DummySQL = "UPDATE `tbl_opdays` SET `Op_Date` = @opnDaysDate,`Unit_Code` = @busUnit," +
                         "`MonOpDays` = @OpDays,`User` = @user WHERE `Trans_Id` = @TransId";

                    MySqlCommand cmdMySQL = new MySqlCommand(DummySQL, conn);

                    cmdMySQL.Parameters.AddWithValue("@TransId", Convert.ToInt32(lblTransId.Text));
                    cmdMySQL.Parameters.AddWithValue("@opnDaysDate", Convert.ToDateTime(dtpopnDaysDate.Text));
                    cmdMySQL.Parameters.AddWithValue("@busUnit", opnDaysUnitCode);
                    cmdMySQL.Parameters.AddWithValue("@OpDays", Convert.ToInt32(txtopnDaysAmount.Text));
                    cmdMySQL.Parameters.AddWithValue("@user", ConnAll.myAccount);

                    cmdMySQL.ExecuteNonQuery();

                    ConnAll.Alert("Data was updated successfully", frmAlert.alertTypeEnum.Success);

                    conn.Close();
                    conn.Dispose();

                    btnUpdate.Text = "Post";
                    btnUpdate.Enabled = false;

                }

                catch (Exception ex)
                {
                    opnDaysConn.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                    MessageBox.Show(ex.Message);
                    return;
                }

                opnDaysConn.opnDaysUnitCode = 0;


                readFlteropnDaysData();
            }
            else //Insert OpnDays Data
            {
                DialogResult msgContinue = MessageBox.Show("Continue to post data?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgContinue == DialogResult.No)
                {
                    return;
                }
                else
                {

                    try
                    {

                        retrieveopnDaysCodes();

                        string strconn = opnDaysConn.mysqlConnString;

                        MySqlConnection conn = new MySqlConnection(strconn);
                        conn.Open();


                        string DummySQL = "INSERT INTO `tbl_opdays`(Op_Date,Unit_Code,MonOpDays,User)  " +
                                                                "VALUES(@opDate,@unitCode,@opDays,@user)";



                        MySqlCommand cmdMySQL = new MySqlCommand(DummySQL, conn);

                        cmdMySQL.Parameters.AddWithValue("@opDate", Convert.ToDateTime(dtpopnDaysDate.Text));
                        cmdMySQL.Parameters.AddWithValue("@unitCode", opnDaysUnitCode);
                        cmdMySQL.Parameters.AddWithValue("@opDays", Convert.ToInt32(txtopnDaysAmount.Text));
                        cmdMySQL.Parameters.AddWithValue("@user", ConnAll.myAccount);


                        cmdMySQL.ExecuteNonQuery();

                        ConnAll.Alert("Data was posted. successfully", frmAlert.alertTypeEnum.Success);

                        conn.Close();
                        conn.Dispose();

                        btnUpdate.Enabled = false;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    readFlteropnDaysData();

                    opnDaysConn.opnDaysUnitCode = 0;

                }



            }

        }



        private void txtBudgetAmount_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtopnDaysAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtopnDaysAmount.Text));
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

        private void cmbBusUnit_DropDown(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();
            fillBusUnit();
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




        private void btnResetBusUnit_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();

            txtopnDaysAmount.Text = "0";

            lblTransId.Text = "lblTransId";


        }

        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();

            opnDaysConn.opnDaysUnitCode = 0;
        }


        private void retrieveFltrBudgetCodes()
        {
            //Retrieve BudgetUnit Code

            SQLStatement = "SELECT `Unit_Code` FROM tbl_units WHERE Unit_Name = " + "'" + cmbfltrBusUnit.Text + "'";

            opnDaysConn.mysqlQuery = SQLStatement;

            opnDaysConn.retrieveUnitCodeNo();

            opnDaysFltrUnitCode = opnDaysConn.opnDaysUnitCode;


        }


        /***********************READ DATA**********************/
        public void readFlteropnDaysData()
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

            queryFltrAccountClassCode = opnDaysFltrAccountClassCode.ToString();
            queryFltrUnitCode = opnDaysFltrUnitCode.ToString();


            dgvopnDays.ColumnCount = 5;
            dgvopnDays.Columns[0].Name = "No.";
            dgvopnDays.Columns[1].Name = "Period";
            dgvopnDays.Columns[2].Name = "Store";
            dgvopnDays.Columns[3].Name = "Mon Opn Days";
            dgvopnDays.Columns[4].Name = "User";


            dgvopnDays.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";


            dgvopnDays.Columns[0].Frozen = false;
            dgvopnDays.Columns[1].Frozen = false;
            dgvopnDays.Columns[2].Frozen = false;
            dgvopnDays.Columns[3].Frozen = false;
            dgvopnDays.Columns[4].Frozen = false;





            //dgvSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvopnDays.Columns[0].Width = 100;
            dgvopnDays.Columns[1].Width = 150;
            dgvopnDays.Columns[2].Width = 250;
            dgvopnDays.Columns[3].Width = 150;
            dgvopnDays.Columns[4].Width = 150;



            //SELECTION MODE

            dgvopnDays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvopnDays.MultiSelect = false;



            if (queryFltrUnitCode != "0" && !tglUserFilter.Checked)

            {
                SQLStatement = @"SELECT tbl_opdays.Trans_Id, tbl_opdays.Op_Date,tbl_units.Unit_Name,
                                        tbl_opdays.MonOpDays,  tbl_users.User_Name
                                        FROM `tbl_opdays`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_opdays.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_opdays.User = tbl_users.User_ID "
          + "WHERE tbl_opdays.Op_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
          " AND tbl_opdays.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
          " ORDER BY tbl_opdays.Trans_Id";
            }


            else if (queryFltrUnitCode != "0" && tglUserFilter.Checked)
            {


                SQLStatement = SQLStatement = @"SELECT tbl_opdays.Trans_Id, tbl_opdays.Op_Date,tbl_units.Unit_Name,
                                        tbl_opdays.MonOpDays,  tbl_users.User_Name
                                        FROM `tbl_opdays`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_opdays.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_opdays.User = tbl_users.User_ID "
                                      + "WHERE tbl_opdays.Op_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                      " AND tbl_opdays.Unit_Code = " + "'" + queryFltrUnitCode + "'" +
                                      "AND User = " + userIdFlterd +
                                      " ORDER BY tbl_opdays.Trans_Id";


            }
            else if (queryFltrUnitCode == "0" && tglUserFilter.Checked)
            {
                SQLStatement = SQLStatement = @"SELECT tbl_opdays.Trans_Id, tbl_opdays.Op_Date,tbl_units.Unit_Name,
                                        tbl_opdays.MonOpDays,  tbl_users.User_Name
                                        FROM `tbl_opdays`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_opdays.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_opdays.User = tbl_users.User_ID "
                               + "WHERE tbl_opdays.Op_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                               "AND User = " + userIdFlterd +
                               " ORDER BY tbl_opdays.Trans_Id";


            }
            else
            {

                SQLStatement = @"SELECT tbl_opdays.Trans_Id, tbl_opdays.Op_Date,tbl_units.Unit_Name,
                                        tbl_opdays.MonOpDays,  tbl_users.User_Name
                                        FROM `tbl_opdays`
                                        LEFT OUTER JOIN `tbl_units` ON tbl_opdays.Unit_Code = tbl_units.Unit_Code
                                        LEFT OUTER JOIN `tbl_users` ON tbl_opdays.User = tbl_users.User_ID "
                                       + "WHERE tbl_opdays.Op_Date BETWEEN " + "'" + queryFlterDateFrom + "' AND " + "'" + queryFlterDateTo + "'" +
                                       " ORDER BY tbl_opdays.Trans_Id";



            }



            opnDaysConn.mysqlQuery = SQLStatement;

            opnDaysConn.retrieveopnDays(dgvopnDays);

            loader.CloseSmall();

        }

        private void btnBudgetFlter_Click(object sender, EventArgs e)
        {
            readFlteropnDaysData();
        }


        public void DeleteDGVRows(string idn)
        {
            opnDaysData MySqlConn = new opnDaysData();
            MySqlConn.mysqlQuery = "DELETE FROM `tbl_opdays` WHERE `Trans_Id` = @no";


            MySqlConn.opnDaysDelete(Convert.ToInt32(idn));


            opnDaysConn.opnDaysUnitCode = 0;


        }


        private void btnBatchDelete_Click(object sender, EventArgs e)
        {



            if (btnBatchDelete.Text == "Batch Delete")
            {
                btnopnDaysFlter.Enabled = false;
                btnAddNew.Enabled = false;

                DataGridViewCheckBoxColumn dchek = new DataGridViewCheckBoxColumn();
                dchek.HeaderText = "Select";
                dgvopnDays.Columns.Insert(0, dchek);

                btnBatchDelete.Text = "Delete Selected";
                btnBatchDelete.FillColor = Color.FromArgb(255, 164, 91);


                foreach (DataGridViewRow row in dgvopnDays.Rows)
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
                    foreach (DataGridViewRow row in dgvopnDays.Rows)
                    {

                        deleteId = row.Cells[1].Value.ToString();



                        if ((bool)row.Cells[0].Value == true)
                        {
                            DeleteDGVRows(deleteId);
                        }

                    }

                    ConnAll.Alert("Selected data was deleted successfully", frmAlert.alertTypeEnum.Success);

                    dgvopnDays.Columns.RemoveAt(0);

                    btnBatchDelete.Text = "Batch Delete";

                    btnopnDaysFlter.Enabled = true;

                    btnCheckUncheck.Hide();
                    btnCancel.Hide();

                    readFlteropnDaysData();
                }

            }
        }

        private void btnCheckUncheck_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCheckUncheck.CheckState == CheckState.Unchecked)
            {

                foreach (DataGridViewRow row in dgvopnDays.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = false;
                }

                //MessageBox.Show("unchecked");
            }
            else
            {
                foreach (DataGridViewRow row in dgvopnDays.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                }

                //MessageBox.Show("checked");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvopnDays.Columns.RemoveAt(0);

            btnBatchDelete.Text = "Batch Delete";
            btnBatchDelete.FillColor = Color.FromArgb(0, 106, 113);

            btnopnDaysFlter.Enabled = true;

            btnCheckUncheck.Hide();
            btnCancel.Hide();

            readFlteropnDaysData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            MessageBox.Show("Fill in the required data on the fields provided", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate.Text = "Post";
            txtopnDaysAmount.Text = "0";
            cmbBusUnit.Items.Clear();
        }

        private void btnResetBusUnit_Click_2(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();
            txtopnDaysAmount.Text = "0";
            dtpopnDaysDate.Value = DateTime.Now;
            btnUpdate.Enabled = false;

        }

        private void btnFilterReset_Click_1(object sender, EventArgs e)
        {
            cmbfltrBusUnit.Items.Clear();


            opnDaysConn.opnDaysUnitCode = 0;

        }

        private void dgvopnDays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //Update Column
            {
                cmbBusUnit.Items.Clear();
                cmbBusUnit.Items.Add(dgvopnDays.SelectedRows[0].Cells[2].Value.ToString());
                cmbBusUnit.SelectedIndex = 0;

                txtopnDaysAmount.Text = dgvopnDays.SelectedRows[0].Cells[3].Value.ToString();

                //try
                //{
                //    txtopnDaysAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtopnDaysAmount.Text));
                //}
                //catch (Exception ex)
                //{
                //    ex.ToString();
                //}

                dtpopnDaysDate.Value = Convert.ToDateTime(dgvopnDays.SelectedRows[0].Cells[1].Value.ToString());

                lblTransId.Text = dgvopnDays.SelectedRows[0].Cells[0].Value.ToString();

                btnUpdate.Text = "Update";

                btnUpdate.Enabled = true;

                MessageBox.Show("Edit data on fields provided above", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.ColumnIndex == 6)
            {
                MySqlConnect MySqlConn = new MySqlConnect();
                MySqlConn.mysqlQuery = "DELETE FROM `tbl_opdays` WHERE `Trans_Id` = @no";

                DialogResult dataDelete = MessageBox.Show("Are you sure you want to delete this data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dataDelete == DialogResult.Yes)
                {
                    lblTransId.Text = dgvopnDays.SelectedRows[0].Cells[0].Value.ToString();
                    MySqlConn.delete(Convert.ToInt32(lblTransId.Text));
                }


                opnDaysConn.opnDaysUnitCode = 0;


                readFlteropnDaysData();
            }
        }

        private void dgvopnDays_MouseHover(object sender, EventArgs e)
        {
            dgvopnDays.ScrollBars = ScrollBars.Both;
        }

        private void dgvopnDays_MouseLeave(object sender, EventArgs e)
        {
            dgvopnDays.ScrollBars = ScrollBars.None;
        }
    }
}
