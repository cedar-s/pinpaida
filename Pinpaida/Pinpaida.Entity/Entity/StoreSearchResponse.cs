using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinpaida.Entity.Entity
{
    /// <summary>
    /// 城市数据
    /// </summary>
    public class CityBrandModel
    {
        public int Brand { get; set; }
        public string BrandName { get; set; }

        public List<StoreSearchModel> List { get; set; }
    }

    public class StoreSearchModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>名称 </summary>
        public string StoreName { get; set; }
        /// <summary>主图 </summary>
        public string MainImage { get; set; }
        /// <summary>品牌 </summary>
        public int brand { get; set; }
        /// <summary>品牌 </summary>
        public string brandName { get; set; }
        /// <summary>品牌认证 </summary>
        public int storeBadges { get; set; }
        /// <summary> 营业时间 </summary>
        public string openTime { get; set; }
        /// <summary> 地址 </summary>
        public string storeAddress { get; set; }
        /// <summary> 电话 </summary>
        public string phoneNumber { get; set; }
        /// <summary> 是否支持预约 </summary>
        public byte apptSchedulerInd { get; set; }


    }

    public class AreaFilteMobdel
    {
        /// <summary>
        /// 1 城市  2 区县
        /// </summary>
        public int AreaType { get; set; }
        /// <summary>
        /// 城市拼音
        /// </summary>
        public string CityNamePy { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 区拼音
        /// </summary>
        public string AreaNamePy { get; set; }
        /// <summary>
        /// 区名称
        /// </summary>
        public string AreaName { get; set; }
    }

    public static class BrandList
    {
        public static List<BrandModel> List = new List<BrandModel>
        {
            new BrandModel{Id=1,Py="apple",Name="苹果" },
            new BrandModel{Id=2,Py="huawei",Name="华为" },
            new BrandModel{Id=4,Py="xiaomi",Name="小米" },
            new BrandModel{Id=5,Py="oppo",Name="OPPO" },
            new BrandModel{Id=6,Py="vivo",Name="VIVO" },
        };
    }
    /// <summary>
    /// 热门城市
    /// </summary>
    public static class HotCityList
    {
        public static List<AreaFilteMobdel> List = new List<AreaFilteMobdel>
        {
            new AreaFilteMobdel{ CityName = "北京", CityNamePy ="beijing",AreaType = 1 },
            new AreaFilteMobdel{ CityName = "上海", CityNamePy ="shanghai", AreaType = 1},
            new AreaFilteMobdel{ CityName = "广州", CityNamePy ="guangzhou", AreaType = 1},
            new AreaFilteMobdel{ CityName = "深圳", CityNamePy ="shenzhen", AreaType = 1},
            new AreaFilteMobdel{ CityName = "杭州", CityNamePy ="杭州", AreaType = 1},
            new AreaFilteMobdel{ CityName = "苏州", CityNamePy ="苏州", AreaType = 1}
        };
    }

    public class BrandModel
    {
        public int Id { get; set; }
        public string Py { get; set; }
        public string Name { get; set; }

    }
}
