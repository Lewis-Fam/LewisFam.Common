using LewisFam.Common.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LewisFam.Common.Util
{
    public static class FileUtil
    {
        public static async Task<string> ReadTextFileAsync(string path)
        {
            byte[] result;
            using (var sourceStream = File.Open(path, FileMode.Open))
            {
                result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
            }
            return System.Text.Encoding.UTF8.GetString(result);
        }

        public static async Task<IList<string>> ReadTextLinesAsync(string path)
        {
            var lines = new List<string>();
            using var sr = new StreamReader(path);
            var line = await sr.ReadLineAsync();

            while (line != null)
            {
                lines.Add(line);
                line = await sr.ReadLineAsync();
            }

            return lines;
        }

        //public static async Task<string> ReadTextFile(string path)
        //{
        //    byte[] result;
        //    using (var sourceStream = File.Open(path, FileMode.Open))
        //    {
        //        result = new byte[sourceStream.Length];
        //        await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
        //    }
        //    return System.Text.Encoding.UTF8.GetString(result);
        //}
        public static void WriteTextFile(string path, string contents)
        {
        }
    }

    public class FileHelperUtil : FileUtilBase
    {
        public FileHelperUtil(string filename) : base(filename)
        {
        }
    }

    public abstract class FileUtilBase
    {
        protected FileUtilBase()
        {
        }

        protected FileUtilBase(string filename)
        {
            FileInfo = new FileInfo(filename);
        }

        protected FileInfo FileInfo { get; }
    }

    public class FileWatcherUtil
    {
        public FileWatcherUtil()
        {
            _path = "logs";
            DirMonitor();
        }        

        
        public void DirMonitor(string path = null)
        {
            if (path != null)
                _path = path;

            Debug.WriteLine(_path);

            if (Directory.Exists(_path))
            {
                if (_fileSystemWatcher == null)
                {
                _fileSystemWatcher = new FileSystemWatcher
                {
                    Path = _path,
                    EnableRaisingEvents = true
                };                
                _fileSystemWatcher.Changed += FileWatcher_IsChanged;
                }
            }
        }

        private static string _path;

        private FileSystemWatcher _fileSystemWatcher;

        private static void FileWatcher_IsChanged(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine(e.ToJson());
        }
    }

    public class StreamUtil : FileUtilBase
    {
        public StreamUtil() : base()
        {
        }

        public StreamUtil(string filename) : base(filename)
        {
        }

        public static string ReadStream1(string file)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }

        public string ReadStream(string file)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }

        public void StreamWrite(string contents)
        {
            using (var sw = new StreamWriter(FileInfo.Name))
            {
                sw.Write(contents);
            }
        }

        public void WriteStream(string file, string contents)
        {
            using (var sw = new StreamWriter(file))
            {
                sw.Write(contents);
            }
        }
    }
}