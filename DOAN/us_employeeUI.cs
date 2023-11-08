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

        bool addFlag;
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
        void not_fillingStatus()
        {
            txt_SoDienThoai.Enabled = false;
            txt_MaNhanVien.Enabled = false;
            txt_TenNhanVien.Enabled = false;
            txt_DiaChi.Enabled = false;
            rb_Nam.Enabled = false;
            rb_Nu.Enabled = false;
        }
        void fillingStatus()
        {
            txt_SoDienThoai.Enabled = true;
            txt_MaNhanVien.Enabled = true;
            txt_TenNhanVien.Enabled = true;
            txt_DiaChi.Enabled = true;
            rb_Nam.Enabled = true;
            rb_Nu.Enabled = true;
        }
        void initial_Status()
        {
            not_fillingStatus();
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
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
            initial_Status();
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
            LoadEmployee();
            txt_TimTheoMaNV.Text = "Theo mã nhân viên";
            txt_TimTheoTen.Text = "Theo tên nhân viên";
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Refresh();
            initial_Status();
            addFlag = false;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            addFlag = true;
            btn_Them.Enabled = false;
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;
            btn_Sua.Enabled = false;

            //Mở các ô cho phép điền thông tin\
            fillingStatus();
            Refresh();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Trường hợp khi người dùng chưa chọn nhan vien cần sửa thông tin
            if (txt_MaNhanVien.Text == "" || txt_MaNhanVien.Text == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chỉnh sửa thông tin", "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            btn_Them.Enabled = false;
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;
            btn_Sua.Enabled = true;

            //Mở các ô cho phép điền thông tin\
            fillingStatus();
            txt_MaNhanVien.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_MaNhanVien.Text == "" || txt_MaNhanVien.Text == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Hỏi người dùng là có chắc chắn muốn xóa khách hàng không
            DialogResult respone = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //Nếu đồng ý
            if (respone == DialogResult.Yes)
            {
                try
                {
                    dbEmployee.deleteEmployee(txt_MaNhanVien.Text);
                    LoadEmployee();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Refresh();
                }
            }
            else
            {
                Refresh();
                return;
            }
            initial_Status();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (addFlag == true) //Trường hợp thêm nhan vien
            {
                string gender = "";
                if (rb_Nam.Checked)
                    gender = rb_Nam.Text;
                if (rb_Nu.Checked)
                    gender = rb_Nu.Text;
                DataSet ds = new DataSet();
                try
                {
                    dbEmployee.addEmployee(txt_MaNhanVien.Text.Trim(), txt_TenNhanVien.Text.Trim(),
                        txt_DiaChi.Text.Trim(), txt_SoDienThoai.Text.Trim(), gender);
                    LoadEmployee();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Refresh();
                }
                addFlag = false;
            }
            else //Trường hợp người dùng nhấn update
            {
                try
                {
                    string gender = "";
                    if (rb_Nam.Checked)
                        gender = rb_Nam.Text;
                    else
                        gender = "Nu";
                    dbEmployee.updateEmployee(txt_MaNhanVien.Text.Trim(), txt_TenNhanVien.Text.Trim(), 
                        txt_DiaChi.Text.Trim(), txt_SoDienThoai.Text.Trim(), gender);
                    LoadEmployee();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Refresh();
                }
            }
            initial_Status();
        }

        private void txt_TimTheoMaNV_Enter(object sender, EventArgs e)
        {
            if (txt_TimTheoMaNV.Text == "Theo mã nhân viên")
            {
                txt_TimTheoMaNV.Text = "";
            }
        }

        private void txt_TimTheoMaNV_Leave(object sender, EventArgs e)
        {
            if (txt_TimTheoMaNV.Text == "")
            {
                txt_TimTheoMaNV.Text = "Theo mã nhân viên";
            }
        }

        private void txt_TimTheoTen_Enter(object sender, EventArgs e)
        {
            if (txt_TimTheoTen.Text == "Theo tên nhân viên")
            {
                txt_TimTheoTen.Text = "";
            }
        }

        private void txt_TimTheoTen_Leave(object sender, EventArgs e)
        {
            if (txt_TimTheoTen.Text == "")
            {
                txt_TimTheoTen.Text = "Theo tên nhân viên";
            }
        }

        private void pb_TimTheoID_Click(object sender, EventArgs e)
        {
            if (txt_TimTheoMaNV.Text != "" && txt_TimTheoMaNV.Text != null && txt_TimTheoMaNV.Text != "Theo mã nhân viên")
            {
                btn_Them.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Huy.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                try
                {
                    DataSet ds = dbEmployee.findEmployeeByID(txt_TimTheoMaNV.Text.Trim());

                    dtEmployee = ds.Tables[0];
                    if (dtEmployee.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy thông tin nhân viên");
                    else
                        MessageBox.Show("Tìm thông tin nhân viên thành công");
                    dgv_Employee.DataSource = dtEmployee;

                    // Thực hiện các cài đặt DataGridView (nếu cần)
                    setDataGridView();
                    txt_TimTheoMaNV.Text = "Theo mã nhân viên";
                    txt_TimTheoTen.Text = "Theo tên nhân viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pb_TimKiemTheoTen_Click(object sender, EventArgs e)
        {
            if (txt_TimTheoTen.Text != "" && txt_TimTheoTen.Text != null && txt_TimTheoTen.Text != "Theo tên nhân viên")
            {
                btn_Them.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Huy.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                try
                {
                    DataSet ds = dbEmployee.findEmployeeByName(txt_TimTheoTen.Text.Trim());

                    dtEmployee = ds.Tables[0];
                    if (dtEmployee.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy thông tin nhân viên");
                    else
                        MessageBox.Show("Tìm thông tin nhân viên thành công");
                    dgv_Employee.DataSource = dtEmployee;

                    // Thực hiện các cài đặt DataGridView (nếu cần)
                    setDataGridView();
                    txt_TimTheoMaNV.Text = "Theo mã nhân viên";
                    txt_TimTheoTen.Text = "Theo tên nhân viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
