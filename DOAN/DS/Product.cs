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
    internal class Product
    {
        DBConnection db = null;
        SqlCommand comm;

        public Product()
        {
            db = new DBConnection();
        }

        public DataSet getProduct()
        {
            return db.ExecuteQueryDataSet("select * from V_PRODUCTS");
        }

        public DataSet getDetailProduct(string id_product)
        {
            return db.ExecuteQueryDataSet(string.Format("select * from V_DetailProduct where ProductID = '{0}'", id_product));
        }
    }
}
