using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using CarManager.Core.Infrastucture;
using CarManager.Service.Cars;

namespace CarManager.Service
{
    public class ServiceRegister : IDependencyRgister
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<ICarService, CarService>();
        }
    }
}
