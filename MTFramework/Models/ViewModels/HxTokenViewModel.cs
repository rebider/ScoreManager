using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class HxTokenViewModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string application { get; set; }
    }
}