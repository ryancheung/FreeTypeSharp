namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    public unsafe static partial class FT
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Init_FreeType(FT_LibraryRec_** alibrary);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_FreeType(FT_LibraryRec_* library);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Face(FT_LibraryRec_* library, byte* filepathname, IntPtr face_index, FT_FaceRec_** aface);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Memory_Face(FT_LibraryRec_* library, byte* file_base, IntPtr file_size, IntPtr face_index, FT_FaceRec_** aface);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Open_Face(FT_LibraryRec_* library, FT_Open_Args_* args, IntPtr face_index, FT_FaceRec_** aface);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Attach_File(FT_FaceRec_* face, byte* filepathname);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Attach_Stream(FT_FaceRec_* face, FT_Open_Args_* parameters);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Reference_Face(FT_FaceRec_* face);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Face(FT_FaceRec_* face);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Select_Size(FT_FaceRec_* face, int strike_index);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Request_Size(FT_FaceRec_* face, FT_Size_RequestRec_* req);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Char_Size(FT_FaceRec_* face, IntPtr char_width, IntPtr char_height, uint horz_resolution, uint vert_resolution);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Pixel_Sizes(FT_FaceRec_* face, uint pixel_width, uint pixel_height);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Load_Glyph(FT_FaceRec_* face, uint glyph_index, FT_LOAD load_flags);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Load_Char(FT_FaceRec_* face, UIntPtr char_code, FT_LOAD load_flags);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Get_Transform(FT_FaceRec_* face, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Render_Glyph(FT_GlyphSlotRec_* slot, FT_Render_Mode_ render_mode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Kerning(FT_FaceRec_* face, uint left_glyph, uint right_glyph, FT_Kerning_Mode_ kern_mode, FT_Vector_* akerning);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Track_Kerning(FT_FaceRec_* face, IntPtr point_size, int degree, IntPtr* akerning);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Select_Charmap(FT_FaceRec_* face, FT_Encoding_ encoding);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Charmap(FT_FaceRec_* face, FT_CharMapRec_* charmap);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Get_Charmap_Index(FT_CharMapRec_* charmap);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Char_Index(FT_FaceRec_* face, UIntPtr charcode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr FT_Get_First_Char(FT_FaceRec_* face, uint* agindex);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr FT_Get_Next_Char(FT_FaceRec_* face, UIntPtr char_code, uint* agindex);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Face_Properties(FT_FaceRec_* face, uint num_properties, FT_Parameter_* properties);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Name_Index(FT_FaceRec_* face, byte* glyph_name);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Glyph_Name(FT_FaceRec_* face, uint glyph_index, void* buffer, uint buffer_max);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* FT_Get_Postscript_Name(FT_FaceRec_* face);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_SubGlyph_Info(FT_GlyphSlotRec_* glyph, uint sub_index, int* p_index, uint* p_flags, int* p_arg1, int* p_arg2, FT_Matrix_* p_transform);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort FT_Get_FSType_Flags(FT_FaceRec_* face);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Face_GetCharVariantIndex(FT_FaceRec_* face, UIntPtr charcode, UIntPtr variantSelector);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Face_GetCharVariantIsDefault(FT_FaceRec_* face, UIntPtr charcode, UIntPtr variantSelector);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* FT_Face_GetVariantSelectors(FT_FaceRec_* face);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* FT_Face_GetVariantsOfChar(FT_FaceRec_* face, UIntPtr charcode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* FT_Face_GetCharsOfVariant(FT_FaceRec_* face, UIntPtr variantSelector);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_MulDiv(IntPtr a, IntPtr b, IntPtr c);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_MulFix(IntPtr a, IntPtr b);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_DivFix(IntPtr a, IntPtr b);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_RoundFix(IntPtr a);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_CeilFix(IntPtr a);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_FloorFix(IntPtr a);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Transform(FT_Vector_* vector, FT_Matrix_* matrix);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Library_Version(FT_LibraryRec_* library, int* amajor, int* aminor, int* apatch);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Face_CheckTrueTypePatents(FT_FaceRec_* face);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Face_SetUnpatentedHinting(FT_FaceRec_* face, byte value);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* FT_Error_String(FT_Error error_code);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Decompose(FT_Outline_* outline, FT_Outline_Funcs_* func_interface, void* user);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_New(FT_LibraryRec_* library, uint numPoints, int numContours, FT_Outline_* anoutline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Done(FT_LibraryRec_* library, FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Check(FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Get_CBox(FT_Outline_* outline, FT_BBox_* acbox);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Translate(FT_Outline_* outline, IntPtr xOffset, IntPtr yOffset);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Copy(FT_Outline_* source, FT_Outline_* target);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Transform(FT_Outline_* outline, FT_Matrix_* matrix);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Embolden(FT_Outline_* outline, IntPtr strength);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_EmboldenXY(FT_Outline_* outline, IntPtr xstrength, IntPtr ystrength);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Reverse(FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Get_Bitmap(FT_LibraryRec_* library, FT_Outline_* outline, FT_Bitmap_* abitmap);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Render(FT_LibraryRec_* library, FT_Outline_* outline, FT_Raster_Params_* @params);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Orientation_ FT_Outline_Get_Orientation(FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Size(FT_FaceRec_* face, FT_SizeRec_** size);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Size(FT_SizeRec_* size);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Activate_Size(FT_SizeRec_* size);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Add_Module(FT_LibraryRec_* library, FT_Module_Class_* clazz);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_ModuleRec_* FT_Get_Module(FT_LibraryRec_* library, byte* module_name);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Remove_Module(FT_LibraryRec_* library, FT_ModuleRec_* module);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Property_Set(FT_LibraryRec_* library, byte* module_name, byte* property_name, void* value);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Property_Get(FT_LibraryRec_* library, byte* module_name, byte* property_name, void* value);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Default_Properties(FT_LibraryRec_* library);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Reference_Library(FT_LibraryRec_* library);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Library(FT_MemoryRec_* memory, FT_LibraryRec_** alibrary);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Library(FT_LibraryRec_* library);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Debug_Hook(FT_LibraryRec_* library, uint hook_index, void* debug_hook);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Add_Default_Modules(FT_LibraryRec_* library);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_TrueTypeEngineType_ FT_Get_TrueType_Engine_Type(FT_LibraryRec_* library);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Glyph(FT_LibraryRec_* library, FT_Glyph_Format_ format, FT_GlyphRec_** aglyph);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Glyph(FT_GlyphSlotRec_* slot, FT_GlyphRec_** aglyph);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_Copy(FT_GlyphRec_* source, FT_GlyphRec_** target);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_Transform(FT_GlyphRec_* glyph, FT_Matrix_* matrix, FT_Vector_* delta);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Glyph_Get_CBox(FT_GlyphRec_* glyph, uint bbox_mode, FT_BBox_* acbox);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_To_Bitmap(FT_GlyphRec_** the_glyph, FT_Render_Mode_ render_mode, FT_Vector_* origin, byte destroy);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Done_Glyph(FT_GlyphRec_* glyph);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Matrix_Multiply(FT_Matrix_* a, FT_Matrix_* b);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Matrix_Invert(FT_Matrix_* matrix);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_RendererRec_* FT_Get_Renderer(FT_LibraryRec_* library, FT_Glyph_Format_ format);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Renderer(FT_LibraryRec_* library, FT_RendererRec_* renderer, uint num_params, FT_Parameter_* parameters);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Palette_Data_Get(FT_FaceRec_* face, FT_Palette_Data_* apalette);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Palette_Select(FT_FaceRec_* face, ushort palette_index, FT_Color_** apalette);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Palette_Set_Foreground_Color(FT_FaceRec_* face, FT_Color_ foreground_color);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Get_Color_Glyph_Layer(FT_FaceRec_* face, uint base_glyph, uint* aglyph_index, uint* acolor_index, FT_LayerIterator_* iterator);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Get_Color_Glyph_Paint(FT_FaceRec_* face, uint base_glyph, FT_Color_Root_Transform_ root_transform, FT_Opaque_Paint_* paint);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Get_Color_Glyph_ClipBox(FT_FaceRec_* face, uint base_glyph, FT_ClipBox_* clip_box);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Get_Paint_Layers(FT_FaceRec_* face, FT_LayerIterator_* iterator, FT_Opaque_Paint_* paint);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Get_Colorline_Stops(FT_FaceRec_* face, FT_ColorStop_* color_stop, FT_ColorStopIterator_* iterator);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte FT_Get_Paint(FT_FaceRec_* face, FT_Opaque_Paint_ opaque_paint, FT_COLR_Paint_* paint);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Bitmap_Init(FT_Bitmap_* abitmap);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Bitmap_New(FT_Bitmap_* abitmap);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Copy(FT_LibraryRec_* library, FT_Bitmap_* source, FT_Bitmap_* target);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Embolden(FT_LibraryRec_* library, FT_Bitmap_* bitmap, IntPtr xStrength, IntPtr yStrength);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Convert(FT_LibraryRec_* library, FT_Bitmap_* source, FT_Bitmap_* target, int alignment);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Blend(FT_LibraryRec_* library, FT_Bitmap_* source, FT_Vector_ source_offset, FT_Bitmap_* target, FT_Vector_* atarget_offset, FT_Color_ color);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_GlyphSlot_Own_Bitmap(FT_GlyphSlotRec_* slot);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Done(FT_LibraryRec_* library, FT_Bitmap_* bitmap);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Get_BBox(FT_Outline_* outline, FT_BBox_* abbox);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Manager_Reset(FTC_ManagerRec_* manager);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Manager_Done(FTC_ManagerRec_* manager);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_Manager_LookupFace(FTC_ManagerRec_* manager, void* face_id, FT_FaceRec_** aface);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_Manager_LookupSize(FTC_ManagerRec_* manager, FTC_ScalerRec_* scaler, FT_SizeRec_** asize);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Node_Unref(FTC_NodeRec_* node, FTC_ManagerRec_* manager);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Manager_RemoveFaceID(FTC_ManagerRec_* manager, void* face_id);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_CMapCache_New(FTC_ManagerRec_* manager, FTC_CMapCacheRec_** acache);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FTC_CMapCache_Lookup(FTC_CMapCacheRec_* cache, void* face_id, int cmap_index, uint char_code);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_ImageCache_New(FTC_ManagerRec_* manager, FTC_ImageCacheRec_** acache);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_ImageCache_Lookup(FTC_ImageCacheRec_* cache, FTC_ImageTypeRec_* type, uint gindex, FT_GlyphRec_** aglyph, FTC_NodeRec_** anode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_ImageCache_LookupScaler(FTC_ImageCacheRec_* cache, FTC_ScalerRec_* scaler, FT_LOAD load_flags, uint gindex, FT_GlyphRec_** aglyph, FTC_NodeRec_** anode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_SBitCache_New(FTC_ManagerRec_* manager, FTC_SBitCacheRec_** acache);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_SBitCache_Lookup(FTC_SBitCacheRec_* cache, FTC_ImageTypeRec_* type, uint gindex, FTC_SBitRec_** sbit, FTC_NodeRec_** anode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_SBitCache_LookupScaler(FTC_SBitCacheRec_* cache, FTC_ScalerRec_* scaler, FT_LOAD load_flags, uint gindex, FTC_SBitRec_** sbit, FTC_NodeRec_** anode);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_StrokerBorder_ FT_Outline_GetInsideBorder(FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_StrokerBorder_ FT_Outline_GetOutsideBorder(FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_New(FT_LibraryRec_* library, FT_StrokerRec_** astroker);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Set(FT_StrokerRec_* stroker, IntPtr radius, FT_Stroker_LineCap_ line_cap, FT_Stroker_LineJoin_ line_join, IntPtr miter_limit);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Rewind(FT_StrokerRec_* stroker);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_ParseOutline(FT_StrokerRec_* stroker, FT_Outline_* outline, byte opened);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_BeginSubPath(FT_StrokerRec_* stroker, FT_Vector_* to, byte open);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_EndSubPath(FT_StrokerRec_* stroker);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_LineTo(FT_StrokerRec_* stroker, FT_Vector_* to);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_ConicTo(FT_StrokerRec_* stroker, FT_Vector_* control, FT_Vector_* to);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_CubicTo(FT_StrokerRec_* stroker, FT_Vector_* control1, FT_Vector_* control2, FT_Vector_* to);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_GetBorderCounts(FT_StrokerRec_* stroker, FT_StrokerBorder_ border, uint* anum_points, uint* anum_contours);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_ExportBorder(FT_StrokerRec_* stroker, FT_StrokerBorder_ border, FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_GetCounts(FT_StrokerRec_* stroker, uint* anum_points, uint* anum_contours);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Export(FT_StrokerRec_* stroker, FT_Outline_* outline);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Done(FT_StrokerRec_* stroker);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_Stroke(FT_GlyphRec_** pglyph, FT_StrokerRec_* stroker, byte destroy);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_StrokeBorder(FT_GlyphRec_** pglyph, FT_StrokerRec_* stroker, byte inside, byte destroy);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_GlyphSlot_Embolden(FT_GlyphSlotRec_* slot);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_GlyphSlot_AdjustWeight(FT_GlyphSlotRec_* slot, IntPtr xdelta, IntPtr ydelta);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_GlyphSlot_Oblique(FT_GlyphSlotRec_* slot);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_GlyphSlot_Slant(FT_GlyphSlotRec_* slot, IntPtr xslant, IntPtr yslant);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Sin(IntPtr angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Cos(IntPtr angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Tan(IntPtr angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Atan2(IntPtr x, IntPtr y);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Angle_Diff(IntPtr angle1, IntPtr angle2);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Unit(FT_Vector_* vec, IntPtr angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Rotate(FT_Vector_* vec, IntPtr angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Vector_Length(FT_Vector_* vec);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Polarize(FT_Vector_* vec, IntPtr* length, IntPtr* angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_From_Polar(FT_Vector_* vec, IntPtr length, IntPtr angle);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Get_Gasp(FT_FaceRec_* face, uint ppem);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Advance(FT_FaceRec_* face, uint gindex, FT_LOAD load_flags, IntPtr* padvance);
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Advances(FT_FaceRec_* face, uint start, uint count, FT_LOAD load_flags, IntPtr* padvances);
    }
}