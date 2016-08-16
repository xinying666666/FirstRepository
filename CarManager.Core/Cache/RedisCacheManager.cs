using CarManager.Core.Config;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly string redisConnectionString;

        public volatile ConnectionMultiplexer redisConnection;

        private readonly object redisConnectionLockne = new object();


        public RedisCacheManager(ApplicationConfig config) {
            if (string.IsNullOrEmpty(config.RedisCacheConfig.ConnectionString))
            {
                throw new ArgumentException("redis config is empty",nameof(config));//nameof(config) 表示参数额名字
            }

            this.redisConnectionString = config.RedisCacheConfig.ConnectionString;

            this.redisConnection = GetRedisConnection();
        }

        private ConnectionMultiplexer GetRedisConnection()
        {
            if (this.redisConnection!=null&&this.redisConnection.IsConnected)
            {
                return redisConnection;
            }

            lock (redisConnectionLockne)
            {
            if (this.redisConnection != null)
            {
                this.redisConnection.Dispose();
            }

            this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
            }
            return this.redisConnection;
        }

        //public RedisCacheManager(string ip) {

        //}
        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public bool Contains(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }

        public T Get<T>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue) //判断是否有值
            {
                return Desiralize<T>(value);
            }
            else
            {
                return default(T);
            }
              

        }
        private T Desiralize<T>(byte[] value) {
            if (value==null)
            {
                return default(T);
            }
            var jsonString = Encoding.UTF8.GetString(value);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public byte[] Serialize(object item) {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value!=null)
            {
                redisConnection.GetDatabase().StringSet(key,Serialize(value), cacheTime);
            }
        }
    }
}
