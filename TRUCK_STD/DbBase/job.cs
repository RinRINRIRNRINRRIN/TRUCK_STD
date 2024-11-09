using MySql.Data.MySqlClient;
using System;
using System.Data;
using TRUCK_STD.Functions;

namespace TRUCK_STD.DbBase
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
        /// For select order status is process
        /// </summary>
        /// <returns></returns>
        public static bool selectOrderProcess()
        {
            try
            {
                sql = "SELECT * FROM truckdata.job a " +
                    "LEFT JOIN jobdetail b " +
                    "ON a.id = b.jobId " +
                    $"WHERE a.status = 'Process' and a.stationName = '{registy.system.stationName}'";
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
        /// For search licensePlate
        /// </summary>
        /// <param name="license">ทะเบียนรถ</param>
        /// <returns></returns>
        public static bool selectLicensePlate(string license)
        {
            try
            {
                sql = $"SELECT * FROM job WHERE licenseHead = '{license}' and status = 'Process'";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);

            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับอัพเดทเลขที่การชั่งเมื่อชั่งเข้าเท่านั้น
        /// </summary>
        /// <param name="id">id order</param>
        /// <returns></returns>
        public static bool updatejobNumber(int id)
        {
            try
            {
                // นำสถานีชั่งไปค้นหาว่าลำดับที่เท่าไหร่
                string yy = DateTime.Now.ToString("yy", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                string MM = DateTime.Now.ToString("MM", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                string DD = DateTime.Now.ToString("dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE jobOrder LIKE '{registy.system.stationName}{yy}{MM}{DD}-'";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);

                string orderJob = $"{registy.system.stationName}{yy}{MM}{DD}-";
                // เช็คข้อมูลที่ได้
                if (tb.Rows.Count == 0)
                {
                    orderJob += "001";
                }
                else
                {
                    string conutStr = tb.Rows.Count.ToString();
                    switch (conutStr.Length)
                    {
                        case 1:
                            orderJob += $"00{tb.Rows.Count + 1}";
                            break;
                        case 2:
                            orderJob += $"0{tb.Rows.Count + 1}";
                            break;
                        case 3:
                            orderJob += $"{tb.Rows.Count + 1}";
                            break;
                    }
                }

                // อัพเดทข้อมูล jobOrder
                sql = "UPDATE job " +
                    "SET jobOrder = @jobOrder " +
                    "WHERE id = @id";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobOrder", orderJob));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("updatejobNumber | " + ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับอัพเดทสถานะเมื่อชั่งออก
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool updateStatus(int id)
        {
            try
            {
                sql = "UPDATE job " +
                   "SET status = @status " +
                   "WHERE id = @id";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@status", "Success"));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"updateStatus {ex.Message}");
                return false;
            }
            return true;
        }

    }
}
