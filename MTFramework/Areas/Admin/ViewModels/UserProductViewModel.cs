using MT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Areas.Admin.ViewModels
{
    public class UserProductViewModel
    {
        public UserModel User { get; set; }

        public List<ProductModel> ProductList { get; set; }

        public List<RoleModel> RoleList { get; set; }

        public List<UserRoleModel> UserRoleList { get; set; }

        public List<UserProductModel> UserProductList { get; set; }

        

    }
}