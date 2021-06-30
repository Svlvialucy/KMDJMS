using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Basic.Enum
{
    public enum ServiceStatusEnum
    {
        /// <summary>
        /// 待分配人员
        /// </summary>
        ToBeAssigned = 0,

        /// <summary>
        /// 已分配待服务
        /// </summary>
        AssignedToBeServed = 1,

        /// <summary>
        /// 服务中
        /// </summary>
        Working = 2,

        /// <summary>
        /// 待返工
        /// </summary>
        ToBeReworked = 3,

        Reworking = 4,

        Finished = 100
    }
}
