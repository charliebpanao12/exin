using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    class opnDaysData : MySqlConnect
    {

        public int opnDaysUnitCode { get; set; }


        public void InsertopnDaysData(DateTime opnDaysdate, int Unit_Code, int opnDays)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@opDate", opnDaysdate);
                mySqlCmd.Parameters.AddWithValue("@unitCode", Unit_Code);
                mySqlCmd.Parameters.AddWithValue("@opDays", opnDays);
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

        public void populateopnDays(DataGridView dgv, string TransId, string Op_Date, string Unit_Code, string MonOpDays, string user)
        {
            dgv.Rows.Add(Convert.ToInt32(TransId), Convert.ToDateTime(Op_Date), Unit_Code, Convert.ToInt32(MonOpDays), user);
        }

        //RETRIEVE FROM DB SL

        public void retrieveopnDays(DataGridView dgv)
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
                    populateopnDays(dgv, row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
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
                    opnDaysUnitCode = Convert.ToInt32(row[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }


        public void opnDaysDelete(int myNo)
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
