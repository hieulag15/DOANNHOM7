using DOAN.BTN_CONTROLS;
using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
                try
                {
                    dtBill.Clear();
                    DataSet ds = dbBill.timTheoMaBill(txt_timTheoMaHoaDon.Text);
                    dtBill = ds.Tables[0];
                    dgv_historyPayment.DataSource = dtBill;

                }
                catch (SqlException)
                {
                    MessageBox.Show("Hóa đơn không tồn tại!");
                }
                e.Handled = true; //không xử lý thêm nữa
            }
        }

        //tìm kiếm theo sđt khách hàng sau khi nhấn phím enter
        private void txt_timTheoSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    dtBill.Clear();
                    DataSet ds = dbBill.timTheoSDT(txt_timTheoSDT.Text);
                    dtBill = ds.Tables[0];
                    dgv_historyPayment.DataSource = dtBill;

                }
                catch (SqlException)
                {
                    MessageBox.Show("Hóa đơn không tồn tại!");
                }
                e.Handled = true; //không xử lý thêm nữa
            }
        }

        //tìm kiếm theo mã sp sau khi nhấn phím enter
        private void txt_timTheoMaMatHang_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    dtBill.Clear();
                    DataSet ds = dbBill.timTheoMaSP(txt_timTheoMaMatHang.Text);
                    dtBill = ds.Tables[0];
                    dgv_historyPayment.DataSource = dtBill;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Hóa đơn không tồn tại!");
                }
                e.Handled = true; //không xử lý thêm nữa
            }
        }

        private void pic_timHoaDon_Click(object sender, EventArgs e)
        {

        }
        private void btn_chiTiet_Click(object sender, EventArgs e)
        {

        }
    }
}
