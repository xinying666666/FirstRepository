using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Cache
{
   public  interface ICacheManager
    {
        /// <summary>
        ///获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        void Set( string key,object value,TimeSpan cacheTime);
        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(string key);
        /// <summary>
        /// 移除一个缓存
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();
    }
}
