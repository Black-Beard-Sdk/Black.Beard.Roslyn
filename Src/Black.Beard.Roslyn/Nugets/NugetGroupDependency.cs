﻿using System.Xml.Linq;

namespace Bb.Nugets
{
    public class NugetGroupDependency
    {

        internal NugetGroupDependency(XElement item)
        {

            foreach (var attribute in item.Attributes())
                if (attribute.Name.LocalName == "targetFramework")
                    TargetFramework = attribute.Value;

            foreach (var c in item.Elements())
            {
                var n = c.Name.LocalName;
                if (n.ToLower() == "dependency")
                    _dependencies.Add(new NugetDependency(c));
            }

        }

        /// <summary>
        /// target framework
        /// </summary>
        public string TargetFramework { get; }


        override public string ToString()
        {
            return TargetFramework;
        }


        public IEnumerable<NugetDependency> Dependencies() => _dependencies;


        private readonly List<NugetDependency> _dependencies = new List<NugetDependency>();

    }


}