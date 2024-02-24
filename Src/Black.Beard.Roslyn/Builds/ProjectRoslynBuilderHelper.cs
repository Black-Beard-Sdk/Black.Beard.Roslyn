using Microsoft.CodeAnalysis.CSharp;
using System.Xml;

namespace Bb.Builds
{



    public static class ProjectRoslynBuilderHelper
    {

        /// <summary>
        /// Create a new instance of <see cref="BuildCSharp"/> from project file 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="debug"></param>
        /// <param name="configureCompilation"></param>
        /// <returns></returns>
        public static BuildCSharp CreateCsharpBuild(this string path, bool debug = false, Action<CSharpCompilationOptions> configureCompilation = null)
        {
            var file = new FileInfo(path);
            return CreateCsharpBuild(file, debug, configureCompilation);
        }

        internal static BuildCSharp CreateCsharpBuild(this FileInfo file, bool debug, List< Action<CSharpCompilationOptions>> configureCompilations, BuildList children)
        {

            file.Refresh();
            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            BuildCSharp builder = new BuildCSharp()
            {
                Debug = debug,
                AssemblyName = Path.GetFileNameWithoutExtension(file.Name),
                _children = children,
                ConfigureCompilations = configureCompilations,
            };

            return builder;
        }


        /// <summary>
        /// Create a new instance of <see cref="BuildCSharp"/> from project file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="debug"></param>
        /// <param name="configureCompilation"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static BuildCSharp CreateCsharpBuild(this FileInfo file, bool debug = false, Action<CSharpCompilationOptions> configureCompilation = null)
        {

            file.Refresh();
            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            var docProject = LoadXml(file.FullName);

            BuildCSharp builder = new BuildCSharp(configureCompilation)
            {
                Debug = debug,
                AssemblyName = Path.GetFileNameWithoutExtension(file.Name),
            }
            .LoadSources(file)
            .Visit(docProject.DocumentElement, file.Directory);

            return builder;

        }

        internal static BuildCSharp Visit(this BuildCSharp builder, XmlElement e, DirectoryInfo dir)
        {

            switch (e.Name.ToLower())
            {

                case "project":


                    builder.Framework.Sdk = FrameworkVersion.ResolveSdkName(e.Attributes["Sdk"].Value);

                    foreach (XmlNode item in e.ChildNodes)
                        if (item is XmlElement e2)
                            Visit(builder, e2, dir);
                    break;

                case "propertygroup":
                    VisitPropertyGroup(builder, e, dir);
                    break;

                case "itemgroup":
                    VisitItemGroup(builder, e, dir);
                    break;

                default:
                    Stop();
                    break;

            }

            return builder;

        }

        private static void VisitItemGroup(BuildCSharp builder, XmlElement e, DirectoryInfo dir)
        {

            foreach (XmlNode item in e.ChildNodes)
                if (item is XmlElement e2)
                    switch (e2.Name.ToLower())
                    {

                        case "folder":
                        case "none":
                            break;

                        case "using":
                            var us = e2.Attributes["Include"].Value.ToString();
                            var subNode = e2.ChildNodes;
                            if (subNode.Count > 0 && subNode[0] is XmlElement e3)
                            {
                                builder.Using(us, c =>
                                {
                                    var name = e3.Name.ToLower();
                                    var value = e3.InnerText;
                                    if (name == "alias")
                                        c.Alias = value;
                                    else if (name == "static")
                                        c.IsStatic = value.ToLower().Trim() == "true";
                                });
                            }
                            else
                                builder.Using(us);
                            break;

                        case "packagereference":
                            var nugetName = e2.Attributes["Include"].Value.ToString();
                            var version = e2.Attributes["Version"].Value.ToString();
                            builder.Nugets.AddReference(nugetName, version);
                            break;

                        case "projectreference":
                            var projectPath = e2.Attributes["Include"].Value.ToString();
                            var path = new FileInfo(Path.Combine(dir.FullName, projectPath));
                            if (path.Exists)
                                builder.AppendProject(path);
                            else
                            {

                            }

                            break;

                        default:
                            Stop();
                            break;

                    }

        }

        private static void VisitPropertyGroup(BuildCSharp builder, XmlElement e, DirectoryInfo dir)
        {

            foreach (XmlNode item in e.ChildNodes)
                if (item is XmlElement e2)
                    switch (e2.Name.ToLower())
                    {

                        case "targetframework":

                            var p = e2.InnerText;
                            if (!string.IsNullOrEmpty(p))
                            {
                                string[] targetframeworks = p.Split(';').Where(c => !string.IsNullOrEmpty(c)).ToArray();
                                builder.AddAvailableVersion(targetframeworks);
                            }
                            break;

                        case "implicitusings":
                            if (e2.InnerText?.ToLower() == "enable")
                                builder.EnableImplicitUsings();
                            break;

                        case "packagereadmefile":
                        case "nullable":
                        case "rootnamespace":
                        case "description":
                        case "packageprojecturl":
                        case "generatepackageonbuild":
                        case "repositoryurl":
                        case "preservecompilationcontext":
                        case "ispackable":
                            break;

                        default:
                            Stop();
                            break;


                    }

        }

        internal static BuildCSharp LoadSources(this BuildCSharp builder, FileInfo fileProject)
        {
            fileProject.Directory.Refresh();
            var p = Path.Combine(fileProject.Directory.FullName, "obj");
            var files = fileProject.Directory.GetFiles("*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
                if (!item.FullName.StartsWith(p))
                    builder.AddSource(item);

            return builder;

        }

        internal static XmlDocument LoadXml(string path)
        {
            var txt = path.LoadFromFile();
            var doc = new XmlDocument();
            doc.LoadXml(txt);
            return doc;
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }


    }

}