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

DotNetCoreBuildSettings settings;

private void BuildProject(string filePath)
{
    DotNetCoreBuild(filePath, settings);
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

    settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        MSBuildSettings = new DotNetCoreMSBuildSettings()
            .SetVersion(version)
    };
});

Task("BuildNET6.0")
    .IsDependentOn("Prep")
    .Does(() =>
{
    settings.Framework = "net6.0";
    BuildProject("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildAndroid")
    .IsDependentOn("Prep")
    .Does(() =>
{
    settings.Framework = "net6.0-android";
    BuildProject("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildiOS")
    .IsDependentOn("Prep")
    .WithCriteria(() => Context.Environment.Platform.IsOSX(), "Not on macOS.")
    .Does(() =>
{
    settings.Framework = "net6.0-ios";
    BuildProject("FreeTypeSharp/FreeTypeSharp.csproj");
});

Task("BuildUWP")
    .IsDependentOn("Prep")
    .WithCriteria(() => Context.Environment.Platform.IsWindows(), "Not on Windows.")
    .Does(() =>
{
    settings.Framework = "net6.0-windows10.0.19041.0";
    BuildProject("FreeTypeSharp/FreeTypeSharp.Uwp.csproj");
});

Task("Default")
    .IsDependentOn("BuildNET6.0")
    .IsDependentOn("BuildAndroid")
    .IsDependentOn("BuildiOS")
    .IsDependentOn("BuildUWP");

Task("Pack")
    .IsDependentOn("BuildNET6.0")
    .IsDependentOn("BuildAndroid")
    .IsDependentOn("BuildiOS")
    .IsDependentOn("BuildUWP")
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
