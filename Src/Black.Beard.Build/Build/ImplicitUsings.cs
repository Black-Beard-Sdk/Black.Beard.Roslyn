namespace Bb.Build
{
    public class ImplicitUsings : PropertyKey
    {


        protected ImplicitUsings(string value) : base("ImplicitUsings", value)
        {

        }

        public static ImplicitUsings Enabled { get; } = new ImplicitUsings("Enabled");

        public static ImplicitUsings Disabled { get; } = new ImplicitUsings("Disabled");


    }

}
