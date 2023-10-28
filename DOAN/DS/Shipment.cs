using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool addShipment(string shid, string sid, string pid, decimal imPrice, DateTime imDate, int pquantity)
        {
            comm = new SqlCommand("EXEC usp_AddShipment @shid, @sid, @pid, @imPrice, @imDate, @pquantity", db.getSqlConn);
            comm.Parameters.AddWithValue("@shid", shid);
            comm.Parameters.AddWithValue("@sid", sid);
            comm.Parameters.AddWithValue("@pid", pid);
            comm.Parameters.AddWithValue("@imPrice", imPrice);
            comm.Parameters.AddWithValue("@imDate", imDate);
            comm.Parameters.AddWithValue("@pquantity", pquantity);

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
