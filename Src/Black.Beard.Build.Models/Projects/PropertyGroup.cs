using System.Xml.Linq;

namespace Bb.Projects
{

    public class PropertyGroup : Group
    {

        public PropertyGroup()
            : base(false)
        {
        }

        public XElement Serialize()
        {
            var result = new XElement("PropertyGroup");
            Serialize(result);
            return result;
        }

        public PropertyGroup GenerateDocumentationFile(bool value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Add(new GenerateDocumentationFile(value));
            return this;
        }

        public PropertyGroup AddRazorSupportForMvc(bool value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Add(new AddRazorSupportForMvc(value));
            return this;
        }

        public PropertyGroup RazorLangVersion(Version value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Add(new RazorLangVersion(value));
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
                Add(new LangVersion(version));
            return this;
        }


        public PropertyGroup AssemblyVersion(Version version)
        {
            if (version != null)
                Add(new AssemblyVersion(version));
            return this;
        }

        public PropertyGroup FileVersion(Version version)
        {
            if (version != null)
                Add(new FileVersion(version));
            return this;
        }

        public PropertyGroup GeneratePackageOnBuild(bool packageOnBuild = true)
        {
            if (packageOnBuild)
                Add(Projects.GeneratePackageOnBuild.True);
            else
                Add(Projects.GeneratePackageOnBuild.False);
            return this;
        }

        public PropertyGroup Nullable(bool nullabble = true)
        {
            if (nullabble)
                Add(Projects.Nullable.True);
            else
                Add(Projects.Nullable.False);
            return this;
        }

        public PropertyGroup IsPackable(bool packable = true)
        {
            if (packable)
                Add(Projects.IsPackable.True);
            else
                Add(Projects.IsPackable.False);
            return this;
        }

        public PropertyGroup ImplicitUsings(bool activated = true)
        {
            if (activated)
                Add(Projects.ImplicitUsings.Enabled);
            else
                Add(Projects.ImplicitUsings.Disabled);
            return this;
        }

        public PropertyGroup UseWPF(bool activated = true)
        {
            if (activated)
                Add(Projects.UseWPF.True);
            else
                Add(Projects.UseWPF.False);
            return this;
        }

        public PropertyGroup UseWindowsForms(bool activated = true)
        {
            if (activated)
                Add(Projects.UseWindowsForms.True);
            else
                Add(Projects.UseWindowsForms.False);
            return this;
        }

        public PropertyGroup RootNamespace(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Add(new Projects.RootNamespace(value));
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

        public PropertyGroup RepositoryUrl(string value)
        {
            return RepositoryUrl(new System.Uri(value));
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
