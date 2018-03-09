using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Common.Helper
{
    /// <summary>
    /// 全局缓存
    /// </summary>
    public static class AppCacheHelper
    {
        /// <summary>
        /// 设置全局缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key, object value, int expire)
        {
            HttpRuntime.Cache[key] = value;
        }

        public static object Get(string key)
        {
            return HttpRuntime.Cache[key];
        }

        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}