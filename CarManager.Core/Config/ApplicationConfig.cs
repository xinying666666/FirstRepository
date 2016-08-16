using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace CarManager.Core.Config
{
    public  class ApplicationConfig :ConfigurationSection
    {
        private const string RedisCacheConfigPropertyName = "redisCache";
        //这个属性不是必须的
        [ConfigurationProperty(RedisCacheConfigPropertyName)]
        public RedisCacheElement RedisCacheConfig {
            get { return (RedisCacheElement)base[RedisCacheConfigPropertyName]; }
            set { base[RedisCacheConfigPropertyName] = value; }
        }
    }
}
