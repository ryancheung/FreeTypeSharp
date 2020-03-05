using System;
using System.Runtime.InteropServices;
using FT_Fixed = System.IntPtr;
using FT_Pos = System.IntPtr;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_Size_Metrics
    {
        public ushort x_ppem;
        public ushort y_ppem;

        public FT_Fixed x_scale;
        public FT_Fixed y_scale;

        public FT_Pos ascender;
        public FT_Pos descender;
        public FT_Pos height;
        public FT_Pos max_advance;
    }
}
