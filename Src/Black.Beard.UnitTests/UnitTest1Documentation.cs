using Bb.Process;
using Black.Beard.Roslyn.Documentation;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace Black.Beard.UnitTests
{
    public class UnitTest1Documentation
    {


        public UnitTest1Documentation()
        {
            
            var ass = Assembly.GetExecutingAssembly();
            _location = new FileInfo(ass.Location).Directory.Parent.Parent.Parent.Parent.FullName;

        }


        [Fact]
        public void TestFailedToStart()
        {


            var sln = Solution.GetSolutions(new DirectoryInfo(_location)).ToList();

            foreach (var s in sln) 
            {

                var p = s.GetProjects().ToList();
            }



            //string pattern = ".cs";

            //var dir = new DirectoryInfo(_location);
            //var files = dir.GetFiles($"{pattern}proj", SearchOption.AllDirectories);
            //foreach (var file in files)
            //{



            //}


        }



        private readonly string _location;

    }


}