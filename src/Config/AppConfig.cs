using LewisFam.Common.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace LewisFam.Common.Config
{
    /// <summary>
    /// The app config.
    /// </summary>
    /// <remarks>Internal use only.</remarks>
    public abstract class AppConfig
    {
        public virtual string AppPropertiesFileName { get; set; }

        public virtual string ConfigurationsFolder { get; set; }

        public virtual string IdentityCacheDirectoryName { get; set; }

        public virtual string IdentityCacheFileName { get; set; }

        public virtual string IdentityClientId { get; set; }

        public virtual string PrivacyStatement { get; set; }

        public virtual string RootDataPath { get; set; }

        public virtual string UserFileName { get; set; }

        public override string ToString()
        {
            return this?.ToJson();
        }

        protected AppConfig()
        {
        }

        protected string ExecutingAssemblyDirectory => AssemblyDirectory;        

        private const string defaultFileName = "appconfig.json";

        private string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}