using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Model.User
{
    public class Address
    {
        public long AddressId { get; set; }

        public long UserId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        /// <summary>
        /// 小区
        /// </summary>
        public string Community { get; set; }

        public string DetailAddress { get; set; }

        public decimal AreaSize { get; set; }
    }
}
