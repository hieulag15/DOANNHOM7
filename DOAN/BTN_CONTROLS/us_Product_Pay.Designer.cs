namespace DOAN.BTN_CONTROLS
{
    partial class us_Product_Pay
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_soLuong = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lbl_maSP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_giaTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.lbl_giaTien);
            this.guna2Panel1.Controls.Add(this.lbl_maSP);
            this.guna2Panel1.Controls.Add(this.lbl_soLuong);
            this.guna2Panel1.Location = new System.Drawing.Point(3, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(204, 53);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lbl_soLuong
            // 
            this.lbl_soLuong.CheckedState.Parent = this.lbl_soLuong;
            this.lbl_soLuong.CustomImages.Parent = this.lbl_soLuong;
            this.lbl_soLuong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(115)))), ((int)(((byte)(165)))));
            this.lbl_soLuong.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_soLuong.ForeColor = System.Drawing.Color.White;
            this.lbl_soLuong.HoverState.Parent = this.lbl_soLuong;
            this.lbl_soLuong.Location = new System.Drawing.Point(20, 11);
            this.lbl_soLuong.Name = "lbl_soLuong";
            this.lbl_soLuong.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.lbl_soLuong.ShadowDecoration.Parent = this.lbl_soLuong;
            this.lbl_soLuong.Size = new System.Drawing.Size(35, 35);
            this.lbl_soLuong.TabIndex = 0;
            this.lbl_soLuong.Text = "1";
            // 
            // lbl_maSP
            // 
            this.lbl_maSP.BackColor = System.Drawing.Color.Transparent;
            this.lbl_maSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(115)))), ((int)(((byte)(165)))));
            this.lbl_maSP.Location = new System.Drawing.Point(71, 11);
            this.lbl_maSP.Name = "lbl_maSP";
            this.lbl_maSP.Size = new System.Drawing.Size(31, 15);
            this.lbl_maSP.TabIndex = 1;
            this.lbl_maSP.Text = "maSP";
            this.lbl_maSP.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_giaTien
            // 
            this.lbl_giaTien.BackColor = System.Drawing.Color.Transparent;
            this.lbl_giaTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(115)))), ((int)(((byte)(165)))));
            this.lbl_giaTien.Location = new System.Drawing.Point(161, 31);
            this.lbl_giaTien.Name = "lbl_giaTien";
            this.lbl_giaTien.Size = new System.Drawing.Size(27, 15);
            this.lbl_giaTien.TabIndex = 2;
            this.lbl_giaTien.Text = "Price";
            this.lbl_giaTien.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // us_Product_Pay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(115)))), ((int)(((byte)(165)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "us_Product_Pay";
            this.Size = new System.Drawing.Size(210, 56);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_giaTien;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_maSP;
        private Guna.UI2.WinForms.Guna2CircleButton lbl_soLuong;
    }
}
