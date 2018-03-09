using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MT.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "修改密码")]
        [Required]
        [UIHint("EditPassword")]
        public string ModifyPassword { get; set; }

        [Display(Name = "确认密码")]
        [Required]
        [UIHint("EditPassword")]
        [Compare("ModifyPassword")]
        public string ConfirmPassword { get; set; }

    }
}