using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Infrastucture;
using Microsoft.Practices.Unity;
using CarManager.Core.Data;

namespace CarManager.Data
{
    public class RepositoryRgister : IDependencyRgister
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IDbContext, CarDbContext>();
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
