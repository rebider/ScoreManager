
//*****************************************************************
//
// File Name:   AgentLogMeta.cs
//
// Description:  AgentLogModel:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace MT.Models.Meta
{
    [Serializable]
    [MetadataType(typeof(AgentLogMeta))]
    public partial class AgentLogModel
    {
        public partial class AgentLogMeta
        {

            [Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public string ID { get; set; }

            [Display(Name = "代理用户的ID")]
            [Required]
            [UIHint("EditText")]
            public int? UserID { get; set; }

            [Display(Name = "旧代理级别 ")]
            [Required]
            [UIHint("EditText")]
        

            public int? BefAgentLevelID { get; set; }
            [Display(Name = "旧代理类型")]
            [Required]
            [UIHint("EditText")]
            public int? BefAgentID { get; set; }

            [Display(Name = "新代理级别 ")]
            [Required]
            [UIHint("EditText")]
           
            public int? CurAgentLevelID { get; set; }

            [Display(Name = "新代理类型")]
            [Required]
            [UIHint("EditText")]
            public int? CurAgentID { get; set; }

            [Display(Name = "插入人ID")]
            [Required]
            [UIHint("EditText")]
        
            public string InsMan { get; set; }

            [Display(Name = "插入时间")]
            [Required]
            [UIHint("EditText")]
            public DateTime? InsTime { get; set; }




        }
    }
}