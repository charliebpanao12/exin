
namespace EXIN.Settings
{
    partial class frmSettings_ExpandedAccounts_New
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
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.zeroitSmoothAnimator1 = new Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2PanelBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panelTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numtxtExpandedAccountCode = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtExpandedAccountDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PanelBottom.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtExpandedAccountCode)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelTitle;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // zeroitSmoothAnimator1
            // 
            this.zeroitSmoothAnimator1.AnimationType = Zeroit.Framework.Transitions.SmoothTransitions.AnimationTypes.FadeIn;
            this.zeroitSmoothAnimator1.Control = this;
            this.zeroitSmoothAnimator1.Duration = 400;
            this.zeroitSmoothAnimator1.Mover = 10F;
            this.zeroitSmoothAnimator1.Offset = 10F;
            this.zeroitSmoothAnimator1.Reverse = true;
            this.zeroitSmoothAnimator1.SmoothOut = false;
            this.zeroitSmoothAnimator1.StartValue = 100;
            this.zeroitSmoothAnimator1.TimerInterval = 10;
            this.zeroitSmoothAnimator1.TimerPassed = 0;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DarkGray;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2PanelBottom
            // 
            this.guna2PanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.guna2PanelBottom.BorderColor = System.Drawing.Color.Transparent;
            this.guna2PanelBottom.Controls.Add(this.btnSave);
            this.guna2PanelBottom.Controls.Add(this.btnClose);
            this.guna2PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2PanelBottom.Location = new System.Drawing.Point(0, 284);
            this.guna2PanelBottom.Name = "guna2PanelBottom";
            this.guna2PanelBottom.Size = new System.Drawing.Size(628, 86);
            this.guna2PanelBottom.TabIndex = 180;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 16;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(333, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 16;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnClose.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(172, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.panelTitle.CustomBorderThickness = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(628, 51);
            this.panelTitle.TabIndex = 179;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 25);
            this.lblTitle.TabIndex = 114;
            this.lblTitle.Text = "Expanded Account";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(74)))), ((int)(((byte)(20)))));
            this.label7.Location = new System.Drawing.Point(207, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 19);
            this.label7.TabIndex = 256;
            this.label7.Text = "*";
            // 
            // numtxtExpandedAccountCode
            // 
            this.numtxtExpandedAccountCode.BackColor = System.Drawing.Color.Transparent;
            this.numtxtExpandedAccountCode.BorderRadius = 5;
            this.numtxtExpandedAccountCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numtxtExpandedAccountCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxtExpandedAccountCode.ForeColor = System.Drawing.Color.DimGray;
            this.numtxtExpandedAccountCode.Location = new System.Drawing.Point(255, 108);
            this.numtxtExpandedAccountCode.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numtxtExpandedAccountCode.Name = "numtxtExpandedAccountCode";
            this.numtxtExpandedAccountCode.Size = new System.Drawing.Size(322, 35);
            this.numtxtExpandedAccountCode.TabIndex = 0;
            this.numtxtExpandedAccountCode.TextOffset = new System.Drawing.Point(5, 0);
            this.numtxtExpandedAccountCode.UpDownButtonFillColor = System.Drawing.Color.White;
            // 
            // txtExpandedAccountDesc
            // 
            this.txtExpandedAccountDesc.BorderRadius = 5;
            this.txtExpandedAccountDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExpandedAccountDesc.DefaultText = "";
            this.txtExpandedAccountDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtExpandedAccountDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtExpandedAccountDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpandedAccountDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpandedAccountDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtExpandedAccountDesc.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtExpandedAccountDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtExpandedAccountDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtExpandedAccountDesc.Location = new System.Drawing.Point(255, 163);
            this.txtExpandedAccountDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExpandedAccountDesc.Multiline = true;
            this.txtExpandedAccountDesc.Name = "txtExpandedAccountDesc";
            this.txtExpandedAccountDesc.PasswordChar = '\0';
            this.txtExpandedAccountDesc.PlaceholderText = "Expanded Account";
            this.txtExpandedAccountDesc.SelectedText = "";
            this.txtExpandedAccountDesc.Size = new System.Drawing.Size(322, 83);
            this.txtExpandedAccountDesc.TabIndex = 1;
            this.txtExpandedAccountDesc.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(39, 121);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(171, 16);
            this.label22.TabIndex = 254;
            this.label22.Text = "Expanded Account Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(74)))), ((int)(((byte)(20)))));
            this.label1.Location = new System.Drawing.Point(203, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 19);
            this.label1.TabIndex = 258;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(39, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 257;
            this.label2.Text = "Expanded Account Desc";
            // 
            // frmSettings_ExpandedAccounts_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numtxtExpandedAccountCode);
            this.Controls.Add(this.txtExpandedAccountDesc);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.guna2PanelBottom);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings_ExpandedAccounts_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings_ExpandedAccounts_New";
            this.Load += new System.EventHandler(this.frmSettings_ExpandedAccounts_New_Load);
            this.guna2PanelBottom.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtExpandedAccountCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator zeroitSmoothAnimator1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelBottom;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2NumericUpDown numtxtExpandedAccountCode;
        private Guna.UI2.WinForms.Guna2TextBox txtExpandedAccountDesc;
        private System.Windows.Forms.Label label22;
    }
}