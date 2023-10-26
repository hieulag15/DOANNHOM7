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
    public partial class us_InforProduct : UserControl
    {
        private Panel pnl_trangchinh;
        public us_InforProduct()
        {
            InitializeComponent();
        }

        public us_InforProduct(Panel pnl_trangchinh)
        {
            InitializeComponent();
            this.pnl_trangchinh = pnl_trangchinh;
        }
    }
}
