using MySql.Data.MySqlClient;
using System.Data;
using TRUCK_STD.Models;

namespace TRUCK_STD.DbBase
{
    internal class product
    {
        public static string ERR { get; set; }

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";


        public static bool Select()
        {
            try
            {
                sql = "SELECT * FROM product";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool SelectChar(productModel productModel)
        {
            try
            {
                sql = $"SELECT * FROM product WHERE names LIKE '%{productModel.names}%'";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Insert(productModel product)
        {
            try
            {
                sql = "INSERT INTO product (id,names,price) " +
                    "VALUES (@id,@names,@price)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@id", product.new_id));
                cmd.Parameters.Add(new MySqlParameter("@names", product.names));
                cmd.Parameters.Add(new MySqlParameter("@price", product.price));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Update(productModel product)
        {
            try
            {
                sql = "UPDATE product " +
                    "SET id = @new_id," +
                    "names = @names," +
                    "price = @price " +
                    "WHERE id = @old_id";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@new_id", product.new_id));
                cmd.Parameters.Add(new MySqlParameter("@names", product.names));
                cmd.Parameters.Add(new MySqlParameter("@price", product.price));
                cmd.Parameters.Add(new MySqlParameter("@old_id", product.old_id));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Delete(productModel product)
        {
            try
            {
                sql = $"DELETE FROM product WHERE id = '{product.old_id}'";
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }

    }
}
