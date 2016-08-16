using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;//第三方的验证框架
using FluentValidation.Mvc;
using CarManager.Web.Validator;
using CarManager.Web.MVC;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarManager.Web.App_Start.ExtensionActivator), "Start")]
namespace CarManager.Web.App_Start
{
   
    public static  class ExtensionActivator
    {
        public static void Start() {
            //首先要拿到容器

            //之后把微软默认的标机替换掉
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;//设置不需要mvc自己提供的验证、

            UnityValidatorFactory unityValidatorFactory = new Validator.UnityValidatorFactory(UnityConfig.GetConfiguredContainer()); 

            //添加我们自己的验证 FluentValidation 第三方验证框架
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(unityValidatorFactory));


            //替换微软的自动的源数据提供者
            ModelMetadataProviders.Current = new CustomModelMetadataProvdiver();


        }
    }
}