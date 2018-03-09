using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MT.Models
{
    public partial class DefaultConnectionDB : Database
    {
        public DefaultConnectionDB()
            : base("SqlServerConnection")
        {
            CommonConstruct();
        }

        public DefaultConnectionDB(string connectionStringName)
            : base(connectionStringName)
        {
            CommonConstruct();
        }

        partial void CommonConstruct();

        public interface IFactory
        {
            DefaultConnectionDB GetInstance();
        }

        private static object Locker = new object();
        public static IFactory Factory { get; set; }
        public static DefaultConnectionDB GetInstance()
        {
            //如果没有HttpContext使用标准单例
            if (HttpContext.Current == null)
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        //double check
                        if (_instance == null)
                        {
                            _instance = new DefaultConnectionDB();
                        }
                    }
                }
                return _instance;
            }
            //如果在web环境中每个请求对应一个实例
            if (!HttpContext.Current.Items.Contains(typeof(DefaultConnectionDB)))
            {
                HttpContext.Current.Items.Add(typeof(DefaultConnectionDB), new DefaultConnectionDB());
            }
            return (DefaultConnectionDB)HttpContext.Current.Items[typeof(DefaultConnectionDB)];

            //if (_instance != null)
            //    return _instance;

            //if (Factory != null)
            //    return Factory.GetInstance();
            //else
            //{
            //    _instance = new DefaultConnectionDB();
            //    return _instance;
            //}
        }

        [ThreadStatic]
        static DefaultConnectionDB _instance;

        public override void OnBeginTransaction()
        {
            if (_instance == null)
                _instance = this;
        }

        public override void OnEndTransaction()
        {
            if (_instance == this)
                _instance = null;
        }

    }
}