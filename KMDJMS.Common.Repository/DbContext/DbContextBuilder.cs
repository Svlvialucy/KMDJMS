using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Common;
using KMDJMS.Common.Basic.Exception;
using Microsoft.EntityFrameworkCore;

namespace KMDJMS.Common.Repository.DbContext
{
    public static class DbContextBuilder
    {
        public const string BasicDataConnectionStringAppSettingName = "DbConnectionString_KMDJMS";

        public static BasicDbContext GetBasicDbContext()
        {
            try
            {
                var options = GetBasicDbContextOptions(BasicDataConnectionStringAppSettingName);
                return new BasicDbContext(options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static DbContextOptions<BasicDbContext> GetBasicDbContextOptions(string connAppSettingName)
        {
            var connectionStringValue = GetAppsetting.GetValue(connAppSettingName);
            if (string.IsNullOrEmpty(connectionStringValue))
                throw new WebApiException($"HsDbContextBuilder GetDbContextOptions ConnectionString:{connAppSettingName} not found.");

            var builder = new DbContextOptionsBuilder<BasicDbContext>().UseMySql(connectionStringValue, new MySqlServerVersion(new Version(5,7)));

            return builder.Options;
        }
    }
}
