namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Bitmap_
    {
        public uint rows;
        public uint width;
        public int pitch;
        public byte* buffer;
        public ushort num_grays;
        public FT_Pixel_Mode_ pixel_mode;
        public byte palette_mode;
        public void* palette;
    }
}