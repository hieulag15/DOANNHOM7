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

        }

        private void btn_HienThiSanPham_Click(object sender, EventArgs e)
        {
            
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
            frm_mathang Fmathang = new frm_mathang();
            TienIch.addForm(Fmathang, pnl_trangchinh);
        }

        private void btn_TaikhoanAdmin_Click(object sender, EventArgs e)
        {

        }

        private void pic_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
