using Pinpaida.Common;
using Pinpaida.DataAccess.Stores;
using Pinpaida.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ViewBag.AreaList = HotCityList.List;
            var list = new List<StoreSearchModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Any())
            {
                data = data.Take(request.PageSize).ToList();
                list = StoresAccess.ConvertList(data);
            }
            ViewBag.List = list;
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
            var py = Hz2PyHelper.Convert(word, Encoding.UTF8)?.ToLower();
            var areaModel = StoresAccess.GetAreaFilter(py);
            var brandList = new List<string> { "apple", "huawei", "xiaomi", "oppo", "vivo" };
            var brandName = StoresAccess.GetBrandString(brand);
            var isBrand = brandList.IndexOf(brandName) >= 0;
            var url = isBrand ? $"{brandName}/" : "list/";
            if (areaModel != null && areaModel.AreaType > 0)
            {//带区域的
                if (areaModel.AreaType == 1)
                {
                    url += $"{areaModel.CityNamePy}/";
                }
                else
                {
                    url += $"{areaModel.CityNamePy}/{areaModel.AreaNamePy}/";
                }
            }
            else
            {
                url += $"?word={word}";
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
                list = StoresAccess.ConvertList(data);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
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
