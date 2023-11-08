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
    public partial class frm_detailPayment : Form
    {
        public frm_detailPayment()
        {
            InitializeComponent();
        }

        string idBill;
        public frm_detailPayment(string idBill)
        {
            InitializeComponent();
            this.idBill = idBill;
        }

        DataTable dtDetailBill = new DataTable();
        Bill dbBill = new Bill();
        private void frm_detailPayment_Load(object sender, EventArgs e)
        {
            try
            {
                dtDetailBill.Clear();
                DataSet ds = dbBill.getDetailBill(idBill);
                dtDetailBill = ds.Tables[0];
                dgv_DetailBill.DataSource = dtDetailBill;

            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có hóa đơn nào");
            }
        }


    }
}
