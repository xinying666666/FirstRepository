using CarManager.Core.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CarManager.WebCore.Infrastucture
{
    /// <summary>
    /// 继承从应用程序域查询 实现 从bin目录下面查询
    /// </summary>
    public class WebTypeFinder: AppDomainTypeFinder
    {
        //标记是否已经在bin目录下面查过
        private bool binFolderAssembliesLoad = false;
        /// <summary>
        /// 定义为虚方法用户可以重写 如果不是bin目录 只需要实现这个方法再注入进去就可以了
        /// </summary>
        /// <returns></returns>
        public virtual string GetBinDirectory() {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)//部署在IIS下找bin目录
            {
                return System.Web.HttpRuntime.BinDirectory;
            }

            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (!binFolderAssembliesLoad)
            {
                binFolderAssembliesLoad = true;
                LoadMatchingAssemblies(GetBinDirectory());
            }
            return base.GetAssemblies();

        }
    }
}
