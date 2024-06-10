using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var value = db.Products.Where(x=>x.Status==true).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> category = (from x in db.Categories.ToList()   //category nesnesi liste türünde.
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName, //görünen kısım
                                                 Value = x.CategoryId.ToString()    //arka planda kaydolan kısım
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            product.Status = true;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = db.Products.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {            
            List<SelectListItem> category = (from x in db.Categories.ToList()   
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName, 
                                                 Value = x.CategoryId.ToString()    
                                             }).ToList();
            ViewBag.category = category;
            var value = db.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = db.Products.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.ImageUrl = product.ImageUrl;
            value.Brand = product.Brand;
            value.Stock = product.Stock;
            value.PurchasePrice = product.PurchasePrice;
            value.SalePrice = product.SalePrice;
            value.Status = true;
            value.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}