using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List cs = new List();
            cs.Values1 = context.Products.Where(x=>x.ProductId == 1).ToList();
            cs.Values2 = context.DetailProducts.Where(y=>y.DetailId == 1).ToList();
            return View(cs);
        }
    }
}