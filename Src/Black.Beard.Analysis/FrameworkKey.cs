using System.Diagnostics;
using System.Reflection;


namespace Bb.Analysis
{


    [DebuggerDisplay("{Name} {Version}")]
    public class FrameworkKey
    {

        internal FrameworkKey()
        {

        }

        static FrameworkKey()
        {
            // netstandard13

            Unknown = new FrameworkKey("unknown key", new Version(0, 0), 0);

            Add(Netstandard10 = new FrameworkKey("netstandard1.0", new Version(1, 0), 800));
            Add("v1.0", Netstandard10);

            Add(Netstandard13 = new FrameworkKey("netstandard1.3", new Version(1, 3), 800));
            Add("v1.3", Netstandard13);

            Add(Netstandard16 = new FrameworkKey("netstandard1.6", new Version(1, 6), 800));
            Add("v1.6", Netstandard16);

            Add(Netstandard20 = new FrameworkKey("netstandard2.0", new Version(2, 0), 800));
            Add("v2.0", Netstandard20);

            Add(Netstandard21 = new FrameworkKey("netstandard2.1", new Version(2, 1), 800));
            Add("v2.1", Netstandard20);

            Add(Netcoreapp20 = new FrameworkKey("netcoreapp2.0", new Version(2, 0), 800));

            Add(Netcoreapp21 = new FrameworkKey("netcoreapp2.1", new Version(2, 1), 800));
            Add("v2.1", Netcoreapp21);

            Add(Netcoreapp22 = new FrameworkKey("netcoreapp2.2", new Version(2, 2), 800));
            Add("v2.2", Netcoreapp22);
            
            Add(Netcoreapp30 = new FrameworkKey("netcoreapp3.0", new Version(3, 0), 800));
            Add("net30", Netcoreapp30);
            Add("v3.0", Netcoreapp30);
            
            Add(Netcoreapp31 = new FrameworkKey("netcoreapp3.1", new Version(3, 1), 800));
            Add("v3.1", Netcoreapp31);

            //Add(new FrameworkKey("netcore4.5", new Version(4, 5), 800));
            //Add(new FrameworkKey("netcore5.0", new Version(5, 0), 800));

            Add(Netcoreapp35 = new FrameworkKey("netcoreapp3.5", new Version(3, 5), 800));
            Add("v3.5", Netcoreapp35);
            Add("net35", Netcoreapp35);

            //Add("net40", new FrameworkKey("netcoreapp4.0", new Version(4, 0), 800));

            Add(Net45 = new FrameworkKey("net4.5", new Version(4, 5), 800));
            Add("net45", Net45);
            Add("net451", Net45);
            Add("v4.5.1", Net45);
            Add("net452", Net45);
            Add("v4.5.2", Net45);


            Add(Net46 = new FrameworkKey("net4.6", new Version(4, 6), 800));
            Add("net461", Net46);
            Add("v4.6.1", Net46);
            Add("net462", Net46);
            Add("v4.6.2", Net46);
            Add("net463", Net46);
            Add("v4.6.3", Net46);

            Add(Net47 = new FrameworkKey("net4.7", new Version(4, 7), 800));
            Add("net471", Net47);
            Add("v4.7.1", Net47);
            Add("net472", Net47);
            Add("v4.7.2", Net47);

            Add(Net48 = new FrameworkKey("net4.8", new Version(4, 8), 800));
            Add("v4.8", Net48);

            Add(Net50 = new FrameworkKey("net5.0", new Version(5, 0), 900));
            Add("v5.0", Net50);

            Add(Net60 = new FrameworkKey("net6.0", new Version(6, 0), 1000));
            Add("v6.0", Net60);

            Add(Net70 = new FrameworkKey("net7.0", new Version(7, 0), 1100));
            Add("v7.0", Net70);

            Add(Net80 = new FrameworkKey("net8.0", new Version(8, 0), 1200));
            Add("v8.0", Net80);


            Add(Net90 = new FrameworkKey("net9.0", new Version(9, 0), 1300));
            Add("v9.0", Net90);

            FrameworkKey.Current = GetCurrentKey();

        }

        /// <summary>
        /// ctor with name and version
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="languageVersion"></param>
        public FrameworkKey(string name, Version version, int languageVersion)
        {
            this.Name = name;
            this.Version = version;
            this.languageVersion = languageVersion;



        }

        public string Name { get; internal set; }

        public Version Version { get; internal set; }

        public int languageVersion { get; internal set; }

        /// <summary>
        /// convert a string to a framework key
        /// </summary>
        /// <param name="name"></param>
        public static implicit operator FrameworkKey(string name)
        {
            return FrameworkKey.Resolve(name);
        }

