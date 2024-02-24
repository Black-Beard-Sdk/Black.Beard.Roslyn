using Microsoft.CodeAnalysis;
using System.Collections;

namespace Bb.Builds
{


    public class FileReferences : IEnumerable<string>
    {



        public FileReferences(DirectoryInfo dir)
        {
                        
            foreach (var item in dir.GetFiles("*.dll", SearchOption.TopDirectoryOnly))
                _files.Add(item.FullName);
            
        }


        /// <summary>
        /// resolve the full path of the specified assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string? Resolve(string filename)
        {

            string file = filename;

            if (!filename.EndsWith(".dll"))
                file += ".dll";

            var result = _files.FirstOrDefault(c => c.EndsWith(file));

            return result;

        }

        public IEnumerator<string> GetEnumerator()
        {
            return _files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _files.GetEnumerator();
        }

        private List<string> _files = new List<string>();

    }



}
