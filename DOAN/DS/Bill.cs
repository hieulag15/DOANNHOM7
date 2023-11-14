using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.DS
{
    internal class Bill
    {
        DBConnection db = null;
        SqlCommand comm;
        public Bill() 
        {
            db = new DBConnection();
        }
        public DataSet getBill()
        {
            return db.ExecuteQueryDataSet("select * from V_INFO_BILL");
        }

        public DataSet getDetailBill(string idBill)
        {
            return db.ExecuteQueryDataSet(string.Format("select * from V_INFO_DETAIL_BILL where [Mã hóa đơn] = '{0}'", idBill));
        }

        public DataRow getBillBasic(string idBill)
        {
            DataSet ds = db.ExecuteQueryDataSet(string.Format("select * from V_BillBasic where b_id = '{0}'", idBill));
            DataRow dr = ds.Tables[0].Rows[0];
            return dr;
        }

        public DataSet timKiem(SqlCommand comm)
        {
            DataSet ds = new DataSet();
            try
            {
                db.openConnection();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            db.closeConnection();
            return ds;
        }
        public DataSet timTheoMaBill(string b_id)
        {
            comm = new SqlCommand("select * from func_timBillTheoMaBill(@b_id)", db.getSqlConn);
            comm.Parameters.AddWithValue("@b_id", b_id);
            return timKiem(comm);
        }
        public DataSet timTheoSDT(string c_phone)
        {
            comm = new SqlCommand("select * from func_timBillTheoSDT(@c_phone)", db.getSqlConn);
            comm.Parameters.AddWithValue("@c_phone", c_phone);
            return timKiem(comm);
        }
        public DataSet timTheoMaSP(string p_id) 
        {
            comm = new SqlCommand("select * from func_timBillTheoMaMatHang(@p_id)", db.getSqlConn);
            comm.Parameters.AddWithValue("@p_id", p_id);
            return timKiem(comm);
        }
        public DataSet timTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            comm = new SqlCommand("select * from func_timBillTheoNgay(@ngayBatDau, @ngayKetThuc)", db.getSqlConn);
            comm.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);
            comm.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);
            return timKiem(comm);
        }

        public bool addBill(string bid, DateTime date, decimal totalpay, decimal discount, string cphone, string eid)
        {
            comm = new SqlCommand("EXEC proc_AddBill @b_id, @date, @totalpay, @discount, @c_phone, @e_id", db.getSqlConn);
            comm.Parameters.AddWithValue("@b_id", bid);
            comm.Parameters.AddWithValue("@date", date.Date);
            comm.Parameters.AddWithValue("@totalpay", totalpay);
            comm.Parameters.AddWithValue("@discount", discount);
            comm.Parameters.AddWithValue("@c_phone", cphone);
            comm.Parameters.AddWithValue("@e_id", eid);

            db.openConnection();
            if (comm.ExecuteNonQuery() > 0)
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

        public bool deleteBill(string bid)
        {
            comm = new SqlCommand("Exec proc_DeleteBill @bid", db.getSqlConn);
            comm.Parameters.AddWithValue("@bid", bid);

            db.openConnection();
            if ((comm.ExecuteNonQuery() == 1))
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

        public Decimal TotalSalesFee(int numberOfDays)
        {
            db = new DBConnection();
            db.openConnection();
            Decimal totalSalesAmount = 0;

            try
            {
                comm = new SqlCommand("SELECT dbo.CalculateTotalSalesAmountInLastNDays(@numberOfDays)", db.getSqlConn);
                comm.Parameters.AddWithValue("@numberOfDays", numberOfDays);

                totalSalesAmount = Convert.ToDecimal(comm.ExecuteScalar());
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return totalSalesAmount;
        }

        public int SPDaBan(int numberOfDays)
        {
            db.openConnection();
            int SPDaBan = 0;
            try
            {
                comm = new SqlCommand("SELECT dbo.func_sanPhamDaBan(@numberOfDays)", db.getSqlConn);
                comm.Parameters.AddWithValue("@numberOfDays", numberOfDays);
                SPDaBan = (int)comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "loi o sp da ban");
            }
            finally
            {
                db.closeConnection();
            }
            return SPDaBan;
        }
        public string CreateAutoID()
        {
            db = new DBConnection();
            db.openConnection();
            try
            {
                comm = new SqlCommand("proc_CreateAutoBillID", db.getSqlConn);
                comm.CommandType = CommandType.StoredProcedure;

                // Thêm tham số đầu vào nếu cần
                // comm.Parameters.AddWithValue("@parameterName", parameterValue);

                object result = comm.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return "";
        }
       
    }

}
