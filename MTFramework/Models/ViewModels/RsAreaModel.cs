using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MT.Models.ViewModels
{
    [TableName("Ba_Area")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public partial class RsAreaModel : Record<RsAreaModel>
    {
        [Column("Id")]
        public string Id { get; set; }

        [Column("Code")]
        public string Code { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("DivisionParent")]
        public string Divisionparent { get; set; }

        [Column("del_flag")]
        public int? DelFlag { get; set; }
    }
}