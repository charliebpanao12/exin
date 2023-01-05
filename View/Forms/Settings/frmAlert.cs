using EXIN.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmAlert : Form
    {
        public frmAlert()
        {
            InitializeComponent();
        }

        public enum alertTypeEnum
        {
            Success,
            Warning,
            Error,
            Info
        }

        private int x, y;
        public void setAlert(string msg, frmAlert.alertTypeEnum type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                frmAlert f = (frmAlert)Application.OpenForms[fname];

                if (f == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            switch (type)
            {
                case frmAlert.alertTypeEnum.Success:
                    this.gunaPictureBox1.Image = Resources.Checkmark_28px;
                    this.BackColor = Color.FromArgb(0, 106, 113);
                    break;
                case frmAlert.alertTypeEnum.Warning:
                    this.gunaPictureBox1.Image = Resources.Warning_28px;
                    this.BackColor = Color.FromArgb(255, 179, 2);
                    break;
                case frmAlert.alertTypeEnum.Error:
                    this.gunaPictureBox1.Image = Resources.Error_28px;
                    this.BackColor = Color.FromArgb(255, 121, 70);
                    break;
                case frmAlert.alertTypeEnum.Info:
                    this.gunaPictureBox1.Image = Resources.Info_28px;
                    this.BackColor = Color.FromArgb(71, 169, 248);
                    break;
            }
            this.gunaLabel1.Text = msg;

            //this.TopMost = false;
            //this.ShowIcon = false;
            //this.ShowInTaskbar = false;

            this.Show();
            this.action = actionEnum.start;
            this.timer1.Interval = 1;
            this.timer1.Start();


        }

        public enum actionEnum
        {
            wait,
            start,
            close
        }

        private frmAlert.actionEnum action;




        private void gunaPictureBox2_Click_1(object sender, EventArgs e)
        {
            this.timer1.Interval = 1;
            this.action = frmAlert.actionEnum.close;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case frmAlert.actionEnum.wait:
                    this.BringToFront();
                    this.timer1.Interval = 1000;
                    this.action = frmAlert.actionEnum.close;
                    break;
                case frmAlert.actionEnum.start:
                    this.BringToFront();
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            this.action = frmAlert.actionEnum.wait;
                        }
                    }
                    break;
                case frmAlert.actionEnum.close:
                    this.BringToFront();
                    this.timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }


    }
}