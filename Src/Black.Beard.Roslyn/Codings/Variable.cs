using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{
    public class Variable
    {

        public Variable(string name, string type1, Type type2)
        {
            Name = name;
            Type1 = type1;
            Type2 = type2;
        }

        public string Name { get; }

        public string Type1 { get; }

        public Type Type2 { get; }

        public TypeSyntax Type
        {
            get
            {
                if (Type1 != null)
                    return Type1.AsType();

                return Type2.AsType();

            }
        }


    }


}
