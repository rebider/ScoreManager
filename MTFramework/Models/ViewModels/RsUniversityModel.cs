using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MT.Models.ViewModels
{
    [TableName("Rs_University")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public partial class RsUniversityModel : Record<RsUniversityModel>
    {
        [ResultColumn("DyName")]
        public string DyName { get; set; }

        [ResultColumn("ProvinceName")]
        public string ProvinceName { get; set; }

        [ResultColumn("CityName")]
        public string CityName { get; set; }

        [ResultColumn("GbName")]
        public string GbName { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("chineseName")]
        public string Chinesename { get; set; }

        [Column("gbCode")]
        public string Gbcode { get; set; }

        [Column("updateTime")]
        public string Updatetime { get; set; }

        [Column("rank")]
        public int? Rank { get; set; }

        [Column("rankYear")]
        public string Rankyear { get; set; }

        [Column("province")]
        public string Province { get; set; }

        [Column("dyCode")]
        public string Dycode { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("population")]
        public int? Population { get; set; }

        [Column("blcdCode")]
        public string Blcdcode { get; set; }

        [Column("xxxz")]
        public string Xxxz { get; set; }

        [Column("jxsj")]
        public string Jxsj { get; set; }

        [Column("iszs")]
        public string Iszs { get; set; }

        [Column("zdyq")]
        public decimal? Zdyq { get; set; }

        [Column("zxPoint")]
        public decimal? Zxpoint { get; set; }

        [Column("bksNum")]
        public int? Bksnum { get; set; }

        [Column("boy")]
        public int? Boy { get; set; }

        [Column("gril")]
        public int? Gril { get; set; }

        [Column("tuition")]
        public decimal? Tuition { get; set; }

        [Column("bklql")]
        public decimal? Bklql { get; set; }

        [Column("bkbyl")]
        public decimal? Bkbyl { get; set; }

        [Column("homePage")]
        public string Homepage { get; set; }

        [Column("yszy")]
        public string Yszy { get; set; }

        [Column("xysz")]
        public string Xysz { get; set; }

        [Column("xsyj")]
        public string Xsyj { get; set; }

        [Column("xyqh")]
        public string Xyqh { get; set; }

        [Column("zmxy")]
        public string Zmxy { get; set; }

        [Column("fromFlag")]
        public string Fromflag { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("logo")]
        public string Logo { get; set; }
        
        [Column("intro")]
        public string Intro { get; set; }

        [Column("del_flag")]
        public int? DelFlag { get; set; }

        [Column("Create_Man")]
        public string CreateMan { get; set; }

        [Column("Create_Time")]
        public DateTime? CreateTime { get; set; }
    }
}