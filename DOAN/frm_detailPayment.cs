using DOAN.BTN_CONTROLS;
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
                DataRow dr = dbBill.getBillBasic(idBill);
                lbl_TenNhanVien.Text = dr[0].ToString();
                lbl_TenKhachHang.Text = dr[1].ToString();
                DateTime ngaylap = (DateTime)dr[2];
                lbl_NgayLap.Text = ngaylap.ToString("dd/MM/yyyy");
                lbl_MaHoaDon.Text = dr[3].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có hóa đơn nào");
            }
        }


    }
}
