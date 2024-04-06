using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;


namespace Bb.Analysis
{


    [DebuggerDisplay("{Name} {Version}")]
    public class FrameworkKey
    {

        #region initializing

        internal FrameworkKey()
        {

        }

        // https://learn.microsoft.com/fr-fr/dotnet/standard/net-standard?tabs=net-standard-1-0
        static FrameworkKey()
        {

            // ".NETFramework3.5"

            Unknown = new FrameworkKey("unknown key", "unknown key", new Version(0, 0, 0), 0);

            Add(Netstandard10 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 0), 800));
            Add(Netstandard11 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 1), 800));
            Add(Netstandard12 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 2), 800));
            Add(Netstandard13 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 3), 800));
            Add(Netstandard14 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 4), 800));
            Add(Netstandard15 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 5), 800));
            Add(Netstandard16 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(1, 6), 800));
            Add(Netstandard20 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(2, 0), 800));
            Add(Netstandard21 = new FrameworkKey(NetStandard, PackageNetStandard, new Version(2, 1), 800));


            Add(Netcoreapp10 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(1, 0), 800));
            Add(Netcoreapp11 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(1, 1), 800));
            Add(Netcoreapp20 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(2, 0), 800));
            Add(Netcoreapp21 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(2, 1), 800));
            Add(Netcoreapp22 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(2, 2), 800));
            Add(Netcoreapp30 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(3, 0), 800));
            Add(Netcoreapp31 = new FrameworkKey(NetCoreApp, PackageNetCoreApp, new Version(3, 1), 800));


            Add(Net35 = new FrameworkKey(Net,               PackageNETFramework, new Version(3, 5), 800));
            Add(Net40 = new FrameworkKey(Net,               PackageNETFramework, new Version(4, 0), 800));
            Add(Net45 = new FrameworkKey(Net,               PackageNETFramework, new Version(4, 5), 800));
            Add(Net451 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 5, 1), 800));
            Add(Net452 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 5, 2), 800));
            Add(Net46 = new FrameworkKey(Net,               PackageNETFramework, new Version(4, 6), 800));
            Add(Net461 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 6, 1), 800));
            Add(Net462 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 6, 2), 800));
            Add(Net463 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 6, 3), 800));
            Add(Net47 = new FrameworkKey(Net,               PackageNETFramework, new Version(4, 7), 800));
            Add(Net471 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 7, 1), 800));
            Add(Net472 = new FrameworkKey(Net,              PackageNETFramework, new Version(4, 7, 2), 800));

            Add(Net48 = new FrameworkKey(Net,               PackageNet, new Version(4, 8), 800));
            Add(Net50 = new FrameworkKey(Net,               PackageNet, new Version(5, 0), 900));
            Add(Net60 = new FrameworkKey(Net,               PackageNet, new Version(6, 0), 1000));
            Add(Net70 = new FrameworkKey(Net,               PackageNet, new Version(7, 0), 1100));
            Add(Net80 = new FrameworkKey(Net,               PackageNet, new Version(8, 0), 1200));
            Add(Net90 = new FrameworkKey(Net,               PackageNet, new Version(9, 0), 1300));


            MatchCompatbility(NetStandard, new Version(1, 0), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 1), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 2), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 3), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 4), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 5), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 6), NetCoreApp, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(2, 0), NetCoreApp, new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(2, 1), NetCoreApp, new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));

            MatchCompatbility(NetStandard, new Version(1, 0), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 1), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 2), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 3), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 4), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 5), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(1, 6), Net, new Version(1, 0), new Version(1, 1), new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(2, 0), Net, new Version(2, 0), new Version(2, 1), new Version(2, 2), new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));
            MatchCompatbility(NetStandard, new Version(2, 1), Net, new Version(3, 0), new Version(3, 1), new Version(5, 0), new Version(6, 0), new Version(7, 0), new Version(8, 0));

            FrameworkKey.Current = GetCurrentKey();

        }

        /// <summary>
        /// ctor with name and version
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="languageVersion"></param>
        public FrameworkKey(string category, string packageCategory, Version version, int languageVersion)
        {

            this.Category = category;
            this.Name = category + version.ToString();
           
            this.PackageCategory = packageCategory;
            this.PackageName = packageCategory + version.ToString();

            if (Category == NetStandard)
                this.Alias = new string[] { category + version.ToString().Replace(".", "") };
            else
                this.Alias = new string[] { category + version.ToString().Replace(".", ""), "v" + version.ToString() };

            this.Version = version;
            this.languageVersion = languageVersion;

        }

        private static void MatchCompatbility(string category1, Version version1, string category2, params Version[] versions)
        {

            var item1 = FrameworkKey._keys.Values.FirstOrDefault(c => c.Category == category1 && c.Version == version1);
            var list2 = FrameworkKey._keys.Values.Where(c => c.Category == category2).Distinct().ToList();

            foreach (var item in versions)
            {
                var selection = list2.Where(c => c.Version == item).FirstOrDefault();
                if (selection != null)
                    selection._compatbilities.Add(item1);
            }

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

        /// <summary>
        /// Add a new framework key
        /// </summary>
        /// <param name="frameworkKey"></param>
        public static FrameworkKey Add(FrameworkKey frameworkKey)
        {
            Add(frameworkKey.Name, frameworkKey);
            if (frameworkKey.Alias != null)
                foreach (var item in frameworkKey.Alias)
                    Add(item, frameworkKey);

            Add(frameworkKey.PackageName, frameworkKey);

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

        #endregion initializing


        #region Properties

        public string Name { get; internal set; }

        public string PackageName { get; }

        public Version Version { get; internal set; }

        public string Category { get; }

        public string PackageCategory { get; }

        public string[] Alias { get; }

        public FrameworkKey[] CompatibilityDotNetStandard => _compatbilities.ToArray();

        public int languageVersion { get; internal set; }

        #endregion Properties


        #region Conversions

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

        #endregion Conversions


        #region Static instances

        public static FrameworkKey Netstandard10 { get; }

        public static FrameworkKey Netstandard11 { get; }

        public static FrameworkKey Netstandard12 { get; }

        public static FrameworkKey Netstandard13 { get; }

        public static FrameworkKey Netstandard14 { get; }

        public static FrameworkKey Netstandard15 { get; }

        public static FrameworkKey Netstandard16 { get; }

        public static FrameworkKey Netstandard20 { get; }

        public static FrameworkKey Netstandard21 { get; }

        public static FrameworkKey Netcoreapp10 { get; }

        public static FrameworkKey Netcoreapp11 { get; }

        public static FrameworkKey Netcoreapp20 { get; }

        public static FrameworkKey Netcoreapp21 { get; }

        public static FrameworkKey Netcoreapp22 { get; }

        public static FrameworkKey Netcoreapp30 { get; }

        public static FrameworkKey Netcoreapp31 { get; }

        public static FrameworkKey Net35 { get; }

        public static FrameworkKey Net40 { get; }

        public static FrameworkKey Net45 { get; }

        public static FrameworkKey Net451 { get; }

        public static FrameworkKey Net452 { get; }

        public static FrameworkKey Net46 { get; }

        public static FrameworkKey Net461 { get; }

        public static FrameworkKey Net462 { get; }

        public static FrameworkKey Net463 { get; }

        public static FrameworkKey Net47 { get; }
        public static FrameworkKey Net471 { get; }

        public static FrameworkKey Net472 { get; }

        public static FrameworkKey Net48 { get; }

        public static FrameworkKey Net50 { get; }

        public static FrameworkKey Net60 { get; }

        public static FrameworkKey Net70 { get; }

        public static FrameworkKey Net80 { get; }

        public static FrameworkKey Net90 { get; }

        public static FrameworkKey Unknown { get; }

        public static FrameworkKey Current { get; }

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

        private static Dictionary<string, FrameworkKey> _keys = new Dictionary<string, FrameworkKey>();

        #endregion  Static instances


        #region Resolve current key

        private static FrameworkKey? GetCurrentKey()
        {

            HashSet<Assembly> _h = new HashSet<Assembly>();
            var stack = new StackTrace();
            for (int i = stack.FrameCount - 1; i >= 0; i--)
            {
                var f = stack.GetFrame(i);
                var m = f.GetMethod();
                var a = m.DeclaringType?.Assembly;
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

        public bool Accept(string framework)
        {

            if (framework == PackageName)
                return true;

            foreach (var item in _compatbilities)
                if (item.Accept(framework))
                    return true;

            return false;

        }

        public bool Accept(FrameworkKey framework)
        {

            if (framework == null)
                return false;

            if (framework == Unknown)
                return false;

            if (framework.Version == this.Version)
                if (framework.Category == this.Category)
                    return true;

            foreach (var item in this._compatbilities)
                if (item.Accept(framework))
                    return true;

            return false;

        }



        #endregion Resolve current key


        /// <summary>
        /// Gets a hash code for this string.  If strings A and B are such that A.Equals(B), then they will return the same hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool Match(FrameworkKey sdk)
        {
            return sdk != null && sdk == this;
        }

        public const string PackageNetStandard = ".NETStandard";
        public const string PackageNetCoreApp = ".NETCoreApp";
        public const string PackageNETFramework = ".NETFramework";
        public const string PackageNet = "net";
        public const string NetStandard = "netstandard";
        public const string NetCoreApp = "netcoreapp";
        public const string Net = "net";

        internal List<FrameworkKey> _compatbilities = new List<FrameworkKey>();

    }

}
