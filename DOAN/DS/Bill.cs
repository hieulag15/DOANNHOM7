﻿using DOAN.DATA;
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
            comm.Parameters.AddWithValue("@date", date);
            comm.Parameters.AddWithValue("@totalpay", totalpay);
            comm.Parameters.AddWithValue("@discount", discount);
            comm.Parameters.AddWithValue("@c_phone", cphone);
            comm.Parameters.AddWithValue("@e_id", eid);

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
