
namespace EXIN.Settings
{
    partial class ucSettings_UserCredentials_BusinessUnits
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
            this.lblBusinessUnit = new System.Windows.Forms.Label();
            this.lblBusinessCategory = new System.Windows.Forms.Label();
            this.toggleControl = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 7;
            this.guna2Panel2.Controls.Add(this.lblBusinessUnit);
            this.guna2Panel2.Controls.Add(this.lblBusinessCategory);
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
            this.guna2Panel2.TabIndex = 170;
            // 
            // lblBusinessUnit
            // 
            this.lblBusinessUnit.AutoSize = true;
            this.lblBusinessUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblBusinessUnit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusinessUnit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBusinessUnit.Location = new System.Drawing.Point(274, 21);
            this.lblBusinessUnit.Name = "lblBusinessUnit";
            this.lblBusinessUnit.Size = new System.Drawing.Size(85, 17);
            this.lblBusinessUnit.TabIndex = 155;
            this.lblBusinessUnit.Text = "Business Unit";
            // 
            // lblBusinessCategory
            // 
            this.lblBusinessCategory.AutoSize = true;
            this.lblBusinessCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblBusinessCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusinessCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBusinessCategory.Location = new System.Drawing.Point(89, 21);
            this.lblBusinessCategory.Name = "lblBusinessCategory";
            this.lblBusinessCategory.Size = new System.Drawing.Size(127, 16);
            this.lblBusinessCategory.TabIndex = 153;
            this.lblBusinessCategory.Text = "Business Category";
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
            // ucSettings_UserCredentials_BusinessUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2Panel2);
            this.Name = "ucSettings_UserCredentials_BusinessUnits";
            this.Size = new System.Drawing.Size(827, 70);
            this.Load += new System.EventHandler(this.ucSettings_UserCredentials_BusinessUnits_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblBusinessUnit;
        private System.Windows.Forms.Label lblBusinessCategory;
        public Guna.UI2.WinForms.Guna2ToggleSwitch toggleControl;
    }
}
