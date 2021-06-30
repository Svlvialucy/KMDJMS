using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace KMDJMS.Common.Basic.Mapper
{
    /// <summary>
    /// MapperExtensions
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class MapperExtensions<S, T>
        where S : class
        where T : class
    {
        /// <summary>
        /// Map from S to T
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Map(S source)
        {
            var mapper = new AutoMapper.Mapper(GetMapperConfiguration());

            return mapper.Map<T>(source);
        }

        /// <summary>
        /// GetMapperConfiguration
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<S, T>());
            return config;
        }
    }
}
