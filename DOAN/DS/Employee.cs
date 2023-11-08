using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
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
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sửa thành công!", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteEmployee(string id)
        {
            cmd = new SqlCommand("proc_DeleteEmployee @id", db.getSqlConn);
            cmd.Parameters.AddWithValue("@id", id);

            db.openConnection();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Xóa thành công!", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
                return true;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
                return false;
            }
        }
        public DataSet findEmployeeByID(string id)
        {
            db.openConnection();

            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SELECT * FROM dbo.SearchEmployeeByID(@id)", db.getSqlConn);
                cmd.Parameters.AddWithValue("@id", id);

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
        public DataSet findEmployeeByName(string name)
        {
            db.openConnection();

            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SELECT * FROM dbo.SearchEmployeeByName(@name)", db.getSqlConn);
                cmd.Parameters.AddWithValue("@name", name);

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
