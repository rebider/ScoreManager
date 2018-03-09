
//*****************************************************************
//
// File Name:   UserInfoMeta.cs
//
// Description:  UserInfo:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(UserInfoMeta))]
    public partial class UserInfoModel
    {
      
        public partial class UserInfoMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string  UserID { get; set; }
            
    		[Display(Name = "电话")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Phone { get; set; }
            
    		[Display(Name = "邮箱")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Email { get; set; }
            
    		[Display(Name = "密码")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Password { get; set; }
            
    		[Display(Name = "客户类型")]
            [UIHint("EditText")]
    		public  int?  UserType { get; set; }
            
    		[Display(Name = "性别")]
            [Required]
            [UIHint("EditText")]
    		public  int?  Sex { get; set; }
            
    		[Display(Name = "国家")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Country { get; set; }
            
    		[Display(Name = "国家电话前缀")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  CountryCode { get; set; }
            
    		[Display(Name = "用户名")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  UserName { get; set; }
               		
            
    		[Display(Name = "出生日期")]
            [Required]
            [UIHint("EditText")]
    		public  DateTime?  Birthday { get; set; }
            
    		[Display(Name = "分配")]
            [UIHint("EditText")]
    		public  int?  UserStatus { get; set; }
            
    		[Display(Name = "省/地区 编号")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Province { get; set; }
            
    		[Display(Name = "城市编号")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  City { get; set; }
            
    		[Display(Name = "区域(地区)")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  District { get; set; }
            
    		[Display(Name = "地址")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  Address { get; set; }
            
    		[Display(Name = "邮编")]
            [UIHint("EditText")]
    		public  int?  Zip { get; set; }
            
    		[Display(Name = "身份证号（证件号）")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  IDcard { get; set; }
                		               		             		            
    		[Display(Name = "用户界面语言")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Lang { get; set; }
            
    		[Display(Name = "最后一次登录时间")]
            [Required]
            [UIHint("EditText")]
    		public  DateTime?  LastLoginTime { get; set; }
              		
            [Display(Name = "录入时间")]
            [Required]
            [UIHint("EditText")]
            public DateTime? CreateTime { get; set; }

            [Display(Name = "回访时间")]          
            [UIHint("EditText")]
            public DateTime? UpdateTime { get; set; }

            [Display(Name = "登录名")]
            [Required]
            [UIHint("EditText")]
            public string LoginName { get; set; }

            [Display(Name = "所属项目")]
            [Required]
            [UIHint("EditText")]
            public int? WhichDepart { get; set; }


            [Display(Name = "所属上级")]
            [Required]
            [UIHint("EditText")]
            public string PID { get; set; }
        }
	}
}

