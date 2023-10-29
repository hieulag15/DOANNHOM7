﻿using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_AddProduct : UserControl
    {
        public us_AddProduct()
        {
            InitializeComponent();
        }

        private Panel pnl_trangchinh;
        public us_AddProduct(Panel pnl_trangchinh)
        {
            InitializeComponent();
            this.pnl_trangchinh = pnl_trangchinh;
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            frm_ListProduct frm_Mathang = new frm_ListProduct(pnl_trangchinh);
            TienIch.addForm(frm_Mathang, pnl_trangchinh);
        }

        private void btn_TaiAnhLen_Click(object sender, EventArgs e)
        {
            TaiAnh();
        }

        private void btn_XacNhanThem_Click(object sender, EventArgs e)
        {
            ThemMatHang();
        }

        //Xử lý

        string imgLoc = "";

        //Tải ảnh mặt hàng lên
        private void TaiAnh()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                //Danh sách đuôi hình có thể upload
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.* |PNG Files (*.png)|*.png";
                dlg.Title = "Select Product Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pic_AnhMatHang.ImageLocation = imgLoc; //Chọn đường dẫn file hình để upload
                    pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Product dbProduct = new Product();

        //Thêm mặt hàng mới
        private void ThemMatHang()
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read); // Tạo file stream liên kết với ảnh đã chọn
                img = new byte[fs.Length]; //Tạo một mảng byte với kích thước của file stream
                fs.Read(img, 0, Convert.ToInt32(fs.Length)); //Đọc luồng tệp đã chọn vào mảng byte
                dbProduct.addProduct(txt_mamathang.Text.Trim(), txt_tenmathang.Text.Trim(), (decimal)Convert.ToDouble(txt_giaban.Text.Trim()),
                    img, cb_kichthuoc.Text.Trim(), (int)Convert.ToInt64(num_soluong.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
