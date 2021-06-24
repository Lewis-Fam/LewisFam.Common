/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace LewisFam.Utils
{
    /// <summary>A Newtonsoft.Json helper utility.</summary>
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

        /// <summary>Deserializes the object. <seealso cref="SerializerSettings.Settings"/></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(this object jsonObj) where T : new()
        {
            var json = jsonObj.ToJson();
            return json.DeserializeObject<T>();
        }

        /// <summary>Deserializes the object. <seealso cref="SerializerSettings.Settings"/></summary>
        /// <param name="json">The json.</param>
        /// <returns>A T.</returns>
        public static T DeserializeObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json, SerializerSettings.Settings);

        [Obsolete("Method will be removed in future release. Please use the new DeserializeObject method.")]
        public static T ToObject<T>(string json) => JsonConvert.DeserializeObject<T>(json, SerializerSettings.Settings);

        #endregion Deserialze

        #region Serialze

        /// <summary>Serializes the object.</summary>
        /// <param name="value"> The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A string.</returns>
        public static string SerializeObjectToJson(this object value, bool format = false) => JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, SerializerSettings.Settings);

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

        /// <summary>To json.</summary>
        /// <param name="value"> The value.</param>
        /// <param name="format">If true, format.</param>
        /// <returns>A string.</returns>
        [Obsolete("Method will be removed in future release. Please use the new new SerializeObjectToJson method.")]
        public static string ToJson(this object value, bool format = false) => JsonConvert.SerializeObject(value, format ? Formatting.Indented : Formatting.None, SerializerSettings.Settings);

        #endregion Serialze
    }
}