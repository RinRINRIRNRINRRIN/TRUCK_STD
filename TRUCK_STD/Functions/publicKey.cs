using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using ZXing;

namespace TRUCK_STD.Functions
{
    internal class publicKey
    {
        // KEY ID
        string keyId = "MRQD8";

        // ข้อมูลที่ต้องการเข้ารหัส
        public static string content = "กข1234 31/10/24 09:41:50 36,560kg 31/10/24 09:55:10 16,000kg";

        // Public Key
        string _publicKey = @"
-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDJfwamBzJ25StkJEt8mnWwNB8z
F5/iLrPe/Lg6ZYlFjf0jqfnvXA2z5cuJ02vFIGu5Kp1VDyBGDq0J5RCRqm7VPZlc
Fb7HyUBIRAvo0jcBvplofQPn+oaSCnmQ4rPUpVJWWlxKqdYSIhqk50GkgeX7zWm0
aQnj0OsFs3Siw4gt+QIDAQAB 
-----END PUBLIC KEY-----";


        public Bitmap GetQRcodePublicKey()
        {
            // เข้ารหัสข้อมูล
            string encryptedBase64 = EncryptWithPublicKey(_publicKey, content);

            // URL Encode ข้อมูลที่เข้ารหัสแล้ว
            string urlEncodedString = HttpUtility.UrlEncode(encryptedBase64);

            // แสดง URL สุดท้าย
            string finalUrl = $"https://cbwm-online.com/api/ts/d?k={keyId}&p={urlEncodedString}";
            Console.WriteLine("Generated URL:");
            Console.WriteLine(finalUrl);

            return GenerateQRCode(finalUrl);
        }


        public string GetUrlPublicKey()
        {
            // เข้ารหัสข้อมูล
            string encryptedBase64 = EncryptWithPublicKey(_publicKey, content);

            // URL Encode ข้อมูลที่เข้ารหัสแล้ว
            string urlEncodedString = HttpUtility.UrlEncode(encryptedBase64);

            // แสดง URL สุดท้าย
            string finalUrl = $"https://cbwm-online.com/api/ts/d?k={keyId}&p={urlEncodedString}";
            Console.WriteLine("Generated URL:");
            Console.WriteLine(finalUrl);

            return finalUrl;
        }



        string EncryptWithPublicKey(string publicKey, string content)
        {
            // อ่าน Public Key ด้วย BouncyCastle
            AsymmetricKeyParameter keyParameter = ReadPublicKeyFromPem(publicKey);

            // ใช้ RSAEngine สำหรับการเข้ารหัส
            var rsaEngine = new Pkcs1Encoding(new RsaEngine());
            rsaEngine.Init(true, keyParameter);

            // แปลงข้อมูลที่ต้องเข้ารหัสเป็น byte[]
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(content);

            // เข้ารหัสข้อมูล
            byte[] encryptedData = rsaEngine.ProcessBlock(dataToEncrypt, 0, dataToEncrypt.Length);

            // แปลงข้อมูลที่เข้ารหัสเป็น Base64
            return Convert.ToBase64String(encryptedData);
        }

        AsymmetricKeyParameter ReadPublicKeyFromPem(string publicKey)
        {
            using (var stringReader = new StringReader(publicKey))
            {
                var pemReader = new PemReader(stringReader);
                return (AsymmetricKeyParameter)pemReader.ReadObject();
            }
        }


        Bitmap GenerateQRCode(string content)
        {
            // สร้าง BarcodeWriter สำหรับ QR Code
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 300,
                    Margin = 1
                }
            };

            // คืนค่าเป็น Bitmap ของ QR Code
            return barcodeWriter.Write(content);
        }
    }
}

