using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScrollBars = System.Windows.Forms.ScrollBars;

namespace EXIN
{
    public partial class UCSL : UserControl
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
        int userId;
        string SQLStatement;
        string activePage;

        MySqlConnect ConnAll = new MySqlConnect();
        FS FSConn = new FS();


        public UCSL()
        {
            InitializeComponent();


            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Subledger Report";
        }

        Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper hScrollHelper;
        Guna.UI.Lib.ScrollBar.DataGridViewScrollHelper vScrollHelper;

        private void UCSL_Load(object sender, EventArgs e)
        {

            fillBusUnit();
            fillChartOfAccounts();

            //readSOAData();
        }

        /***********************READ DATA**********************/
        public void readSLData()
        {
            //DATAGRIDVIEW PROPERTIES

            dgvSL.ColumnCount = 5;
            dgvSL.Columns[0].Name = "Date";
            dgvSL.Columns[1].Name = "Amount";
            dgvSL.Columns[2].Name = "GL_No";
            dgvSL.Columns[3].Name = "GLSL";
            dgvSL.Columns[4].Name = "Unit_Code";



            dgvSL.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvSL.Columns[1].DefaultCellStyle.Format = "n2";


            dgvSL.Columns[0].Frozen = false;
            dgvSL.Columns[1].Frozen = false;
            dgvSL.Columns[2].Frozen = false;
            dgvSL.Columns[3].Frozen = false;
            dgvSL.Columns[4].Frozen = false;




            //dgvSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvSL.Columns[0].Width = 100;
            dgvSL.Columns[1].Width = 150;
            dgvSL.Columns[2].Width = 70;
            dgvSL.Columns[3].Width = 70;
            dgvSL.Columns[4].Width = 125;


            //SELECTION MODE

            dgvSL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSL.MultiSelect = false;

            if (cmbCOA.Text != "" & cmbBusUnit.Text == "")
            {
                SQLStatement = @"SELECT DATE, SUM(`Amount`) AS `Amount`, GL, GLSL, Unit_Code FROM(SELECT NOW() AS DATE, `Amount`,
                                             `GLSL`,`Unit_Code`,LEFT(tbl_transaction.GLSL, 3) AS `GL` FROM tbl_transaction
                                            )sub"
                                            + " WHERE GL LIKE " + "'%" + COACode + "%'"
                                            + " GROUP BY GLSL, Unit_Code"
                                            + " ORDER BY GLSL ASC;";
            }
            else if (cmbCOA.Text == "" & cmbBusUnit.Text != "")
            {
                SQLStatement = @"SELECT DATE, SUM(`Amount`) AS `Amount`, GL, GLSL, Unit_Code FROM(SELECT NOW() AS DATE, `Amount`,
                                             `GLSL`,`Unit_Code`,LEFT(tbl_transaction.GLSL, 3) AS `GL` FROM tbl_transaction
                                            )sub"
                                        + " WHERE Unit_Code LIKE " + "'%" + busUnit + "%'"
                                        + " GROUP BY GLSL, Unit_Code"
                                        + " ORDER BY GLSL ASC;";
            }
            else if (cmbCOA.Text != "" & cmbBusUnit.Text != "")
            {
                SQLStatement = @"SELECT DATE, SUM(`Amount`) AS `Amount`, GL, GLSL, Unit_Code FROM(SELECT NOW() AS DATE, `Amount`,
                                             `GLSL`,`Unit_Code`,LEFT(tbl_transaction.GLSL, 3) AS `GL` FROM tbl_transaction
                                            )sub"
                                        + " WHERE Unit_Code LIKE " + "'%" + busUnit + "%'"
                                        + " AND GL LIKE " + "'%" + COACode + "%'"
                                        + " GROUP BY GLSL, Unit_Code"
                                        + " ORDER BY GLSL ASC;";
            }
            else
            {
                SQLStatement = @"SELECT DATE, SUM(`Amount`) AS `Amount`, GL, GLSL, Unit_Code FROM(SELECT NOW() AS DATE, `Amount`,
                                             `GLSL`,`Unit_Code`,LEFT(tbl_transaction.GLSL, 3) AS `GL` FROM tbl_transaction
                                            )sub"
                                        + " WHERE Unit_Code LIKE " + "'%" + busUnit + "%'"
                                        + " AND GL LIKE " + "'%" + COACode + "%'"
                                        + " GROUP BY GLSL, Unit_Code"
                                        + " ORDER BY GLSL ASC;";
            }




            FSConn.mysqlQuery = SQLStatement;

            FSConn.retrieveSL(dgvSL);


            //dgvSL.Rows[0].Selected = false;
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


            MySqlCommand mySqlCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Unit_Code` = @Unit_Code " +
                "ORDER BY `Project_Name` ASC", ConnAll.mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@Unit_Code", busUnit);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);



            foreach (DataRow row in mySqlDataTable.Rows)
            {
                //cmbProject.Items.Add(row[1].ToString());
            }


        }

        public void fillCostCenter()
        {
            // cmbCostCenter.Items.Clear();


            //LOOP THRU cmbCostCenter


            MySqlCommand mySqlCmd = new MySqlCommand("SELECT `CostCenter_Code`,`CostCenter_Name` FROM `tbl_costcenter`  " +
                "ORDER BY `CostCenter_Name` ASC", ConnAll.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);



            foreach (DataRow row in mySqlDataTable.Rows)
            {
                //cmbCostCenter.Items.Add(row[1].ToString());
            }

        }

        public void fillChartOfAccounts()
        {
            cmbCOA.Items.Clear();


            //LOOP THRU cmbCostCenter


            MySqlCommand mySqlCmd = new MySqlCommand("SELECT DISTINCT `GL`, `GL_Account` FROM `tbl_chartofaccounts`  " +
                "ORDER BY `GL` ASC", ConnAll.mySqlconn);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbCOA.Items.Add(row[1].ToString());
            }
        }

        private void cmbBusUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
            fillProject();
            fillCostCenter();
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            //cmbProject.Items.Clear();
            // cmbCostCenter.Items.Clear();
            cmbCOA.SelectedIndex = -1;

            busUnit = "";
            projectCode = "";
            costCenterCode = "";
            COACode = "";

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



            ////Get Project Code


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


            //MySqlCommand CostCenterCmd = new MySqlCommand("SELECT `CostCenter_Code`,`CostCenter_Name` FROM `tbl_costcenter` " +
            //    "WHERE CostCenter_Name = @CostCenter  " +
            //    "ORDER BY `CostCenter_Name` ASC", ConnAll.mySqlconn);
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

            MySqlCommand COACmd = new MySqlCommand("SELECT `GL`, `GL_Account` FROM `tbl_chartofaccounts`  " +
                "WHERE GL_Account = @GL  " +
                "ORDER BY `GL` ASC", ConnAll.mySqlconn);
            COACmd.Parameters.AddWithValue("@GL", cmbCOA.Text);
            MySqlDataAdapter COAAdapter = new MySqlDataAdapter();
            COAAdapter.SelectCommand = COACmd;
            System.Data.DataTable COADataTable = new System.Data.DataTable();
            COAAdapter.Fill(COADataTable);

            foreach (DataRow row in COADataTable.Rows)
            {
                COACode = row[0].ToString();
            }

            ConnAll.closeConnection();


        }

        /**************************EXCEL EXPORT***********************/

        private void replaceDgvString()
        {


            foreach (DataGridViewRow row in dgvSL.Rows)
            {

                foreach (DataGridViewCell c in row.Cells)
                {


                    c.Value = Regex.Replace(c.Value.ToString(), @"\t|\n|\r|[,]", "");

                }
            }
        }


        private void ExportCSV()
        {
            readSLData();
            replaceDgvString();

            if (dgvSL.Rows.Count > 0)
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
                            int columnCount = dgvSL.Columns.Count;
                            string columnNames = "";
                            int rowCount = dgvSL.Rows.Count;

                            var outputCsv = new string[rowCount + 1];

                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvSL.Columns[i].HeaderText + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvSL.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvSL.Rows[i - 1].Cells[j].Value.ToString() + ",";
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






        /*****************PAGINATION*****************/
        private void btnPageReset_Click(object sender, EventArgs e)
        {
            //one = 1;
            //two = 2;
            //three = 3;

            //btnOne.Text = Convert.ToString(1);
            //btnSecond.Text = Convert.ToString(2);
            //btnThird.Text = Convert.ToString(3);

            //page_1 = 0;

            //activePage = btnOne.Name;
            //highlightPage();

            //readSLData();
        }



        private void btnOne_Click(object sender, EventArgs e)
        {
            page_1 = (one * dataperPage) - dataperPage;
            activePage = (sender as Guna2CircleButton).Name;
            highlightPage();

            readSLData();
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            page_1 = (two * dataperPage) - dataperPage;
            activePage = (sender as Guna2CircleButton).Name;
            highlightPage();

            readSLData();
        }

        private void btnThird_Click(object sender, EventArgs e)
        {
            page_1 = (three * dataperPage) - dataperPage;
            activePage = (sender as Guna2CircleButton).Name;
            highlightPage();

            readSLData();


        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            //one = Convert.ToInt32(btnThird.Text) + 1;
            //two = Convert.ToInt32(btnThird.Text) + 2;
            //three = Convert.ToInt32(btnThird.Text) + 3;

            //btnOne.Text = Convert.ToString(one);
            //btnSecond.Text = Convert.ToString(two);
            //btnThird.Text = Convert.ToString(three);

            //foreach (Control c in pnlPages.Controls)
            //{
            //        c.BackColor = Color.Transparent;
            //}
        }

        public void highlightPage()
        {
            //foreach (Control c in pnlPages.Controls)
            //{
            //    if (c.Name == activePage)
            //    {
            //        c.BackColor = Color.FromArgb(80, 201, 195);
            //    }
            //    else
            //    {
            //        c.BackColor = Color.Transparent;
            //    }
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            readSLData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            //cmbProject.SelectedIndex = -1;
            //cmbCostCenter.SelectedIndex = -1;
            cmbCOA.SelectedIndex = -1;

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            populateFilterCodes();
            readSLData();
            totalStatement();



        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }


        private void totalStatement()
        {
            int sum = 0;
            for (int i = 0; i < dgvSL.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvSL.Rows[i].Cells[1].Value);
            }
            txtTotal.Text = sum.ToString("0,0.00", CultureInfo.InvariantCulture);


        }

        private void dgvSL_MouseHover(object sender, EventArgs e)
        {
            dgvSL.ScrollBars = ScrollBars.Both;
        }

        private void dgvSL_MouseLeave(object sender, EventArgs e)
        {
            dgvSL.ScrollBars = ScrollBars.None;
        }
    }
}
