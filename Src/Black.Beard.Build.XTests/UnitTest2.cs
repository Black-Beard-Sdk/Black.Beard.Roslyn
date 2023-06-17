using Bb.Build;
using Bb.Projects;
using System.IO;
using Xunit;

namespace Bb.Beard.Build.XTests
{

    public class UnitTest2
    {

        private readonly DirectoryInfo _baseDirectory;

        public UnitTest2()
        {
            var file = typeof(UnitTest1).Assembly.Location;
            this._baseDirectory = new FileInfo(file).Directory;
        }

        [Fact]
        public void Test1()
        {

            var name = "Black.Beard.tests";
            var dir = new DirectoryInfo(Path.Combine(this._baseDirectory.FullName, name));

            var project = new MsProjectForBuild(name, dir)
            .Sdk(ProjectSdk.MSBuildSdkSqlProj110)
            .SetPropertyGroup(c =>
            {
                c.TargetFramework(TargetFramework.Netstandard20)
                .SqlServerVersion(SqlServerVersion.Sql150);
            })
            .SqlCmdVariables(c =>
            {
                c.SqlCmdVariable("var1");
            })
            .SqlDeploy(c =>
            {
                //c.PreDeploy("");
                //c.PostDeploy("");
            })
            ;

            var result = project.Build(inMemory: false, load: false);

            var assembly = project.Assembly;

        }

    }

}