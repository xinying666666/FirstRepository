using CarManager.Core.Infrastucture;
using CarManager.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    public class ActionAuthorzieAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            if (filterContext==null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            bool skip = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true);

            if (skip)
            {
                return;
            }

            //判断是否登录
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }

            //授权
            //拿到control名字
            string controllName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            string actionName = filterContext.ActionDescriptor.ActionName;


            IPermissonService permissonService=ServiceContainer.Resolve<IPermissonService>();
            var allowCallAttribures = filterContext.ActionDescriptor.GetCustomAttributes(true).OfType<AllowCallAttribute>();

             string[] allowActions = allowCallAttribures.SelectMany(ac=>ac.AllowActions).Distinct().ToArray();

            string userName = filterContext.HttpContext.User.Identity.Name;

            if (allowActions.Any(o=>permissonService.Authorize(o,userName)))
            {
                return;
            }

            //
            if (permissonService.Authorize(controllName+ actionName,userName))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);//验证没有通过跳转到 未登录处理






        }
    }
}