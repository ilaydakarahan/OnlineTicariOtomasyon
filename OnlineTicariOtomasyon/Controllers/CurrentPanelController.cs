using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CurrentPanelController : Controller
    {
        Context db = new Context();
        
        public ActionResult Index()
        {
            var mail = (string)Session["Email"];
            var values = db.Currents.FirstOrDefault(x=>x.Email == mail);
            ViewBag.email = mail;
            return View(values);
        }
        public ActionResult Shop()
        {
            var mail = (string)Session["Email"];
            var id = db.Currents.Where(x => x.Email == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = db.Salees.Where(x => x.CurrentId == id).ToList();
            return View(values);
        }
        public ActionResult CargoTracking(string number)
        {
            var value = from x in db.CargoDetails select x;
            value = value.Where(y => y.TrackingNo.Contains(number));
            return View(value.ToList());
        }

		public ActionResult CurrentCargoTracking(string id)
		{
			var values = db.CargoTrackings.Where(x => x.TrackingNo == id).ToList();
			return View(values);
		}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
	}
}