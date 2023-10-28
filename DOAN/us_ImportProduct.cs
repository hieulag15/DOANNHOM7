using DOAN.DS;
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
    public partial class us_ImportProduct : UserControl
    {
        Panel pnl_trangchinh;
        string id_product;
        public us_ImportProduct()
        {
            InitializeComponent();
        }

        public us_ImportProduct(string id_product, Panel pnl_trangchinh)
        {
            InitializeComponent();
            this.id_product = id_product;
            this.pnl_trangchinh = pnl_trangchinh;
        }

        Product dbProduct = new Product();

        private void us_ImportProduct_Load(object sender, EventArgs e)
        {
            txt_mamathang.Text = id_product;

            DataSet pro = dbProduct.getOneProduct(id_product);
            DataRow dr = pro.Tables[0].Rows[0];

            pic_AnhMatHang.Image = TienIch.ConvertByteArraytoImage((byte[])dr[3]);
            pic_AnhMatHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        Shipment dbshipment= new Shipment();

        private void btn_XacNhanNhap_Click(object sender, EventArgs e)
        {
            try
            {
                dbshipment.addShipment(txt_malohang.Text.Trim(), txt_maNCC.Text.Trim(), txt_mamathang.Text.Trim(), Convert.ToDateTime(date_ngaynhap.Value), 
                    (decimal)Convert.ToDouble(txt_gianhap.Text.Trim()), (int)Convert.ToInt64(num_soluongmathang.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            frm_ListProduct Fmathang = new frm_ListProduct(this.pnl_trangchinh);
            TienIch.addForm(Fmathang, pnl_trangchinh);
        }
    }
}
