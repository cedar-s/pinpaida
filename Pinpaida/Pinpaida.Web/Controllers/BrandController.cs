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
        public ActionResult BrandIndex(string brand, string city, string area,string key)
        {
            ViewData["brand"] = brand;
            ViewData["city"] = city;
            ViewData["area"] = area;
            var request = new StoreSearchRequest {
                Area=area,
                Brand=brand,
                City=city,
                PageSize=4,
                SearchKey= key
            };
            var list = new List<StoreSearchModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Any())
            {
                data = data.Take(request.PageSize).ToList();
                list = ConvertList(data);
            }
            ViewBag.List = list;
            return View();
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
