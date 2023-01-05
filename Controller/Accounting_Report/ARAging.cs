using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    class ARAging : MySqlConnect
    {

        public string UnitCode;


        public void populateDataGrid(DataGridView dgv, string ID, string Date, string Voucher_No, string GLSL, string Amount, string GL, string Item_Description, string ClearingStat, string ClearingDate)
        {
            dgv.Rows.Add(Convert.ToInt32(ID), Convert.ToDateTime(Date), Voucher_No, GLSL, Convert.ToDouble(Amount), GL, Item_Description, ClearingStat, ClearingDate);
        }

        //RETRIEVE FROM DB SL

        public void retrieveData(DataGridView dgv)
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
                    populateDataGrid(dgv, row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());
                }

                DataGridViewImageColumn dimg = new DataGridViewImageColumn();
                dimg.Image = Properties.Resources.pencil_green;
                dimg.HeaderText = "Clear";
                dimg.ImageLayout = DataGridViewImageCellLayout.Zoom;
                //dimg.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dimg.Width = 50;


                dgv.Columns.Add(dimg);

                DataGridViewImageColumn dimg_2 = new DataGridViewImageColumn();
                dimg_2.Image = Properties.Resources.clean_green;
                dimg_2.HeaderText = "Unclear";
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
                    UnitCode = row[0].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }


        public void InsertARAgingData(DateTime lastYeardate, int Unit_Code, double amount, int accountClassCode)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@lastYearDate", lastYeardate);
                mySqlCmd.Parameters.AddWithValue("@unitCode", Unit_Code);
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

        public void deleteData(int myNo)
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


        public void clearReceivable(int voucherNo, string clearingStatus, DateTime clearingDate, int userCode, string deleteStatus)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@voucherNo", voucherNo);
                mySqlCmd.Parameters.AddWithValue("@clearingStatus", clearingStatus);
                mySqlCmd.Parameters.AddWithValue("@clearingDate", clearingDate);
                mySqlCmd.Parameters.AddWithValue("@userCode", userCode);
                mySqlCmd.Parameters.AddWithValue("@deleteStatus", deleteStatus);

                mySqlCmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }




    }
}
