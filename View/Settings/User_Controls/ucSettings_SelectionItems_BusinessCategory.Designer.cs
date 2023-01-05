
namespace EXIN.Settings
{
    partial class ucSettings_SelectionItems_BusinessCategory
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
            this.lblLocked = new System.Windows.Forms.Label();
            this.lblNoAccess = new System.Windows.Forms.Label();
            this.lblBusinessCategory = new System.Windows.Forms.Label();
            this.toggleControl = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 7;
            this.guna2Panel2.Controls.Add(this.lblLocked);
            this.guna2Panel2.Controls.Add(this.lblNoAccess);
            this.guna2Panel2.Controls.Add(this.lblBusinessCategory);
            this.guna2Panel2.Controls.Add(this.toggleControl);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(5, 5);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 7;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.guna2Panel2.ShadowDecoration.Depth = 50;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 1, 2, 5);
            this.guna2Panel2.Size = new System.Drawing.Size(390, 58);
            this.guna2Panel2.TabIndex = 171;
            // 
            // lblLocked
            // 
            this.lblLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocked.BackColor = System.Drawing.Color.Transparent;
            this.lblLocked.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(18)))), ((int)(((byte)(181)))));
            this.lblLocked.Location = new System.Drawing.Point(256, 8);
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Size = new System.Drawing.Size(127, 16);
            this.lblLocked.TabIndex = 155;
            this.lblLocked.Text = "Locked";
            this.lblLocked.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLocked.Visible = false;
            // 
            // lblNoAccess
            // 
            this.lblNoAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoAccess.BackColor = System.Drawing.Color.Transparent;
            this.lblNoAccess.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(71)))), ((int)(((byte)(17)))));
            this.lblNoAccess.Location = new System.Drawing.Point(256, 35);
            this.lblNoAccess.Name = "lblNoAccess";
            this.lblNoAccess.Size = new System.Drawing.Size(127, 16);
            this.lblNoAccess.TabIndex = 154;
            this.lblNoAccess.Text = "No Access";
            this.lblNoAccess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNoAccess.Visible = false;
            // 
            // lblBusinessCategory
            // 
            this.lblBusinessCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBusinessCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblBusinessCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusinessCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBusinessCategory.Location = new System.Drawing.Point(76, 8);
            this.lblBusinessCategory.Name = "lblBusinessCategory";
            this.lblBusinessCategory.Size = new System.Drawing.Size(197, 41);
            this.lblBusinessCategory.TabIndex = 153;
            this.lblBusinessCategory.Text = "Business Category";
            this.lblBusinessCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toggleControl
            // 
            this.toggleControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toggleControl.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleControl.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleControl.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggleControl.CheckedState.InnerColor = System.Drawing.Color.White;
            this.toggleControl.Location = new System.Drawing.Point(26, 18);
            this.toggleControl.Name = "toggleControl";
            this.toggleControl.Size = new System.Drawing.Size(35, 20);
            this.toggleControl.TabIndex = 16;
            this.toggleControl.UncheckedState.BorderColor = System.Drawing.Color.DarkGray;
            this.toggleControl.UncheckedState.FillColor = System.Drawing.Color.DarkGray;
            this.toggleControl.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggleControl.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.toggleControl.CheckedChanged += new System.EventHandler(this.toggleControl_CheckedChanged);
            this.toggleControl.Click += new System.EventHandler(this.toggleControl_Click);
            // 
            // ucSettings_SelectionItems_BusinessCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.guna2Panel2);
            this.Name = "ucSettings_SelectionItems_BusinessCategory";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(400, 68);
            this.Load += new System.EventHandler(this.ucSettings_SelectionItems_BusinessCategory_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblBusinessCategory;
        public Guna.UI2.WinForms.Guna2ToggleSwitch toggleControl;
        public System.Windows.Forms.Label lblNoAccess;
        public System.Windows.Forms.Label lblLocked;
    }
}
