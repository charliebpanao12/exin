using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmBudgetSetup : Form
    {
        public frmBudgetSetup()
        {
            InitializeComponent();
            AddBudgetInput();
        }

        string busUnitName;
        string busUnitCode;
        string projectCode;
        string costCenterCode;
        string busUQuery;
        int userId;
        string SQLStatement;
        string accountClassName;
        string accountCode;
        ArrayList arList = new ArrayList();
        ArrayList arList2 = new ArrayList();
        DateTime dateCurrent;
        MySqlConnect ConnAll = new MySqlConnect();
        FS FSConn = new FS();
        Budget BudgetConn = new Budget();





        private void frmBudgetSetup_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);


            dpkBudgetDate.Text = DateTime.Today.ToShortDateString();
        }
        //FILL COMBO BOXES

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

        //public void fillProject()
        //{

        //    cmbProjectCode.Items.Clear();

        //    //Get BusUnit Code

        //    MySqlCommand ConnBusUnitCmd = new MySqlCommand("SELECT `Unit_Code` FROM `tbl_units` WHERE `Unit_Name` = @Unit_Name", ConnAll.mySqlconn);
        //    ConnBusUnitCmd.Parameters.AddWithValue("@Unit_Name", busUnitName);
        //    MySqlDataAdapter ConnBusUnitAdapter = new MySqlDataAdapter();
        //    ConnBusUnitAdapter.SelectCommand = ConnBusUnitCmd;
        //    System.Data.DataTable BusUnitDataTable = new System.Data.DataTable();
        //    ConnBusUnitAdapter.Fill(BusUnitDataTable);


        //    foreach (DataRow row in BusUnitDataTable.Rows)
        //    {
        //        busUnitCode = row[0].ToString();
        //    }




        //    //LOOP THRU cmbProject


        //    MySqlCommand mySqlCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Unit_Code` = @Unit_Code " +
        //        "ORDER BY `Project_Name` ASC", ConnAll.mySqlconn);
        //    mySqlCmd.Parameters.AddWithValue("@Unit_Code", busUnitCode);
        //    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
        //    mySqlAdapter.SelectCommand = mySqlCmd;
        //    System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
        //    mySqlAdapter.Fill(mySqlDataTable);



        //    foreach (DataRow row in mySqlDataTable.Rows)
        //    {
        //        cmbProjectCode.Items.Add(row[1].ToString());
        //    }


        //}

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
                busUnitCode = row[0].ToString();
            }


            ////Get Project Code


            //MySqlCommand ProjectCmd = new MySqlCommand("SELECT `Project_Code`,`Project_Name` FROM `tbl_projects` WHERE `Project_Name` = @Project " +
            //    "ORDER BY `Project_Name` ASC", ConnAll.mySqlconn);
            //ProjectCmd.Parameters.AddWithValue("@Project", cmbProjectCode.Text);
            //MySqlDataAdapter ProjectAdapter = new MySqlDataAdapter();
            //ProjectAdapter.SelectCommand = ProjectCmd;
            //System.Data.DataTable ProjectDataTable = new System.Data.DataTable();
            //ProjectAdapter.Fill(ProjectDataTable);

            //foreach (DataRow row in ProjectDataTable.Rows)
            //{
            //    projectCode = row[0].ToString();
            //}

        }

        public void AddBudgetInput()
        {
            FSConn.AddBudgetInput(pnlBudgetDock);
        }

        private void pnlBudgetDock_Resize(object sender, EventArgs e)
        {

        }

        private void btnCloseDropDown_Click(object sender, EventArgs e)
        {
            populateFilterCodes();

        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {

            dpkBudgetDate.Value = DateTime.Today;
        }

        private void btnAddUCInput_Click(object sender, EventArgs e)
        {
            FSConn.AddBudgetInput(pnlBudgetDock);
        }

        private void btnDoneDropDown_Click(object sender, EventArgs e)
        {
            populateFilterCodes();

        }

        private void cmbUnitCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            busUnitName = cmbBusUnit.GetItemText(cmbBusUnit.SelectedItem);
            populateFilterCodes();
        }

        private void dpkBudgetDate_ValueChanged(object sender, EventArgs e)
        {
            dateCurrent = dpkBudgetDate.Value;

        }

        private void cmbUnitCode_Click(object sender, EventArgs e)
        {
            cmbBusUnit.Items.Clear();
            fillBusUnit();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dpkBudgetDate.Text == "" || cmbBusUnit.Text == "")
            {
                MessageBox.Show("Do not leave a field empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int i = 0;


            foreach (Control p in pnlBudgetDock.Controls)
            {

                arList.Add(dpkBudgetDate.Text);
                arList.Add(busUnitCode);
                arList.Add('0');


                foreach (Control c in p.Controls)
                {


                    if (c.Name.ToString() == "txtClassCode")
                    {
                        arList.Add(c.Text);

                    }
                    else if (c.Name.ToString() == "txtBudgetAmount")
                    {
                        arList.Add(c.Text);

                    }

                }

                //MessageBox.Show(arList[0].ToString());
                //MessageBox.Show(arList[1].ToString());
                //MessageBox.Show(arList[2].ToString());
                //MessageBox.Show(arList[3].ToString());
                //MessageBox.Show(arList[4].ToString());


                arList2.AddRange(arList);

                // MessageBox.Show(arList[0].ToString() + " " + arList[1].ToString() + " " + arList[2].ToString() + " " + arList[3].ToString() + " " + arList[4].ToString() + " ");

                arList.Clear();
                i++;

            }

            postBudgetData();

            arList.Clear();
            arList2.Clear();



        }

        private void clearControls()
        {
            foreach (Control p in pnlBudgetDock.Controls)
            {
                pnlBudgetDock.Controls.Remove(p);
            }

            foreach (Control p in pnlBudgetDock.Controls)
            {
                pnlBudgetDock.Controls.Remove(p);
            }

            foreach (Control p in pnlBudgetDock.Controls)
            {
                pnlBudgetDock.Controls.Remove(p);
            }

            foreach (Control p in pnlBudgetDock.Controls)
            {
                pnlBudgetDock.Controls.Remove(p);
            }
        }

        private void postBudgetData()
        {
            DialogResult msgContinue = MessageBox.Show("Continue to post data?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgContinue == DialogResult.No)
            {
                return;
            }
            else
            {
                for (int i = 0; i < arList2.Count - 1; i += 5)
                {


                    BudgetConn.mysqlQuery = "INSERT INTO `tbl_budget_accountclass`(Budget_Date,Unit_Code,Project_Code,Budget_Amount,AccountClass_Code,User_Code)  " +
                                                            "VALUES(@transDate,@unitCode,@projectCode,@amount,@classCode,@usercode)";
                    try
                    {
                        BudgetConn.InsertBudgetFigures(Convert.ToDateTime(arList2[i].ToString()), Convert.ToInt32(arList2[i + 1].ToString()), Convert.ToInt32(arList2[i + 2].ToString()), Convert.ToDouble(arList2[i + 3].ToString()), Convert.ToInt32(arList2[i + 4]));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                BudgetConn.Alert("Posted", frmAlert.alertTypeEnum.Success);

            }

            clearControls();

            dpkBudgetDate.Text = DateTime.Today.ToShortDateString();
            cmbBusUnit.Items.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmController"] != null)
            {
                (Application.OpenForms["frmController"] as frmController).clearUserControls();
            }

        }
    }
}
