using Pinpaida.DataAccess;
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

        public JsonResult GetMysql() {
            DataTable dt = new DataTable();
            StringBuilder getsql = new StringBuilder();
            getsql.AppendFormat(@"select DISTINCT a1.Longitude,a1.Latitude
                            from area a
                            inner join area a1 on a1.parentcode=a.regioncode
                            where a.RegionCode in ('530000','540000','610000','620000','630000','640000','650000')");
            dt = MySqlHelper.Query(getsql.ToString()).Tables[0];
            return Json(dt);
        }

        public ActionResult Demo() {
            ViewBag.Controller = "Admin";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
              
		public ActionResult Detail()
        {
            return View();
        }
    }


}
