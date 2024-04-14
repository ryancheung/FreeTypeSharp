namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FTC_ScalerRec_
    {
        public void* face_id;
        public uint width;
        public uint height;
        public int pixel;
        public uint x_res;
        public uint y_res;
    }
}