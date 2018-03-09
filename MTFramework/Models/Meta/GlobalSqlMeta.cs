
//*****************************************************************
//
// File Name:   GlobalSqlMeta.cs
//
// Description:  Global_Sql:系统SQL统一管理
//
// Coder:       CodeSmith Generate
//
// Date:        2015-03-25 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(GlobalSqlMeta))]
    public partial class GlobalSqlModel
    {
        public partial class GlobalSqlMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "SQL键名")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  SQLKey { get; set; }
            
    		[Display(Name = "SQL主体")]
            [Required]
            [UIHint("EditText")]

    		public  string  SQLContent { get; set; }
            
    		[Display(Name = "备注")]
            [UIHint("EditText")]
            [StringLength(500)]

            public string Remark { get; set; }

            [Display(Name = "连接字符串名")]
            [UIHint("EditText")]
            [StringLength(500)]
            public  string  SqlConnection { get; set; }
            
    		[Display(Name = "是否废弃 1：是； 0 ：否（默认0）")]
            [Required]
            [UIHint("EditDelFlagList")]
            [Range(0,10240000)]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "创建人")]
            [Required]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [Required]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
        }
	}
}

