using System.Xml.Linq;

namespace Bb.Nugets
{
    public class NugetDocument
    {

        /// <summary>
        /// Create a NugetDocument from a directory that contains a nuspec file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static NugetDocument ResolveNugetDocument(DirectoryInfo path)
        {
            NugetDocument doc = null;
            var list = path.GetFiles("*.nuspec");
            foreach (var c in list)
                doc = new NugetDocument(c);
            return doc;
        }

        /// <summary>
        /// Create a NugetDocument from a file that contains a nuspec file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static NugetDocument ResolveNugetDocument(FileInfo path)
        {
            return new NugetDocument(path);
        }


        internal NugetDocument(FileInfo metadataFile)
        {

            _metadataFile = metadataFile;
            var root = metadataFile.LoadXmlFromFile().Root;
            _ns = root.Name.NamespaceName;

            var metadata = root.Element(XName.Get("metadata", _ns));
            if (metadata != null)
                foreach (var item in metadata.Elements())
                    switch (item.Name.LocalName.ToLower())
                    {

                        case "id":
                            Id = item.Value;
                            break;
                        case "version":
                            Version = new Version(item.Value);
                            break;
                        case "description":
                            Description = item.Value;
                            break;


                        case "repository":
                            Repository = new NugetRepository(item);
                            break;


                        case "dependencies":
                            foreach (var group in item.Elements())
                                _dependencies.Add(new NugetGroupDependency(group));
                            break;

                        default:
                            break;
                    }


        }


        public string Id { get; }

        public Version Version { get; }

        public string Description { get; }

        public NugetRepository Repository { get; }

        public override string ToString()
        {
            return Id.ToString() + " " + Version.ToString();
        }

        /// <summary>
        /// return the dependencies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NugetGroupDependency> Dependencies() => _dependencies;

        /// <summary>
        /// return the dependencies for a specific framework
        /// </summary>
        /// <param name="framework"></param>
        /// <returns></returns>
        public IEnumerable<NugetGroupDependency> Dependencies(string framework)
        {
            return _dependencies.Where(c => c.TargetFramework == framework);
        }


        private List<NugetGroupDependency> _dependencies = new List<NugetGroupDependency>();
        private FileInfo _metadataFile;
        private string _ns;


    }


}
