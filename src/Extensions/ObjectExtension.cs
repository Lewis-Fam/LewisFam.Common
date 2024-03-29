﻿/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LewisFam.Extensions
{
    public static class ObjectExtension
    {
        public static IEnumerable<PropertyInfo> GetPropertyInfo(this object obj)
        {
            return obj.GetType().GetProperties();
        }

        public static IEnumerable<string> GetPropertyNames(this object obj)
        {
            return GetPropertyInfo(obj).Select(s => s.Name);
        }
    }
}