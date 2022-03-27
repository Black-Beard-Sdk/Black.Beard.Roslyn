using System;
using System.Xml.Linq;

namespace Bb.Build
{


    public class PackageReferences : ItemGroup
    {

        public PackageReferences()
        {

        }

        public PackageReferences PackageReference(string packageName, Version version, Action<PackageReference> initializer = null)
        {
            
            if (string.IsNullOrEmpty(packageName))
                throw new ArgumentNullException(nameof(packageName));
            
            if (version == null)
                throw new ArgumentNullException(nameof(version));

            var package = new PackageReference(packageName, version);
            if (initializer != null)
                initializer(package);

            Add(package);

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
