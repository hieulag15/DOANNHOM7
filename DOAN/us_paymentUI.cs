using DOAN.BTN_CONTROLS;
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

        private void txt_timTheoMaHoaDon_Enter(object sender, EventArgs e)
        {
            txt_timTheoMaHoaDon.Text = string.Empty;
        }
        private void txt_timTheoSDT_Enter(object sender, EventArgs e)
        {
            txt_timTheoSDT.Text = string.Empty;
        }
        private void txt_timTheoMaMatHang_Enter(object sender, EventArgs e)
        {
            txt_timTheoMaMatHang.Text = string.Empty;
        }

        //tìm kiếm theo mã hóa đơn sau khi nhấn phím enter
        private void txt_timTheoMaHoaDon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtBill.Clear();
                DataSet ds = dbBill.timTheoMaBill(txt_timTheoMaHoaDon.Text);
                dtBill = ds.Tables[0];
                dgv_historyPayment.DataSource = dtBill;
                txt_timTheoSDT.Text = "Theo SĐT khách hàng";
                txt_timTheoMaMatHang.Text = "Theo mã mặt hàng";
                e.Handled = true; //không xử lý thêm nữa
            }
        }

        //tìm kiếm theo sđt khách hàng sau khi nhấn phím enter
        private void txt_timTheoSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtBill.Clear();
                DataSet ds = dbBill.timTheoSDT(txt_timTheoSDT.Text);
                dtBill = ds.Tables[0];
                dgv_historyPayment.DataSource = dtBill;
                txt_timTheoMaHoaDon.Text = "Theo mã hóa đơn";
                txt_timTheoMaMatHang.Text = "Theo mã mặt hàng";
                e.Handled = true; //không xử lý thêm nữa
            }
        }

        //tìm kiếm theo mã sp sau khi nhấn phím enter
        private void txt_timTheoMaMatHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtBill.Clear();
                DataSet ds = dbBill.timTheoMaSP(txt_timTheoMaMatHang.Text);
                dtBill = ds.Tables[0];
                dgv_historyPayment.DataSource = dtBill;
                txt_timTheoMaHoaDon.Text = "Theo mã hóa đơn";
                txt_timTheoSDT.Text = "Theo SĐT khách hàng";
                e.Handled = true; //không xử lý thêm nữa
            }
        }

        private void pic_timHoaDon_Click(object sender, EventArgs e)
        {
            dtBill.Clear();
            DataSet ds = dbBill.timTheoNgay(dtp_mocDau.Value, dtp_mocSau.Value);
            dtBill = ds.Tables[0];
            dgv_historyPayment.DataSource = dtBill;
            txt_timTheoMaHoaDon.Text = "Theo mã hóa đơn";
            txt_timTheoSDT.Text = "Theo SĐT khách hàng";
            txt_timTheoMaMatHang.Text = "Theo mã mặt hàng";
        }
        private void btn_chiTiet_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgv_historyPayment.CurrentRow;
            string b_id = (string)currentRow.Cells[0].Value;
            frm_Main frm_home = new frm_Main();
            frm_detailPayment frm_detail = new frm_detailPayment();
            frm_detail.ShowDialog();
        }

        private void pic_refresh_Click(object sender, EventArgs e)
        {
            txt_timTheoMaHoaDon.Text = "Theo mã hóa đơn";
            txt_timTheoSDT.Text = "Theo SĐT khách hàng";
            txt_timTheoMaMatHang.Text = "Theo mã mặt hàng";
            dtp_mocDau.Value = DateTime.Today;
            dtp_mocSau.Value = DateTime.Today;
            LoadHistoryBill();
        }
    }
}
