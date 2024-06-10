using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var value = db.Departments.Where(x => x.Status == true).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            department.Status = true;
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var value = db.Departments.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            var value = db.Departments.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            var values = db.Departments.Find(department.DepartmentId);
            values.DepartmentName = department.DepartmentName;
            department.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id)
        {
            var values = db.Employees.Where(x => x.DepartmentId == id).ToList();
            var name = db.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.Ad = name;

            return View(values);
        }

        public ActionResult DepartmentSales(int id)
        {
            var values = db.Salees.Where(x=>x.EmployeeId == id).ToList();
            var name = db.Employees.Where(x=>x.EmployeeId == id).Select(y => y.Name).FirstOrDefault();
            ViewBag.employee = name;
            return View(values);
        }
    }
}