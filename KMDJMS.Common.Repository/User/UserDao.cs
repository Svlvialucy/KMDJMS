using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMDJMS.Common.Repository.Common;
using KMDJMS.Common.Repository.DbContext;
using KMDJMS.Common.Dto.User;

namespace KMDJMS.Common.Repository.User
{
    public class UserDao : IDiRepository
    {
        private readonly BasicDbContext _basicDbContext;

        public UserDao(BasicDbContext basicDbContext)
        {
            _basicDbContext = basicDbContext;
        }

        public Model.User.User GetUserByPhone(string phone)
        {
            var user = _basicDbContext.Users.FirstOrDefault(t => t.Phone == phone);

            return user;
        }

        public List<Model.User.User> GetUserList(GetUserListSo request)
        {
            var query = _basicDbContext.Users.AsQueryable();

            if(request.UserId > 0)
            {
                query = query.Where(t => request.UserId == t.UserId);
            }

            if (!string.IsNullOrEmpty(request.UserName))
            {
                query = query.Where(t => t.UserName.Contains(request.UserName));
            }

            if (!string.IsNullOrEmpty(request.Phone))
            {
                query = query.Where(t => t.Phone.Contains(request.Phone));
            }

            var list = query.ToList();

            return list;
        }
    }
}
