
//*****************************************************************
//
// File Name:   UserLoginLogMeta.cs
//
// Description:  UserLoginLog:
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
    [MetadataType(typeof(UserLoginLogMeta))]
    public partial class UserLoginLogModel
    {
        public partial class UserLoginLogMeta
        {
    		[Display(Name = "编号")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "用户编号")]
            [UIHint("EditText")]
    		public  int?  UserID { get; set; }
            
    		[Display(Name = "登录时间")]
            [UIHint("EditText")]
    		public  DateTime?  LoginTime { get; set; }
            
    		[Display(Name = "登录ip")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  LoginIp { get; set; }
            
    		[Display(Name = "登录设备编号")]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  DeviceID { get; set; }
            
    		[Display(Name = "手机操作系统")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  DeviceOS { get; set; }
            
    		[Display(Name = "APP版本")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  AppVersion { get; set; }
            
        }
	}
}

