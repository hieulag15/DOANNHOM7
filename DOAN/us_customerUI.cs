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
        DataTable dtCustomerNoActive = new DataTable();
        Customer dbCustomer = new Customer();

        public void LoadCustomer()
        {
            dtCustomer.Clear();
            DataSet ds = dbCustomer.getCustomer();
            dtCustomer = ds.Tables[0];
            dgv_DanhSachHD.DataSource = dtCustomer;
            setDataGridView();
        }

        public void LoadCustomerNoActive()
        {
            dtCustomerNoActive.Clear();
            DataSet ds = dbCustomer.getCustomerNoActive();
            dtCustomerNoActive = ds.Tables[0];
            dgv_DanhSachKHD.DataSource = dtCustomerNoActive;
            setDataGridView2();
        }

        private void us_customerUI_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadCustomerNoActive();
        }
        private void setDataGridView()
        {
            if (dgv_DanhSachHD != null)
            {
                //Set Header Text cho dtgv
                dgv_DanhSachHD.Columns[0].HeaderText = "Số điện thoại";
                dgv_DanhSachHD.Columns[1].HeaderText = "Tên";
                dgv_DanhSachHD.Columns[2].HeaderText = "Điểm";

                //Set chiều rộng cột
                int width = dgv_DanhSachHD.Width;
                int n_column = dgv_DanhSachHD.ColumnCount;
                dgv_DanhSachHD.Columns[0].Width -= width / n_column;
                dgv_DanhSachHD.Columns[1].Width -= width / n_column;
                dgv_DanhSachHD.Columns[2].Width -= width / n_column;
                dgv_DanhSachHD.AutoResizeColumns();
            }
        }
        private void setDataGridViewTimKiem()
        {
            if (dgv_TimKiem != null)
            {
                //Set Header Text cho dtgv
                dgv_TimKiem.Columns[0].HeaderText = "Số điện thoại";
                dgv_TimKiem.Columns[1].HeaderText = "Tên";
                dgv_TimKiem.Columns[2].HeaderText = "Điểm";
                dgv_TimKiem.Columns[3].HeaderText = "Hoạt động";
                //Set chiều rộng cột
                int width = dgv_DanhSachHD.Width;
                int n_column = dgv_DanhSachHD.ColumnCount;
                dgv_TimKiem.Columns[0].Width -= width / n_column;
                dgv_TimKiem.Columns[1].Width -= width / n_column;
                dgv_TimKiem.Columns[2].Width -= width / n_column;
                dgv_TimKiem.Columns[3].Width -= width / n_column;
                dgv_TimKiem.AutoResizeColumns();
            }
        }
        private void setDataGridView2()
        {
            if (dgv_DanhSachKHD != null)
            {
                //Set Header Text cho dtgv
                dgv_DanhSachKHD.Columns[0].HeaderText = "Số điện thoại";
                dgv_DanhSachKHD.Columns[1].HeaderText = "Tên";
                dgv_DanhSachKHD.Columns[2].HeaderText = "Điểm";
                //Set chiều rộng cột
                int width = dgv_DanhSachKHD.Width;
                int n_column = dgv_DanhSachKHD.ColumnCount;
                dgv_DanhSachKHD.Columns[0].Width -= width / n_column;
                dgv_DanhSachKHD.Columns[1].Width -= width / n_column;
                dgv_DanhSachKHD.Columns[2].Width -= width / n_column;
                dgv_DanhSachKHD.AutoResizeColumns();
            }
        }
        private void Refresh()
        {
            txt_SoDienThoai.Text = "";
            txt_TenKhachHang.Text = "";
            txt_DiemTichLuy.Text = "";
            rb_HD.Checked = false;
            rb_KhongHD.Checked = false;
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            Refresh();
            dgv_DanhSachKHD.Visible = true;
            dgv_DanhSachHD.Visible = true;
            dgv_TimKiem.Visible = false;
            lbl_HD.Visible = true;
            lbl_TimKiem.Visible = false;
            txt_TimKhachHang.Text = "";
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (txt_SoDienThoai.Text == "" || txt_TenKhachHang.Text == "" || txt_DiemTichLuy.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (dbCustomer.addCustomer(txt_SoDienThoai.Text.Trim(), txt_TenKhachHang.Text.Trim(), 
                    //Lấy giá trị điểm trong Textbox, nếu textbox không có dữ liệu thì cho nó bằng 0
                    txt_DiemTichLuy.Text.Trim() != null ? (int)Convert.ToDecimal(txt_DiemTichLuy.Text.Trim()) : 0) == true)
                {

                    MessageBox.Show("Thêm khách hàng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng không thành công");
                }
                LoadCustomer();
                LoadCustomerNoActive();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (txt_SoDienThoai.Text == "" || txt_TenKhachHang.Text == "" || txt_DiemTichLuy.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool check = rb_HD.Checked ? true : false;
            try
            {
                dbCustomer.updateCustomer(
                    txt_SoDienThoai.Text.Trim(),
                    txt_TenKhachHang.Text.Trim(),
                    //Lấy giá trị điểm trong Textbox, nếu textbox không có dữ liệu thì cho nó bằng 0
                    txt_DiemTichLuy.Text.Trim() != null ? (int)Convert.ToDecimal(txt_DiemTichLuy.Text.Trim()) : 0, check);

                MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                LoadCustomer();
                LoadCustomerNoActive();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_SoDienThoai.Text == "" || txt_SoDienThoai.Text == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    LoadCustomerNoActive();
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
            if (txt_TimKhachHang.Text != "" && txt_TimKhachHang.Text != null)
            {
                try
                {
                    DataSet ds = dbCustomer.findCustomer(txt_TimKhachHang.Text.Trim());
                    
                    dgv_DanhSachKHD.Visible = false;
                    dgv_DanhSachHD.Visible = false;
                    lbl_HD.Visible = false;
                    lbl_TimKiem.Visible = true;
                    dgv_TimKiem.Visible = true;
                    MessageBox.Show("Tìm thông tin khách hàng thành công");
                    dtCustomer = ds.Tables[0];
                    
                    dgv_TimKiem.DataSource = dtCustomer;

                    // Thực hiện các cài đặt DataGridView (nếu cần)
                    setDataGridViewTimKiem();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgv_DanhSachHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txt_SoDienThoai.Text = dgv_DanhSachHD.Rows[numrow].Cells[0].Value.ToString();
                txt_TenKhachHang.Text = dgv_DanhSachHD.Rows[numrow].Cells[1].Value.ToString();
                txt_DiemTichLuy.Text = dgv_DanhSachHD.Rows[numrow].Cells[2].Value.ToString();
                rb_HD.Checked = true;
            }
        }

        private void dgv_DanhSachKHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txt_SoDienThoai.Text = dgv_DanhSachKHD.Rows[numrow].Cells[0].Value.ToString();
                txt_TenKhachHang.Text = dgv_DanhSachKHD.Rows[numrow].Cells[1].Value.ToString();
                txt_DiemTichLuy.Text = dgv_DanhSachKHD.Rows[numrow].Cells[2].Value.ToString();
                rb_KhongHD.Checked = true;
            }
        }

        private void dgv_TimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txt_SoDienThoai.Text = dgv_TimKiem.Rows[numrow].Cells[0].Value.ToString();
                txt_TenKhachHang.Text = dgv_TimKiem.Rows[numrow].Cells[1].Value.ToString();
                txt_DiemTichLuy.Text = dgv_TimKiem.Rows[numrow].Cells[2].Value.ToString();
                rb_HD.Checked = Convert.ToInt32(dgv_TimKiem.Rows[numrow].Cells[3].Value) == 1 ? true : false;
                rb_KhongHD.Checked = !rb_HD.Checked;
            }
        }
    }
}
