//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Text;

namespace LewisFam.Common.Util
{
//namespace LewisFam.Core.Helpers
//{
//    public class Zip
//    {
//        public static void Extract(string _zipPath, string _extractPath, string _endsWith)
//        {
//            string zipPath = _zipPath;

//            string extractPath = _extractPath;

//            // Normalizes the path.
//            extractPath = Path.GetFullPath(extractPath);

//            // Ensures that the last character on the extraction path
//            // is the directory separator char.
//            // Without this, a malicious zip file could try to traverse outside of the expected
//            // extraction path.
//            if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
//                extractPath += Path.DirectorySeparatorChar;

//            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
//            {
//                foreach (ZipArchiveEntry entry in archive.Entries)
//                {
//                    if (entry.FullName.EndsWith(_endsWith, StringComparison.OrdinalIgnoreCase))
//                    {
//                        // Gets the full path to ensure that relative segments are removed.
//                        string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

//                        // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
//                        // are case-insensitive.
//                        if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
//                            entry.ExtractToFile(destinationPath);
//                    }
//                }
//            }
//        }
//    }
//}
}