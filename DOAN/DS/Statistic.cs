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
    internal class Statistic
    {
        DBConnection db = null;
        SqlCommand comm;
        public Statistic()
        {
            db = new DBConnection();
        }
        public int tongKhachHang()
        {
            comm= new SqlCommand("select * from");
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
