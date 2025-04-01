using Bb.ComponentModel;
using Bb.Nugets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{


    public class TestDownloadUnitTest
    {

        [Fact]
        public async Task Test1()
        {

            var service = new NuGetDownloader(null)
                .FilterFiles(c => c.EndsWith(".dll"))
                .SetRepositoryFolder("c:\\tmp\\nuget")
                .FilterFramworks((a, b, c) =>
                {
                    return true;
                })
                ;

            var items = await service.GetPackageFilesAsync("Black.Beard.ComponentModel");


            List<AssemblyMatched> assemblies = new List<AssemblyMatched>();

            var addon = new AddonsResolver();

            foreach (var item in items)
            {
                assemblies = addon.SearchListReferences(item).ToList();
                var filteredAssemblies = assemblies.Where(c => !c.IsLoaded && !c.IsSdk).ToList();
                foreach (var assembly in filteredAssemblies)
                    assemblies.Add(assembly);
            }

            Assert.True(assemblies.Count == 2);

        }


    }

}