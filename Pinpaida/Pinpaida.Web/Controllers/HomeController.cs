using Pinpaida.DataAccess;
using Pinpaida.DataAccess.Stores;
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

            return View();
        }
              
        /// <summary>
        /// 获取店铺详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public ActionResult Detail(int id)
        {
            ViewBag.store = StoresAccess.GetStoresDetail(id);
            return View();
        }
    }


}
