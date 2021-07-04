using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KMDJMS.Common.Service.Common.Auth
{
    public static class AuthInfo
    {
        public static readonly AsyncLocal<Model.User.User> KMDJUser;

        public static void SetRequestAuthInfo(Model.User.User user)
        {
            KMDJUser.Value = user;
        }
    }
}
