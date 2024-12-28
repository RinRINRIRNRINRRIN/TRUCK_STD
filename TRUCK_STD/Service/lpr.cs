using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace TRUCK_STD.Service
{
    internal class lpr
    {
        public static string licens1 { get; set; }
        public static string licens2 { get; set; }
        public static string licenPlate1 { get; set; }
        public static string licenPlate2 { get; set; }
        public static string Picture1 { get; set; }
        public static string Picture2 { get; set; }

        /// <summary>
        /// Check API
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CheckAPI()
        {
            try
            {
                var options = new RestClientOptions("http://192.168.1.100:1234")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/testApi/", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("TEST API " + ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check cam have a car
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static async Task<bool> CheckLicenPlate(string ip)
        {
            try
            {
                var options = new RestClientOptions($"http://{ip}:8000")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/cgi-bin/set.cgi?random=0.5874662150022185", Method.Post);
                request.AddHeader("Content-Type", "text/plain");
                var body = @"key=capture";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                Console.WriteLine(response.StatusCode);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
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
        /// <summary>
        /// For read data form Server
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static async Task<bool> GetLicensPlate(string ip)
        {
            try
            {

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var options = new RestClientOptions("http://192.168.1.100:1234")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"/get-licensePlate/?ipcam={ip}", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return false;
                }

                JObject kay = JObject.Parse(response.Content);
                if (kay["plate_num"].ToString() == "NoLicensePlate")
                {
                    return false;
                }


                if (kay["cam_ip"].ToString() == ip)
                {
                    licens1 = kay["plate_num"].ToString();

                    licenPlate1 = kay["closeup_pic"].ToString().Replace('-', '+');
                    licenPlate1 = licenPlate1.Replace('_', '/');
                    licenPlate1 = licenPlate1.Replace('.', '=');

                    Picture1 = kay["picture"].ToString().Replace('-', '+');
                    Picture1 = Picture1.Replace('_', '/');
                    Picture1 = Picture1.Replace('.', '=');
                }
                else if (kay["cam_ip"].ToString() == ip)
                {
                    licens2 = kay["plate_num"].ToString();

                    licenPlate2 = kay["closeup_pic"].ToString().Replace('-', '+');
                    licenPlate2 = licenPlate2.Replace('_', '/');
                    licenPlate2 = licenPlate2.Replace('.', '=');

                    Picture2 = kay["picture"].ToString().Replace('-', '+');
                    Picture2 = Picture2.Replace('_', '/');
                    Picture2 = Picture2.Replace('.', '=');
                }
                stopwatch.Stop();
                Console.WriteLine("TIME GET AND REPLANE IMAGE : " + stopwatch.Elapsed.TotalSeconds);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// For set data form API
        /// </summary>
        /// <param name="ip">ไอพีที่ต้องการ</param>
        /// <returns></returns>
        public static async Task ResetLicensePlate(string ip)
        {
            try
            {
                var options = new RestClientOptions($"http://192.168.1.100:1234")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"/reset/?ipcam={ip}", Method.Post);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
            }
            catch (Exception ex)
            {

            }
        }



    }
}
