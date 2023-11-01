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
                dgv_Customer.Columns[3].HeaderText = "Trạng thái";

                //Set chiều rộng cột
                int width = dgv_Customer.Width;
                int n_column = dgv_Customer.ColumnCount;
                dgv_Customer.Columns[0].Width -= width / n_column;
                dgv_Customer.Columns[1].Width -= width / n_column;
                dgv_Customer.Columns[2].Width -= width / n_column;
                dgv_Customer.Columns[3].Width -= width / n_column;
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
                rb_HD.Checked = Convert.ToInt32(dgv_Customer.Rows[numrow].Cells[3].Value) == 1 ? true : false;
                rb_KHD.Checked = !rb_HD.Checked;
            }
        }
    }
}
