#if !ANDROID && !IOS
using PlatformSharp;
using FreeTypeSharp.Native.LibraryLoader;

namespace FreeTypeSharp.Native
{
#pragma warning disable 1591
    internal static class NativeLibs
    {
        public static readonly NativeLibrary libpng = new NativeLibrary(
            PlatformInfo.CurrentPlatform == Platform.Windows ? "libpng16" : "libpng");
        public static readonly NativeLibrary libfreetype = new NativeLibrary(
            PlatformInfo.CurrentPlatform == Platform.Windows ? "freetype" : "libfreetype");
    }
#pragma warning restore 1591
}
#endif
