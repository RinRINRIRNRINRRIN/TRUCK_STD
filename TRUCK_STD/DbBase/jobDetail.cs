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
        /// สำหรับค้นหารายการชั่งของเลข order นั้น ๆ 
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool selectOrderDetail(string id)
        {
            try
            {
                sql = $"SELECT * FROM job a " +
                   $"LEFT JOIN customer b " +
                   $"ON a.customerName = b.customerName " +
                   $"LEFT JOIN product c " +
                   $"ON a.productName = c.productName " +
                   $"LEFT JOIN jobdetail d " +
                   $"ON a.jobOrder = d.jobOrder " +
                   $" WHERE a.jobOrder = '{id}'";
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
        /// ค้นหาข้อมูลเพื่อทำ report ทั้งการชั่งที่สำเร็จและรอดำเนินการ
        /// </summary>
        /// <param name="state">สถานะของการชั่ง Process,Success</param>
        /// <returns></returns>
        public static bool selectOrderMakeReport(string state)
        {
            try
            {
                sql = $"SELECT a.jobOrder,a.licenseHead,a.licenseTail,a.netWeight,b.customerName,c.productName,d.dateTimes,d.weight,d.weightType FROM job a " +
                 $"LEFT JOIN customer b " +
                 $"ON a.customerName = b.customerName " +
                 $"LEFT JOIN product c " +
                 $"ON a.productName = c.productName " +
                 $"LEFT JOIN jobdetail d " +
                $"ON a.jobOrder = d.jobOrder " +
                $"WHERE a.state = '{state}'  ORDER BY d.id ASC";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        public static bool SelectSearchQuery(string query)
        {
            try
            {
                da = new MySqlDataAdapter(query, con);
                tb = new DataTable();
                da.Fill(tb);


            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// บันทึกข้อมูลรอง
        /// </summary>
        /// <param name="jobId">เลขที่ออเดอร์</param>
        /// <param name="weightType">ประเภทการชั่ง ชั่งเข้า,ชั่งออก</param>
        /// <param name="weight">น้ำหนักไม่มีทศนิยม</param>
        /// <returns></returns>
        public static bool InsertNewOrderdetail(string jobId, string weightType, int weight, string pictureLicense, string pictureCarFront, string pictrueCarBack)
        {
            try
            {
                // เพิ่มข้อมูล order detail
                sql = "INSERT INTO jobDetail (jobOrder,weightType,weight,pictureLicense,pictureCarFront,pictureCarBack,dateTimes) " +
                    "VALUES(@jobOrder,@weightType,@weight,@pictureLicense,@pictureCarFront,@pictureCarBack,current_timestamp())";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobOrder", jobId));
                cmd.Parameters.Add(new MySqlParameter("@weightType", weightType));
                cmd.Parameters.Add(new MySqlParameter("@weight", weight));
                cmd.Parameters.Add(new MySqlParameter("@pictureLicense", pictureLicense));
                cmd.Parameters.Add(new MySqlParameter("@pictureCarFront", pictureCarFront));
                cmd.Parameters.Add(new MySqlParameter("@pictureCarBack", pictrueCarBack));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                Console.WriteLine($"InsertNewOrderdetail | {ex.Message} ");
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับลบข้อมูลรอง
        /// </summary>
        /// <param name="id">เลขที่ order</param>
        /// <returns></returns>
        public static bool DeleteOrder(string id)
        {
            try
            {
                sql = $"DELETE FROM truckdata.jobdetail WHERE jobOrder = '{id}'";
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
