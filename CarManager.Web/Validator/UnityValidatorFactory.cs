using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Microsoft.Practices.Unity;

namespace CarManager.Web.Validator
{
    public class UnityValidatorFactory:ValidatorFactoryBase
    {
        private readonly IUnityContainer unityContainer;

        public UnityValidatorFactory(IUnityContainer unityContainer) {
            this.unityContainer = unityContainer;
        }
         public override IValidator CreateInstance(Type validatorType)
        {  //unity 容器中解析一个验证器类型  validatorType.GetGenericArguments().First().FullName 将泛型参数的第一个参数的全名解析为验证器
            //如果没有解析出来会报一个异常
            IValidator validator = null;
            try
            {
                //                                 验证器类型                  获取泛型参数的第一个 参数的全名            转换一个验证器
                validator = unityContainer.Resolve(validatorType, validatorType.GetGenericArguments().First().FullName) as IValidator;
            }
            catch (Exception)
            {
                validator = null;
            }
            return validator ;
        }
    }

}