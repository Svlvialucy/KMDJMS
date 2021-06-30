using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using KMDJMS.Common.Repository.Common;
using KMDJMS.Common.Repository.DbContext;
using KMDJMS.Common.Service.Common;
using KMDJMS.Common.Service.Common.Log;
using Microsoft.Extensions.DependencyInjection;

namespace KMDJMS.Common.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResources(this IServiceCollection services, params Assembly[] assemblies)
        {
            //Add DbContexts
            services.AddDbContexts();

            //Add Services
            if (assemblies != null && assemblies.Length > 0)
            {
                foreach (var assembly in assemblies)
                {
                    services.AddServicesFromAssembly(assembly);
                }
            }

            AddRepositories(services);

            //Add MemoryCache
            services.AddMemoryCache(options =>
            {
                options.CompactionPercentage = 0.9;
            });

            //Set ServiceProvider
            ServiceProviderExtentions.SetServiceProvider(services);

            return services;
        }

        /// <summary>
        /// 添加需要依赖注入的Service
        /// </summary>
        /// <param name="service"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection service, Assembly assembly)
        {
            var services = assembly?.GetTypes()?.Where(type => !type.IsInterface && typeof(IDiService).IsAssignableFrom(type))?.ToList();
            if (services != null)
            {
                foreach (var type in services)
                {
                    service.AddScoped(type);
                }

                LogHelper.Info($"ServiceCollectionExtensions AddServicesFromAssembly: {services.Count} services added.");
            }

            return service;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            var repositories = Assembly.GetAssembly(typeof(IDiRepository)).GetTypes()
                .Where(type => !type.IsInterface && typeof(IDiRepository).IsAssignableFrom(type)).ToList();
            foreach (var repository in repositories)
            {
                service.AddScoped(repository);
            }
            LogHelper.Info($"ServiceCollectionExtensions AddRepositories: {repositories.Count} repositories added.");
            return service;
        }
    }
}
