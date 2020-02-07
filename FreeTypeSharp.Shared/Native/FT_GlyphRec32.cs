using System;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
#pragma warning disable 1591
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_GlyphRec32
    {
        public FT_LibraryRec* library;
        public IntPtr clazz;
        public FT_Glyph_Format format;
        public FT_Vector32 advance;
    }
#pragma warning restore 1591
}
