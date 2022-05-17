using System;
using System.Xml.Linq;

namespace Bb.Build
{
    public class References : ItemGroup
    {

        public References()
        {
        }


        public References Reference(string referenceName, string path, Action<Reference>? initializer = null)
        {

            if (string.IsNullOrEmpty(referenceName))
                throw new ArgumentNullException(nameof(referenceName));

            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
  

            var package = new Reference(referenceName, path);
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
