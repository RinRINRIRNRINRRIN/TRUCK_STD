using MySql.Data.MySqlClient;
using System.Data;
using TRUCK_STD.Models;

namespace TRUCK_STD.DbBase
{
    internal class cctvs
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
        public static bool Insert(cctvModels cctv)
        {
            try
            {
                sql = "INSERT INTO cctv (ip,port,user,password,position) " +
                    "VALUES (@ip,@port,@user,@password,@position)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@ip", cctv.new_ip));
                cmd.Parameters.Add(new MySqlParameter("@port", cctv.port));
                cmd.Parameters.Add(new MySqlParameter("@user", cctv.user));
                cmd.Parameters.Add(new MySqlParameter("@password", cctv.pass));
                cmd.Parameters.Add(new MySqlParameter("@position", cctv.position));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Update(cctvModels cctv)
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
                cmd.Parameters.Add(new MySqlParameter("@new_ip", cctv.new_ip));
                cmd.Parameters.Add(new MySqlParameter("@port", cctv.port));
                cmd.Parameters.Add(new MySqlParameter("@user", cctv.user));
                cmd.Parameters.Add(new MySqlParameter("@password", cctv.pass));
                cmd.Parameters.Add(new MySqlParameter("@position", cctv.position));
                cmd.Parameters.Add(new MySqlParameter("@old_ip", cctv.old_ip));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Delete(cctvModels cctv)
        {
            try
            {
                sql = $"DELETE FROM cctv WHERE ip = '{cctv.old_ip}'";
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
