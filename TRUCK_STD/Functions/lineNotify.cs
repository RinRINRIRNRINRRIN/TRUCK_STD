using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace TRUCK_STD.Functions
{
    internal class lineNotify
    {

        public string oder { get; set; }
        public string customer { get; set; }
        public string carNumber { get; set; }  // Continus head and tail
        public string dateIn { get; set; }
        public string timeIn { get; set; }
        public string dateOut { get; set; }
        public string timeOut { get; set; }
        public string weightIn { get; set; }
        public string weightOut { get; set; }
        public string weightNet { get; set; }

        public string ERR { get; set; }

        public async Task<bool> SendApi()
        {
            try
            {
                RestClientOptions restClientOptions = new RestClientOptions("https://notify-api.line.me/api/notify")
                {
                    MaxTimeout = -1,
                };

                RestClient restClient = new RestClient(restClientOptions);
                RestRequest restRequest = new RestRequest("https://notify-api.line.me/api/notify", Method.Post);

                restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                //restRequest.AddHeader("Authorization", "Bearer " + line_token);
                //restRequest.AddParameter("message", messsageSend);
                RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                // ตรวจสอบว่าส่งสำเร็จหรือไม่
                if (restResponse.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }
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
