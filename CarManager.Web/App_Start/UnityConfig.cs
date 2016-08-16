using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using CarManager.Core.Infrastucture;
using CarManager.WebCore.Infrastucture;
using System.Configuration;
using CarManager.Core.Config;

namespace CarManager.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        //这个方法要删除 因为core中已经有一个容器了
        //private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        //{
        //    var container = new UnityContainer();
        //    RegisterTypes(container);
        //    return container;
        //});


        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
             RegisterTypes(ServiceContainer.Current);

            return ServiceContainer.Current;
           // return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();


            //IUnityContainer ->UnityContainer
            container.RegisterInstance<IUnityContainer>(container);
            //通过自己定义的类型查找器
            ITypeFinder typeFinder = new WebTypeFinder();


            //将config 中的配置节注入
            var config = ConfigurationManager.GetSection("applicationConfig") as ApplicationConfig;//根据配置节名获取配置节 转换成配置节类型
            //将配置注入到容器中
            container.RegisterInstance<ApplicationConfig>(config);

            var registerTypes = typeFinder.FindClassesOfType<IDependencyRgister>();//只要实现了IDependencyRgister接口的类
            foreach (Type registerType in registerTypes)
            {
                var register = (IDependencyRgister)Activator.CreateInstance(registerType);//创建实例

                register.RegisterType(container);//调用实例的container方法

            }
        }
    }
}
