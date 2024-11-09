﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace TRUCK_STD.Functions
{
    internal class CCTV
    {
        public string user { get; set; }
        public string pass { get; set; }
        public string ip { get; set; }
        public string port { get; set; }
        public string[] option { get; set; }

        public async Task<bool> SetCamera(VlcControl vlc)
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

        public async Task Stop(VlcControl vlc)
        {
            vlc.Stop();
            await Task.Delay(1000);
        }

        public bool TakePicture(VlcControl vlc)
        {
            // ตรวจสอบว่าโฟลเดอร์ PictureLPR มีอยู่หรือไม่ หากไม่มีให้สร้างใหม่
            string folderPath = Path.Combine(Application.StartupPath, "PictureCCTV");
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
