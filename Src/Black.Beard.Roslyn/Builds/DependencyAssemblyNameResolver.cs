using ICSharpCode.Decompiler.Metadata;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Bb.Builds
{


    public static class DependencyAssemblyNameResolver
    {

        /// <summary>
        ///  Return the list of assemblies referenced by the file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="references"></param>
        /// <param name="download"></param>
        public static List<AssemblyReference> Resolve(FileInfo file, AssemblyReferences references, bool download)
        {
            List<AssemblyReference> hash = new List<AssemblyReference>();
            ResolveImpl(file, hash, references, download);
            hash.Remove(hash.FirstOrDefault(c => c.Location == file.FullName));
            return hash;
        }

        private static void ResolveImpl(FileInfo file, List<AssemblyReference> list, AssemblyReferences references, bool download)
        {

            var isInSdk = references.IsInSdk(file.FullName);
            if (isInSdk)
                return;

            AssemblyReference current = null;

            using (var lib = new PEFile(file.FullName))
                if (!list.Any(c => c.FullAssemblyName == lib.Module.FullAssemblyName))
                {

                    list.Add(current = new AssemblyReference()
                    {
                        AssemblyName = lib.Module.AssemblyName,
                        FullAssemblyName = lib.Module.FullAssemblyName,
                        Location = file.FullName,
                        Resolved = true,
                    });

                    foreach (var item in lib.AssemblyReferences)
                        if (!list.Any(c => c.AssemblyName == item.Name))
                        {
                            var reference = references.SearchInRegistered(item.Name);
                            if (reference != null)
                            {
                                if (!references.IsInSdk(reference.Location))
                                    ResolveImpl(new FileInfo(reference.Location), list, references, download);
                            }
                            else
                            {

                                var location = references.SearchNext(item.Name, item.Version, download);

                                if (location != null)
                                {
                                    if (!references.IsInSdk(reference.Location))
                                        ResolveImpl(new FileInfo(location), list, references, download);
                                }
                                else
                                    list.Add(current = new AssemblyReference()
                                    {
                                        AssemblyName = item.Name,
                                        FullAssemblyName = item.FullName,
                                        Location = file.FullName,
                                        Resolved = false,
                                    });

                            }
                        }

                }
        }

        [DebuggerDisplay("{AssemblyName}")]
        public class AssemblyReference
        {

            public string Location { get; set; }

            public string AssemblyName { get; set; }

            public string FullAssemblyName { get; set; }


            public bool Resolved { get; set; }


        }

    }

}
