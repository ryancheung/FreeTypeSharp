namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Raster_Params_
    {
        public FT_Bitmap_* target;
        public void* source;
        public int flags;
        public void* gray_spans;
        public void* black_spans;
        public void* bit_test;
        public void* bit_set;
        public void* user;
        public FT_BBox_ clip_box;
    }
}