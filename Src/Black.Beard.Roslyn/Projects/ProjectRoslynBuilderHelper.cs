using Bb;
using Bb.Builds;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.CodeAnalysis.CSharp;

namespace Black.Beard.Roslyn.BuildProjects
{



    public static class ProjectRoslynBuilderHelper
    {

        public static BuildCSharp CreateCsharpBuild(string path, bool debug = false)
        {

            var file = new FileInfo(path);
            file.Refresh();

            if (!file.Exists)
                throw new FileNotFoundException(path);

            BuildCSharp builder = new BuildCSharp()
            {
                //ResolveAssembliesInCode = true,
                Debug = debug,
            };

            LoadSources(file, builder);

            XmlDocument docProject = LoadXml(path);
            Visit(builder, docProject.DocumentElement, file.Directory);

            return builder;

        }



        private static void Visit(BuildCSharp builder, XmlElement e, DirectoryInfo dir)
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

        }

        private static void VisitItemGroup(BuildCSharp builder, XmlElement e, DirectoryInfo dir)
        {

            foreach (XmlNode item in e.ChildNodes)
                if (item is XmlElement e2)
                    switch (e2.Name.ToLower())
                    {

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
                                        c.IsStatic = value.ToLower().Trim() ==  "true";
                                });
                            }
                            else
                                builder.Using(us);                            
                            break;

                        case "PackageReference":

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

                                //builder.ConfigureCompilation(c =>
                                //{
                                //    // c.WithPlatform(Microsoft.CodeAnalysis.Platform.AnyCpu);
                                //});

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
                            break;

                        default:
                            Stop();
                            break;


                    }

        }

        private static void LoadSources(FileInfo fileProject, BuildCSharp builder)
        {
            fileProject.Directory.Refresh();
            var p = Path.Combine(fileProject.Directory.FullName, "obj");
            var files = fileProject.Directory.GetFiles("*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
                if (!item.FullName.StartsWith(p))
                    builder.AddSource(item);
        }

        private static XmlDocument LoadXml(string path)
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