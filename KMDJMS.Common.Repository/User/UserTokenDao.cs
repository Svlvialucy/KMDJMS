using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMDJMS.Common.Model.User;
using KMDJMS.Common.Repository.Common;
using KMDJMS.Common.Repository.DbContext;

namespace KMDJMS.Common.Repository.User
{
    public class UserTokenDao : IDiRepository
    {
        private readonly BasicDbContext _basicDbContext;

        public UserTokenDao(BasicDbContext basicDbContext)
        {
            _basicDbContext = basicDbContext;
        }

        public void AddToken(UserToken userToken)
        {
            _basicDbContext.UserTokens.Add(userToken);
            _basicDbContext.SaveChanges();
        }

        public UserToken GetToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            return _basicDbContext.UserTokens.FirstOrDefault(t => t.Token == token);
        }

        public void RemoveToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            var userToken = _basicDbContext.UserTokens.FirstOrDefault(t => t.Token == token);
            if (userToken == null)
            {
                return;
            }

            _basicDbContext.Remove(userToken);
            _basicDbContext.SaveChanges();
        }
    }
}
