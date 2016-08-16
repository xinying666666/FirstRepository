using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.WebCore.MVC;

namespace CarManager.Web.Controllers
{
    public class CsrfController : BaseController
    {
        // GET: Csrf
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//防止用户仿冒用户验证
        public ActionResult PushNotice(string notice) {
            ViewBag.Notice = notice;
            return View();
        }
    }
}