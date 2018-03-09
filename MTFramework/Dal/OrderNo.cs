using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.Common;

namespace MT.Dal
{
    public class OrderNo : Controller
    {
        //
        // GET: /OrderNo/

        public static string Get(int UserID, MTConfig.OrderTypes OrderType)
        {
            Random random = new Random();
            return DateTime.Now.ToString("yyyyMMdd") + (int)OrderType + DateTime.Now.ToString("ffffHHssmm") + UserID+ random.Next(1000,9999);
        }

    }
}
