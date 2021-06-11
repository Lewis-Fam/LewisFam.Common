﻿/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Author: LewisFam
***/

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LewisFam.Utils.Json
{
    ///<inheritdoc cref="JsonUtil"/>
    public static partial class JsonUtil
    {
        /// <summary>The serializer settings.</summary>
        private static class SerializerSettings
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

                //new JsonUtil.ParseStringConverter(),
                new StringEnumConverter(),
            },
            };
        }
    }
}