using System.Diagnostics;
using System.Reflection;

namespace Bb.Analysis
{


    [DebuggerDisplay("{Name}")]
    public class FrameworkType
    {


        static FrameworkType()
        {
            FrameworkType._currentName = GetCurrentKey();
        }

        private FrameworkType(string name, string Key, string windowDirectory, FrameworkType? baseType)
        {
            this.Name = name;
            this.ProjectKey = Key;
            this.WindowDirectory = windowDirectory;
            this.BaseType = baseType;
        }


        public string Name { get; }


        public string ProjectKey { get; }


        public string WindowDirectory { get; }

        public FrameworkType? BaseType { get; }

        public static implicit operator FrameworkType(string name)
        {
            return FrameworkType.ResolveSdkName(name);
        }

        /// <summary>
        /// Resolve type from sdk name
        /// </summary>
        /// <param name="sdk"></param>
        /// <returns></returns>
        public static FrameworkType ResolveSdkName(string sdk)
        {

            switch (sdk)
            {

                case ".NETCoreApp":
                case ".NETCore.App":
                case "Microsoft.NETCore.App":
                case "Microsoft.NET.Sdk":
                    return FrameworkType.NETCore;

                case ".WindowsDesktopApp":
                case ".WindowsDesktop.App":
                case "Microsoft.WindowsDesktop.App":
                case "Microsoft.NET.Sdk.WindowsDesktop":
                    return FrameworkType.WindowsDesktop;

                case ".AspNetCoreApp":
                case ".AspNetCore.App":
                case "Microsoft.AspNetCore.App":
                case "Microsoft.NET.Sdk.Web":
                    return FrameworkType.AspNetCore;

                default:
                    return Unknown;

            }
                   
        }

        public static IEnumerable<FrameworkType> All()
        {
            yield return NETCore;
            yield return AspNetCore;
            yield return WindowsDesktop;
        }

        public static FrameworkType Current => _current ?? (_current = FrameworkType.ResolveSdkName(_currentName));

        public static FrameworkType NETCore = new FrameworkType(".NETCore.App", "Microsoft.NET.Sdk", "Microsoft.NETCore.App", null);
        public static FrameworkType AspNetCore = new FrameworkType(".AspNetCore.App", "Microsoft.NET.Sdk.Web", "Microsoft.AspNetCore.App", NETCore);
        public static FrameworkType WindowsDesktop = new FrameworkType(".WindowsDesktop.App", "Microsoft.NET.Sdk.WindowsDesktop", "Microsoft.WindowsDesktop.App", NETCore);

        public static FrameworkType Unknown = new FrameworkType("Unknown type", "Unknown type", "Unknown type", null);


        private static string _currentName;
        private static FrameworkType _current;




        #region Resolve current key

        private static string GetCurrentKey()
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

            HashSet<string> keys = new HashSet<string>();
            foreach (var item in _h)
            {
                var v1 = GetVersion(item);
                if (v1 != null)
                    keys.Add(v1);
            }

            return keys.FirstOrDefault();

        }

        private static string GetVersion(Assembly assembly)
        {

            var fileAssembly = new FileInfo(assembly.Location);
            var dir = fileAssembly.Directory;

            return GetVersion(dir, Path.GetFileNameWithoutExtension(fileAssembly.Name));                   

        }

        public static string GetVersion(DirectoryInfo dir, string pattern)
        {

            var ee = FrameworkHelper.TryGetDeps(dir, pattern);
            if (ee != null)
            {
                var tt = ee.Value.GetString();
                tt = tt.Split(',')[0];
                return tt;
            }

            ee = FrameworkHelper.TryGetRuntimeConfig(dir, pattern);
            if (ee != null)
            {
                var tt = ee.Value.GetProperty("name").GetString();
                return tt;
            }

            return null;

        }

        #endregion Resolve current key
    }

}
