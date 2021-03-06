﻿using Pinpaida.Common;
using Pinpaida.DataAccess;
using Pinpaida.DataAccess.Stores;
using Pinpaida.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Pinpaida.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            var ipCity = IPHelper.GetIPCitys()?.ToLower();
            if (string.IsNullOrEmpty(ipCity) || ipCity == "未知" || ipCity == "内网ip")
            {
                ipCity = "苏州";
            }
            var request = new StoreSearchRequest
            {
                City = ipCity,
                PageSize = 4,
            };
            var list = new List<StoreSearchModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Any())
            {
                data = data.Take(request.PageSize).ToList();
                list = StoresAccess.ConvertList(data);
            }
            ViewBag.List = list;
            ViewBag.AreaList = HotCityList.List;
            return View();
        }

        /// <summary>
        /// 获取店铺详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            var model = StoresAccess.GetStoresDetail(id);
            ViewBag.store = model;
            ViewBag.BrandModel = BrandList.GetModel(model.brand);
            ViewBag.brand = ViewBag.BrandModel.Py;
            var request = new StoreSearchRequest
            {
                City = model.city,
                Brand = ViewBag.BrandModel.Py,
                PageSize = 4,
            };
            var list = new List<StoreSearchModel>();
            var data = StoresAccess.GetStoreList(request);
            if (data != null && data.Any())
            {
                data = data.Where(x => x.Id != id).Take(request.PageSize).ToList();
                list = StoresAccess.ConvertList(data);
            }
            ViewBag.List = list;
            return View();
        }
    }


}
