using MySql.Data.MySqlClient;
using System.Data;

namespace TRUCK_STD.DbBase
{
    internal class cctvs
    {

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";

        public static string ERR { get; set; }
        public static string new_ip { get; set; }
        public static string old_ip { get; set; }
        public static int port { get; set; }
        public static string user { get; set; }
        public static string pass { get; set; }
        public static string position { get; set; }


        private static void ClearProp()
        {
            new_ip = null;
            port = 0;
            user = null;
            pass = null;
            position = null;
        }
        public static bool Select()
        {
            try
            {
                sql = "SELECT * FROM cctv";
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
        public static bool Insert()
        {
            try
            {
                sql = "INSERT INTO cctv (ip,port,user,password,position) " +
                    "VALUES (@ip,@port,@user,@password,@position)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@ip", new_ip));
                cmd.Parameters.Add(new MySqlParameter("@port", port));
                cmd.Parameters.Add(new MySqlParameter("@user", user));
                cmd.Parameters.Add(new MySqlParameter("@password", pass));
                cmd.Parameters.Add(new MySqlParameter("@position", position));
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
                sql = "UPDATE cctv " +
                    "SET ip  = @new_ip," +
                    "port = @port," +
                    "user = @user, " +
                    "password = @password," +
                    "position = @position  " +
                    "WHERE ip = @old_ip";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@new_ip", new_ip));
                cmd.Parameters.Add(new MySqlParameter("@port", port));
                cmd.Parameters.Add(new MySqlParameter("@user", user));
                cmd.Parameters.Add(new MySqlParameter("@password", pass));
                cmd.Parameters.Add(new MySqlParameter("@position", position));
                cmd.Parameters.Add(new MySqlParameter("@old_ip", old_ip));
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
                sql = $"DELETE FROM cctv WHERE ip = '{old_ip}'";
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
