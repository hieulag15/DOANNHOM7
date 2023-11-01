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
                
                //Ẩn các cột: sinh nhật, địa chỉ, trang thái.
                for (int i = 0; i < dgv_Employee.ColumnCount; i++)
                {
                    if (i == 5)
                        dgv_Employee.Columns[i].Visible = false;
                }

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
    }
}
