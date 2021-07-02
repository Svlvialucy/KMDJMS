using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Common;
using KMDJMS.Common.Model.User;
using Microsoft.EntityFrameworkCore;

namespace KMDJMS.Common.Repository.DbContext
{
    public class BasicDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        /// <summary>
        /// 选项
        /// </summary>
        public DbContextOptions<BasicDbContext> Options { get; }

        public DbSet<Model.User.User> Users { get; set; }

        public DbSet<Model.User.UserToken> UserTokens { get; set; }

        public BasicDbContext(DbContextOptions<BasicDbContext> options) : base(options)
        {
            Options = options;
        }
    }
}
