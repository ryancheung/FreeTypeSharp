using System;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
#pragma warning disable 1591
    public static unsafe partial class FreeTypeNative
    {
        public static bool IsWindows()
        {
#if __IOS__ || ANDROID
            return false;
#else
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                case PlatformID.Unix:
                    return false;
                default:
                    return true;
            }
#endif
        }
        public static Boolean Use64BitInterface => Environment.Is64BitProcess;

#if ANDROID
        const String LIBRARY = "freetype";
#elif __IOS__
        const String LIBRARY = "__Internal";
#else
        const String LIBRARY = "freetype";
#endif

        [DllImport(LIBRARY, EntryPoint="FT_Init_FreeType", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Init_FreeType(IntPtr alibrary);

        [DllImport(LIBRARY, EntryPoint="FT_Done_FreeType", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_FreeType(IntPtr library);

        [DllImport(LIBRARY, EntryPoint="FT_New_Face", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Face32(IntPtr library, [MarshalAs(UnmanagedType.LPStr)] String filepathname, Int32 face_index, IntPtr aface);

        [DllImport(LIBRARY, EntryPoint="FT_New_Face", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Face64(IntPtr library, [MarshalAs(UnmanagedType.LPStr)] String filepathname, Int64 face_index, IntPtr aface);

        [DllImport(LIBRARY, EntryPoint="FT_New_Memory_Face", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Memory_Face32(IntPtr library, IntPtr file_base, Int32 file_size, Int32 face_index, IntPtr aface);

        [DllImport(LIBRARY, EntryPoint="FT_New_Memory_Face", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Memory_Face64(IntPtr library, IntPtr file_base, Int64 file_size, Int64 face_index, IntPtr aface);

        [DllImport(LIBRARY, EntryPoint="FT_Done_Face", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Face(IntPtr face);

        [DllImport(LIBRARY, EntryPoint="FT_Set_Char_Size", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Char_Size32(IntPtr face, Int32 char_width, Int32 char_height, UInt32 horz_resolution, UInt32 vert_resolution);

        [DllImport(LIBRARY, EntryPoint="FT_Set_Char_Size", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Char_Size64(IntPtr face, Int32 char_width, Int32 char_height, UInt32 horz_resolution, UInt32 vert_resolution);

        [DllImport(LIBRARY, EntryPoint="FT_Select_Size", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Select_Size(IntPtr face, Int32 strike_index);

        [DllImport(LIBRARY, EntryPoint="FT_Get_Char_Index", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 FT_Get_Char_Index32(IntPtr face, UInt32 charcode);

        [DllImport(LIBRARY, EntryPoint="FT_Get_Char_Index", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 FT_Get_Char_Index64(IntPtr face, UInt64 charcode);

        [DllImport(LIBRARY, EntryPoint = "FT_Set_Transform", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Transform(IntPtr face, IntPtr matrix, IntPtr delta);

        [DllImport(LIBRARY, EntryPoint="FT_Load_Glyph", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Load_Glyph(IntPtr face, UInt32 glyph_index, Int32 load_flags);

        [DllImport(LIBRARY, EntryPoint="FT_Get_Kerning", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Kerning(IntPtr face, UInt32 left_glyph, UInt32 right_glyph, UInt32 kern_mode, IntPtr akerning);

        [DllImport(LIBRARY, EntryPoint="FT_Get_Glyph", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Glyph(IntPtr slot, IntPtr aglyph);

        [DllImport(LIBRARY, EntryPoint="FT_Done_Glyph", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Done_Glyph(IntPtr glyph);

        [DllImport(LIBRARY, EntryPoint="FT_Render_Glyph", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Render_Glyph(IntPtr slot, FT_Render_Mode render_mode);

        [DllImport(LIBRARY, EntryPoint="FT_Stroker_New", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_New(IntPtr library, IntPtr astroker);

        [DllImport(LIBRARY, EntryPoint="FT_Stroker_Done", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Done(IntPtr stroker);

        [DllImport(LIBRARY, EntryPoint="FT_Stroker_Set", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Set32(IntPtr stroker, Int32 radius, FT_Stroker_LineCap line_cap, FT_Stroker_LineJoin line_join, Int32 miter_limit);

        [DllImport(LIBRARY, EntryPoint="FT_Stroker_Set", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Set64(IntPtr stroker, Int64 radius, FT_Stroker_LineCap line_cap, FT_Stroker_LineJoin line_join, Int64 miter_limit);

        [DllImport(LIBRARY, EntryPoint="FT_Glyph_StrokeBorder", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_StrokeBorder(IntPtr pglyph, IntPtr stroker, Boolean inside, Boolean destroy);

        [DllImport(LIBRARY, EntryPoint="FT_Glyph_To_Bitmap", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_To_Bitmap(IntPtr the_glyph, FT_Render_Mode render_mode, IntPtr origin, Boolean destroy);
        
        [DllImport(LIBRARY, EntryPoint="FT_Property_Set", CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Property_Set(IntPtr alibrary, string module_name, string property_name, IntPtr value);

    }
#pragma warning restore 1591
}
