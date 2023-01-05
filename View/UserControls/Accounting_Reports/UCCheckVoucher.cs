using Guna.UI2.WinForms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace EXIN
{
    public partial class UCCheckVoucher : UserControl
    {

        int page_1 = 0;
        int dataperPage = 20;

        static int one = 1;
        static int two = 2;
        static int three = 3;

        string strSearch;
        string searchContent;

        string postStatus;
        int rdovoucherNo;

        public static string Post = "Post";

        static UCCheckVoucher _UC;

        public static UCCheckVoucher Instance
        {
            get
            {
                if (_UC == null)
                {
                    _UC = new UCCheckVoucher();
                }
                return _UC;
            }
        }

        public UCCheckVoucher()
        {
            InitializeComponent();

        }

        Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper hScrollHelper;
        //Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper vScrollHelper;


        private void btnNew_Click(object sender, EventArgs e)
        {
            //frmCheckVoucher frmCheckVoucher = new frmCheckVoucher();
            //frmCheckVoucher.ShowDialog();


            //Guna.UI.Lib.GraphicsHelper.DrawLineShadow(pnlNewCV, Color.Red, 50, 50, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
        }

        private void dgvChecks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (hScrollHelper != null)
            {
                hScrollHelper.UpdateScrollBar();
            }

            readData();

            /*if (vScrollHelper != null)
            {
                vScrollHelper.UpdateScrollBar();
            }*/
        }

        private void UCCheckVoucher_Load(object sender, EventArgs e)
        {



            hScrollHelper = new Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper(dgvChecks, gunaHScrollBar1, true);
            //vScrollHelper = new Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper(dgvChecks, gunaVScrollBar1, true);

            hScrollHelper.UpdateScrollBar();
            //vScrollHelper.UpdateScrollBar();

            pnlNewCV.Hide();

            rdoPanel.Hide();

            readData();

        }

        public void readData()
        {
            //DATAGRIDVIEW PROPERTIES

            dgvChecks.ColumnCount = 11;
            dgvChecks.Columns[0].Name = "Date";
            dgvChecks.Columns[1].Name = "Voucher No.";
            dgvChecks.Columns[2].Name = "Check No.";
            dgvChecks.Columns[3].Name = "Payee";
            dgvChecks.Columns[4].Name = "Amount";
            dgvChecks.Columns[5].Name = "Particulars";
            dgvChecks.Columns[6].Name = "Type";
            dgvChecks.Columns[7].Name = "Check Date";
            dgvChecks.Columns[8].Name = "Bank";
            dgvChecks.Columns[9].Name = "User";
            dgvChecks.Columns[10].Name = "Payment Status";

            dgvChecks.Columns[4].DefaultCellStyle.Format = "n2";
            dgvChecks.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvChecks.Columns[7].DefaultCellStyle.Format = "MM/dd/yyyy";

            dgvChecks.Columns[0].Frozen = false;
            dgvChecks.Columns[1].Frozen = false;
            dgvChecks.Columns[2].Frozen = false;
            dgvChecks.Columns[3].Frozen = false;
            dgvChecks.Columns[4].Frozen = false;
            dgvChecks.Columns[5].Frozen = false;
            dgvChecks.Columns[6].Frozen = false;
            dgvChecks.Columns[7].Frozen = false;
            dgvChecks.Columns[8].Frozen = false;
            dgvChecks.Columns[9].Frozen = false;
            dgvChecks.Columns[10].Frozen = false;

            //dgvChecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //SELECTION MODE
            dgvChecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChecks.MultiSelect = false;
            //dgvChecks.ScrollBars = ScrollBars.Both;


            //Pagination

            MySqlConnect MySqlConn = new MySqlConnect();


            string SQLStatement;


            if (strSearch == "SEARCH")
            {
                SQLStatement = "SELECT * FROM `rci_check_voucher` WHERE `payee` LIKE  " + "'%" + searchContent + "%'"
                    + "OR `particulars` LIKE" + "'%" + searchContent + "%'"
                    + "OR `amount` LIKE" + "'%" + searchContent + "%'"
                    + "OR `check_No` LIKE" + "'%" + searchContent + "%'"
                    + "OR `posting_Status` LIKE" + "'%" + searchContent + "%'"
                    + " ORDER BY `voucher_No` DESC LIMIT " + page_1 + "," + dataperPage;
            }
            else
            {
                SQLStatement = "SELECT * FROM `rci_check_voucher` ORDER BY `voucher_No` DESC LIMIT " + page_1 + "," + dataperPage;
            }


            MySqlConn.mysqlQuery = SQLStatement;

            MySqlConn.retrieve(dgvChecks);

            pnlNewCV.Hide();

        }

        public void readAllData()
        {
            //DATAGRIDVIEW PROPERTIES

            dgvChecks.ColumnCount = 11;
            dgvChecks.Columns[0].Name = "Date";
            dgvChecks.Columns[1].Name = "Voucher No.";
            dgvChecks.Columns[2].Name = "Check No.";
            dgvChecks.Columns[3].Name = "Payee";
            dgvChecks.Columns[4].Name = "Amount";
            dgvChecks.Columns[5].Name = "Particulars";
            dgvChecks.Columns[6].Name = "Type";
            dgvChecks.Columns[7].Name = "Check Date";
            dgvChecks.Columns[8].Name = "Bank";
            dgvChecks.Columns[9].Name = "User";
            dgvChecks.Columns[10].Name = "Payment Status";

            dgvChecks.Columns[4].DefaultCellStyle.Format = "n2";
            dgvChecks.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvChecks.Columns[7].DefaultCellStyle.Format = "MM/dd/yyyy";

            dgvChecks.Columns[0].Frozen = false;
            dgvChecks.Columns[1].Frozen = false;
            dgvChecks.Columns[2].Frozen = false;
            dgvChecks.Columns[3].Frozen = false;
            dgvChecks.Columns[4].Frozen = false;
            dgvChecks.Columns[5].Frozen = false;
            dgvChecks.Columns[6].Frozen = false;
            dgvChecks.Columns[7].Frozen = false;
            dgvChecks.Columns[8].Frozen = false;
            dgvChecks.Columns[9].Frozen = false;
            dgvChecks.Columns[10].Frozen = false;

            //dgvChecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //SELECTION MODE
            dgvChecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChecks.MultiSelect = false;
            //dgvChecks.ScrollBars = ScrollBars.Both;


            //Pagination

            MySqlConnect MySqlConn = new MySqlConnect();


            string SQLStatement;

            SQLStatement = "SELECT * FROM `rci_check_voucher` ORDER BY `voucher_No` DESC";


            MySqlConn.mysqlQuery = SQLStatement;

            MySqlConn.retrieve(dgvChecks);

            pnlNewCV.Hide();

        }
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
        }

        private void btnPost_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }


        public string pendingVoucherNo;
        private void dgvChecks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11) //Update Column
            {
                Post = "Update";

                pnlNewCV.Show();
                btnBankSearch.Show();
                btnPayeeSearch.Show();

                txtNo.Text = dgvChecks.SelectedRows[0].Cells[1].Value.ToString();
                txtNo.Enabled = false;
                txtNo.BackColor = Color.FromArgb(186, 139, 249);
                txtType.Text = dgvChecks.SelectedRows[0].Cells[6].Value.ToString();
                txtType.Enabled = false;
                txtType.BackColor = Color.FromArgb(186, 139, 249);
                txtCheckNo.Text = dgvChecks.SelectedRows[0].Cells[2].Value.ToString();
                cmbPayee.Items.Add(dgvChecks.SelectedRows[0].Cells[3].Value.ToString());
                cmbPayee.SelectedIndex = 0;
                cmbBank.Items.Add(dgvChecks.SelectedRows[0].Cells[8].Value.ToString());
                cmbBank.SelectedIndex = 0;
                txtAmount.Text = dgvChecks.SelectedRows[0].Cells[4].Value.ToString();
                txtParticulars.Text = dgvChecks.SelectedRows[0].Cells[5].Value.ToString();
                dtpCheckDate.Value = Convert.ToDateTime(dgvChecks.SelectedRows[0].Cells[7].Value.ToString());
                lblTransDate.Text = DateTime.Now.ToLongDateString();
                converttoNumber();

                btnPost.Text = "Update";

            }

            if (e.ColumnIndex == 12) //Delete Column
            {
                MySqlConnect MySqlConn = new MySqlConnect();
                //MySqlConn.mysqlQuery = "DELETE FROM `rci_check_voucher` WHERE `voucher_No` = @no";
                MySqlConn.mysqlQuery = "UPDATE `rci_check_voucher` SET `posting_Status` = 'Cancelled' WHERE `voucher_No` = @no";

                DialogResult dataDelete = MessageBox.Show("Are you sure you want to cancel this voucher?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dataDelete == DialogResult.Yes)
                {
                    txtNo.Text = dgvChecks.SelectedRows[0].Cells[1].Value.ToString();
                    MySqlConn.delete(Convert.ToInt32(txtNo.Text));
                }

                txtNo.Text = null;
                cmbPayee.Text = null;
                cmbPayee.Items.Clear();
                cmbBank.Items.Clear();
                txtAmount.Text = null;
                txtParticulars.Text = null;
                txtCheckNo.Text = null;

                txtType.Text = null;
                txtWords.Text = null;

                pnlNewCV.Hide();


                readData();

            }

            if (e.ColumnIndex == 13) //Update Posting Status
            {
                gunaTransition1.Show(rdoPanel);

                rdovoucherNo = Convert.ToInt32(dgvChecks.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTransDate.Text = DateTime.Now.ToLongDateString();
        }


        private void converttoNumber()
        {
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Insert amount", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string number = NumberToText.Convert(decimal.Parse(txtAmount.Text));
                txtWords.Text = number;
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            converttoNumber();
        }

        public void fillComboPayee()
        {
            //LOOP THRU cmbPayee

            MySqlConnect MySqlConn = new MySqlConnect();
            MySqlCommand mySqlCmd = new MySqlCommand("SELECT `payee_Name` FROM `rci_payee_profile` ORDER BY `payee_Name` ASC", MySqlConn.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            MySqlConn.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbPayee.Items.Add(row[0].ToString());
            }



        }

        public void fillComboBank()
        {
            //LOOP THRU cmbBank

            MySqlConnect MySqlConn2 = new MySqlConnect();
            MySqlCommand mySqlCmd2 = new MySqlCommand("SELECT `sl_name` FROM `rci_chart_of_accounts` WHERE `gl_no` = 150 ORDER BY `sl_name` ASC", MySqlConn2.mySqlconn);
            MySqlDataAdapter mySqlAdapter2 = new MySqlDataAdapter();
            mySqlAdapter2.SelectCommand = mySqlCmd2;
            System.Data.DataTable mySqlDataTable2 = new System.Data.DataTable();
            mySqlAdapter2.Fill(mySqlDataTable2);

            MySqlConn2.closeConnection();

            foreach (DataRow row in mySqlDataTable2.Rows)
            {
                cmbBank.Items.Add(row[0].ToString());
            }


        }
        private void btnCreateCV_Click(object sender, EventArgs e)
        {

            pnlNewCV.Show();

            btnBankSearch.Hide();
            btnPayeeSearch.Hide();


            fillComboPayee();
            fillComboBank();


            txtNo.Text = null;
            txtNo.Enabled = false;
            txtNo.BackColor = Color.FromArgb(186, 139, 249);
            txtAmount.Text = null;
            txtParticulars.Text = null;
            txtCheckNo.Text = null;
            txtType.Text = "CV";
            txtType.Enabled = false;
            txtType.BackColor = Color.FromArgb(186, 139, 249);
            txtWords.Text = null;
            dtpCheckDate.Text = null;
            lblTransDate.Text = DateTime.Now.ToLongDateString();
            timer1.Start();

            btnPost.Text = "Post";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            readData();
            pnlNewCV.Hide();
        }

        private void btnAddCheckName_Click(object sender, EventArgs e)
        {
            frmPayees frmCheckNames = new frmPayees();
            frmCheckNames.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmPayees frmCheckNames = new frmPayees();
            frmCheckNames.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            MySqlConnect mySqlConn = new MySqlConnect();

            mySqlConn.getVoucherNo = Convert.ToInt32(dgvChecks.SelectedRows[0].Cells[1].Value.ToString());

            mySqlConn.getPrintString = (sender as Guna2ImageButton).Name;

            frmViewer crptViewer = new frmViewer();

            crptViewer.ShowDialog();


        }

        public void PostData()
        {

            MySqlConnect MySqlConn = new MySqlConnect();


            if (Post == "Post")
            {

                try
                {
                    if (txtAmount.Text == "" || txtCheckNo.Text == "" || txtParticulars.Text == "" || txtType.Text == "" || txtWords.Text == "" || cmbBank.Text == "" || cmbPayee.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MySqlConn.mysqlQuery = "SELECT MAX(`voucher_No`) FROM  `rci_check_voucher`";
                    MySqlConn.maxVoucherNo();

                    DialogResult resultInsert = MessageBox.Show("Do you want to continue posting?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultInsert == DialogResult.Yes)
                    {
                        MySqlConn.mysqlQuery = "INSERT INTO `rci_check_voucher`(`voucher_Type`,`voucher_No`,`payee`,`amount`,`particulars`,`check_No`,`check_Date`,`transaction_Date`,`bank`,`user`,`posting_Status`)  " +
                         "VALUES(@type,@no,@payee,@amount,@particulars,@checkNo,@checkDate,@transDate,@bank,@user,@posting)";

                        lblTransDate.Text = DateTime.Now.ToLongTimeString();

                        MySqlConn.myType = "CV";
                        MySqlConn.myNo = MySqlConn.voucherNo;
                        MySqlConn.myPayee = cmbPayee.Text;
                        MySqlConn.myAmount = Convert.ToDouble(txtAmount.Text);
                        MySqlConn.myParticulars = txtParticulars.Text;
                        MySqlConn.myCheckNo = txtCheckNo.Text;
                        MySqlConn.myCheckDate = Convert.ToDateTime(dtpCheckDate.Text);
                        MySqlConn.myTransDate = Convert.ToDateTime(lblTransDate.Text);
                        if (btnPDC.Checked)
                        {
                            MySqlConn.myPostingStatus = "PDC-Pending";
                        }
                        else
                        {
                            MySqlConn.myPostingStatus = "NCV-Pending";
                        }

                        MySqlConn.myBank = cmbBank.Text;
                        MySqlConn.myCheckDataInsert();
                    }

                    txtNo.Text = null;
                    cmbPayee.Text = null;
                    cmbPayee.Items.Clear();
                    cmbBank.Text = null;
                    cmbBank.Items.Clear();
                    txtAmount.Text = null;
                    txtParticulars.Text = null;
                    txtCheckNo.Text = null;

                    txtType.Text = null;
                    txtWords.Text = null;

                    pnlNewCV.Hide();
                    readData();
                }

                catch (Exception ex)
                {
                    Accounting Acctg = new Accounting();
                    Acctg.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else //Update
            {
                try
                {

                    if (txtAmount.Text == "" || txtCheckNo.Text == "" || txtNo.Text == "" || txtParticulars.Text == "" || txtType.Text == "" || txtWords.Text == "" || cmbBank.Text == "" || cmbPayee.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MySqlConn.mysqlQuery = "UPDATE `rci_check_voucher` SET `voucher_Type` = @type, `payee` = @payee,`amount` = @amount," +
                        "`particulars` = @particulars,`check_No` = @checkNo,`check_Date` = @checkDate,`transaction_Date` = @transDate,`user` = @myAccount,`bank` = @bank WHERE `voucher_No` = @no";

                    DialogResult dataUpdate = MessageBox.Show("Update data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dataUpdate == DialogResult.Yes)
                    {
                        MySqlConn.update(Convert.ToInt32(txtNo.Text), txtType.Text, Convert.ToInt32(txtCheckNo.Text), cmbPayee.Text, Convert.ToDouble(txtAmount.Text), txtParticulars.Text, Convert.ToDateTime(dtpCheckDate.Text), Convert.ToDateTime(lblTransDate.Text), MySqlConn.myAccount, cmbBank.Text);
                    }

                    txtNo.Text = null;
                    cmbPayee.Text = null;
                    cmbPayee.Items.Clear();
                    cmbBank.Text = null;
                    cmbBank.Items.Clear();
                    txtAmount.Text = null;
                    txtParticulars.Text = null;
                    txtCheckNo.Text = null;

                    txtType.Text = null;
                    txtWords.Text = null;

                    pnlNewCV.Hide();
                    readData();
                }
                catch (Exception ex)
                {
                    Accounting Acctg = new Accounting();
                    Acctg.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
        }

        private void btnPost_Click_1(object sender, EventArgs e)
        {
            Post = (sender as Guna2Button).Text;
            PostData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cmbPayee.Items.Clear();
            cmbBank.Items.Clear();
            pnlNewCV.Hide();
        }

        private void btnChartAccount_Click(object sender, EventArgs e)
        {
            frmChartofAccounts frmzCA = new frmChartofAccounts();
            frmzCA.ShowDialog();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            page_1 = (one * dataperPage) - dataperPage;
            readData();
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {

            page_1 = (two * dataperPage) - dataperPage;
            readData();
        }

        private void btnThird_Click(object sender, EventArgs e)
        {

            page_1 = (three * dataperPage) - dataperPage;
            readData();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            one = Convert.ToInt32(btnThird.Text) + 1;
            two = Convert.ToInt32(btnThird.Text) + 2;
            three = Convert.ToInt32(btnThird.Text) + 3;

            btnOne.Text = Convert.ToString(one);
            btnSecond.Text = Convert.ToString(two);
            btnThird.Text = Convert.ToString(three);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            one = 1;
            two = 2;
            three = 3;

            btnOne.Text = Convert.ToString(1);
            btnSecond.Text = Convert.ToString(2);
            btnThird.Text = Convert.ToString(3);

            page_1 = 0;
            readData();
        }

        private void btnSearch_KeyUp(object sender, KeyEventArgs e)
        {
            strSearch = (sender as Guna2TextBox).PlaceholderText;
            searchContent = btnSearch.Text;
            readData();
        }

        private void btnBankSearch_Click(object sender, EventArgs e)
        {
            fillComboBank();
        }

        private void btnPayeeSearch_Click(object sender, EventArgs e)
        {
            fillComboPayee();
        }

        private void btnCheckPrint_Click(object sender, EventArgs e)
        {
            MySqlConnect mySqlConn = new MySqlConnect();

            mySqlConn.getVoucherNo = Convert.ToInt32(dgvChecks.SelectedRows[0].Cells[1].Value.ToString());

            mySqlConn.getPrintString = (sender as Guna2ImageButton).Name;

            frmViewer crptViewer = new frmViewer();

            crptViewer.ShowDialog();
        }

        private void txtCheckNoAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

            InputHandler inputChecker = new InputHandler();

            inputChecker.CheckInputNum(e);

            inputChecker.CheckEnterKey(PostData, e);

        }

        private void cmbBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandler inputChecker = new InputHandler();

            inputChecker.CheckEnterKey(PostData, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gunaTransition1.Hide(rdoPanel);
        }

        private void btnUpdateRdo_Click(object sender, EventArgs e)
        {

            if (rdoPending.Checked)
            {
                postStatus = "NCV-Pending";
            }
            else if (rdoForRelease.Checked)
            {
                postStatus = "NCV-For Release";
            }
            else if (rdoReleased.Checked)
            {
                postStatus = "NCV-Released";
            }
            else if (rdoCleared.Checked)
            {
                postStatus = "NCV-Cleared";
            }
            else if (rdoPDCPending.Checked)
            {
                postStatus = "PDC-Pending";
            }
            else if (rdoPDCforRelease.Checked)
            {
                postStatus = "PDC-For Release";
            }
            else if (rdoPDCReleased.Checked)
            {
                postStatus = "PDC-Released";
            }
            else if (rdoPDCDue.Checked)
            {
                postStatus = "PDC-Due";
            }
            else
            {
                postStatus = "PDC-Cleared";
            }

            DialogResult postPrompt = MessageBox.Show("Change Current Status?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (postPrompt == DialogResult.Yes)
            {
                MySqlConnect MySqlConn = new MySqlConnect();
                MySqlConn.mysqlQuery = "UPDATE `rci_check_voucher` SET `posting_Status` = @status WHERE `voucher_No` = @no";

                MySqlConn.myStatusUpdate(postStatus, rdovoucherNo);
            }

            gunaTransition1.Hide(rdoPanel);

            readData();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            readAllData();
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dgvChecks.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dgvChecks.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dgvChecks.Rows.Count; i++)
            {
                for (int j = 0; j < dgvChecks.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dgvChecks[j, i].Value == null ? "" : dgvChecks[j, i].Value;
                    myRange.Select();
                }
            }
            readData();
            MessageBox.Show("Data exported to excel", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
