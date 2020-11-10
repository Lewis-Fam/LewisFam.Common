using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LewisFam.Common.Util
{
    public static partial class FileUtil
    {
            public static string ReadStream(string file)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }


        public static string ReadAllBytes(string fileName, bool fromTop, int count)
        {
            var bytes = File.ReadAllBytes(fileName);
            if (fromTop)
            {
                return Encoding.UTF8.GetString(bytes, 0, count);
            }
            return Encoding.UTF8.GetString(bytes, bytes.Length - count, count);
        }

        public static string ReadAllLines(string fileName, bool fromTop, int count)
        {
            var lines = File.ReadAllLines(fileName);
            if (fromTop)
            {
                return string.Join(Environment.NewLine, lines.Take(count));
            }
            return string.Join(Environment.NewLine, lines.Reverse().Take(count));
        }

        public static async Task<IList<string>> ReadAllLinesAsync(string path)
        {
            var lines = new List<string>();
            using var sr = new StreamReader(path);
            var line = await sr.ReadLineAsync();

            while (line != null)
            {   lines.Add(line);
                line = await sr.ReadLineAsync();
                lines.Add(line);
            }

            return lines;
        }

         public static async Task<IList<string>> ReadAllLinesAsync(string path, string find)
        {
            var lines = new List<string>();
            using var sr = new StreamReader(path);
            var line = await sr.ReadLineAsync();

            while (line != null)
            {                                                   
                line = await sr.ReadLineAsync();
                if (line.Contains(find))
                    lines.Add(line);
            }

            return lines;
        }

        public static async Task<string> ReadTextLinesAsync(string path)
        {
            byte[] result;
            using (var sourceStream = File.Open(path, FileMode.Open))
            {
                result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
            }
            return System.Text.Encoding.UTF8.GetString(result);
        }

        public static void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        private static Tuple<string, string> MakeError()
        {
            return Tuple.Create("\0", "\0");
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
        public FileInfo FileInfo { get; protected set; }

        protected FileUtilBase()
        {
        }

        protected FileUtilBase(string filename)
        {
            FileInfo = new FileInfo(filename);
        }
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

    public static class StreamUtil 
    {   
        public static FileInfo FileInfo { get; set; }

        public static string ReadStream1(string file)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }

        public static string ReadStream(string file)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }

        public static void StreamWrite(FileInfo fileInfo, string contents)
        {
            using (var sw = new StreamWriter(fileInfo.Name))
            {
                sw.Write(contents);
            }
        }

        public static void WriteStream(string file, string contents)
        {
            using (var sw = new StreamWriter(file))
            {
                sw.Write(contents);
            }
        }
    }
}