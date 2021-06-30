using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Enum;

namespace KMDJMS.Common.Model.Order
{
    public class ServiceProgress
    {
        public long ServiceProgressId { get; set; }

        public long OrderId { get; set; }

        public ServiceStatusEnum ServiceStatus { get; set; }

        public string ServiceStatusNote { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
