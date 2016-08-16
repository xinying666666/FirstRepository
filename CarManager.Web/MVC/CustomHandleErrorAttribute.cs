using CarManager.Core.Log;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    public class CustomHandleErrorAttribute:HandleErrorAttribute
    {
        //注入日志
        private readonly ILogger logger;

        public CustomHandleErrorAttribute(ILogger logger)
        {
            this.logger = logger;
        }

        //通过属性和标记的形式注入
        // [Dependency]
        //public ILogger logger { get; set; }
        //ILogger logger=

        public override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);    

            filterContext.ExceptionHandled = true;
            var ex = filterContext.Exception;
            logger.Error("发现未处理的异常",ex);

            filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
    }
}