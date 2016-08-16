using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.WebCore.MVC;

namespace CarManager.Web.Controllers
{
    public class MasterTestController : BaseController
    {
        // GET: MasterTest
        public ActionResult Index()
        {
            return View();
        }
    }
}