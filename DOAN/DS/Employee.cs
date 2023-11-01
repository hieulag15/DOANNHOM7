using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.DS
{
    internal class Employee
    {
        DBConnection db = null;

        public Employee()
        {
            db = new DBConnection();
        }

        public DataSet getEmployee()
        {
            return db.ExecuteQueryDataSet("select * from EMPLOYEE");
        }
    }
}
