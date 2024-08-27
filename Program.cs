using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace qr_code_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://documents.hektas.com.tr/";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20 piksel genişlikli modüller

            string filePath = "C:\\Users\\bsevgen\\source\\repos\\qr_code_generator\\repo\\QRCode.png";

            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                qrCodeImage.Save(filePath, ImageFormat.Png);
                Console.WriteLine($"QR kodu '{filePath}' dosyasına kaydedildi.");
            }
            catch (ExternalException ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
