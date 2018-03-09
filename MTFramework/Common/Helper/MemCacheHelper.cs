using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Memcached.ClientLibrary;

namespace MT.Common
{
    public static class MemCacheHelper
    {
        /// <summary>
        /// 缓存地址
        /// </summary>
        private static string[] ServersConnect = { };

        /// <summary>
        /// Cache缓存信息
        /// </summary>
        private static SockIOPool pool = SockIOPool.GetInstance("default");


        static MemCacheHelper()
        {
            string serverconn = System.Configuration.ConfigurationManager.ConnectionStrings["MemcachedServerConnString"].ConnectionString;
            if (serverconn != "")
            {
                ServersConnect = serverconn.Split(';');
            }
            pool.SetServers(ServersConnect);
            pool.InitConnections = 5;
            pool.MinConnections = 5;
            pool.MaxConnections = 500;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.MaxBusy = 10 * 1000;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();
        }

        private static MemcachedClient GetClient()
        {
            MemcachedClient client = new MemcachedClient();
            client.PoolName = "default";
            return client;
        }

        /// <summary>
        /// 移除缓存信息
        /// </summary>
        /// <param name="objId"></param>
        public static bool RemoveObject(string key)
        {
            MemcachedClient tmp = GetClient();
            return tmp.Delete(key);
        }

        public static object GetObject(string key)
        {
            MemcachedClient tmp = GetClient();
            return tmp.Get(key);
        }

        /// <summary>
        /// 更新缓存信息
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        public static bool SetObject(string objId, object o, int expiry = 0)
        {
            MemcachedClient tmp = GetClient();
            bool bRes = false;
            if (expiry > 0)
            {
                bRes = tmp.Set(objId, o, DateTime.Now.AddSeconds(expiry));
            }
            else
            {
                bRes = tmp.Set(objId, o);
            }
            return bRes;
        }

        /// <summary>
        /// 清空缓存信息
        /// </summary>
        public static bool ClearAll()
        {
            return GetClient().FlushAll();
        }
    }
}
