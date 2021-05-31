using System;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_GlyphLoaderRec
    {
        public IntPtr memory;
        public uint max_points;
        public uint max_contours;
        public uint max_subglyphs;
        public bool use_extra;

        public FT_GlyphLoadRec @base;
        public FT_GlyphLoadRec current;

        public IntPtr other;
    }
}
