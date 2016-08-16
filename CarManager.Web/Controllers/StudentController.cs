using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.WebCore.MVC;
using CarManager.Web.Models.Student;
using CarManager.Web.MVC;

namespace CarManager.Web.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        //[Route("abc")]  自定义路由
        public ActionResult Index()
        {
            Student student = new Student() { Name = "兔子", Sex = false, CreateTime = DateTime.Now };
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
        //[AllowAction("Update","Create")]
        [AllowCall("Update", "Create")]
        public ActionResult GetJson() {
            return Json(new object());
        }
    }
}