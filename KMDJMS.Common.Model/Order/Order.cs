using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Enum;

namespace KMDJMS.Common.Model.Order
{
    public class Order
    {
        public long OrderId { get; set; }

        public bool IsDeleted { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        public decimal ServiceScore { get; set; }

        public string ServiceValuation { get; set; }

        #region User

        public long UserId { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 备用电话
        /// </summary>
        public string SparePhone { get; set; }

        public DateTime CreateTime { get; set; }

        public string Appointment { get; set; }

        public decimal Amount { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        /// <summary>
        /// 小区
        /// </summary>
        public string Community { get; set; }

        public string DetailAddress { get; set; }

        public decimal AreaSize { get; set; }

        #endregion

        #region Product

        public long ProductId { get; set; }

        /// <summary>
        /// 服务项目名
        /// </summary>
        public string ProductName { get; set; }

        #endregion

    }
}
