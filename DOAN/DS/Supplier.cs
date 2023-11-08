using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace DOAN.DS
{
    internal class Supplier
    {
        DBConnection db = null;
        SqlCommand comm;
        public Supplier()
        { 
            db = new DBConnection(); 
        }
        public DataSet getSupplier()
        {
            return db.ExecuteQueryDataSet("select * from V_INFO_SUPPLIER");
        }
        public string CreateAutoID()
        {
            db.openConnection();
            try
            {
                comm = new SqlCommand("proc_CreateAutoSupplierID", db.getSqlConn);
                comm.CommandType = CommandType.StoredProcedure;

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

        public bool addSupplier(string s_id, string s_name, string s_phone, string s_address)
        {
            comm = new SqlCommand("EXEC proc_AddSupplier @s_id, @s_name, @s_phone, @s_address", db.getSqlConn);
            comm.Parameters.AddWithValue("@s_id", s_id);
            comm.Parameters.AddWithValue("@s_name", s_name);
            comm.Parameters.AddWithValue("@s_phone", s_phone);
            comm.Parameters.AddWithValue("@s_address", s_address);
            db.openConnection();  
            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public bool updateSupplier(string s_id, string s_name, string s_phone, string s_address)
        {
            comm = new SqlCommand("EXEC proc_updateSupplier @s_id, @s_name, @s_phone, @s_address", db.getSqlConn);
            comm.Parameters.AddWithValue("@s_id", s_id);
            comm.Parameters.AddWithValue("@s_name", s_name);
            comm.Parameters.AddWithValue("@s_phone", s_phone);
            comm.Parameters.AddWithValue("@s_address", s_address);
            db.openConnection();
            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public bool deleteSupplier(string s_id)
        {
            comm = new SqlCommand("EXEC proc_DeleteSupplier @s_id", db.getSqlConn);
            comm.Parameters.AddWithValue("@s_id", s_id);
            db.openConnection();
            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
