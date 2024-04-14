namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Outline_Funcs_
    {
        public void* move_to;
        public void* line_to;
        public void* conic_to;
        public void* cubic_to;
        public int shift;
        public IntPtr delta;
    }
}