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
        public frm_mathang()
        {
            InitializeComponent();
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
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
