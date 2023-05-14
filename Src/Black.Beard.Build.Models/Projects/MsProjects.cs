namespace Bb.Projects
{


    public static class MsProjects
    {



        public static MsProject CreateProject
            (
            string targetDirectory, 
            string name,
            TargetFramework targetFramework,
            string @namespace = null
            )
        {

            var dir = new DirectoryInfo(targetDirectory);

            var project = new MsProject(name, dir)
                .Sdk(ProjectSdk.MicrosoftNETSdk)
                .SetPropertyGroup(c =>
                {

                    c.TargetFramework(targetFramework)
                     .RootNamespace(@namespace)
                     ;                 
                })
                ;

            return project;
        }

    }

}

// https://gitter.im/dotnet/roslyn?at=5de833f855066245986b8467
