#if NETSTANDARD2_0
using System;
using System.Runtime.InteropServices;
using static FreeTypeSharp.NativeLibraryLoader;
#endif

namespace FreeTypeSharp.Native
{
    static unsafe partial class FT
    {

#if NETSTANDARD2_0

        #region Core API

        #region FreeType Version

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Library_Version_(IntPtr library, out int amajor, out int aminor, out int apatch);
        public static FT_Library_Version_ FT_Library_Version = LoadFunction<FT_Library_Version_>("FT_Library_Version");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool FT_Face_CheckTrueTypePatents_(IntPtr face);
        public static FT_Face_CheckTrueTypePatents_ FT_Face_CheckTrueTypePatents = LoadFunction<FT_Face_CheckTrueTypePatents_>("FT_Face_CheckTrueTypePatents");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool FT_Face_SetUnpatentedHinting_(IntPtr face, [MarshalAs(UnmanagedType.U1)] bool value);
        public static FT_Face_SetUnpatentedHinting_ FT_Face_SetUnpatentedHinting = LoadFunction<FT_Face_SetUnpatentedHinting_>("FT_Face_SetUnpatentedHinting");

        #endregion

        #region Base Interface

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Init_FreeType_(out IntPtr alibrary);
        public static FT_Init_FreeType_ FT_Init_FreeType = LoadFunction<FT_Init_FreeType_>("FT_Init_FreeType");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Done_FreeType_(IntPtr library);
        public static FT_Done_FreeType_ FT_Done_FreeType = LoadFunction<FT_Done_FreeType_>("FT_Done_FreeType");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error FT_New_Face_(IntPtr library, string filepathname, int face_index, out IntPtr aface);
        public static FT_New_Face_ FT_New_Face = LoadFunction<FT_New_Face_>("FT_New_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_New_Memory_Face_(IntPtr library, IntPtr file_base, int file_size, int face_index, out IntPtr aface);
        public static FT_New_Memory_Face_ FT_New_Memory_Face = LoadFunction<FT_New_Memory_Face_>("FT_New_Memory_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Open_Face_(IntPtr library, IntPtr args, int face_index, out IntPtr aface);
        public static FT_Open_Face_ FT_Open_Face = LoadFunction<FT_Open_Face_>("FT_Open_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error FT_Attach_File_(IntPtr face, string filepathname);
        public static FT_Attach_File_ FT_Attach_File = LoadFunction<FT_Attach_File_>("FT_Attach_File");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Attach_Stream_(IntPtr face, IntPtr parameters);
        public static FT_Attach_Stream_ FT_Attach_Stream = LoadFunction<FT_Attach_Stream_>("FT_Attach_Stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Reference_Face_(IntPtr face);
        public static FT_Reference_Face_ FT_Reference_Face = LoadFunction<FT_Reference_Face_>("FT_Reference_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Done_Face_(IntPtr face);
        public static FT_Done_Face_ FT_Done_Face = LoadFunction<FT_Done_Face_>("FT_Done_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Select_Size_(IntPtr face, int strike_index);
        public static FT_Select_Size_ FT_Select_Size = LoadFunction<FT_Select_Size_>("FT_Select_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Request_Size_(IntPtr face, IntPtr req);
        public static FT_Request_Size_ FT_Request_Size = LoadFunction<FT_Request_Size_>("FT_Request_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Set_Char_Size_(IntPtr face, IntPtr char_width, IntPtr char_height, uint horz_resolution, uint vert_resolution);
        public static FT_Set_Char_Size_ FT_Set_Char_Size = LoadFunction<FT_Set_Char_Size_>("FT_Set_Char_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Set_Pixel_Sizes_(IntPtr face, uint pixel_width, uint pixel_height);
        public static FT_Set_Pixel_Sizes_ FT_Set_Pixel_Sizes = LoadFunction<FT_Set_Pixel_Sizes_>("FT_Set_Pixel_Sizes");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Load_Glyph_(IntPtr face, uint glyph_index, int load_flags);
        public static FT_Load_Glyph_ FT_Load_Glyph = LoadFunction<FT_Load_Glyph_>("FT_Load_Glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Load_Char_(IntPtr face, uint char_code, int load_flags);
        public static FT_Load_Char_ FT_Load_Char = LoadFunction<FT_Load_Char_>("FT_Load_Char");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Set_Transform_(IntPtr face, IntPtr matrix, IntPtr delta);
        public static FT_Set_Transform_ FT_Set_Transform = LoadFunction<FT_Set_Transform_>("FT_Set_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Render_Glyph_(IntPtr slot, FT_Render_Mode render_mode);
        public static FT_Render_Glyph_ FT_Render_Glyph = LoadFunction<FT_Render_Glyph_>("FT_Render_Glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_Kerning_(IntPtr face, uint left_glyph, uint right_glyph, uint kern_mode, out FT_Vector akerning);
        public static FT_Get_Kerning_ FT_Get_Kerning = LoadFunction<FT_Get_Kerning_>("FT_Get_Kerning");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_Track_Kerning_(IntPtr face, IntPtr point_size, int degree, out IntPtr akerning);
        public static FT_Get_Track_Kerning_ FT_Get_Track_Kerning = LoadFunction<FT_Get_Track_Kerning_>("FT_Get_Track_Kerning");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_Glyph_Name_(IntPtr face, uint glyph_index, IntPtr buffer, uint buffer_max);
        public static FT_Get_Glyph_Name_ FT_Get_Glyph_Name = LoadFunction<FT_Get_Glyph_Name_>("FT_Get_Glyph_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr FT_Get_Postscript_Name_(IntPtr face);
        public static FT_Get_Postscript_Name_ FT_Get_Postscript_Name = LoadFunction<FT_Get_Postscript_Name_>("FT_Get_Postscript_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Select_Charmap_(IntPtr face, FT_Encoding encoding);
        public static FT_Select_Charmap_ FT_Select_Charmap = LoadFunction<FT_Select_Charmap_>("FT_Select_Charmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Set_Charmap_(IntPtr face, IntPtr charmap);
        public static FT_Set_Charmap_ FT_Set_Charmap = LoadFunction<FT_Set_Charmap_>("FT_Set_Charmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int FT_Get_Charmap_Index_(IntPtr charmap);
        public static FT_Get_Charmap_Index_ FT_Get_Charmap_Index = LoadFunction<FT_Get_Charmap_Index_>("FT_Get_Charmap_Index");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FT_Get_Char_Index_(IntPtr face, uint charcode);
        public static FT_Get_Char_Index_ FT_Get_Char_Index = LoadFunction<FT_Get_Char_Index_>("FT_Get_Char_Index");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FT_Get_First_Char_(IntPtr face, out uint agindex);
        public static FT_Get_First_Char_ FT_Get_First_Char = LoadFunction<FT_Get_First_Char_>("FT_Get_First_Char");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FT_Get_Next_Char_(IntPtr face, uint char_code, out uint agindex);
        public static FT_Get_Next_Char_ FT_Get_Next_Char = LoadFunction<FT_Get_Next_Char_>("FT_Get_Next_Char");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FT_Get_Name_Index_(IntPtr face, IntPtr glyph_name);
        public static FT_Get_Name_Index_ FT_Get_Name_Index = LoadFunction<FT_Get_Name_Index_>("FT_Get_Name_Index");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_SubGlyph_Info_(IntPtr glyph, uint sub_index, out int p_index, out uint p_flags, out int p_arg1, out int p_arg2, out FT_Matrix p_transform);
        public static FT_Get_SubGlyph_Info_ FT_Get_SubGlyph_Info = LoadFunction<FT_Get_SubGlyph_Info_>("FT_Get_SubGlyph_Info");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ushort FT_Get_FSType_Flags_(IntPtr face);
        public static FT_Get_FSType_Flags_ FT_Get_FSType_Flags = LoadFunction<FT_Get_FSType_Flags_>("FT_Get_FSType_Flags");

        #endregion

        #region Glyph Variants
        //TODO:
        #endregion

        #region Glyph Management

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_Glyph_(IntPtr slot, out IntPtr aglyph);
        public static FT_Get_Glyph_ FT_Get_Glyph = LoadFunction<FT_Get_Glyph_>("FT_Get_Glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Glyph_Copy_(IntPtr source, out IntPtr target);
        public static FT_Glyph_Copy_ FT_Glyph_Copy = LoadFunction<FT_Glyph_Copy_>("FT_Glyph_Copy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Glyph_Transform_(IntPtr glyph, ref FT_Matrix matrix, ref FT_Vector delta);
        public static FT_Glyph_Transform_ FT_Glyph_Transform = LoadFunction<FT_Glyph_Transform_>("FT_Glyph_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Glyph_Get_CBox_(IntPtr glyph, FT_Glyph_BBox_Mode bbox_mode, out FT_BBox acbox);
        public static FT_Glyph_Get_CBox_ FT_Glyph_Get_CBox = LoadFunction<FT_Glyph_Get_CBox_>("FT_Glyph_Get_CBox");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Glyph_To_Bitmap_(ref IntPtr the_glyph, FT_Render_Mode render_mode, ref FT_Vector origin, [MarshalAs(UnmanagedType.U1)] bool destroy);
        public static FT_Glyph_To_Bitmap_ FT_Glyph_To_Bitmap = LoadFunction<FT_Glyph_To_Bitmap_>("FT_Glyph_To_Bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Done_Glyph_(IntPtr glyph);
        public static FT_Done_Glyph_ FT_Done_Glyph = LoadFunction<FT_Done_Glyph_>("FT_Done_Glyph");

        #endregion

        #region Mac Specific Interface - check for macOS before calling these methods.
        //TODO:
        #endregion

        #region Size Management

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_New_Size_(IntPtr face, out IntPtr size);
        public static FT_New_Size_ FT_New_Size = LoadFunction<FT_New_Size_>("FT_New_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Done_Size_(IntPtr size);
        public static FT_Done_Size_ FT_Done_Size = LoadFunction<FT_Done_Size_>("FT_Done_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Activate_Size_(IntPtr size);
        public static FT_Activate_Size_ FT_Activate_Size = LoadFunction<FT_Activate_Size_>("FT_Activate_Size");

        #endregion

        #endregion

        #region Support API

        #region Computations
        //TODO:
        #endregion

        #region List Processing

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr FT_List_Find_(IntPtr list, IntPtr data);
        public static FT_List_Find_ FT_List_Find = LoadFunction<FT_List_Find_>("FT_List_Find");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_List_Add_(IntPtr list, IntPtr node);
        public static FT_List_Add_ FT_List_Add = LoadFunction<FT_List_Add_>("FT_List_Add");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_List_Insert_(IntPtr list, IntPtr node);
        public static FT_List_Insert_ FT_List_Insert = LoadFunction<FT_List_Insert_>("FT_List_Insert");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_List_Remove_(IntPtr list, IntPtr node);
        public static FT_List_Remove_ FT_List_Remove = LoadFunction<FT_List_Remove_>("FT_List_Remove");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_List_Up_(IntPtr list, IntPtr node);
        public static FT_List_Up_ FT_List_Up = LoadFunction<FT_List_Up_>("FT_List_Up");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_List_Iterate_(IntPtr list, FT_List_Iterator iterator, IntPtr user);
        public static FT_List_Iterate_ FT_List_Iterate = LoadFunction<FT_List_Iterate_>("FT_List_Iterate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_List_Finalize_(IntPtr list, FT_List_Destructor destroy, IntPtr memory, IntPtr user);
        public static FT_List_Finalize_ FT_List_Finalize = LoadFunction<FT_List_Finalize_>("FT_List_Finalize");

        #endregion

        #region Outline Processing

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_New_(IntPtr library, uint numPoints, int numContours, out IntPtr anoutline);
        public static FT_Outline_New_ FT_Outline_New = LoadFunction<FT_Outline_New_>("FT_Outline_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_New_Internal_(IntPtr memory, uint numPoints, int numContours, out IntPtr anoutline);
        public static FT_Outline_New_Internal_ FT_Outline_New_Internal = LoadFunction<FT_Outline_New_Internal_>("FT_Outline_New_Internal");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Done_(IntPtr library, IntPtr outline);
        public static FT_Outline_Done_ FT_Outline_Done = LoadFunction<FT_Outline_Done_>("FT_Outline_Done");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Done_Internal_(IntPtr memory, IntPtr outline);
        public static FT_Outline_Done_Internal_ FT_Outline_Done_Internal = LoadFunction<FT_Outline_Done_Internal_>("FT_Outline_Done_Internal");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Copy_(IntPtr source, ref IntPtr target);
        public static FT_Outline_Copy_ FT_Outline_Copy = LoadFunction<FT_Outline_Copy_>("FT_Outline_Copy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Outline_Translate_(IntPtr outline, int xOffset, int yOffset);
        public static FT_Outline_Translate_ FT_Outline_Translate = LoadFunction<FT_Outline_Translate_>("FT_Outline_Translate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Outline_Transform_(IntPtr outline, ref FT_Matrix matrix);
        public static FT_Outline_Transform_ FT_Outline_Transform = LoadFunction<FT_Outline_Transform_>("FT_Outline_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Embolden_(IntPtr outline, IntPtr strength);
        public static FT_Outline_Embolden_ FT_Outline_Embolden = LoadFunction<FT_Outline_Embolden_>("FT_Outline_Embolden");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_EmboldenXY_(IntPtr outline, int xstrength, int ystrength);
        public static FT_Outline_EmboldenXY_ FT_Outline_EmboldenXY = LoadFunction<FT_Outline_EmboldenXY_>("FT_Outline_EmboldenXY");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Outline_Reverse_(IntPtr outline);
        public static FT_Outline_Reverse_ FT_Outline_Reverse = LoadFunction<FT_Outline_Reverse_>("FT_Outline_Reverse");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Check_(IntPtr outline);
        public static FT_Outline_Check_ FT_Outline_Check = LoadFunction<FT_Outline_Check_>("FT_Outline_Check");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Get_BBox_(IntPtr outline, out FT_BBox abbox);
        public static FT_Outline_Get_BBox_ FT_Outline_Get_BBox = LoadFunction<FT_Outline_Get_BBox_>("FT_Outline_Get_BBox");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Decompose_(IntPtr outline, ref FT_Outline_Funcs func_interface, IntPtr user);
        public static FT_Outline_Decompose_ FT_Outline_Decompose = LoadFunction<FT_Outline_Decompose_>("FT_Outline_Decompose");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Outline_Get_CBox_(IntPtr outline, out FT_BBox acbox);
        public static FT_Outline_Get_CBox_ FT_Outline_Get_CBox = LoadFunction<FT_Outline_Get_CBox_>("FT_Outline_Get_CBox");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Get_Bitmap_(IntPtr library, IntPtr outline, IntPtr abitmap);
        public static FT_Outline_Get_Bitmap_ FT_Outline_Get_Bitmap = LoadFunction<FT_Outline_Get_Bitmap_>("FT_Outline_Get_Bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Outline_Render_(IntPtr library, IntPtr outline, IntPtr @params);
        public static FT_Outline_Render_ FT_Outline_Render = LoadFunction<FT_Outline_Render_>("FT_Outline_Render");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Orientation FT_Outline_Get_Orientation_(IntPtr outline);
        public static FT_Outline_Get_Orientation_ FT_Outline_Get_Orientation = LoadFunction<FT_Outline_Get_Orientation_>("FT_Outline_Get_Orientation");

        #endregion

        #region Quick retrieval of advance values

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_Advance_(IntPtr face, uint gIndex, uint load_flags, out IntPtr padvance);
        public static FT_Get_Advance_ FT_Get_Advance = LoadFunction<FT_Get_Advance_>("FT_Get_Advance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Get_Advances_(IntPtr face, uint start, uint count, uint load_flags, out IntPtr padvance);
        public static FT_Get_Advances_ FT_Get_Advances = LoadFunction<FT_Get_Advances_>("FT_Get_Advances");

        #endregion

        #region Bitmap Handling

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Bitmap_New_(IntPtr abitmap);
        public static FT_Bitmap_New_ FT_Bitmap_New = LoadFunction<FT_Bitmap_New_>("FT_Bitmap_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Bitmap_Copy_(IntPtr library, IntPtr source, IntPtr target);
        public static FT_Bitmap_Copy_ FT_Bitmap_Copy = LoadFunction<FT_Bitmap_Copy_>("FT_Bitmap_Copy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Bitmap_Embolden_(IntPtr library, IntPtr bitmap, IntPtr xStrength, IntPtr yStrength);
        public static FT_Bitmap_Embolden_ FT_Bitmap_Embolden = LoadFunction<FT_Bitmap_Embolden_>("FT_Bitmap_Embolden");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Bitmap_Convert_(IntPtr library, IntPtr source, IntPtr target, int alignment);
        public static FT_Bitmap_Convert_ FT_Bitmap_Convert = LoadFunction<FT_Bitmap_Convert_>("FT_Bitmap_Convert");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_GlyphSlot_Own_Bitmap_(IntPtr slot);
        public static FT_GlyphSlot_Own_Bitmap_ FT_GlyphSlot_Own_Bitmap = LoadFunction<FT_GlyphSlot_Own_Bitmap_>("FT_GlyphSlot_Own_Bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Bitmap_Done_(IntPtr library, IntPtr bitmap);
        public static FT_Bitmap_Done_ FT_Bitmap_Done = LoadFunction<FT_Bitmap_Done_>("FT_Bitmap_Done");

        #endregion

        #region Glyph Stroker

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_StrokerBorder FT_Outline_GetInsideBorder_(IntPtr outline);
        public static FT_Outline_GetInsideBorder_ FT_Outline_GetInsideBorder = LoadFunction<FT_Outline_GetInsideBorder_>("FT_Outline_GetInsideBorder");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_StrokerBorder FT_Outline_GetOutsideBorder_(IntPtr outline);
        public static FT_Outline_GetOutsideBorder_ FT_Outline_GetOutsideBorder = LoadFunction<FT_Outline_GetOutsideBorder_>("FT_Outline_GetOutsideBorder");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_New_(IntPtr library, out IntPtr astroker);
        public static FT_Stroker_New_ FT_Stroker_New = LoadFunction<FT_Stroker_New_>("FT_Stroker_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Stroker_Set_(IntPtr stroker, int radius, FT_Stroker_LineCap line_cap, FT_Stroker_LineJoin line_join, IntPtr miter_limit);
        public static FT_Stroker_Set_ FT_Stroker_Set = LoadFunction<FT_Stroker_Set_>("FT_Stroker_Set");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Stroker_Rewind_(IntPtr stroker);
        public static FT_Stroker_Rewind_ FT_Stroker_Rewind = LoadFunction<FT_Stroker_Rewind_>("FT_Stroker_Rewind");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_ParseOutline_(IntPtr stroker, IntPtr outline, [MarshalAs(UnmanagedType.U1)] bool opened);
        public static FT_Stroker_ParseOutline_ FT_Stroker_ParseOutline = LoadFunction<FT_Stroker_ParseOutline_>("FT_Stroker_ParseOutline");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_BeginSubPath_(IntPtr stroker, ref FT_Vector to, [MarshalAs(UnmanagedType.U1)] bool open);
        public static FT_Stroker_BeginSubPath_ FT_Stroker_BeginSubPath = LoadFunction<FT_Stroker_BeginSubPath_>("FT_Stroker_BeginSubPath");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_EndSubPath_(IntPtr stroker);
        public static FT_Stroker_EndSubPath_ FT_Stroker_EndSubPath = LoadFunction<FT_Stroker_EndSubPath_>("FT_Stroker_EndSubPath");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_LineTo_(IntPtr stroker, ref FT_Vector to);
        public static FT_Stroker_LineTo_ FT_Stroker_LineTo = LoadFunction<FT_Stroker_LineTo_>("FT_Stroker_LineTo");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_ConicTo_(IntPtr stroker, ref FT_Vector control, ref FT_Vector to);
        public static FT_Stroker_ConicTo_ FT_Stroker_ConicTo = LoadFunction<FT_Stroker_ConicTo_>("FT_Stroker_ConicTo");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_CubicTo_(IntPtr stroker, ref FT_Vector control1, ref FT_Vector control2, ref FT_Vector to);
        public static FT_Stroker_CubicTo_ FT_Stroker_CubicTo = LoadFunction<FT_Stroker_CubicTo_>("FT_Stroker_CubicTo");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_GetBorderCounts_(IntPtr stroker, FT_StrokerBorder border, out uint anum_points, out uint anum_contours);
        public static FT_Stroker_GetBorderCounts_ FT_Stroker_GetBorderCounts = LoadFunction<FT_Stroker_GetBorderCounts_>("FT_Stroker_GetBorderCounts");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Stroker_ExportBorder_(IntPtr stroker, FT_StrokerBorder border, IntPtr outline);
        public static FT_Stroker_ExportBorder_ FT_Stroker_ExportBorder = LoadFunction<FT_Stroker_ExportBorder_>("FT_Stroker_ExportBorder");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stroker_GetCounts_(IntPtr stroker, out uint anum_points, out uint anum_contours);
        public static FT_Stroker_GetCounts_ FT_Stroker_GetCounts = LoadFunction<FT_Stroker_GetCounts_>("FT_Stroker_GetCounts");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Stroker_Export_(IntPtr stroker, IntPtr outline);
        public static FT_Stroker_Export_ FT_Stroker_Export = LoadFunction<FT_Stroker_Export_>("FT_Stroker_Export");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Stroker_Done_(IntPtr stroker);
        public static FT_Stroker_Done_ FT_Stroker_Done = LoadFunction<FT_Stroker_Done_>("FT_Stroker_Done");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Glyph_Stroke_(ref IntPtr pglyph, IntPtr stoker, [MarshalAs(UnmanagedType.U1)] bool destroy);
        public static FT_Glyph_Stroke_ FT_Glyph_Stroke = LoadFunction<FT_Glyph_Stroke_>("FT_Glyph_Stroke");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Glyph_StrokeBorder_(ref IntPtr pglyph, IntPtr stoker, [MarshalAs(UnmanagedType.U1)] bool inside, [MarshalAs(UnmanagedType.U1)] bool destroy);
        public static FT_Glyph_StrokeBorder_ FT_Glyph_StrokeBorder = LoadFunction<FT_Glyph_StrokeBorder_>("FT_Glyph_StrokeBorder");

        #endregion

        #region Module Management

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Add_Module_(IntPtr library, IntPtr clazz);
        public static FT_Add_Module_ FT_Add_Module = LoadFunction<FT_Add_Module_>("FT_Add_Module");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate IntPtr FT_Get_Module_(IntPtr library, string module_name);
        public static FT_Get_Module_ FT_Get_Module = LoadFunction<FT_Get_Module_>("FT_Get_Module");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Remove_Module_(IntPtr library, IntPtr module);
        public static FT_Remove_Module_ FT_Remove_Module = LoadFunction<FT_Remove_Module_>("FT_Remove_Module");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error FT_Property_Set_(IntPtr library, string module_name, string property_name, IntPtr value);
        public static FT_Property_Set_ FT_Property_Set = LoadFunction<FT_Property_Set_>("FT_Property_Set");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error FT_Property_Get_(IntPtr library, string module_name, string property_name, IntPtr value);
        public static FT_Property_Get_ FT_Property_Get = LoadFunction<FT_Property_Get_>("FT_Property_Get");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Reference_Library_(IntPtr library);
        public static FT_Reference_Library_ FT_Reference_Library = LoadFunction<FT_Reference_Library_>("FT_Reference_Library");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_New_Library_(IntPtr memory, out IntPtr alibrary);
        public static FT_New_Library_ FT_New_Library = LoadFunction<FT_New_Library_>("FT_New_Library");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Done_Library_(IntPtr library);
        public static FT_Done_Library_ FT_Done_Library = LoadFunction<FT_Done_Library_>("FT_Done_Library");

        //TODO figure out the method signature for debug_hook. (FT_DebugHook_Func)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Set_Debug_Hook_(IntPtr library, uint hook_index, IntPtr debug_hook);
        public static FT_Set_Debug_Hook_ FT_Set_Debug_Hook = LoadFunction<FT_Set_Debug_Hook_>("FT_Set_Debug_Hook");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FT_Add_Default_Modules_(IntPtr library);
        public static FT_Add_Default_Modules_ FT_Add_Default_Modules = LoadFunction<FT_Add_Default_Modules_>("FT_Add_Default_Modules");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr FT_Get_Renderer_(IntPtr library, FT_Glyph_Format format);
        public static FT_Get_Renderer_ FT_Get_Renderer = LoadFunction<FT_Get_Renderer_>("FT_Get_Renderer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Set_Renderer_(IntPtr library, IntPtr renderer, uint num_params, IntPtr parameters);
        public static FT_Set_Renderer_ FT_Set_Renderer = LoadFunction<FT_Set_Renderer_>("FT_Set_Renderer");

        #endregion

        #region GZIP Streams

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stream_OpenGzip_(IntPtr stream, IntPtr source);
        public static FT_Stream_OpenGzip_ FT_Stream_OpenGzip = LoadFunction<FT_Stream_OpenGzip_>("FT_Stream_OpenGzip");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Gzip_Uncompress_(IntPtr memory, IntPtr output, ref IntPtr output_len, IntPtr input, IntPtr input_len);
        public static FT_Gzip_Uncompress_ FT_Gzip_Uncompress = LoadFunction<FT_Gzip_Uncompress_>("FT_Gzip_Uncompress");

        #endregion

        #region LZW Streams

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stream_OpenLZW_(IntPtr stream, IntPtr source);
        public static FT_Stream_OpenLZW_ FT_Stream_OpenLZW = LoadFunction<FT_Stream_OpenLZW_>("FT_Stream_OpenLZW");

        #endregion

        #region BZIP2 Streams

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Stream_OpenBzip2_(IntPtr stream, IntPtr source);
        public static FT_Stream_OpenBzip2_ FT_Stream_OpenBzip2 = LoadFunction<FT_Stream_OpenBzip2_>("FT_Stream_OpenBzip2");

        #endregion

        #region LCD Filtering

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Library_SetLcdFilter_(IntPtr library, FT_LcdFilter filter);
        public static FT_Library_SetLcdFilter_ FT_Library_SetLcdFilter = LoadFunction<FT_Library_SetLcdFilter_>("FT_Library_SetLcdFilter");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error FT_Library_SetLcdFilterWeights_(IntPtr library, byte[] weights);
        public static FT_Library_SetLcdFilterWeights_ FT_Library_SetLcdFilterWeights = LoadFunction<FT_Library_SetLcdFilterWeights_>("FT_Library_SetLcdFilterWeights");

        #endregion

        #endregion

        #region Caching Sub-system
        //TODO:
        #endregion

        #region Miscellaneous
        //TODO;
        #endregion

#endif

    }
}