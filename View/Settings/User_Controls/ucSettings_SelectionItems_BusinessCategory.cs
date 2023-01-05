using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXIN.Controller;
using MySql.Data.MySqlClient;

namespace EXIN.Settings
{
    public partial class ucSettings_SelectionItems_BusinessCategory : UserControl
    {
        public string categoryCode;
        public string categoryName;
        public string verifyUserID; // This variable is used to verify if the user has access to this business category
        public Boolean alreadyExisting = false; // This variable is used to validate if the record for this business category is existing by default
        public Boolean locked = false; // This variable is used to validate if this chart of account has an active transaction
        
        public ucSettings_SelectionItems_BusinessCategory()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Controls - Toggle Switch
            toggleControl.CheckedState.FillColor = Global.themeColor1;
        }

        private void ucSettings_SelectionItems_BusinessCategory_Load(object sender, EventArgs e)
        {
            lblBusinessCategory.Text = categoryName;

            if (verifyUserID.Trim() == "")
            {
                lblNoAccess.Visible = true;
            }
            else
            {
                lblNoAccess.Visible = false;
            }

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
            // Validate if the user has access to this business category
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
