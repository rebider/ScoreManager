using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using MT.Models;

namespace MT.Areas.Admin.ViewModels
{
    public class IndexViewModel
    {

        public List<GroupModel> GroupList { get; set; }

        public List<NodeModel> NodeList{ get; set; }

        public UserModel UserInfo { get; set; }
     
         
    }
}