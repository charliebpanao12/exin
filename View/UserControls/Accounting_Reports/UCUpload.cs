using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace EXIN
{
    public partial class UCUpload : UserControl
    {
        public UCUpload()
        {
            InitializeComponent();


            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Upload Data";

        }

        string templateName;

        LastYearData LYConn = new LastYearData();
        Budget BudgetConn = new Budget();

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileName.Clear();
            cmbTemplates.SelectedIndex = -1;
            templateName = "";
        }

        public DataTable ReadCsvFile()
        {

            DataTable dtCsv = new DataTable();
            string Fulltext;
            if (txtFileName.Text != "")
            {
                string FileSaveWithPath = txtFileName.Text;

                using (StreamReader sr = new StreamReader(FileSaveWithPath))
                {
                    while (!sr.EndOfStream)
                    {
                        Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                        string[] rows = Fulltext.Split('\n'); //split full file text into rows  


                        for (int i = 0; i < rows.Count() - 1; i++)
                        {
                            string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                            {
                                if (i == 0)
                                {
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        dtCsv.Columns.Add(rowValues[j]); //add headers  
                                    }
                                }
                                else
                                {
                                    DataRow dr = dtCsv.NewRow();
                                    for (int k = 0; k < rowValues.Count(); k++)
                                    {
                                        dr[k] = rowValues[k].ToString();
                                    }
                                    dtCsv.Rows.Add(dr); //add other rows  
                                }
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            templateName = cmbTemplates.GetItemText(cmbTemplates.SelectedItem);

            if (templateName == "")
            {
                MessageBox.Show("Please select in the Dropdown menu where to Upload Data", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Text files | *.csv";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName;
                    fileName = dlg.FileName;
                    txtFileName.Text = fileName;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            string databaseName = cmbTemplates.GetItemText(cmbTemplates.SelectedItem);

            DialogResult dataUpload = MessageBox.Show("Are you sure you want to upload this data in the " + databaseName + "?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dataUpload == DialogResult.No)
            {
                return;
            }
            else
            {

                var loader = new WaitFormFunc();
                loader.Show();

                if (txtFileName.Text == "")
                {
                    MessageBox.Show("Please select a valid file format (.csv)", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (templateName == "")
                    {
                        MessageBox.Show("Please select in the Dropdown menu where to Upload Data", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (templateName == "Last Year Database")
                    {
                        DataTable dt = new DataTable();

                        dt = ReadCsvFile();

                        foreach (DataRow row in dt.Rows)
                        {

                            LYConn.mysqlQuery = "INSERT INTO `tbl_lastyear_upload`(LastYear_Date,Unit_Code,Amount,AccountClass_Code,User_Code)  " +
                                                "VALUES(@lastYearDate,@unitCode,@amount,@classCode,@usercode)";

                            LYConn.InsertLastYearData(Convert.ToDateTime(row[1].ToString()), Convert.ToInt32(row[2].ToString()), Convert.ToDouble(row[3].ToString()), Convert.ToInt32(row[4].ToString()));


                        }


                    }

                    else if (templateName == "Budget Database")
                    {

                        DataTable dt = new DataTable();

                        dt = ReadCsvFile();

                        foreach (DataRow row in dt.Rows)
                        {

                            BudgetConn.mysqlQuery = "INSERT INTO `tbl_budget_accountclass`(Budget_Date,Unit_Code,Project_Code,Budget_Amount,AccountClass_Code,User_Code)  " +
                                        "VALUES(@transDate,@unitCode,@projectCode,@amount,@classCode,@usercode)";

                            BudgetConn.InsertBudgetFigures(Convert.ToDateTime(row[1].ToString()), Convert.ToInt32(row[2].ToString()), Convert.ToInt32(row[3].ToString()), Convert.ToDouble(row[4].ToString()), Convert.ToInt32(row[5].ToString()));
                        }

                    }


                    MessageBox.Show("Data was uploaded to " + templateName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loader.Close();

                }

            }
        }
    }
}
