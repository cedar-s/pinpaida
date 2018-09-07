using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinpaida.Entity.Model
{
    public class StoresModel
    {
        /// <summary>Id </summary>
        public int Id { get; set; }
        /// <summary>店铺ID </summary>
        public string storeID { get; set; }
        /// <summary>上级ID，没有可不写 </summary>
        public string shipToID { get; set; }
        /// <summary> 是否支持维修预约</summary>
        public Byte apptSchedulerInd { get; set; }
        /// <summary>预约维修产品内容 </summary>
        public string queueType { get; set; }
        /// <summary>店铺名称 </summary>
        public string storeName { get; set; }
        /// <summary> 店铺网址</summary>
        public string storeUrl { get; set; }
        /// <summary> 店铺邮箱</summary>
        public string storeEmail { get; set; }
        /// <summary>店铺电话 </summary>
        public string phoneNumber { get; set; }
        /// <summary>店铺地址 </summary>
        public string storeAddress { get; set; }
        /// <summary>区县 </summary>
        public string district { get; set; }
        /// <summary>区县拼音 </summary>
        public string districtPy { get; set; }
        /// <summary>城市 </summary>
        public string city { get; set; }
        /// <summary> 城市拼音</summary>
        public string cityPy { get; set; }
        /// <summary> 省份</summary>
        public string state { get; set; }
        /// <summary> 省份拼音</summary>
        public string statePy { get; set; }
        /// <summary> 邮编</summary>
        public string postCode { get; set; }
        /// <summary>国家编码统一CN</summary>
        public string country { get; set; }
        /// <summary> 洲统一ASIA</summary>
        public string regionName { get; set; }
        /// <summary>经度 </summary>
        public string geoX { get; set; }
        /// <summary>纬度 </summary>
        public string geoY { get; set; }
        /// <summary>服务产品内容 </summary>
        public string serviceProductNames { get; set; }
        /// <summary>销售产品内容 </summary>
        public string sellProductNames { get; set; }
        /// <summary>现场、接机点，可不填  </summary>
        public int serviceTypes { get; set; }
        /// <summary>1-官方普通授权，3-官方优质授权，5-官方直营，4-网站认证，9-未知店，默认1\r\n </summary>
        public int storeBadges { get; set; }
        /// <summary>营业时间 </summary>
        public string openTime { get; set; }
        /// <summary> 店铺图片，只存图片名称逗号隔开</summary>
        public string storeImage { get; set; }
        /// <summary>交通方式 </summary>
        public string storeWay { get; set; }
        /// <summary>新增时间 </summary>
        public DateTime addDate { get; set; }
        /// <summary> 没有可不填</summary>
        public string description { get; set; }
        /// <summary> 主图</summary>
        public string mainImage { get; set; }
        /// <summary>1-苹果，2-华为，3-三星，4-小米，5-vivo，6-oppo，7-魅族，其他按组合来12表示苹果华为，16表示苹果vivo </summary>
        public int brand { get; set; }
        /// <summary>越小越靠前默认50 </summary>
        public int sortby { get; set; }
        /// <summary> 状态，默认0不可用</summary>
        public int status { get; set; }

    }
}
