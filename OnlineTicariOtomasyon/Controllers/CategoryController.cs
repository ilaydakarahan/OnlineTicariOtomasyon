using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var values = context.Categories.ToList().ToPagedList(sayfa,4);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var values = context.Categories.Find(category.CategoryId);
            values.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductCategoryList()
        {

			Cascading cascading = new Cascading();
			cascading.Kategoriler = new SelectList(context.Categories, "CategoryId", "CategoryName");
			cascading.Urunler = new SelectList(context.Products, "ProductId", "ProductName");
			return View(cascading);
		}

        public JsonResult UrunGetir(int p)
        {
            var urunlist = (from x in context.Products
                            join y in context.Categories
                            on  x.CategoryId equals y.CategoryId
                            where x.CategoryId == p
                            select new
                            {
                                Text = x.ProductName,
                                Value = x.ProductId.ToString()
                            }).ToList();
            return Json(urunlist, JsonRequestBehavior.AllowGet);
        }
    }
}