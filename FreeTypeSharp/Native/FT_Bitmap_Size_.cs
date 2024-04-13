namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Bitmap_Size_
    {
        public short height;
        public short width;
        public IntPtr size;
        public IntPtr x_ppem;
        public IntPtr y_ppem;
    }
}