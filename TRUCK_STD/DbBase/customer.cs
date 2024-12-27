using MySql.Data.MySqlClient;
using System.Data;

namespace TRUCK_STD.DbBase
{
    internal class customer
    {

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";

        public static string ERR { get; set; }
        public static string new_id { get; set; }
        public static string old_id { get; set; }
        public static string names { get; set; }


        static void ClearProp()
        {
            new_id = null;
            old_id = null;
            names = null;
        }

        public static bool Select()
        {
            try
            {
                sql = "SELECT * FROM truckdata.customer";
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
        public static string Select(string _name)
        {
            string result = "";
            try
            {
                sql = $"SELECT * FROM customer WHERE customerName LIKE '%{_name}%'";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);

                if (tb.Rows.Count == 0)
                    return "";

                foreach (DataRow rw in tb.Rows)
                {
                    result = rw["names"].ToString();
                }

            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return "";
            }

            return result;
        }


        public static bool Insert()
        {
            try
            {
                sql = "INSERT INTO customer (customerId,customerName) " +
                    "VALUES (@customerId,@customerName)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@customerId", new_id));
                cmd.Parameters.Add(new MySqlParameter("@customerName", names));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                ClearProp();
                return false;
            }
            ClearProp();
            return true;
        }
        public static bool Update()
        {
            try
            {
                sql = "UPDATE customer " +
                    "SET customerId = @new_id," +
                    "customerName = @customerName " +
                    "WHERE customerId = @old_id";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@new_id", new_id));
                cmd.Parameters.Add(new MySqlParameter("@customerName", names));
                cmd.Parameters.Add(new MySqlParameter("@old_id", old_id));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                ClearProp();
                return false;
            }
            ClearProp();
            return true;
        }
        public static bool Delete()
        {
            try
            {
                sql = $"DELETE FROM customer WHERE customerId = '{old_id}'";
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                ClearProp();
                return false;
            }
            ClearProp();
            return true;
        }


    }
}
