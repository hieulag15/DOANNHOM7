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
            btn_LamMoi_Click(sender, e);
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
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_tenSupplier.Text = "";
            txt_SDTSupplier.Text = "";
            txt_diaChiSupplier.Text = "";
            btn_themMoi.Enabled = true;
            btn_capNhat.Enabled = false;
        }
        private void btn_themMoi_Click(object sender, EventArgs e)
        {
            string auto_id = dbSupplier.CreateAutoID(); //s_id duoc tao tu dong
            if (checkTxt())
            {
                if (dbSupplier.addSupplier(auto_id, txt_tenSupplier.Text.Trim(), txt_SDTSupplier.Text.Trim(), txt_diaChiSupplier.Text.Trim()))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công");
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp không thành công");
                }
                loadSupplier();
            }
            else
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
            } 
                
        }
        public bool checkTxt()
        {
            if (txt_tenSupplier.Text.Trim() != ""
                && txt_diaChiSupplier.Text.Trim() != ""
                && txt_SDTSupplier.Text.Trim() != "")
            {
                return true; 
            }
            else return false; //if textbox = ""
        }
        private void btn_chinhSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgv_supplier.CurrentRow;
            //string s_id = (string)currentRow.Cells[0].Value; //s_id
            txt_tenSupplier.Text= (string)currentRow.Cells[1].Value;
            txt_SDTSupplier.Text = (string)currentRow.Cells[2].Value;
            txt_diaChiSupplier.Text= (String)currentRow.Cells[3].Value;
            btn_themMoi.Enabled = false;
            btn_capNhat.Enabled = true;
        }
        private void btn_capNhat_Click(object sender, EventArgs e)
        {

            DataGridViewRow currentRow = dgv_supplier.CurrentRow;
            string currentRow_id = (string)currentRow.Cells[0].Value; //lay s_id tu datagridview
            if (checkTxt())
            {
                if (dbSupplier.updateSupplier(currentRow_id, txt_tenSupplier.Text.Trim(), txt_SDTSupplier.Text.Trim(), txt_diaChiSupplier.Text.Trim()))
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
                loadSupplier();
                btn_LamMoi_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgv_supplier.CurrentRow;
            string currentRow_id = (string)currentRow.Cells[0].Value; //lay s_id tu datagridview
            //Hỏi người dùng là có chắc chắn muốn xóa khách hàng không
            DialogResult respone = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp có ID" +currentRow_id, "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //Nếu đồng ý
            if (respone == DialogResult.Yes)
            {
                if (dbSupplier.deleteSupplier(currentRow_id))
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            loadSupplier();
            btn_LamMoi_Click(sender, e);
        }
    }
}
