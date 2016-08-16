using CarManager.Core.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace CarManager.Web.MVC
{
    public class ActionFilterRegister : IDependencyRgister
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<CustomHandleErrorAttribute>();
        }
    }
}