using Microsoft.CodeAnalysis;
using System.Collections;
using System.Reflection;
using Refs;
using ICSharpCode.Decompiler.Metadata;
using System;

namespace Bb.Builds
{


    /// <summary>
    /// Assembly references
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable&lt;Reference&gt;" />
    public class AssemblyReferences : IEnumerable<Reference>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyReferences"/> class.
        /// </summary>
        public AssemblyReferences()
        {
            this._referencesByAssembly = new Dictionary<string, Dictionary<Version, Reference>>();
        }


        #region Add

        #region Types and assemblies

        /// <summary>
        /// Adds assemblies references from types.
        /// </summary>
        /// <param name="typeAssembly">The type assembly.</param>
        /// <exception cref="System.NullReferenceException">typeAssembly</exception>
        public AssemblyReferences AddByTypes(params Type[] typeAssembly)
        {

            if (typeAssembly == null)
                throw new NullReferenceException(nameof(typeAssembly));

            foreach (var item in typeAssembly)
                AddByAssembly(item.Assembly);

            return this;

        }

        /// <summary>
        /// Adds the reference by assembly from specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="System.NullReferenceException">type</exception>
        public AssemblyReferences AddByType(Type type)
        {

            if (type == null)
                throw new NullReferenceException(nameof(type));

            AddByAssembly(type.Assembly);

            return this;

        }

        /// <summary>
        /// Adds assembly list in references.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <exception cref="System.NullReferenceException">assemblies</exception>
        public AssemblyReferences AddByAssemblies(params Assembly[] assemblies)
        {

            if (assemblies == null)
                throw new NullReferenceException(nameof(assemblies));

            foreach (var item in assemblies)
                AddByAssembly(item);

            return this;

        }

        /// <summary>
        /// Adds the reference by specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <exception cref="System.NullReferenceException">assembly</exception>
        public AssemblyReferences AddByAssembly(Assembly assembly)
        {

            if (assembly == null)
                throw new NullReferenceException(nameof(assembly));

            AddAssemblyLocation(assembly.Location);

            return this;

        }

        #endregion Types and assemblies

        /// <summary>
        /// search filename in the sdk folder and add the reference
        /// </summary>
        /// <param name="filename"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public AssemblyReferences AddResolveFilename(string assemblyFilename)
        {

            FileReferences references = Sdk.GetReferences();

            var l = references.Resolve(assemblyFilename)?.FirstOrDefault();

            if (l == null)
                throw new FileNotFoundException(assemblyFilename);

            AddAssemblyLocation(l);

            return this;

        }


