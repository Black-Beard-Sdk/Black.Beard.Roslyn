using Bb.Analysis;
using Bb.Builds;
using System.Diagnostics;
using System.Xml.Linq;

namespace Bb.Nugets
{


    /// <summary>
    /// Nuget document
    /// </summary>
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

            this._list = new List<Reference>();

            Trace.TraceInformation($"Load metadata file {metadataFile.FullName}");

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
                            Version = Helper.ResolveVersion(item.Value);
                            break;
                        case "description":
                            Description = item.Value;
                            break;

                        case "repository":
                            Repository = new NugetRepository(item);
                            break;

                        case "dependencies":
                            foreach (var group in item.Elements())
                                _dependencies.Add(new NugetGroupDependency(group, this));
                            break;

                        default:
                            break;
                    }


        }

        /// <summary>
        /// Package nuget Id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Package nuget version
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Package nuget description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Repository informations
        /// </summary>
        public NugetRepository Repository { get; }

        public override string ToString()
        {
            return Id.ToString() + " " + Version.ToString();
        }

        /// <summary>
        /// return true if the dependencies are for multiple target build
        /// </summary>
        public bool IsMultipleTarget => _dependencies.Count > 1;

        /// <summary>
        /// return the dependencies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NugetGroupDependency> GroupDependencies() => _dependencies;

        /// <summary>
        /// return the dependencies for a specific framework
        /// </summary>
        /// <param name="framework"></param>
        /// <returns></returns>
        public IEnumerable<NugetGroupDependency> GroupDependencies(FrameworkKey framework, FrameworkVersion frameworkTarget)
        {
            return _dependencies.Where(c =>
            {

                if (!framework.Accept(c.TargetFramework))
                    return false;

                return true;

            });
        }

        /// <summary>
        /// return the dependencies for a specific framework
        /// </summary>
        /// <param name="framework"></param>
        /// <returns></returns>
        public IEnumerable<NugetGroupDependency> GroupDependencies(FrameworkKey framework)
        {
            return _dependencies.Where(c => c.TargetFramework == framework);
        }

        /// <summary>
        /// List libraries references found in the folder lib
        /// </summary>
        public IEnumerable<Reference> References => _list;


        internal void Add(Reference reference)
        {
            reference.Package = this;
            _list.Add(reference);
        }

        private List<NugetGroupDependency> _dependencies = new List<NugetGroupDependency>();
        private FileInfo _metadataFile;
        private string _ns;
        private List<Reference> _list;

    }


}
