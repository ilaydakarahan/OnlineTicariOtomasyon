using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        Context c = new Context();

        public ActionResult Graphics()
        {
			ArrayList xvalue = new ArrayList();
			ArrayList yvalue = new ArrayList();
			var sonuc = c.Products.ToList();
			sonuc.ToList().ForEach(x => xvalue.Add(x.ProductName));
			sonuc.ToList().ForEach(x => yvalue.Add(x.Stock));

			var graphics = new Chart(width: 800, height: 800).AddTitle("Kategori - Ürün Stok").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);

			return File(graphics.ToWebImage().GetBytes(), "image/jpeg");        
        }
        public ActionResult Index()
        {          
            return View();
        }
        public List<Graphics> ProductList()
        {
            List<Graphics> graphics = new List<Graphics>();
            graphics = c.Products.Select(x => new Models.Graphics
            {
                urunad = x.ProductName,
                Stok = x.Stock
            }).ToList();

            return graphics;
        }
		public ActionResult VisualizeProductResult()
		{
            return Json(ProductList(), JsonRequestBehavior.AllowGet);   //jsonlı olan metod google charttaki görselleştirmeye ulaşabilmek için kullanılır.
		}

        public ActionResult EmployeeIndex()
        {
            return View();
        }
        public List<EmployeeDep> EmployeeDepList()
        {
            List<EmployeeDep> values = new List<EmployeeDep>();
            values = (from x in c.Employees group x by x.Department.DepartmentName into y select new EmployeeDep
            {
                dep = y.Key,
                number = y.Count()
            }).ToList();

            return values;
        }
        public ActionResult VisualizeEmployeeResult()
        {
			return Json(EmployeeDepList(), JsonRequestBehavior.AllowGet);
		}

	}
}