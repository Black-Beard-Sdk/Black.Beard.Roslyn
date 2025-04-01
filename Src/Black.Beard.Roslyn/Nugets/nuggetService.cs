using System;
using System.IO;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Frameworks;


/*
 //<PackageReference Include="NuGet.Protocol" Version="x.y.z" />
 //<PackageReference Include="NuGet.Configuration" Version="x.y.z" />
*/

namespace Bb.Nugets
{

    public class NuGetDownloader
    {
        public async Task DownloadPackageAsync(string packageId, string version, string outputPath)
        {

            // Configure the logger
            ILogger logger = NullLogger.Instance;

            // Set up the settings
            var settings = Settings.LoadDefaultSettings(root: null);
            var packageSourceProvider = new PackageSourceProvider(settings);
            var sourceRepositoryProvider = new SourceRepositoryProvider(packageSourceProvider, Repository.Provider.GetCoreV3());

            // Get the source repository
            var sourceRepository = sourceRepositoryProvider.CreateRepository(new PackageSource("https://api.nuget.org/v3/index.json"));

            // Get the package metadata resource
            var metadataResource = await sourceRepository.GetResourceAsync<PackageMetadataResource>();

            // Get the package metadata
            var packageMetadata = await metadataResource.GetMetadataAsync(packageId, includePrerelease: false, includeUnlisted: false, sourceCacheContext: new SourceCacheContext(), log: logger, token: default);

            // Find the specific version
            var package = packageMetadata.FirstOrDefault(p => p.Identity.Version.ToString() == version);
            if (package == null)
                throw new Exception($"Package {packageId} version {version} not found.");

            // Get the package download resource
            var downloadResource = await sourceRepository.GetResourceAsync<DownloadResource>();

            // Download the package
            var downloadResult = await downloadResource.GetDownloadResourceResultAsync(package.Identity, new PackageDownloadContext(new SourceCacheContext()), SettingsUtility.GetGlobalPackagesFolder(settings), logger, default);

            // Save the package to the specified output path
            using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await downloadResult.PackageStream.CopyToAsync(fileStream);
            }

            // Download dependencies
            var dependencyInfoResource = await sourceRepository.GetResourceAsync<DependencyInfoResource>();
            var dependencyInfo = await dependencyInfoResource.ResolvePackage(package.Identity, NuGetFramework.AnyFramework, new SourceCacheContext(), logger, default);

            foreach (var dependency in dependencyInfo.Dependencies)
            {
                await DownloadPackageAsync(dependency.Id, dependency.VersionRange.MinVersion.ToString(), Path.Combine(outputPath, $"{dependency.Id}.{dependency.VersionRange.MinVersion}.nupkg"));
            }
        }
    }


}
