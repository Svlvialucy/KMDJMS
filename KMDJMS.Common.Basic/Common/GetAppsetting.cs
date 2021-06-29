using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KMDJMS.Common.Basic.Common
{
    public class GetAppsetting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="build"></param>
        public static void Connection(IConfiguration build)
        {
            Configuration = build;
        }

        public static IConfiguration Configuration { get; private set; }

        public static string GetValue(string key)
        {
            return Configuration.GetSection(key).Value;
        }

        public static List<T> GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<List<T>>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<List<T>>>()
                .Value;
            return obj;
        }
    }
}
