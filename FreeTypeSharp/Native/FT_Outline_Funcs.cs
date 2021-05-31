using System;
using System.Runtime.InteropServices;
using FT_Pos = System.IntPtr;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_Outline_Funcs
    {
        public IntPtr moveTo;
        public IntPtr lineTo;
        public IntPtr conicTo;
        public IntPtr cubicTo;
        public int shift;
        public FT_Pos delta;
    }
}