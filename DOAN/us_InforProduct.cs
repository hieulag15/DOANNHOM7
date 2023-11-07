using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_InforProduct : UserControl
    {
        public us_InforProduct()
        {
            InitializeComponent();
        }

        private Panel pnl_trangchinh;
        string id_product;
        public us_InforProduct(Panel pnl_trangchinh, string id_product)
        {
            InitializeComponent();
            this.pnl_trangchinh = pnl_trangchinh;
            this.id_product = id_product;
        }

        private void us_InforProduct_Load(object sender, EventArgs e)
        {
            LoadInforProduct();
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            frm_ListProduct frm_Mathang = new frm_ListProduct(pnl_trangchinh);
            TienIch.addForm(frm_Mathang, pnl_trangchinh);
        }

        private void btn_LuuThayDoi_Click(object sender, EventArgs e)
        {
            CapNhatMathang();
        }

        private void btn_ThayDoiAnh_Click(object sender, EventArgs e)
        {
            ThayDoiAnh();
        }

        //Xử lý

        DataTable dtProduct = new DataTable();
        Product dbProduct = new Product();
        byte[] img = null;

        //Hàm hiển thị thông tin sản phẩm
        public void LoadInforProduct()
        {
            try
            {
                DataRow dr = dbProduct.getOneProduct(id_product);
                txt_mamathang.Text = dr[0].ToString();
                txt_tenmathang.Text = dr[1].ToString();
                txt_giaban.Text = dr[2].ToString();
                cb_kichthuoc.Text = dr[4].ToString();
                num_soluong.Value = int.Parse(dr[5].ToString());
                txt_LoaiMatHang.Text = dbProduct.GetTypeProduct(id_product);
                img = (byte[])dr[3];
                pic_AnhMatHang.Image = TienIch.ConvertByteArraytoImage(img);
                pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            }
            catch (SqlException)
            {
                MessageBox.Show("Loi");
            }
        }

        //Thay đổi thông tin mặt hàng
        private void CapNhatMathang()
        {
            try
            {
                dbProduct.updateProduct(txt_mamathang.Text.Trim(), txt_tenmathang.Text.Trim(), (decimal)Convert.ToDouble(txt_giaban.Text.Trim()),
                    img, cb_kichthuoc.Text.Trim(), (int)Convert.ToInt64(num_soluong.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        string imgLoc = "";

        //Thay đổi ảnh mặt hàng
        private void ThayDoiAnh()
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
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                img = new byte[fs.Length];
                fs.Read(img, 0, Convert.ToInt32(fs.Length));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
