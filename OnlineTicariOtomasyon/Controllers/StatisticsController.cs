using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var value = context.Currents.Count().ToString();
            ViewBag.d1 = value;

            var product = context.Products.Count().ToString();
            ViewBag.d2 = product;

            var employee = context.Employees.Count().ToString();
            ViewBag.d3 = employee;

            var category = context.Categories.Count().ToString();
            ViewBag.d4 = category;

            var stock = context.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = stock;

            var brand = (from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = brand;

            var critical = context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = critical;

            var maxproduct = (from x in context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = maxproduct;

            var minproduct = (from x in context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = minproduct;

            var beyazesya = context.Products.Count(x => x.CategoryId == 1).ToString();
            ViewBag.d10 = beyazesya;

            var tv = context.Products.Count(x => x.CategoryId == 5).ToString();
            ViewBag.d11 = tv;

            var maxbrand = context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = maxbrand;     //En çok ürünü bulunan marka.Markaya göre gruplandır,counta(yani sayısına göre) göre azalan olarak sırala.
                                        //en üstteki değeri yani keyi getir.

            var topSeller = context.Salees.GroupBy(m => m.Product.ProductName).OrderByDescending
            (m => m.Sum(x => x.Custom)).Select(m => m.Key).FirstOrDefault().ToString();
            ViewBag.d13 = topSeller;    //Çok satan ürün

            var total = context.Salees.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = total;

            DateTime now = DateTime.Today;
            var values = context.Salees.Count(x => x.Date == now).ToString();
            ViewBag.d15 = values;

            var sales = context.Salees.Where(x => x.Date == now).Sum(y => y.TotalAmount).ToString();
            ViewBag.d16 = sales;

            return View();
        }

        public ActionResult Tables()
        {
            var values = from x in context.Currents
                         group x by x.City into y
                         select new ClassGroup
                         {
                             City = y.Key,
                             Number = y.Count()
                         };
            return View(values.ToList());
        }

    }
}