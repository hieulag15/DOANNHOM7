using DOAN.DATA;
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

        bool addFlag;
        DataTable dtAccount = new DataTable();
        DataTable dtAccountActive = new DataTable();
        Account dbAccount = new Account();
        Account account = new Account();
        int role = 0;

        void LoadAccount()
        {
            dtAccount.Clear();
            DataSet ds = account.getAccount();
            dtAccount = ds.Tables[0];
            dgv_DanhSachHD.DataSource = dtAccount;
            setDataGridView();
        }
        void not_fillingStatus()
        {
            txt_TaiKhoan.Enabled = false;
            txt_MaNhanVien.Enabled = false;
            txt_MatKhau.Enabled = false;
            rbtn_Quanly.Enabled = false;
            rb_HD.Enabled = false;
            rb_KhongHD.Enabled = false;
        }
        void fillingStatus()
        {
            txt_TaiKhoan.Enabled = true;
            txt_MaNhanVien.Enabled = true;
            txt_MatKhau.Enabled = true;
            rbtn_Quanly.Enabled = true;
            rb_HD.Enabled = true;
            rb_KhongHD.Enabled = true;
        }
        void initial_Status()
        {
            not_fillingStatus();
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;
            btn_Xoa.Enabled = true;
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
            initial_Status();
        }
        private void Refresh()
        {
            txt_TaiKhoan.Text = "";
            txt_MaNhanVien.Text = "";
            txt_MatKhau.Text = "";
            rbtn_Quanly.Checked = false;
            rb_HD.Checked = false;
            rb_KhongHD.Checked = false;
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

        private void rbtn_Quanly_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn_Quanly.Checked)
            {
                role = 1;
            }
        }

        private void dgv_DanhSachHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txt_TaiKhoan.Text = dgv_DanhSachHD.Rows[numrow].Cells[0].Value.ToString();
                txt_MatKhau.Text = dgv_DanhSachHD.Rows[numrow].Cells[1].Value.ToString();
                txt_MaNhanVien.Text = dgv_DanhSachHD.Rows[numrow].Cells[2].Value.ToString();
                rb_HD.Checked = true;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Trường hợp khi người dùng chưa chọn nhan vien cần sửa thông tin
            if (txt_MaNhanVien.Text == "" || txt_MaNhanVien.Text == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần chỉnh sửa thông tin", "Lỗi",
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

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (addFlag == true) //Trường hợp thêm nhan vien
            {
                try
                {
                    account.addAccount(txt_TaiKhoan.Text.Trim(), txt_MatKhau.Text.Trim(), txt_MaNhanVien.Text.Trim(), role);
                    LoadAccount();
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
                    account.updateAccount(txt_TaiKhoan.Text.Trim(), txt_MatKhau.Text.Trim());
                    LoadAccount();
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

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            Refresh();
            initial_Status();
            LoadAccount();
            txt_TimTheoTenTK.Text = "Theo tên đăng nhập";
            txt_TimTheoID.Text = "Theo mã nhân viên";
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Refresh();
            initial_Status();
            addFlag = false;
        }

        private void txt_TimTheoTenTK_Enter(object sender, EventArgs e)
        {
            if (txt_TimTheoTenTK.Text == "Theo tên đăng nhập")
            {
                txt_TimTheoTenTK.Text = "";
            }
        }

        private void txt_TimTheoTenTK_Leave(object sender, EventArgs e)
        {
            if (txt_TimTheoTenTK.Text == "")
            {
                txt_TimTheoTenTK.Text = "Theo tên đăng nhập";
            }
        }

        private void txt_TimTheoID_Leave(object sender, EventArgs e)
        {
            if (txt_TimTheoID.Text == "")
            {
                txt_TimTheoID.Text = "Theo mã nhân viên";
            }
        }

        private void txt_TimTheoID_Enter(object sender, EventArgs e)
        {
            if (txt_TimTheoID.Text == "Theo mã nhân viên")
            {
                txt_TimTheoID.Text = "";
            }
        }

        private void pb_TimTheoTenTK_Click(object sender, EventArgs e)
        {
            if (txt_TimTheoTenTK.Text != "" && txt_TimTheoTenTK.Text != null && txt_TimTheoTenTK.Text != "Theo mã nhân viên")
            {
                btn_Them.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Huy.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                try
                {
                    DataSet ds = dbAccount.findAccountByUserName(txt_TimTheoTenTK.Text.Trim());

                    dtAccount = ds.Tables[0];
                    if (dtAccount.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy thông tin tài khoản");
                    else
                        MessageBox.Show("Tìm thông tin tài khoản thành công");
                    dgv_DanhSachHD.DataSource = dtAccount;

                    // Thực hiện các cài đặt DataGridView (nếu cần)
                    setDataGridView();
                    txt_TimTheoTenTK.Text = "Theo tên đăng nhập";
                    txt_TimTheoID.Text = "Theo mã nhân viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pb_TimTheoID_Click(object sender, EventArgs e)
        {
            if (txt_TimTheoTenTK.Text != "" && txt_TimTheoTenTK.Text != null && txt_TimTheoTenTK.Text != "Theo mã nhân viên")
            {
                btn_Them.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Huy.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                try
                {
                    DataSet ds = dbAccount.findAccountByID(txt_TimTheoID.Text.Trim());

                    dtAccount = ds.Tables[0];
                    if (dtAccount.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy thông tin tài khoản");
                    else
                        MessageBox.Show("Tìm thông tin tài khoản thành công");
                    dgv_DanhSachHD.DataSource = dtAccount;

                    // Thực hiện các cài đặt DataGridView (nếu cần)
                    setDataGridView();
                    txt_TimTheoTenTK.Text = "Theo tên đăng nhập";
                    txt_TimTheoID.Text = "Theo mã nhân viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
