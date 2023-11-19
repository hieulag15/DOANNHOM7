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
    public partial class us_Account : UserControl
    {
        public us_Account()
        {
            InitializeComponent();
        }

        DataTable dtAccount = new DataTable();
        DataTable dtAccountActive = new DataTable();
        Account account = new Account();

        void LoadAccount()
        {
            dtAccount.Clear();
            DataSet ds = account.getAccount();
            dtAccount = ds.Tables[0];
            dgv_DanhSachHD.DataSource = dtAccount;
            setDataGridView();
        }

        private void setDataGridView()
        {
            if (dgv_DanhSachHD != null)
            {
                //Set Header Text cho dtgv
                dgv_DanhSachHD.Columns[0].HeaderText = "Tài khoản";
                dgv_DanhSachHD.Columns[1].HeaderText = "Mật khẩu";
                dgv_DanhSachHD.Columns[2].HeaderText = "Mã nhân viên";

                //Set chiều rộng cột
                int width = dgv_DanhSachHD.Width;
                int n_column = dgv_DanhSachHD.ColumnCount;
                dgv_DanhSachHD.Columns[0].Width -= width / n_column;
                dgv_DanhSachHD.Columns[1].Width -= width / n_column;
                dgv_DanhSachHD.Columns[2].Width -= width / n_column;
                dgv_DanhSachHD.AutoResizeColumns();
            }
        }

        private void us_Account_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }
    }
}
