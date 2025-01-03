﻿using MySql.Data.MySqlClient;
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
                // เช็คว่ามีการเชื่อมต่ออยู่แล้วหรือไม่
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                // สร้างการเชื่อมต่อ
                con.ConnectionString = $"Server={HOST};Port={PORT};Database={BASS};Uid={USER};Pwd={PASS};SslMode=none;charset=utf8;";
                // เปิดการเชื่อมต่อ
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
