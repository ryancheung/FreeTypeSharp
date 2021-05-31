using System;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_GlyphLoadRec
    {
        public FT_Outline outline;
        public FT_Vector* extra_points;
        public FT_Vector* extra_points2;
        public uint num_subglyphs;
        public FT_SubGlyphRec* subglyphs;
    }
}
