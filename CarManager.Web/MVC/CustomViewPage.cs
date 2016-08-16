using CarManager.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    public abstract class CustomViewPage<TModel> : WebViewPage<TModel>
    {
        public string T(string key)
        {
            return Resources.ResourceManager.GetString(key);
        }
    }
}