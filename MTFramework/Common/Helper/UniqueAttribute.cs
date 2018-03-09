using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    [AttributeUsageAttribute(AttributeTargets.Property|AttributeTargets.Field|AttributeTargets.Parameter, AllowMultiple = false)]
    public class UniqueAttribute : ValidationAttribute
    {
        
    }
}