﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Xml;

namespace Bb.Builds
{


    internal static class ReferenceTypeExtension
    {

        public static Reference SelectOptimized(this IEnumerable<Reference> items, FrameworkVersion version)
        {

            var selections = items.OrderByDescending(c => c.Framework.Version).ToList();
            var selection = selections.First();

            foreach (var item in selections)
                if (item.Version > selection.Version)
                    selection = item;

            return selection;

        }

    }


    public static class ProjectRoslynBuilderHelper
    {

        /// <summary>
        /// Create a new instance of <see cref="BuildCSharp"/> from project file 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="debug"></param>
        /// <param name="configureCompilation"></param>
        /// <returns></returns>
        public static BuildCSharp CreateCsharpBuild(this string path, bool debug = false, Func<CSharpCompilationOptions, CSharpCompilationOptions> configureCompilation = null)
        {
            var file = new FileInfo(path);
            return CreateCsharpBuild(file, debug, configureCompilation);
        }

        internal static BuildCSharp CreateCsharpBuild(this FileInfo file, bool debug, List<Func<CSharpCompilationOptions, CSharpCompilationOptions>> configureCompilations, BuildList children)
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
        public static BuildCSharp CreateCsharpBuild(this FileInfo file, bool debug = false, Func<CSharpCompilationOptions, CSharpCompilationOptions> configureCompilation = null)
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
                    builder.Framework.Sdk = e.Attributes["Sdk"].Value;
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
                    //Stop();
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

                        case "concurrentgarbagecollection":
                            builder.RuntimeConfig.GCConcurrent = e2.InnerText?.ToLower() == "true";
                            break;

                        case "threadpoolminthreads":
                            if (int.TryParse(e2.InnerText?.ToLower()?.Trim() ?? string.Empty, out int r1))
                            builder.RuntimeConfig.MinThreads = r1;
                            break;

                        case "threadpoolmaxthreads":
                            if (int.TryParse(e2.InnerText?.ToLower()?.Trim() ?? string.Empty, out int r2))
                                builder.RuntimeConfig.MaxThreads = r2;
                            break;

                        case "compile":
                            //var toRemove = e2.Attributes["Remove"].Value.ToString();
                        case "content":
                        case "embeddedresource":
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
                            builder.Nugets.AddPackage(nugetName, version);
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
                            //Stop();
                            break;

                    }

        }

        private static void VisitPropertyGroup(BuildCSharp builder, XmlElement e, DirectoryInfo dir)
        {

            foreach (XmlNode item in e.ChildNodes)
                if (item is XmlElement e2)
                    switch (e2.Name.ToLower())
                    {

                        case "title": 
                            builder.AddAssemblyAttribute("System.Reflection.AssemblyTitleAttribute", "RepositoryUrl", e2.InnerText);
                            builder.AddReferences(typeof(AssemblyCompanyAttribute));
                            break;

                        case "repositoryurl":
                            builder.AddAssemblyAttribute(typeof(AssemblyMetadataAttribute), "RepositoryUrl", e2.InnerText);
                            break;
                        case "version":
                            builder.AddAssemblyAttribute(typeof(AssemblyVersionAttribute), e2.InnerText);
                            break;
                        case "description":
                            builder.AddAssemblyAttribute(typeof(AssemblyDescriptionAttribute), e2.InnerText);
                            break;
                        case "assemblytitle":
                            builder.AddAssemblyAttribute(typeof(AssemblyTitleAttribute), e2.InnerText);
                            break;
                        case "company":
                            builder.AddAssemblyAttribute(typeof(AssemblyCompanyAttribute), e2.InnerText);
                            break;

                        case "startupobject":
                            builder.MainTypeName = e2.InnerText;
                            builder.SetOutputKind(OutputKind.ConsoleApplication);
                            break;

                        case "targetframework":
                            var p = e2.InnerText;
                            if (!string.IsNullOrEmpty(p))
                            {
                                string[] targetframeworks = p.Split(';').Where(c => !string.IsNullOrEmpty(c)).ToArray();
                                builder.AddAvailableSdk(targetframeworks);
                            }
                            break;

                        case "implicitusings":
                            if (e2.InnerText?.ToLower() == "enable")
                                builder.EnableImplicitUsings();
                            break;

                        case "generatedocumentationfile":
                        case "usersecretsid":
                        case "dockerdefaulttargetos":
                        case "packagereadmefile":
                        case "nullable":
                        case "rootnamespace":
                        case "packageprojecturl":
                        case "generatepackageonbuild":
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