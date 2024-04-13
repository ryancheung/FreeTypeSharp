namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Parameter_
    {
        public UIntPtr tag;
        public void* data;
    }
}