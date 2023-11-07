using System;
using System.Collections.Generic;
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
        public Detail_Bill(string b_id)
        {
            this.b_id = b_id;
        }
        public string getTenNhanVien() { return this.tenNhanVien; }
        public string getTenKhachHang() { return this.tenKhachHang; }
        public DateTime getNgayLap() { return this.ngayLap; }
        public decimal getTongThanhToan() {  return this.tongThanhToan;}

    }
}
