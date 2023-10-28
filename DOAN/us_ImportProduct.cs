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
        public us_ImportProduct()
        {
            InitializeComponent();
        }

        Shipment dbshipment= new Shipment();

        private void btn_XacNhanNhap_Click(object sender, EventArgs e)
        {
            try
            {
                dbshipment.addShipment(txt_malohang.Text.Trim(), txt_maNCC.Text.Trim(), txt_mamathang.Text.Trim(), (decimal)Convert.ToDouble(txt_gianhap.Text.Trim()),
                    Convert.ToDateTime(date_ngaynhap.Value), (int)Convert.ToInt64(num_soluonglo.Text.Trim()),  (int)Convert.ToInt64(num_soluongmathang.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
