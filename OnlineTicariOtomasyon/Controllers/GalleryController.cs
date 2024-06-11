using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context context= new Context();
        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}