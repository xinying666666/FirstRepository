using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarManager.Web.MVC
{
    //允许在方法和 类上进行标记 并且允许标记多个
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple =true)]
    public class AllowCallAttribute:Attribute
    {
        public string[] AllowActions { get; set; }

        public AllowCallAttribute(params string[] allowAction)
        {
            this.AllowActions = AllowActions;
        }
    }
}