using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Index(string code)
		{
            //QR KOD EKLEME METODU
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap image = karekod.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
			return View();
		}

	}
}