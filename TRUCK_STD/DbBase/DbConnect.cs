using MySql.Data.MySqlClient;
using System;
using TRUCK_STD.Functions;
namespace TRUCK_STD.DbBase
{
    internal class DbConnect
    {
        public static string HOST { get; set; }
        public static int PORT { get; set; }
        public static string USER { get; set; }
        public static string PASS { get; set; }
        public static string BASS { get; set; }

        public static MySqlConnection con = new MySqlConnection();
        public static string ERR { get; set; }

        public static bool ConnectBase()
        {
            try
            {
                con.Close();
                Console.WriteLine(registy.db.host);
                con.ConnectionString = $"Server={HOST};Port={PORT};Database={BASS};Uid={USER};Pwd={PASS};SslMode=none;charset=utf8;";
                con.Open();
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
