using System.Collections.Generic;

namespace LewisFam.Common.Util
{
    public static partial class JsonUtil
    {        
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
            public static IEnumerable<T> ReadAllJsons<T>(string path)
            {
                var jsonLines = System.IO.File.ReadAllLines(path);
                var rtn = new List<T>();
                foreach (var json in jsonLines)
                {
                    var r = DeserializeObject<T>(json);
                    rtn.Add(r);
                }
                return rtn;
            }
            
            /// <inheritdoc cref="System.IO.File.ReadAllText(string)"/>            
            public static string ReadAllText(string path)
            {
                 return System.IO.File.ReadAllText(path);
            }
        }
    }
}