using Pinpaida.Common;
using Pinpaida.Entity.Entity;
using Pinpaida.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinpaida.DataAccess.Stores
{
    public class StoresAccess
    {
        /// <summary>
        /// 获取门店列表
        /// </summary>
        /// <param name="request"></param>
        public static List<StoresModel> GetStoreList(StoreSearchRequest request)
        {
            var list = new List<StoresModel>();
            var bi = GetBrandInt(request.Brand);
            DataTable dt = new DataTable();
            try
            {
                StringBuilder getsql = new StringBuilder();
                getsql.Append(" SELECT * FROM  stores  WHERE  1=1 ");
                if (bi > 0)
                {
                    getsql.Append($" AND  brand = {bi} ");
                }
                if (!string.IsNullOrEmpty(request.City))
                {
                    getsql.Append($" AND  cityPy = '{request.City}' ");
                }
                if (!string.IsNullOrEmpty(request.Area))
                {
                    getsql.Append($" AND  statePy = '{request.Area}' ");
                }
                if (!string.IsNullOrEmpty(request.SearchKey))
                {
                    getsql.Append($" AND  storeName Like '%{request.SearchKey}%' ");
                }

                getsql.Append($" Order by sortby asc ");
                dt = MySqlHelper.Query(getsql.ToString())?.Tables[0];
                list = GetStoresModelList(dt);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        /// <summary>
        /// 门店列表，DataTable转Model
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static StoresModel GetStoresModel(DataTable dt)
        {
            var list = GetStoresModelList(dt);
            return list?.FirstOrDefault();
        }
        /// <summary>
        /// 门店列表，DataTable转List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<StoresModel> GetStoresModelList(DataTable dt)
        {
            var list = new List<StoresModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StoresModel
                    {
                        addDate = ConvertHelper.ToDateTime(dr["addDate"]),
                        apptSchedulerInd = (byte)ConvertHelper.ToInt32(dr["addDate"]),
                        brand = ConvertHelper.ToInt32(dr["brand"]),
                        city = ConvertHelper.ToString(dr["city"]),
                        country = ConvertHelper.ToString(dr["country"]),
                        cityPy = ConvertHelper.ToString(dr["cityPy"]),
                        description = ConvertHelper.ToString(dr["description"]),
                        district = ConvertHelper.ToString(dr["district"]),
                        districtPy = ConvertHelper.ToString(dr["districtPy"]),
                        geoX = ConvertHelper.ToString(dr["geoX"]),
                        geoY = ConvertHelper.ToString(dr["geoY"]),
                        Id = ConvertHelper.ToInt32(dr["Id"]),
                        mainImage = ConvertHelper.ToString(dr["mainImage"]),
                        openTime = ConvertHelper.ToString(dr["openTime"]),
                        phoneNumber = ConvertHelper.ToString(dr["phoneNumber"]),
                        postCode = ConvertHelper.ToString(dr["postCode"]),
                        queueType = ConvertHelper.ToString(dr["queueType"]),
                        regionName = ConvertHelper.ToString(dr["regionName"]),
                        sellProductNames = ConvertHelper.ToString(dr["sellProductNames"]),
                        serviceProductNames = ConvertHelper.ToString(dr["serviceProductNames"]),
                        serviceTypes = ConvertHelper.ToInt32(dr["serviceTypes"]),
                        shipToID = ConvertHelper.ToString(dr["shipToID"]),
                        sortby = ConvertHelper.ToInt32(dr["sortby"]),
                        state = ConvertHelper.ToString(dr["state"]),
                        status = ConvertHelper.ToInt32(dr["status"]),
                        storeAddress = ConvertHelper.ToString(dr["storeAddress"]),
                        storeBadges = ConvertHelper.ToInt32(dr["storeBadges"]),
                        storeEmail = ConvertHelper.ToString(dr["storeEmail"]),
                        storeID = ConvertHelper.ToString(dr["storeID"]),
                        storeImage = ConvertHelper.ToString(dr["storeImage"]),
                        statePy = ConvertHelper.ToString(dr["statePy"]),
                        storeName = ConvertHelper.ToString(dr["storeName"]),
                        storeUrl = ConvertHelper.ToString(dr["storeUrl"]),
                        storeWay = ConvertHelper.ToString(dr["storeWay"]),
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 1-苹果，2-华为，3-三星，4-小米，5-vivo，6-oppo，
        /// 7-魅族，其他按组合来12表示苹果华为，16表示苹果vivo
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static int GetBrandInt(string brand)
        {
            var bi = 0;
            brand = brand?.ToLower() ?? String.Empty;
            bi = BrandList.List.FirstOrDefault(x => x.Py == brand)?.Id ?? 0;
            return bi;
        }

        /// <summary>
        /// 1-苹果，2-华为，3-三星，4-小米，5-vivo，6-oppo，
        /// 7-魅族，其他按组合来12表示苹果华为，16表示苹果vivo
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static string GetBrandString(int brand)
        {
            var bi = string.Empty;
            bi = BrandList.List.FirstOrDefault(x => x.Id == brand)?.Py ?? string.Empty;
            return bi;
        }

        /// <summary>
        /// 关键词匹配区域
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static AreaFilteMobdel GetAreaFilter(string word)
        {
            var areaModel = new AreaFilteMobdel();
            StringBuilder getsql = new StringBuilder();
            getsql.Append(" SELECT  * FROM  stores  WHERE  1=1 ");
            getsql.Append($" AND  ( cityPy = '{word}' or city='{word}')  Limit 1; ");
            var dt = MySqlHelper.Query(getsql.ToString())?.Tables[0];
            var model = GetStoresModel(dt);
            if (model != null && model.Id > 0)
            {
                areaModel = new AreaFilteMobdel
                {
                    AreaName = string.Empty,
                    AreaNamePy = string.Empty,
                    CityName = model.city,
                    CityNamePy = model.cityPy,
                    AreaType = 1
                };
                return areaModel;
            }
            getsql = new StringBuilder();
            getsql.Append(" SELECT  * FROM  stores  WHERE  1=1 ");
            getsql.Append($" AND  ( districtPy = '{word}' or district='{word}')  Limit 1; ");
            dt = MySqlHelper.Query(getsql.ToString())?.Tables[0];
            model = GetStoresModel(dt);
            if (model != null && model.Id > 0)
            {
                areaModel = new AreaFilteMobdel
                {
                    AreaName = model.district,
                    AreaNamePy = model.districtPy,
                    CityName = model.city,
                    CityNamePy = model.cityPy,
                    AreaType = 2
                };
                return areaModel;
            }
            return null;
        }
    }
}
