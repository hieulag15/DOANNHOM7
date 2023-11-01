﻿using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class Frm_Login : Form
    {
        Account dbAccount = new Account();
        public Frm_Login()
        {
            InitializeComponent();

            panelShop.BackColor = Color.FromArgb(100, Color.White);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            bool check = dbAccount.testLogin(txt_Username.Text, txt_Password.Text);
            if (check)
            {
                DataSet ds = dbAccount.GetAccount(txt_Username.Text, txt_Password.Text);
                DataTable dt = ds.Tables[0];
                dbAccount = new Account(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                frm_Main frm_home = new frm_Main();
                frm_home.account = dbAccount;
                this.Hide();
                frm_home.ShowDialog();
                this.Close();
            }
        }

        private void txt_Username_Leave(object sender, EventArgs e)
        {
            if (txt_Username.Text == "")
            {
                txt_Username.Text = "Username";
            }
        }

        private void txt_Username_Click(object sender, EventArgs e)
        {
            if (txt_Username.Text == "Username")
            {
                txt_Username.Text = "";
            }
        }

        private void txt_Password_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "Password")
            {
                txt_Password.Text = "";
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text == "")
            {
                txt_Password.Text = "Password";
            }
        }
    }
}
