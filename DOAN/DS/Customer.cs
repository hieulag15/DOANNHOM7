using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DOAN.DS
{
    internal class Customer
    {
        DBConnection db = null;
        SqlCommand cmd;

        public Customer()
        {
            db = new DBConnection();
        }

        public DataSet getCustomer()
        {
            db = new DBConnection();
            return db.ExecuteQueryDataSet("select * from V_CUSTOMER_POINT");
        }
        public DataSet getCustomerNoActive()
        {
            db = new DBConnection();
            return db.ExecuteQueryDataSet("select * from V_CUSTOMERNOACTIVE");
        }

        public bool addCustomer(string phone, string name, decimal point)
        {

            db = new DBConnection();
            string queryString = "EXEC proc_AddCustomer @phone, @name, @point";
            cmd = new SqlCommand(queryString, db.getSqlConn);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@point", point);

            db.openConnection();
            try
            {
                cmd.ExecuteNonQuery();
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
        public bool updateCustomer(string phone, string name, decimal point, bool status)
        {
            string queryString = "EXEC proc_UpdateCustomer @phone, @name, @point, @status";

            cmd = new SqlCommand(queryString, db.getSqlConn);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@point", point);
            cmd.Parameters.AddWithValue("@status", status);
            db.openConnection();
            try
            {
                cmd.ExecuteNonQuery();
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

        public bool deleteCustomer(string phone)
        {
            cmd = new SqlCommand("proc_DeleteCustomer @phone", db.getSqlConn);
            cmd.Parameters.AddWithValue("@phone", phone);

            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
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
        public DataSet findCustomer(string phone)
        {
            db.openConnection();

            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SELECT * FROM dbo.SearchCustomerByPhone(@phone)", db.getSqlConn);
                cmd.Parameters.AddWithValue("@phone", phone);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.closeConnection();
            }

            db.closeConnection();
            return ds;
        }
    }
}
