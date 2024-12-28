using Bunifu.UI.WinForms;
using Serilog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TRUCK_STD.Design;
using TRUCK_STD.Functions;
namespace TRUCK_STD.Function
{
    class Func_Main
    {

        // ตัวแปร ฐานข้อมูล
        private static Image picReport;

        #region Program Start up
        /// <summary>
        /// ใช้สำหรับเช็คที่อยู่ log ว่ามีอยู่ในเครื่องหรือไม่
        /// </summary>
        /// <returns></returns>
        public static bool CHECK_FILE_LOG()
        {
            try
            {
                DateTime dateTime = DateTime.Now;

                int day = dateTime.Day;
                int month = dateTime.Month;
                int year = dateTime.Year;

                string datETime = day + "-" + month + "-" + year;

                if (!File.Exists(datETime))
                {
                    using (File.Create(Application.StartupPath + datETime + ".txt"))
                    {

                    }
                }

                Log.Logger = new LoggerConfiguration()
                        .WriteTo.File(datETime + ".txt")
                        .CreateLogger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// ใช้สำหรับเช็คว่าโปรแกรมเปิดซ้ำหรือไม่
        /// </summary>
        /// <returns></returns>
        public static bool CHECK_PROGRAM()
        {
            try
            {
                // Get ข้อมูลโปรแกรม
                Process[] processes = Process.GetProcessesByName("TRUCK_STD");
                // ถ้าโปรแกรมที่ชื่อ KPOS มากกว่า 1 
                if (processes.Length > 1)
                {
                    Log.Warning("มีโปรแกรมเปิดอยู่แล้ว");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("CHECK_PROGRAM " + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ใช้สำหรับ GEN รหัสติดตั้งโปรแกรม และ แก้ไขหัวตั๋ว หลังจากติดตั้งเสร็จ
        /// </summary>
        /// <param name="key">เลขที่ SM,SS,SO</param>
        /// <returns></returns>
        public static string GEN_PASSWORD_INSTALL(string key)
        {
            string MD5Key = "";
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string DateMD5 = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));

                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(key + "PGM" + DateMD5));

                    StringBuilder sBuilder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    MD5Key = sBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GEN_PASSWORD_I " + ex.Message);
                return "ERROR";
            }
            return MD5Key;
        }

        /// <summary>
        /// สำหรับ GEN รหัสเพื่อปลดล็อคฟังชั่นนั้น ๆ  รวมถึงการปลดล็อคโปรแกรม
        /// </summary>
        /// <param name="key">เลขที่ SS,SM,SO</param>
        /// <param name="extension">ประเภทฟังชั่น LINE,API,LOGIN,PRICE,LOCK</param>
        /// <returns></returns>
        public static string GEN_PASSWORD_EXTENSION(string key, string extension)
        {
            string MD5Key = "";
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string DateMD5 = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));

                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(key + extension + DateMD5));

