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
    internal class Employee
    {
        DBConnection db = null;
        SqlCommand cmd;
        public Employee()
        {
            db = new DBConnection();
        }

        public DataSet getEmployee()
        {
            return db.ExecuteQueryDataSet("select * from V_EMPLOYEE_INFO");
        }
        public bool addEmployee(string id, string name, string address, string phone, string gender)
        {
            db = new DBConnection();
            string queryString = "EXEC proc_AddEmployee @id, @name, @address, @phone, @gender";
            cmd = new SqlCommand(queryString, db.getSqlConn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@gender", gender);
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
        public bool updateEmployee(string id, string name, string address, string phone, string gender)
        {
            string queryString = "EXEC proc_UpdateEmployee @id, @name, @address, @phone, @gender";

            cmd = new SqlCommand(queryString, db.getSqlConn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@gender", gender);

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

        public bool deleteEmployee(string id)
        {
            cmd = new SqlCommand("proc_DeleteEmployee @id", db.getSqlConn);
            cmd.Parameters.AddWithValue("@id", id);

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
        public DataSet findEmployee(string id)
        {
            db.openConnection();
            DataSet ds = new DataSet();
            try
            {

                cmd = new SqlCommand("proc_FindEmployeeByID", db.getSqlConn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(); //Tạo một cầu nối giữa SQl command và Database
                da.SelectCommand = cmd;
                da.Fill(ds); //Đưa dữ liệu vừa gọi được vào DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
    }
}
