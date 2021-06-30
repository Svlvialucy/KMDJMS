using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Common;
using KMDJMS.Common.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KMDJMS.Common.Repository.Common
{
    public static class ServiceCollectionDbContextExtensions
    {
        /// <summary>
        /// 添加需要依赖注入的DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<BasicDbContext>(
                options => options.UseMySql(
                    GetAppsetting.GetValue(DbContextBuilder.BasicDataConnectionStringAppSettingName), new MySqlServerVersion(new Version(5, 7))));
            

            return services;
        }
    }
}