        /// <summary>
        /// convert a version to a framework key
        /// </summary>
        /// <param name="name"></param>
        public static implicit operator FrameworkKey(Version name)
        {
            return FrameworkKey.Resolve(name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
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
            if (!FrameworkKey._keys.ContainsKey(k))
                FrameworkKey._keys.Add(k, frameworkKey);

            var l = NormalizeKey(k);
            if (!FrameworkKey._keys.ContainsKey(l))
                FrameworkKey._keys.Add(k, frameworkKey);

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

            if (k.Contains(@"/"))
                k = k.Substring(0, k.IndexOf(@"/"));

            if (FrameworkKey._keys.TryGetValue(k, out result))
                return result;

            k = NormalizeKey(key);
            if (FrameworkKey._keys.TryGetValue(k, out result))
                return result;

            if (Resolver != null)
            {

                var r = Resolver(key);

                if (r != null)
                    return r;

            }

            Trace.TraceWarning($"Framework key not found for {key}");
            return Unknown;

        }

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

            if (list.Count > 1)
            {
                var revision = version.Revision;
                var result = list.Where(c => c.Value.Version.Revision == revision).ToList();
                if (result.Count > 0)
                    list = result;

                if (list.Count > 1)
                {
                    var build = version.Build;
                    result = list.Where(c => c.Value.Version.Build == build).ToList();
                    if (result.Count > 0)
                        list = result;
                }

            }

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


        public static Func<string, FrameworkKey> Resolver { get; set; }


        public static FrameworkKey Netstandard10 { get; }

        public static FrameworkKey Netstandard13 { get; }

        public static FrameworkKey Netstandard16 { get; }

        public static FrameworkKey Netstandard20 { get; }

        public static FrameworkKey Netstandard21 { get; }

        public static FrameworkKey Netcoreapp20 { get; }
        public static FrameworkKey Netcoreapp21 { get; }

        public static FrameworkKey Netcoreapp22 { get; }

        public static FrameworkKey Netcoreapp30 { get; }

        public static FrameworkKey Netcoreapp31 { get; }

        public static FrameworkKey Netcoreapp35 { get; }

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
        
        public static FrameworkKey Net90 { get; }


        public static FrameworkKey Unknown { get; }
        public static FrameworkKey Current { get; }




        #region Resolve current key

        private static FrameworkKey? GetCurrentKey()
        {

            HashSet<Assembly> _h = new HashSet<Assembly>();
            var stack = new StackTrace();
            for (int i = stack.FrameCount - 1; i >= 0; i--)
            {
                var f = stack.GetFrame(i);
                var m = f.GetMethod();
                var a = m.DeclaringType.Assembly;
                if (a != null && a.GetName().Name != "System.Private.CoreLib" && !a.IsDynamic)
                    _h.Add(a);
            }

            HashSet<FrameworkKey> keys = new HashSet<FrameworkKey>();
            foreach (var item in _h)
            {
                var v1 = GetVersion(item);
                if (v1 != null)
                    keys.Add(v1);
            }

            return keys.OrderByDescending(c => c.Version).FirstOrDefault();

        }

        private static FrameworkKey? GetVersion(Assembly assembly)
        {
            var fileAssembly = new FileInfo(assembly.Location);
            var dir = fileAssembly.Directory;
            return GetVersion(dir, Path.GetFileNameWithoutExtension(fileAssembly.Name));
        }

        public static FrameworkKey? GetVersion(DirectoryInfo dir, string pattern)
        {

            var ee = FrameworkHelper.TryGetDeps(dir, pattern);
            if (ee != null)
            {
                var nam = ee.Value.GetString();
                nam = nam.Split(',').Where(c => c.StartsWith("Version=")).FirstOrDefault();
                nam = nam.Substring(nam.IndexOf('=') + 1);
                var r = FrameworkKey.Resolve(nam);
                if (r != FrameworkKey.Unknown)
                    return r;
            }

            ee = FrameworkHelper.TryGetRuntimeConfig(dir, pattern);
            if (ee != null)
            {
                var nam = ee.Value.GetProperty("tfm").GetString();
                return FrameworkKey.Resolve(nam);
            }

            var file = dir.GetFiles(pattern + ".runtimeconfig.json", SearchOption.AllDirectories).FirstOrDefault();
            if (file != null)
            {
                var json = System.Text.Json.JsonDocument.Parse(File.ReadAllText(file.FullName));
                var nam = json.RootElement.GetProperty("runtimeOptions").GetProperty("tfm").GetString();
                return FrameworkKey.Resolve(nam);
            }

            return null;

        }

        #endregion Resolve current key

        private static Dictionary<string, FrameworkKey> _keys = new Dictionary<string, FrameworkKey>();

    }

}
