using System;
using System.Collections.Generic;
using System.Text;
using KMDJMS.Common.Basic.Enum;

namespace KMDJ.Common.Dto.Common.Log
{
    public class LoggingModel
    {
        public string Message { get; set; }

        public LogTypeEnum LogType { get; set; }

        public System.Exception Exception { get; set; }

        public LoggingModel(string message, LogTypeEnum type = LogTypeEnum.Info, System.Exception ex = null)
        {
            this.Message = message;
            this.LogType = type;
            this.Exception = ex;
        }

        public LoggingModel()
        {

        }
    }
}
