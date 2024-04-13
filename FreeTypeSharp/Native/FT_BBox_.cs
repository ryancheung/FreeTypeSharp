namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_BBox_
    {
        public IntPtr xMin;
        public IntPtr yMin;
        public IntPtr xMax;
        public IntPtr yMax;
    }
}