using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Basic.Enum
{
    public enum UserStatusEnum
    {
        /// <summary>
        /// 异常,失效
        /// </summary>
        Invalid = -1,

        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 删除
        /// </summary>
        Deleted = 1,

    }
}
