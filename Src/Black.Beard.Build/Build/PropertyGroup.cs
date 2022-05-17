using System;
using System.Xml.Linq;

namespace Bb.Build
{

    public class PropertyGroup : Group
    {

        public PropertyGroup() 
            : base (false)
        {
        }

        public XElement Serialize()
        {
            var result = new XElement("PropertyGroup");
            Serialize(result);
            return result;
        }

        public PropertyGroup TargetFramework(TargetFramework value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Add(value);
            return this;
        }

        public PropertyGroup AssemblyVersion(Version version)
        {
            if (version != null)
                Add(new Build.AssemblyVersion(version));
            return this;
        }
        
        public PropertyGroup FileVersion(Version version)
        {
            if (version != null)
                Add(new Build.FileVersion(version));
            return this;
        }

        public PropertyGroup GeneratePackageOnBuild(bool packageOnBuild = true)
        {
            if (packageOnBuild)
                Add(Build.GeneratePackageOnBuild.True);
            else
                Add(Build.GeneratePackageOnBuild.False);
            return this;
        }

        public PropertyGroup Nullable(bool nullabble = true)
        {
            if (nullabble)
                Add(Build.Nullable.True);
            else
                Add(Build.Nullable.False);
            return this;
        }

        public PropertyGroup IsPackable(bool packable = true)
        {
            if (packable)
                Add(Build.IsPackable.True);
            else
                Add(Build.IsPackable.False);
            return this;
        }

        public PropertyGroup ImplicitUsings(bool activated = true)
        {
            if (activated)
                Add(Build.ImplicitUsings.Enabled);
            else
                Add(Build.ImplicitUsings.Disabled);
            return this;
        }

        public PropertyGroup UseWPF(bool activated = true)
        {
            if (activated)
                Add(Build.UseWPF.True);
            else
                Add(Build.UseWPF.False);
            return this;
        }

        public PropertyGroup UseWindowsForms(bool activated = true)
        {
            if (activated)
                Add(Build.UseWindowsForms.True);
            else
                Add(Build.UseWindowsForms.False);
            return this;
        }

        public PropertyGroup RootNamespace(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add(new Build.RootNamespace(value));
            return this;
        }

        public PropertyGroup PackageReadmeFile(string value)
        {
            if (!string.IsNullOrEmpty(value)) 
                Add(new PackageReadmeFile(value));
            return this;
        }

        public PropertyGroup PackageProjectUrl(string value)
        {
            if (!string.IsNullOrEmpty(value)) 
                Add(new PackageProjectUrl(value));
            return this;
        }

        public PropertyGroup Description(string value)
        {
            if (!string.IsNullOrEmpty(value)) 
                Add(new Description(value));
            return this;
        }

        public PropertyGroup StartupObject(string value)
        {
            if (!string.IsNullOrEmpty(value)) 
                Add(new StartupObject(value));
            return this;
        }

        public PropertyGroup RepositoryUrl(Uri value)
        {
            if (value != null) 
                Add(new RepositoryUrl(value.ToString()));
            return this;
        }

        public PropertyGroup SqlServerVersion(SqlServerVersion value)
        {
            if (value != null)
                Add(value);
            return this;
        }
    }

}
