using LewisFam.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LewisFam.Common.Util
{
    public static partial class JsonUtil
    {

        #region Deserialze

        #region Xml

        public static XNode DeserializeXNode(string json, string name)
        {
            return JsonConvert.DeserializeXNode(json, name);
        }

        public static Task<XDocument> DeserializeXNodeAsync(string json, string name)
        {
            return Task.Run(() => JsonConvert.DeserializeXNode(json, name));
        }

        #endregion Xml

        public static T DeserializeObject<T>(string json) => JsonConvert.DeserializeObject<T>(json, SerializerSettings.Settings);

        public static Task<T> DeserializeObjectAsync<T>(string json) => Task.Run(() => JsonConvert.DeserializeObject<T>(json, SerializerSettings.Settings));

        [Obsolete("Method will be removed in future release. Please use the new DeserializeObject method.")]
        public static T FromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json, SerializerSettings.Settings);

        [Obsolete("Method will be removed in future release. Please use the new DeserializeObjectAsync method.")]           
        public static Task<T> FromJsonAsync<T>(string json) => Task.Run(() => JsonConvert.DeserializeObject<T>(json, SerializerSettings.Settings));


        

        #endregion Deserialze

        #region Serialze

        /// <summary>Serializes the object.</summary>
        /// <param name="value">The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A string.</returns>
        public static string SerializeObject(object value, bool format = false) => value.ToJson(format);

        /// <summary>Serializes the object Async.</summary>
        /// <param name="value">The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A string.</returns>
        public static async Task<string> SerializeObjectAsync(object value, bool format = false) => await value.ToJsonAsync(format);



        ///// <summary>
        ///// Tos the json.
        ///// </summary>
        ///// <param name="obj">The obj.</param>
        ///// <param name="format">If true, format.</param>
        ///// <returns>A string.</returns>
        //[Obsolete("Method will be removed in future release. Please use the new new SerializeObject method.")]           
        //public static string ToJson(object obj, bool format = false) => obj.ToJson(format);

        //[Obsolete("Method will be removed in future release. Please uee the new SerializeObjectAsync method.")]           
        //public static async Task<string> ToJsonAsync(object obj, bool format = false) => await obj.ToJsonAsync(format);


        /// <summary>
        /// To json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A string.</returns>
        //[Obsolete("Method will be removed in future release. Please use the new new SerializeObject method.")]           
        public static string ToJson(this object value, bool format = false) => JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, SerializerSettings.Settings);

        /// <summary>To JSON</summary>
        /// <param name="value"> The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A json string.</returns>
        //[Obsolete("Method will be removed in future release. Please uee the new SerializeObjectAsync method.")]           
        public static async Task<string> ToJsonAsync(this object value, bool format = false)
        {
            return await Task.Run<string>(() =>
            {
                return JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, SerializerSettings.Settings);
            });
        }

        #endregion Serialze
    }
}