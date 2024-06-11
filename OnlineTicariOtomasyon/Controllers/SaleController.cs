using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var value = context.Salees.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSalee()
        {
            List<SelectListItem> value = (from x in context.Products.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductId.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name + " " + x.Surname,
                                              Value = x.EmployeeId.ToString()
                                          }).ToList();

            ViewBag.Product = value;
            ViewBag.Current = value2;
            ViewBag.Employee = value3;
            return View();
        }
        [HttpPost]
        public ActionResult AddSalee(Sales sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.Salees.Add(sales);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSale(int id)
        {
            List<SelectListItem> value = (from x in context.Products.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductId.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name + " " + x.Surname,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();

            ViewBag.Product = value;
            ViewBag.Current = value2;
            ViewBag.Employee = value3;

            var values = context.Salees.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSale(Sales sales)
        {
            var values = context.Salees.Find(sales.SalesId);
            values.Date = sales.Date;
            values.ProductId= sales.ProductId;
            values.Custom=sales.Custom;
            values.Price= sales.Price;
            values.TotalAmount=sales.TotalAmount;
            values.CurrentId=sales.CurrentId;
            values.EmployeeId=sales.EmployeeId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleDetail(int id)
        {
            var values = context.Salees.Where(x=>x.SalesId ==id).ToList();
            return View(values);
        }
    }
}