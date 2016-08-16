using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    public static class MvcHelperExt
    {
        public static MvcHtmlString  DisplayPrice(this HtmlHelper html, double price) {
            return new MvcHtmlString(string.Format("{0:C}",price));
        }
    }
}