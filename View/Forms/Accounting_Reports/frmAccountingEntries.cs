using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmAccountingEntries : Form
    {
        public frmAccountingEntries()
        {
            InitializeComponent();
        }

        public string transactionDate;
        public string register;
        public int voucherNo;
        public int glsl;
        public double amount;
        public string particulars;
        public string[,] arrControl;
        public int counterList = 0;
        public int counter = 0;
        public int voucher_No;
        public List<string> listEntries = new List<string>();

        private void btnAdd_Click(object sender, EventArgs e)
        {

            {
                Accounting Acctg = new Accounting();


                DialogResult resultInsert = MessageBox.Show("Do you want to post data?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resultInsert == DialogResult.Yes)
                {


                    foreach (Control p in pnlList.Controls) //to loop to each Control in Panel
                    {

                        //MessageBox.Show("Counter list:" + counterList.ToString());

                        voucher_No = Acctg.entry_No; //Add current voucher number from UCCheckVoucher


                        //MessageBox.Show(voucher_No.ToString());


                        foreach (Control c in p.Controls)
                        {//to loop to each Control in Controls ini the Panel
                            listEntries.Add(c.Text);

                        }
                        //List is accessible here
                        /* foreach (var item in listEntries)
                             {
                                 MessageBox.Show(item + " This is from the List");
                             } */

                        Acctg.mysqlQuery = "INSERT INTO `rci_accounting_entries`(`transaction_Date`,`register`,`voucher_No`,`glsl`,`amount`,`particulars`,`usercode`,`posting_Status`)  " +
                                                        "VALUES(@transDate,@register,@voucher_No,@glsl,@amount,@particulars,@usercode,@posting_Status)";

                        transactionDate = DateTime.Now.ToLongDateString();

                        Acctg.InsertAcctgEntries(Convert.ToDateTime(transactionDate), "CV", voucher_No, Convert.ToInt32(listEntries[4]), Convert.ToDouble(listEntries[2]), Convert.ToString(listEntries[1]));

                        listEntries.Clear();

                    }

                } //End If

                Acctg.mysqlQuery = "UPDATE `rci_check_voucher` SET `posting_Status` = 'Posted' WHERE `voucher_No` = @voucher_No";
                Acctg.UpdateVoucherStatus(voucher_No);

                Acctg.Alert("Data posted", frmAlert.alertTypeEnum.Success);
                Acctg.closeConnection();

            }

        }

        private void frmAccountingEntries_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {
                UCAccountingEntries uc = new UCAccountingEntries();
                uc.Dock = DockStyle.Top;

                pnlList.Controls.Add(uc);

            }
        }


    }
}
