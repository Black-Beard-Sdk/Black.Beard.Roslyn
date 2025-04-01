using Microsoft.CodeAnalysis;
using System.Collections;

namespace Bb.Builds
{


    public class FileReferences
    {

        public FileReferences(IEnumerable<DirectoryInfo> directories)
        {

            var _d = new HashSet<string>();
            if (directories == null)
                _directories = new HashSet<DirectoryInfo>(3);
            else
            {
                _directories = new HashSet<DirectoryInfo>(directories.Count() + 3);

                directories.ToList().ForEach(c =>
                {
                    _directories.Add(c);
                    _d.Add(c.FullName);
                });
            }

            var _trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);
            HashSet<string> dirs = new HashSet<string>(_trustedAssembliesPaths.Select(c => new FileInfo(c).Directory.FullName));
            foreach (var item in dirs)
                if (_d.Add(item))
                {
                    var d = new DirectoryInfo(item);
                    if (d.Exists)
                        _directories.Add(d);
                }

        }


        /// <summary>
        /// resolve the full path of the specified assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEnumerable<string> Resolve(string filename)
        {

            string file = filename;

            if (!filename.EndsWith(".dll"))
                file += ".dll";

            List<string> files = new List<string>();
            foreach (var dir in _directories)
            {
                var item = dir.GetFiles(file, SearchOption.TopDirectoryOnly).FirstOrDefault();
                if (item != null)
                    files.Add( item.FullName);
            }

            if (files.Count > 0)
                return files;

            return null;

        }



        private readonly HashSet<DirectoryInfo> _directories;


    }



}
