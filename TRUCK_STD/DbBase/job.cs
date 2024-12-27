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
        /// สำหรับเจน OrderId และบันทึกไปที่ main table
        /// </summary>
        /// <param name="licenseHead"></param>
        /// <param name="licenseTail"></param>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="weightIn"></param>
        static string GenOrderNumberAndSaveJob()
        {
            string job = "";
            try
            {
                string yy = DateTime.Now.ToString("yy", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                string MM = DateTime.Now.ToString("MM", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                string DD = DateTime.Now.ToString("dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE jobOrder LIKE '{registy.system.stationName}{yy}{MM}{DD}-%'";
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
                    int conutStr = tb.Rows.Count + 1;
                    switch (conutStr.ToString().Length)
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

                job = orderJob;

            }
            catch (Exception ex)
            {
                return "";
            }
            return job;
        }

        /// <summary>
        /// ค้นหาทะเบียนรถค้างชั่งที่ยังไม่เสร็จทั้งหมด
        /// </summary>
        /// <returns></returns>
        public static bool selectOrderProcess()
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = "SELECT * FROM truckdata.job a " +
                    "LEFT JOIN truckdata.jobdetail b " +
                    "ON b.jobOrder = a.jobOrder " +
                    "LEFT JOIN truckdata.customer c " +
                    "ON c.customerName = a.customerName " +
                    "LEFT JOIN truckdata.product d " +
                    "ON d.productName = a.productName " +
                    $"WHERE  a.state = 'Process' and a.dateRegistor BETWEEN '{date} 00:00:00' and '{date} 23:59:59' and stationName = '{registy.system.stationName}'";

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

        /// <summary>
        /// ค้นหาทะเบียนรถค้างชั่งที่ยังไม่เสร็จเฉพาะทะเบียนนั้น
        /// </summary>
        /// <returns></returns>
        private static string selectOrderProcessWithLicensePlate(string licensePlate)
        {
            string id = "";
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = "SELECT * FROM truckdata.job a " +
                    "LEFT JOIN truckdata.jobdetail b " +
                    "ON a.jobOrder = b.jobOrder " +
                    $"WHERE  a.state = 'Process' and a.dateRegistor BETWEEN '{date} 00:00:00' and '{date} 23:59:59' and a.stationName = '{registy.system.stationName}' and a.licenseHead = '{licensePlate}'";

                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);

                foreach (DataRow rw in tb.Rows)
                {
                    id = rw["jobOrder"].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return "";
            }
            return id;
        }

        /// <summary>
        /// สำหรับบันทึกแบบปกติไม่มีรูป ไม่มีกล้อง
        /// </summary>
        /// <param name="licenseHead">ทะเบียนหัว</param>
        /// <param name="licenseTail">ทะเบียนท้าย</param>
        /// <param name="customerId">รหัสลูกค้า</param>
        /// <param name="productId">รหัสสินค้า</param>
        /// <returns></returns>
        public static bool AddNewOrder(string licenseHead, string licenseTail, string customerId, string productId, string weightIn)
        {
            try
            {
                #region Insert Job
                string orderJob = GenOrderNumberAndSaveJob();

                if (string.IsNullOrWhiteSpace(orderJob))
                {
                    sql = "INSERT INTO truckdata.job (jobOrder,stationName,licenseHead,licenseTail,note,dateRegistor,state,customerId,productId,netWeight)" +
                                         "VALUES(@jobOrder,@stationName,@licenseHead,@licenseTail,@note,current_timestamp(),@state,@customerId,@productId,@netWeight)";

                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.Add(new MySqlParameter("@jobOrder", orderJob));
                    cmd.Parameters.Add(new MySqlParameter("@stationName", registy.system.stationName));
                    cmd.Parameters.Add(new MySqlParameter("@licenseHead", licenseHead));
                    cmd.Parameters.Add(new MySqlParameter("@licenseTail", licenseTail));
                    cmd.Parameters.Add(new MySqlParameter("@note", "-"));
                    cmd.Parameters.Add(new MySqlParameter("@state", "Process"));
                    cmd.Parameters.Add(new MySqlParameter("@customerId", customerId));
                    cmd.Parameters.Add(new MySqlParameter("@productId", productId));
                    cmd.Parameters.Add(new MySqlParameter("@netWeight", "0"));
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }
                #endregion


                #region Insert Jobdetail
                // SelectIdJob
                string id = selectOrderProcessWithLicensePlate(licenseHead);

                // AddNewJobDetail
                if (!jobDetail.InsertNewOrderdetail(id, "ชั่งเข้า", int.Parse(weightIn), "", "", ""))
                {
                    return false;
                }
                #endregion

            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับบันทึกไม่มีกล้องแต่มีราคา
        /// </summary>
        /// <param name="licenseHead"></param>
        /// <param name="licenseTail"></param>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="weightIn"></param>
        /// <param name="productPrice"></param>
        /// <returns></returns>
        public static bool AddNewOrder(string licenseHead, string licenseTail, string customerId, string productId, string weightIn, string productPrice)
        {
            try
            {
                #region Insert Job


                string orderJob = GenOrderNumberAndSaveJob();

                if (!string.IsNullOrWhiteSpace(orderJob))
                {
                    sql = "INSERT INTO truckdata.job (jobOrder,stationName,licenseHead,licenseTail,note,dateRegistor,state,customerName,productName,productPrice,netWeight)" +
                                       "VALUES(@jobOrder,@stationName,@licenseHead,@licenseTail,@note,current_timestamp(),@state,@customerName,@productName,@productPrice,@netWeight)";

                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.Add(new MySqlParameter("@jobOrder", orderJob));
                    cmd.Parameters.Add(new MySqlParameter("@stationName", registy.system.stationName));
                    cmd.Parameters.Add(new MySqlParameter("@licenseHead", licenseHead));
                    cmd.Parameters.Add(new MySqlParameter("@licenseTail", licenseTail));
                    cmd.Parameters.Add(new MySqlParameter("@note", "-"));
                    cmd.Parameters.Add(new MySqlParameter("@state", "Process"));
                    cmd.Parameters.Add(new MySqlParameter("@customerName", customerId));
                    cmd.Parameters.Add(new MySqlParameter("@productName", productId));
                    cmd.Parameters.Add(new MySqlParameter("@productPrice", productPrice));
                    cmd.Parameters.Add(new MySqlParameter("@netWeight", "0"));
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }
                #endregion

                #region Insert JobDetail
                // SelectIdJob
                string _id = selectOrderProcessWithLicensePlate(licenseHead);

                // AddNewJobDetail
                if (!jobDetail.InsertNewOrderdetail(_id, "ชั่งเข้า", int.Parse(weightIn), "", "", ""))
                {
                    ERR = jobDetail.ERR;
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับบันทึกแบบมีแต่กล้อง
        /// </summary>
        /// <param name="licenseHead"></param>
        /// <param name="licenseTail"></param>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="weightIn"></param>
        /// <param name="pictureLicense"></param>
        /// <param name="pictureCarFront"></param>
        /// <param name="pictrueCarBack"></param>
        /// <returns></returns>
        public static bool AddNewOrder(string licenseHead, string licenseTail, string customerId, string productId, string weightIn, string pictureLicense, string pictureCarFront, string pictrueCarBack)
        {
            try
            {
                #region Insert Job
                string orderJob = GenOrderNumberAndSaveJob();

                if (string.IsNullOrWhiteSpace(orderJob))
                {
                    sql = "INSERT INTO truckdata.job (jobOrder,stationName,licenseHead,licenseTail,note,dateRegistor,state,customerId,productId,netWeight)" +
                                         "VALUES(@jobOrder,@stationName,@licenseHead,@licenseTail,@note,current_timestamp(),@state,@customerId,@productId,@netWeight)";

                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.Add(new MySqlParameter("@jobOrder", orderJob));
                    cmd.Parameters.Add(new MySqlParameter("@stationName", registy.system.stationName));
                    cmd.Parameters.Add(new MySqlParameter("@licenseHead", licenseHead));
                    cmd.Parameters.Add(new MySqlParameter("@licenseTail", licenseTail));
                    cmd.Parameters.Add(new MySqlParameter("@note", "-"));
                    cmd.Parameters.Add(new MySqlParameter("@state", "Process"));
                    cmd.Parameters.Add(new MySqlParameter("@customerId", customerId));
                    cmd.Parameters.Add(new MySqlParameter("@productId", productId));
                    cmd.Parameters.Add(new MySqlParameter("@netWeight", "0"));
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }

                #endregion

                // SelectIdJob
                string id = selectOrderProcessWithLicensePlate(licenseHead);

                // AddNewJobDetail
                if (!jobDetail.InsertNewOrderdetail(id, "ชั่งเข้า", int.Parse(weightIn), pictureLicense, pictureCarFront, pictrueCarBack))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับบันทึกแบบมีแต่กล้องและมีราคา
        /// </summary>
        /// <param name="licenseHead"></param>
        /// <param name="licenseTail"></param>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="weightIn"></param>
        /// <param name="pictureLicense"></param>
        /// <param name="pictureCarFront"></param>
        /// <param name="pictrueCarBack"></param>
        /// <returns></returns>
        public static bool AddNewOrder(string licenseHead, string licenseTail, string customerId, string productId, string productPrice, string weightIn, string pictureLicense, string pictureCarFront, string pictrueCarBack)
        {
            try
            {
                #region Insert Job
                string orderJob = GenOrderNumberAndSaveJob();

                if (!string.IsNullOrWhiteSpace(orderJob))
                {
                    sql = "INSERT INTO truckdata.job (jobOrder,stationName,licenseHead,licenseTail,note,dateRegistor,state,customerId,productId,productPrice,netWeight)" +
                                         "VALUES(@jobOrder,@stationName,@licenseHead,@licenseTail,@note,current_timestamp(),@state,@customerId,@productId,@productPrice,@netWeight)";

                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.Add(new MySqlParameter("@jobOrder", orderJob));
                    cmd.Parameters.Add(new MySqlParameter("@stationName", registy.system.stationName));
                    cmd.Parameters.Add(new MySqlParameter("@licenseHead", licenseHead));
                    cmd.Parameters.Add(new MySqlParameter("@licenseTail", licenseTail));
                    cmd.Parameters.Add(new MySqlParameter("@note", "-"));
                    cmd.Parameters.Add(new MySqlParameter("@state", "Process"));
                    cmd.Parameters.Add(new MySqlParameter("@customerId", customerId));
                    cmd.Parameters.Add(new MySqlParameter("@productId", productId));
                    cmd.Parameters.Add(new MySqlParameter("@productPrice", productPrice));
                    cmd.Parameters.Add(new MySqlParameter("@netWeight", "0"));
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return false;
                }

                #endregion

                // SelectIdJob
                string id = selectOrderProcessWithLicensePlate(licenseHead);

                // AddNewJobDetail
                if (!jobDetail.InsertNewOrderdetail(id, "ชั่งเข้า", int.Parse(weightIn), pictureLicense, pictureCarFront, pictrueCarBack))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                Console.WriteLine(ERR);
                return false;
            }
            return true;
        }

        public static bool SelectId(int id)
        {
            try
            {
                sql = $"SELECT * FROM job a " +
                    $"LEFT JOIN customer b " +
                    $"ON a.customerId = b.id " +
                    $"LEFT JOIN product c " +
                    $"ON a.productId = c.id " +
                    $"LEFT JOIN jobdetail d " +
                    $"ON a.id = d.jobId " +
                    $" WHERE a.id = {id}";
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

        public static bool SelectHistory()
        {
            try
            {
                sql = "SELECT id,dateRegistor,jobOrder,licenseHead,licenseTail,netWeight,state FROM truckdata.job";
                da = new MySqlDataAdapter(sql, con);
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
        /// สำหรับอัพเดทสถานะรถ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state">สถานะที่ต้องการอัพเดท</param>
        /// <returns></returns>
        public static bool updateStatusWeightIn(int id, string state, string newWeith)
        {
            try
            {
                sql = "UPDATE job " +
                   "SET state = @state," +
                   "netWeight = @netWeight, " +
                   "WHERE id = @id";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@state", state));
                cmd.Parameters.Add(new MySqlParameter("@netWeight", newWeith));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"updatestate {ex.Message}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับอัพเดทสถานะรถ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state">สถานะที่ต้องการอัพเดท</param>
        /// <returns></returns>
        public static bool updateStatusWeightOut(string id, string state, double newWeith, double impurity, double huminity, double powder, string priceOther, double priceNet)
        {
            try
            {
                sql = "UPDATE job " +
                   "SET state = @state," +
                   "netWeight = @netWeight, " +
                   "powderPercent = @powderPercent, " +
                   "impurityPercent = @impurityPercent, " +
                   "huminityPercent = @huminityPercent, " +
                   "priceOther = @priceOther, " +
                   "priceNet = @priceNet " +
                   "WHERE jobOrder = @id";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@state", state));
                cmd.Parameters.Add(new MySqlParameter("@netWeight", newWeith));
                cmd.Parameters.Add(new MySqlParameter("@powderPercent", powder));
                cmd.Parameters.Add(new MySqlParameter("@impurityPercent", impurity));
                cmd.Parameters.Add(new MySqlParameter("@huminityPercent", huminity));
                cmd.Parameters.Add(new MySqlParameter("@priceOther", priceOther));
                cmd.Parameters.Add(new MySqlParameter("@priceNet", priceNet));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"updatestate {ex.Message}");
                return false;
            }
            return true;
        }


        /// <summary>
        /// ปรับสถานะเป็นยกเลิกที่หน้าประวัติการชั่งเมื่อผู้ใช้กด ลบ
        /// </summary>
        /// <param name="id">เลขที่ออเดอร์ที่ต้องการจะยกเลิก</param>
        /// <returns></returns>
        public static bool updateStataWhenDelete(string id)
        {
            try
            {
                sql = $"UPDATE truckdata.job " +
                    $"SET state = @state " +
                    $"WHERE jobOrder = @jobOrder";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@state", "Cancel"));
                cmd.Parameters.Add(new MySqlParameter("@jobOrder", id));
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
        /// สำหรับลบ เลขที่การชั่ง
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool deleteOrdet(string id)
        {
            try
            {
                // delete orderdetail
                if (!jobDetail.DeleteOrder(id))
                {
                    return false;
                }

                sql = $"DELETE FROM truckdata.job WHERE jobOrder = '{id}'";
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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
        /// สำหรับเอาข้อมูลไปปร้ินตั่ซ
        /// </summary>
        /// <param name="id">เลขที่ id ทีต้องการพิมพ์</param>
        /// <returns></returns>
        public static bool selectForPrint(string id)
        {
            try
            {
                sql = $"SELECT * FROM truckdata.job a " +
                    $"LEFT JOIN truckdata.jobdetail b " +
                    $"ON a.id = b.jobId " +
                    $"LEFT JOIN truckdata.customer c " +
                    $"ON c.id = a.customerId " +
                    $"LEFT JOIN truckdata.product d " +
                    $"ON d.id = a.productId " +
                    $"WHERE a.id = {id}";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }




        //-----------------------------------------------------------------------------------------


        /// <summary>
        /// For search licensePlate
        /// </summary>
        /// <param name="license">ทะเบียนรถ</param>
        /// <returns></returns>
        public static bool selectLicensePlate(string license)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE licenseHead = '{license}' and state = 'Process' and dateRegistor = '{date}'";
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
        /// ค้นหาข้อมูล order ทั้งหมดในวันนั้น ทุกสถานะ
        /// </summary>
        /// <returns></returns>
        public static bool selectOrderToday()
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM truckdata.job WHERE dateRegistor = '{date}'";
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
        /// สำหรับค้นหาทะเบียนรถที่ลงทะเบียนไว้แล้ว
        /// </summary>
        /// <param name="license"></param>
        /// <returns></returns>
        public static bool selectLicensePlatePendding(string license)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM job WHERE licenseHead = '{license}' and state = 'Pendding' and dateRegistor = '{date}'";
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
        /// สำหรับค้นหาทะเบียนรถที่กำลังชั่งหรือทำรายการ ใช้สำหรับจุดลงทะเบียน
        /// </summary>
        /// <param name="license"></param>
        /// <returns></returns>
        public static bool selectLicensePlateProcess(string license)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                sql = $"SELECT * FROM truckdata.job WHERE licenseHead = '{license}' and state = 'Process'";
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
        /// สำหรับอัพเดทสถานะเมื่อชั่งออก
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool updateStatus(int id)
        {
            try
            {
                sql = "UPDATE job " +
                   "SET state = @state " +
                   "WHERE id = @id";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@state", "Success"));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"updatestate {ex.Message}");
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับลงทะเบียนรถคันใหม่
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="fullname"></param>
        /// <param name="licenseHead"></param>
        /// <param name="licenseTail"></param>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static bool AddNewRegistor(string idCard, string fullname, string licenseHead, string licenseTail, int customerId, int productId)
        {
            try
            {
                sql = "INSERT INTO truckdata.job(jobOrder,stationName,idCard,epc,fullname,licenseHead,licenseTail,objective,dateRegistor,state,customerId,productId,netWeight)" +
                                        "VALUES(@jobOrder,@stationName,@idCard,@epc,@fullname,@licenseHead,@licenseTail,@objective,current_date(),@state,@customerId,@productId,@netWeight)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobOrder", "-"));
                cmd.Parameters.Add(new MySqlParameter("@stationName", "-"));
                cmd.Parameters.Add(new MySqlParameter("@idCard", idCard));
                cmd.Parameters.Add(new MySqlParameter("@epc", "-"));
                cmd.Parameters.Add(new MySqlParameter("@fullname", fullname));
                cmd.Parameters.Add(new MySqlParameter("@licenseHead", licenseHead));
                cmd.Parameters.Add(new MySqlParameter("@licenseTail", licenseTail));
                cmd.Parameters.Add(new MySqlParameter("@objective", "-"));
                cmd.Parameters.Add(new MySqlParameter("@state", "Process"));
                cmd.Parameters.Add(new MySqlParameter("@customerId", customerId));
                cmd.Parameters.Add(new MySqlParameter("@productId", productId));
                cmd.Parameters.Add(new MySqlParameter("@netWeight", 0));
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
                    "SET jobOrder = @jobOrder," +
                    "station = @station " +
                    "WHERE id = @id";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@jobOrder", orderJob));
                cmd.Parameters.Add(new MySqlParameter("@station", registy.system.stationName));
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




    }
}
