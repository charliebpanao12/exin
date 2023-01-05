using EXIN.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_SupplierList_WTaxReference : UserControl
    {
        public string atcCode;
        public string atcTitle;
        public double atcPercentage;
        public Boolean alreadyExisting = false; // This variable is used to validate if the record for this business category is existing by default
        public Boolean locked = false; // This variable is used to validate if this chart of account has an active transaction

        public ucSettings_SupplierList_WTaxReference()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Controls - Toggle Switch
            toggleControl.CheckedState.FillColor = Global.themeColor1;
        }

        private void ucSettings_SupplierList_WTaxReference_Load(object sender, EventArgs e)
        {
            lblATCTitle.Text = atcTitle;
            lblATCCode.Text = atcCode + " : " + atcPercentage + "%";

            if (locked == true)
            {
                lblLocked.Visible = true;
            }
            else
            {
                lblLocked.Visible = false;
            }
        }

        private void toggleControl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleControl_Click(object sender, EventArgs e)
        {
            // Validation for toggle on/off
            if (lblNoAccess.Visible == true || lblLocked.Visible == true)
            {
                if (toggleControl.Checked == true)
                {
                    toggleControl.Checked = false;
                }
                else
                {
                    toggleControl.Checked = true;
                }
                return;
            }
        }
    }
}
