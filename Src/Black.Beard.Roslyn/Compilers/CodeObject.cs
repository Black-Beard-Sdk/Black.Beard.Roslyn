using System;

namespace Bb.Compilers
{
    public class CodeObject
    {

        public CodeObject(string name, string[] baseTypes)
        {
            this.Name = name;
            this.BaseTypes = baseTypes;
        }

        public bool EvaluateInherit(string name)
        {

            foreach (var item in this.BaseTypes)
                if (item.EndsWith(name))
                    return true;

            return false;

        }


        public bool Evaluate(Type type)
        {

            if (type.Name == this.Name)
            {
                if (!string.IsNullOrEmpty(this.Namespace))
                {
                    if (type.Namespace == this.Namespace)
                        return true;
                }
                else
                    return true;
            }

            return false;

        }

        public bool EvaluateInherit(Type type)
        {

            if (type.BaseType != null)
            {

            }

            return false;

        }

        public string Name { get; }

        public string Namespace { get; internal set; }

        public string[] BaseTypes { get; }

    }


}
