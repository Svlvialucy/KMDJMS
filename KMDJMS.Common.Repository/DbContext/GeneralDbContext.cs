using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Model.User;
using Microsoft.EntityFrameworkCore;

namespace KMDJMS.Common.Repository.DbContext
{
    public class GeneralDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private const string DbConnectionStringAppSetting = "DbConnectionString_KMDJMS";


        public DbSet<User> Users { get; set; }
    }
}
