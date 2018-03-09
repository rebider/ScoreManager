
using PetaPoco;
//*****************************************************************
//
// File Name:   DwgxMeta.cs
//
// Description:  Ba_dwgx:
//
// Coder:       CodeSmith Generate
//
// Date:        2014-04-03 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MT.Models
{
    [TableName("Ba_dwgx")]


    [PrimaryKey("Id")]



    [ExplicitColumns]
    public partial class RsDwgxModel : Record<RsDwgxModel>
    {




        [Column("Id")]
        public string Id { get; set; }







        [Column("code")]
        public string Code { get; set; }







        [Column("name")]
        public string Name { get; set; }







        [Column("parent")]
        public string Parent { get; set; }







        [Column("dwjc")]
        public string Dwjc { get; set; }







        [Column("note")]
        public string Note { get; set; }







        [Column("clevel")]
        public int? Clevel { get; set; }







        [Column("population")]
        public decimal? Population { get; set; }







        [Column("citysize")]
        public string Citysize { get; set; }







        [Column("orderView")]
        public int? Orderview { get; set; }







        [Column("del_flag")]
        public int? DelFlag { get; set; }





    }
}

