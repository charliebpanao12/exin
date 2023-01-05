namespace EXIN
{
    partial class frmViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewer));
            this.crvCheckVoucher = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCheckVoucher
            // 
            this.crvCheckVoucher.ActiveViewIndex = -1;
            this.crvCheckVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCheckVoucher.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCheckVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCheckVoucher.Location = new System.Drawing.Point(0, 0);
            this.crvCheckVoucher.Name = "crvCheckVoucher";
            this.crvCheckVoucher.Size = new System.Drawing.Size(788, 504);
            this.crvCheckVoucher.TabIndex = 0;
            this.crvCheckVoucher.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 504);
            this.Controls.Add(this.crvCheckVoucher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewer";
            this.Text = "crvViewer";
            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCheckVoucher;
    }
}