namespace Bb.Projects
{
    public class Nullable : PropertyKey
    {

        protected Nullable(string value) : base("Nullable", value)
        {

        }

        public static Nullable True { get; } = new Nullable("True");

        public static Nullable False { get; } = new Nullable("False");

    }

}
