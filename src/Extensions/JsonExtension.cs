using LewisFam.Common.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static LewisFam.Common.Util.JsonUtil;

namespace LewisFam.Common.Extensions
{
    public static class JsonExtension
    {
        /// <summary>To JSON</summary>
        /// <param name="value"> The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A json string.</returns>
        public static string ToJson(this object value, bool format = false) => JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, SerializerSettings.Settings);

                /// <summary>Tos the json async.</summary>
        /// <param name="obj">   The obj.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A Task.</returns>
        public static async Task<string> ToJsonAsync(this object obj, bool format = false)
        {
            return await Task.Run<string>(() =>
            {
                return JsonConvert.SerializeObject(obj, format ? Formatting.Indented : Formatting.None, SerializerSettings.Settings);
            });
        }
    }
}
