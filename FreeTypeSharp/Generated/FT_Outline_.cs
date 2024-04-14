namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Outline_
    {
        public short n_contours;
        public short n_points;
        public FT_Vector_* points;
        public byte* tags;
        public short* contours;
        public int flags;
    }
}