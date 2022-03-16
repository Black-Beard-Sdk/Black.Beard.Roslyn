using Bb.ComponentModel;
using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Bb.Builds
{
    public class AssemblyReferences : IEnumerable<PortableExecutableReference>
    {

        public AssemblyReferences()
        {

            this._references = new Dictionary<string, PortableExecutableReference>();

            AddRange(
                typeof(BuildCSharp),
                typeof(Uri),
                typeof(object),
                typeof(System.ComponentModel.DescriptionAttribute)
                );

        }

        public void AddRange(params Type[] typeAssembly)
        {

            if (typeAssembly == null)
                throw new NullReferenceException(nameof(typeAssembly));

            foreach (var item in typeAssembly)
                Add(item.Assembly);

        }

        public void AddRange(params string[] assemblies)
        {

            if (assemblies == null)
                throw new NullReferenceException(nameof(assemblies));

            foreach (var item in assemblies)
                AddAssemblyFile(item);

        }

        public void AddRange(params Assembly[] assemblies)
        {

            if (assemblies == null)
                throw new NullReferenceException(nameof(assemblies));

            foreach (var item in assemblies)
                Add(item);

        }

        public void Add(Type type)
        {

            if (type == null)
                throw new NullReferenceException(nameof(type));

            Add(type.Assembly);

        }

        public void Add(Assembly assembly)
        {

            if (assembly == null)
                throw new NullReferenceException(nameof(assembly));

            AddAssemblyFile(assembly.Location);

        }

        public void AddAssemblyFile(string location)
        {

            if (!File.Exists(location))
                throw new FileNotFoundException(location);

            PortableExecutableReference newReference = AssemblyMetadata
                .CreateFromFile(location)
                .GetReference();

            if (!this._references.ContainsKey(location))
                this._references.Add(location, newReference);

        }

        public void AddAssemblyName(string assemblyName)
        {

            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName));

            var ass = TypeDiscovery.Instance.AddAssemblyname(assemblyName);

            if (ass == null)
                throw new FileLoadException(assemblyName);

            Add(ass);

        }

        public void Add(string key, PortableExecutableReference reference)
        {

            if (reference == null)
                throw new NullReferenceException(nameof(reference));

            if (!this._references.ContainsKey(key))
                this._references.Add(key, reference);

        }

        public IEnumerator<PortableExecutableReference> GetEnumerator()
        {
            foreach (var item in this._references)
                yield return item.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in this._references)
                yield return item.Value;
        }

        private readonly Dictionary<string, PortableExecutableReference> _references;

    }



}
