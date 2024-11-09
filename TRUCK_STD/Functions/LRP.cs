using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace TRUCK_STD.Functions
{
    internal class LRP
    {
        public static string user { get; set; }
        public static string pass { get; set; }
        public static string ip { get; set; }
        public static string port { get; set; }
        public static string[] option { get; set; }


        /// <summary>
        /// สำหรับการเชื่อมต่อกล้อง
        /// </summary>
        /// <param name="vlc"></param>
        public static async Task<bool> SetCamera(VlcControl vlc)
        {
            vlc.SetMedia(new Uri($"rtsp://{user}:{pass}@{ip}:{port}"), option);
            vlc.Play();
            bool isConnect = false;
            while (true)
            {
                if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing)
                {
                    isConnect = true;
                    break;
                }
                else if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended)
                {
                    isConnect = false;
                    break;
                }
                await Task.Delay(1000);
            }
            if (!isConnect)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// สำหรับหยุดการเชื่อมต่อ
        /// </summary>
        /// <param name="vlc"></param>
        public static void Stop(VlcControl vlc)
        {
            vlc.Stop();
        }

        public static bool TakePicture(VlcControl vlc)
        {
            // ตรวจสอบว่าโฟลเดอร์ PictureLPR มีอยู่หรือไม่ หากไม่มีให้สร้างใหม่
            string folderPath = Path.Combine(Application.StartupPath, "PictureLPR");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // นับจำนวนไฟล์ในโฟลเดอร์ PictureLPR
            int count = Directory.GetFiles(folderPath).Length;

            // สร้างชื่อไฟล์ตามวันที่และจำนวนไฟล์
            string yy = DateTime.Now.ToString("yy", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
            string MM = DateTime.Now.ToString("MM", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
            string dd = DateTime.Now.ToString("dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
            string fileName = $"{yy}{MM}{dd}_{count + 1}.png";  // นับไฟล์แล้วเพิ่ม 1
            string path = Path.Combine(folderPath, fileName);

            // บันทึกรูปภาพ
            if (!vlc.TakeSnapshot(path))
            {
                return false;
            }

            return true;
        }
    }
}
