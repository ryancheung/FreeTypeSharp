namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Opaque_Paint_
    {
        public byte* p;
        public byte insert_root_transform;
    }
}