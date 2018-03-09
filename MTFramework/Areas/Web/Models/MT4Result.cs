using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Areas.Web.Models
{
    public class MT4Result
    {
        public string Group { get; set; }

        public int Leverage { get; set; }

        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public uint RegTime { get; set; } 
    }
}