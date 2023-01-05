using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Tools
{
    public partial class UCOfferings : UserControl
    {
        public UCOfferings()
        {
            InitializeComponent();

        }

        classControl_Docking control_Docking = new classControl_Docking();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var connection = new MySqlConnect();
        }

        private void UCOfferings_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            new classMsgBox().showMsgConfirmation("Confirmation Message");
            if (Global.msgConfirmation == true)
            {
                // your codes here when the OK button has been pressed
                new classMsgBox().showMsgSuccessful("You pressed OK button");
            }
            else
            {
                // your codes here when the NO button has been pressed
                new classMsgBox().showMsgSuccessful("You pressed NO button");
            }
            Application.OpenForms["frmParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
            if (Global.msgConfirmation == true)
            {
                // your codes here when the OK button has been pressed
                new classMsgBox().showMsgSuccessful("You pressed OK button");
            }
            else
            {
                // your codes here when the NO button has been pressed
                new classMsgBox().showMsgSuccessful("You pressed NO button");
            }
            Application.OpenForms["frmParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgError("There's an error in your codes!");
            Application.OpenForms["frmParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgInformation("This is an infomative message!");
            Application.OpenForms["frmParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgLogout("Do you really want to logout this account?");
            if (Global.msgConfirmation == true)
            {
                // your codes here when the OK button has been pressed
                new classMsgBox().showMsgSuccessful("You pressed OK button");
            }
            else
            {
                // your codes here when the NO button has been pressed
                new classMsgBox().showMsgSuccessful("You pressed NO button");
            }

            Application.OpenForms["frmParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgSuccessful("Record has been saved successfully!");
            Application.OpenForms["frmParentContainer"].Activate(); // Bring the parent form to the front
        }

    }
}
