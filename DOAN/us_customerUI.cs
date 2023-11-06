using DOAN.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            setDataGridView();
        }

        private void us_customerUI_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }
        private void setDataGridView()
        {
            if (dgv_Customer != null)
            {
                //Set Header Text cho dtgv
                dgv_Customer.Columns[0].HeaderText = "Số điện thoại";
                dgv_Customer.Columns[1].HeaderText = "Tên";
                dgv_Customer.Columns[2].HeaderText = "Điểm";

                //Set chiều rộng cột
                int width = dgv_Customer.Width;
                int n_column = dgv_Customer.ColumnCount;
                dgv_Customer.Columns[0].Width -= width / n_column;
                dgv_Customer.Columns[1].Width -= width / n_column;
                dgv_Customer.Columns[2].Width -= width / n_column;
                dgv_Customer.AutoResizeColumns();
            }
        }

        private void dgv_Customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txt_SoDienThoai.Text = dgv_Customer.Rows[numrow].Cells[0].Value.ToString();
                txt_TenKhachHang.Text = dgv_Customer.Rows[numrow].Cells[1].Value.ToString();
                txt_DiemTichLuy.Text = dgv_Customer.Rows[numrow].Cells[2].Value.ToString();
                rb_HD.Checked = true;
            }
        }
        private void Refresh()
        {
            txt_SoDienThoai.Text = "";
            txt_TenKhachHang.Text = "";
            txt_DiemTichLuy.Text = "";
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (dbCustomer.addCustomer(txt_SoDienThoai.Text.Trim(), txt_TenKhachHang.Text.Trim(), 
                    //Lấy giá trị điểm trong Textbox, nếu textbox không có dữ liệu thì cho nó bằng 0
                    txt_DiemTichLuy.Text.Trim() != null ? (int)Convert.ToDecimal(txt_DiemTichLuy.Text.Trim()) : 0
                    ) == true)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng không thành công");
                }
                LoadCustomer();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                dbCustomer.updateCustomer(
                    txt_SoDienThoai.Text.Trim(),
                    txt_TenKhachHang.Text.Trim(),
                    //Lấy giá trị điểm trong Textbox, nếu textbox không có dữ liệu thì cho nó bằng 0
                    txt_DiemTichLuy.Text.Trim() != null ? (int)Convert.ToDecimal(txt_DiemTichLuy.Text.Trim()) : 0);

                MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                LoadCustomer();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            //Hỏi người dùng là có chắc chắn muốn xóa khách hàng không
            DialogResult respone = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //Nếu đồng ý
            if (respone == DialogResult.Yes)
            {
                try
                {
                    dbCustomer.deleteCustomer(txt_SoDienThoai.Text);
                    MessageBox.Show("Xóa thông tin khách hàng thành công");
                    LoadCustomer();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Refresh();
                return;
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
