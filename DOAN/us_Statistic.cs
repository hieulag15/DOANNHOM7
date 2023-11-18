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
        Customer dbcustomer = new Customer();
        Product dbProduct = new Product();
        DataTable dtProduct = new DataTable();
        private void us_Statistic_Load(object sender, EventArgs e)
        {
            tongTienNhapHang = dbshipment.TotalImportFee(0);
            tongTienBanHang = dbBill.TotalSalesFee(0);
            tongDoanhThu = tongTienBanHang - tongTienNhapHang;
            tongTien = tongDoanhThu;
            HienThiThongTin();
            loadCustomerNumber();
            lbl_SPDaBan.Text = dbBill.SPDaBan(0).ToString();
            LoadProductBestSeller(1);
        }

        Decimal tongTienNhapHang;
        Decimal tongTienBanHang;
        Decimal tongDoanhThu;
        Decimal tongTien;

        private void chart(decimal _tongTienNhapHang, decimal _tongTienBanHang)
        {
            // Set up the chart properties
            chart1.ChartAreas[0].AxisY.Title = "Tổng tiền";
            chart1.Series.Clear();
            chart1.Series.Add("Tổng tiền nhập hàng");
            chart1.Series.Add("Tổng tiền bán hàng");

            // Add data points to the chart
            chart1.Series["Tổng tiền nhập hàng"].Points.AddXY("", _tongTienNhapHang);
            chart1.Series["Tổng tiền bán hàng"].Points.AddXY("", _tongTienBanHang);

            // Hide X-axis labels
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            // Hide X-axis ticks
            chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;

            // Optionally, you can hide X-axis lines
            chart1.ChartAreas[0].AxisX.LineWidth = 0;
        }
        
        private void loadCustomerNumber()
        {
            int result= dbcustomer.customerNumber();
            lbl_tongKhachHang.Text = result.ToString();
        }
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
                    chart(tongTienNhapHang, tongTienBanHang);
                    lbl_SPDaBan.Text = dbBill.SPDaBan(1000).ToString();
                    LoadProductBestSeller(1001);
                }
                if (cb_SoNgay.SelectedIndex == 1)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(0);
                    tongTienBanHang = dbBill.TotalSalesFee(0);
                    chart(tongTienNhapHang, tongTienBanHang);
                    lbl_SPDaBan.Text = dbBill.SPDaBan(0).ToString();
                    LoadProductBestSeller(1);
                }
                if (cb_SoNgay.SelectedIndex == 2)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(7);
                    tongTienBanHang = dbBill.TotalSalesFee(7);
                    chart(tongTienNhapHang, tongTienBanHang);
                    lbl_SPDaBan.Text = dbBill.SPDaBan(7).ToString();
                    LoadProductBestSeller(8);
                }
                if (cb_SoNgay.SelectedIndex == 3)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(30);
                    tongTienBanHang = dbBill.TotalSalesFee(30);
                    chart(tongTienNhapHang, tongTienBanHang);
                    lbl_SPDaBan.Text = dbBill.SPDaBan(30).ToString();
                    LoadProductBestSeller(31);
                }
                if (cb_SoNgay.SelectedIndex == 4)
                {
                    tongTienNhapHang = dbshipment.TotalImportFee(90);
                    tongTienBanHang = dbBill.TotalSalesFee(90);
                    chart(tongTienNhapHang, tongTienBanHang);
                    lbl_SPDaBan.Text = dbBill.SPDaBan(90).ToString();
                    LoadProductBestSeller(91);
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
        public void LoadProductBestSeller(int date)
        {
            dtProduct.Clear();
            DataSet ds = dbProduct.getProductBestSeller(date);
            dtProduct = ds.Tables[0];
            dgv_ListProductBestSeller.DataSource = dtProduct;
            setDataGridView();
        }
        private void setDataGridView()
        {
            if (dgv_ListProductBestSeller != null)
            {
                //Set Header Text cho dtgv
                dgv_ListProductBestSeller.Columns[0].HeaderText = "ID";
                dgv_ListProductBestSeller.Columns[1].HeaderText = "Tên sản phẩm";
                dgv_ListProductBestSeller.Columns[2].HeaderText = "Kích thước";
                dgv_ListProductBestSeller.Columns[3].HeaderText = "Số lượng";

                //Set chiều rộng cột
                int width = dgv_ListProductBestSeller.Width;
                int n_column = dgv_ListProductBestSeller.ColumnCount;
                dgv_ListProductBestSeller.Columns[0].Width -= width / n_column;
                dgv_ListProductBestSeller.Columns[1].Width -= width / n_column;
                dgv_ListProductBestSeller.Columns[2].Width -= width / n_column;
                dgv_ListProductBestSeller.Columns[3].Width -= width / n_column;
                dgv_ListProductBestSeller.AutoResizeColumns();

                // Set độ cao của Header Text
                dgv_ListProductBestSeller.ColumnHeadersHeight = 40; // Điều chỉnh độ cao tùy ý
            }
        }
    }
}
