#tool nuget:?package=vswhere&version=2.6.7

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("build-target", "Default");
var version = Argument("build-version", EnvironmentVariable("BUILD_NUMBER") ?? "0.0.0.0");
var configuration = Argument("build-configuration", "Release");
var apiKey = Argument("api-key", "");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

MSBuildSettings msBuildSettings;

private void BuildProject(string filePath)
{
    MSBuild(filePath, msBuildSettings);
}

private bool GetMSBuildWith(string requires)
{
    if (IsRunningOnWindows())
    {
        DirectoryPath vsLatest = VSWhereLatest(new VSWhereLatestSettings { Requires = requires });

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
    // We tag the version with the build branch to make it
    // easier to spot special builds in NuGet feeds.
    var branch = EnvironmentVariable("GIT_BRANCH") ?? string.Empty;
    if (branch == "develop")
	version += "-develop";

    Console.WriteLine("Build Version: {0}", version);

    msBuildSettings = new MSBuildSettings();
    msBuildSettings.Verbosity = Verbosity.Minimal;
    msBuildSettings.Configuration = configuration;
    msBuildSettings.WithProperty("Version", version);
});

Task("BuildCore")
    .IsDependentOn("Prep")
    .Does(() =>
{
    DotNetCoreRestore("FreeTypeSharp.Core/FreeTypeSharp.Core.csproj");
    BuildProject("FreeTypeSharp.Core/FreeTypeSharp.Core.csproj");
});

Task("BuildAndroid")
    .IsDependentOn("Prep")
    .WithCriteria(() =>
{
    if (IsRunningOnWindows())
        return GetMSBuildWith("Component.Xamarin");

    return DirectoryExists("/Library/Frameworks/Xamarin.Android.framework");
}).Does(() =>
{
    DotNetCoreRestore("FreeTypeSharp.Android/FreeTypeSharp.Android.csproj");
    BuildProject("FreeTypeSharp.Android/FreeTypeSharp.Android.csproj");
});

Task("BuildiOS")
    .IsDependentOn("Prep")
    .WithCriteria(() =>
{
    return DirectoryExists("/Library/Frameworks/Xamarin.iOS.framework");
}).Does(() =>
{
    DotNetCoreRestore("FreeTypeSharp.iOS/FreeTypeSharp.iOS.csproj");
    BuildProject("FreeTypeSharp.iOS/FreeTypeSharp.iOS.csproj");
});

Task("Pack")
    .IsDependentOn("BuildCore")
    .IsDependentOn("BuildAndroid")
    .IsDependentOn("BuildiOS")
.Does(() =>
{
    PackageNuGet(NuGetSpecFile, "Artifacts");
});

Task("Default")
    .IsDependentOn("Pack");

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
