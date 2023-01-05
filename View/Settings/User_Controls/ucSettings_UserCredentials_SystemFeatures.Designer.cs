
namespace EXIN.Settings
{
    partial class ucSettings_UserCredentials_SystemFeatures
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSystemFeature = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.toggleControl = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 7;
            this.guna2Panel2.Controls.Add(this.lblSystemFeature);
            this.guna2Panel2.Controls.Add(this.lblCategory);
            this.guna2Panel2.Controls.Add(this.toggleControl);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(87, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 7;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.guna2Panel2.ShadowDecoration.Depth = 50;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 1, 2, 5);
            this.guna2Panel2.Size = new System.Drawing.Size(649, 60);
            this.guna2Panel2.TabIndex = 169;
            // 
            // lblSystemFeature
            // 
            this.lblSystemFeature.AutoSize = true;
            this.lblSystemFeature.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemFeature.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemFeature.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSystemFeature.Location = new System.Drawing.Point(274, 21);
            this.lblSystemFeature.Name = "lblSystemFeature";
            this.lblSystemFeature.Size = new System.Drawing.Size(103, 17);
            this.lblSystemFeature.TabIndex = 155;
            this.lblSystemFeature.Text = "System Feature";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCategory.Location = new System.Drawing.Point(89, 21);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(69, 16);
            this.lblCategory.TabIndex = 153;
            this.lblCategory.Text = "Category";
            // 
            // toggleControl
            // 
            this.toggleControl.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleControl.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleControl.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggleControl.CheckedState.InnerColor = System.Drawing.Color.White;
            this.toggleControl.Location = new System.Drawing.Point(26, 20);
            this.toggleControl.Name = "toggleControl";
            this.toggleControl.Size = new System.Drawing.Size(35, 20);
            this.toggleControl.TabIndex = 16;
            this.toggleControl.UncheckedState.BorderColor = System.Drawing.Color.DarkGray;
            this.toggleControl.UncheckedState.FillColor = System.Drawing.Color.DarkGray;
            this.toggleControl.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggleControl.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // ucSettings_UserCredentials_SystemFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2Panel2);
            this.Name = "ucSettings_UserCredentials_SystemFeatures";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(827, 70);
            this.Load += new System.EventHandler(this.ucSettings_UserCredentials_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Guna.UI2.WinForms.Guna2ToggleSwitch toggleControl;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSystemFeature;
    }
}
