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
        /// 常用电话
        /// </summary>
        public string CommonPhone { get; set; }

        /// <summary>
        /// 备用电话
        /// </summary>
        public string SparePhone { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRoleEnum UserRole { get; set; }
    }
}
