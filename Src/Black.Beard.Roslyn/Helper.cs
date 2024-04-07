using Bb.Extensions;
using Bb.Nugets;
using System.Text.RegularExpressions;

namespace Bb
{

    internal static class Helper
    {




        /// <summary>
        /// resolve version
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Version ResolveVersion(this string text)
        {

            Match m = Regex.Match(text, @"(?<version>\d+\.\d+(\.\d+((\.|-)\d+)?)?)", RegexOptions.IgnoreCase);
            var versionValue = m.Groups["version"].Value;
            if (!string.IsNullOrEmpty(versionValue))
                versionValue = versionValue.Trim(Path.DirectorySeparatorChar);
            if (Version.TryParse(versionValue.Replace("-", "."), out Version version))
                return version;

            return null;

        }


        public static (string,  Version) ResolveIdAndVersion(this string file, string tempPath)
        {
            NugetCompressedDocument docZip = NugetCompressedDocument.Create(file, tempPath);
            var doc = docZip.Load();
            return (doc.Id, doc.Version);
        }
               

        public static DirectoryInfo Unzip(this string filepath, string targetFolder)
        {
            return filepath.Unzip(new DirectoryInfo(targetFolder));
        }

        public static DirectoryInfo Unzip(this string filepath, DirectoryInfo targetFolder)
        {

            targetFolder.Refresh();
            if (targetFolder.Exists)
                targetFolder.Delete(true);
            targetFolder.Create();
            var file = new FileInfo(filepath);
            file.Uncompress(targetFolder);
            return targetFolder;
        }

        public static string Download(this Url url, DirectoryInfo targetFolder = null)
        {

            if (targetFolder == null)
                targetFolder = GetTempDir();

            var w = url.DownloadFileAsync(targetFolder.FullName);
            w.Wait();
            var file = w.Result;
            targetFolder.Refresh();

            return file;

        }

        public static DirectoryInfo GetTempDir()
        {

            var tempPath = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            tempPath.Refresh();
            if (tempPath.Exists)
                tempPath.Delete(true);
            tempPath.Create();
            tempPath.Refresh();
            return tempPath;

        }

        public static Url Url(this string uri, params string[] segments)
        {

            var u = new Url(uri);

            foreach (var item in segments)
                if (!string.IsNullOrEmpty(item))
                    u.AppendPathSegment(item);

            return u;

        }

    }

}
