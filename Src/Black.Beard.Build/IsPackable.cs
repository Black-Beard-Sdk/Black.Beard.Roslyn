namespace Bb.Build
{
    public class IsPackable : PropertyKey
    {

        protected IsPackable(string value) : base("IsPackable", value)
        {

        }

        public static IsPackable True { get; } = new IsPackable("True");

        public static IsPackable False { get; } = new IsPackable("False");

    }

}
