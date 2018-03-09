using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class HxUserViewModel
    {
        public string action { get; set; }
        public string application { get; set; }
        public string path { get; set; }
        public string uri { get; set; }
        public dynamic entities { get; set; }
        public string timestamp { get; set; }
        public string duration { get; set; }
        public string organization { get; set; }
        public string applicationName { get; set; }
    }
}