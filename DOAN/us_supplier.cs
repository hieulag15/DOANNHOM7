using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class us_supplier : UserControl
    {
        public us_supplier()
        {
            InitializeComponent();
        }
        Supplier dbSupplier = new Supplier();
        DataTable dtSupplier = new DataTable();
        private void us_supplier_Load(object sender, EventArgs e)
        {
            loadSupplier();
        }
        public void loadSupplier()
        {
            try
            {
                dtSupplier.Clear(); //clear datatable
                DataSet ds = dbSupplier.getSupplier();
                dtSupplier = ds.Tables[0];
                dgv_supplier.DataSource = dtSupplier;

            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa có nhà cung cấp nào");
            }
        }

        private void btn_themMoi_Click(object sender, EventArgs e)
        {
            string s_id = dbSupplier.CreateAutoID();

            if (dbSupplier.addSupplier(s_id, txt_tenSupplier.Text.Trim(), txt_SDTSupplier.Text.Trim(), txt_diaChiSupplier.Text.Trim()))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp không thành công");
            }
            loadSupplier();
        }


    }
}
