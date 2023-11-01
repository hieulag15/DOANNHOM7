using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_Sell : UserControl
    {
        Product product = new Product();
        public us_Sell()
        {
            InitializeComponent();
        }

        private void us_Sell_Load(object sender, EventArgs e)
        {
            Panel_Product.Controls.Clear();
            product.getProductList(Panel_Product);
        }
    }
}
