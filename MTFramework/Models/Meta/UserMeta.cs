
using PetaPoco;
//*****************************************************************
//
// File Name:   UserMeta.cs
//
// Description:  User:用户表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-27 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(UserMeta))]
    public partial class UserModel
    {


        public partial class UserMeta
        {
            [Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public string ID { get; set; }

            [Display(Name = "用户名")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
            public string Name { get; set; }

            [Display(Name = "密码")]
            [Required]
            [UIHint("EditText")]
            [StringLength(32)]
            public string Password { get; set; }

            [Display(Name = "真实姓名")]
            [UIHint("EditText")]
            [StringLength(50)]
            public string NickName { get; set; }

            [Display(Name = "性别")]

            [UIHint("EditText")]
            //[DropDownList("DDL_SEX")]
            [Required]

            public string Sex { get; set; }

            [Display(Name = "公司id")]
            [Required]

            [UIHint("EditText")]
            //[DropDownList("DDL_COMPANY")]
            public int? CompanyId { get; set; }

            [Display(Name = "公司编码")]
            [Required]
            public string CompanyCode { get; set; }

            [Display(Name = "公司名称")]
            [UIHint("EditText")]
            [Required]
            public string CompanyName { get; set; }

            [Display(Name = "用户类别")]

            [UIHint("EditText")]
        
            [Required]
            public string UserType { get; set; }



            [Display(Name = "是否废弃")]
            [Required]
            [UIHint("EditDelFlagList")]
            public int? DelFlag { get; set; }

            [Display(Name = "创建人")]
            [Required]
            [UIHint("EditText")]
            [Range(0, 100)]
            public int? CreateMan { get; set; }

            [Display(Name = "创建时间")]
            [Required]
            [UIHint("EditText")]
            public DateTime? CreateTime { get; set; }

            [Display(Name = "修改人")]
            [UIHint("EditText")]
            [Range(0, 100)]
            public int? ModifyMan { get; set; }

            [Display(Name = "修改时间")]
            [UIHint("EditText")]
            public DateTime? ModifyTime { get; set; }

        }
    }
}

