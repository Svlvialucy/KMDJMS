using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMDJMS.Common.Model.User
{
    [Table("KM_UserToken")]
    public class UserToken
    {
        [Key]
        public string Token { get; set; }

        public long UserId { get; set; }

        /// <summary>
        /// SessionId
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireTime { get; set; }
    }
}
