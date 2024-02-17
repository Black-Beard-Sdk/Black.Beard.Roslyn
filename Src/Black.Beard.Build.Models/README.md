# Black.Beard.Projects.Models

[![Build status](https://ci.appveyor.com/api/projects/status/2r6ucvo29ywpvdc8?svg=true)](https://ci.appveyor.com/project/gaelgael5/black-beard-roslyn)

Helpers for create a project Csharp
It work if dotnet is not installed.


Sample to use Black.Beard.Projects.Models for create a csproj
```CSHARP

    //Usings
    using Bb.Build;
    using System;
    using System.IO;

    // create a folder for store the generated project file
    var name = "Black.Beard.tests";
    var dir = new DirectoryInfo(Path.Combine(this._baseDirectory.FullName, name));

    var project = MsProjects
                    .CreateProject((name, dir)        
                    .Sdk(ProjectSdk.MicrosoftNETSdk)    // Specify the target build

                    .SetPropertyGroup(c =>              // set the properties of the build
                    {
                        c.TargetFramework(TargetFramework.Net6)
                         .RootNamespace("Bb")
                         .Description("My description")
                         .RepositoryUrl(new System.Uri("http://github.com"))
                        ;
                    })

                    .Packages(p =>                      // Reference packages
                    {
                        p.PackageReference("Black.Beard.ComponentModel", new Version("1.0.36"))
                         .PackageReference("Black.Beard.Helpers.ContentLoaders", new Version("1.0.8"))
                        ;

                    });

    // Save project
    var result = project.Save();


```
