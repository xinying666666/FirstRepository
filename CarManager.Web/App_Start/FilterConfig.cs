using CarManager.Core.Infrastucture;
using CarManager.Core.Log;
using CarManager.Web.MVC;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //加入自己的路由过滤器

            //filters.Add(new LanuageActionFilter());

            //filters.Add(new HandleErrorAttribute()); //这里是微软自己的异常处理器   

            //注入 程序开始的时候已经将自己的异常处理器注入进去   
            //filters.Add(new CustomHandleErrorAttribute(ServiceContainer.Resolve<ILogger>()));

            //每一个action 执行前 判断主题
            //filters.Add(new ThemeActionFiter());

            //filters.Add(new ActionAuthorzieAttribute());//注入权限验证过滤器




        }
    }
}
