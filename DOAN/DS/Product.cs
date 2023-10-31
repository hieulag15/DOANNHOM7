using DOAN.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public DataSet FindProduct(string p_name)
        {
            db = new DBConnection();
            db.openConnection();
            DataSet ds = new DataSet();
            try
            {
                comm = new SqlCommand("proc_FindProduct", db.getSqlConn);
                comm.Parameters.AddWithValue("@searchChar", p_name);

                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(); //Tạo một cầu nối giữa SQl command và Database
                da.SelectCommand = comm;
                da.Fill(ds); //Đưa dữ liệu vừa gọi được vào DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return ds;
        }

        public DataSet FindProductByIDType(string p_name)
        {
            db = new DBConnection();
            db.openConnection();
            DataSet ds = new DataSet();
            try
            {
                comm = new SqlCommand("proc_FindProductByIDType", db.getSqlConn);
                comm.Parameters.AddWithValue("@idtype", p_name);

                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(); //Tạo một cầu nối giữa SQl command và Database
                da.SelectCommand = comm;
                da.Fill(ds); //Đưa dữ liệu vừa gọi được vào DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return ds;
        }

        public string GetTypeProduct(string id_product)
        {
            Dictionary<string, string> productTypes = new Dictionary<string, string>
            {
                { "PT", "Áo thun" },
                { "PK", "Áo khoác" },
                { "PM", "Áo sơ mi" },
                { "PP", "Áo Polo" },
                { "PJ", "Quần Jean" },
                { "PE", "Quần Tây" },
                { "PS", "Quần Short" },
            };

            foreach (string key in productTypes.Keys)
            {
                if (id_product.Contains(key))
                {
                    return productTypes[key];
                }
            }
            return "Không xác định";
        }

        public string CreateAutoID(string idtype)
        {
            db = new DBConnection();
            db.openConnection();
            try
            {
                comm = new SqlCommand("proc_CreateAutoProductID", db.getSqlConn);
                comm.Parameters.AddWithValue("@idtype", idtype);
                comm.CommandType = CommandType.StoredProcedure;

                // Thêm tham số đầu vào nếu cần
                // comm.Parameters.AddWithValue("@parameterName", parameterValue);

                object result = comm.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return "";
        }
    }
}
