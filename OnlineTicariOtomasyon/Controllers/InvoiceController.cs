using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{

	[Authorize(Roles = "A")]
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

        public ActionResult Dynamic()
        {
            DynamicInvoice _dynamicInvoice = new DynamicInvoice();
            _dynamicInvoice.value1 = context.Invoices.ToList();
            _dynamicInvoice.value2 = context.InvoiceItems.ToList();
            return View(_dynamicInvoice);
        
        }

        public ActionResult InvoiceSave(string InvoiceSerialNo, string InvoiceSequenceNo, DateTime Date, string TaxOffice,
			string Deliverer, string Receiver, string Total, InvoiceItem[] items)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceSerialNo = InvoiceSerialNo;
            invoice.InvoiceSequenceNo = InvoiceSequenceNo;
            invoice.Date = Date;
            invoice.TaxOffice = TaxOffice;
            invoice.Receiver = Receiver;
            invoice.Deliverer = Deliverer;
            invoice.Total = decimal.Parse(Total);

            context.Invoices.Add(invoice);
            foreach (var x in items)
            {
                InvoiceItem iv = new InvoiceItem();
                iv.Description = x.Description; //iv olan veritabanındaki değeri tutar, x olan dışarıdan gelen parametredeki değeri tutar.
                iv.UnitPrice = x.UnitPrice;
                iv.InvoiceId = x.InvoiceItemId;
                iv.Quantity = x.Quantity;
                iv.TotalAmount = x.TotalAmount;
                context.InvoiceItems.Add(iv);
            
            }

            context.SaveChanges();
            return Json("İşlem Başarılı." , JsonRequestBehavior.AllowGet);
        }
    }
}