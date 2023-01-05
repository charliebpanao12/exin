using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public class MySqlConnect
    {
        static frmController _obj;
        public static frmController Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmController();
                }
                return _obj;
            }
        }

        public void Alert(string msg, frmAlert.alertTypeEnum type)
        {
            frmAlert f = new frmAlert();
            f.setAlert(msg, type);
        }

        public string connstr = "Server=localhost; User Id=root; Password=; Database=db_exinnov;port=3306;Convert Zero Datetime=True";
        //public string connstr = "Server=localhost; User Id=root; Password=; Database=db_inventory_system_refined_selections;port=3306;Convert Zero Datetime=True"; // Refined Selections - Local
        //public string connstr = "Server=192.168.254.100; User Id=server; Password=; Database=knc_vouchersystem;port=3306;Convert Zero Datetime=True";

        protected string query;
        public MySqlConnection mySqlconn;
        public MySqlCommand mySqlCmd;
        public MySqlDataAdapter mySqlAdapter;
        public DataTable mySqlDataTable;
        public Boolean myLoginStatus;
        public MySqlDataReader mySqlDataReader;

        public string myUserValue { get; set; }
        public string myPassValue { get; set; }

        public int ExinOps;

        private static string myUserName { get; set; }
        private static int myUserAccount { get; set; }

        private static string myExpirtyDate { get; set; }

        private static int crptvoucherNo;
        private static string printString;
        private static string updateUser = "Register";
        //private string approvalStatus;

        //bool verifyPassHash;
        string verifyPassword;

        public string mysqlConnString
        {
            get
            {
                return connstr;
            }
            set
            {
                connstr = value;
            }
        }

        public string myUser
        {
            get
            {
                return myUserName;
            }
            set
            {
                myUserName = value;
            }
        }

        public int myAccount
        {
            get
            {
                return myUserAccount;
            }
            set
            {
                myUserAccount = value;
            }
        }


        public string endDate
        {
            get
            {
                return myExpirtyDate;
            }
            set
            {
                myExpirtyDate = value;
            }
        }

        public string mysqlQuery
        {
            get
            {
                return query;
            }
            set
            {
                query = value;
            }
        }

        public int getVoucherNo
        {
            get
            {
                return crptvoucherNo;
            }
            set
            {
                crptvoucherNo = value;
            }
        }

        public string getPrintString
        {
            get
            {
                return printString;
            }
            set
            {
                printString = value;
            }
        }

        public string getUserUpdate
        {
            get
            {
                return updateUser;
            }
            set
            {
                updateUser = value;
            }
        }

        public int crvVoucherNo = crptvoucherNo;
        public string crvPrintString = printString;
        public string updateUserString = updateUser;

        public MySqlConnect()
        {

            //MessageBox.Show(connstr);
            try
            {
                mySqlconn = new MySqlConnection(connstr);
                mySqlconn.Open();
            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                return;
            }

        }


        public void myUserLogin()
        {
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@userName", myUserValue);
            mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            if (mySqlDataTable.Rows.Count != 1)
            {
                this.Alert("Incorrect Username", frmAlert.alertTypeEnum.Error);
                return;
            }

            foreach (DataRow row in mySqlDataTable.Rows)
            {
                this.myUser = row[4].ToString();
                this.myAccount = Convert.ToInt32(row[1].ToString());
                Global.userID = this.myAccount;
                Global.userName = row["User_Name"].ToString();
                Global.displayName = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                Global.userLevel = row["User_Role"].ToString();
            }
        }

        public void myPassLogin()
        {
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);
            //mySqlCmd.Parameters.AddWithValue("@userPassword", myPassValue);
            mySqlCmd.Parameters.AddWithValue("@userName", myUserValue);
            mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            // MessageBox.Show(myPassValue);

            foreach (DataRow row in mySqlDataTable.Rows)
            {
                // MessageBox.Show(row[2].ToString());
                //verifyPassHash = BCrypt.Net.BCrypt.Verify(myPassValue,row[2].ToString());
                //this.approvalStatus = row[7].ToString();
                verifyPassword = row[3].ToString();
            }

            //MessageBox.Show(verifyPassHash.ToString());


            //if (this.approvalStatus == "Pending")
            //{
            //    this.Alert("Wait for Admin Approval", frmAlert.alertTypeEnum.Error);
            //    return;
            //}

            if (verifyPassword != myPassValue)
            {
                this.Alert("Incorrect Password", frmAlert.alertTypeEnum.Error);
                return;
            }
            else
            {

                this.Alert("Login Successful", frmAlert.alertTypeEnum.Success);

                closeConnection();

                this.myLoginStatus = true;

                // Get the preferences
                classGlobalFunctions.getPreferences_ThemeStyle(Global.userID);

                // Show the main form
                frmMain frmMain = new frmMain();
                frmMain.Show();

                //frmController frmController = new frmController();
                //frmController.Show();

            }

        }

        public void checkCredentials(int SF_Code, MethodInvoker evt)
        {
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@userID", myAccount);
            mySqlCmd.Parameters.AddWithValue("@SF_Code", SF_Code);
            mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            if (mySqlDataTable.Rows.Count != 1)
            {
                this.Alert("Access to this module is prohibited", frmAlert.alertTypeEnum.Error);
            }
            else
            {
                evt();
            }

        }

        public void checkTaxCredentials(int SF_Code)
        {
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@userID", myAccount);
            mySqlCmd.Parameters.AddWithValue("@SF_Code", SF_Code);
            mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            if (mySqlDataTable.Rows.Count != 1)
            {
                ExinOps = 1;
            }
            else
            {
                ExinOps = 0;
            }
        }


        public void mySystemExpiry()
        {
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);
            mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                this.endDate = row[1].ToString();
            }

            closeConnection();

        }

        //Insert Parameters for Check Voucher

        public string myType { get; set; }
        public int myNo { get; set; }
        public string myPayee { get; set; }
        public double myAmount { get; set; }
        public string myParticulars { get; set; }
        public string myCheckNo { get; set; }
        public DateTime myCheckDate { get; set; }
        public DateTime myTransDate { get; set; }
        public string myPostingStatus { get; set; }

        public string myBank { get; set; }




        public void myCheckDataInsert()
        {

            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@type", myType);
                mySqlCmd.Parameters.AddWithValue("@no", myNo);
                mySqlCmd.Parameters.AddWithValue("@payee", myPayee);
                mySqlCmd.Parameters.AddWithValue("@amount", myAmount);
                mySqlCmd.Parameters.AddWithValue("@particulars", myParticulars);
                mySqlCmd.Parameters.AddWithValue("@checkNo", myCheckNo);
                mySqlCmd.Parameters.AddWithValue("@checkDate", myCheckDate);
                mySqlCmd.Parameters.AddWithValue("@transDate", myTransDate);
                mySqlCmd.Parameters.AddWithValue("@user", myAccount);
                mySqlCmd.Parameters.AddWithValue("@posting", myPostingStatus);
                mySqlCmd.Parameters.AddWithValue("@bank", myBank);
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



        //DataGridView Properties and Methods
        public void populate(DataGridView dgv, string transDate, string voucherNo, string checkNo, string payee, string amount, string particulars, string type, string checkDate, string bank, string userId, string postingStatus)
        {
            dgv.Rows.Add(Convert.ToDateTime(transDate), Convert.ToInt32(voucherNo), Convert.ToInt32(checkNo), payee, Convert.ToDouble(amount), particulars, type, Convert.ToDateTime(checkDate), bank, Convert.ToInt32(userId), postingStatus);

        }

        //RETRIEVE FROM DB

        public void retrieve(DataGridView dgv)
        {


            dgv.Rows.Clear();

            //SQL STMT
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);

            //OPEN CON,RETRIEVE,FILL DGVIEW
            try
            {


                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = mySqlCmd;
                DataTable mySqlDataTable = new DataTable();
                mySqlAdapter.Fill(mySqlDataTable);

                //LOOP THRU DT
                foreach (DataRow row in mySqlDataTable.Rows)
                {
                    populate(dgv, row[8].ToString(), row[2].ToString(), row[6].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[1].ToString(), row[7].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString());
                }

                //to Add Buttons, Check Boxes, Image, Combo Box to DGV  

                /*DataGridViewComboBoxColumn dcombo = new DataGridViewComboBoxColumn();
                dcombo.HeaderText = "ComboBox";
                dcombo.FlatStyle = FlatStyle.Popup;
                dcombo.Items.Add("A");
                dcombo.Items.Add("B");
                dcombo.Items.Add("C");
                dcombo.Items.Add("D");

                

                DataGridViewButtonColumn dbtn = new DataGridViewButtonColumn();
                dbtn.HeaderText = "Button";
                dbtn.FlatStyle = FlatStyle.Popup;
                dbtn.DataPropertyName = "Add";
                dbtn.Text = "Add";
                dbtn.UseColumnTextForButtonValue = true;
                dbtn.DefaultCellStyle.ForeColor = Color.Black;
                dbtn.DefaultCellStyle.BackColor = Color.Yellow;


                DataGridViewCheckBoxColumn dchek = new DataGridViewCheckBoxColumn();
                dchek.HeaderText = "CheckBox";*/

                DataGridViewImageColumn dimg = new DataGridViewImageColumn();
                dimg.Image = Properties.Resources.pen;
                dimg.HeaderText = "Edit";
                dimg.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dimg.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                dgv.AllowUserToAddRows = false;

                //dgv.Columns.Add(dcombo);
                //dgv.Columns.Add(dbtn);
                //dgv.Columns.Add(dchek);

                dgv.Columns.Add(dimg);


                //*********Add 2nd Image Column*************


                DataGridViewImageColumn dimg_2 = new DataGridViewImageColumn();
                dimg_2.Image = Properties.Resources.clean;
                dimg_2.HeaderText = "Cancel";
                dimg_2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dimg_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgv.AllowUserToAddRows = false;

                dgv.Columns.Add(dimg_2);

                //*********Add 3rd Image Column*************


                DataGridViewImageColumn dimg_3 = new DataGridViewImageColumn();
                dimg_3.Image = Properties.Resources.add;
                dimg_3.HeaderText = "Status";
                dimg_3.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dimg_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgv.AllowUserToAddRows = false;

                dgv.Columns.Add(dimg_3);


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



        //UPDATE DB

        public void update(int myNo, string myType, int myCheckNo, string myPayee, double myAmount, string myParticulars, DateTime myCheckDate, DateTime myTransDate, int myAccount, string myBank)
        {


            //OPEN CON,UPDATE,RETRIEVE DGVIEW
            try
            {
                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@type", myType);
                mySqlCmd.Parameters.AddWithValue("@no", myNo);
                mySqlCmd.Parameters.AddWithValue("@payee", myPayee);
                mySqlCmd.Parameters.AddWithValue("@amount", myAmount);
                mySqlCmd.Parameters.AddWithValue("@particulars", myParticulars);
                mySqlCmd.Parameters.AddWithValue("@checkNo", myCheckNo);
                mySqlCmd.Parameters.AddWithValue("@checkDate", myCheckDate);
                mySqlCmd.Parameters.AddWithValue("@transDate", myTransDate);
                mySqlCmd.Parameters.AddWithValue("@myAccount", myAccount);
                mySqlCmd.Parameters.AddWithValue("@bank", myBank);
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

        public void delete(int myNo)
        {


            //Delete
            try
            {
                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@no", myNo);
                mySqlCmd.ExecuteNonQuery();

                this.Alert("Selected data was deleted successfully", frmAlert.alertTypeEnum.Success);
                this.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.closeConnection();
            }

        }

        public void closeConnection()
        {
            mySqlconn.Close();
            mySqlconn.Dispose();
        }

        public int voucherNo;
        public void maxVoucherNo()
        {
            mySqlCmd = new MySqlCommand(this.query, mySqlconn);
            mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                var x = row[0].ToString();

                if (x == "")
                {
                    voucherNo = 1;
                }
                else
                {
                    voucherNo = Convert.ToInt32(row[0].ToString()) + 1;
                }

            }
        }

        public void myUserRegistration(string userName, string userPassword, string userEmail, string firstName, string middleName, string lastName)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@userName", userName);
                mySqlCmd.Parameters.AddWithValue("@userPassword", userPassword);
                mySqlCmd.Parameters.AddWithValue("@userEmail", userEmail);
                mySqlCmd.Parameters.AddWithValue("@firstName", firstName);
                mySqlCmd.Parameters.AddWithValue("@middleName", middleName);
                mySqlCmd.Parameters.AddWithValue("@lastName", lastName);
                mySqlCmd.Parameters.AddWithValue("@userStatus", "Pending");

                mySqlCmd.ExecuteNonQuery();

                this.Alert("Success, wait for Admin Approval", frmAlert.alertTypeEnum.Success);
                this.closeConnection();

            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public void myUserUpdate(string userName, string userPassword, string userEmail, string firstName, string middleName, string lastName)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@userName", userName);
                mySqlCmd.Parameters.AddWithValue("@userPassword", userPassword);
                mySqlCmd.Parameters.AddWithValue("@userEmail", userEmail);
                mySqlCmd.Parameters.AddWithValue("@firstName", firstName);
                mySqlCmd.Parameters.AddWithValue("@middleName", middleName);
                mySqlCmd.Parameters.AddWithValue("@lastName", lastName);
                mySqlCmd.Parameters.AddWithValue("@user", myAccount);

                mySqlCmd.ExecuteNonQuery();

                this.Alert("User information updated", frmAlert.alertTypeEnum.Success);
                this.closeConnection();

            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                MessageBox.Show(ex.Message);
                return;
            }

        }


        public void myStatusUpdate(string postStatus, int voucherNo)
        {
            try
            {

                mySqlCmd = new MySqlCommand(this.query, mySqlconn);
                mySqlCmd.Parameters.AddWithValue("@status", postStatus);
                mySqlCmd.Parameters.AddWithValue("@no", voucherNo);

                mySqlCmd.ExecuteNonQuery();

                this.Alert("Status was updated", frmAlert.alertTypeEnum.Success);
                this.closeConnection();

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
