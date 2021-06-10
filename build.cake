#tool nuget:?package=vswhere&version=2.8.4

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("build-target", "Default");
var version = Argument("build-version", EnvironmentVariable("BUILD_NUMBER") ?? "2.0.0.1");
var configuration = Argument("build-configuration", "Release");
var apiKey = Argument("api-key", "");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

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

private bool GetMSBuildWith(string requires)
{
    if (IsRunningOnWindows())
    {
        DirectoryPath vsLatest = VSWhereLatest(new VSWhereLatestSettings { Requires = requires, IncludePrerelease = true });

        if (vsLatest != null)
        {
            var files = GetFiles(vsLatest.FullPath + "/**/MSBuild.exe");
            if (files.Any())
            {
                msBuildSettings.ToolPath = files.First();
                return true;
            }
        }
    }

    return false;
}

var NuGetToolPath = Context.Tools.Resolve ("nuget.exe");
var NuGetSpecFile = "nuget/FreeTypeSharp.nuspec";

var PackageNuGet = new Action<FilePath, DirectoryPath> ((nuspecPath, outputPath) =>
{
    EnsureDirectoryExists (outputPath);

    NuGetPack (nuspecPath, new NuGetPackSettings {
        OutputDirectory = outputPath,
        BasePath = nuspecPath.GetDirectory (),
        ToolPath = NuGetToolPath,
        Version = version
    });
});

var RunProcess = new Action<FilePath, string> ((process, args) =>
{
    var result = StartProcess (process, args);
    if (result != 0) {
        throw new Exception ($"Process '{process}' failed with error: {result}");
    }
});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Prep")
    .Does(() =>
{
    Console.WriteLine("Build Version: {0}", version);

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

Task("BuildNET6.0")
    .IsDependentOn("Prep")
    .Does(() =>
{
    dnBuildSettings.Framework = "net6.0";
    BuildDotnet("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildAndroid")
    .IsDependentOn("Prep")
    .Does(() =>
{
    dnBuildSettings.Framework = "net6.0-android";
    BuildDotnet("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildiOS")
    .IsDependentOn("Prep")
    .WithCriteria(() => Context.Environment.Platform.IsOSX(), "Not on macOS.")
    .Does(() =>
{
    dnBuildSettings.Framework = "net6.0-ios";
    BuildDotnet("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildUWP")
    .IsDependentOn("Prep")
    .WithCriteria(() => Context.Environment.Platform.IsWindows(), "Not on Windows.")
    .Does(() =>
{
    dnBuildSettings.Framework = "net5.0-windows10.0.19041.0";
    BuildDotnet("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildAll")
    .IsDependentOn("Prep")
    .WithCriteria(() =>
{
    if (!IsRunningOnWindows())
        return false;

    return GetMSBuildWith("Microsoft.VisualStudio.Component.Windows10SDK.17763");
}).Does(() =>
{
    BuildMSBuild("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("Default")
    .IsDependentOn("BuildAll");

Task("Pack")
    .IsDependentOn("BuildAll")
.Does(() =>
{
    PackageNuGet(NuGetSpecFile, "Artifacts");
});

Task("Publish")
    .IsDependentOn("Pack")
.Does(() =>
{
    var args = $"push -Source \"https://api.nuget.org/v3/index.json\" -ApiKey {apiKey} Artifacts/FreeTypeSharp.{version}.nupkg";

    RunProcess(NuGetToolPath, args);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
