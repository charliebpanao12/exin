
namespace EXIN.Point_Of_Sales
{
    partial class ucPOS_NewTransaction_Item
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
            this.panelItemContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.picItemPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelItemContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panelItemContainer
            // 
            this.panelItemContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelItemContainer.BorderRadius = 7;
            this.panelItemContainer.Controls.Add(this.lblPrice);
            this.panelItemContainer.Controls.Add(this.lblItemCode);
            this.panelItemContainer.Controls.Add(this.lblItemName);
            this.panelItemContainer.Controls.Add(this.picItemPicture);
            this.panelItemContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelItemContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItemContainer.FillColor = System.Drawing.Color.White;
            this.panelItemContainer.Location = new System.Drawing.Point(3, 3);
            this.panelItemContainer.Name = "panelItemContainer";
            this.panelItemContainer.ShadowDecoration.BorderRadius = 10;
            this.panelItemContainer.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.panelItemContainer.ShadowDecoration.Enabled = true;
            this.panelItemContainer.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 1, 2, 5);
            this.panelItemContainer.Size = new System.Drawing.Size(143, 170);
            this.panelItemContainer.TabIndex = 31;
            this.panelItemContainer.Click += new System.EventHandler(this.panelItemContainer_Click);
            this.panelItemContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelItemContainer_MouseDown);
            this.panelItemContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelItemContainer_MouseUp);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPrice.Location = new System.Drawing.Point(75, 148);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(64, 17);
            this.lblPrice.TabIndex = 118;
            this.lblPrice.Text = "₱ 0.00";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPrice.Click += new System.EventHandler(this.lblPrice_Click);
            this.lblPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPrice_MouseDown);
            // 
            // lblItemCode
            // 
            this.lblItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItemCode.BackColor = System.Drawing.Color.Transparent;
            this.lblItemCode.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblItemCode.Location = new System.Drawing.Point(6, 148);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(59, 16);
            this.lblItemCode.TabIndex = 117;
            this.lblItemCode.Text = "ID:";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemCode.Click += new System.EventHandler(this.label1_Click);
            this.lblItemCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblItemCode_MouseDown);
            this.lblItemCode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblItemCode_MouseUp);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblItemName.Location = new System.Drawing.Point(6, 115);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(132, 31);
            this.lblItemName.TabIndex = 116;
            this.lblItemName.Text = "Item";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblItemName.Click += new System.EventHandler(this.lblItemName_Click);
            this.lblItemName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblItemName_MouseDown);
            this.lblItemName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblItemName_MouseUp);
            // 
            // picItemPicture
            // 
            this.picItemPicture.BackColor = System.Drawing.Color.Transparent;
            this.picItemPicture.BorderRadius = 7;
            this.picItemPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.picItemPicture.Enabled = false;
            this.picItemPicture.FillColor = System.Drawing.Color.Transparent;
            this.picItemPicture.ImageRotate = 0F;
            this.picItemPicture.Location = new System.Drawing.Point(0, 0);
            this.picItemPicture.Name = "picItemPicture";
            this.picItemPicture.Size = new System.Drawing.Size(143, 111);
            this.picItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItemPicture.TabIndex = 22;
            this.picItemPicture.TabStop = false;
            this.picItemPicture.UseTransparentBackground = true;
            this.picItemPicture.Click += new System.EventHandler(this.picItemPicture_Click);
            this.picItemPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picItemPicture_MouseDown);
            this.picItemPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picItemPicture_MouseUp);
            // 
            // ucPOS_NewTransaction_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelItemContainer);
            this.Name = "ucPOS_NewTransaction_Item";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(149, 176);
            this.Load += new System.EventHandler(this.ucPOS_NewTransaction_Item_Load);
            this.panelItemContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItemPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelItemContainer;
        private Guna.UI2.WinForms.Guna2PictureBox picItemPicture;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label lblPrice;
    }
}
