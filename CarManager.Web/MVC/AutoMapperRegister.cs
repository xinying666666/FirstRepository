using CarManager.Core.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using AutoMapper;

namespace CarManager.Web.MVC
{
    public class AutoMapperRegister : IDependencyRgister
    {
        public void RegisterType(IUnityContainer container)
        {
            //throw new NotImplementedException();
            //表示该类型是从Profile 继承 需要参与  类型映射
            var profileType = this.GetType().Assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));
            //所有映射器都是单例
            var profileInstance = profileType.Select(t=>(Profile)Activator.CreateInstance(t));//通过类型创建一个类型实例
            //配置实例  将所有的实现了 Profile 的实例加到 mapper的总配置当中去
            var config = new MapperConfiguration(cfg =>{ profileInstance.ToList().ForEach(p => cfg.AddProfile(p)); });

            container.RegisterInstance(config);
            container.RegisterInstance<IMapper>(config.CreateMapper());

        }
    }
}