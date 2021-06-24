using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LewisFam.Utils
{
    public static partial class FileUtil
    {
        #region Classes

        public static class Stream
        {
            #region Methods

            public static void Save(string path, string contents, FileMode fileMode = FileMode.OpenOrCreate, bool deleteFile = false)
            {
                if (File.Exists(path) && deleteFile)
                {
                    File.Delete(path);
                }

                //Create the file.
                using var fs = File.Open(path, fileMode);
                WriteContents(fs, contents);
            }

            public static async Task SaveAsync(string path, string contents, FileMode fileMode = FileMode.OpenOrCreate, bool deleteFile = false)
            {
                if (File.Exists(path) && deleteFile)
                {
                    File.Delete(path);
                }

                var bytes = new UTF8Encoding(true).GetBytes(contents);

                await using var fs = File.Open(path, fileMode);
                await WriteContentsAsync(fs, bytes);
            }

            #endregion Methods

            #region Helpers

            private static void WriteContents(System.IO.Stream fs, string value)
            {
                var bytes = new UTF8Encoding(true).GetBytes(value);
                fs.Write(bytes, 0, bytes.Length);
            }

            private static async Task WriteContentsAsync(System.IO.Stream stream, byte[] value)
            {
                stream.Seek(0, SeekOrigin.End);
                await stream.WriteAsync(value, 0, value.Length);
            }

            #endregion Helpers
        }

        #endregion Classes
    }
}