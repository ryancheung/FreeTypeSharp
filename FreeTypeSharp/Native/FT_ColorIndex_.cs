namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_ColorIndex_
    {
        public ushort palette_index;
        public short alpha;
    }
}