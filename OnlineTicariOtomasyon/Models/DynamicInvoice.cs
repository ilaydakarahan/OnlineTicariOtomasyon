using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
	public class DynamicInvoice
	{
		public IEnumerable<Invoice> value1 { get; set;}
		public IEnumerable<InvoiceItem> value2 { get; set;}
	}
}