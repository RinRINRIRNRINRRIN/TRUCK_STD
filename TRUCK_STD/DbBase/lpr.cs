using MySql.Data.MySqlClient;
using System.Data;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;

namespace TRUCK_STD.DbBase
{
    internal class lpr
    {

        public static string ERR { get; set; }

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";


        /// <summary>
        /// For select front and back cam
        /// </summary>
        /// <returns></returns>
        public static bool SelectCam()
        {
            try
            {
                sql = "SELECT * FROM lpr WHERE position = 'หน้า' or position = 'หลัง' ";
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

        /// <summary>
        /// For select ทางเข้า และทางออก 
        /// </summary>
        /// <returns></returns>
        public static bool SelectCamInOut()
        {
            try
            {
                switch (registy.system.stationType)
                {
                    case "สถานีชั่ง":
                        sql = "SELECT * FROM truckdata.lpr WHERE position = 'หน้า' or position = 'หลัง' ";
                        break;
                    case "จุดลงทะเบียน":
                        sql = "SELECT * FROM truckdata.lpr WHERE position = 'ทางเข้า' or position = 'ทางออก' ";
                        break;
                }
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

        public static bool Select()
        {
            try
            {
                sql = "SELECT * FROM lpr";
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
        public static bool Insert(lprModels lpr)
        {
            try
            {
                sql = "INSERT INTO lpr (ip,port,user,password,position) " +
                    "VALUES (@ip,@port,@user,@password,@position)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@ip", lpr.new_ip));
                cmd.Parameters.Add(new MySqlParameter("@port", lpr.port));
                cmd.Parameters.Add(new MySqlParameter("@user", lpr.user));
                cmd.Parameters.Add(new MySqlParameter("@password", lpr.pass));
                cmd.Parameters.Add(new MySqlParameter("@position", lpr.position));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Update(lprModels lpr)
        {
            try
            {
                sql = "UPDATE lpr " +
                    "SET ip  = @new_ip," +
                    "port = @port," +
                    "user = @user, " +
                    "password = @password, " +
                    "position = @position  " +
                    "WHERE ip = @old_ip";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@new_ip", lpr.new_ip));
                cmd.Parameters.Add(new MySqlParameter("@port", lpr.port));
                cmd.Parameters.Add(new MySqlParameter("@user", lpr.user));
                cmd.Parameters.Add(new MySqlParameter("@password", lpr.pass));
                cmd.Parameters.Add(new MySqlParameter("@position", lpr.position));

                cmd.Parameters.Add(new MySqlParameter("@old_ip", lpr.old_ip));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        public static bool Delete(lprModels lpr)
        {
            try
            {
                sql = $"DELETE FROM lpr WHERE ip = '{lpr.old_ip}'";
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
