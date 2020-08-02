using System.Drawing;
using QRCoder;
using static QRCoder.PayloadGenerator;
using System.Drawing.Imaging;
using System.Web;

namespace BikeandBarrel.Services
{
    public class QRService
    {
        public void CreateGuestQR(string Imagepath,string Logopath)
        {
            Url generator = new Url("http://www.madbee.in");
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Image.FromFile(Logopath),20,6);
            //Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.White,true);
            qrCodeAsBitmap.Save(Imagepath, ImageFormat.Png);
        }
    }
}
