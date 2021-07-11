using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Dto.User
{
    public class BriefUser
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string RedirectUrl { get; set; }

        public string Token { get; set; }
    }
}
