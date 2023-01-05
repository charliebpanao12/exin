using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    class Budget : MySqlConnect
    {

        public int budgetUnitCode { get; set; }
        public int budgetAccountClassCode { get; set; }

        public void InsertBudgetFigures(DateTime transdate, int Unit_Code, int Project_Code, double amount, int accountClassCode)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@transDate", transdate);
                mySqlCmd.Parameters.AddWithValue("@unitCode", Unit_Code);
                mySqlCmd.Parameters.AddWithValue("@projectCode", Project_Code);
                mySqlCmd.Parameters.AddWithValue("@amount", amount);
                mySqlCmd.Parameters.AddWithValue("@classCode", accountClassCode);
                mySqlCmd.Parameters.AddWithValue("@usercode", myAccount);

                mySqlCmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public void populateBudget(DataGridView dgv, string TransId, string BudgetDate, string Unit_Code, string Amount, string BudgetClass, string user)
        {
            dgv.Rows.Add(Convert.ToInt32(TransId), Convert.ToDateTime(BudgetDate), Unit_Code, Convert.ToDouble(Amount), BudgetClass, user);
        }

        //RETRIEVE FROM DB SL

        public void retrieveBudget(DataGridView dgv)
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
                    populateBudget(dgv, row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                DataGridViewImageColumn dimg = new DataGridViewImageColumn();
                dimg.Image = Properties.Resources.pencil_green;
                dimg.HeaderText = "Edit";
                dimg.ImageLayout = DataGridViewImageCellLayout.Zoom;
                //dimg.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dimg.Width = 50;


                dgv.Columns.Add(dimg);

                DataGridViewImageColumn dimg_2 = new DataGridViewImageColumn();
                dimg_2.Image = Properties.Resources.clean_green;
                dimg_2.HeaderText = "Cancel";
                dimg_2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                //dimg_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dimg_2.Width = 50;

                dgv.AllowUserToAddRows = false;

                dgv.Columns.Add(dimg_2);


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

        public void retrieveCodeNo()
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

                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    budgetUnitCode = Convert.ToInt32(row[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }


        public void retrieveUnitCodeNo()
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

                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    budgetUnitCode = Convert.ToInt32(row[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }

        public void retrieveAccountClassCodeNo()
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

                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    budgetAccountClassCode = Convert.ToInt32(row[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }

        public void budgetDelete(int myNo)
        {


            //Delete
            try
            {
                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@no", myNo);
                mySqlCmd.ExecuteNonQuery();

                this.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }



    }
}
