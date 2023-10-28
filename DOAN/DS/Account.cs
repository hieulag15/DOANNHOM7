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
    public class Account
    {
        DBConnection db = null;
        SqlCommand cmd = null;

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string eid { get; set; }

        public Account(string username, string password, string name, string eid)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.eid = eid;
        }

        public Account() 
        {
            db = new DBConnection();
        }


        public DataSet getAccount()
        {
            return db.ExecuteQueryDataSet("select * from V_INFO_ACCOUNT");
        }

        public bool testLogin(string username, string password)
        {
            db.openConnection();
            cmd = new SqlCommand("SELECT dbo.uf_CheckLogin(@a_username, @a_password)", db.getSqlConn);
            cmd.Parameters.AddWithValue("@a_username", username);
            cmd.Parameters.AddWithValue("@a_password", password);
            int result = (int)cmd.ExecuteScalar();
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public DataSet GetAccount(string username, string password)
        {
            return db.ExecuteQueryDataSet("Select * from dbo.uf_PermissionRole('" + username + "', '" + password + "')");
        }
    }
}
