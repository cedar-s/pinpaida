using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Pinpaida.Web.Controllers
{
    public class BrandController : Controller
    {
		public ActionResult BrandIndex(string brand, string city, string area)
        {
			ViewData["brand"] = brand;
			ViewData["city"] = city;
			ViewData["area"] = area;

            return View();
        }

    }


}
