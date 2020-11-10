using System;
using System.IO;
using System.Reflection;

namespace LewisFam.Common.Util
{
    public static partial class FileUtil
    {
        public static class FileDirectoryUtil
        {
            public static string GetAssemblyDirectory()
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}