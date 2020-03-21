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
        public delegate void __FT_Library_Version(IntPtr library, out int amajor, out int aminor, out int apatch);
        public static __FT_Library_Version FT_Library_Version = LoadFunction<__FT_Library_Version>("FT_Library_Version");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool __FT_Face_CheckTrueTypePatents(IntPtr face);
        public static __FT_Face_CheckTrueTypePatents FT_Face_CheckTrueTypePatents = LoadFunction<__FT_Face_CheckTrueTypePatents>("FT_Face_CheckTrueTypePatents");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool __FT_Face_SetUnpatentedHinting(IntPtr face, [MarshalAs(UnmanagedType.U1)] bool value);
        public static __FT_Face_SetUnpatentedHinting FT_Face_SetUnpatentedHinting = LoadFunction<__FT_Face_SetUnpatentedHinting>("FT_Face_SetUnpatentedHinting");

        #endregion

        #region Base Interface

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Init_FreeType(out IntPtr alibrary);
        public static __FT_Init_FreeType FT_Init_FreeType = LoadFunction<__FT_Init_FreeType>("FT_Init_FreeType");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Done_FreeType(IntPtr library);
        public static __FT_Done_FreeType FT_Done_FreeType = LoadFunction<__FT_Done_FreeType>("FT_Done_FreeType");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_New_Face(IntPtr library, string filepathname, int face_index, out IntPtr aface);
        public static __FT_New_Face FT_New_Face = LoadFunction<__FT_New_Face>("FT_New_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_New_Memory_Face(IntPtr library, IntPtr file_base, int file_size, int face_index, out IntPtr aface);
        public static __FT_New_Memory_Face FT_New_Memory_Face = LoadFunction<__FT_New_Memory_Face>("FT_New_Memory_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Open_Face(IntPtr library, IntPtr args, int face_index, out IntPtr aface);
        public static __FT_Open_Face FT_Open_Face = LoadFunction<__FT_Open_Face>("FT_Open_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_Attach_File(IntPtr face, string filepathname);
        public static __FT_Attach_File FT_Attach_File = LoadFunction<__FT_Attach_File>("FT_Attach_File");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Attach_Stream(IntPtr face, IntPtr parameters);
        public static __FT_Attach_Stream FT_Attach_Stream = LoadFunction<__FT_Attach_Stream>("FT_Attach_Stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Reference_Face(IntPtr face);
        public static __FT_Reference_Face FT_Reference_Face = LoadFunction<__FT_Reference_Face>("FT_Reference_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Done_Face(IntPtr face);
        public static __FT_Done_Face FT_Done_Face = LoadFunction<__FT_Done_Face>("FT_Done_Face");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Select_Size(IntPtr face, int strike_index);
        public static __FT_Select_Size FT_Select_Size = LoadFunction<__FT_Select_Size>("FT_Select_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Request_Size(IntPtr face, IntPtr req);
        public static __FT_Request_Size FT_Request_Size = LoadFunction<__FT_Request_Size>("FT_Request_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Set_Char_Size(IntPtr face, IntPtr char_width, IntPtr char_height, uint horz_resolution, uint vert_resolution);
        public static __FT_Set_Char_Size FT_Set_Char_Size = LoadFunction<__FT_Set_Char_Size>("FT_Set_Char_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Set_Pixel_Sizes(IntPtr face, uint pixel_width, uint pixel_height);
        public static __FT_Set_Pixel_Sizes FT_Set_Pixel_Sizes = LoadFunction<__FT_Set_Pixel_Sizes>("FT_Set_Pixel_Sizes");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Load_Glyph(IntPtr face, uint glyph_index, int load_flags);
        public static __FT_Load_Glyph FT_Load_Glyph = LoadFunction<__FT_Load_Glyph>("FT_Load_Glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Load_Char(IntPtr face, uint char_code, int load_flags);
        public static __FT_Load_Char FT_Load_Char = LoadFunction<__FT_Load_Char>("FT_Load_Char");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Set_Transform(IntPtr face, IntPtr matrix, IntPtr delta);
        public static __FT_Set_Transform FT_Set_Transform = LoadFunction<__FT_Set_Transform>("FT_Set_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Render_Glyph(IntPtr slot, FT_Render_Mode render_mode);
        public static __FT_Render_Glyph FT_Render_Glyph = LoadFunction<__FT_Render_Glyph>("FT_Render_Glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_Kerning(IntPtr face, uint left_glyph, uint right_glyph, uint kern_mode, out FT_Vector akerning);
        public static __FT_Get_Kerning FT_Get_Kerning = LoadFunction<__FT_Get_Kerning>("FT_Get_Kerning");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_Track_Kerning(IntPtr face, IntPtr point_size, int degree, out IntPtr akerning);
        public static __FT_Get_Track_Kerning FT_Get_Track_Kerning = LoadFunction<__FT_Get_Track_Kerning>("FT_Get_Track_Kerning");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_Glyph_Name(IntPtr face, uint glyph_index, IntPtr buffer, uint buffer_max);
        public static __FT_Get_Glyph_Name FT_Get_Glyph_Name = LoadFunction<__FT_Get_Glyph_Name>("FT_Get_Glyph_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Get_Postscript_Name(IntPtr face);
        public static __FT_Get_Postscript_Name FT_Get_Postscript_Name = LoadFunction<__FT_Get_Postscript_Name>("FT_Get_Postscript_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Select_Charmap(IntPtr face, FT_Encoding encoding);
        public static __FT_Select_Charmap FT_Select_Charmap = LoadFunction<__FT_Select_Charmap>("FT_Select_Charmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Set_Charmap(IntPtr face, IntPtr charmap);
        public static __FT_Set_Charmap FT_Set_Charmap = LoadFunction<__FT_Set_Charmap>("FT_Set_Charmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __FT_Get_Charmap_Index(IntPtr charmap);
        public static __FT_Get_Charmap_Index FT_Get_Charmap_Index = LoadFunction<__FT_Get_Charmap_Index>("FT_Get_Charmap_Index");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __FT_Get_Char_Index(IntPtr face, uint charcode);
        public static __FT_Get_Char_Index FT_Get_Char_Index = LoadFunction<__FT_Get_Char_Index>("FT_Get_Char_Index");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __FT_Get_First_Char(IntPtr face, out uint agindex);
        public static __FT_Get_First_Char FT_Get_First_Char = LoadFunction<__FT_Get_First_Char>("FT_Get_First_Char");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __FT_Get_Next_Char(IntPtr face, uint char_code, out uint agindex);
        public static __FT_Get_Next_Char FT_Get_Next_Char = LoadFunction<__FT_Get_Next_Char>("FT_Get_Next_Char");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __FT_Get_Name_Index(IntPtr face, IntPtr glyph_name);
        public static __FT_Get_Name_Index FT_Get_Name_Index = LoadFunction<__FT_Get_Name_Index>("FT_Get_Name_Index");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_SubGlyph_Info(IntPtr glyph, uint sub_index, out int p_index, out uint p_flags, out int p_arg1, out int p_arg2, out FT_Matrix p_transform);
        public static __FT_Get_SubGlyph_Info FT_Get_SubGlyph_Info = LoadFunction<__FT_Get_SubGlyph_Info>("FT_Get_SubGlyph_Info");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ushort __FT_Get_FSType_Flags(IntPtr face);
        public static __FT_Get_FSType_Flags FT_Get_FSType_Flags = LoadFunction<__FT_Get_FSType_Flags>("FT_Get_FSType_Flags");

        #endregion

        #region Glyph Variants

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __FT_Face_GetCharVariantIndex(IntPtr face, uint charcode, uint variantSelector);
        public static __FT_Face_GetCharVariantIndex FT_Face_GetCharVariantIndex = LoadFunction<__FT_Face_GetCharVariantIndex>("FT_Face_GetCharVariantIndex");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __FT_Face_GetCharVariantIsDefault(IntPtr face, uint charcode, uint variantSelector);
        public static __FT_Face_GetCharVariantIsDefault FT_Face_GetCharVariantIsDefault = LoadFunction<__FT_Face_GetCharVariantIsDefault>("FT_Face_GetCharVariantIsDefault");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Face_GetVariantSelectors(IntPtr face);
        public static __FT_Face_GetVariantSelectors FT_Face_GetVariantSelectors = LoadFunction<__FT_Face_GetVariantSelectors>("FT_Face_GetVariantSelectors");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Face_GetVariantsOfChar(IntPtr face, uint charcode);
        public static __FT_Face_GetVariantsOfChar FT_Face_GetVariantsOfChar = LoadFunction<__FT_Face_GetVariantsOfChar>("FT_Face_GetVariantsOfChar");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Face_GetCharsOfVariant(IntPtr face, uint variantSelector);
        public static __FT_Face_GetCharsOfVariant FT_Face_GetCharsOfVariant = LoadFunction<__FT_Face_GetCharsOfVariant>("FT_Face_GetCharsOfVariant");

        #endregion

        #region Glyph Management

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_Glyph(IntPtr slot, out IntPtr aglyph);
        public static __FT_Get_Glyph FT_Get_Glyph = LoadFunction<__FT_Get_Glyph>("FT_Get_Glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Glyph_Copy(IntPtr source, out IntPtr target);
        public static __FT_Glyph_Copy FT_Glyph_Copy = LoadFunction<__FT_Glyph_Copy>("FT_Glyph_Copy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Glyph_Transform(IntPtr glyph, ref FT_Matrix matrix, ref FT_Vector delta);
        public static __FT_Glyph_Transform FT_Glyph_Transform = LoadFunction<__FT_Glyph_Transform>("FT_Glyph_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Glyph_Get_CBox(IntPtr glyph, FT_Glyph_BBox_Mode bbox_mode, out FT_BBox acbox);
        public static __FT_Glyph_Get_CBox FT_Glyph_Get_CBox = LoadFunction<__FT_Glyph_Get_CBox>("FT_Glyph_Get_CBox");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Glyph_To_Bitmap(ref IntPtr the_glyph, FT_Render_Mode render_mode, ref FT_Vector origin, [MarshalAs(UnmanagedType.U1)] bool destroy);
        public static __FT_Glyph_To_Bitmap FT_Glyph_To_Bitmap = LoadFunction<__FT_Glyph_To_Bitmap>("FT_Glyph_To_Bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Done_Glyph(IntPtr glyph);
        public static __FT_Done_Glyph FT_Done_Glyph = LoadFunction<__FT_Done_Glyph>("FT_Done_Glyph");

        #endregion

        #region Mac Specific Interface - check for macOS before calling these methods.

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_New_Face_From_FOND(IntPtr library, IntPtr fond, int face_index, out IntPtr aface);
        public static __FT_New_Face_From_FOND FT_New_Face_From_FOND = LoadFunction<__FT_New_Face_From_FOND>("FT_New_Face_From_FOND");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_GetFile_From_Mac_Name(string fontName, out IntPtr pathSpec, out int face_index);
        public static __FT_GetFile_From_Mac_Name FT_GetFile_From_Mac_Name = LoadFunction<__FT_GetFile_From_Mac_Name>("FT_GetFile_From_Mac_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_GetFile_From_Mac_ATS_Name(string fontName, out IntPtr pathSpec, out int face_index);
        public static __FT_GetFile_From_Mac_ATS_Name FT_GetFile_From_Mac_ATS_Name = LoadFunction<__FT_GetFile_From_Mac_ATS_Name>("FT_GetFile_From_Mac_ATS_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_GetFilePath_From_Mac_ATS_Name(string fontName, IntPtr path, int maxPathSize, out int face_index);
        public static __FT_GetFilePath_From_Mac_ATS_Name FT_GetFilePath_From_Mac_ATS_Name = LoadFunction<__FT_GetFilePath_From_Mac_ATS_Name>("FT_GetFilePath_From_Mac_ATS_Name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_New_Face_From_FSSpec(IntPtr library, IntPtr spec, int face_index, out IntPtr aface);
        public static __FT_New_Face_From_FSSpec FT_New_Face_From_FSSpec = LoadFunction<__FT_New_Face_From_FSSpec>("FT_New_Face_From_FSSpec");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_New_Face_From_FSRef(IntPtr library, IntPtr @ref, int face_index, out IntPtr aface);
        public static __FT_New_Face_From_FSRef FT_New_Face_From_FSRef = LoadFunction<__FT_New_Face_From_FSRef>("FT_New_Face_From_FSRef");

        #endregion

        #region Size Management

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_New_Size(IntPtr face, out IntPtr size);
        public static __FT_New_Size FT_New_Size = LoadFunction<__FT_New_Size>("FT_New_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Done_Size(IntPtr size);
        public static __FT_Done_Size FT_Done_Size = LoadFunction<__FT_Done_Size>("FT_Done_Size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Activate_Size(IntPtr size);
        public static __FT_Activate_Size FT_Activate_Size = LoadFunction<__FT_Activate_Size>("FT_Activate_Size");

        #endregion

        #endregion

        #region Support API

        #region Computations

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_MulDiv(IntPtr a, IntPtr b, IntPtr c);
        public static __FT_MulDiv FT_MulDiv = LoadFunction<__FT_MulDiv>("FT_MulDiv");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_MulFix(IntPtr a, IntPtr b);
        public static __FT_MulFix FT_MulFix = LoadFunction<__FT_MulFix>("FT_MulFix");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_DivFix(IntPtr a, IntPtr b);
        public static __FT_DivFix FT_DivFix = LoadFunction<__FT_DivFix>("FT_DivFix");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_RoundFix(IntPtr a);
        public static __FT_RoundFix FT_RoundFix = LoadFunction<__FT_RoundFix>("FT_RoundFix");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_CeilFix(IntPtr a);
        public static __FT_CeilFix FT_CeilFix = LoadFunction<__FT_CeilFix>("FT_CeilFix");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_FloorFix(IntPtr a);
        public static __FT_FloorFix FT_FloorFix = LoadFunction<__FT_FloorFix>("FT_FloorFix");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Vector_Transform(ref FT_Vector vec, ref FT_Matrix matrix);
        public static __FT_Vector_Transform FT_Vector_Transform = LoadFunction<__FT_Vector_Transform>("FT_Vector_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Matrix_Multiply(ref FT_Matrix a, ref FT_Matrix b);
        public static __FT_Matrix_Multiply FT_Matrix_Multiply = LoadFunction<__FT_Matrix_Multiply>("FT_Matrix_Multiply");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Matrix_Invert(ref FT_Matrix matrix);
        public static __FT_Matrix_Invert FT_Matrix_Invert = LoadFunction<__FT_Matrix_Invert>("FT_Matrix_Invert");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Sin(IntPtr angle);
        public static __FT_Sin FT_Sin = LoadFunction<__FT_Sin>("FT_Sin");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Cos(IntPtr angle);
        public static __FT_Cos FT_Cos = LoadFunction<__FT_Cos>("FT_Cos");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Tan(IntPtr angle);
        public static __FT_Tan FT_Tan = LoadFunction<__FT_Tan>("FT_Tan");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Atan2(IntPtr x, IntPtr y);
        public static __FT_Atan2 FT_Atan2 = LoadFunction<__FT_Atan2>("FT_Atan2");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Angle_Diff(IntPtr angle1, IntPtr angle2);
        public static __FT_Angle_Diff FT_Angle_Diff = LoadFunction<__FT_Angle_Diff>("FT_Angle_Diff");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Vector_Unit(out FT_Vector vec, IntPtr angle);
        public static __FT_Vector_Unit FT_Vector_Unit = LoadFunction<__FT_Vector_Unit>("FT_Vector_Unit");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Vector_Rotate(ref FT_Vector vec, IntPtr angle);
        public static __FT_Vector_Rotate FT_Vector_Rotate = LoadFunction<__FT_Vector_Rotate>("FT_Vector_Rotate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Vector_Length(ref FT_Vector vec);
        public static __FT_Vector_Length FT_Vector_Length = LoadFunction<__FT_Vector_Length>("FT_Vector_Length");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Vector_Polarize(ref FT_Vector vec, out IntPtr length, out IntPtr angle);
        public static __FT_Vector_Polarize FT_Vector_Polarize = LoadFunction<__FT_Vector_Polarize>("FT_Vector_Polarize");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Vector_From_Polar(out FT_Vector vec, IntPtr length, IntPtr angle);
        public static __FT_Vector_From_Polar FT_Vector_From_Polar = LoadFunction<__FT_Vector_From_Polar>("FT_Vector_From_Polar");
        #endregion

        #region List Processing

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_List_Find(IntPtr list, IntPtr data);
        public static __FT_List_Find FT_List_Find = LoadFunction<__FT_List_Find>("FT_List_Find");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_List_Add(IntPtr list, IntPtr node);
        public static __FT_List_Add FT_List_Add = LoadFunction<__FT_List_Add>("FT_List_Add");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_List_Insert(IntPtr list, IntPtr node);
        public static __FT_List_Insert FT_List_Insert = LoadFunction<__FT_List_Insert>("FT_List_Insert");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_List_Remove(IntPtr list, IntPtr node);
        public static __FT_List_Remove FT_List_Remove = LoadFunction<__FT_List_Remove>("FT_List_Remove");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_List_Up(IntPtr list, IntPtr node);
        public static __FT_List_Up FT_List_Up = LoadFunction<__FT_List_Up>("FT_List_Up");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_List_Iterate(IntPtr list, FT_List_Iterator iterator, IntPtr user);
        public static __FT_List_Iterate FT_List_Iterate = LoadFunction<__FT_List_Iterate>("FT_List_Iterate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_List_Finalize(IntPtr list, FT_List_Destructor destroy, IntPtr memory, IntPtr user);
        public static __FT_List_Finalize FT_List_Finalize = LoadFunction<__FT_List_Finalize>("FT_List_Finalize");

        #endregion

        #region Outline Processing

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_New(IntPtr library, uint numPoints, int numContours, out IntPtr anoutline);
        public static __FT_Outline_New FT_Outline_New = LoadFunction<__FT_Outline_New>("FT_Outline_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_New_Internal(IntPtr memory, uint numPoints, int numContours, out IntPtr anoutline);
        public static __FT_Outline_New_Internal FT_Outline_New_Internal = LoadFunction<__FT_Outline_New_Internal>("FT_Outline_New_Internal");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Done(IntPtr library, IntPtr outline);
        public static __FT_Outline_Done FT_Outline_Done = LoadFunction<__FT_Outline_Done>("FT_Outline_Done");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Done_Internal(IntPtr memory, IntPtr outline);
        public static __FT_Outline_Done_Internal FT_Outline_Done_Internal = LoadFunction<__FT_Outline_Done_Internal>("FT_Outline_Done_Internal");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Copy(IntPtr source, ref IntPtr target);
        public static __FT_Outline_Copy FT_Outline_Copy = LoadFunction<__FT_Outline_Copy>("FT_Outline_Copy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Outline_Translate(IntPtr outline, int xOffset, int yOffset);
        public static __FT_Outline_Translate FT_Outline_Translate = LoadFunction<__FT_Outline_Translate>("FT_Outline_Translate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Outline_Transform(IntPtr outline, ref FT_Matrix matrix);
        public static __FT_Outline_Transform FT_Outline_Transform = LoadFunction<__FT_Outline_Transform>("FT_Outline_Transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Embolden(IntPtr outline, IntPtr strength);
        public static __FT_Outline_Embolden FT_Outline_Embolden = LoadFunction<__FT_Outline_Embolden>("FT_Outline_Embolden");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_EmboldenXY(IntPtr outline, int xstrength, int ystrength);
        public static __FT_Outline_EmboldenXY FT_Outline_EmboldenXY = LoadFunction<__FT_Outline_EmboldenXY>("FT_Outline_EmboldenXY");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Outline_Reverse(IntPtr outline);
        public static __FT_Outline_Reverse FT_Outline_Reverse = LoadFunction<__FT_Outline_Reverse>("FT_Outline_Reverse");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Check(IntPtr outline);
        public static __FT_Outline_Check FT_Outline_Check = LoadFunction<__FT_Outline_Check>("FT_Outline_Check");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Get_BBox(IntPtr outline, out FT_BBox abbox);
        public static __FT_Outline_Get_BBox FT_Outline_Get_BBox = LoadFunction<__FT_Outline_Get_BBox>("FT_Outline_Get_BBox");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Decompose(IntPtr outline, ref FT_Outline_Funcs func_interface, IntPtr user);
        public static __FT_Outline_Decompose FT_Outline_Decompose = LoadFunction<__FT_Outline_Decompose>("FT_Outline_Decompose");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Outline_Get_CBox(IntPtr outline, out FT_BBox acbox);
        public static __FT_Outline_Get_CBox FT_Outline_Get_CBox = LoadFunction<__FT_Outline_Get_CBox>("FT_Outline_Get_CBox");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Get_Bitmap(IntPtr library, IntPtr outline, IntPtr abitmap);
        public static __FT_Outline_Get_Bitmap FT_Outline_Get_Bitmap = LoadFunction<__FT_Outline_Get_Bitmap>("FT_Outline_Get_Bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Outline_Render(IntPtr library, IntPtr outline, IntPtr @params);
        public static __FT_Outline_Render FT_Outline_Render = LoadFunction<__FT_Outline_Render>("FT_Outline_Render");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Orientation __FT_Outline_Get_Orientation(IntPtr outline);
        public static __FT_Outline_Get_Orientation FT_Outline_Get_Orientation = LoadFunction<__FT_Outline_Get_Orientation>("FT_Outline_Get_Orientation");

        #endregion

        #region Quick retrieval of advance values

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_Advance(IntPtr face, uint gIndex, uint load_flags, out IntPtr padvance);
        public static __FT_Get_Advance FT_Get_Advance = LoadFunction<__FT_Get_Advance>("FT_Get_Advance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Get_Advances(IntPtr face, uint start, uint count, uint load_flags, out IntPtr padvance);
        public static __FT_Get_Advances FT_Get_Advances = LoadFunction<__FT_Get_Advances>("FT_Get_Advances");

        #endregion

        #region Bitmap Handling

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Bitmap_New(IntPtr abitmap);
        public static __FT_Bitmap_New FT_Bitmap_New = LoadFunction<__FT_Bitmap_New>("FT_Bitmap_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Bitmap_Copy(IntPtr library, IntPtr source, IntPtr target);
        public static __FT_Bitmap_Copy FT_Bitmap_Copy = LoadFunction<__FT_Bitmap_Copy>("FT_Bitmap_Copy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Bitmap_Embolden(IntPtr library, IntPtr bitmap, IntPtr xStrength, IntPtr yStrength);
        public static __FT_Bitmap_Embolden FT_Bitmap_Embolden = LoadFunction<__FT_Bitmap_Embolden>("FT_Bitmap_Embolden");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Bitmap_Convert(IntPtr library, IntPtr source, IntPtr target, int alignment);
        public static __FT_Bitmap_Convert FT_Bitmap_Convert = LoadFunction<__FT_Bitmap_Convert>("FT_Bitmap_Convert");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_GlyphSlot_Own_Bitmap(IntPtr slot);
        public static __FT_GlyphSlot_Own_Bitmap FT_GlyphSlot_Own_Bitmap = LoadFunction<__FT_GlyphSlot_Own_Bitmap>("FT_GlyphSlot_Own_Bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Bitmap_Done(IntPtr library, IntPtr bitmap);
        public static __FT_Bitmap_Done FT_Bitmap_Done = LoadFunction<__FT_Bitmap_Done>("FT_Bitmap_Done");

        #endregion

        #region Glyph Stroker

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_StrokerBorder __FT_Outline_GetInsideBorder(IntPtr outline);
        public static __FT_Outline_GetInsideBorder FT_Outline_GetInsideBorder = LoadFunction<__FT_Outline_GetInsideBorder>("FT_Outline_GetInsideBorder");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_StrokerBorder __FT_Outline_GetOutsideBorder(IntPtr outline);
        public static __FT_Outline_GetOutsideBorder FT_Outline_GetOutsideBorder = LoadFunction<__FT_Outline_GetOutsideBorder>("FT_Outline_GetOutsideBorder");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_New(IntPtr library, out IntPtr astroker);
        public static __FT_Stroker_New FT_Stroker_New = LoadFunction<__FT_Stroker_New>("FT_Stroker_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Stroker_Set(IntPtr stroker, int radius, FT_Stroker_LineCap line_cap, FT_Stroker_LineJoin line_join, IntPtr miter_limit);
        public static __FT_Stroker_Set FT_Stroker_Set = LoadFunction<__FT_Stroker_Set>("FT_Stroker_Set");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Stroker_Rewind(IntPtr stroker);
        public static __FT_Stroker_Rewind FT_Stroker_Rewind = LoadFunction<__FT_Stroker_Rewind>("FT_Stroker_Rewind");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_ParseOutline(IntPtr stroker, IntPtr outline, [MarshalAs(UnmanagedType.U1)] bool opened);
        public static __FT_Stroker_ParseOutline FT_Stroker_ParseOutline = LoadFunction<__FT_Stroker_ParseOutline>("FT_Stroker_ParseOutline");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_BeginSubPath(IntPtr stroker, ref FT_Vector to, [MarshalAs(UnmanagedType.U1)] bool open);
        public static __FT_Stroker_BeginSubPath FT_Stroker_BeginSubPath = LoadFunction<__FT_Stroker_BeginSubPath>("FT_Stroker_BeginSubPath");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_EndSubPath(IntPtr stroker);
        public static __FT_Stroker_EndSubPath FT_Stroker_EndSubPath = LoadFunction<__FT_Stroker_EndSubPath>("FT_Stroker_EndSubPath");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_LineTo(IntPtr stroker, ref FT_Vector to);
        public static __FT_Stroker_LineTo FT_Stroker_LineTo = LoadFunction<__FT_Stroker_LineTo>("FT_Stroker_LineTo");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_ConicTo(IntPtr stroker, ref FT_Vector control, ref FT_Vector to);
        public static __FT_Stroker_ConicTo FT_Stroker_ConicTo = LoadFunction<__FT_Stroker_ConicTo>("FT_Stroker_ConicTo");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_CubicTo(IntPtr stroker, ref FT_Vector control1, ref FT_Vector control2, ref FT_Vector to);
        public static __FT_Stroker_CubicTo FT_Stroker_CubicTo = LoadFunction<__FT_Stroker_CubicTo>("FT_Stroker_CubicTo");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_GetBorderCounts(IntPtr stroker, FT_StrokerBorder border, out uint anum_points, out uint anum_contours);
        public static __FT_Stroker_GetBorderCounts FT_Stroker_GetBorderCounts = LoadFunction<__FT_Stroker_GetBorderCounts>("FT_Stroker_GetBorderCounts");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Stroker_ExportBorder(IntPtr stroker, FT_StrokerBorder border, IntPtr outline);
        public static __FT_Stroker_ExportBorder FT_Stroker_ExportBorder = LoadFunction<__FT_Stroker_ExportBorder>("FT_Stroker_ExportBorder");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stroker_GetCounts(IntPtr stroker, out uint anum_points, out uint anum_contours);
        public static __FT_Stroker_GetCounts FT_Stroker_GetCounts = LoadFunction<__FT_Stroker_GetCounts>("FT_Stroker_GetCounts");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Stroker_Export(IntPtr stroker, IntPtr outline);
        public static __FT_Stroker_Export FT_Stroker_Export = LoadFunction<__FT_Stroker_Export>("FT_Stroker_Export");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Stroker_Done(IntPtr stroker);
        public static __FT_Stroker_Done FT_Stroker_Done = LoadFunction<__FT_Stroker_Done>("FT_Stroker_Done");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Glyph_Stroke(ref IntPtr pglyph, IntPtr stoker, [MarshalAs(UnmanagedType.U1)] bool destroy);
        public static __FT_Glyph_Stroke FT_Glyph_Stroke = LoadFunction<__FT_Glyph_Stroke>("FT_Glyph_Stroke");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Glyph_StrokeBorder(ref IntPtr pglyph, IntPtr stoker, [MarshalAs(UnmanagedType.U1)] bool inside, [MarshalAs(UnmanagedType.U1)] bool destroy);
        public static __FT_Glyph_StrokeBorder FT_Glyph_StrokeBorder = LoadFunction<__FT_Glyph_StrokeBorder>("FT_Glyph_StrokeBorder");

        #endregion

        #region Module Management

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Add_Module(IntPtr library, IntPtr clazz);
        public static __FT_Add_Module FT_Add_Module = LoadFunction<__FT_Add_Module>("FT_Add_Module");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate IntPtr __FT_Get_Module(IntPtr library, string module_name);
        public static __FT_Get_Module FT_Get_Module = LoadFunction<__FT_Get_Module>("FT_Get_Module");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Remove_Module(IntPtr library, IntPtr module);
        public static __FT_Remove_Module FT_Remove_Module = LoadFunction<__FT_Remove_Module>("FT_Remove_Module");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_Property_Set(IntPtr library, string module_name, string property_name, IntPtr value);
        public static __FT_Property_Set FT_Property_Set = LoadFunction<__FT_Property_Set>("FT_Property_Set");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public delegate FT_Error __FT_Property_Get(IntPtr library, string module_name, string property_name, IntPtr value);
        public static __FT_Property_Get FT_Property_Get = LoadFunction<__FT_Property_Get>("FT_Property_Get");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Reference_Library(IntPtr library);
        public static __FT_Reference_Library FT_Reference_Library = LoadFunction<__FT_Reference_Library>("FT_Reference_Library");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_New_Library(IntPtr memory, out IntPtr alibrary);
        public static __FT_New_Library FT_New_Library = LoadFunction<__FT_New_Library>("FT_New_Library");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Done_Library(IntPtr library);
        public static __FT_Done_Library FT_Done_Library = LoadFunction<__FT_Done_Library>("FT_Done_Library");

        //TODO figure out the method signature for debug_hook. (FT_DebugHook_Func)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Set_Debug_Hook(IntPtr library, uint hook_index, IntPtr debug_hook);
        public static __FT_Set_Debug_Hook FT_Set_Debug_Hook = LoadFunction<__FT_Set_Debug_Hook>("FT_Set_Debug_Hook");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_Add_Default_Modules(IntPtr library);
        public static __FT_Add_Default_Modules FT_Add_Default_Modules = LoadFunction<__FT_Add_Default_Modules>("FT_Add_Default_Modules");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __FT_Get_Renderer(IntPtr library, FT_Glyph_Format format);
        public static __FT_Get_Renderer FT_Get_Renderer = LoadFunction<__FT_Get_Renderer>("FT_Get_Renderer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Set_Renderer(IntPtr library, IntPtr renderer, uint num_params, IntPtr parameters);
        public static __FT_Set_Renderer FT_Set_Renderer = LoadFunction<__FT_Set_Renderer>("FT_Set_Renderer");

        #endregion

        #region GZIP Streams

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stream_OpenGzip(IntPtr stream, IntPtr source);
        public static __FT_Stream_OpenGzip FT_Stream_OpenGzip = LoadFunction<__FT_Stream_OpenGzip>("FT_Stream_OpenGzip");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Gzip_Uncompress(IntPtr memory, IntPtr output, ref IntPtr output_len, IntPtr input, IntPtr input_len);
        public static __FT_Gzip_Uncompress FT_Gzip_Uncompress = LoadFunction<__FT_Gzip_Uncompress>("FT_Gzip_Uncompress");

        #endregion

        #region LZW Streams

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stream_OpenLZW(IntPtr stream, IntPtr source);
        public static __FT_Stream_OpenLZW FT_Stream_OpenLZW = LoadFunction<__FT_Stream_OpenLZW>("FT_Stream_OpenLZW");

        #endregion

        #region BZIP2 Streams

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Stream_OpenBzip2(IntPtr stream, IntPtr source);
        public static __FT_Stream_OpenBzip2 FT_Stream_OpenBzip2 = LoadFunction<__FT_Stream_OpenBzip2>("FT_Stream_OpenBzip2");

        #endregion

        #region LCD Filtering

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Library_SetLcdFilter(IntPtr library, FT_LcdFilter filter);
        public static __FT_Library_SetLcdFilter FT_Library_SetLcdFilter = LoadFunction<__FT_Library_SetLcdFilter>("FT_Library_SetLcdFilter");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_Library_SetLcdFilterWeights(IntPtr library, byte[] weights);
        public static __FT_Library_SetLcdFilterWeights FT_Library_SetLcdFilterWeights = LoadFunction<__FT_Library_SetLcdFilterWeights>("FT_Library_SetLcdFilterWeights");

        #endregion

        #endregion

        #region Caching Sub-system

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_Manager_New(IntPtr library, uint max_faces, uint max_sizes, ulong maxBytes, FTC_Face_Requester requester, IntPtr req_data, out IntPtr amanager);
        public static __FTC_Manager_New FTC_Manager_New = LoadFunction<__FTC_Manager_New>("FTC_Manager_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FTC_Manager_Reset(IntPtr manager);
        public static __FTC_Manager_Reset FTC_Manager_Reset = LoadFunction<__FTC_Manager_Reset>("FTC_Manager_Reset");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FTC_Manager_Done(IntPtr manager);
        public static __FTC_Manager_Done FTC_Manager_Done = LoadFunction<__FTC_Manager_Done>("FTC_Manager_Done");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_Manager_LookupFace(IntPtr manager, IntPtr face_id, out IntPtr aface);
        public static __FTC_Manager_LookupFace FTC_Manager_LookupFace = LoadFunction<__FTC_Manager_LookupFace>("FTC_Manager_LookupFace");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_Manager_LookupSize(IntPtr manager, IntPtr scaler, out IntPtr asize);
        public static __FTC_Manager_LookupSize FTC_Manager_LookupSize = LoadFunction<__FTC_Manager_LookupSize>("FTC_Manager_LookupSize");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FTC_Node_Unref(IntPtr node, IntPtr manager);
        public static __FTC_Node_Unref FTC_Node_Unref = LoadFunction<__FTC_Node_Unref>("FTC_Node_Unref");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FTC_Manager_RemoveFaceID(IntPtr manager, IntPtr face_id);
        public static __FTC_Manager_RemoveFaceID FTC_Manager_RemoveFaceID = LoadFunction<__FTC_Manager_RemoveFaceID>("FTC_Manager_RemoveFaceID");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_CMapCache_New(IntPtr manager, out IntPtr acache);
        public static __FTC_CMapCache_New FTC_CMapCache_New = LoadFunction<__FTC_CMapCache_New>("FTC_CMapCache_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __FTC_CMapCache_Lookup(IntPtr cache, IntPtr face_id, int cmap_index, uint char_code);
        public static __FTC_CMapCache_Lookup FTC_CMapCache_Lookup = LoadFunction<__FTC_CMapCache_Lookup>("FTC_CMapCache_Lookup");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_ImageCache_New(IntPtr manager, out IntPtr acache);
        public static __FTC_ImageCache_New FTC_ImageCache_New = LoadFunction<__FTC_ImageCache_New>("FTC_ImageCache_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_ImageCache_Lookup(IntPtr cache, IntPtr type, uint gindex, out IntPtr aglyph, out IntPtr anode);
        public static __FTC_ImageCache_Lookup FTC_ImageCache_Lookup = LoadFunction<__FTC_ImageCache_Lookup>("FTC_ImageCache_Lookup");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_ImageCache_LookupScaler(IntPtr cache, IntPtr scaler, uint load_flags, uint gindex, out IntPtr aglyph, out IntPtr anode);
        public static __FTC_ImageCache_LookupScaler FTC_ImageCache_LookupScaler = LoadFunction<__FTC_ImageCache_LookupScaler>("FTC_ImageCache_LookupScaler");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_SBitCache_New(IntPtr manager, out IntPtr acache);
        public static __FTC_SBitCache_New FTC_SBitCache_New = LoadFunction<__FTC_SBitCache_New>("FTC_SBitCache_New");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_SBitCache_Lookup(IntPtr cache, IntPtr type, uint gindex, out IntPtr sbit, out IntPtr anode);
        public static __FTC_SBitCache_Lookup FTC_SBitCache_Lookup = LoadFunction<__FTC_SBitCache_Lookup>("FTC_SBitCache_Lookup");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FTC_SBitCache_LookupScaler(IntPtr cache, IntPtr scaler, uint load_flags, uint gindex, out IntPtr sbit, out IntPtr anode);
        public static __FTC_SBitCache_LookupScaler FTC_SBitCache_LookupScaler = LoadFunction<__FTC_SBitCache_LookupScaler>("FTC_SBitCache_LookupScaler");

        #endregion

        #region Miscellaneous

        #region OpenType Validation

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_OpenType_Validate(IntPtr face, uint validation_flags, out IntPtr base_table, out IntPtr gdef_table, out IntPtr gpos_table, out IntPtr gsub_table, out IntPtr jsft_table);
        public static __FT_OpenType_Validate FT_OpenType_Validate = LoadFunction<__FT_OpenType_Validate>("FT_OpenType_Validate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __FT_OpenType_Free(IntPtr face, IntPtr table);
        public static __FT_OpenType_Free FT_OpenType_Free = LoadFunction<__FT_OpenType_Free>("FT_OpenType_Free");

        #endregion

        #region The TrueType Engine

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_TrueTypeEngineType __FT_Get_TrueType_Engine_Type(IntPtr library);
        public static __FT_Get_TrueType_Engine_Type FT_Get_TrueType_Engine_Type = LoadFunction<__FT_Get_TrueType_Engine_Type>("FT_Get_TrueType_Engine_Type");

        #endregion

        #region TrueTypeGX/AAT Validation

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_TrueTypeGX_Validate(IntPtr face, uint validation_flags, ref byte[] tables, uint tableLength);
        public static __FT_TrueTypeGX_Validate FT_TrueTypeGX_Validate = LoadFunction<__FT_TrueTypeGX_Validate>("FT_TrueTypeGX_Validate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_TrueTypeGX_Free(IntPtr face, IntPtr table);
        public static __FT_TrueTypeGX_Free FT_TrueTypeGX_Free = LoadFunction<__FT_TrueTypeGX_Free>("FT_TrueTypeGX_Free");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_ClassicKern_Validate(IntPtr face, uint validation_flags, out IntPtr ckern_table);
        public static __FT_ClassicKern_Validate FT_ClassicKern_Validate = LoadFunction<__FT_ClassicKern_Validate>("FT_ClassicKern_Validate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate FT_Error __FT_ClassicKern_Free(IntPtr face, IntPtr table);
        public static __FT_ClassicKern_Free FT_ClassicKern_Free = LoadFunction<__FT_ClassicKern_Free>("FT_ClassicKern_Free");

        #endregion

        #endregion

#endif

    }
}