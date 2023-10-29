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
    public partial class frm_ListProduct : Form
    {
        public frm_ListProduct()
        {
            InitializeComponent();
        }

        private Panel pnl_trangchinh;
        public frm_ListProduct(Panel pnl_trangchinh)
        {
            InitializeComponent();
            this.pnl_trangchinh= pnl_trangchinh;
        }

        private void frm_mathang_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btn_XemChiTiet_Click(object sender, EventArgs e)
        {
            XemChiTiet();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            us_AddProduct us_AddProduct = new us_AddProduct(pnl_trangchinh);
            TienIch.addUserControl(us_AddProduct, pnl_trangchinh);
        }

        private void dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_Product.CurrentRow.Index;
            id_product = dgv_Product.Rows[i].Cells[0].Value.ToString();

            DataSet pro = dbProduct.getOneProduct(id_product);
            DataRow dr = pro.Tables[0].Rows[0];

            pic_AnhMatHang.Image =  TienIch.ConvertByteArraytoImage((byte[])dr[3]);
            pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            XoaMatHang();
        }


        //Xử lý
 
        DataTable dtProduct = new DataTable();
        Product dbProduct = new Product();
        string id_product;

        public void LoadProduct()
        {
            try
            {
                dtProduct.Clear();
                DataSet ds = dbProduct.getProduct();
                dtProduct = ds.Tables[0];

                if (dtProduct.Rows.Count > 0)
                {
                    dgv_Product.DataSource = dtProduct;
                    id_product = dgv_Product.Rows[0].Cells[0].Value.ToString();

                    DataSet pro = dbProduct.getOneProduct(id_product);
                    DataRow dr = pro.Tables[0].Rows[0];

                    pic_AnhMatHang.Image = TienIch.ConvertByteArraytoImage((byte[])dr[3]);
                    pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Chưa có mặt hàng nào");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có mặt hàng nào");
            }
        }

        //Mở form xem chi tiết thông tin mặt hàng
        private void XemChiTiet()
        {
            try
            {
                us_InforProduct us_InforProduct = new us_InforProduct(pnl_trangchinh, id_product);
                TienIch.addUserControl(us_InforProduct, pnl_trangchinh);
            }
            catch
            {
                frm_ListProduct Fmathang = new frm_ListProduct(this.pnl_trangchinh);
                TienIch.addForm(Fmathang, pnl_trangchinh);
                MessageBox.Show("Chưa thêm đủ thông tin về Nhà sản xuất hoặc Lô hàng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void XoaMatHang()
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa sản phẩm?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbProduct.deleteProduct(id_product);
                    // Cập nhật lại DataGridView 
                    LoadProduct();
                    // Thông báo 
                    MessageBox.Show("Đã xóa xong!");

                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }
    }
}
