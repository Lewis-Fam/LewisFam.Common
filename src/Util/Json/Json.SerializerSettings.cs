using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LewisFam.Common.Util
{
    public static partial class JsonUtil
    {
        internal static class SerializerSettings
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        OverrideSpecifiedNames = false,
                    },
                },
                MetadataPropertyHandling = MetadataPropertyHandling.Default,
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = {
                new IsoDateTimeConverter
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal
                },
                new JsonUtil.ParseStringConverter(),
                new StringEnumConverter(),
            },
            };
        }
    }   


}
