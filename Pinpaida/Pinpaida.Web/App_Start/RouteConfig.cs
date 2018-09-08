using System.Web.Mvc;
using System.Web.Routing;

namespace Pinpaida.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //品牌首页
            routes.MapRoute(
                name: "brand",
                url: "{brand}",
                defaults: new { controller = "Brand", action = "BrandIndex", brand = UrlParameter.Optional },
                constraints: new { brand = "^apple|huawei|xiaomi|oppo|vivo$" }
            );

            //品牌城市页
            routes.MapRoute(
                name: "brand-1",
                url: "{brand}/{city}",
                defaults: new { controller = "Brand", action = "BrandIndex", brand = UrlParameter.Optional, city = UrlParameter.Optional },
                constraints: new { brand = "^apple|huawei|xiaomi|oppo|vivo$" }
            );

            //品牌城市+区域页
            routes.MapRoute(
                name: "brand-2",
                url: "{brand}/{city}/{area}",
                defaults: new { controller = "Brand", action = "BrandIndex", brand = UrlParameter.Optional, city = UrlParameter.Optional, area = UrlParameter.Optional },
                constraints: new { brand = "^apple|huawei|xiaomi|oppo|vivo$" }
            );
            //列表
            routes.MapRoute(
                name: "list",
                url: "list",
                defaults: new { controller = "Brand", action = "BrandIndex" }
            );
            //城市首页
            routes.MapRoute(
                name: "city",
                url: "list/{city}",
                defaults: new { controller = "City", action = "CityIndex", city = UrlParameter.Optional }
            );

            //区域页
            routes.MapRoute(
                name: "city-1",
                url: "list/{city}/{area}",
                defaults: new { controller = "City", action = "CityIndex1", city = UrlParameter.Optional, area = UrlParameter.Optional }
            );
            //搜索
            routes.MapRoute(
                name: "search",
                url: "search",
                defaults: new { controller = "Brand", action = "Search" }
            );
           

            //商圈页暂不开放
            routes.MapRoute(
                name: "city-1-1",
                url: "list/{city}/{area}/{street}",
                defaults: new { controller = "City", action = "CityIndex", city = UrlParameter.Optional, area = UrlParameter.Optional, street = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Default2",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "controller", action = "action", id = UrlParameter.Optional }
           );
        }
    }
}
