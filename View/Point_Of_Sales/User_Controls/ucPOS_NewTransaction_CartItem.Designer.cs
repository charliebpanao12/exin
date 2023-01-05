
namespace EXIN.Point_Of_Sales
{
    partial class ucPOS_NewTransaction_CartItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPOS_NewTransaction_CartItem));
            this.panelItemContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddQuantity = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnDeductQuantity = new Guna.UI2.WinForms.Guna2TileButton();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDeleteItem = new Guna.UI2.WinForms.Guna2TileButton();
            this.lblItemName = new System.Windows.Forms.Label();
            this.panelItemContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelItemContainer
            // 
            this.panelItemContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelItemContainer.BorderRadius = 7;
            this.panelItemContainer.Controls.Add(this.btnAddQuantity);
            this.panelItemContainer.Controls.Add(this.btnDeductQuantity);
            this.panelItemContainer.Controls.Add(this.txtQuantity);
            this.panelItemContainer.Controls.Add(this.btnDeleteItem);
            this.panelItemContainer.Controls.Add(this.lblItemName);
            this.panelItemContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItemContainer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.panelItemContainer.Location = new System.Drawing.Point(6, 6);
            this.panelItemContainer.Name = "panelItemContainer";
            this.panelItemContainer.ShadowDecoration.BorderRadius = 10;
            this.panelItemContainer.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.panelItemContainer.ShadowDecoration.Enabled = true;
            this.panelItemContainer.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 2, 5);
            this.panelItemContainer.Size = new System.Drawing.Size(328, 52);
            this.panelItemContainer.TabIndex = 32;
            // 
            // btnAddQuantity
            // 
            this.btnAddQuantity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddQuantity.BackColor = System.Drawing.Color.Transparent;
            this.btnAddQuantity.BorderRadius = 7;
            this.btnAddQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddQuantity.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddQuantity.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddQuantity.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(146)))), ((int)(((byte)(55)))));
            this.btnAddQuantity.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuantity.ForeColor = System.Drawing.Color.White;
            this.btnAddQuantity.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(180)))), ((int)(((byte)(53)))));
            this.btnAddQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnAddQuantity.Image")));
            this.btnAddQuantity.ImageSize = new System.Drawing.Size(10, 10);
            this.btnAddQuantity.Location = new System.Drawing.Point(281, 6);
            this.btnAddQuantity.Name = "btnAddQuantity";
            this.btnAddQuantity.Size = new System.Drawing.Size(40, 40);
            this.btnAddQuantity.TabIndex = 119;
            this.btnAddQuantity.Click += new System.EventHandler(this.btnAddQuantity_Click);
            // 
            // btnDeductQuantity
            // 
            this.btnDeductQuantity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeductQuantity.BackColor = System.Drawing.Color.Transparent;
            this.btnDeductQuantity.BorderRadius = 7;
            this.btnDeductQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeductQuantity.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeductQuantity.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeductQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeductQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeductQuantity.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(216)))), ((int)(((byte)(26)))));
            this.btnDeductQuantity.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeductQuantity.ForeColor = System.Drawing.Color.White;
            this.btnDeductQuantity.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(224)))), ((int)(((byte)(48)))));
            this.btnDeductQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnDeductQuantity.Image")));
            this.btnDeductQuantity.ImageSize = new System.Drawing.Size(10, 10);
            this.btnDeductQuantity.Location = new System.Drawing.Point(182, 6);
            this.btnDeductQuantity.Name = "btnDeductQuantity";
            this.btnDeductQuantity.Size = new System.Drawing.Size(40, 40);
            this.btnDeductQuantity.TabIndex = 121;
            this.btnDeductQuantity.Click += new System.EventHandler(this.btnDeductQuantity_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtQuantity.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "10pcs";
            this.txtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantity.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantity.Location = new System.Drawing.Point(218, 6);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.PlaceholderText = "";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.Size = new System.Drawing.Size(68, 40);
            this.txtQuantity.TabIndex = 120;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteItem.BorderRadius = 7;
            this.btnDeleteItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteItem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(74)))), ((int)(((byte)(37)))));
            this.btnDeleteItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.ForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(66)))), ((int)(((byte)(31)))));
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDeleteItem.Location = new System.Drawing.Point(7, 6);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteItem.TabIndex = 118;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Font = new System.Drawing.Font("DejaVu Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblItemName.Location = new System.Drawing.Point(55, 10);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(115, 33);
            this.lblItemName.TabIndex = 117;
            this.lblItemName.Text = "Item";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucPOS_NewTransaction_CartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.panelItemContainer);
            this.Name = "ucPOS_NewTransaction_CartItem";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(340, 64);
            this.Load += new System.EventHandler(this.ucPOS_NewTransaction_CartItem_Load);
            this.panelItemContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelItemContainer;
        private System.Windows.Forms.Label lblItemName;
        private Guna.UI2.WinForms.Guna2TileButton btnDeleteItem;
        private Guna.UI2.WinForms.Guna2TileButton btnAddQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2TileButton btnDeductQuantity;
    }
}
