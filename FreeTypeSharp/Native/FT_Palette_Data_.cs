namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Palette_Data_
    {
        public ushort num_palettes;
        public ushort* palette_name_ids;
        public ushort* palette_flags;
        public ushort num_palette_entries;
        public ushort* palette_entry_name_ids;
    }
}