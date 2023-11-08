﻿using DOAN.BTN_CONTROLS;
using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_paymentUI : UserControl
    {
        public us_paymentUI()
        {
            InitializeComponent();
        }

        DataTable dtBill = new DataTable();
        Bill dbBill = new Bill();

        private void us_paymentUI_Load(object sender, EventArgs e)
        {
            LoadHistoryBill();
        }

        //load datagridview
        public void LoadHistoryBill()
        {
            try
            {
                dtBill.Clear();
                DataSet ds = dbBill.getBill();
                dtBill = ds.Tables[0];
                dgv_historyPayment.DataSource = dtBill;
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có hóa đơn nào");
            }
        }

        private void dgv_historyPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_historyPayment.CurrentRow.Index;
            idbill = dgv_historyPayment.Rows[i].Cells[0].Value.ToString();
        }

        private void txt_timTheoMaHoaDon_Enter(object sender, EventArgs e)
        {
            SetDefaultTextValues();
            txt_timTheoMaHoaDon.Text = string.Empty;
        }
        private void txt_timTheoSDT_Enter(object sender, EventArgs e)
        {
            SetDefaultTextValues();
            txt_timTheoSDT.Text = string.Empty;
        }
        private void txt_timTheoMaMatHang_Enter(object sender, EventArgs e)
        {
            SetDefaultTextValues();
            txt_timTheoMaMatHang.Text = string.Empty;
        }

        private void btn_chiTiet_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgv_historyPayment.CurrentRow;
            string b_id = (string)currentRow.Cells[0].Value;
            frm_Main frm_home = new frm_Main();
            frm_detailPayment frm_detail = new frm_detailPayment();
            frm_detail.ShowDialog();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            SetDefaultTextValues();
            dtp_mocDau.Value = DateTime.Today;
            dtp_mocSau.Value = DateTime.Today;
            LoadHistoryBill();
        }

        private void btn_ApDung_Click(object sender, EventArgs e)
        {
            dtBill.Clear();
            DataSet ds = dbBill.timTheoNgay(dtp_mocDau.Value, dtp_mocSau.Value);
            dtBill = ds.Tables[0];
            dgv_historyPayment.DataSource = dtBill;
            SetDefaultTextValues();
        }

        private void pic_timMaHoaDon_Click(object sender, EventArgs e)
        {
            dtBill.Clear();
            DataSet ds = dbBill.timTheoMaBill(txt_timTheoMaHoaDon.Text);
            dtBill = ds.Tables[0];
            dgv_historyPayment.DataSource = dtBill;
        }

        private void pic_timSĐT_Click(object sender, EventArgs e)
        {
            dtBill.Clear();
            DataSet ds = dbBill.timTheoSDT(txt_timTheoSDT.Text);
            dtBill = ds.Tables[0];
            dgv_historyPayment.DataSource = dtBill;
        }

        private void pic_timmamathang_Click(object sender, EventArgs e)
        {
            dtBill.Clear();
            DataSet ds = dbBill.timTheoMaSP(txt_timTheoMaMatHang.Text);
            dtBill = ds.Tables[0];
            dgv_historyPayment.DataSource = dtBill;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            XoaHoaDon();
        }

        //Xử lý
        private void SetDefaultTextValues()
        {
            txt_timTheoMaHoaDon.Text = "Theo mã hóa đơn";
            txt_timTheoSDT.Text = "Theo SĐT khách hàng";
            txt_timTheoMaMatHang.Text = "Theo mã mặt hàng";
        }

        string idbill;
        private void XoaHoaDon()
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa hóa đơn?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbBill.deleteBill(idbill);
                    // Cập nhật lại DataGridView 
                    LoadHistoryBill();
                    // Thông báo 
                    MessageBox.Show("Đã xóa xong!");

                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }
    }
}
