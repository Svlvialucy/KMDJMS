using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KMDJMS.Common.Basic.Enum;
using KMDJMS.Common.Basic.Exception;
using KMDJMS.Common.Basic.Mapper;
using KMDJMS.Common.Basic.Util;
using KMDJMS.Common.Dto.User;
using KMDJMS.Common.Repository.User;
using KMDJMS.Common.Service.Common;

namespace KMDJMS.Common.Service.User
{
    public class UserService : IDiService
    {
        private readonly UserDao _userDao;
        private readonly UserTokenService _userTokenService;

        public UserService(UserDao userDao, UserTokenService userTokenService)
        {
            _userDao = userDao;
            _userTokenService = userTokenService;
        }

        public BriefUser Login(string phone, string password, string sessionId)
        {
            var encryptPassword = EncryptHelper.EncryptPassword(password, phone);
            var user = _userDao.GetUserByPhone(phone);

            if (user == null || user.UserStatus != UserStatusEnum.Normal)
            {
                throw new WebApiException("用户不存在");
            }

            if (user.Password != encryptPassword)
            {
                throw new WebApiException("密码错误");
            }

            //未激活 
            if (!user.IsVerified)
            {
                return new BriefUser() { RedirectUrl = "NA" }; //NA给前端 可以跳出重发激活邮件
            }

            var token = _userTokenService.AddToken(user, sessionId);

            var briefUser = MapperToBrief(user);
            briefUser.Token = token;
            return briefUser;
        }

        public void Logout(string token)
        {
            _userTokenService.ClearToken(token);
        }

        public List<BriefUser> GetList(GetUserListSo request)
        {
            var userList = _userDao.GetUserList(request);

            return userList.Select(MapperToBrief).ToList();
        }

        public BriefUser MapperToBrief(Model.User.User user)
        {
            return MapperExtensions<Model.User.User, BriefUser>.Map(user);
        }
    }
}
