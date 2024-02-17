using Bb.Analysis;
using Bb.ComponentModel;
using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Specialized;
using Refs;

namespace Bb.Builds
{

    /// <summary>
    /// Assembly references
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable&lt;Microsoft.CodeAnalysis.PortableExecutableReference&gt;" />
    public class AssemblyReferences : IEnumerable<KeyValuePair<string, PortableExecutableReference>>
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyReferences"/> class.
        /// </summary>
        public AssemblyReferences()
        {
            this._references = new Dictionary<string, PortableExecutableReference>();
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

            return AddAssemblyLocation(assembly.Location);

        }

        #endregion Types and assemblies

        /// <summary>
        /// search filename in the sdk folder and add the reference
        /// </summary>
        /// <param name="filename"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public PortableExecutableReference ResolveFilename(string assemblyFilename)
        {

            FileReferences references = Sdk.GetReferences();

            var l = references.Resolve(assemblyFilename);

            if (l == null)
                throw new FileNotFoundException(assemblyFilename);

            return AddAssemblyLocation(l);

        }

        /// <summary>
        /// Adds the assembly reference by assembly name.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <exception cref="System.ArgumentNullException">assemblyName</exception>
        /// <exception cref="System.IO.FileLoadException"></exception>
        public PortableExecutableReference ResolveAssemblyName(string assemblyName)
        {

            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName));

            var item = Libs.Items.Where(c => c.Name == assemblyName).FirstOrDefault();

            if (item == null)
                throw new FileLoadException(assemblyName);

            string lib = Sdk.GetReferences().Resolve(assemblyName);

            if (!string.IsNullOrEmpty(lib))
                return AddAssemblyLocation(lib);

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


        //public void Append(params string[] assemblies)
        //{
        //    var references = Sdk.GetReferences();
        //    foreach (var item in assemblies)
        //    {
        //        var lib = references.Where(c => c == item).FirstOrDefault();
        //        if (lib != null)
        //            AddReference(lib);
        //        else
        //            throw new InvalidDataException(item);
        //    }
        //}


        /// <summary>
        /// Adds the assembly location path.
        /// </summary>
        /// <param name="assemblyLocation">The assembly location.</param>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public PortableExecutableReference AddAssemblyLocation(string assemblyLocation)
        {

            if (!File.Exists(assemblyLocation))
                throw new FileNotFoundException(assemblyLocation);

            return Add(assemblyLocation, MetadataReference.CreateFromFile(assemblyLocation));

        }

        /// <summary>
        /// Adds the specified references.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="reference">The reference.</param>
        /// <exception cref="System.NullReferenceException">reference</exception>
        public PortableExecutableReference Add(string key, PortableExecutableReference reference)
        {

            if (reference == null)
                throw new NullReferenceException(nameof(reference));

            if (!this._references.TryGetValue(key, out var instance))
                this._references.Add(key, instance = reference);

            return instance;

        }

        #endregion Add


        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, PortableExecutableReference>> GetEnumerator()
        {
            foreach (var item in this._references)
                yield return item;
        }

        public IEnumerable<PortableExecutableReference> Libraries()
        {
            foreach (var item in this._references)
                yield return item.Value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in this._references)
                yield return item;
        }

        #endregion IEnumerable


        //internal void AppendAssemblies()
        //{
        //    References references = Sdk.GetReferences();
        //    //AddAssemblyPath(references.Resolve(Refs.Net60.Microsoft.Win32.Registry.Lib.Dll));
        //    //string path = Sdk.Directory.FullName;
        //    ////AddAssemblyPath(Path.Combine(path, CommonNet.netstandard.Lib.Dll + ".dll"));
        //    //AddAssemblyPath(Path.Combine(path, "System.dll"));
        //    //AddAssemblyPath(Path.Combine(path, "System.Core.dll"));
        //    //AddAssemblyPath(Path.Combine(path, CommonNet.System.Runtime.Lib.Dll + ".Extensions.dll"));
        //    //AddAssemblyPath(Path.Combine(path, CommonNet.System.Runtime.Lib.Dll + ".dll"));
        //    ////AddReference(references.Reference(typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo)));
        //}

        public FrameworkVersion Sdk { get; internal set; }


        private readonly Dictionary<string, PortableExecutableReference> _references;

    }



}
