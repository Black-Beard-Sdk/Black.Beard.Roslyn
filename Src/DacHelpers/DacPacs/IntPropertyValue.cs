﻿namespace Bb.DacPacs
{

    public class IntPropertyValue : PropertyValue
    {

        public IntPropertyValue(string key)
            : base(key)
        {

        }

        public static implicit operator IntPropertyValue(int value)
        {
            return new IntPropertyValue(value.ToString());
        }

    }




}
