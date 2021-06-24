/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LewisFam.Utils
{
    ///<inheritdoc cref="JsonUtil"/>
    public static partial class JsonUtil
    {
        /// <summary>Deserializes the object async.</summary>
        /// <param name="json">The json string.</param>
        /// <returns>T</returns>
        public static Task<T> DeserializeObjectAsync<T>(this string json) => Task.Run(() => JsonConvert.DeserializeObject<T>(json, JsonUtil.SerializerSettings.Settings));

        /// <summary>Deserializes the object async.</summary>
        /// <param name="json">The json string.</param>
        /// <returns>A Task.</returns>
        [Obsolete("Method will be removed in future release. Please use the new DeserializeObjectAsync method.")]
        public static Task<T> FromJsonAsync<T>(this string json) => Task.Run(() => JsonConvert.DeserializeObject<T>(json, JsonUtil.SerializerSettings.Settings));

        /// <summary>Serializes the object Async.</summary>
        /// <param name="value"> The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A string.</returns>
        //public static async Task<string> SerializeObjectAsync(this object value, bool format = false) => await value.ToJsonAsync(format);
        public static async Task<string> SerializeObjectToJsonAsync(this object value, bool format = false) => await Task.Run<string>(() =>
        {
            return JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, JsonUtil.SerializerSettings.Settings);
        });

        /// <summary>To JSON</summary>
        /// <param name="value"> The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A json string.</returns>
        [Obsolete("Method will be removed in future release. Please uee the new SerializeObjectToJsonAsync method.")]
        public static async Task<string> ToJsonAsync(this object value, bool format = false)
        {
            return await Task.Run<string>(() =>
            {
                return JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, JsonUtil.SerializerSettings.Settings);
            });
        }
    }
}