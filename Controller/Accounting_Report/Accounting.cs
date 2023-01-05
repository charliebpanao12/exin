using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EXIN
{
    class Accounting : MySqlConnect
    {
        public static int static_Voucher;

        public int getVoucher
        {
            get
            {
                return static_Voucher;
            }
            set
            {
                static_Voucher = value;
            }
        }

        public int entry_No = static_Voucher;

        public void payeeInsert(string name, string address, double contact, double tinNumber, int myAccount)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@name", name);
                mySqlCmd.Parameters.AddWithValue("@address", address);
                mySqlCmd.Parameters.AddWithValue("@contact", contact);
                mySqlCmd.Parameters.AddWithValue("@tinNumber", tinNumber);
                mySqlCmd.Parameters.AddWithValue("@user", myAccount);


                mySqlCmd.ExecuteNonQuery();

                this.Alert("Data posted", frmAlert.alertTypeEnum.Success);
                this.closeConnection();

            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }


        public void payeeUpdate(string name, string address, double contact, double tinNumber, int id)
        {


            //OPEN CON,UPDATE,RETRIEVE DGVIEW
            try
            {
                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@name", name);
                mySqlCmd.Parameters.AddWithValue("@address", address);
                mySqlCmd.Parameters.AddWithValue("@contact", contact);
                mySqlCmd.Parameters.AddWithValue("@tinNumber", tinNumber);
                mySqlCmd.Parameters.AddWithValue("@usercode", myAccount);
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlCmd.ExecuteNonQuery();

                this.Alert("Data updated successfully", frmAlert.alertTypeEnum.Success);
                this.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }

        public void acctgEntryInsert(string name, string address, double contact, double tinNumber, int myAccount)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@name", name);
                mySqlCmd.Parameters.AddWithValue("@address", address);
                mySqlCmd.Parameters.AddWithValue("@contact", contact);
                mySqlCmd.Parameters.AddWithValue("@tinNumber", tinNumber);
                mySqlCmd.Parameters.AddWithValue("@user", myAccount);


                mySqlCmd.ExecuteNonQuery();

                this.Alert("Data posted", frmAlert.alertTypeEnum.Success);
                this.closeConnection();

            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }


        public void InsertAcctgEntries(DateTime transdate, string reg, int voucherNo, int glSL, double amount, string particulars)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@transDate", transdate);
                mySqlCmd.Parameters.AddWithValue("@register", reg);
                mySqlCmd.Parameters.AddWithValue("@voucher_No", voucherNo);
                mySqlCmd.Parameters.AddWithValue("@glsl", glSL);
                mySqlCmd.Parameters.AddWithValue("@amount", amount);
                mySqlCmd.Parameters.AddWithValue("@particulars", particulars);
                mySqlCmd.Parameters.AddWithValue("@usercode", myAccount);
                mySqlCmd.Parameters.AddWithValue("@posting_Status", "Posted");


                mySqlCmd.ExecuteNonQuery();

                //this.Alert("Data posted", frmAlert.alertTypeEnum.Success);


            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public void UpdateVoucherStatus(int voucherNo)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@voucher_No", voucherNo);

                mySqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public void UpdateChartAccount(int SLNo, string SLName, int GLNo, string GLName, int id)
        {


            //Udpate Chart of Accounts
            try
            {
                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@SLNo", SLNo);
                mySqlCmd.Parameters.AddWithValue("@SLName", SLName);
                mySqlCmd.Parameters.AddWithValue("@GLNo", GLNo);
                mySqlCmd.Parameters.AddWithValue("@GLName", GLName);
                mySqlCmd.Parameters.AddWithValue("@id", id);


                mySqlCmd.ExecuteNonQuery();

                this.Alert("Account was updated successfully", frmAlert.alertTypeEnum.Success);
                this.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }

        public void AddChartAccount(int SLNo, string SLName, int GLNo, string GLName)
        {


            //Add new Account in the Chart
            try
            {
                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@SLNo", SLNo);
                mySqlCmd.Parameters.AddWithValue("@SLName", SLName);
                mySqlCmd.Parameters.AddWithValue("@GLNo", GLNo);
                mySqlCmd.Parameters.AddWithValue("@GLName", GLName);

                mySqlCmd.ExecuteNonQuery();

                this.Alert("Account was added successfully", frmAlert.alertTypeEnum.Success);
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
