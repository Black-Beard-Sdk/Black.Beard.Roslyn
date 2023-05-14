using System.Xml.Linq;

namespace Bb.Projects
{

    public class ProjectReferences : ItemGroup
    {


        public ProjectReferences()
        {

        }

        public ProjectReferences PackageReference(string packageName, Action<ProjectReference> initializer = null)
        {

            if (string.IsNullOrEmpty(packageName))
                throw new ArgumentNullException(nameof(packageName));
    

            var projectReference = new ProjectReference(packageName);
            if (initializer != null)
                initializer(projectReference);

            Add(projectReference);

            return this;

        }

        public XElement Serialize()
        {
            var result = new XElement("ItemGroup");
            Serialize(result);
            return result;
        }


    }


}
