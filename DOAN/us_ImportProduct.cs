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
    public partial class us_ImportProduct : UserControl
    {
        public us_ImportProduct()
        {
            InitializeComponent();
        }

        Panel pnl_trangchinh;
        string id_shipment;
        string id_ncc;
        public us_ImportProduct(Panel pnl_trangchinh, string id_shipment, string id_ncc)
        {
            InitializeComponent();
            this.pnl_trangchinh = pnl_trangchinh;
            this.id_shipment= id_shipment;
            this.id_ncc= id_ncc;
        }

        private void us_ImportProduct_Load(object sender, EventArgs e)
        {
            LoadImportProduct();
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            us_Shipment us_Shipment = new us_Shipment(pnl_trangchinh);
            TienIch.addUserControl(us_Shipment, pnl_trangchinh);
        }

        private void btn_XacNhanThem_Click(object sender, EventArgs e)
        {
            ThemChiTietLoHang();
            LoadProduct();
        }

        string id_product;
        private void dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_Product.CurrentRow.Index;
            id_product = dgv_Product.Rows[i].Cells[0].Value.ToString();

            txt_mamathang.Text = id_product;

            pic_AnhMatHang.Image = TienIch.ConvertByteArraytoImage((byte[])dgv_Product.Rows[i].Cells[3].Value);
            pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void pic_TimMatHang_Click(object sender, EventArgs e)
        {
            dtProduct = new DataTable();
            dtProduct.Clear();
            dtProduct = dbProduct.FindProduct(txt_timten.Text).Tables[0];
            dgv_Product.DataSource = dtProduct;

            dgv_Product.Columns[3].Visible = false;
        }

        //Xử lý

        DataTable dtProduct = new DataTable();
        Product dbProduct = new Product();

        //Hiển thị thông tin lô hàng và nhà cung cấp
        private void LoadImportProduct()
        {
            txt_malohang.Text = id_shipment;
            txt_maNCC.Text = id_ncc;
            LoadProduct();
        }

        private void LoadProduct()
        {
            try
            {
                dtProduct.Clear();
                DataSet ds = dbProduct.getProduct();
                dtProduct = ds.Tables[0];

                if (dtProduct.Rows.Count > 0)
                {
                    dgv_Product.DataSource = dtProduct;
                    dgv_Product.Columns[3].Visible = false;
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

        Shipment dbShipment = new Shipment();

        //Thêm thông tin chi tiết lô hàng mới
        private void ThemChiTietLoHang()
        {
            try
            {
                dbShipment.addDetailShipment(txt_malohang.Text.Trim(), txt_mamathang.Text.Trim(),
                    (decimal)Convert.ToDouble(txt_gianhap.Text.Trim()), (int)Convert.ToInt64(num_soluongmathang.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LamMoi()
        {
            txt_mamathang.Text = "";
            txt_gianhap.Text = "";
            num_soluongmathang.Value = 0;
            date_ngaynhap.Value = DateTime.Now;
        }

        private void TimMatHang()
        {
            dtProduct = new DataTable();
            dtProduct.Clear();
            dtProduct = dbProduct.FindProduct(txt_timten.Text).Tables[0];
            dgv_Product.DataSource = dtProduct;

            dgv_Product.Columns[3].Visible = false;
        }
    }
}
