using System;
using static FreeTypeSharp.Native.FT;

namespace FreeTypeSharp.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new FreeTypeLibrary();
            FT_Library_Version(library.Native, out var major, out var minor, out var patch);
            Console.WriteLine($"FreeType version: {major}.{minor}.{patch}");
            Console.WriteLine($"FreeType native path: {NativeLibraryLoader.NativeLibraryPath}");
        }
    }
}
