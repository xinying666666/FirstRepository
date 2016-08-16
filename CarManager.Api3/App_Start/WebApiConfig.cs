using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;


namespace CarManager.Api3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //返回数据格式化
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("format","json","application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("format", "xml", "application/json"));

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.AddJsonpFormatter();//jsonp

            config.EnableCors();  //cors 配置
        }
    }
}
