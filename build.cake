#tool nuget:?package=vswhere&version=2.6.7

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("build-target", "Default");
var version = Argument("build-version", EnvironmentVariable("BUILD_NUMBER") ?? "0.0.0.0");
var configuration = Argument("build-configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

MSBuildSettings msPackSettings, mdPackSettings;
DotNetCoreMSBuildSettings dnBuildSettings;
DotNetCorePackSettings dnPackSettings;

private void PackProject(string filePath)
{
    MSBuild(filePath, msPackSettings);
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
                msPackSettings.ToolPath = files.First();
                return true;
            }
        }
    }

    return false;
}

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

    msPackSettings = new MSBuildSettings();
    msPackSettings.Verbosity = Verbosity.Minimal;
    msPackSettings.Configuration = configuration;
    msPackSettings.WithProperty("Version", version);
    msPackSettings.WithTarget("Pack");

    mdPackSettings = new MSBuildSettings();
    mdPackSettings.Verbosity = Verbosity.Minimal;
    mdPackSettings.Configuration = configuration;
    mdPackSettings.WithProperty("Version", version);
    mdPackSettings.WithTarget("PackageAddin");

    dnBuildSettings = new DotNetCoreMSBuildSettings();
    dnBuildSettings.WithProperty("Version", version);

    dnPackSettings = new DotNetCorePackSettings();
    dnPackSettings.MSBuildSettings = dnBuildSettings;
    dnPackSettings.Verbosity = DotNetCoreVerbosity.Minimal;
    dnPackSettings.Configuration = configuration;
});

Task("BuildCore")
    .IsDependentOn("Prep")
    .Does(() =>
{
    DotNetCoreRestore("FreeTypeSharp.Core/FreeTypeSharp.Core.csproj");
    PackProject("FreeTypeSharp.Core/FreeTypeSharp.Core.csproj");
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
    PackProject("FreeTypeSharp.Android/FreeTypeSharp.Android.csproj");
});

Task("BuildiOS")
    .IsDependentOn("Prep")
    .WithCriteria(() =>
{
    return DirectoryExists("/Library/Frameworks/Xamarin.iOS.framework");
}).Does(() =>
{
    DotNetCoreRestore("FreeTypeSharp.iOS/FreeTypeSharp.iOS.csproj");
    PackProject("FreeTypeSharp.iOS/FreeTypeSharp.iOS.csproj");
});

Task("Default")
    .IsDependentOn("BuildCore")
    .IsDependentOn("BuildAndroid")
    .IsDependentOn("BuildiOS");

Task("Publish")
    .IsDependentOn("Default")
.Does(() =>
{
    var publishString = "push -Source \"https://api.nuget.org/v3/index.json\" -ApiKey az {0}";
    var publishAndroid = string.Format(publishString, $"Artifacts\\Android\\Release\\FreeTypeSharp.Android.{version}.nupkg");
    var publishiOS = string.Format(publishString, $"Artifacts\\iOS\\Release\\FreeTypeSharp.iOS.{version}.nupkg");
    var publishCore = string.Format(publishString, $"Artifacts\\Core\\Release\\FreeTypeSharp.Core.{version}.nupkg");

    var exitCodeAndroid = StartProcess("nuget.exe", publishAndroid);
    var exitCodeCore = StartProcess("nuget.exe", publishCore);
    var exitCodeiOS = StartProcess("nuget.exe", publishiOS);

    Information("Exit code: Android {0}, iOS {1}, Core {2}", exitCodeAndroid, exitCodeiOS, exitCodeCore);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
