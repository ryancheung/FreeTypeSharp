namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_StreamRec_
    {
        public byte* _base;
        public UIntPtr size;
        public UIntPtr pos;
        public FT_StreamDesc_ descriptor;
        public FT_StreamDesc_ pathname;
        public void* read;
        public void* close;
        public FT_MemoryRec_* memory;
        public byte* cursor;
        public byte* limit;
    }
}