using Serilog;
using System;
using System.Security.Cryptography;
using System.Text;

namespace TRUCK_STD.Functions
{
    internal class md5
    {
        public static string _key_programNumber { get; set; }
        public static string _key_type { get; set; }


        public static string GEN_MD5()
        {
            string MD5Key = "";
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string DateMD5 = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));

                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_key_programNumber + _key_type + DateMD5));

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
    }
}
