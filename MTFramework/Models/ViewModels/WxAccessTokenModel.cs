using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class WxAccessTokenModel
    {

        public string access_token { get; set; }

        public string expires_in { get; set; }

        public string errcode { get; set; }

        public string errmsg { get; set; }

    }
}