using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public DataSet getOneProduct(string id_product)
        {
            return db.ExecuteQueryDataSet(string.Format("select * from PRODUCT where p_id = '{0}'", id_product));
        }

        public DataSet getDetailProduct(string id_product)
        {
            return db.ExecuteQueryDataSet(string.Format("select * from V_DetailProduct where ProductID = '{0}'", id_product));
        }

        public bool addProduct(string pid, string name, decimal price, byte[] image, string size, int quantity)
        {
            comm = new SqlCommand("EXEC proc_AddProduct @pid, @name, @price, @image, @size , @quantity", db.getSqlConn);
            comm.Parameters.AddWithValue("@pid", pid);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@price", price);
            comm.Parameters.AddWithValue("@image", image.ToArray());
            comm.Parameters.AddWithValue("@size", size);
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

        public bool deleteProduct(string pid)
        {
            comm = new SqlCommand("Exec proc_DeleteProduct @pid", db.getSqlConn);
            comm.Parameters.AddWithValue("@pid", pid);

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

        public bool updateProduct(string pid, string name, decimal price, byte[] image, string size, int quantity)
        {

            comm = new SqlCommand("EXEC proc_UpdateProduct @pid, @name, @price, @image, @size , @quantity", db.getSqlConn);
            comm.Parameters.AddWithValue("@pid", pid);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@price", price);
            comm.Parameters.AddWithValue("@image", image.ToArray());
            comm.Parameters.AddWithValue("@size", size);
            comm.Parameters.AddWithValue("@quantity", quantity);

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
    }
}
