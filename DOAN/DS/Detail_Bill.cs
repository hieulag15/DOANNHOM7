using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.DS
{
    internal class Detail_Bill
    {
        private string b_id;
        private string tenNhanVien;
        private string tenKhachHang;
        private DateTime ngayLap;
        private decimal tongThanhToan;
        DBConnection db = null;
        SqlCommand comm;
        public Detail_Bill(string b_id)
        {
            this.b_id = b_id;
        }
        public Detail_Bill()
        {
            db = new DBConnection();
        }
        public string getTenNhanVien() { return this.tenNhanVien; }
        public string getTenKhachHang() { return this.tenKhachHang; }
        public DateTime getNgayLap() { return this.ngayLap; }
        public decimal getTongThanhToan() {  return this.tongThanhToan;}

        public bool addDetailBill(string bid, string pid, int quantity)
        {
            comm = new SqlCommand("EXEC proc_AddDetailBill @b_id, @p_id, @db_quantity", db.getSqlConn);
            comm.Parameters.AddWithValue("@b_id", bid);
            comm.Parameters.AddWithValue("@p_id", pid);
            comm.Parameters.AddWithValue("@db_quantity", quantity);

            db.openConnection();
            if (comm.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

    }
}
