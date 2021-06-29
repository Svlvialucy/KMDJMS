using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace KMDJMS.Common.Repository.Common
{
    public static class ServiceProviderExtentions
    {
        private static ServiceProvider _serviceProvider;

        /// <summary>
        /// 设置ServiceProvider
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void SetServiceProvider(IServiceCollection serviceCollection)
        {
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// 创建Scope
        /// </summary>
        /// <returns></returns>
        public static IServiceScope CreateScope()
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = new ServiceCollection()
                    .AddDbContexts()
                    .BuildServiceProvider();
            }

            return _serviceProvider.CreateScope();
        }
    }
}