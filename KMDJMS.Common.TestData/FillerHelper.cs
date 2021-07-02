using System;
using System.Collections.Generic;
using System.Text;
using Tynamix.ObjectFiller;

namespace KMDJMS.Common.TestData
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class FillerHelper<T> where T : class
    {
        /// <summary>
        /// 根据默认随机插件以及注解特性信息填充对象
        /// </summary>
        /// <returns></returns>
        public static T Create()
        {
            return Randomizer<T>.Create(FillerSetup.Create<T>().SetupAnnotations().Result);
        }
    }
}
