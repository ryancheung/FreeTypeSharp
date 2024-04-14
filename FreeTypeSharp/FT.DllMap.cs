using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace FreeTypeSharp
{
    public static partial class FT
    {
#if __IOS__
        public const string LibName = "__Internal";
#else
        public const string LibName = "freetype";
#endif

#if NETCOREAPP3_1_OR_GREATER && !__IOS__
        static FT()
        {
            NativeLibrary.SetDllImportResolver(typeof(FT).Assembly, ImportResolver);
        }

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName != LibName) return default;

            IntPtr handle = default;
            bool success = false;

            bool isWindows = false, isMacOS = false, isLinux = false, isAndroid = false;
#if NETCOREAPP3_1
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                isWindows = true;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                isMacOS = true;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                isLinux = true;
#else
            if (OperatingSystem.IsWindows())
                isWindows = true;
            else if (OperatingSystem.IsMacOS())
                isMacOS = true;
            else if (OperatingSystem.IsLinux())
                isLinux = true;
            else if (OperatingSystem.IsAndroid())
                isAndroid = true;
#endif

            string ActualLibraryName;
            if (isWindows)
                ActualLibraryName = "freetype.dll";
            else if (isMacOS)
                ActualLibraryName = "libfreetype.dylib";
            else if (isLinux)
                ActualLibraryName = "libfreetype.so";
            else if (isAndroid)
                ActualLibraryName = "libfreetype.so";
            else
                throw new PlatformNotSupportedException();

            string rootDirectory = AppContext.BaseDirectory;

            if (isWindows)
            {
                string arch = Environment.Is64BitProcess ? "win-x64" : "win-x86";
                var searchPaths = new[]
                {
                    // This is where native libraries in our nupkg should end up
                    Path.Combine(rootDirectory, "runtimes", arch, "native", ActualLibraryName),
                    Path.Combine(rootDirectory, Environment.Is64BitProcess ? "x64" : "x86", ActualLibraryName),
                    Path.Combine(rootDirectory, ActualLibraryName)
                };

                foreach (var path in searchPaths)
                {
                    success = NativeLibrary.TryLoad(path, out handle);

                    if (success)
                        return handle;
                }

                // Fallback to system installed freetype
                success = NativeLibrary.TryLoad(libraryName, typeof(FT).Assembly,
                    DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
                    out handle);

                if (success)
                    return handle;

                throw new FileLoadException("Failed to load native freetype library!");
            }

            if (isLinux || isMacOS)
            {
                string arch = isMacOS ? "osx" : "linux-" + (Environment.Is64BitProcess ? "x64" : "x86");

                var searchPaths = new[]
                {
                    // This is where native libraries in our nupkg should end up
                    Path.Combine(rootDirectory, "runtimes", arch, "native", ActualLibraryName),
                    // The build output folder
                    Path.Combine(rootDirectory, ActualLibraryName),
                    Path.Combine("/usr/local/lib", ActualLibraryName),
                    Path.Combine("/usr/lib", ActualLibraryName)
                };

                foreach (var path in searchPaths)
                {
                    success = NativeLibrary.TryLoad(path, out handle);

                    if (success)
                        return handle;
                }

                // Fallback to system installed freetype
                success = NativeLibrary.TryLoad(libraryName, typeof(FT).Assembly,
                    DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
                    out handle);

                if (success)
                    return handle;

                throw new FileLoadException("Failed to load native freetype library!");
            }

            if (isAndroid)
            {
                success = NativeLibrary.TryLoad(ActualLibraryName, typeof(FT).Assembly,
                    DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies, 
                    out handle);

                if (!success)
                    success = NativeLibrary.TryLoad(ActualLibraryName, out handle);

                if (success)
                    return handle;

                // Fallback to system installed freetype
                success = NativeLibrary.TryLoad(libraryName, typeof(FT).Assembly,
                    DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
                    out handle);

                if (success)
                    return handle;

                throw new FileLoadException("Failed to load native freetype library!");
            }

            return handle;
        }
#endif
    }
}