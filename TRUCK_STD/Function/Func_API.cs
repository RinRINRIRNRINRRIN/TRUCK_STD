using RestSharp;
using Serilog;
using System;
using System.Configuration;
using System.Threading.Tasks;
using TRUCK_STD.Functions;
namespace TRUCK_STD.Function
{
    class Func_API
    {
        public static string para_order { get; set; }

        public static string para_dateIn { get; set; }
        public static string para_timeIn { get; set; }
        public static string para_dateOut { get; set; }
        public static string para_timeOut { get; set; }
        public static string para_carRegistration { get; set; }
        public static string para_product { get; set; }
        public static string para_company { get; set; }
        public static string para_wghIn { get; set; }
        public static string para_wghOut { get; set; }
        public static string para_wghNet { get; set; }
        public static string para_price { get; set; }
        public static string para_priceNet { get; set; }
        public static string para_mode { get; set; }


        /// <summary>
        /// สำหรับส่งข้อมูลไปหา API โดยจะส่งเมื่อมีการชั่งเสร็จ 1 ครั้งเท่านั้น
        /// </summary>
        /// <param name="para_order">เลขที่ออเดอร์</param>
        /// <param name="para_dateIn">วันที่ชั่งเข้า</param>
        /// <param name="para_timeIn">เวลาชั่งเข้า</param>
        /// <param name="para_dateOut">วันที่ชั่งออก</param>
        /// <param name="para_timeOut">เวลาชั่งออก</param>
        /// <param name="para_carRegistration">ทะเบียนรถ</param>
        /// <param name="para_product">สินค้า</param>
        /// <param name="para_company">ชื่อลูกค้า</param>
        /// <param name="para_wghIn">น้ำหนักชั่งเข้า</param>
        /// <param name="para_wghOut">น้ำหนักชั่งออก</param>
        /// <param name="para_wghNet">น้ำหนักสุทธิ์</param>
        /// <param name="para_price">ราคาสินค้าต่อ กก.</param>
        /// <param name="para_priceNet">ราคาสุทธิ์</param>
        /// <returns>true or false</returns>
        public async static Task<bool> SEND_DATA_API()
        {
            string API_URL = ConfigurationManager.AppSettings["API_URL"];
            // ตรวจสอบก่อนว่ากำหนดค่าให้กับ API หรือไม่
            if (API_URL == "")
            {
                return false;
            }

            try
            {
                RestClientOptions restClientOptions = new RestClientOptions(API_URL)
                {
                    MaxTimeout = -1,
                };

                RestClient restClient = new RestClient(restClientOptions);
                RestRequest restRequest = new RestRequest(API_URL, Method.Post);
                restRequest.Timeout = 5000;
                restRequest.AddHeader("Content-Type", "application/json");

                string body = "";
                // ตรวจสอบก่อนว่า โปรแกรมมีฟัง่ชั่นคำนวนราคาหรือไม่
                if (registy.function.PRICE == "TRUE")
                {
                    body = "{||:||,|para_order|:|" + para_order + "|," +
                    "|para_dateIn|:|" + para_dateIn + "|," +
                    "|para_timeIn|:|" + para_timeIn + "|," +
                    "|para_dateOut|:|" + para_dateOut + "|," +
                    "|para_timeOut|:|" + para_timeOut + "|," +
                    "|para_carRegistration|:|" + para_carRegistration + "|," +
                    "|para_product|:|" + para_product + "|," +
                    "|para_company|:|" + para_company + "|," +
                    "|para_wghIn|:|" + para_wghIn + "|," +
                    "|para_wghOut|:|" + para_wghOut + "|," +
                    "|para_wghNet|:|" + para_wghNet + "|," +
                    "|para_price|:|" + para_price + "|," +
                    "|para_priceNet|:|" + para_priceNet + "|}";
                }
                else
                {
                    body = "{|para_order|:|" + para_order + "|," +
                   "|para_dateIn|:|" + para_dateIn + "|," +
                   "|para_timeIn|:|" + para_timeIn + "|," +
                   "|para_dateOut|:|" + para_dateOut + "|," +
                   "|para_timeOut|:|" + para_timeOut + "|," +
                   "|para_carRegistration|:|" + para_carRegistration + "|," +
                   "|para_product|:|" + para_product + "|," +
                   "|para_company|:|" + para_company + "|," +
                   "|para_wghIn|:|" + para_wghIn + "|," +
                   "|para_wghOut|:|" + para_wghOut + "|," +
                   "|para_wghNet|:|" + para_wghNet + "|}";
                }
                // แปรกข้อความเป็นรูปแบบ JSON
                string bodyToJson = body.Replace('|', '"');
                restRequest.AddStringBody(bodyToJson, DataFormat.Json);

                RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Log.Error("ส่งข้อมูล API ไม่สำเร็จ " + API_URL);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API 01 " + ex.Message);
                Log.Error("SEND_DATA_APOI " + API_URL + " " + ex.Message);
                return false;
            }
            return true;
        }



        public async static Task<bool> SEND_DATA_API_HW()
        {
            string API_URL = ConfigurationManager.AppSettings["API_URL"];
            // ตรวจสอบก่อนว่ากำหนดค่าให้กับ API หรือไม่
            if (API_URL == "")
            {
                return false;
            }

            try
            {
                RestClientOptions restClientOptions = new RestClientOptions(API_URL)
                {
                    MaxTimeout = -1,
                };

                RestClient restClient = new RestClient(restClientOptions);
                RestRequest restRequest = new RestRequest(API_URL, Method.Post);
                restRequest.Timeout = 5000;
                restRequest.AddHeader("Content-Type", "application/json");

                string body = "";
                // ตรวจสอบก่อนว่า โปรแกรมมีฟัง่ชั่นคำนวนราคาหรือไม่
                if (registy.function.PRICE == "TRUE")
                {
                    body = "{|para_mode|:|" + para_mode + "|," +
                    "|para_order|:|" + para_order + "|," +
                    "|para_dateIn|:|" + para_dateIn + "|," +
                    "|para_timeIn|:|" + para_timeIn + "|," +
                    "|para_dateOut|:|" + para_dateOut + "|," +
                    "|para_timeOut|:|" + para_timeOut + "|," +
                    "|para_carRegistration|:|" + para_carRegistration + "|," +
                    "|para_product|:|" + para_product + "|," +
                    "|para_company|:|" + para_company + "|," +
                    "|para_wghNet|:|" + para_wghNet + "|," +
                    "|para_price|:|" + para_price + "|," +
                    "|para_priceNet|:|" + para_priceNet + "|";
                }
                else
                {
                    body = "{|para_mode|:|" + para_mode + "|," +
                   "|para_order|:|" + para_order + "|," +
                   "|para_dateIn|:|" + para_dateIn + "|," +
                   "|para_timeIn|:|" + para_timeIn + "|," +
                   "|para_dateOut|:|" + para_dateOut + "|," +
                   "|para_timeOut|:|" + para_timeOut + "|," +
                   "|para_carRegistration|:|" + para_carRegistration + "|," +
                   "|para_product|:|" + para_product + "|," +
                   "|para_company|:|" + para_company + "|," +
                   "|para_wghNet|:|" + para_wghNet + "|}";
                }
                // แปรกข้อความเป็นรูปแบบ JSON
                string bodyToJson = body.Replace('|', '"');
                restRequest.AddStringBody(bodyToJson, DataFormat.Json);

                RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Log.Error("ส่งข้อมูล API ไม่สำเร็จ " + API_URL);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API 01 " + ex.Message);
                Log.Error("SEND_DATA_APOI " + API_URL + " " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
