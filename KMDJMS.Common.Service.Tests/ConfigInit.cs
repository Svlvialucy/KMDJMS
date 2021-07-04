using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KMDJMS.Common.Service.Tests
{
    [SetUpFixture]
    public class ConfigInit
    {
        [OneTimeSetUp]
        public void Setup()
        {
            try
            {
                Console.WriteLine($"Best.Handset.Server.Service.Tests test setup...{DateTime.Now}");
                //Task.WaitAll(
                //    new ConfigRegister().Register(isDebugger: true),
                //    ResourceManagementRegister.Register(CultureInfo.CreateSpecificCulture("zh-CN"), Q9LanguageExtendtions.GetRequestCultureInfo)
                //);
                //Console.WriteLine($"Best.Handset.Server.Server.Tests test setup successfully {DateTime.Now}");
                //foreach (var item in ResourceManagerEx.Resources)
                //{
                //    Console.WriteLine($"SERVICE  {item.Key} -- {JsonConvert.SerializeObject(item.Value)}");
                //}
            }
            catch (Exception ex)
            {
                //Logger.LogError(new EventId(), "ConfigRegister Register error:", ex);
                Console.WriteLine($"Best.Handset.Server.Service.Tests test setup failed. {ex.Message}");
            }
            //Logger.LogInfo("end ConfigRegister Register");
        }
    }
}
