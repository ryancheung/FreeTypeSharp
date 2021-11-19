#addin nuget:?package=Cake.FileHelpers&version=4.0.1

var baseVersion = "2.0.0.";

var target = Argument("build-target", "Default");
var version = Argument("build-version", EnvironmentVariable("BUILD_NUMBER") ?? baseVersion + "1");
var configuration = Argument("build-configuration", "Release");

MSBuildSettings msBuildSettings;
DotNetCoreMSBuildSettings dnMSBuildSettings;
DotNetCoreBuildSettings dnBuildSettings;

private void BuildMSBuild(string filePath)
{
    MSBuild(filePath, msBuildSettings);
}

private void BuildDotnet(string filePath)
{
    DotNetCoreBuild(filePath, dnBuildSettings);
}

private void ParseVersion()
{
    if (!string.IsNullOrEmpty(EnvironmentVariable("GITHUB_ACTIONS")))
    {
        var gitRef = EnvironmentVariable("GITHUB_REF");

        if (gitRef.Contains("refs/tags/")) // There's a git release
        {
            version = gitRef.Replace("refs/tags/v", "").Trim();
        }
        else
        {
            version = baseVersion + EnvironmentVariable("GITHUB_RUN_NUMBER");

            var branch = EnvironmentVariable("GITHUB_REF");

            if (branch != " refs/heads/release")
                version = version + "-develop";
        }
    }
    else
    {
        var branch = EnvironmentVariable("BRANCH_NAME") ?? string.Empty;
        if (!branch.Contains("release"))
            version += "-develop";
    }

    Console.WriteLine("Version: " + version);
}

var NuGetSpecFile = "nuget/FreeTypeSharp.nuspec";

var PackageNuGet = new Action<FilePath, DirectoryPath> ((nuspecPath, outputPath) =>
{
    EnsureDirectoryExists (outputPath);

    NuGetPack (nuspecPath, new NuGetPackSettings {
        OutputDirectory = outputPath,
        BasePath = nuspecPath.GetDirectory (),
        Version = version
    });
});

Task("Prep")
    .Does(() =>
{
    ParseVersion();

    msBuildSettings = new MSBuildSettings();
    msBuildSettings.Verbosity = Verbosity.Minimal;
    msBuildSettings.Configuration = configuration;
    msBuildSettings.Restore = true;
    msBuildSettings.WithProperty("Version", version);

    dnMSBuildSettings = new DotNetCoreMSBuildSettings();
    dnMSBuildSettings.WithProperty("Version", version);

    dnBuildSettings = new DotNetCoreBuildSettings();
    dnBuildSettings.Verbosity = DotNetCoreVerbosity.Minimal;
    dnBuildSettings.Configuration = configuration;
    dnBuildSettings.MSBuildSettings = dnMSBuildSettings;
});

Task("Build")
    .IsDependentOn("Prep")
    .Does(() =>
{
    BuildDotnet("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("Pack")
    .IsDependentOn("Build")
    .WithCriteria(() =>
{
    return IsRunningOnMacOs();
}).Does(() =>
{
    PackageNuGet(NuGetSpecFile, "Artifacts");
});

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
