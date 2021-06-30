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

        public BasicDbContext(DbContextOptions<BasicDbContext> options) : base(options)
        // Don't use base type, so that dependency injection can choose the correct DbContext from multiple DbContext types.
        {
            Options = options;
        }
    }
}
