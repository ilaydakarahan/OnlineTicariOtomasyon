﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Models
{
	public class Cascading
	{
		public IEnumerable<SelectListItem> Kategoriler { get; set; }
		public IEnumerable<SelectListItem> Urunler { get; set; }
	}
}