/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Utils
{
    ///<inheritdoc cref="JsonUtil"/>
    public static partial class JsonUtil
    {

        /// <summary>A Json file helper utility.</summary>
        public static class FileUtil
        {
            /// <inheritdoc cref="System.IO.File.ReadAllLines(string)"/>
            /// <remarks>A text file of json object lines.</remarks>
            /// <exception cref="System.IO.PathTooLongException"></exception>
            /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
            /// <exception cref="System.IO.IOException"></exception>
            /// <exception cref="System.UnauthorizedAccessException"></exception>
            /// <exception cref="System.IO.FileNotFoundException"></exception>
            /// <exception cref="System.Security.SecurityException"></exception>
            public static IEnumerable<T> ReadAllJsonLines<T>(string path)
            {
                var jsonLines = System.IO.File.ReadAllLines(path);
                return jsonLines.Select(DeserializeObject<T>).ToList();
            }

            /// <inheritdoc cref="System.IO.File.ReadAllLines(string)"/>
            /// <exception cref="System.IO.PathTooLongException"></exception>
            /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
            /// <exception cref="System.IO.IOException"></exception>
            /// <exception cref="System.UnauthorizedAccessException"></exception>
            /// <exception cref="System.IO.FileNotFoundException"></exception>
            /// <exception cref="System.Security.SecurityException"></exception>
            public static string ReadAllText(string path)
            {
                return System.IO.File.ReadAllText(path);
            }
        }
    }
}