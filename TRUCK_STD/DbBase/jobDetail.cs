using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace TRUCK_STD.DbBase
{
    internal class jobDetail
    {
        public static string ERR { get; set; }

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";


        /// <summary>
        /// สำหรับเช็คว่ามีการชั่งไปกี่รายการ ถ้าเป็น 2 หมายความว่าชั่งครบแล้ว
        /// </summary>
        /// <returns></returns>
        public static bool SelectCountOrderDetail(int id)
        {
            try
            {
                sql = $"SELECT * FROM jobDetail WHERE jobId = {id}";
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
        /// For add new data weight
        /// </summary>
        /// <param name="jobId">เลขที่ออเดรอ์ AI</param>
        /// <param name="weightType">ประเภทการชั่ง ชั่งเข้า,ชั่งออก</param>
        /// <param name="weight">น้ำหนักไม่มีทศนิยม</param>
        /// <returns></returns>
        public static bool InsertNewOrderdetail(int jobId, string weightType, int weight)
        {
            try
            {
                // เพิ่มข้อมูล order detail
                sql = "INSERT INTO jobDetail (jobId,weightType,weight,dateTimes) VALUES(@jobId,@weightType,@weight,current_timestamp())";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobId", jobId));
                cmd.Parameters.Add(new MySqlParameter("@weightType", weightType));
                cmd.Parameters.Add(new MySqlParameter("@weight", weight));
                cmd.ExecuteNonQuery();


            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"InsertNewOrderdetail | {ex.Message} ");
                return false;
            }
            return true;
        }
    }
}
