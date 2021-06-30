using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Model.Order
{
    public class OrderQualityInspector
    {
        public long OrderQualityInspectorId { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public long OrderId { get; set; }
    }
}
