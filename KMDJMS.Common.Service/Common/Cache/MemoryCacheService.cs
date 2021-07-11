using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace KMDJMS.Common.Service.Common.Cache
{
    public class MemoryCacheService : IDiService
    {
        private static readonly MemoryCacheService Instance = new MemoryCacheService();

        private static readonly IMemoryCache MemoryCache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());

        static MemoryCacheService()
        {
        }

        private MemoryCacheService()
        {

        }

        /// <summary>
        /// 获取实例对象
        /// </summary>
        public static MemoryCacheService GetInstance
        {
            get
            {
                return Instance;
            }
        }

        public T GetValue<T>(string key)
        {
            return MemoryCache.Get<T>(key);
        }

        public void SetValue<T>(string key, T value)
        {
            MemoryCache.Set(key, value);
        }

        public void SetValue<T>(string key, T value, TimeSpan expireTimeSpan)
        {
            MemoryCache.Set(key, value, expireTimeSpan);
        }

        public void RemoveValue(string key)
        {
            MemoryCache.Remove(key);
        }
    }
}
