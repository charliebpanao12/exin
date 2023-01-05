using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EXIN.Controller.Accounting_Report
{
    public class ctrlDashboard : MySqlConnect
    {
        MySqlCommand Comd;
        MySqlDataAdapter Adapter;
        DataTable Data_Table;
        List<string> DataList = new List<string>();


        public List<string> ReadSalesbyBrand(params string[] ParameterValue)
        {

            try
            {
                Comd = new MySqlCommand(this.query, this.mySqlconn);

                Comd.Parameters.AddWithValue("@pnlAccountNumber", ParameterValue[0]);
                Comd.Parameters.AddWithValue("@startDate", DateTime.Parse(ParameterValue[1].ToString()));
                Comd.Parameters.AddWithValue("@endDate", DateTime.Parse(ParameterValue[2].ToString()));



                Adapter = new MySqlDataAdapter();
                Adapter.SelectCommand = Comd;
                Data_Table = new DataTable();
                Adapter.FillAsync(Data_Table);

                foreach (DataRow row in Data_Table.Rows)
                {
                    for (var i = 0; i < Data_Table.Columns.Count; i++)
                    {
                        DataList.Add(row[i].ToString());
                    }
                }
                this.closeConnection();
                return DataList;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataList.Clear();
                this.closeConnection();
                return DataList;
            }


        }

        public List<string> ReadSalesbyStore(params string[] ParameterValue)
        {

            try
            {
                Comd = new MySqlCommand(this.query, this.mySqlconn);

                Comd.Parameters.AddWithValue("@pnlAccountNumber", ParameterValue[0]);
                Comd.Parameters.AddWithValue("@startDate", DateTime.Parse(ParameterValue[1].ToString()));
                Comd.Parameters.AddWithValue("@endDate", DateTime.Parse(ParameterValue[2].ToString()));
                Comd.Parameters.AddWithValue("@categoryCode", ParameterValue[3]);



                Adapter = new MySqlDataAdapter();
                Adapter.SelectCommand = Comd;
                Data_Table = new DataTable();
                Adapter.FillAsync(Data_Table);

                foreach (DataRow row in Data_Table.Rows)
                {
                    for (var i = 0; i < Data_Table.Columns.Count; i++)
                    {
                        DataList.Add(row[i].ToString());
                    }
                }
                return DataList;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataList.Clear();
                return DataList;
            }

            this.closeConnection();
        }

        public List<string> ReadSalesbyDate(params string[] ParameterValue)
        {

            try
            {
                Comd = new MySqlCommand(this.query, this.mySqlconn);

                Comd.Parameters.AddWithValue("@pnlAccountNumber", ParameterValue[0]);
                Comd.Parameters.AddWithValue("@startDate", DateTime.Parse(ParameterValue[1].ToString()));
                Comd.Parameters.AddWithValue("@endDate", DateTime.Parse(ParameterValue[2].ToString()));
                Comd.Parameters.AddWithValue("@categoryCode", ParameterValue[3]);
                Comd.Parameters.AddWithValue("@unitCode", ParameterValue[4]);



                Adapter = new MySqlDataAdapter();
                Adapter.SelectCommand = Comd;
                Data_Table = new DataTable();
                Adapter.FillAsync(Data_Table);

                for (var i = Data_Table.Rows.Count - 1; i >= 0; i--) //Reverse Loop
                {
                    for (var c = 0; c < Data_Table.Columns.Count; c++)
                    {
                        DataList.Add(Data_Table.Rows[i][c].ToString());
                    }
                }
                return DataList;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataList.Clear();
                return DataList;
            }

            this.closeConnection();
        }
    }
}
