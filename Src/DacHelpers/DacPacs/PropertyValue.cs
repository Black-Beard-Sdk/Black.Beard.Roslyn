namespace Bb.DacPacs
{

    public class PropertyValue
    {

        protected PropertyValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }

    }

}
