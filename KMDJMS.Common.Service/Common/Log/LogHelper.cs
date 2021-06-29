using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using KMDJ.Common.Dto.Common.Log;
using KMDJMS.Common.Basic.Enum;
using log4net;

namespace KMDJMS.Common.Service.Common.Log
{
    public class LogHelper : IDiService
    {
        private static volatile LogHelper _instance = null;
        private static readonly object lockHelper = new object();
        private static ILog _logger;
        private static ConcurrentQueue<LoggingModel> _messageQueue;
        private static Thread _thread;
        private static volatile bool _isProcessing = false;

        #region singleton
        public static LogHelper Instance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new LogHelper();
                }
            }
            return _instance;
        }
        #endregion

        public static void StartLogThread()
        {
            _messageQueue = new ConcurrentQueue<LoggingModel>();
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _thread = new Thread(InternalWriteLog);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.IsBackground = true;

            _thread.Start();
        }

        /// <summary>
        /// 消费数据 实际写入日志
        /// </summary>
        public static void InternalWriteLog()
        {
            LoggingModel model;
            while (_messageQueue.TryDequeue(out model))
            {
                _isProcessing = true;

                switch (model.LogType)
                {
                    case LogTypeEnum.Debug:
                        _logger.Debug(model.Message, model.Exception);
                        break;
                    case LogTypeEnum.Info:
                        _logger.Info(model.Message, model.Exception);
                        break;
                    case LogTypeEnum.Warn:
                        _logger.Warn(model.Message, model.Exception);
                        break;
                    case LogTypeEnum.Error:
                        _logger.Error(model.Message, model.Exception);
                        break;
                    case LogTypeEnum.Fatal:
                        _logger.Fatal(model.Message, model.Exception);
                        break;
                    default:
                        _logger.Error($"LogType error{model.LogType} {model.Exception}");
                        break;
                }
            }

            //队列无数据则停止循环，等待唤醒
            _isProcessing = false;
        }

        /// <summary>
        /// 唤醒消费数据
        /// </summary>
        private static void Trigger()
        {
            if (_isProcessing)
            {
                return;
            }
            _thread = new Thread(InternalWriteLog);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.IsBackground = true;

            _thread.Start();
        }


        #region Log

        public static void Debug(Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Debug,
                    Message = ""
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Debug(string message, Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Debug,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Debug(string message)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Debug,
                    Message = message,
                });
                Trigger();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Info(Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Info,
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Info(string message, Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Info,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Info(string message)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Info,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Warn(Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Warn,
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Warn(string message, Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Warn,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Warn(string message)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Warn,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Error(Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Error,
                    Exception = exception
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Error(string message, Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Error,
                    Message = message,
                    Exception = exception
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Error(string message)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Error,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Fatal(Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Fatal,
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void Fatal(string message, Exception exception)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    Exception = exception,
                    LogType = LogTypeEnum.Fatal,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Fatal(string message)
        {
            try
            {
                _messageQueue.Enqueue(new LoggingModel()
                {
                    LogType = LogTypeEnum.Fatal,
                    Message = message
                });
                Trigger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion



    }
}
