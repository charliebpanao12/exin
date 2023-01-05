using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_UserCredentials_BusinessUnits : UserControl
    {
        public string categoryCode;
        public string unitCode;
        public string unitName;

        public ucSettings_UserCredentials_BusinessUnits()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Controls - Toggle Switch
            toggleControl.CheckedState.FillColor = Global.themeColor1;
        }

        private void ucSettings_UserCredentials_BusinessUnits_Load(object sender, EventArgs e)
        {
            lblBusinessCategory.Text = categoryCode;
            lblBusinessUnit.Text = "(" + unitCode + ") " + unitName;
        }
    }
}
