namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Matrix_
    {
        public IntPtr xx;
        public IntPtr xy;
        public IntPtr yx;
        public IntPtr yy;
    }
}