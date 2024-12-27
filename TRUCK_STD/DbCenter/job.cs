using MySql.Data.MySqlClient;
using System;
using System.Data;
using TRUCK_STD.Models;

namespace TRUCK_STD.DbCenter
{
    internal class job
    {
        public static string ERR { get; set; }

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";




        /// <summary>
        /// สำหรับแสดงข้อมูลในวันนั้นๆ 
        /// </summary>
        /// <returns></returns>
        public static bool Select_Today()
        {
            try
            {
                DateTime dateToday = DateTime.Now;
                string date = dateToday.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE dateRegistor =  '{date}'";
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
        /// สำหรับดึงค่า id ขอบ job 
        /// </summary>
        /// <param name="jobModels"></param>
        /// <returns></returns>
        public static bool SelectGetId(jobModels jobModels)
        {
            try
            {
                DateTime dateToday = DateTime.Now;
                string date = dateToday.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE dateRegistor =  '{date}' and status = 'Pendding' and idcard = '{jobModels.idCard}'";
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
        /// สำหรับนำเลข RFID ไปค้นหาในวันนั้น
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public static bool SelectSearchRFIDToday(string rfid)
        {
            try
            {
                DateTime dateToday = DateTime.Now;
                string date = dateToday.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE dateRegistor =  '{date}' and epc = '{rfid}' and status = 'Process'";
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
        /// สำหรับต้นหาเลขบัตรประชาชนลาสุด
        /// </summary>
        /// <param name="id">เลชบัตรประชาชน</param>
        /// <returns></returns>
        public static bool SelectSearchIdCardToday(string id)
        {
            try
            {
                DateTime dateToday = DateTime.Now;
                string date = dateToday.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE dateRegistor =  '{date}' and idcard = '{id}'  and status = 'Pendding'";
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
        /// สำหรับปรับสถานะ
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static bool UpdateStatusAndEPC(jobModels job)
        {
            try
            {
                sql = "UPDATE job " +
                    "SET epc = @epc," +
                    "status = @status " +
                    "WHERE id = @id";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@epc", job.epc));
                cmd.Parameters.Add(new MySqlParameter("@status", job.status));
                cmd.Parameters.Add(new MySqlParameter("@id", job.id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับค้นหาข้อมูลว่าชั่งครบจำนวนหรือยัง
        /// </summary>
        /// <returns></returns>
        public static bool SelectSearchWeight(string rfid)
        {
            try
            {
                DateTime dateToday = DateTime.Now;
                string date = dateToday.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = "SELECT * FROM job a " +
                    "LEFT JOIN jobdetail b " +
                    "ON a.id = b.jobid " +
                    $"WHERE a.dateRegistor = '{date}' and a.status = 'Process' and a.epc = '{rfid}'";

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
    }
}
