﻿using CarManager.Core.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using CarManager.Core.Cache;
using CarManager.Core.Log;
using CarManager.Service.Security;

namespace CarManager.Service
{
    public class InfrastructureRegister : IDependencyRgister
    {
        public void RegisterType(IUnityContainer container)
        {
            //container.RegisterType<ICacheManager, RedisCacheManager>();//缓存的注入 
            container.RegisterType<ICacheManager, MemoryCacheManager>();//缓存的注入 
            container.RegisterType<ILogger,NullLogger>();
            container.RegisterType<IPermissonService, PermissonService>();

            

        }
    }
}
