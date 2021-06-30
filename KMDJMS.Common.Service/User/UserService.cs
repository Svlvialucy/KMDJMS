using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Mapper;
using KMDJMS.Common.Dto.User;
using KMDJMS.Common.Repository.User;
using KMDJMS.Common.Service.Common;

namespace KMDJMS.Common.Service.User
{
    public class UserService : IDiService
    {
        private readonly UserDao _userDao;

        public UserService(UserDao userDao)
        {
            _userDao = userDao;
        }

        public BriefUser Login(string phone, string password, string sessionId)
        {
            var user = _userDao.GetUserByPhone(phone, password);

            return MapperExtensions<Model.User.User, BriefUser>.Map(user);
        }
    }
}
