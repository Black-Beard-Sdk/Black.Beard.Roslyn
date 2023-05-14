using Bb.Projects;
using System;
using System.IO;

namespace Bb.Build
{


    public static class MsProjectsForBuild
    {

        public static MsProjectForBuild CreateProject
            (
            string targetDirectory, 
            string name,
            TargetFramework targetFramework,
            string @namespace = null
            )
        {

            var dir = new DirectoryInfo(targetDirectory);

            var project = new MsProjectForBuild(name, dir)
                .Sdk(ProjectSdk.MicrosoftNETSdk)
                .SetPropertyGroup(c =>
                {

                    c.TargetFramework(targetFramework)
                     .RootNamespace(@namespace)
                     ;                 
                })
                ;

            return (MsProjectForBuild)project;

        }

    }

}

// https://gitter.im/dotnet/roslyn?at=5de833f855066245986b8467
