using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context db = new Context();
        public ActionResult Index(string search)
        {
            var values = from x in db.CargoDetails select x;
			if (!string.IsNullOrEmpty(search))
			{
				values = values.Where(y=>y.TrackingNo.Contains(search));
			}
            return View(values.ToList());
        }


		[HttpGet]
        public ActionResult AddCargo()
        {
			string randomString = Guid.NewGuid().ToString().Substring(0, 10);
			ViewBag.trackingNumber = randomString;

			return View();
        }
        [HttpPost]
		public ActionResult AddCargo(CargoDetail cargoDetail)
		{
            db.CargoDetails.Add(cargoDetail);
            db.SaveChanges();
			return RedirectToAction("Index");
		}


		//public static string TakipKoduUret()
		//{
		//	char[] chars = new char[62];
		//	chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
		//	byte[] data = new byte[1];
		//	using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
		//	{
		//		crypto.GetNonZeroBytes(data);
		//		data = new byte[6];
		//		crypto.GetNonZeroBytes(data);
		//	}
		//	StringBuilder result = new StringBuilder(6);
		//	foreach (byte b in data)
		//	{
		//		result.Append(chars[b % (chars.Length)]);
		//	}			
		//	return result.ToString();
		//}

		public ActionResult CargoTakip(string id)
		{
			var values = db.CargoTrackings.Where(x=>x.TrackingNo == id).ToList();
			return View(values);
		}
	}
}