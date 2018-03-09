using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MT.Areas.Admin.ViewModels
{
    public class AccessRecordViewModel
    {
        /// <summary>
        /// 访问地址
        /// </summary>
        [Display(Name = "访问地址")]
        [ResultColumn(Name = "Access_Url")]
        public string AccessUrl { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        [Display(Name = "访问次数")]
        [ResultColumn(Name = "Pv")]
        public string Pv { get; set; }

        /// <summary>
        /// 独立ip访问数
        /// </summary>
        [Display(Name = "独立ip访问数")]
        [ResultColumn(Name = "Up")]
        public string Up { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Display(Name = "时间")]
        [ResultColumn(Name = "Hour")]
        public string Hour { get; set; }

    }
}