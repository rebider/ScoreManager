using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    [TableName("Ba_Edu")]


    [PrimaryKey("Id")]



    [ExplicitColumns]
    public partial class RsEduModel : Record<RsEduModel>
    {




        [Column("Id")]
        public string Id { get; set; }







        [Column("Code")]
        public string Code { get; set; }







        [Column("Name")]
        public string Name { get; set; }







        [Column("Note")]
        public string Note { get; set; }







        [Column("del_flag")]
        public int? DelFlag { get; set; }




    }
}