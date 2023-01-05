using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EXIN
{
    class FS : MySqlConnect
    {
        public string categoryCode;

        public void fetchFS(Control pnlControl)
        {
            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {


                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                foreach (Control c in pnlControl.Controls)
                {
                    c.Hide();
                }

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    UCFiguresBS uc = new UCFiguresBS();
                    uc.Dock = DockStyle.Top;

                    pnlControl.Controls.Add(uc);
                    uc.BringToFront();

                    uc.Controls[1].Text = row[1].ToString(); //GLSLname
                    uc.Controls[0].Text = row[2].ToString();//Amount
                    uc.Controls[2].Text = row[0].ToString();//Account
                    uc.Controls[0].Name = row[0].ToString();//Account

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void fetchTotals(Control txtBox)
        {
            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {


                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    txtBox.Text = row[0].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void fetchPnlTotal(Control pnlControl)
        {
            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {


                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    UCFiguresBS uc = new UCFiguresBS();
                    uc.Dock = DockStyle.Top;

                    pnlControl.Controls.Add(uc);
                    uc.BringToFront();

                    uc.Controls[1].Text = "Profit(Loss)"; //GLSLname
                    uc.Controls[0].Text = row[0].ToString();//Amount
                    uc.Controls[2].Text = " ";//GLSL
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void fetchExcelTransactions(Worksheet DataSheet, int StartCol, int StartRow, int EndCol)
        {
            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {


                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);


                int i = 0;
                int j = 0;

                foreach (DataRow row in mySqlDataTable.Rows)
                {

                    for (int r = 0; r < EndCol; r++)
                    {
                        Range myRange = (Range)DataSheet.Cells[StartRow + j, StartCol + i];
                        myRange.Value = row[r].ToString() == null ? "" : row[r].ToString();
                        i++;
                        myRange.Select();
                    }
                    i = 0;
                    j++;
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void fetchCSVTransactions(string FileName, int columnCount)
        {
            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            int i = 0;


            try
            {
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                int rowCount = mySqlDataTable.Rows.Count;



                var outputCsv = new string[rowCount + 1];



                foreach (DataRow row in mySqlDataTable.Rows)
                {

                    for (int j = 0; j != columnCount; j++)
                    {
                        outputCsv[i] += Regex.Replace(row[j].ToString(), @"\t|\n|\r|[,]", "") + ",";
                    }

                    i++;
                }


                File.WriteAllLines(FileName, outputCsv, Encoding.UTF8);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }


        //DataGridView Properties and Methods
        public void populate(DataGridView dgv, DateTime transDate, string voucherType, string Ref, int GLSL, double Amount, string Particulars, int UnitCode, string CheckNo, string Supplier, string User)
        {
            dgv.Rows.Add(transDate, voucherType, Ref, GLSL, Amount,
                Particulars, UnitCode, CheckNo, Supplier, User);
        }

        //RETRIEVE FROM DB

        public void retrieveSOA(DataGridView dgv)
        {

            dgv.Rows.Clear();

            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    populate(dgv, Convert.ToDateTime(row[0].ToString()), row[1].ToString(), row[2].ToString(), Convert.ToInt32(row[3].ToString()), Convert.ToDouble(row[4].ToString()), row[5].ToString(),
                        Convert.ToInt32(row[6].ToString()), row[7].ToString(), row[8].ToString(), row[9].ToString());
                }

                this.closeConnection();

                //CLEAR DT
                mySqlDataTable.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void populateSL(DataGridView dgv, string cutOffDate, string Amount, string GLNo, string GLSL, string BusUnit)
        {
            dgv.Rows.Add(Convert.ToDateTime(cutOffDate), Convert.ToDouble(Amount), Convert.ToInt32(GLNo), Convert.ToInt32(GLSL), Convert.ToInt32(BusUnit));
        }

        //RETRIEVE FROM DB SL

        public void retrieveSL(DataGridView dgv)
        {

            dgv.Rows.Clear();

            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    populateSL(dgv, row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                this.closeConnection();

                //CLEAR DT
                mySqlDataTable.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void SumSL(Control txtLabel)
        {



            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);


            try
            {
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    txtLabel.Text = row[0].ToString();
                }

                this.closeConnection();

                //CLEAR DT
                mySqlDataTable.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void populateFS(DataGridView dgv, string GL, string Account, string Amount)
        {
            dgv.Rows.Add(Convert.ToInt32(GL), Account, Convert.ToDouble(Amount));
        }

        public void fetchFSGrid(DataGridView dgv)
        {

            dgv.Rows.Clear();

            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    populateFS(dgv, row[0].ToString(), row[1].ToString(), row[2].ToString());
                }

                //CLEAR DT
                mySqlDataTable.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

        public void AddBudgetInput(Control pnlControl)
        {

            UCBudgetInputs uc = new UCBudgetInputs();
            uc.Dock = DockStyle.Top;

            pnlControl.Controls.Add(uc);
            uc.BringToFront();


        }

        public void fetchCategoryCode()
        {
            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);


            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {


                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    this.categoryCode = row[0].ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }
        }

    }
}
