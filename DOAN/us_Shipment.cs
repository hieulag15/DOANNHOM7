﻿using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_Shipment : UserControl
    {
        Panel pnl_trangchinh;
        public us_Shipment()
        {
            InitializeComponent();
        }

        public us_Shipment(Panel pnl_trangchinh)
        {
            InitializeComponent();
            this.pnl_trangchinh = pnl_trangchinh;
        }

        DataTable dtShipment = new DataTable();
        Shipment dbShipment = new Shipment();
        DataTable dtDetailShipment = new DataTable();

        //Hiển thị các lô hàng
        public void LoadShipment()
        {
            date_ngaynhap.Value = DateTime.Today;
            try
            {
                dtShipment.Clear();
                DataSet ds = dbShipment.getShipment();
                dtShipment = ds.Tables[0];
                dgv_Shipment.DataSource = dtShipment;
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có lô hàng nào");
            }
        }

        string id_shipment;
        //Hiển thị chi tiết các mặt hàng trong mỗi lô hàng
        public void LoadDetailShipment()
        {
            try
            {
                dtDetailShipment.Clear();
                DataSet ds = dbShipment.getDetailShipment(id_shipment);
                dtDetailShipment = ds.Tables[0];
                dgv_DetailShipment.DataSource = dtDetailShipment;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không có mặt hàng nào");
            }
        }      

        //Thêm lô hàng mới
        private void ThemLoHang()
        {
            string prefixIDShipment = dbShipment.CreateAutoShipmentID();
            try
            {
                //truyền dữ liệu vào hàm thêm lô hàng
                dbShipment.addShipment(prefixIDShipment.Trim(), txt_maNCC.Text.Trim(), Convert.ToDateTime(date_ngaynhap.Value));
                LoadShipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Xóa lô hàng
        private void XoaLoHang()
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa sản phẩm?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbShipment.deleteShipment(id_shipment);
                    // Cập nhật lại bảng lô hàng và chi tiết lô hàng 
                    LoadShipment();
                    LoadDetailShipment();
                    // Thông báo 
                    MessageBox.Show("Đã xóa xong!");

                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa lô hàng!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void LamMoi()
        {
            pnl_ThemLoHang.Visible = false;
            txt_maNCC.Text = "";
        }

        private void us_Shipment_Load(object sender, EventArgs e)
        {
            LoadShipment();
        }

        private void dgv_Shipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_Shipment.CurrentRow.Index;
            id_shipment = dgv_Shipment.Rows[i].Cells[4].Value.ToString();
            LoadDetailShipment();
        }

        private void btn_ThemLoHang_Click(object sender, EventArgs e)
        {
            pnl_ThemLoHang.Visible = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btn_XacNhanThem_Click(object sender, EventArgs e)
        {
            ThemLoHang();
            LamMoi();
        }

        private void btn_XoaLoHang_Click(object sender, EventArgs e)
        {
            XoaLoHang();
        }

        private void btn_NhapKho_Click(object sender, EventArgs e)
        {
            us_ImportProduct us_ImportProduct = new us_ImportProduct(pnl_trangchinh, id_shipment);
            TienIch.addUserControl(us_ImportProduct, pnl_trangchinh);
        }
    }
}
