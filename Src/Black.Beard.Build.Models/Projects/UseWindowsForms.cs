namespace Bb.Projects
{
    public class UseWindowsForms : PropertyKey
    {

        protected UseWindowsForms(string value) : base("UseWindowsForms", value)
        {

        }

        public static UseWindowsForms True { get; } = new UseWindowsForms("True");

        public static UseWindowsForms False { get; } = new UseWindowsForms("False");

    }

}
