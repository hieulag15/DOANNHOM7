using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.DS
{
    internal class Customer
    {
        DBConnection db = null;

        public Customer()
        {
            db = new DBConnection();
        }

        public DataSet getCustomer()
        {
            return db.ExecuteQueryDataSet("select * from V_CUSTOMER_POINT");
        }
    }
}
