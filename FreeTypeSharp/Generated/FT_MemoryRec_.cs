namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_MemoryRec_
    {
        public void* user;
        public void* alloc;
        public void* free;
        public void* realloc;
    }
}