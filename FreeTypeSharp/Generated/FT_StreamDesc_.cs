namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_StreamDesc_
    {
        public IntPtr value;
        public void* pointer;
    }
}