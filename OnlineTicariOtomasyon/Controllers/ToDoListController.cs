using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var value = db.Currents.Count().ToString();
            ViewBag.currents=value;
            var value2 = db.Products.Count().ToString();
            ViewBag.products=value2;
            var value3 = db.Categories.Count().ToString();
            ViewBag.categories=value3;
            var value4 = (from x in db.Currents select x.City).Distinct().Count().ToString();
            ViewBag.city = value4;


            var list = db.ToDoLists.ToList();
            return View(list);
        }
    }
}