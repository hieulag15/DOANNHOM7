using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN.BTN_CONTROLS
{
    public partial class us_Product : UserControl
    {
        public us_Product()
        {
            InitializeComponent();
        }

        public string ItemPrice
        {
            get { return lbl_giaTien.Text; }
            set { lbl_giaTien.Text = value; }
        }

        public Image ItemImage
        {
            get { return ptb_anhSanPham.Image; }
            set { ptb_anhSanPham.Image = value; }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
