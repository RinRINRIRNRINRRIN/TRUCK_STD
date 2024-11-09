using MySql.Data.MySqlClient;
using System.Data;
using TRUCK_STD.Models;

namespace TRUCK_STD.DbBase
{
    internal class customer
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
                sql = "SELECT * FROM customer";
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
        public static bool SelectChar(customerModel customerModel)
        {
            try
            {
                sql = $"SELECT * FROM customer WHERE names LIKE '%{customerModel.names}%'";
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
        public static bool Insert(customerModel customer)
        {
            try
            {
                sql = "INSERT INTO customer (id,names) " +
                    "VALUES (@id,@names)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@id", customer.new_id));
                cmd.Parameters.Add(new MySqlParameter("@names", customer.names));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Update(customerModel customer)
        {
            try
            {
                sql = "UPDATE customer " +
                    "SET id = @new_id," +
                    "names = @names " +
                    "WHERE id = @old_id";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@new_id", customer.new_id));
                cmd.Parameters.Add(new MySqlParameter("@names", customer.names));
                cmd.Parameters.Add(new MySqlParameter("@old_id", customer.old_id));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Delete(customerModel customer)
        {
            try
            {
                sql = $"DELETE FROM customer WHERE id = '{customer.old_id}'";
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
