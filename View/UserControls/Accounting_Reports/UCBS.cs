using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCBS : UserControl
    {
        public UCBS()
        {
            InitializeComponent();
            //pnlPreloader.Hide();
        }

        string busUnitName;
        string busUnit;
        string projectCode;
        string costCenterCode;
        string busUQuery;
        int userId;
        string categoryCode;
        FS FSConnAll = new FS();
        MySqlConnect ConnAll = new MySqlConnect();

        //Preloader

        //private void SetPreloader(bool displayLoader)
        //{
        //    if (displayLoader)
        //    {
        //        this.Invoke((MethodInvoker)delegate
        //        {


        //            pnlPreloader.Show();
        //            pnlPreloader.BringToFront();
        //            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        //        });
        //    }
        //    else
        //    {
        //        this.Invoke((MethodInvoker)delegate
        //        {

        //            pnlPreloader.Hide();

        //            this.Cursor = System.Windows.Forms.Cursors.Default;
        //        });
        //    }
        //}

        private void loadFS()
        {

            //Preloader Start
            //SetPreloader(true);
            //Asset Setup

            // DATAGRIDVIEW PROPERTIES

            dgvRevenue.ColumnCount = 3;
            dgvRevenue.Columns[0].Name = "GL";
            dgvRevenue.Columns[1].Name = "Account";
            dgvRevenue.Columns[2].Name = "Amount";

            dgvRevenue.Columns[2].DefaultCellStyle.Format = "n2";
            dgvRevenue.Columns[0].Width = 70;
            dgvRevenue.Columns[1].Width = 130;
            dgvRevenue.Columns[2].Width = 124;
            //dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvRevenue.Columns[0].Frozen = false;
            dgvRevenue.Columns[1].Frozen = false;
            dgvRevenue.Columns[2].Frozen = false;


            dgvExpenses.ColumnCount = 3;
            dgvExpenses.Columns[0].Name = "GL";
            dgvExpenses.Columns[1].Name = "Account";
            dgvExpenses.Columns[2].Name = "Amount";

            dgvExpenses.Columns[2].DefaultCellStyle.Format = "n2";
            dgvExpenses.Columns[0].Width = 70;
            dgvExpenses.Columns[1].Width = 130;
            dgvExpenses.Columns[2].Width = 124;

            //dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvExpenses.Columns[0].Frozen = false;
            dgvExpenses.Columns[1].Frozen = false;
            dgvExpenses.Columns[2].Frozen = false;


            dgvAssets.ColumnCount = 3;
            dgvAssets.Columns[0].Name = "GL";
            dgvAssets.Columns[1].Name = "Account";
            dgvAssets.Columns[2].Name = "Amount";

            dgvAssets.Columns[2].DefaultCellStyle.Format = "n2";
            dgvAssets.Columns[0].Width = 70;
            dgvAssets.Columns[1].Width = 130;
            dgvAssets.Columns[2].Width = 124;


            //dgvAssets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvAssets.Columns[0].Frozen = false;
            dgvAssets.Columns[1].Frozen = false;
            dgvAssets.Columns[2].Frozen = false;


            dgvLiabilities.ColumnCount = 3;
            dgvLiabilities.Columns[0].Name = "GL";
            dgvLiabilities.Columns[1].Name = "Account";
            dgvLiabilities.Columns[2].Name = "Amount";

            dgvLiabilities.Columns[2].DefaultCellStyle.Format = "n2";
            dgvLiabilities.Columns[0].Width = 70;
            dgvLiabilities.Columns[1].Width = 130;
            dgvLiabilities.Columns[2].Width = 124;
            //dgvLiabilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvLiabilities.Columns[0].Frozen = false;
            dgvLiabilities.Columns[1].Frozen = false;
            dgvLiabilities.Columns[2].Frozen = false;

            //CategoryCode Setup


            FSConnAll.mysqlQuery = @"SELECT `Category_Code`                                            
                                            FROM `tbl_units` WHERE `Unit_Code` = '" + busUnit + "'";


            FSConnAll.fetchCategoryCode();

            categoryCode = FSConnAll.categoryCode;


            //REVENUE Set up

            if (busUnit != null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                            FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                            FROM tbl_transaction
                                                             WHERE " +
                                                "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                "AND tbl_transaction.Status = 'Active' " + @") sub
                                                            WHERE GLSL < 800
                                                             AND GLSL >= 700
                                                            GROUP BY GLSL 
                                                            ORDER BY GLSL ASC) sub2
                                                            LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                            WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";



                FSConnAll.fetchFSGrid(dgvRevenue);

            }

            else if (busUnit != null && projectCode != null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                            FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                            FROM tbl_transaction
                                                             WHERE " +
                                                        "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                        "AND tbl_transaction.Status = 'Active' " +
                                                        "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" + @") sub
                                                            WHERE GLSL < 800
                                                             AND GLSL >= 700
                                                            GROUP BY GLSL 
                                                            ORDER BY GLSL ASC) sub2
                                                            LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                            WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvRevenue);

            }
            else if (busUnit != null && projectCode != null && costCenterCode != null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                            FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                            FROM tbl_transaction
                                                             WHERE " +
                                           "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                           "AND tbl_transaction.Status = 'Active' " +
                                           "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" +
                                          "AND tbl_transaction.CostCenter_Code = " + "'" + costCenterCode + "'" + @") sub
                                                            WHERE GLSL < 800
                                                             AND GLSL >= 700
                                                            GROUP BY GLSL 
                                                            ORDER BY GLSL ASC) sub2
                                                            LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                            WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvRevenue);
            }
            else if (busUnit == null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                    "tbl_transaction.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                                    "AND tbl_transaction.Status = 'Active' " +
                                                    "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                                   "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + @") sub
                                                        WHERE GLSL < 800
                                                         AND GLSL >= 700
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvRevenue);
            }
            else
            {
                MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //OPEX Setup

            if (busUnit != null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                      "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                      "AND tbl_transaction.Status = 'Active' " + @") sub
                                                        WHERE GLSL < 900
                                                         AND GLSL >= 800
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvExpenses);
            }

            else if (busUnit != null && projectCode != null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                 "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                 "AND tbl_transaction.Status = 'Active' " +
                                                 "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" + @") sub
                                                        WHERE GLSL < 900
                                                         AND GLSL >= 800
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvExpenses);
            }
            else if (busUnit != null && projectCode != null && costCenterCode != null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                    "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                    "AND tbl_transaction.Status = 'Active' " +
                                                    "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" +
                                                   "AND tbl_transaction.CostCenter_Code = " + "'" + costCenterCode + "'" + @") sub
                                                        WHERE GLSL < 900
                                                         AND GLSL >= 800
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvExpenses);
            }
            else if (busUnit == null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                               "tbl_transaction.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                               "AND tbl_transaction.Status = 'Active' " +
                                               "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                              "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + @") sub
                                                        WHERE GLSL < 900
                                                         AND GLSL >= 800
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFSGrid(dgvExpenses);
            }
            else
            {
                MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




            //Other Expense Setup

            if (busUnit != null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                      "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                      "AND tbl_transaction.Status = 'Active' " + @") sub
                                                        WHERE GLSL >= 900
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFS(pnlNetIncome);
            }
            else if (busUnit != null && projectCode != null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                         "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                         "AND tbl_transaction.Status = 'Active' " +
                                                         "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" + @") sub
                                                        WHERE GLSL >= 900
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFS(pnlNetIncome);
            }
            else if (busUnit != null && projectCode != null && costCenterCode != null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                            "tbl_transaction.Unit_Code LIKE " + "'" + busUnit + "'" +
                                            "AND tbl_transaction.Status = 'Active' " +
                                           "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" +
                                           "AND tbl_transaction.CostCenter_Code = " + "'" + costCenterCode + "'" + @") sub
                                                        WHERE GLSL >= 900
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFS(pnlNetIncome);
            }
            else if (busUnit == null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                 "tbl_transaction.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                                 "AND tbl_transaction.Status = 'Active' " +
                                                 "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                                "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + @") sub
                                                        WHERE GLSL >= 900
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                        LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchFS(pnlNetIncome);
            }
            else
            {
                MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //PNL Total Setup in NetIncomePanel

            if (busUnit != null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                         "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                         "AND tbl_transaction.Status = 'Active' " + @") sub
                                                        WHERE GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchPnlTotal(pnlNetIncome);
            }
            else if (busUnit != null && projectCode != null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                           "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                           "AND tbl_transaction.Status = 'Active' " +
                                           "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" + @") sub
                                                        WHERE GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchPnlTotal(pnlNetIncome);

            }
            else if (busUnit != null && projectCode != null && costCenterCode != null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                      "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                      "AND tbl_transaction.Status = 'Active' " +
                                                      "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" +
                                                     "AND tbl_transaction.CostCenter_Code = " + "'" + costCenterCode + "'" + @") sub
                                                        WHERE GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchPnlTotal(pnlNetIncome);
            }
            else if (busUnit == null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                    "tbl_transaction.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                                    "AND tbl_transaction.Status = 'Active' " +
                                                    "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                                   "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + @") sub
                                                        WHERE GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchPnlTotal(pnlNetIncome);

            }
            else
            {
                MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }





            //Sum Sales

            if (busUnit != null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                   "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                   "AND tbl_transaction.Status = 'Active' " + @") sub
                                                        WHERE GLSL < 800
                                                        AND GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtSales);
            }
            else if (busUnit != null && projectCode != null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                         "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                         "AND tbl_transaction.Status = 'Active' " +
                                         "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" + @") sub
                                                        WHERE GLSL < 800
                                                        AND GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtSales);
            }
            else if (busUnit != null && projectCode != null && costCenterCode != null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                  "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                  "AND tbl_transaction.Status = 'Active' " +
                                                  "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" +
                                                 "AND tbl_transaction.CostCenter_Code = " + "'" + costCenterCode + "'" + @") sub
                                                        WHERE GLSL < 800
                                                        AND GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtSales);
            }
            else if (busUnit == null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                               "tbl_transaction.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                               "AND tbl_transaction.Status = 'Active' " +
                                               "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                              "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + @") sub
                                                        WHERE GLSL < 800
                                                        AND GLSL >= 700
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtSales);
            }
            else
            {
                MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //Sum OPEX

            if (busUnit != null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                       "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                       "AND tbl_transaction.Status = 'Active' " + @") sub
                                                       WHERE GLSL >= 800
                                                        AND GLSL < 900
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtOPEX);
            }
            else if (busUnit != null && projectCode != null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                      "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                      "AND tbl_transaction.Status = 'Active' " +
                                                      "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" + @") sub
                                                       WHERE GLSL >= 800
                                                        AND GLSL < 900
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtOPEX);
            }
            else if (busUnit != null && projectCode != null && costCenterCode != null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                                         "tbl_transaction.Unit_Code = " + "'" + busUnit + "'" +
                                                         "AND tbl_transaction.Status = 'Active' " +
                                                         "AND tbl_transaction.Project_Code = " + "'" + projectCode + "'" +
                                                        "AND tbl_transaction.CostCenter_Code = " + "'" + costCenterCode + "'" + @") sub
                                                       WHERE GLSL >= 800
                                                        AND GLSL < 900
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtOPEX);
            }
            else if (busUnit == null && projectCode == null && costCenterCode == null)
            {
                FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount,Unit_Code,Project_Code,CostCenter_Code
                                                        FROM tbl_transaction
                                                         WHERE " +
                                         "tbl_transaction.Unit_Code LIKE " + "'%" + busUnit + "%'" +
                                         "AND tbl_transaction.Status = 'Active' " +
                                         "AND tbl_transaction.Project_Code LIKE " + "'%" + projectCode + "%'" +
                                        "AND tbl_transaction.CostCenter_Code LIKE " + "'%" + costCenterCode + "%'" + @") sub
                                                       WHERE GLSL >= 800
                                                        AND GLSL < 900
                                                        ) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
                FSConnAll.fetchTotals(txtOPEX);

            }
            else
            {
                MessageBox.Show("Cannot proceed with the report, incorrect parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }





            /**************BALANCE SHEET BALANCES SETUP*******************/


            //Asset Setup


            FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                        WHERE GLSL < 400
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
            FSConnAll.fetchFSGrid(dgvAssets);



            //Liab Setup


            FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                        WHERE GLSL < 600
                                                        AND GLSL >= 400
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
            FSConnAll.fetchFSGrid(dgvLiabilities);

            //Equity Setup

            FSConnAll.mysqlQuery = @"SELECT DISTINCT sub2.GLSL, LEFT(GL_Account,20), Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                        WHERE GLSL < 700
                                                        AND GLSL >= 600
                                                        GROUP BY GLSL 
                                                        ORDER BY GLSL ASC) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
            FSConnAll.fetchFS(pnlEquities);

            //PNL Total Setup in Equity Panel


            FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                        WHERE GLSL  >= 700) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
            FSConnAll.fetchPnlTotal(pnlEquities);


            ////Sum Assets

            FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                        WHERE GLSL  < 400) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";

            FSConnAll.fetchTotals(txtAssets);

            ////Sum Liabs

            FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                         WHERE GLSL < 600
                                                        AND GLSL >= 400) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
            FSConnAll.fetchTotals(txtLiabilities);

            ////Sum Equity

            FSConnAll.mysqlQuery = @"SELECT DISTINCT Amount FROM (SELECT GLSL, FORMAT(-SUM(Amount),2) AS Amount
                                                        FROM (SELECT LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount
                                                        FROM tbl_transaction WHERE tbl_transaction.Status = 'Active') sub
                                                         WHERE GLSL >= 600) sub2
                                                         LEFT JOIN (SELECT * FROM tbl_chartofaccounts
                                                        WHERE Category_Code LIKE " + "'%" + categoryCode + "%'" + @") Chart ON  sub2.GLSL = Chart.GL;";
            FSConnAll.fetchTotals(txtEquities);

            //EBITDA

            if (txtSales.Text == "" && txtOPEX.Text != "")
            {
                var ebitda = Convert.ToDouble(txtOPEX.Text) * -1;
                txtEBITDA.Text = string.Format("{0:0,0.00}", ebitda);
            }
            else if (txtSales.Text != "" && txtOPEX.Text == "")
            {
                var ebitda = Convert.ToDouble(txtSales.Text);
                txtEBITDA.Text = string.Format("{0:0,0.00}", ebitda);
            }
            else if (txtSales.Text == "" && txtOPEX.Text == "")
            {
                txtEBITDA.Text = string.Format("{0:0,0.00}", 0);
            }
            else
            {
                var ebitda = Convert.ToDouble(txtSales.Text) - Convert.ToDouble(txtOPEX.Text);
                txtEBITDA.Text = string.Format("{0:0,0.00}", ebitda);
            }





            ////Sum EBITDA
            //FS FSSumEBITDA = new FS();
            //FSSumEBITDA.mysqlQuery = @"SELECT FORMAT(-SUM(Amount),2)
            //                                FROM (SELECT tbl_chartofaccounts.GL_Account, LEFT(tbl_transaction.GLSL,3) AS GLSL, tbl_transaction.Amount, 
            //                                        tbl_transaction.Unit_Code, tbl_transaction.Project_Code, tbl_transaction.CostCenter_Code FROM tbl_transaction
            //                                        INNER JOIN tbl_chartofaccounts ON tbl_transaction.GLSL = tbl_chartofaccounts.GLSL) sub
            //                                 WHERE GLSL >= 700
            //                                AND GLSL < 900
            //                                ;";
            //FSSumEBITDA.fetchTotals(txtEBITDA);



            //this.Invoke((MethodInvoker)delegate
            //{


            //Select Balance Sheet in ComboBox

            //dgvAssets.Rows[0].Selected = false;
            //dgvLiabilities.Rows[0].Selected = false;
            //dgvExpenses.Rows[0].Selected = false;
            //dgvRevenue.Rows[0].Selected = false;

            cmbReport.SelectedIndex = 0;
            //});

            //SetPreloader(false);

        }

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



            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbBusUnit.Items.Add(row[1].ToString());
            }

        }

        public void fillProject()
        {
            cmbProject.Items.Clear();

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
                cmbProject.Items.Add(row[1].ToString());
            }


        }

        public void fillCostCenter()
        {
            cmbCostCenter.Items.Clear();


            //LOOP THRU cmbCostCenter


            MySqlCommand mySqlCmd = new MySqlCommand("SELECT `CostCenter_Code`,`CostCenter_Name` FROM `tbl_costcenter`  " +
                "ORDER BY `CostCenter_Name` ASC", ConnAll.mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@Unit_Code", busUnit);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);



            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbCostCenter.Items.Add(row[1].ToString());
            }


        }



        private void UCBS_Load(object sender, EventArgs e)
        {

            grpFilter.Hide();

            txtBusUnit.Text = cmbBusUnit.Text;
            txtProject.Text = cmbProject.Text;
            txtCostCenter.Text = cmbCostCenter.Text;

            fillBusUnit();
            loadFS();

            //try
            //{
            //    Thread threadInput = new Thread(loadFS);
            //    threadInput.Start();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            gunaTransition1.Show(grpFilter);
            grpFilter.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
            cmbCostCenter.SelectedIndex = -1;
            gunaTransition1.Hide(grpFilter);
        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            gunaTransition1.Show(grpFilter);
            cmbReport.SelectedIndex = 0;
            grpFilter.BringToFront();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

            txtBusUnit.Text = cmbBusUnit.Text;
            txtProject.Text = cmbProject.Text;
            txtCostCenter.Text = cmbCostCenter.Text;

            //Get BusUnit Code

            MySqlCommand ConnBusUnitCmd = new MySqlCommand("SELECT `Unit_Code` FROM `tbl_units` WHERE `Unit_Name` = @Unit_Name", ConnAll.mySqlconn);
            ConnBusUnitCmd.Parameters.AddWithValue("@Unit_Name", busUnitName);
            MySqlDataAdapter ConnBusUnitAdapter = new MySqlDataAdapter();
            ConnBusUnitAdapter.SelectCommand = ConnBusUnitCmd;
            DataTable BusUnitDataTable = new DataTable();
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
            DataTable ProjectDataTable = new DataTable();
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
            DataTable mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            foreach (DataRow row in mySqlDataTable.Rows)
            {
                costCenterCode = row[0].ToString();
            }




            loadFS();

            cmbReport.SelectedIndex = 1;


            gunaTransition1.Hide(grpFilter);
        }

        private void cmbReport_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReport.GetItemText(cmbReport.SelectedItem) == "BALANCE SHEET")
            {
                //this.Invoke((MethodInvoker)delegate
                //{

                pnlPnlMain.Hide();
                pnlBSMain.Show();
                pnlBSMain.BringToFront();

                //pnlBSMain.Show();
                //pnlBSMain.BringToFront();
                //pnlPnlMain.Hide();
                //});
            }
            else if (cmbReport.GetItemText(cmbReport.SelectedItem) == "PNL")
            {

                pnlBSMain.Hide();
                pnlPnlMain.Show();
                pnlPnlMain.BringToFront();


                //pnlPnlMain.Show();
                //pnlPnlMain.BringToFront();


            }
        }

        private void cmbBusUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
            fillProject();
            fillCostCenter();
            //MessageBox.Show("Project and Cost Center are loaded","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbBusUnit.SelectedIndex = -1;
            cmbProject.Items.Clear();
            cmbCostCenter.Items.Clear();

            txtBusUnit.Text = cmbBusUnit.Text;
            txtProject.Text = cmbProject.Text;
            txtCostCenter.Text = cmbCostCenter.Text;

            busUnit = "";
            projectCode = "";
            costCenterCode = "";
        }

        private void pnlStats_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
