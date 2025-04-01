using NuGet.Common;
using NuGet.Configuration;
using NuGet.Protocol.Core.Types;
using NuGet.Frameworks;
using NuGet.Packaging;


/*
    <PackageReference Include="NuGet.Protocol" Version="x.y.z" />
    <PackageReference Include="NuGet.Configuration" Version="x.y.z" />
    <PackageReference Include="NuGet.Packaging" Version="x.y.z" />
*/

namespace Bb.Nugets
{

    public class NuGetDownloader
    {

        public NuGetDownloader(ILogger logger)
        {
            // Configure the logger
            _logger = logger ?? NullLogger.Instance;
            _packageSource = new PackageSource("https://api.nuget.org/v3/index.json");

            // Set up the settings
            _settings = Settings.LoadDefaultSettings(root: null);
            var packageSourceProvider = new PackageSourceProvider(_settings);
            _sourceRepositoryProvider = new SourceRepositoryProvider(packageSourceProvider, Repository.Provider.GetCoreV3());

        }


        public NuGetDownloader SetRepositoryFolder(string outputPath)
        {
            return SetRepositoryFolder(new DirectoryInfo(outputPath));
        }

        public NuGetDownloader SetRepositoryFolder(DirectoryInfo outputPath)
        {

            if (outputPath == null)
                throw new ArgumentNullException(nameof(outputPath));

            if (!outputPath.Exists)
                outputPath.Create();

            this._outputPath = outputPath;

            return this;

        }


        public NuGetDownloader SetPackageSource(string url)
        {
            _packageSource = new PackageSource(url);
            return this;
        }

        public NuGetDownloader FilterFiles(Func<string, bool> filter)
        {
            _filterFile = filter;
            return this;
        }

        public NuGetDownloader FilterFramworks(Func<string, Version?, NuGetFramework[], bool> filter)
        {
            _filterFramework = filter;
            return this;

        }

        public async Task DownloadPackageAsync(string packageId, Version? version = null)
        {
            string target = Path.Combine(_outputPath.FullName, $"{packageId}.{version}.nupkg");

            // Get the source repository
            var sourceRepository = _sourceRepositoryProvider.CreateRepository(_packageSource);

            // Get the package metadata resource
            var metadataResource = await sourceRepository.GetResourceAsync<PackageMetadataResource>();

            IPackageSearchMetadata package;
            // Get the package metadata
            var packageMetadata = await metadataResource.GetMetadataAsync(packageId, includePrerelease: false, includeUnlisted: false, sourceCacheContext: new SourceCacheContext(), log: _logger, token: default);
            if (packageMetadata == null || !packageMetadata.Any())
                throw new Exception($"Package {packageId} not found.");

            if (version != null)
            {
                // Find the latest version
                package = packageMetadata.OrderByDescending(p => p.Identity.Version).FirstOrDefault();
                if (package == null)
                    throw new Exception($"Package {packageId} not found.");
            }
            else
            {
                var v = version.ToString();
                package = packageMetadata.FirstOrDefault(p => p.Identity.Version.ToString() == v);
                if (package == null)
                    throw new Exception($"Package {packageId} version {version} not found.");
            }

            // Find the specific version

            if (!File.Exists(target))
            {
                // Get the package download resource
                var downloadResource = await sourceRepository.GetResourceAsync<DownloadResource>();

                // Download the package
                var downloadResult = await downloadResource.GetDownloadResourceResultAsync
                    (
                        package.Identity,
                        new PackageDownloadContext(new SourceCacheContext()),
                        SettingsUtility.GetGlobalPackagesFolder(_settings),
                        _logger,
                        default
                    );

                // Save the package to the specified output path
                using (var fileStream = new FileStream(target, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await downloadResult.PackageStream.CopyToAsync(fileStream);
                }
            }

            // Download dependencies
            var dependencyInfoResource = await sourceRepository.GetResourceAsync<DependencyInfoResource>();
            var dependencyInfo = await dependencyInfoResource.ResolvePackage(package.Identity, NuGetFramework.AnyFramework, new SourceCacheContext(), _logger, default);

            foreach (var dependency in dependencyInfo.Dependencies)
            {
                await DownloadPackageAsync(dependency.Id, new Version(dependency.VersionRange.MinVersion.ToString()));
            }
        }

        public async Task<string[]> GetPackageFilesAsync(string packageId, Version? version = null)
        {
            string target = Path.Combine(_outputPath.FullName, $"{packageId}.{version}.nupkg");

            if (!File.Exists(target))
                await DownloadPackageAsync(packageId, version);

            string extractPath = Path.Combine(_outputPath.FullName, $"{packageId}.{version}");
            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
                ExtractPackage(target, packageId, version, extractPath);
            }

            return Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories);
        }

        private void ExtractPackage(string packagePath, string packageId, Version? version, string extractPath)
        {

            using (var packageReader = new PackageArchiveReader(packagePath))
                if (FilterFramework(packageId, version, packageReader))
                    foreach (var file in packageReader.GetFiles())
                        if (FilterFile(file))
                        {
                            var filePath = Path.Combine(extractPath, file);
                            var directory = Path.GetDirectoryName(filePath);

                            if (!Directory.Exists(directory))
                                Directory.CreateDirectory(directory);

                            using (var fileStream = File.Create(filePath))
                            using (var packageStream = packageReader.GetStream(file))
                                packageStream.CopyTo(fileStream);

                        }

        }

        private bool FilterFramework(string packageId, Version? version, PackageArchiveReader packageReader)
        {

            if (_filterFramework != null)
            {
                var p = _filterFramework(packageId, version, packageReader.GetSupportedFrameworks().ToArray());
                return p;
            }

            return true;

        }

        private bool FilterFile(string file)
        {

            if (_filterFile == null || _filterFile(file))
                return true;

            return false;

        }

        public async Task<NuGetFramework[]> GetPackageFrameworksAsync(string packageId, Version version)
        {

            string target = Path.Combine(_outputPath.FullName, $"{packageId}.{version}.nupkg");

            if (!File.Exists(target))
            {
                await DownloadPackageAsync(packageId, version);
            }

            using (var packageReader = new PackageArchiveReader(target))
            {
                var frameworks = packageReader.GetSupportedFrameworks().ToArray();
                return frameworks;
            }

        }

        private readonly ILogger _logger;
        private readonly SourceRepositoryProvider _sourceRepositoryProvider;
        private PackageSource _packageSource;
        private ISettings _settings;
        private DirectoryInfo _outputPath;
        private Func<string, bool> _filterFile;
        private Func<string, Version?, NuGetFramework[], bool> _filterFramework;
    }


}
