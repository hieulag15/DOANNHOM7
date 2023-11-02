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
    public partial class us_Product_Pay : UserControl
    {
        public string ItemPrice
        {
            get { return lbl_giaTien.Text; }
            set { lbl_giaTien.Text = value; }
        }

        public string ItemID
        {
            get { return lbl_maSP.Text; }
            set { lbl_maSP.Text = value; }
        }

        public string ItemQuantity
        {
            get { return lbl_soLuong.Text; }
            set { lbl_soLuong.Text = value; }
        }

        public us_Product_Pay()
        {
            InitializeComponent();
        }
    }
}
