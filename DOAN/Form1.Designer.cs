namespace DOAN
{
    partial class Form1
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
            this.us_paymentUI1 = new DOAN.us_paymentUI();
            this.SuspendLayout();
            // 
            // us_paymentUI1
            // 
            this.us_paymentUI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(100)))), ((int)(((byte)(74)))));
            this.us_paymentUI1.Location = new System.Drawing.Point(13, 13);
            this.us_paymentUI1.Margin = new System.Windows.Forms.Padding(4);
            this.us_paymentUI1.Name = "us_paymentUI1";
            this.us_paymentUI1.Size = new System.Drawing.Size(1302, 682);
            this.us_paymentUI1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 786);
            this.Controls.Add(this.us_paymentUI1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private us_paymentUI us_paymentUI1;
    }
}

