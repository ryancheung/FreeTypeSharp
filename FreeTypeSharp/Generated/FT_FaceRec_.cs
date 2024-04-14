namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_FaceRec_
    {
        public IntPtr num_faces;
        public IntPtr face_index;
        public IntPtr face_flags;
        public IntPtr style_flags;
        public IntPtr num_glyphs;
        public byte* family_name;
        public byte* style_name;
        public int num_fixed_sizes;
        public FT_Bitmap_Size_* available_sizes;
        public int num_charmaps;
        public FT_CharMapRec_** charmaps;
        public FT_Generic_ generic;
        public FT_BBox_ bbox;
        public ushort units_per_EM;
        public short ascender;
        public short descender;
        public short height;
        public short max_advance_width;
        public short max_advance_height;
        public short underline_position;
        public short underline_thickness;
        public FT_GlyphSlotRec_* glyph;
        public FT_SizeRec_* size;
        public FT_CharMapRec_* charmap;
        public FT_DriverRec_* driver;
        public FT_MemoryRec_* memory;
        public FT_StreamRec_* stream;
        public FT_ListRec_ sizes_list;
        public FT_Generic_ autohint;
        public void* extensions;
        public FT_Face_InternalRec_* _internal;
    }
}