                    StringBuilder sBuilder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    MD5Key = sBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GEN_PASS_E " + ex.Message);
                return "ERROR";
            }
            return MD5Key;
        }

        /// <summary>
        /// สำหรับเช็ค วันหมดอายุโปรแกรม
        /// </summary>
        /// <param name="passExpDate">รหัสที่ลูกค้าคีย์เข้มา</param>
        /// <returns></returns>
        public static string CHECK_EXPRIE_DATE(string passExpDate)
        {
            string dateDecry = "";
            try
            {
                // ทำการ GEN รหัสถาวร โดยจะใช้หลักจาก และนำรหัสที่ผู้ใช้คีย์เข้ามาว่า ตรงกันหรือไม่
                string dateForeverMD5 = GEN_PASSWORD_EXTENSION(registy.system.id, "DATE_FOREVER");
                Console.WriteLine(dateForeverMD5);
                if (passExpDate == dateForeverMD5)
                {
                    // ถ้าหาก รหัสเหมือนกันนั้นหมายความว่าเป็นรหัส ถาวร              
                    return "FOREVER";
                }
                else
                {
                    Int64 passConvert64 = Int64.Parse(passExpDate);
                    // แต่หากไม่เหมือนกันให้นำรหัสมา decrypt เพื่อดูว่าหมดอายุวันที่เท่าไหร่
                    Int64 keyUnloak = passConvert64 / 1932;
                    string dayDecrypt = "";
                    // ถ้าเท่ากับ 8 คือ dd/MM/yyyy
                    if (Convert.ToString(keyUnloak).Length == 8)
                    {
                        dayDecrypt = Convert.ToString(keyUnloak);
                        // แต่ถ้าวันหมดอายุ ยังไม่เลย หรือ เท่ากับวันนี้ ให้บันทึกวันหมดอายุ ตามวันปัจจุบัน
                        string b = Convert.ToString(dayDecrypt).Substring(0, 2);
                        string c = Convert.ToString(dayDecrypt).Substring(2, 2);
                        string d = Convert.ToString(dayDecrypt).Substring(4, 4);
                        // กำหนดวันหมดอายุที่ตัวแปรก
                        dateDecry = b + "/" + c + "/" + Convert.ToString(int.Parse(d) + 543);
                        Console.WriteLine(keyUnloak);
                    }
                    // ถ้าเท่ากับ 7 คือ d/MM/yyyy
                    else if (Convert.ToString(keyUnloak).Length == 7)
                    {
                        dayDecrypt = "0" + Convert.ToString(keyUnloak);
                        string b = Convert.ToString(dayDecrypt).Substring(0, 2);
                        string c = Convert.ToString(dayDecrypt).Substring(2, 2);
                        string d = Convert.ToString(dayDecrypt).Substring(4, 4);
                        // กำหนดวันหมดอายุที่ตัวแปรก
                        dateDecry = b + "/" + c + "/" + Convert.ToString(int.Parse(d) + 543);
                        Console.WriteLine(0 + keyUnloak);
                    }

                    //DateTime aa = DateTime.Parse(dateDecry);
                    ////string bbb = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                    //string bbb = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                    //DateTime bb = DateTime.Parse(bbb);

                    //// ตรวจสอบว่ารหัสที่ได้มาหมดอายุหรือยัง
                    //if (aa < bb)
                    //{
                    //    Log.Warning("รหัสหมดอายุ");
                    //    Console.WriteLine("รหัสหมดอายุ");
                    //    return "";
                    //}
                }
            }
            catch (Exception ex)
            {

                Log.Error("FuncMain CHECK_EXPRIE_DATE " + ex.Message);
                return "";
            }
            return dateDecry;
        }

        /// <summary>
        /// ใช้สำหรับเช็ค textbox ที่คีย์เข้ามาห้ามให้มีตัวอักษรให้มีเฉพาะตัวเลข เท่านั้น
        /// </summary>
        /// <param name="sender">Object ที่จะเช็ค</param>
        /// <param name="e">Event</param>
        /// <param name="frm">ฟอร์ม</param>
        public static void CHECK_CHARATER_KEY_NUMBER_ONLY(object sender, KeyPressEventArgs e, Form frm)
        {
            try
            {
                // ทำการเสร้าง Messagebox ใหม่
                BunifuSnackbar msg = new BunifuSnackbar();
                // ตรวจสอบไม่ให้ คีย์ค่าอืนเข้ามา
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    msg.Show(frm, "กรุณากรอกเฉพาะตัวเลข เท่านั้น", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    e.Handled = true; // ไม่อนุญาตให้ป้อนตัวอักษรที่ไม่ใช่ตัวเลข
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR MAIN FUNCTION 16 " + ex.Message);
            }
        }

        /// <summary>
        /// ใช้สำหรับเช็ค textbox ที่คีย์เข้ามาห้ามให้มีตัวอักษรให้มีเฉพาะตัวเลข เท่านั้น
        /// </summary>
        /// <param name="sender">Object ที่จะเช็ค</param>
        /// <param name="e">Event</param>
        /// <param name="frm">ฟอร์ม</param>
        public static void CHECK_CHARATER_KEY_NUMBER_AND_DOT(object sender, KeyPressEventArgs e, Form frm)
        {
            try
            {
                // ทำการเสร้าง Messagebox ใหม่
                BunifuSnackbar msg = new BunifuSnackbar();
                // ตรวจสอบไม่ให้ คีย์ค่าอืนเข้ามา
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    msg.Show(frm, "กรุณากรอกเฉพาะตัวเลข เท่านั้น", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    e.Handled = true; // ไม่อนุญาตให้ป้อนตัวอักษรที่ไม่ใช่ตัวเลข
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR MAIN FUNCTION 16 " + ex.Message);
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace("-", ""); // Remove hyphens if present
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }

        /// <summary>
        /// สำหรับเช็คโปรแกรม พ.ศ. และ ค.ศ.
        /// </summary>
        /// <returns></returns>
        public static bool CHECK_DATE_COMPUTER_YEAR()
        {
            try
            {
                // ทำการตรวจสอบว่า คอมพิวเตอร์ให้ format วันที่อะไร ต้องใช้ format TH เท่านั้น
                string dateTime = DateTime.Now.ToString("yyyy");
                int a = (int.Parse(dateTime) - 543);
                if (a < 2000)
                {
                    // หมายถึงคอมเครื่องนี้ ตั้งเป็น ค.ศ.
                    Log.Error("รูปแบบวันที่ผิด year :" + a);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncMain CHECK_DATE_COMPUTER : " + ex.Message);
                Log.Error("FuncMain CHECK_DATE_COMPUTER : " + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับเช็ค  วันที่คอมพิวเตอร์ ห้ามย้อนกลับวันที่คอมพิวเตอร์
        /// </summary>
        /// <returns></returns>
        public static bool CHECK_DATE_PROGRAM_AND_DATE_COMPUTER()
        {
            try
            {
                DateTime dateProgram = DateTime.Parse(registy.system.date);
                string a = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                DateTime dateComputer = DateTime.Parse(a);

                // เปรียบเทียบวันที่  วันที่คอมพิวเตอร์ ห้ามน้อยกว่าวันที่โปรแกรม
                if (dateComputer < dateProgram)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncMain CHECK_DATE_PROGRAM_AND_DATE_COMPUTER : " + ex.Message);
                Log.Error("FuncMain CHECK_DATE_PROGRAM_AND_DATE_COMPUTER : " + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับโชว์ messageAlertFrom
        /// </summary>
        /// <param name="AlertLevel">ระดับข้อความ 0,1,2,</param>
        public static void SHOW_FROM_ALERT(int AlertLevel, string messageAlert)
        {
            frmProgramMessageAlert frm = new frmProgramMessageAlert();

            switch (AlertLevel)
            {
                case 0: // โปรแกรมหมดอายุใช้งาน demo
                    frm.messageAlert = messageAlert;
                    frm.alertLevel = 0;
                    break;
                case 1: // alert ปลดล็อคโปรแกรมทั่วไป
                    frm.messageAlert = messageAlert;
                    frm.alertLevel = 1;
                    break;
                case 2: // โปรแกรมหมดอายุใช้งาน ใช้งานจริง
                    frm.messageAlert = messageAlert;
                    frm.alertLevel = 2;
                    break;

            }

            frm.ShowDialog();
            if (!frm.chckUnlock)
            {
                Application.Exit();
            }

        }
        #endregion


    }
}


