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
        public ActionResult BrandIndex(string brand, string city, string area)
        {
            ViewData["brand"] = brand;
            ViewData["city"] = city;
            ViewData["area"] = area;

            return View();
        }

        /// <summary>
        /// 列表页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetStoreList(StoreSearchRequest request)
        {
            var list = StoresAccess.GetStoreList(request);
            return Json(list);
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
