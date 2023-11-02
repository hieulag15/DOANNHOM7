using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace DOAN.DS
{
    internal class Shipment
    {
        DBConnection db = null;
        SqlCommand comm;

        public Shipment()
        {
            db = new DBConnection();
        }

        public DataSet getShipment()
        {
            return db.ExecuteQueryDataSet("select * from V_INFO_SHIPMENT");
        }

        public DataRow getOneShipment(string id_shipment)
        {
            DataSet ds = db.ExecuteQueryDataSet(string.Format("select * from SHIPMENT where sh_id = '{0}'", id_shipment));
            DataRow dr = ds.Tables[0].Rows[0];
            return dr;
        }

        public DataSet getDetailShipment(string id_shipment)
        {
            return db.ExecuteQueryDataSet(string.Format("select * from V_INFO_DETAIL_SHIPMENT where [Mã lô hàng] = '{0}'", id_shipment));
        }

        public bool addShipment(string shid, string sid, DateTime imDate)
        {
            comm = new SqlCommand("EXEC proc_AddShipment @shid, @sid, @imDate", db.getSqlConn);
            comm.Parameters.AddWithValue("@shid", shid);
            comm.Parameters.AddWithValue("@sid", sid);
            comm.Parameters.AddWithValue("@imDate", imDate);

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

        public bool addDetailShipment(string shid, string pid, decimal imPrice, int quantity)
        {
            comm = new SqlCommand("EXEC proc_AddDetailShipment @shid, @pid, @imPrice, @quantity", db.getSqlConn);
            comm.Parameters.AddWithValue("@shid", shid);
            comm.Parameters.AddWithValue("@pid", pid);
            comm.Parameters.AddWithValue("@imPrice", imPrice);
            comm.Parameters.AddWithValue("@quantity", quantity);

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

        public bool deleteShipment(string shid)
        {
            comm = new SqlCommand("Exec proc_DeleteShipment @shid", db.getSqlConn);
            comm.Parameters.AddWithValue("@shid", shid);

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

        public string CreateAutoID(string prefix)
        {
            db = new DBConnection();
            db.openConnection();
            try
            {
                comm = new SqlCommand("proc_CreateAutoShipmentID", db.getSqlConn);
                comm.Parameters.AddWithValue("@prefix", prefix);
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return "";
        }
    }
}
