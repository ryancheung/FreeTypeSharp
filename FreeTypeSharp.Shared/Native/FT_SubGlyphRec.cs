using System;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_SubGlyphRec
    {
        public int index;
        public ushort flags;
        public int arg1;
        public int arg2;
        public FT_Matrix transform;
    }
}
