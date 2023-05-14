namespace Bb.Projects
{
    public class GeneratePackageOnBuild : PropertyKey
    {
        protected GeneratePackageOnBuild(string value) : base("GeneratePackageOnBuild", value)
        {

        }

        public static GeneratePackageOnBuild True { get; } = new GeneratePackageOnBuild("True");
        
        public static GeneratePackageOnBuild False { get; } = new GeneratePackageOnBuild("False");

    }

}
