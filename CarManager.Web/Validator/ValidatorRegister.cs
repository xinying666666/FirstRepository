using CarManager.Core.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using FluentValidation;
using CarManager.Web.Properties;

namespace CarManager.Web.Validator
{
    public class ValidatorRegister : IDependencyRgister
    {
        public void RegisterType(IUnityContainer container)
        {
            //查找所有验证器的类型                                             获取接口             接如果接口是泛型  且接口泛型的类型是一个验证器的类型
            var validatorTypers = this.GetType().Assembly.GetTypes().Where(t=>t.GetInterfaces().Any(i=>i.IsGenericType&&i.GetGenericTypeDefinition()==typeof(IValidator<>)));
            FluentValidation.Mvc.FluentValidationModelValidatorProvider.Configure();

            ValidatorOptions.ResourceProviderType = typeof(Resources);

            //解析器是一个委托 Type, MemberInfo, LambdaExpression, string
            ValidatorOptions.DisplayNameResolver = (type, memberInfo, lambdaExpression) => {
                string key = type.Name+memberInfo.Name+"DisplayName";
                string displayName = Resources.ResourceManager.GetString(key);
                return displayName;
            };

            foreach (Type type in validatorTypers)
            {  //                                                                                                     生命周期   定义单例
                container.RegisterType(typeof(IValidator<>),type,type.BaseType.GetGenericArguments().First().FullName,new ContainerControlledLifetimeManager());
            }
        }
    }
}