using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Model.User;
using KMDJMS.Common.Repository.User;
using KMDJMS.Common.Service.Common;
using KMDJMS.Common.Service.Common.Cache;

namespace KMDJMS.Common.Service.User
{
    public class UserTokenService : IDiService
    {
        private readonly UserTokenDao _userTokenDao;

        public UserTokenService(UserTokenDao userTokenDao)
        {
            _userTokenDao = userTokenDao;
        }

        public string AddToken(Model.User.User user, string sessionId)
        {
            var userToken = new UserToken()
            {
                UserId = user.UserId,
                ExpireTime = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                SessionId = sessionId,
                Token = Guid.NewGuid().ToString()
            };

            _userTokenDao.AddToken(userToken);
            SetTokenToCache(userToken);

            return userToken.Token;
        }

        public void ClearToken(string token)
        {
            var userToken = GetTokenByCache(token);
            if (userToken != null)
            {
                RemoveTokenByCache(token);
            }

            ClearTokenFromDb(token);
        }

        private void ClearTokenFromDb(string token)
        {
            var userToken = _userTokenDao.GetToken(token);

            if (userToken == null)
            {
                return;
            }
            else
            {
                _userTokenDao.RemoveToken(token);
                return;
            }
        }

        private void SetTokenToCache(UserToken userToken)
        {
            MemoryCacheService.GetInstance.SetValue<UserToken>(userToken.Token, userToken);
        }

        private UserToken GetTokenByCache(string token)
        {
            var cacheManager = MemoryCacheService.GetInstance;
            return cacheManager.GetValue<UserToken>(token);
        }
        private void RemoveTokenByCache(string token)
        {
            var cacheManager = MemoryCacheService.GetInstance;
            cacheManager.RemoveValue(token);
        }
    }
}
