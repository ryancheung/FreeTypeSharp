using System;
using static FreeTypeSharp.FT;

namespace FreeTypeSharp.Core.Test
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var library = new FreeTypeLibrary();
            int major, minor, patch;
            FT_Library_Version(library.Native, &major, &minor, &patch);
            Console.WriteLine($"FreeType version: {major}.{minor}.{patch}");
        }
    }
}
