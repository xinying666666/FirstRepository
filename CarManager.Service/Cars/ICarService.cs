using CarManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Service.Cars
{
    public  interface ICarService
    {
        void CreateCar(Car car);

        void UpdateCar(Car car);

        void DeleteCar(Car car);

        List<Car> GetCars();
    }
}
