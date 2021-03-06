﻿using System.Runtime.Serialization.Json;

namespace LewisFam.Common.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DataContractJsonSerializer Json<T>()
        {
            return new DataContractJsonSerializer(typeof(T));
        }
    }
}
