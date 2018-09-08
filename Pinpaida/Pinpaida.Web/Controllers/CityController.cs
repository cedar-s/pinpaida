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
        public ActionResult CityIndex(string city, string area)
        {
            var areaModel = new AreaFilteMobdel();
            if (!string.IsNullOrEmpty(area))
            {
                areaModel = StoresAccess.GetAreaFilter(area);
            }
            else if (!string.IsNullOrEmpty(city))
            {
                areaModel = StoresAccess.GetAreaFilter(city);
            }
            if (areaModel == null || areaModel.AreaType == 0)
            {
                return Redirect("/");
            }
            ViewBag.CityName = areaModel?.CityName ?? string.Empty;
            ViewBag.CityPy = areaModel?.CityNamePy ?? string.Empty;
            ViewBag.AreaPy = areaModel?.AreaNamePy ?? string.Empty;
            ViewBag.AreaName = areaModel?.AreaName ?? string.Empty;
            ViewBag.AreaList = HotCityList.List;
            var request = new StoreSearchRequest
            {
                Area = area,
                City = city,
            };
            var cityList = new List<CityBrandModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Count > 0)
            {
                BrandList.List.ForEach(x =>
                {
                    var bData = data.Where(d => d.brand == x.Id).OrderBy(d => d.sortby).ToList();
                    if (bData != null && bData.Count > 0)
                    {
                        var cityModel = new CityBrandModel
                        {
                            Brand = x.Id,
                            BrandName = x.Name,
                            List = new List<StoreSearchModel>()
                        };
                        bData = bData.Take(4).ToList();
                        cityModel.List.AddRange(StoresAccess.ConvertList(bData));
                        cityList.Add(cityModel);
                    }
                });
            }
            ViewBag.CityList = cityList;
            return View();
        }
        public ActionResult CityIndex1(string city)
        {
            ViewData["city"] = "CityIndex1";
            return View();
        }

    }


}
