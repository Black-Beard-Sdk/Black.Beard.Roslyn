using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Bb.Json.Jslt.Builds
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
                Add(item);

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

            Add( assembly.Location);

        }

        public void Add(string location)
        {

            if (File.Exists(location))
                throw new FileNotFoundException(location);

            PortableExecutableReference newReference = AssemblyMetadata
                .CreateFromFile(location)
                .GetReference();

            if (!this._references.ContainsKey(location))
                this._references.Add(location, newReference);

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
