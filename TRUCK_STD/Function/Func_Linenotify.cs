using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace TRUCK_STD.Function
{
    class Func_Linenotify
    {

        /// <summary>
        /// 1.สร้างตัวแปรสำหรับเก็บ Array Objectgr เพื่อจะต้องสร้างตัวแปรก่อนทำการส่งไปหาไลน์
        /// </summary>
        public static Dictionary<string, string> parameters = new Dictionary<string, string>();

        /// <summary>
        /// 2.หลังจากมีการกำหนดตัวแปร parameters แล้วจะทำการส่ง Api
        /// </summary>
        /// <returns></returns>
        public async static Task<bool> SEND_LINE_NOTIFY()
        {
            try
            {
                //ดึงค่ารูปแบบที่จะส่ง Line Notify ของผู้ใช้มาก่อน
                string formatCustomer = ConfigurationManager.AppSettings["Line_message"];
                // แยกคำออกก่อนเพื่อจะได้แทนค่าง่ายๆ  
                string[] formatSplit = formatCustomer.Split('\r');
                // สร้างตัวแปรเพื่อรองรับ ข้อมูลที่ถูกแทนค่าแล้ว
                string[] messageRequest = formatSplit;
                // ทำการกำหนดค่าโดยการ ลูปหาคำและแทนค่าคำ


                for (int i = 0; i < formatSplit.Length; i++)
                {
                    while (formatSplit[i].Contains("@"))
                    {
                        foreach (var para in parameters)
                        {
                            // หาคำที่เหมือนและแทนค่าลงไป 
                            if (formatSplit[i].Contains(para.Key))
                            {
                                messageRequest[i] = formatSplit[i].Replace(para.Key, para.Value);
                                Console.WriteLine(messageRequest[i]);
                                formatSplit[i] = formatSplit[i].Replace(para.Key, para.Value);
                                Console.WriteLine(formatSplit[i]);
                                break;
                            }
                        }
                    }
                }

                string messsageSend = "";
                foreach (string element in messageRequest)
                {
                    messsageSend += element;
                }



                // เมื่อจบลูปการทำงานก็ให้นำข้อความที่ถูกแทนค่าแล้วส่งไปหา api 
                string line_token = ConfigurationManager.AppSettings["Line_token"];

                RestClientOptions restClientOptions = new RestClientOptions("https://notify-api.line.me/api/notify")
                {
                    MaxTimeout = -1,
                };

                RestClient restClient = new RestClient(restClientOptions);
                RestRequest restRequest = new RestRequest("https://notify-api.line.me/api/notify", Method.Post);

                restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Authorization", "Bearer " + line_token);
                restRequest.AddParameter("message", messsageSend);
                RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                // ตรวจสอบว่าส่งสำเร็จหรือไม่
                if (restResponse.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
