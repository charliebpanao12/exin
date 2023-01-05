
namespace EXIN
{
    partial class frmTransparentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zeroitSmoothAnimator1 = new Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator();
            this.SuspendLayout();
            // 
            // zeroitSmoothAnimator1
            // 
            this.zeroitSmoothAnimator1.AnimationType = Zeroit.Framework.Transitions.SmoothTransitions.AnimationTypes.FadeIn;
            this.zeroitSmoothAnimator1.Control = this;
            this.zeroitSmoothAnimator1.Duration = 500;
            this.zeroitSmoothAnimator1.Mover = 10F;
            this.zeroitSmoothAnimator1.Offset = 10F;
            this.zeroitSmoothAnimator1.Reverse = true;
            this.zeroitSmoothAnimator1.SmoothOut = false;
            this.zeroitSmoothAnimator1.StartValue = 100;
            this.zeroitSmoothAnimator1.TimerInterval = 10;
            this.zeroitSmoothAnimator1.TimerPassed = 0;
            // 
            // frmTransparentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(507, 380);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTransparentForm";
            this.ShowInTaskbar = false;
            this.Text = "frmMsgBox_TransparentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTransparentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator zeroitSmoothAnimator1;
    }
}