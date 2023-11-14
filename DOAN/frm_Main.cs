using DOAN.DS;
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
    public partial class frm_Main : Form
    {
        Color background1 = Color.FromArgb(65, 100, 74);
        public Account account;
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_trangchinh_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_Name.Text = account.name.ToString();
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            lbl_date.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_HienThiKhachHang_Click(object sender, EventArgs e)
        {
            us_customerUI customerUI = new us_customerUI();
            TienIch.addUserControl(customerUI, pnl_trangchinh);
            LayLaiMau();
            btn_HienThiKhachHang.FillColor = Color.FromArgb(120, 159, 196);
        }

        private void btn_HienThiHoaDon_Click(object sender, EventArgs e)
        {
            us_paymentUI paymentUI = new us_paymentUI(pnl_trangchinh);
            TienIch.addUserControl(paymentUI, pnl_trangchinh);
            LayLaiMau();
            btn_HienThiHoaDon.FillColor = Color.FromArgb(120, 159, 196);
        }

        private void btn_QuanlyNhanvien_Click(object sender, EventArgs e)
        {
            us_employeeUI employeeUI = new us_employeeUI();
            TienIch.addUserControl(employeeUI, pnl_trangchinh);
            LayLaiMau();
            btn_QuanlyNhanvien.FillColor = Color.FromArgb(120, 159, 196);
        }

        private void btn_HienThiMatHang_Click(object sender, EventArgs e)
        {
            frm_ListProduct Fmathang = new frm_ListProduct(pnl_trangchinh);
            TienIch.addForm(Fmathang, pnl_trangchinh);
            LayLaiMau();
            btn_HienThiMatHang.FillColor = Color.FromArgb(120, 159, 196);
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

        private void btn_Banhang_Click(object sender, EventArgs e)
        {
            us_Sell us_Banhang = new us_Sell();
            us_Banhang.eid = account.eid.ToString();
            TienIch.addUserControl(us_Banhang, pnl_trangchinh);
            LayLaiMau();
            btn_Banhang.FillColor = Color.FromArgb(120, 159, 196);
        }

        private void btn_LoHang_Click(object sender, EventArgs e)
        {
            us_Shipment us_Shipment = new us_Shipment(pnl_trangchinh);
            TienIch.addUserControl(us_Shipment, pnl_trangchinh);
            LayLaiMau();
            btn_LoHang.FillColor = Color.FromArgb(120, 159, 196);
        }

        private void LayLaiMau()
        {
            btn_Banhang.FillColor = Color.FromArgb(75, 115, 165);
            btn_HienThiMatHang.FillColor = Color.FromArgb(75, 115, 165);
            btn_LoHang.FillColor = Color.FromArgb(75, 115, 165);
            btn_HienThiHoaDon.FillColor = Color.FromArgb(75, 115, 165);
            btn_NhaCungCap.FillColor = Color.FromArgb(75, 115, 165);
            btn_HienThiKhachHang.FillColor = Color.FromArgb(75, 115, 165);
            btn_thongke.FillColor = Color.FromArgb(75, 115, 165);
            btn_QuanlyNhanvien.FillColor = Color.FromArgb(75, 115, 165);
            btn_CaiDat.FillColor = Color.FromArgb(75, 115, 165);
        }

        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            us_supplier supplier = new us_supplier();
            TienIch.addUserControl(supplier, pnl_trangchinh);
            LayLaiMau();
            btn_NhaCungCap.FillColor = Color.FromArgb(120, 159, 196);           
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            us_Statistic statistic = new us_Statistic(); 
            TienIch.addUserControl(statistic, pnl_trangchinh);
            LayLaiMau();
            btn_thongke.FillColor = Color.FromArgb(120, 159, 196);
        }
    }
}
