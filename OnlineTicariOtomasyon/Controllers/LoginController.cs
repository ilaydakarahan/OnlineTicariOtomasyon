using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult CurrentRegister()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult CurrentRegister(Current current)
        {
            db.Currents.Add(current);
            db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin(Current current)
        {
            var value = db.Currents.FirstOrDefault(x=>x.Email == current.Email && x.CurrentPassword == current.CurrentPassword);
            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Email, false);
                Session["Email"] = value.Email.ToString();
                return RedirectToAction("Index" , "CurrentPanel");             
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var values = db.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else { return RedirectToAction("Index" , "Login" ); }
        }

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Index", "Login");
		}
	}
}