using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class UserAuthModel
    {

        public UserModel User { get; set; }

        public List<NodeModel> NodeList { get; set; }

        public List<GroupModel> GroupList { get; set; }

        public List<RoleModel> RoleList { get; set; }

    }
}