        /// <summary>
        /// Adds the assembly reference by assembly name.
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="Version">The version to find.</param>
        /// <exception cref="System.ArgumentNullException">assemblyName</exception>
        /// <exception cref="System.IO.FileLoadException"></exception>
        public Reference ResolveAssemblyName(string assemblyName, Func<ReferenceType, List<Reference>, Reference> func)
        {

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            List<string> list;
            string lib = null;
            List<Reference> referenceList = null;
            Reference reference = null;
            var references = Sdk.GetReferences();

            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName));


            referenceList = SearchInRegistered(assemblyName);
            if (referenceList != null)
                reference = func(ReferenceType.Local, referenceList.ToList());


            if (reference != null)
                return reference;


            var item = Libs.Items.Where(c => c.Name == assemblyName).FirstOrDefault(); // try to resolve the name of the file assembly
            if (item != null)
            {

                list = references.Resolve(item.File)?.ToList();
                if (list != null && list.Count > 0)
                {
                    referenceList = new List<Reference>(list.Count);

                    foreach (var item1 in list)
                        referenceList.Add(new Reference(item1));

                    reference = func(ReferenceType.CollectedByFrameworkNamed, referenceList);
                    if (reference != null)
                    {
                        if (AddInRecoveryIfNotFound)
                            AddAssemblyLocation(reference.Location);
                        AddAssemblyLocation(reference.Location);
                        return reference;
                    }

                }

            }


            list = references.Resolve(assemblyName)?.ToList();
            if (list != null && list.Count > 0)
            {

                referenceList = new List<Reference>(list.Count);

                foreach (var item1 in list)
                    referenceList.Add(new Reference(item1));

                reference = func(ReferenceType.CollectedByFrameworkNamed, referenceList);

                if (reference != null)
                {
                    if (AddInRecoveryIfNotFound) 
                        AddAssemblyLocation(reference.Location);
                    return reference;
                }

            }


            if (UseNugetForRecovery)
            {
                reference = SearchNext(assemblyName, func);
                if (reference != null)
                {
                    if (AddInRecoveryIfNotFound)
                        AddAssemblyLocation(reference.Location);
                    return reference;
                }
            }

            return null;

        }



        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <exception cref="System.NullReferenceException">assemblies</exception>
        public AssemblyReferences AddAssemblyFiles(params string[] assemblies)
        {

            if (assemblies == null)
                throw new NullReferenceException(nameof(assemblies));

            foreach (var item in assemblies)
                AddAssemblyLocation(item);

            return this;

        }



        /// <summary>
        /// Adds the specified references.
        /// </summary>
        /// <param name="location">The key.</param>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="Version">The version to find.</param>
        /// <exception cref="System.NullReferenceException">reference</exception>
        public Reference AddAssemblyLocation(string location)
        {

            if (location == null)
                throw new NullReferenceException(nameof(location));


            foreach (var item1 in _referencesByAssembly.Values)
                foreach (var item2 in item1.Values)
                    if (item2.Location == location)
                        return item2;


            Reference instance = new Reference(location);

            return AddReference(instance);

        }

        public Reference AddReference(Reference instance)
        {
            if (!_referencesByAssembly.TryGetValue(instance.AssemblyName, out var versions))
                _referencesByAssembly.Add(instance.AssemblyName, versions = new Dictionary<Version, Reference>());

            if (!versions.ContainsKey(instance.Version))
                versions.Add(instance.Version, instance);
            else
                versions[instance.Version] = instance;

            return instance;
        }


        /// <summary>
        /// Return the specified references.
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="Version">The version to find.</param>
        /// <exception cref="System.NullReferenceException">reference</exception>
        public Reference SearchInRegistered(string assemblyName, Version version)
        {

            if (_referencesByAssembly.TryGetValue(assemblyName, out var versions))
                if (versions.TryGetValue(version, out var instance))
                {
                    return instance;
                }
                else
                {
                    return versions.Values.Where(c => c.Version >= version).OrderByDescending(c => c.Version).FirstOrDefault();
                }

            return null;

        }

        /// <summary>
        /// Return the specified references.
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="Version">The version to find.</param>
        /// <exception cref="System.NullReferenceException">reference</exception>
        public List<Reference> SearchInRegistered(string assemblyName)
        {

            if (_referencesByAssembly.TryGetValue(assemblyName, out var versions))
                return versions.Values.ToList();

            return default;

        }

        #endregion Add


        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Reference> GetEnumerator()
        {
            foreach (var item in this._referencesByAssembly)
                foreach (var item2 in item.Value)
                    yield return item2.Value;
        }

        public IEnumerable<(string, List<(Version, PortableExecutableReference)>)> Libraries()
        {
            foreach (var item in this._referencesByAssembly)
            {

                var list = new List<(Version, PortableExecutableReference)>(item.Value.Count);

                foreach (var item2 in item.Value.OrderByDescending(c => c.Key))
                    list.Add((item2.Key, item2.Value.ExecutableReference));

                yield return (item.Key, list);

            }

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


        public Reference SearchNext(string name, Func<ReferenceType, List<Reference>, Reference> func)
        {

            if (_next != null)
                return _next.ResolveAssemblyName(name, this.Sdk, func);

            return null;

        }


        /// <summary>
        /// return true if the file is in the sdk directory
        /// </summary>
        /// <param name="fullName">file location</param>
        /// <returns></returns>
        public bool IsInSdk(string fullName)
        {
            return this.Sdk.IsInSdk(new FileInfo(fullName));
        }


        /// <summary>
        /// return true if the file is in the sdk directory
        /// </summary>
        /// <param name="file">file location</param>
        /// <returns></returns>
        public bool IsInSdk(FileInfo file)
        {
            return this.Sdk.IsInSdk(file);
        }


        #endregion IEnumerable


        public bool AddInRecoveryIfNotFound { get; set; }

        public bool UseNugetForRecovery { get; set; }

        public FrameworkVersion Sdk { get; internal set; }

        private IAssemblyReferenceResolver _next;
        private readonly Dictionary<string, Dictionary<Version, Reference>> _referencesByAssembly;

    }


    public enum ReferenceType
    {
        Local,
        CollectedByFrameworkNamed,
        Freesearch,
        Nuget
    }


}
