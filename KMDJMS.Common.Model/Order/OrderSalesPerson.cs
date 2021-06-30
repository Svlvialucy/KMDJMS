using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Model.Order
{
    public class OrderSalesPerson
    {
        public long OrderSalesPersonId { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal CommissionAmount { get; set; }
    }
}
