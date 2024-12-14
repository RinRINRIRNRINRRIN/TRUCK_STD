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
        /// สำหรับค้นหารายการชั่ง
        /// </summary>
        /// <returns></returns>
        public static bool selectOrderDetail(int id)
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
        /// สำหรับบันทึกมีกล้อง
        /// </summary>
        /// <param name="jobId">เลขที่ออเดรอ์ AI</param>
        /// <param name="weightType">ประเภทการชั่ง ชั่งเข้า,ชั่งออก</param>
        /// <param name="weight">น้ำหนักไม่มีทศนิยม</param>
        /// <returns></returns>
        public static bool InsertNewOrderdetail(int jobId, string weightType, int weight, string pictureLicense, string pictureCarFront, string pictrueCarBack)
        {
            try
            {
                // เพิ่มข้อมูล order detail
                sql = "INSERT INTO jobDetail (jobId,weightType,weight,pictureLicense,pictureCarFront,pictureCarBack,dateTimes) VALUES(@jobId,@weightType,@weight,@pictureLicense,@pictureCarFront,@pictureCarBack,current_timestamp())";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobId", jobId));
                cmd.Parameters.Add(new MySqlParameter("@weightType", weightType));
                cmd.Parameters.Add(new MySqlParameter("@weight", weight));
                cmd.Parameters.Add(new MySqlParameter("@pictureLicense", pictureLicense));
                cmd.Parameters.Add(new MySqlParameter("@pictureCarFront", pictureCarFront));
                cmd.Parameters.Add(new MySqlParameter("@pictureCarBack", pictrueCarBack));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"InsertNewOrderdetail | {ex.Message} ");
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับมีไม่มีกล้อง
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

        /// <summary>
        /// สำหรับมีไม่มีกล้องมีราคา
        /// </summary>
        /// <param name="jobId">เลขที่ออเดรอ์ AI</param>
        /// <param name="weightType">ประเภทการชั่ง ชั่งเข้า,ชั่งออก</param>
        /// <param name="weight">น้ำหนักไม่มีทศนิยม</param>
        /// <returns></returns>
        public static bool InsertNewOrderdetail(int jobId, string weightType, int weight, double productPrice)
        {
            try
            {
                // เพิ่มข้อมูล order detail
                sql = "INSERT INTO jobDetail (jobId,weightType,weight,pictureLicense,pictureCarFront,pictureCarBack,dateTimes) VALUES(@jobId,@weightType,@weight,@pictureLicense,@pictureCarFront,@pictureCarBack,current_timestamp())";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobId", jobId));
                cmd.Parameters.Add(new MySqlParameter("@weightType", weightType));
                cmd.Parameters.Add(new MySqlParameter("@weight", weight));
                cmd.Parameters.Add(new MySqlParameter("@pictureLicense", "-"));
                cmd.Parameters.Add(new MySqlParameter("@pictureCarFront", "-"));
                cmd.Parameters.Add(new MySqlParameter("@pictureCarBack", "-"));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"InsertNewOrderdetail | {ex.Message} ");
                return false;
            }
            return true;
        }




        public static bool DeleteOrder(int id)
        {
            try
            {
                sql = $"DELETE FROM truckdata.jobdetail WHERE jobId = {id}";
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
