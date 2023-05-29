
namespace Bb.Projects
{

    public class PackageReference : Group
    {

        public PackageReference(string value, Version version) : base("PackageReference", true)
        {

            AddAttribute("Include", value);
            if (version != null )
                AddAttribute("Version", version.ToString());
        }

    }

}
