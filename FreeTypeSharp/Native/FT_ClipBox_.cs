namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_ClipBox_
    {
        public FT_Vector_ bottom_left;
        public FT_Vector_ top_left;
        public FT_Vector_ top_right;
        public FT_Vector_ bottom_right;
    }
}