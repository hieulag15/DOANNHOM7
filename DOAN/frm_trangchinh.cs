using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace DOAN
{
    public partial class frm_trangchinh : Form
    {
        Color background1 = Color.FromArgb(65, 100, 74); 

        public frm_trangchinh()
        {
            InitializeComponent();
        }

        private void frm_trangchinh_Load(object sender, EventArgs e)
        {
            timer1.Start();

            lbl_time.Text = DateTime.Now.ToLongTimeString();
            lbl_date.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_HienThiKhachHang_Click(object sender, EventArgs e)
        {
            us_customerUI customerUI = new us_customerUI();
            TienIch.addUserControl(customerUI, pnl_trangchinh);
        }

        private void btn_HienThiHoaDon_Click(object sender, EventArgs e)
        {
            us_paymentUI paymentUI = new us_paymentUI();
            TienIch.addUserControl(paymentUI, pnl_trangchinh);
        }

        private void btn_QuanlyNhanvien_Click(object sender, EventArgs e)
        {
            us_employeeUI employeeUI = new us_employeeUI();
            TienIch.addUserControl(employeeUI, pnl_trangchinh);
        }

        private void btn_HienThiMatHang_Click(object sender, EventArgs e)
        {
            frm_mathang Fmathang = new frm_mathang(this.pnl_trangchinh);
            TienIch.addForm(Fmathang, pnl_trangchinh);
        }

        private void btn_TaikhoanAdmin_Click(object sender, EventArgs e)
        {

        }

        private void pic_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btn_NhapKho_Click(object sender, EventArgs e)
        {

        }

        private void btn_Banhang_Click(object sender, EventArgs e)
        {
            us_banhang us_Banhang = new us_banhang();
            TienIch.addUserControl(us_Banhang, pnl_trangchinh);
        }
    }
}
