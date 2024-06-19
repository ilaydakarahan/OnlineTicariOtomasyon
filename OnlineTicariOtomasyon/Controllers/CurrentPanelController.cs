using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        Context db = new Context();
        [Authorize]
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
    }
}