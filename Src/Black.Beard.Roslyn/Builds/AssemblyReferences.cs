using Microsoft.CodeAnalysis;
using System.Collections;
using System.Reflection;
using Refs;
using ICSharpCode.Decompiler.Metadata;
using System.Text.RegularExpressions;

namespace Bb.Builds
{


    /// <summary>
    /// Assembly references
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable&lt;Reference&gt;" />
    public class AssemblyReferences : IEnumerable<KeyValuePair<string, Reference>>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyReferences"/> class.
        /// </summary>
        public AssemblyReferences()
        {
            this._referencesByAssembly = new Dictionary<string, Reference>();
        }


        #region Add

        #region Types and assemblies

        /// <summary>
        /// Adds assemblies references from types.
        /// </summary>
        /// <param name="typeAssembly">The type assembly.</param>
        /// <exception cref="System.NullReferenceException">typeAssembly</exception>
        public void AddTypesRange(params Type[] typeAssembly)
        {

            if (typeAssembly == null)
                throw new NullReferenceException(nameof(typeAssembly));

            foreach (var item in typeAssembly)
                AddAssembly(item.Assembly);

        }

        /// <summary>
        /// Adds the reference by assembly from specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="System.NullReferenceException">type</exception>
        public void AddByType(Type type)
        {

            if (type == null)
                throw new NullReferenceException(nameof(type));

            AddAssembly(type.Assembly);

        }

        /// <summary>
        /// Adds assembly list in references.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <exception cref="System.NullReferenceException">assemblies</exception>
        public void AddAssembliesRange(params Assembly[] assemblies)
        {

            if (assemblies == null)
                throw new NullReferenceException(nameof(assemblies));

            foreach (var item in assemblies)
                AddAssembly(item);

        }

        /// <summary>
        /// Adds the reference by specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <exception cref="System.NullReferenceException">assembly</exception>
        public PortableExecutableReference AddAssembly(Assembly assembly)
        {

            if (assembly == null)
                throw new NullReferenceException(nameof(assembly));

            return AddAssemblyLocation(assembly.Location, assembly.GetName().Name);

        }

        #endregion Types and assemblies

        /// <summary>
        /// search filename in the sdk folder and add the reference
        /// </summary>
        /// <param name="filename"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public PortableExecutableReference ResolveFilename(string assemblyFilename, string assemblyName = null)
        {

            FileReferences references = Sdk.GetReferences();

            var l = references.Resolve(assemblyFilename);

            if (l == null)
                throw new FileNotFoundException(assemblyFilename);

            return AddAssemblyLocation(l, assemblyName);

        }

        /// <summary>
        /// Adds the assembly reference by assembly name.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <exception cref="System.ArgumentNullException">assemblyName</exception>
        /// <exception cref="System.IO.FileLoadException"></exception>
        public PortableExecutableReference ResolveAssemblyName(string assemblyName)
        {

            string lib = null;

            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName));


            if (_referencesByAssembly.TryGetValue(assemblyName, out var result))  // in already referenced assemblies
                return result.ExecutableReference;

            var item = Libs.Items.Where(c => c.Name == assemblyName).FirstOrDefault();

            if (item != null)
            {
                lib = Sdk.GetReferences().Resolve(assemblyName);
                if (!string.IsNullOrEmpty(lib))
                    return AddAssemblyLocation(lib, assemblyName);
            }

            if (_next != null)
            {
                lib = _next.ResolveAssemblyName(assemblyName, this.Sdk);
                if (!string.IsNullOrEmpty(lib))
                    return AddAssemblyLocation(lib, assemblyName);
            }

            return null;

        }


        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <exception cref="System.NullReferenceException">assemblies</exception>
        public void AddRangeAssemblyFiles(params string[] assemblies)
        {

            if (assemblies == null)
                throw new NullReferenceException(nameof(assemblies));

            foreach (var item in assemblies)
                AddAssemblyLocation(item);

        }


        /// <summary>
        /// Adds the assembly location path.
        /// </summary>
        /// <param name="assemblyLocation">The assembly location.</param>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public PortableExecutableReference AddAssemblyLocation(string assemblyLocation, string assemblyName = null)
        {

            if (!File.Exists(assemblyLocation))
                throw new FileNotFoundException(assemblyLocation);

            return Add(assemblyLocation, assemblyName);

        }

        /// <summary>
        /// Adds the specified references.
        /// </summary>
        /// <param name="location">The key.</param>
        /// <param name="reference">The reference.</param>
        /// <exception cref="System.NullReferenceException">reference</exception>
        public PortableExecutableReference Add(string location, string assemblyName = null)
        {

            if (location == null)
                throw new NullReferenceException(nameof(location));

            if (string.IsNullOrEmpty(assemblyName))
            {
                var item = _referencesByAssembly.Where(c => c.Value.Location == location).FirstOrDefault();
                if (item.Value != null)
                    return item.Value.ExecutableReference;
                try
                {
                    var lib = new PEFile(location);
                    assemblyName = lib.Name;
                }
                catch (Exception)
                {

                }
            }

            if (!_referencesByAssembly.TryGetValue(assemblyName, out var instance))
                _referencesByAssembly.Add(assemblyName, instance = new Reference(location, assemblyName));

            else
                instance.SelectLastest(location);

            return instance.ExecutableReference;

        }

        #endregion Add


        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, Reference>> GetEnumerator()
        {
            foreach (var item in this._referencesByAssembly)
                yield return item;
        }

        public IEnumerable<PortableExecutableReference> Libraries()
        {
            foreach (var item in this._referencesByAssembly)
                yield return item.Value.ExecutableReference;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in this._referencesByAssembly)
                yield return item;
        }

        public void Next(IAssemblyReferenceResolver next)
        {
            if (_next == null)
                _next = next;
            else
                _next.Next(next);
        }


        #endregion IEnumerable


        public FrameworkVersion Sdk { get; internal set; }


        private IAssemblyReferenceResolver _next;
        private readonly Dictionary<string, Reference> _referencesByAssembly;


    }

    public class Reference
    {

        public Reference(string location, string assemblyName)
        {
            this.Location = location;
            this.AssemblyName = assemblyName;

            this.Version = ResolveVersion(location);

        }

        private Version ResolveVersion(string location)
        {

            Match m = Regex.Match(location, @"(?<version>\d+\.\d+.\d?.\d?)", RegexOptions.IgnoreCase);
            var versionValue = m.Groups["version"].Value;
            if (!string.IsNullOrEmpty(versionValue))
                versionValue = versionValue.Trim(Path.DirectorySeparatorChar);
            if (Version.TryParse(versionValue, out Version version))
                return version;

            return null;

        }

        public string Location { get; private set; }

        public string AssemblyName { get; private set; }
        public Version Version { get; private set; }

        public PortableExecutableReference ExecutableReference => _executableReference ?? (_executableReference = MetadataReference.CreateFromFile(Location));

        private PortableExecutableReference _executableReference;

        internal void SelectLastest(string location)
        {

            var newVersion = ResolveVersion(location);
            if (newVersion > this.Version)
            {
                this.Location = location;
                this.Version = Version;
                _executableReference = null;
            }

        }

    }




}
