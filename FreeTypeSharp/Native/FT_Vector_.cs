namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Vector_
    {
        public IntPtr x;
        public IntPtr y;
    }
}