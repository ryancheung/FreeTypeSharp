namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FTC_SBitRec_
    {
        public byte width;
        public byte height;
        public sbyte left;
        public sbyte top;
        public byte format;
        public byte max_grays;
        public short pitch;
        public sbyte xadvance;
        public sbyte yadvance;
        public byte* buffer;
    }
}