namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FTC_ImageTypeRec_
    {
        public void* face_id;
        public uint width;
        public uint height;
        public int flags;
    }
}