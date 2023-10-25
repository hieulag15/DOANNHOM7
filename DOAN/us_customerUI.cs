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
    public partial class us_customerUI : UserControl
    {
        public us_customerUI()
        {
            InitializeComponent();
        }

        DataTable dtCustomer = new DataTable();
        Customer dbCustomer = new Customer();

        public void LoadCustomer()
        {
            dtCustomer.Clear();
            DataSet ds = dbCustomer.getCustomer();
            dtCustomer = ds.Tables[0];
            dgv_Customer.DataSource = dtCustomer;
        }

        private void us_customerUI_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
