using System.Text.RegularExpressions;

namespace Bb.Analysis
{
    public static class FrameworkKeys
    {

        static FrameworkKeys()
        {

            //Add(new FrameworkKey("net1.0", new Version(1, 0), 800));
            //Add(new FrameworkKey("net1.1", new Version(1, 1), 800));
            //Add(new FrameworkKey("net2.0", new Version(2, 0), 800));


            Unknown = new FrameworkKey("unknown", new Version(0, 0), 0);


            Add(Netstandard20 = new FrameworkKey("netstandard2.0", new Version(2, 0), 800));
            Add(Netcoreapp21 = new FrameworkKey("netcoreapp2.1", new Version(2, 1), 800));
            Add(Netcoreapp22 = new FrameworkKey("netcoreapp2.2", new Version(2, 2), 800));
            Add(Netcoreapp30 = new FrameworkKey("netcoreapp3.0", new Version(3, 0), 800));
            Add(Netcoreapp31 = new FrameworkKey("netcoreapp3.1", new Version(3, 1), 800));

            //Add(new FrameworkKey("netcore4.5", new Version(4, 5), 800));
            //Add(new FrameworkKey("netcore5.0", new Version(5, 0), 800));

            //Add("net30", Netcoreapp30);
            //Add("net35", Netcoreapp30);

            //Add("net40", new FrameworkKey("netcoreapp4.0", new Version(4, 0), 800));

            Add(Net45 = new FrameworkKey("net4.5", new Version(4, 5), 800));
            Add("net451", Net45);
            Add("net452", Net45);


            Add(Net46 = new FrameworkKey("net4.6", new Version(4, 6), 800));
            Add("net461", Net46);
            Add("net462", Net46);
            Add("net463", Net46);

            Add(Net47 = new FrameworkKey("net4.7", new Version(4, 7), 800));
            Add("net471", Net47);
            Add("net472", Net47);

            Add(Net48 = new FrameworkKey("net4.8", new Version(4, 8), 800));
            Add(Net50 = new FrameworkKey("net5.0", new Version(5, 0), 900));
            Add(Net60 = new FrameworkKey("net6.0", new Version(6, 0), 1000));
            Add(Net70 = new FrameworkKey("net7.0", new Version(7, 0), 1100));
            Add(Net80 = new FrameworkKey("net8.0", new Version(8, 0), 1200));

            Add(Net80 = new FrameworkKey("net9.0", new Version(8, 0), 1300));

        }


        /// <summary>
        /// Add a new framework key
        /// </summary>
        /// <param name="frameworkKey"></param>
        public static FrameworkKey Add(FrameworkKey frameworkKey)
        {
            return Add(frameworkKey.Name, frameworkKey);
        }


        /// <summary>
        /// Add a new framework key
        /// </summary>
        /// <param name="frameworkKey"></param>
        public static FrameworkKey Add(string key, FrameworkKey frameworkKey)
        {

            var k = key.ToLower().Replace(".", "");
            if (!FrameworkKeys._keys.ContainsKey(k))
                FrameworkKeys._keys.Add(k, frameworkKey);

            var l = NormalizeKey(k);
            if (!FrameworkKeys._keys.ContainsKey(l))
                FrameworkKeys._keys.Add(k, frameworkKey);

            return frameworkKey;

        }

        public static string NormalizeKey(string key)
        {

            var k = key.ToLower().Replace(".", "");

            if (k.StartsWith("portable-"))
                k = k.Substring("portable-".Length);

            if (k.Contains("-"))
            {
                var p = k.IndexOf("-");
                k = k.Substring(0, p);
            }

            if (k.Contains("+"))
            {
                var p = k.IndexOf("+");
                k = k.Substring(0, p);
            }

            return k;

        }


        /// <summary>
        /// resolve by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static FrameworkKey Resolve(string key)
        {

            FrameworkKey result;

            var k = key.ToLower().Replace(".", "");

            if (FrameworkKeys._keys.TryGetValue(k, out result))
                return result;

            k = NormalizeKey(key);
            if (FrameworkKeys._keys.TryGetValue(k, out result))
                return result;

            if (Resolver != null)
            {
                
                var r = Resolver(key);
                
                if (r != null)
                    return r;

            }

            return Unknown;

        }

        public static Func<string, FrameworkKey> Resolver { get; set; }    

        /// <summary>
        /// resolve by version
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static FrameworkKey Resolve(Version version)
        {
            var major = version.Major;
            var minor = version.Minor;

            var list = _keys
                .Where(c => c.Value.Version.Major == major
                    && c.Value.Version.Minor == minor).ToList();

            return list.OrderBy(c => c.Value.Version).Last().Value;

        }

        /// <summary>
        /// return all framework keys
        /// </summary>
        public static IEnumerable<FrameworkKey> All
        {
            get
            {
                foreach (var item in _keys)
                    yield return item.Value;
            }
        }


        public static FrameworkKey Netstandard20 { get; }
        public static FrameworkKey Netcoreapp21 { get; }
        public static FrameworkKey Netcoreapp22 { get; }
        public static FrameworkKey Netcoreapp30 { get; }
        public static FrameworkKey Netcoreapp31 { get; }
        public static FrameworkKey Net45 { get; }
        public static FrameworkKey Net46 { get; }
        public static FrameworkKey Net461 { get; }
        public static FrameworkKey Net462 { get; }
        public static FrameworkKey Net47 { get; }
        public static FrameworkKey Net48 { get; }
        public static FrameworkKey Net50 { get; }
        public static FrameworkKey Net60 { get; }
        public static FrameworkKey Net70 { get; }
        public static FrameworkKey Net80 { get; }

        public static FrameworkKey Unknown { get; }


        private static Dictionary<string, FrameworkKey> _keys = new Dictionary<string, FrameworkKey>();                      

    }

}
