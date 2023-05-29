using System;
using System.Xml.Linq;

namespace Bb.Projects
{

    public class PropertyGroup : Group
    {

        public PropertyGroup()
            : base("PropertyGroup", false)
        {
        }

        public PropertyGroup GenerateDocumentationFile(bool value = true)
        {
            Add("GenerateDocumentationFile", value);
            return this;
        }

        public PropertyGroup AddRazorSupportForMvc(bool value = true)
        {
            Add("AddRazorSupportForMvc", value);
            return this;
        }

        public PropertyGroup RazorLangVersion(Version value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Add("RazorLangVersion", value);
            return this;
        }

        public PropertyGroup TargetFramework(TargetFramework value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Add(value);
            return this;
        }

        public PropertyGroup LangVersion(Version version)
        {
            if (version != null)
                Add("LangVersion", version);
            return this;
        }

        public PropertyGroup AssemblyVersion(Version version)
        {
            if (version != null)
                Add("AssemblyVersion", version);
            return this;
        }

        public PropertyGroup FileVersion(Version version)
        {
            if (version != null)
                Add("FileVersion", version);
            return this;
        }

        public PropertyGroup GeneratePackageOnBuild(bool value = true)
        {
            Add("GeneratePackageOnBuild", value);
            return this;
        }               

        public PropertyGroup DockerDefaultTargetOS(DockerDefaultTargetOS value)
        {
            Add(value);
            return this;
        }

        public PropertyGroup UserSecretsId(Guid value)
        {
            Add("UserSecretsId", value);
            return this;
        }

        public PropertyGroup UserSecretsId(string value)
        {
            Add("UserSecretsId", Guid.Parse(value));
            return this;
        }

        public PropertyGroup UserSecretsId()
        {
            Add("UserSecretsId", Guid.NewGuid());
            return this;
        }

        public PropertyGroup IsPackable(bool value = true)
        {
            Add("IsPackable", value);
            return this;
        }

        public PropertyGroup Nullable(bool value = true)
        {
            if (value)
                Add("Nullable", "enable");
            else
                Add("Nullable", "disable");
            return this;
        }

        public PropertyGroup ImplicitUsings(bool activated = true)
        {
            if (activated)
                Add("ImplicitUsings", "enable");
            else
                Add("ImplicitUsings", "disable");
            return this;
        }

        public PropertyGroup UseWPF(bool value = true)
        {
            Add("UseWPF", value);
            return this;
        }

        public PropertyGroup UseWindowsForms(bool value = true)
        {
            Add("UseWindowsForms", value);
            return this;
        }

        public PropertyGroup RootNamespace(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add("RootNamespace", value);
            return this;
        }

        public PropertyGroup PackageReadmeFile(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add("PackageReadmeFile", value);
            return this;
        }

        public PropertyGroup PackageProjectUrl(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add("PackageProjectUrl", value);
            return this;
        }

        public PropertyGroup Description(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add("Description", value);
            return this;
        }

        public PropertyGroup StartupObject(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add("StartupObject", value);
            return this;
        }

        public PropertyGroup RepositoryUrl(string value)
        {
            if (value != null)
                Add("RepositoryUrl", value);
            return this;
        }

        public PropertyGroup RepositoryUrl(Uri value)
        {
            if (value != null)
                Add("RepositoryUrl", value);

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
