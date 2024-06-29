using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
	public class EmployeeController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> department = (from x in context.Departments.ToList()   
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName, 
                                                 Value = x.DepartmentId.ToString()    
                                             }).ToList();
            ViewBag.department = department;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if(Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);  //Dosya adını aldı.
                string extension = Path.GetExtension(Request.Files[0].FileName);    //Uzantısını aldı.
                string image = "~/Images/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(image));
                employee.ImageUrl ="/Images/" + filename + extension;
            }

            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            List<SelectListItem> department = (from x in context.Departments.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentId.ToString()
                                               }).ToList();
            ViewBag.department = department;
            var value = context.Employees.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);  //Dosya adını aldı.
                string extension = Path.GetExtension(Request.Files[0].FileName);    //Uzantısını aldı.
                string image = "~/Images/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(image));
                employee.ImageUrl = "/Images/" + filename + extension;
            }

            var values = context.Employees.Find(employee.EmployeeId);
            values.Name = employee.Name;
            values.Surname = employee.Surname;
            values.ImageUrl = employee.ImageUrl;
            values.DepartmentId = employee.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}