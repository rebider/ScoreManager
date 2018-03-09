
//*****************************************************************
//
// File Name:   CacheDal.cs
//
// Description:  CacheDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using MT.Models;
using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace MT.Dal
{
    public class CacheDAL:BaseDAL<CacheModel>
    {
        /// <summary>
        /// 清理缓存
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                HttpContext.Current.Cache.Remove(enumerator.Key.ToString());
            }
        }

        /// <summary>
        /// 判断某缓存值是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            return (HttpContext.Current.Cache[key] != null);
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            try
            {
                if (HttpContext.Current.Cache[key] != null)
                {
                    return HttpContext.Current.Cache[key];
                }
            }
            catch
            {
            }
            return null;
        }

        /// <summary>
        /// 获取缓存值且转换为字符串类型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCacheToString(string key)
        {
            try
            {
                if (HttpContext.Current.Cache[key] != null)
                {
                    return ToString(HttpContext.Current.Cache[key]);
                }
            }
            catch
            {
            }
            return "";
        }

        /// <summary>
        /// 移除某缓存值
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            try
            {
                if (HttpContext.Current.Cache[key] != null)
                {
                    HttpContext.Current.Cache.Remove(key);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 模糊移除某些缓存值
        /// </summary>
        /// <param name="likekey"> 如: housing_follow_json_11200 </param>
        public static void RemoveLike(string likekey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();   // 所有缓存枚举

            string key = "";
            while (CacheEnum.MoveNext())
            {
                key = CacheEnum.Key.ToString();

                if (key.Contains(likekey))
                    Remove(key);
            }
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key"> 键值 </param>
        /// <param name="value"> 缓存内容 </param>
        /// <param name="seconds"> 缓存秒数 </param>
        /// <returns></returns>
        public static bool SetCache(string key, object value, int seconds)
        {
            if (value == null)
            {
                return SetCache(key, "", seconds);
            }
            try
            {
                if (HttpContext.Current.Cache[key] != null)
                {
                    HttpContext.Current.Cache.Remove(key);
                }
                if (seconds <= 0)
                {
                    HttpContext.Current.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(1.0), CacheItemPriority.NotRemovable, null);
                }
                else
                {
                    HttpContext.Current.Cache.Insert(key, value, null, DateTime.Now.AddSeconds((double)seconds), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
                }
                return true;
            }
            catch
            {
            }
            return false;
        }

        private static string ToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }

}
