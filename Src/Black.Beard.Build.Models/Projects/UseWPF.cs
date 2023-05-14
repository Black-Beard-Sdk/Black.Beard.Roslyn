namespace Bb.Projects
{
    public class UseWPF : PropertyKey
    {

        protected UseWPF(string value) : base("UseWPF", value)
        {

        }

        public static UseWPF True { get; } = new UseWPF("True");

        public static UseWPF False { get; } = new UseWPF("False");

    }

}
