﻿namespace Bb.DacPacs
{

    public class FileFormatVersionPropertyValue : PropertyValue
    {

        private FileFormatVersionPropertyValue(string key) 
            : base(key)
        {

        }

        public static FileFormatVersionPropertyValue Version12 = new FileFormatVersionPropertyValue("1.2");

    }




}
