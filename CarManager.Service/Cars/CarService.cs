using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Domain;
using CarManager.Core.Data;
using CarManager.Core.Cache;

namespace CarManager.Service.Cars
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRespository;
        //缓存管理
        private readonly ICacheManager cacheManager;

        private const string CarsCaheKey = nameof(CarService) + nameof(Car);

        public CarService(IRepository<Car> carRespository,ICacheManager cacheManager) {
            this.carRespository = carRespository;
            this.cacheManager = cacheManager;
        }

        public void CreateCar(Car car)
        {
            carRespository.Insert(car);
        }

        public void DeleteCar(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCars()
        {
            List<Car> cars = null;
            if (cacheManager.Contains(CarsCaheKey))//缓存中存在从缓存中取得的
            {
                cars = cacheManager.Get<List<Car>>(CarsCaheKey);
            }
            else
            {
                cars = carRespository.Table.ToList();

                cacheManager.Set(CarsCaheKey, cars,TimeSpan.FromMinutes(2));//缓存两分钟

            }
            return cars;
        }

        public void UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
