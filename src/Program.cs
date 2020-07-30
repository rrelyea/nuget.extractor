using NuGet.Common;
using NuGet.Configuration;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Versioning;
using System;
using System.Threading;

namespace nuget.extractor
{
    class Program
    {
        static void Main(string[] args)
        {

            //NOTE: this code is not best practice...just hacked it up so it would compile for right now.
            var id = "NuGet.Protocol";
            var version = new NuGetVersion("5.6.0");
            PackageIdentity package = new PackageIdentity(id, version);
            var logger = NullLogger.Instance;
            var packageDownloader = new NuGet.Protocol.LocalPackageArchiveDownloader("c:\\packages\\source",
                                        "c:\\packages\\other",
                                        package,
                                        NullLogger.Instance);
            var clientPolicyContext = ClientPolicyContext.GetClientPolicy(Settings.LoadDefaultSettings(null), logger);
            var pathResolver = new VersionFolderPathResolver("");
            var extractionContext = new PackageExtractionContext(PackageSaveMode.Defaultv3, XmlDocFileSaveMode.None, clientPolicyContext, logger);
            NuGet.Packaging.PackageExtractor.InstallFromSourceAsync(
                                                package,
                                                packageDownloader,
                                                pathResolver,
                                                extractionContext,
                                                CancellationToken.None);
        }
    }
}
