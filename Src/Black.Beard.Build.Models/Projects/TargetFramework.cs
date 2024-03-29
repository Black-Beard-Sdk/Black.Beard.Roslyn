﻿using System.Xml.Linq;

namespace Bb.Projects
{

    public class TargetFramework : PropertyKey
    {

        public TargetFramework(string value) 
            : base("TargetFramework", value)
        {
        }

        public static TargetFramework Net5 { get; } = new TargetFramework("net5.0");

        public static TargetFramework Net6 { get; } = new TargetFramework("net6.0");
        
        public static TargetFramework Net8 { get; } = new TargetFramework("net8.0");
        
        public static TargetFramework Net9 { get; } = new TargetFramework("net9.0");


        public static TargetFramework Netstandard20 { get; } = new TargetFramework("netstandard2.0");

    }

    public class DockerDefaultTargetOS : PropertyKey
    {

        public DockerDefaultTargetOS(string value) 
            : base("DockerDefaultTargetOS", value)
        {

        }

        public static DockerDefaultTargetOS Linux { get; } = new DockerDefaultTargetOS("Linux");
        public static DockerDefaultTargetOS Windows { get; } = new DockerDefaultTargetOS("Windows");


    }

}
