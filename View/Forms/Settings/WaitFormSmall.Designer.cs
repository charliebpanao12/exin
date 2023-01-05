
namespace EXIN
{
    partial class WaitFormSmall
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.prgLoader = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            // 
            // prgLoader
            // 
            this.prgLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prgLoader.AutoStart = true;
            this.prgLoader.Location = new System.Drawing.Point(25, 17);
            this.prgLoader.Name = "prgLoader";
            this.prgLoader.ProgressColor = System.Drawing.Color.Teal;
            this.prgLoader.Size = new System.Drawing.Size(71, 66);
            this.prgLoader.TabIndex = 2;
            // 
            // WaitFormSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(120, 100);
            this.Controls.Add(this.prgLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitFormSmall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaitFormSmall";
            this.Load += new System.EventHandler(this.WaitFormSmall_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator prgLoader;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}