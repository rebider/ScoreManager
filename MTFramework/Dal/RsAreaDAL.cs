using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MT.Models.ViewModels;
using PetaPoco;

namespace MT.Dal
{
    public class RsAreaDAL
    {

        public static List<RsAreaModel> GetAreas()
        {
            Database database = new Database("RsSqlServerConnection");
            return database.Fetch<RsAreaModel>(@"select [Id],[Code],[Name],[DivisionParent],[del_flag] from [Ba_Area]");
        }

    }
}