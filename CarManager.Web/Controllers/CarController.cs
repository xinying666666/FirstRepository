using CarManager.Core.Domain;
using CarManager.Service.Cars;
using CarManager.Web.Models.Cars;
using CarManager.WebCore.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace CarManager.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService carService;

        private readonly IMapper mapper;

        private readonly MapperConfiguration mapperConfig;

        public CarController(ICarService carService,IMapper mapper, MapperConfiguration mapperConfig) {
            this.carService = carService;
            this.mapper = mapper;
            this.mapperConfig=mapperConfig;
        }
        // GET: Cars
        public ActionResult Index()
        {
            //var model = carService.GetCars().Select(c => new CarViewModel() { Name=c.Name,Price=c.Price});

            List<Car> carList = carService.GetCars();

            var  moldes = carList.AsQueryable().ProjectTo<CarViewModel>(mapperConfig);//using AutoMapper.QueryableExtensions;


            return View(moldes);
        }


        public JsonResult GetCars() {
            dynamic jsonObj = new System.Dynamic.ExpandoObject();
            jsonObj.name = "c++";
            jsonObj.id = "123";
            jsonObj.price = 88;

            return Json(jsonObj, JsonRequestBehavior.AllowGet);
            //return Json(carService.GetCars(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(CarViewModel model)
        {
            if (ModelState.IsValid)//验证要生效 需要在car类中打标记
            {

                //如果CarViewModel 中字段是大写 Car 中字段是小写 可以在model后面加一起linq 的表达式
                Car car = mapper.Map<CarViewModel, Car>(model);
                car.CreateDate = DateTime.Now;
                carService.CreateCar(car);
                return RedirectToAction(nameof(Index));
            }

            //ModelState.AddModelError(string Empty)

            return View(model);

            
        }
    }
}