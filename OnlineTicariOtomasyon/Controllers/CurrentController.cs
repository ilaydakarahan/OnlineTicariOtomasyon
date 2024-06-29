using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
	public class CurrentController : Controller
    {
        Context context = new Context(); 
        public ActionResult Index()
        {
            var values = context.Currents.Where(x=>x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            current.Status = true;
            context.Currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var value = context.Currents.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCurrent(int id)
        {
            var value = context.Currents.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCurrent(Current current)
        {
            var values = context.Currents.Find(current.CurrentId);
            values.CurrentName = current.CurrentName;
            values.CurrentSurname = current.CurrentSurname;
            values.City = current.City;
            values.Email = current.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailCurrent(int id)
        {
            var values = context.Salees.Where(x=>x.CurrentId == id).ToList();
            return View(values);
        }
    }
}