using Pinpaida.DataAccess.Stores;
using Pinpaida.Entity.Entity;
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
        public ActionResult CityIndex(string city, string area, string brand)
        {
            ViewData["city"] = "hahah";
            if (!string.IsNullOrEmpty(brand))
            {
                ViewBag.BrandModel = BrandList.List.FirstOrDefault(x => x.Py == brand);
                ViewBag.BrandName = ViewBag.BrandModel?.Name ?? string.Empty;
            }
            var areaModel = new AreaFilteMobdel();
            if (!string.IsNullOrEmpty(area))
            {
                areaModel = StoresAccess.GetAreaFilter(area);
            }
            ViewBag.CityName = areaModel?.CityName ?? string.Empty;
            ViewBag.AreaName = areaModel?.AreaNamePy ?? string.Empty;
            return View();
        }
        public ActionResult CityIndex1(string city)
        {
            ViewData["city"] = "CityIndex1";
            return View();
        }

    }


}
