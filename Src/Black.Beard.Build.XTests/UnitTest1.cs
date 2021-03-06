using Bb.Build;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Bb.Beard.Build.XTests
{

    public class UnitTest1
    {

        private readonly DirectoryInfo _baseDirectory;

        public UnitTest1()
        {
            var file = typeof(UnitTest1).Assembly.Location;
            this._baseDirectory = new FileInfo(file).Directory;
        }

        [Fact]
        public void Test1()
        {

            var name = "Black.Beard.tests";
            var dir = new DirectoryInfo(Path.Combine(this._baseDirectory.FullName, name));

            var project = new MsProject(name, dir)
                .Sdk(ProjectSdk.MicrosoftNETSdk)
                .SetPropertyGroup(c =>
                {
                    c.TargetFramework(TargetFramework.Net6)
                    .RootNamespace("Bb")
                    .Description("My description")
                    .RepositoryUrl(new System.Uri("http://github.com"))
                    ;
                })
                .Packages(p =>
                {
                    p.PackageReference("Black.Beard.ComponentModel", new Version("1.0.36"))
                     .PackageReference("Black.Beard.Helpers.ContentLoaders", new Version("1.0.8"))
                    ;

                });

            var result = project.Build(inMemory: true, load: true);

            var assembly = project.Assembly;

        }


        [Fact]
        public void Test2()
        {

            var name = "Black.Beard.tests";
            var dir = new DirectoryInfo(Path.Combine(this._baseDirectory.FullName, name));

            var project = MsProjects.CreateCsProject(dir.FullName, name, 
                TargetFramework.Net6, 
                "Bb"                
                )
                .SetPropertyGroup(a =>
                {
                    a.Description("MyDescription");
                })
                .Packages(p =>
                {
                    p.PackageReference("Black.Beard.ComponentModel", new Version("1.0.36"))
                     .PackageReference("Black.Beard.Helpers.ContentLoaders", new Version("1.0.8"))
                    ;

                });

            var result = project.Build(inMemory: true, load: true);
            var assembly = project.Assembly;

        }


    }


}