

using System.Drawing;
using System.IO;
using ZXing;

namespace TRUCK_STD.Function
{
    public class Func_GenQrCode
    {
        public static byte[] GenerateQRCode(string text)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 250,
                    Height = 250
                }
            };

            using (Bitmap bitmap = barcodeWriter.Write(text))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }
    }
}
