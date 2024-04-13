namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_ColorStopIterator_
    {
        public uint num_color_stops;
        public uint current_color_stop;
        public byte* p;
        public byte read_variable;
    }
}