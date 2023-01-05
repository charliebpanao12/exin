using EXIN.Report_Generator.CrystalReport;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmViewer : Form
    {
        public frmViewer()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void frmViewer_Load(object sender, EventArgs e)
        {
            MySqlConnect MySqlConn = new MySqlConnect();

            int voucherNo = MySqlConn.crvVoucherNo;
            string printString = MySqlConn.crvPrintString;

            //MessageBox.Show(printString);



            MySqlCommand mySqlCmd = new MySqlCommand("SELECT * FROM `rci_check_voucher` WHERE `voucher_No` = @voucherNo", MySqlConn.mySqlconn);
            mySqlCmd.Parameters.AddWithValue("@voucherNo", voucherNo);
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            DataTable mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            /*foreach (DataRow row in mySqlDataTable.Rows)
            {
                MessageBox.Show(String.Format("{0} {1} {2} {3}", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString()));
            } */
            if (printString == "btnCVPrint")
            {

                crptCheckVoucher crpt = new crptCheckVoucher();

                crpt.Database.Tables["CheckVoucher"].SetDataSource(mySqlDataTable);
                crvCheckVoucher.ReportSource = crpt;
                crvCheckVoucher.Zoom(100);

            }
            else if (printString == "btnCheckPrint")
            {

                crptCheck crpt = new crptCheck();

                crpt.Database.Tables["CheckVoucher"].SetDataSource(mySqlDataTable);
                crvCheckVoucher.ReportSource = crpt;
                crvCheckVoucher.Zoom(100);
            }





        }
    }
}
