using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var value = context.Invoices.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateInvoice(int id)
        {
            var value = context.Invoices.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var values = context.Invoices.Find(invoice.InvoiceId);
            values.InvoiceSerialNo = invoice.InvoiceSerialNo;
            values.InvoiceSequenceNo = invoice.InvoiceSequenceNo;
            values.Date = invoice.Date;
            values.TaxOffice = invoice.TaxOffice;
            values.Deliverer = invoice.Deliverer;
            values.Receiver = invoice.Receiver;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailInvoice(int id)
        {
            var values = context.InvoiceItems.Where(x=>x.InvoiceId == id).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInvoiceItem()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem ınvoiceItem)
        {
            context.InvoiceItems.Add(ınvoiceItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}