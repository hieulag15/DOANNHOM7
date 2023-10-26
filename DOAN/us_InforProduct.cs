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
    public partial class us_InforProduct : UserControl
    {
        private Panel pnl_trangchinh;
        string id_product;
        public us_InforProduct()
        {
            InitializeComponent();
        }

        public us_InforProduct(Panel pnl_trangchinh, string id_product)
        {
            InitializeComponent();
            this.pnl_trangchinh = pnl_trangchinh;
            this.id_product = id_product;
        }

        private void us_InforProduct_Load(object sender, EventArgs e)
        {
            LoadDetailProduct();
        }

        DataTable dtProduct = new DataTable();
        Product dbProduct = new Product();

        public void LoadDetailProduct()
        {
            try
            {
                dtProduct.Clear();
                DataSet ds = dbProduct.getDetailProduct(id_product);
                DataRow dr = ds.Tables[0].Rows[0];
                txt_mamathang.Text = dr[0].ToString();
                txt_tenmathang.Text = dr[1].ToString();
                txt_giaban.Text = dr[2].ToString();
                txt_kichthuoc.Text = dr[4].ToString();
                guna2NumericUpDown1.Value = int.Parse(dr[5].ToString());
                txt_maNCC.Text = dr[6].ToString();
                txt_tenNCC.Text = dr[7].ToString();
                txt_malohang.Text = dr[8].ToString();
                txt_gianhap.Text = dr[9].ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Loi");
            }
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            frm_mathang frm_Mathang = new frm_mathang(pnl_trangchinh);
            TienIch.addForm(frm_Mathang, pnl_trangchinh);
        }
    }
}
