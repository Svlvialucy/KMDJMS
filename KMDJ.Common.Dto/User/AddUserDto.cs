using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Enum;

namespace KMDJMS.Common.Dto.User
{
    public class AddUserDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 常用电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRoleEnum UserRole { get; set; }
    }
}
