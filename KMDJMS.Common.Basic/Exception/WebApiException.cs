using System;
using System.Collections.Generic;
using System.Text;

namespace KMDJMS.Common.Basic.Exception
{
    public class WebApiException : System.Exception
    {
        /// <summary>
        /// WebApiException
        /// </summary>
        public WebApiException() : this(null)
        {
        }

        /// <summary>
        /// WebApiException
        /// </summary>
        /// <param name="message"></param>
        public WebApiException(string message) : base(message)
        {
        }
    }
}
