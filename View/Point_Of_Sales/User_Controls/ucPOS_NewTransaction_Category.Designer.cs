
namespace EXIN.Point_Of_Sales
{
    partial class ucPOS_NewTransaction_Category
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
            this.btnCategory = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // btnCategory
            // 
            this.btnCategory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnCategory.BorderRadius = 10;
            this.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(88)))), ((int)(((byte)(208)))));
            this.btnCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(103)))), ((int)(((byte)(216)))));
            this.btnCategory.ImageOffset = new System.Drawing.Point(0, 10);
            this.btnCategory.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCategory.Location = new System.Drawing.Point(3, 3);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.ShadowDecoration.BorderRadius = 10;
            this.btnCategory.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.btnCategory.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.btnCategory.Size = new System.Drawing.Size(115, 76);
            this.btnCategory.TabIndex = 29;
            this.btnCategory.Text = "Category";
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // ucPOS_NewTransaction_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnCategory);
            this.Name = "ucPOS_NewTransaction_Category";
            this.Size = new System.Drawing.Size(121, 81);
            this.Load += new System.EventHandler(this.ucPOS_NewTransaction_Category_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TileButton btnCategory;
    }
}
