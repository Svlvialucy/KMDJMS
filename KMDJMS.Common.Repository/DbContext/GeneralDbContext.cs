using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Repository.DbContext
{
    public class GeneralDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private const string DbConnectionStringAppSetting = "DbConnectionString_KMDJMS";

    }
}
