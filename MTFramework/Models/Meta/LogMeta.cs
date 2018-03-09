
//*****************************************************************
//
// File Name:   LogMeta.cs
//
// Description:  Log:日志记录表
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
    [MetadataType(typeof(LogMeta))]
    public partial class LogModel
    {
        public partial class LogMeta
        {
    		[Display(Name = "主")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "操作人ID")]
            [Required]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  UserId { get; set; }
            
    		[Display(Name = "操作表名")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  TableName { get; set; }
            
    		[Display(Name = "操作类型")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  LogType { get; set; }
            
    		[Display(Name = "SQL语句与参数值")]
            [Required]
            [UIHint("EditText")]
            [StringLength(-1)]
    		public  string  SQLInfo { get; set; }
            
    		[Display(Name = "废弃标记")]
            [Required]
            [UIHint("EditDelFlagList")]
            [Range(0,10240000)]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "创建人ID")]
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

