
using System.Diagnostics;

namespace Bb.Nugets
{

    /// <summary>
    /// Nuget compressed document
    /// </summary>
    public class NugetCompressedDocument
    {

        /// <summary>
        /// Create a NugetCompressedDocument from a file that contains a nupkg file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="targetFolder"></param>
        /// <returns></returns>
        public static NugetCompressedDocument Create(string path, string targetFolder = null)
        {
            DirectoryInfo target = null;

            if (string.IsNullOrEmpty(targetFolder))
                target = Helper.GetTempDir();

            return Create(new FileInfo(path), target);
        }

        /// <summary>
        /// Create a NugetCompressedDocument from a file that contains a nupkg file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="targetFolder"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static NugetCompressedDocument Create(FileInfo path, DirectoryInfo targetFolder = null)
        {

            if (targetFolder == null)
                targetFolder = Helper.GetTempDir();
            if (!targetFolder.Exists)
                targetFolder.Create();


            path.Refresh();
            if (!path.Exists)
                throw new FileNotFoundException(path.FullName);


            return new NugetCompressedDocument(path, targetFolder);

        }

        private NugetCompressedDocument(FileInfo file, DirectoryInfo targetFolder = null)
        {
            _targetFolder = targetFolder;
            _file = file;
        }
                
        /// <summary>
        /// load the nuget document
        /// </summary>
        /// <returns></returns>
        public NugetDocument Load()
        {

            if (_targetFolder == null)
                _targetFolder = Helper.GetTempDir();

            Trace.TraceInformation($"Unzip nuget {_file.FullName} to {_targetFolder.FullName}");
            var targetfolder = _file.FullName.Unzip(Path.Combine(_targetFolder.FullName, "unzip"));

            return NugetDocument.ResolveNugetDocument(targetfolder);

        }


        public override string ToString()
        {
            return _file.ToString();
        }

        private DirectoryInfo _targetFolder;
        private readonly FileInfo _file;


    }


}
