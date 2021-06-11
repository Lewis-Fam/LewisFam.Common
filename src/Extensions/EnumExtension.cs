/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Author: LewisFam
***/

using System;

namespace LewisFam.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}