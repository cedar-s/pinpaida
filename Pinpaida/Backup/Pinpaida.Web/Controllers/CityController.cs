using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Pinpaida.Web.Controllers
{
    public class CityController : Controller
    {
        public ActionResult CityIndex(string city)
        {
			ViewData["city"] = city;
            return View();
        }
  

    }


}
