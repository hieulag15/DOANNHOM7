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
    public partial class us_employeeUI : UserControl
    {
        public us_employeeUI()
        {
            InitializeComponent();
        }
        DataTable dtEmployee = new DataTable();
        Employee dbEmployee = new Employee();

        public void LoadEmployee()
        {
            dtEmployee.Clear();
            DataSet ds = dbEmployee.getEmployee(); // Lấy dữ liệu Employee đưa vào Dataset
            dtEmployee = ds.Tables[0];
            dgv_Employee.DataSource = dtEmployee;
            setDataGridView();
        }

        private void setDataGridView()
        {
            if (dgv_Employee != null)
            {
                //Set Header Text cho dtgv
                dgv_Employee.Columns[0].HeaderText = "ID";
                dgv_Employee.Columns[1].HeaderText = "Tên";
                dgv_Employee.Columns[2].HeaderText = "Địa chỉ";
                dgv_Employee.Columns[3].HeaderText = "Số điện thoại";
                dgv_Employee.Columns[4].HeaderText = "Giới tính";
                
                //Set chiều rộng cột
                int width = dgv_Employee.Width;
                int n_column = dgv_Employee.ColumnCount;
                dgv_Employee.Columns[0].Width -= width / n_column;
                dgv_Employee.Columns[1].Width -= width / n_column;
                dgv_Employee.Columns[2].Width -= width / n_column;
                dgv_Employee.Columns[3].Width -= width / n_column;
                dgv_Employee.Columns[4].Width -= width / n_column;
                dgv_Employee.AutoResizeColumns();
            }
        }

        private void us_employeeUI_Load(object sender, EventArgs e)
        {
            LoadEmployee();
        }

        private void dgv_Employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txt_MaNhanVien.Text = dgv_Employee.Rows[numrow].Cells[0].Value.ToString();
                txt_TenNhanVien.Text = dgv_Employee.Rows[numrow].Cells[1].Value.ToString();
                txt_DiaChi.Text = dgv_Employee.Rows[numrow].Cells[2].Value.ToString();
                txt_SoDienThoai.Text = dgv_Employee.Rows[numrow].Cells[3].Value.ToString();
                rb_Nam.Checked = dgv_Employee.Rows[numrow].Cells[4].Value.ToString() == "Nam" ? true : false;
                rb_Nu.Checked = !rb_Nam.Checked;
            }
        }
        private void Refresh()
        {
            txt_SoDienThoai.Text = "";
            txt_MaNhanVien.Text = "";
            txt_TenNhanVien.Text = "";
            txt_DiaChi.Text = "";
            rb_Nam.Checked = false;
            rb_Nu.Checked = false;
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
            string gender = "";
            if (rb_Nam.Checked)
                gender = rb_Nam.Text;
            else
                gender = rb_Nu.Text;
            DataSet ds = new DataSet();
            ds = dbEmployee.findEmployee(txt_MaNhanVien.Text);
            if (ds != null)
            {
                dbEmployee.updateEmployee(txt_MaNhanVien.Text.Trim(), txt_TenNhanVien.Text.Trim(), txt_DiaChi.Text.Trim(), txt_SoDienThoai.Text.Trim(), gender);
            }
            else
            {
                try
                {
                    if (dbEmployee.addEmployee(txt_MaNhanVien.Text.Trim(), txt_TenNhanVien.Text.Trim(), txt_DiaChi.Text.Trim(), txt_SoDienThoai.Text.Trim(), gender) == true)
                    {
                        MessageBox.Show("Thêm nhân viên thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công");
                    }
                    LoadEmployee();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "";
                if (rb_Nam.Checked)
                    gender = rb_Nam.Text;
                else
                    gender = "Nu";
                dbEmployee.updateEmployee(txt_MaNhanVien.Text.Trim(), txt_TenNhanVien.Text.Trim(), txt_DiaChi.Text.Trim(), txt_SoDienThoai.Text.Trim(), gender);

                MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                LoadEmployee();
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
                    dbEmployee.deleteEmployee(txt_MaNhanVien.Text);
                    MessageBox.Show("Xóa thông tin khách hàng thành công");
                    LoadEmployee();
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
