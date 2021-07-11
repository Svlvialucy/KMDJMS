using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using KMDJMS.Common.Basic.Enum;

namespace KMDJMS.Common.Model.User
{
    [Table("KM_User")]
    public class User
    {
        [Key]
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 电话 唯一
        /// </summary>
        public string Phone { get; set; }

        public string Password { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRoleEnum UserRole { get; set; }

        public string WeChatCode { get; set; }

        public UserStatusEnum UserStatus { get; set; }

        public bool IsVerified { get; set; }
    }
}
