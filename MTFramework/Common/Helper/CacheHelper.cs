using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Caching;
using System.Web;

namespace MT.Common
{
    public class CacheHelper
    {
        public static bool SetCache(string cacheKey, object value, params string[] keyParms)
        {
            string key = string.Format(cacheKey, keyParms);
            CacheInfo cacheInfo = GetCacheInfo(cacheKey);
            if (null == cacheInfo)
            {
                return false;
            }
            //if (cacheInfo.CacheType == "21")//IIS缓存
            //{
            //    HttpContext.Current.Cache.Insert(key, value, null, DateTime.MaxValue, new TimeSpan(0, 0, cacheInfo.CacheTime, 0));
            //}
            //else if (cacheInfo.CacheType == "22")//Memcache缓存
            //{

            //}
            bool res = MemCacheHelper.SetObject(key, value, cacheInfo.CacheTime);
            return res;
        }

        public static bool RemoveCache(string cacheKey, params string[] keyParms)
        {
            string key = string.Format(cacheKey, keyParms);
            bool res = MemCacheHelper.RemoveObject(key);
            return res;
        }

        /// <summary>
        /// 读取缓存配置信息
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        private static CacheInfo GetCacheInfo(string cacheKey)
        {
            const string sql_get = @"select cache_time from sys_cache where cache_key='{0}'";
            CacheInfo cacheInfo = null;
            SqlConnection conn =
                new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString);
            using (conn)
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(string.Format(sql_get, cacheKey), conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cacheInfo = new CacheInfo();
                        
                        cacheInfo.CacheTime = int.Parse(reader["cache_time"].ToString());
                    }
                }
            }
            return cacheInfo;
        }
    }

    class CacheInfo
    {
        public string CacheKey { get; set; }

        public string CacheType { get; set; }

        public int CacheTime { get; set; }
    }
}