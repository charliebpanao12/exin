
namespace EXIN.Inventory_System
{
    partial class frmInventory_InventoryOut_AddNewTransaction_Quantity
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
            this.elpParent = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2PanelBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PanelTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.numtxtQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2PanelBottom.SuspendLayout();
            this.guna2PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // elpParent
            // 
            this.elpParent.BorderRadius = 15;
            this.elpParent.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.DarkGray;
            // 
            // guna2PanelBottom
            // 
            this.guna2PanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.guna2PanelBottom.BorderColor = System.Drawing.Color.Transparent;
            this.guna2PanelBottom.Controls.Add(this.btnSave);
            this.guna2PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2PanelBottom.Location = new System.Drawing.Point(0, 191);
            this.guna2PanelBottom.Name = "guna2PanelBottom";
            this.guna2PanelBottom.Size = new System.Drawing.Size(445, 86);
            this.guna2PanelBottom.TabIndex = 172;
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
            this.btnSave.Location = new System.Drawing.Point(161, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Continue";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2PanelTitle
            // 
            this.guna2PanelTitle.Controls.Add(this.label9);
            this.guna2PanelTitle.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.guna2PanelTitle.CustomBorderThickness = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.guna2PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelTitle.Name = "guna2PanelTitle";
            this.guna2PanelTitle.Size = new System.Drawing.Size(445, 51);
            this.guna2PanelTitle.TabIndex = 171;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 25);
            this.label9.TabIndex = 114;
            this.label9.Text = "Quantity";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DimGray;
            this.label25.Location = new System.Drawing.Point(60, 95);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 16);
            this.label25.TabIndex = 169;
            this.label25.Text = "Quantity";
            // 
            // numtxtQuantity
            // 
            this.numtxtQuantity.BackColor = System.Drawing.Color.Transparent;
            this.numtxtQuantity.BorderRadius = 5;
            this.numtxtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numtxtQuantity.DecimalPlaces = 2;
            this.numtxtQuantity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxtQuantity.Location = new System.Drawing.Point(158, 88);
            this.numtxtQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numtxtQuantity.Name = "numtxtQuantity";
            this.numtxtQuantity.Size = new System.Drawing.Size(218, 33);
            this.numtxtQuantity.TabIndex = 173;
            this.numtxtQuantity.ThousandsSeparator = true;
            // 
            // frmInventory_InventoryIn_AddNewTransaction_Quantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 277);
            this.Controls.Add(this.numtxtQuantity);
            this.Controls.Add(this.guna2PanelBottom);
            this.Controls.Add(this.guna2PanelTitle);
            this.Controls.Add(this.label25);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInventory_InventoryIn_AddNewTransaction_Quantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInventory_Products_NewItem_Quantity";
            this.Load += new System.EventHandler(this.frmInventory_Products_NewItem_Quantity_Load);
            this.guna2PanelBottom.ResumeLayout(false);
            this.guna2PanelTitle.ResumeLayout(false);
            this.guna2PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse elpParent;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        public Guna.UI2.WinForms.Guna2Panel guna2PanelBottom;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        public Guna.UI2.WinForms.Guna2Panel guna2PanelTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label25;
        public Guna.UI2.WinForms.Guna2NumericUpDown numtxtQuantity;
    }
}