using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    public static class ThemeHelper
    {
        public static void ChangeTheme(string themeName) {
            //微软默认的视图引擎
            var engine = ViewEngines.Engines.Where(e=>e is RazorViewEngine).Single() as RazorViewEngine;

            engine.ViewLocationFormats = engine.PartialViewLocationFormats = engine.MasterLocationFormats=new string
                []{
             "~/Views/Themes/" + themeName + "/{1}/{0}.cshtml",
             "~/Views/" + themeName + "/{1}/{0}.cshtml",
              "~/Views/Shared/{0}.cshtml",
            };

           

        }
    }
}