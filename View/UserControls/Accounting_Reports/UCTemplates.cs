using EXIN.Controller.Settings;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCTemplates : UserControl
    {
        public UCTemplates()
        {
            InitializeComponent();


            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Upload Templates";
        }

        string templateName;


        private void downloadCommiTemp()
        {
            var fileHandler = new FileHandler();

            fileHandler.clearFiles();

            fileHandler.copyExcelFile("Commi Upload Template.xlsm", "Commi Upload Template.xlsm");

            Process.Start("explorer.exe", @"c:\EXINReleases");
        }


        private void downloadBudgetTemp()
        {
            var fileHandler = new FileHandler();

            fileHandler.clearFiles();

            fileHandler.copyExcelFile("Budget Upload Template.xlsm", "Budget Upload Template.xlsm");

            Process.Start("explorer.exe", @"c:\EXINReleases");
        }

        private void downloadLastYearTemp()
        {
            var fileHandler = new FileHandler();

            fileHandler.clearFiles();

            fileHandler.copyExcelFile("Last Year Upload Template.xlsm", "Last Year Upload Template.xlsm");

            Process.Start("explorer.exe", @"c:\EXINReleases");
        }

        private void btnResetBusUnit_Click(object sender, EventArgs e)
        {
            cmbTemplates.SelectedIndex = -1;
            templateName = null;
            MessageBox.Show("Select a template", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

            templateName = cmbTemplates.GetItemText(cmbTemplates.SelectedItem);

            if (templateName == "Commisary Upload Template")
            {
                downloadCommiTemp();
            }
            else if (templateName == "Budget Upload Template")
            {
                downloadBudgetTemp();
            }
            else if (templateName == "Last Year Upload Template")
            {
                downloadLastYearTemp();
            }


        }

    }
}
