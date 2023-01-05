using EXIN.View.UserControls.Accounting_Reports;
using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCAccounting : UserControl
    {

        public UCAccounting()
        {
            InitializeComponent();
            pnlMenuTwo.Hide();
            pnlMenuThree.Hide();

            frmController.Instance.PnlTitle.Hide();
            guna2Transition2.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Accounting Menu";

        }




        private void gunaButton1_Click(object sender, EventArgs e)
        {
            clearUserControls();
            UCCheckVoucher uCV = new UCCheckVoucher();
            uCV.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uCV);

            frmController.Instance.PnlContainer.Controls["UCCheckVoucher"].BringToFront();

            frmController.Instance.BackButton.Visible = true;

            /*UCCheckVoucher uc = new UCCheckVoucher();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
            pnlContainer.Controls["UCCheckVoucher"].BringToFront();*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            clearUserControls();
            UCCheckVoucher uCV = new UCCheckVoucher();
            uCV.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uCV);

            frmController.Instance.PnlContainer.Controls["UCCheckVoucher"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Show();

            if (pnlMenuOne.Visible == true)
            {
                guna2Transition1.HideSync(pnlMenuOne);
                guna2Transition1.ShowSync(pnlMenuTwo);
            }
            else if (pnlMenuTwo.Visible == true)
            {
                guna2Transition1.HideSync(pnlMenuTwo);
                guna2Transition1.ShowSync(pnlMenuThree);
            }


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pnlMenuThree.Visible == true)
            {
                guna2Transition1.HideSync(pnlMenuThree);
                guna2Transition1.ShowSync(pnlMenuTwo);
            }
            else if (pnlMenuTwo.Visible == true)
            {
                guna2Transition1.HideSync(pnlMenuTwo);
                guna2Transition1.ShowSync(pnlMenuOne);
            }
        }


        private void btnARAging_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCARAging uc = new UCARAging();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);

            frmController.Instance.PnlContainer.Controls["UCARAging"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCDashboardGraph uc = new UCDashboardGraph();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);

            frmController.Instance.PnlContainer.Controls["UCDashboardGraph"].BringToFront();

            frmController.Instance.BackButton.Visible = true;


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCExcelMenu uExcel = new UCExcelMenu();
            uExcel.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uExcel);

            frmController.Instance.PnlContainer.Controls["UCExcelMenu"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }

        private void btnSOA_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCSOA uSOA = new UCSOA();
            uSOA.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uSOA);

            frmController.Instance.PnlContainer.Controls["UCSOA"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }


        private void btnBudget_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCBudget_Projects uBudget = new UCBudget_Projects();
            uBudget.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uBudget);

            frmController.Instance.PnlContainer.Controls["UCBudget_Projects"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }

        private void btnLastYear_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCLastYear_Upload uCLastYear = new UCLastYear_Upload();
            uCLastYear.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uCLastYear);

            frmController.Instance.PnlContainer.Controls["UCLastYear_Upload"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }

        private void btnOpnDays_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCOperatingDays uCOpnDays = new UCOperatingDays();
            uCOpnDays.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uCOpnDays);

            frmController.Instance.PnlContainer.Controls["UCOperatingDays"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }

        private void btnSL_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCSL uSL = new UCSL();
            uSL.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uSL);

            frmController.Instance.PnlContainer.Controls["UCSL"].BringToFront();

            frmController.Instance.BackButton.Visible = true;
        }

        public void clearUserControls()
        {
            foreach (Control c in frmController.Instance.PnlContainer.Controls)
            {
                pnlContainer.Controls.Remove(c);
            }


        }
    }
}
