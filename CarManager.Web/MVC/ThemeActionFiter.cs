using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    public class ThemeActionFiter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ThemeHelper.ChangeTheme(filterContext.RouteData.Values["theme"].ToString());
        }
    }
}