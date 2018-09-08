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
    public class BrandController : Controller
    {
        public ActionResult BrandIndex(string brand, string city, string area, string word)
        {
            ViewData["brand"] = brand;
            ViewData["city"] = city;
            ViewData["area"] = area;
            ViewData["word"] = word;
            ViewBag.BrandModel = BrandList.List.FirstOrDefault(x => x.Py == brand);
            ViewBag.BrandName = ViewBag.BrandModel?.Name ?? string.Empty;
            var request = new StoreSearchRequest
            {
                Area = area,
                Brand = brand,
                City = city,
                PageSize = 4,
                SearchKey = word
            };
            var areaList = new List<AreaFilteMobdel>();
            var list = new List<StoreSearchModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Any())
            {
                data.ForEach(x =>
                {
                    var a = new AreaFilteMobdel
                    {
                        AreaType = 1,
                        CityName = x.city,
                        CityNamePy = x.cityPy
                    };
                    var a2 = areaList.FirstOrDefault(al => al.CityNamePy == x.cityPy);
                    if (a2 == null)
                    {
                        areaList.Add(a);
                    }
                });
                data = data.Take(request.PageSize).ToList();
                list = ConvertList(data);
            }
            ViewBag.List = list;
            ViewBag.AreaList = areaList;
            return View();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public RedirectResult Search(int brand, string word)
        {
            var areaModel = StoresAccess.GetAreaFilter(word);
            var url = string.Empty;
            var brandList = new List<string> { "apple", "huawei", "xiaomi", "oppo", "vivo" };
            var brandName = StoresAccess.GetBrandString(brand);
            var isBrand = brandList.IndexOf(brandName) >= 0;
            if (areaModel != null && areaModel.AreaType > 0)
            {//带区域的
                if (areaModel.AreaType == 1)
                {
                    url = $"list/{areaModel.CityNamePy}/";
                }
                else
                {
                    url = $"list/{areaModel.CityNamePy}/{areaModel.AreaNamePy}/";
                }
                if (isBrand) url += $"brand={brandName}";
            }
            else if (isBrand)
            {//"?word={word}"
                url = $"{brandName}/?word={word}";
            }
            else
            {
                url = $"list/?word={word}";
            }

            return Redirect(url);
        }

        /// <summary>
        /// 列表页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetStoreList(StoreSearchRequest request)
        {
            var list = new List<StoreSearchModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Any())
            {
                data = data.Take(request.PageSize).ToList();
                list = ConvertList(data);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// List转获
        /// </summary>
        /// <param name="data"></param>
        private static List<StoreSearchModel> ConvertList(List<Entity.Model.StoresModel> data)
        {
            var list = new List<StoreSearchModel>();
            if (data != null && data.Any())
            {
                list.AddRange(data.Select(x => new StoreSearchModel
                {
                    apptSchedulerInd = x.apptSchedulerInd,
                    brand = x.brand,
                    brandName = "",
                    Id = x.Id,
                    MainImage = x.mainImage,
                    openTime = x.openTime,
                    phoneNumber = x.phoneNumber,
                    storeAddress = x.storeAddress,
                    storeBadges = x.storeBadges,
                    StoreName = x.storeName
                }));
            }
            return list;
        }

        #region 列表页

        /// <summary>
        /// 列表页
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="city"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public ActionResult List(string brand, string city, string area)
        {
            ViewData["brand"] = brand;
            ViewData["city"] = city;
            ViewData["area"] = area;

            return View();
        }
        #endregion

    }


}
