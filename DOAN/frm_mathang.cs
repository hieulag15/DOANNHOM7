using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class frm_mathang : Form
    {
        string id_product;
        private Panel pnl_trangchinh;
        public frm_mathang()
        {
            InitializeComponent();
        }

        public frm_mathang(Panel pnl_trangchinh)
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
                dgv_Product.DataSource = dtProduct;
            }
            catch (SqlException)
            {
                MessageBox.Show("Loi");
            }
        }

        private void frm_mathang_Load(object sender, EventArgs e)
        {
            LoadProduct();
            id_product = dgv_Product.Rows[0].Cells[0].Value.ToString();
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
                frm_mathang Fmathang = new frm_mathang(this.pnl_trangchinh);
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
        }
    }
}
