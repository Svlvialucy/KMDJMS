using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Basic.Enum
{
    public enum OrderStatusEnum
    {
        Invalid = -1,

        UnPaid = 0,

        /// <summary>
        /// 已支付待服务
        /// </summary>
        PaidOnServing = 1,

        /// <summary>
        /// 服务中
        /// </summary>
        Serving = 2,

        /// <summary>
        /// 完成
        /// </summary>
        Finished = 100
    }
}
