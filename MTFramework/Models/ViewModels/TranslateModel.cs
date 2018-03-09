using System.Collections.Generic;
using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System;
using MT.Common;
using System.Text;
using PetaPoco.Internal;

namespace MT.Models.ViewModels
{
    public class TranslateModel 
    {

        public string from { get; set; }


        public string to { get; set; }


        public List<TranslateResultModel> trans_result { get; set; }


    }

    public class TranslateResultModel
    {

        public string src { get; set; }

        public string dst { get; set; }

    }
}
