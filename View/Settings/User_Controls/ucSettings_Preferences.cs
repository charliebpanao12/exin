using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace EXIN.Settings
{
    public partial class ucSettings_Preferences : UserControl
    {
        Boolean stopLoop = true;

        public ucSettings_Preferences()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Controls - Button 1
            btnSave.FillColor = Global.themeColor1;
            btnSave.HoverState.FillColor = Global.themeColor2;
            btnSave.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Toggle Switch
            toggleTheme1.CheckedState.FillColor = Global.themeColor1;
            toggleTheme2.CheckedState.FillColor = Global.themeColor1;
            toggleTheme3.CheckedState.FillColor = Global.themeColor1;
            toggleTheme4.CheckedState.FillColor = Global.themeColor1;
            toggleTheme5.CheckedState.FillColor = Global.themeColor1;
            toggleTheme6.CheckedState.FillColor = Global.themeColor1;
            toggleTheme7.CheckedState.FillColor = Global.themeColor1;
            toggleTheme8.CheckedState.FillColor = Global.themeColor1;
            toggleTheme9.CheckedState.FillColor = Global.themeColor1;
            toggleTheme10.CheckedState.FillColor = Global.themeColor1;
        }

        private void ucSettings_Preferences_Load(object sender, EventArgs e)
        {
            loadPreferences_ThemeStyle();
        }

        private void loadPreferences_ThemeStyle()
        {
            if (Global.themeStyle == "Theme 1")
            {
                toggleTheme1.Checked = true;
            }
            else if (Global.themeStyle == "Theme 2")
            {
                toggleTheme2.Checked = true;
            }
            else if (Global.themeStyle == "Theme 3")
            {
                toggleTheme3.Checked = true;
            }
            else if (Global.themeStyle == "Theme 4")
            {
                toggleTheme4.Checked = true;
            }
            else if (Global.themeStyle == "Theme 5")
            {
                toggleTheme5.Checked = true;
            }
            else if (Global.themeStyle == "Theme 6")
            {
                toggleTheme6.Checked = true;
            }
            else if (Global.themeStyle == "Theme 7")
            {
                toggleTheme7.Checked = true;
            }
            else if (Global.themeStyle == "Theme 8")
            {
                toggleTheme8.Checked = true;
            }
            else if (Global.themeStyle == "Theme 9")
            {
                toggleTheme9.Checked = true;
            }
            else if (Global.themeStyle == "Theme 10")
            {
                toggleTheme10.Checked = true;
            }
            else
            {
                toggleTheme1.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Access Validation
            if (classValidateCredentials.validateCredentials(Global.userID, "System Settings", "Preferences", "Change Theme") == false) // Validate if the user has access to a certain system feature
            {
                new classMsgBox().showMsgError("Access Denied!");
                Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                // Get the selected themes
                string themeStyle = "";
                string themeColor1 = "";
                string themeColor2 = "";
                string themeColor3 = "";
                string themeColor4 = "";

                if (toggleTheme1.Checked == true)
                {
                    themeStyle = "Theme 1";
                    themeColor1 = "" + theme1_Color1.FillColor.R + ", " + theme1_Color1.FillColor.G + ", " + theme1_Color1.FillColor.B;
                    themeColor2 = "" + theme1_Color2.FillColor.R + ", " + theme1_Color2.FillColor.G + ", " + theme1_Color2.FillColor.B;
                    themeColor3 = "" + theme1_Color3.FillColor.R + ", " + theme1_Color3.FillColor.G + ", " + theme1_Color3.FillColor.B;
                    themeColor4 = "" + theme1_Color4.FillColor.R + ", " + theme1_Color4.FillColor.G + ", " + theme1_Color4.FillColor.B;
                }
                else if (toggleTheme2.Checked == true)
                {
                    themeStyle = "Theme 2";
                    themeColor1 = "" + theme2_Color1.FillColor.R + ", " + theme2_Color1.FillColor.G + ", " + theme2_Color1.FillColor.B;
                    themeColor2 = "" + theme2_Color2.FillColor.R + ", " + theme2_Color2.FillColor.G + ", " + theme2_Color2.FillColor.B;
                    themeColor3 = "" + theme2_Color3.FillColor.R + ", " + theme2_Color3.FillColor.G + ", " + theme2_Color3.FillColor.B;
                    themeColor4 = "" + theme2_Color4.FillColor.R + ", " + theme2_Color4.FillColor.G + ", " + theme2_Color4.FillColor.B;
                }
                else if (toggleTheme3.Checked == true)
                {
                    themeStyle = "Theme 3";
                    themeColor1 = "" + theme3_Color1.FillColor.R + ", " + theme3_Color1.FillColor.G + ", " + theme3_Color1.FillColor.B;
                    themeColor2 = "" + theme3_Color2.FillColor.R + ", " + theme3_Color2.FillColor.G + ", " + theme3_Color2.FillColor.B;
                    themeColor3 = "" + theme3_Color3.FillColor.R + ", " + theme3_Color3.FillColor.G + ", " + theme3_Color3.FillColor.B;
                    themeColor4 = "" + theme3_Color4.FillColor.R + ", " + theme3_Color4.FillColor.G + ", " + theme3_Color4.FillColor.B;
                }
                else if (toggleTheme4.Checked == true)
                {
                    themeStyle = "Theme 4";
                    themeColor1 = "" + theme4_Color1.FillColor.R + ", " + theme4_Color1.FillColor.G + ", " + theme4_Color1.FillColor.B;
                    themeColor2 = "" + theme4_Color2.FillColor.R + ", " + theme4_Color2.FillColor.G + ", " + theme4_Color2.FillColor.B;
                    themeColor3 = "" + theme4_Color3.FillColor.R + ", " + theme4_Color3.FillColor.G + ", " + theme4_Color3.FillColor.B;
                    themeColor4 = "" + theme4_Color4.FillColor.R + ", " + theme4_Color4.FillColor.G + ", " + theme4_Color4.FillColor.B;
                }
                else if (toggleTheme5.Checked == true)
                {
                    themeStyle = "Theme 5";
                    themeColor1 = "" + theme5_Color1.FillColor.R + ", " + theme5_Color1.FillColor.G + ", " + theme5_Color1.FillColor.B;
                    themeColor2 = "" + theme5_Color2.FillColor.R + ", " + theme5_Color2.FillColor.G + ", " + theme5_Color2.FillColor.B;
                    themeColor3 = "" + theme5_Color3.FillColor.R + ", " + theme5_Color3.FillColor.G + ", " + theme5_Color3.FillColor.B;
                    themeColor4 = "" + theme5_Color4.FillColor.R + ", " + theme5_Color4.FillColor.G + ", " + theme5_Color4.FillColor.B;
                }
                else if (toggleTheme6.Checked == true)
                {
                    themeStyle = "Theme 6";
                    themeColor1 = "" + theme6_Color1.FillColor.R + ", " + theme6_Color1.FillColor.G + ", " + theme6_Color1.FillColor.B;
                    themeColor2 = "" + theme6_Color2.FillColor.R + ", " + theme6_Color2.FillColor.G + ", " + theme6_Color2.FillColor.B;
                    themeColor3 = "" + theme6_Color3.FillColor.R + ", " + theme6_Color3.FillColor.G + ", " + theme6_Color3.FillColor.B;
                    themeColor4 = "" + theme6_Color4.FillColor.R + ", " + theme6_Color4.FillColor.G + ", " + theme6_Color4.FillColor.B;
                }
                else if (toggleTheme7.Checked == true)
                {
                    themeStyle = "Theme 7";
                    themeColor1 = "" + theme7_Color1.FillColor.R + ", " + theme7_Color1.FillColor.G + ", " + theme7_Color1.FillColor.B;
                    themeColor2 = "" + theme7_Color2.FillColor.R + ", " + theme7_Color2.FillColor.G + ", " + theme7_Color2.FillColor.B;
                    themeColor3 = "" + theme7_Color3.FillColor.R + ", " + theme7_Color3.FillColor.G + ", " + theme7_Color3.FillColor.B;
                    themeColor4 = "" + theme7_Color4.FillColor.R + ", " + theme7_Color4.FillColor.G + ", " + theme7_Color4.FillColor.B;
                }
                else if (toggleTheme8.Checked == true)
                {
                    themeStyle = "Theme 8";
                    themeColor1 = "" + theme8_Color1.FillColor.R + ", " + theme8_Color1.FillColor.G + ", " + theme8_Color1.FillColor.B;
                    themeColor2 = "" + theme8_Color2.FillColor.R + ", " + theme8_Color2.FillColor.G + ", " + theme8_Color2.FillColor.B;
                    themeColor3 = "" + theme8_Color3.FillColor.R + ", " + theme8_Color3.FillColor.G + ", " + theme8_Color3.FillColor.B;
                    themeColor4 = "" + theme8_Color4.FillColor.R + ", " + theme8_Color4.FillColor.G + ", " + theme8_Color4.FillColor.B;
                }
                else if (toggleTheme9.Checked == true)
                {
                    themeStyle = "Theme 9";
                    themeColor1 = "" + theme9_Color1.FillColor.R + ", " + theme9_Color1.FillColor.G + ", " + theme9_Color1.FillColor.B;
                    themeColor2 = "" + theme9_Color2.FillColor.R + ", " + theme9_Color2.FillColor.G + ", " + theme9_Color2.FillColor.B;
                    themeColor3 = "" + theme9_Color3.FillColor.R + ", " + theme9_Color3.FillColor.G + ", " + theme9_Color3.FillColor.B;
                    themeColor4 = "" + theme9_Color4.FillColor.R + ", " + theme9_Color4.FillColor.G + ", " + theme9_Color4.FillColor.B;
                }
                else if (toggleTheme10.Checked == true)
                {
                    themeStyle = "Theme 10";
                    themeColor1 = "" + theme10_Color1.FillColor.R + ", " + theme10_Color1.FillColor.G + ", " + theme10_Color1.FillColor.B;
                    themeColor2 = "" + theme10_Color2.FillColor.R + ", " + theme10_Color2.FillColor.G + ", " + theme10_Color2.FillColor.B;
                    themeColor3 = "" + theme10_Color3.FillColor.R + ", " + theme10_Color3.FillColor.G + ", " + theme10_Color3.FillColor.B;
                    themeColor4 = "" + theme10_Color4.FillColor.R + ", " + theme10_Color4.FillColor.G + ", " + theme10_Color4.FillColor.B;
                }
                else
                {
                    themeStyle = "Theme 1";
                    themeColor1 = "" + theme1_Color1.FillColor.R + ", " + theme1_Color1.FillColor.G + ", " + theme1_Color1.FillColor.B;
                    themeColor2 = "" + theme1_Color2.FillColor.R + ", " + theme1_Color2.FillColor.G + ", " + theme1_Color2.FillColor.B;
                    themeColor3 = "" + theme1_Color3.FillColor.R + ", " + theme1_Color3.FillColor.G + ", " + theme1_Color3.FillColor.B;
                    themeColor4 = "" + theme1_Color4.FillColor.R + ", " + theme1_Color4.FillColor.G + ", " + theme1_Color4.FillColor.B;
                }

                MySqlConnect Conns = new MySqlConnect();    // Connect to the database 
                Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_users SET preference_theme_style=@preference_theme_style, preference_theme_color_1=@preference_theme_color_1, preference_theme_color_2=@preference_theme_color_2, preference_theme_color_3=@preference_theme_color_3, preference_theme_color_4=@preference_theme_color_4 WHERE User_ID="+ Global.userID +";", Conns.mySqlconn);     // Create a query command
                // Add Command Parameters
                Conns.mySqlCmd.Parameters.AddWithValue("preference_theme_style", themeStyle);
                Conns.mySqlCmd.Parameters.AddWithValue("preference_theme_color_1", themeColor1);
                Conns.mySqlCmd.Parameters.AddWithValue("preference_theme_color_2", themeColor2);
                Conns.mySqlCmd.Parameters.AddWithValue("preference_theme_color_3", themeColor3);
                Conns.mySqlCmd.Parameters.AddWithValue("preference_theme_color_4", themeColor4);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                Conns.closeConnection();    // !Important ->> Close the connection from the database

                // Successful Message
                new classMsgBox().showMsgSuccessful("Record has been updated!");

                classGlobalFunctions.getPreferences_ThemeStyle(Global.userID);

                // Reload the theme style in this current form
                InitializeThemes();

                // Reload the theme style in the settings form
                var settingsForm = Application.OpenForms.OfType<frmSettings>().Single();
                settingsForm.InitializeThemes();

                // Reload the theme style in the main form
                var mainForm = Application.OpenForms.OfType<frmMain>().Single();
                mainForm.InitializeThemes();
            }
            Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
        }

        private void toggleOptionsOff()
        {
            for (var i = panelContainer.Controls["flowLayoutPanel1"].Controls.Count - 1; i >= 0; i--)
            {
                if (panelContainer.Controls["flowLayoutPanel1"].Controls[i] is Guna.UI2.WinForms.Guna2Panel)
                {
                    for (var j = panelContainer.Controls["flowLayoutPanel1"].Controls[i].Controls[0].Controls.Count - 1; j >= 0; j--)
                    {
                        if (panelContainer.Controls["flowLayoutPanel1"].Controls[i].Controls[0].Controls[j] is Guna.UI2.WinForms.Guna2ToggleSwitch)
                        {
                            Guna.UI2.WinForms.Guna2ToggleSwitch toggleSwitch = panelContainer.Controls["flowLayoutPanel1"].Controls[i].Controls[0].Controls[j] as Guna.UI2.WinForms.Guna2ToggleSwitch;
                            toggleSwitch.Checked = false;
                        }
                    }
                }
            }
        }

        private void toggleTheme1_Click(object sender, EventArgs e)
        {
            if (toggleTheme1.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme1.Checked = true;
            }
        }

        private void toggleTheme2_Click(object sender, EventArgs e)
        {
            if (toggleTheme2.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme2.Checked = true;
            }
        }

        private void toggleTheme3_Click(object sender, EventArgs e)
        {
            if (toggleTheme3.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme3.Checked = true;
            }
        }

        private void toggleTheme4_Click(object sender, EventArgs e)
        {
            if (toggleTheme4.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme4.Checked = true;
            }
        }

        private void toggleTheme5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleTheme5_Click(object sender, EventArgs e)
        {
            if (toggleTheme5.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme5.Checked = true;
            }
        }

        private void toggleTheme6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleTheme6_Click(object sender, EventArgs e)
        {
            if (toggleTheme6.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme6.Checked = true;
            }
        }

        private void toggleTheme7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleTheme7_Click(object sender, EventArgs e)
        {
            if (toggleTheme7.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme7.Checked = true;
            }
        }

        private void toggleTheme8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleTheme8_Click(object sender, EventArgs e)
        {
            if (toggleTheme8.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme8.Checked = true;
            }
        }

        private void toggleTheme9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleTheme9_Click(object sender, EventArgs e)
        {
            if (toggleTheme9.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme9.Checked = true;
            }
        }

        private void toggleTheme10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleTheme10_Click(object sender, EventArgs e)
        {
            if (toggleTheme10.Checked == true)
            {
                toggleOptionsOff();
                toggleTheme10.Checked = true;
            }
        }

        private void toggleTheme1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
