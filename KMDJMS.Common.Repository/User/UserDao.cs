using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMDJMS.Common.Repository.Common;
using KMDJMS.Common.Repository.DbContext;

namespace KMDJMS.Common.Repository.User
{
    public class UserDao : IDiRepository
    {
        private readonly BasicDbContext _basicDbContext;

        public UserDao(BasicDbContext basicDbContext)
        {
            _basicDbContext = basicDbContext;
        }

        public Model.User.User GetUserByPhone(string phone, string password)
        {
            var user = _basicDbContext.Users.FirstOrDefault(t => t.CommonPhone == phone);

            return user;
        }
    }
}
