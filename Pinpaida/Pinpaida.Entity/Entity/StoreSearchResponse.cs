using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinpaida.Entity.Entity
{
    public class StoreSearchResponse
    {
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
}
