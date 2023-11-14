using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_Statistic : UserControl
    {
        public us_Statistic()
        {
            InitializeComponent();
        }

        Shipment dbshipment = new Shipment();
        Bill dbBill = new Bill();
        private void us_Statistic_Load(object sender, EventArgs e)
        {
            tongTien = dbBill.TotalSalesFee(0) - dbshipment.TotalImportFee(0);
            HienThiThongTin();
        }

        Decimal tongTienNhapHang;
        Decimal tongTienBanHang;
        Decimal tongDoanhThu;
        Decimal tongTien;

        private void HienThiThongTin()
        {
            lbl_tongtien.Text = tongTien.ToString();
        }

        private void cb_SoNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_SoNgay.SelectedItem != null)
            {
                if (cb_SoNgay.SelectedIndex == 0)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(1000);
                    tongTienBanHang = dbBill.TotalSalesFee(1000);
                }
                if (cb_SoNgay.SelectedIndex == 1)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(0);
                    tongTienBanHang = dbBill.TotalSalesFee(0);
                }
                if (cb_SoNgay.SelectedIndex == 2)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(7);
                    tongTienBanHang = dbBill.TotalSalesFee(7);
                }
                if (cb_SoNgay.SelectedIndex == 3)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(30);
                    tongTienBanHang = dbBill.TotalSalesFee(30);
                }
                if (cb_SoNgay.SelectedIndex == 4)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(90);
                    tongTienBanHang = dbBill.TotalSalesFee(90);
                }

                tongDoanhThu = tongTienBanHang - tongTienNhapHang;

                if (cb_Tong.SelectedIndex == 0)
                {
                    tongTien = tongDoanhThu;
                }
                if (cb_Tong.SelectedIndex == 1)
                {
                    tongTien = tongTienNhapHang;
                }
                if (cb_Tong.SelectedIndex == 2)
                {
                    tongTien = tongTienBanHang;
                }

                HienThiThongTin();
            }
        }

        private void cb_Tong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Tong.SelectedItem != null)
            {
                if (cb_Tong.SelectedIndex == 0)
                {
                    tongTien = tongDoanhThu;
                }
                if (cb_Tong.SelectedIndex == 1)
                {
                    tongTien = tongTienNhapHang;
                }
                if (cb_Tong.SelectedIndex == 2)
                {
                    tongTien = tongTienBanHang;
                }
                HienThiThongTin();
            }            
        }
    }
}
