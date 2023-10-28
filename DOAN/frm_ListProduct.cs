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
        string id_product;
        private Panel pnl_trangchinh;
        public frm_ListProduct()
        {
            InitializeComponent();
        }

        public frm_ListProduct(Panel pnl_trangchinh)
        {
            InitializeComponent();
            this.pnl_trangchinh= pnl_trangchinh;
        }

        DataTable dtProduct = new DataTable();
        Product dbProduct = new Product();


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

        private void frm_mathang_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btn_XemChiTiet_Click(object sender, EventArgs e)
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
            txt_timkiem.Text = id_product.ToString();

            DataSet pro = dbProduct.getOneProduct(id_product);
            DataRow dr = pro.Tables[0].Rows[0];

            pic_AnhMatHang.Image =  TienIch.ConvertByteArraytoImage((byte[])dr[3]);
            pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void btn_NhapKho_Click(object sender, EventArgs e)
        {
            us_ImportProduct us_ImportProduct = new us_ImportProduct(id_product, pnl_trangchinh);
            TienIch.addUserControl(us_ImportProduct, pnl_trangchinh);
        }
    }
}
