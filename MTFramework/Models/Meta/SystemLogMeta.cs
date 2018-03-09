
//*****************************************************************
//
// File Name:   SystemLogMeta.cs
//
// Description:  SystemLog:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(SystemLogMeta))]
    public partial class SystemLogModel
    {
        public partial class SystemLogMeta
        {
    		[Display(Name = "日志编号")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "用户编号")]
            [UIHint("EditText")]
    		public  int?  UserID { get; set; }
            
    		[Display(Name = "日志类型")]
            [UIHint("EditText")]
    		public  int?  Type { get; set; }
            
    		[Display(Name = "日志信息")]
            [UIHint("EditText")]
            [StringLength(1000)]
    		public  string  LogInfo { get; set; }
            
    		[Display(Name = "操作时间")]
            [UIHint("EditText")]
    		public  DateTime?  InsTime { get; set; }
            
    		[Display(Name = "IP")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  IP { get; set; }
            
    		[Display(Name = "提交参数")]
            [UIHint("EditText")]
    		public  string  Parameters { get; set; }
            
        }
	}
}

