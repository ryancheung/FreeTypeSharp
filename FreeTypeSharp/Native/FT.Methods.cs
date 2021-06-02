using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
#if __IOS__
    [Foundation.Preserve(AllMembers=true)]
#endif
    public static unsafe partial class FT
    {

#if __IOS__
        public const string FreeTypeLibaryName = "__Internal";
#else
        public const string FreeTypeLibaryName = "freetype";
#endif

        public static readonly string ActualLibraryName;

        static FT()
        {
            if (OperatingSystem.IsWindows())
                ActualLibraryName = "freetype.dll";
            else if (OperatingSystem.IsMacOS())
                ActualLibraryName = "libfreetype.dylib";
            else if (OperatingSystem.IsLinux())
                ActualLibraryName = "libfreetype.so";
            else if (OperatingSystem.IsAndroid())
                ActualLibraryName = "libfreetype.so";
            else if (OperatingSystem.IsIOS())
                ActualLibraryName = "libfreetype.dylib";
            else
                throw new PlatformNotSupportedException();

#if !__IOS__
            NativeLibrary.SetDllImportResolver(typeof(FT).Assembly, ImportResolver);
#endif
        }

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName != FreeTypeLibaryName) return default;

            IntPtr handle;
            var success = NativeLibrary.TryLoad(libraryName, typeof(FT).Assembly,
                DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
                out handle);

            if (success)
                return handle;

            string rootDirectory = AppContext.BaseDirectory;

            if (OperatingSystem.IsWindows())
            {
                string arch = Environment.Is64BitProcess ? "win-x64" : "win-x86";
                var searchPaths = new[]
                {
                    // This is where native libraries in our nupkg should end up
                    Path.Combine(rootDirectory, "runtimes", arch, "native", ActualLibraryName),
                    Path.Combine(rootDirectory, Environment.Is64BitProcess ? "x64" : "x86", ActualLibraryName),
                    Path.Combine(rootDirectory, ActualLibraryName)
                };

                foreach (var path in searchPaths)
                {
                    success = NativeLibrary.TryLoad(path, typeof(FT).Assembly,
                        DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
                        out handle);

                    if (success)
                        return handle;
                }

                throw new FileLoadException("Failed to load native freetype library!");
            }

            if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                string arch = OperatingSystem.IsMacOS() ? "osx" : "linux-" + (Environment.Is64BitProcess ? "x64" : "x86");

                var searchPaths = new[]
                {
                    // This is where native libraries in our nupkg should end up
                    Path.Combine(rootDirectory, "runtimes", arch, "native", ActualLibraryName),
                    // The build output folder
                    Path.Combine(rootDirectory, ActualLibraryName),
                    Path.Combine("/usr/local/lib", ActualLibraryName),
                    Path.Combine("/usr/lib", ActualLibraryName)
                };

                foreach (var path in searchPaths)
                {
                    success = NativeLibrary.TryLoad(path, typeof(FT).Assembly,
                        DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
                        out handle);

                    if (success)
                        return handle;
                }

                throw new FileLoadException("Failed to load native freetype library!");
            }

            if (OperatingSystem.IsAndroid())
            {
                success = NativeLibrary.TryLoad(ActualLibraryName, typeof(FT).Assembly,
                    DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies, 
                    out handle);

                if (success)
                    return handle;

                throw new FileLoadException("Failed to load native freetype library!");
            }

            return handle;
        }

        #region Core API

        #region FreeType Version

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Library_Version(IntPtr library, out int amajor, out int aminor, out int apatch);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FT_Face_CheckTrueTypePatents(IntPtr face);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FT_Face_SetUnpatentedHinting(IntPtr face, [MarshalAs(UnmanagedType.U1)] bool value);
        

        #endregion

        #region Base Interface

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Init_FreeType(out IntPtr alibrary);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_FreeType(IntPtr library);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern FT_Error FT_New_Face(IntPtr library, string filepathname, int face_index, out IntPtr aface);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Memory_Face(IntPtr library, IntPtr file_base, int file_size, int face_index, out IntPtr aface);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Open_Face(IntPtr library, IntPtr args, int face_index, out IntPtr aface);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern FT_Error FT_Attach_File(IntPtr face, string filepathname);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Attach_Stream(IntPtr face, IntPtr parameters);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Reference_Face(IntPtr face);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Face(IntPtr face);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Select_Size(IntPtr face, int strike_index);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Request_Size(IntPtr face, IntPtr req);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Char_Size(IntPtr face, IntPtr char_width, IntPtr char_height, uint horz_resolution, uint vert_resolution);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Pixel_Sizes(IntPtr face, uint pixel_width, uint pixel_height);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Load_Glyph(IntPtr face, uint glyph_index, int load_flags);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Load_Char(IntPtr face, uint char_code, int load_flags);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Transform(IntPtr face, IntPtr matrix, IntPtr delta);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Render_Glyph(IntPtr slot, FT_Render_Mode render_mode);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Kerning(IntPtr face, uint left_glyph, uint right_glyph, uint kern_mode, out FT_Vector akerning);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Track_Kerning(IntPtr face, IntPtr point_size, int degree, out IntPtr akerning);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Glyph_Name(IntPtr face, uint glyph_index, IntPtr buffer, uint buffer_max);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Get_Postscript_Name(IntPtr face);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Select_Charmap(IntPtr face, FT_Encoding encoding);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Charmap(IntPtr face, IntPtr charmap);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Get_Charmap_Index(IntPtr charmap);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Char_Index(IntPtr face, uint charcode);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_First_Char(IntPtr face, out uint agindex);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Next_Char(IntPtr face, uint char_code, out uint agindex);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Get_Name_Index(IntPtr face, IntPtr glyph_name);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_SubGlyph_Info(IntPtr glyph, uint sub_index, out int p_index, out uint p_flags, out int p_arg1, out int p_arg2, out FT_Matrix p_transform);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort FT_Get_FSType_Flags(IntPtr face);
        

        #endregion

        #region Glyph Variants

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FT_Face_GetCharVariantIndex(IntPtr face, uint charcode, uint variantSelector);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Face_GetCharVariantIsDefault(IntPtr face, uint charcode, uint variantSelector);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Face_GetVariantSelectors(IntPtr face);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Face_GetVariantsOfChar(IntPtr face, uint charcode);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Face_GetCharsOfVariant(IntPtr face, uint variantSelector);
        

        #endregion

        #region Glyph Management

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Glyph(IntPtr slot, out IntPtr aglyph);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_Copy(IntPtr source, out IntPtr target);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_Transform(IntPtr glyph, ref FT_Matrix matrix, ref FT_Vector delta);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Glyph_Get_CBox(IntPtr glyph, FT_Glyph_BBox_Mode bbox_mode, out FT_BBox acbox);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_To_Bitmap(ref IntPtr the_glyph, FT_Render_Mode render_mode, ref FT_Vector origin, [MarshalAs(UnmanagedType.U1)] bool destroy);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Done_Glyph(IntPtr glyph);
        

        #endregion

        #region Mac Specific Interface - check for macOS before calling these methods.

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        //public static extern FT_Error FT_New_Face_From_FOND(IntPtr library, IntPtr fond, int face_index, out IntPtr aface);
        

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        //public static extern FT_Error FT_GetFile_From_Mac_Name(string fontName, out IntPtr pathSpec, out int face_index);
        
        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        //public static extern FT_Error FT_GetFile_From_Mac_ATS_Name(string fontName, out IntPtr pathSpec, out int face_index);
        

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        //public static extern FT_Error FT_GetFilePath_From_Mac_ATS_Name(string fontName, IntPtr path, int maxPathSize, out int face_index);
        

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        //public static extern FT_Error FT_New_Face_From_FSSpec(IntPtr library, IntPtr spec, int face_index, out IntPtr aface);
        

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        //public static extern FT_Error FT_New_Face_From_FSRef(IntPtr library, IntPtr @ref, int face_index, out IntPtr aface);
        

        #endregion

        #region Size Management

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Size(IntPtr face, out IntPtr size);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Size(IntPtr size);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Activate_Size(IntPtr size);
        

        #endregion

        #endregion

        #region Support API

        #region Computations

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_MulDiv(IntPtr a, IntPtr b, IntPtr c);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_MulFix(IntPtr a, IntPtr b);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_DivFix(IntPtr a, IntPtr b);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_RoundFix(IntPtr a);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_CeilFix(IntPtr a);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_FloorFix(IntPtr a);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Transform(ref FT_Vector vec, ref FT_Matrix matrix);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Matrix_Multiply(ref FT_Matrix a, ref FT_Matrix b);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Matrix_Invert(ref FT_Matrix matrix);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Sin(IntPtr angle);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Cos(IntPtr angle);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Tan(IntPtr angle);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Atan2(IntPtr x, IntPtr y);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Angle_Diff(IntPtr angle1, IntPtr angle2);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Unit(out FT_Vector vec, IntPtr angle);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Rotate(ref FT_Vector vec, IntPtr angle);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Vector_Length(ref FT_Vector vec);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_Polarize(ref FT_Vector vec, out IntPtr length, out IntPtr angle);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Vector_From_Polar(out FT_Vector vec, IntPtr length, IntPtr angle);
        
        #endregion

        #region List Processing

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_List_Find(IntPtr list, IntPtr data);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_List_Add(IntPtr list, IntPtr node);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_List_Insert(IntPtr list, IntPtr node);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_List_Remove(IntPtr list, IntPtr node);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_List_Up(IntPtr list, IntPtr node);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_List_Iterate(IntPtr list, FT_List_Iterator iterator, IntPtr user);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_List_Finalize(IntPtr list, FT_List_Destructor destroy, IntPtr memory, IntPtr user);
        

        #endregion

        #region Outline Processing

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_New(IntPtr library, uint numPoints, int numContours, out IntPtr anoutline);
        

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        //public static extern FT_Error FT_Outline_New_Internal(IntPtr memory, uint numPoints, int numContours, out IntPtr anoutline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Done(IntPtr library, IntPtr outline);
        

        // No methods in iOS
        //[DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        //public static extern FT_Error FT_Outline_Done_Internal(IntPtr memory, IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Copy(IntPtr source, ref IntPtr target);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Translate(IntPtr outline, int xOffset, int yOffset);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Transform(IntPtr outline, ref FT_Matrix matrix);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Embolden(IntPtr outline, IntPtr strength);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_EmboldenXY(IntPtr outline, int xstrength, int ystrength);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Reverse(IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Check(IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Get_BBox(IntPtr outline, out FT_BBox abbox);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Decompose(IntPtr outline, ref FT_Outline_Funcs func_interface, IntPtr user);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Outline_Get_CBox(IntPtr outline, out FT_BBox acbox);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Get_Bitmap(IntPtr library, IntPtr outline, IntPtr abitmap);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Outline_Render(IntPtr library, IntPtr outline, IntPtr @params);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Orientation FT_Outline_Get_Orientation(IntPtr outline);
        

        #endregion

        #region Quick retrieval of advance values

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Advance(IntPtr face, uint gIndex, uint load_flags, out IntPtr padvance);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Get_Advances(IntPtr face, uint start, uint count, uint load_flags, out IntPtr padvance);
        

        #endregion

        #region Bitmap Handling

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Bitmap_New(IntPtr abitmap);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Copy(IntPtr library, IntPtr source, IntPtr target);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Embolden(IntPtr library, IntPtr bitmap, IntPtr xStrength, IntPtr yStrength);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Convert(IntPtr library, IntPtr source, IntPtr target, int alignment);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_GlyphSlot_Own_Bitmap(IntPtr slot);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Bitmap_Done(IntPtr library, IntPtr bitmap);
        

        #endregion

        #region Glyph Stroker

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_StrokerBorder FT_Outline_GetInsideBorder(IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_StrokerBorder FT_Outline_GetOutsideBorder(IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_New(IntPtr library, out IntPtr astroker);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Set(IntPtr stroker, int radius, FT_Stroker_LineCap line_cap, FT_Stroker_LineJoin line_join, IntPtr miter_limit);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Rewind(IntPtr stroker);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_ParseOutline(IntPtr stroker, IntPtr outline, [MarshalAs(UnmanagedType.U1)] bool opened);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_BeginSubPath(IntPtr stroker, ref FT_Vector to, [MarshalAs(UnmanagedType.U1)] bool open);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_EndSubPath(IntPtr stroker);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_LineTo(IntPtr stroker, ref FT_Vector to);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_ConicTo(IntPtr stroker, ref FT_Vector control, ref FT_Vector to);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_CubicTo(IntPtr stroker, ref FT_Vector control1, ref FT_Vector control2, ref FT_Vector to);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_GetBorderCounts(IntPtr stroker, FT_StrokerBorder border, out uint anum_points, out uint anum_contours);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_ExportBorder(IntPtr stroker, FT_StrokerBorder border, IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stroker_GetCounts(IntPtr stroker, out uint anum_points, out uint anum_contours);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Export(IntPtr stroker, IntPtr outline);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Stroker_Done(IntPtr stroker);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_Stroke(ref IntPtr pglyph, IntPtr stoker, [MarshalAs(UnmanagedType.U1)] bool destroy);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Glyph_StrokeBorder(ref IntPtr pglyph, IntPtr stoker, [MarshalAs(UnmanagedType.U1)] bool inside, [MarshalAs(UnmanagedType.U1)] bool destroy);
        

        #endregion

        #region Module Management

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Add_Module(IntPtr library, IntPtr clazz);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr FT_Get_Module(IntPtr library, string module_name);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Remove_Module(IntPtr library, IntPtr module);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern FT_Error FT_Property_Set(IntPtr library, string module_name, string property_name, IntPtr value);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern FT_Error FT_Property_Get(IntPtr library, string module_name, string property_name, IntPtr value);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Reference_Library(IntPtr library);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_New_Library(IntPtr memory, out IntPtr alibrary);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Done_Library(IntPtr library);
        

        //TODO figure out the method signature for debug_hook. (FT_DebugHook_Func)
        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Debug_Hook(IntPtr library, uint hook_index, IntPtr debug_hook);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Add_Default_Modules(IntPtr library);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FT_Get_Renderer(IntPtr library, FT_Glyph_Format format);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Set_Renderer(IntPtr library, IntPtr renderer, uint num_params, IntPtr parameters);
        

        #endregion

        #region GZIP Streams

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stream_OpenGzip(IntPtr stream, IntPtr source);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Gzip_Uncompress(IntPtr memory, IntPtr output, ref IntPtr output_len, IntPtr input, IntPtr input_len);
        

        #endregion

        #region LZW Streams

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stream_OpenLZW(IntPtr stream, IntPtr source);
        

        #endregion

        #region BZIP2 Streams

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Stream_OpenBzip2(IntPtr stream, IntPtr source);
        

        #endregion

        #region LCD Filtering

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Library_SetLcdFilter(IntPtr library, FT_LcdFilter filter);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_Library_SetLcdFilterWeights(IntPtr library, byte[] weights);
        

        #endregion

        #endregion

        #region Caching Sub-system

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_Manager_New(IntPtr library, uint max_faces, uint max_sizes, ulong maxBytes, FTC_Face_Requester requester, IntPtr req_data, out IntPtr amanager);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Manager_Reset(IntPtr manager);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Manager_Done(IntPtr manager);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_Manager_LookupFace(IntPtr manager, IntPtr face_id, out IntPtr aface);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_Manager_LookupSize(IntPtr manager, IntPtr scaler, out IntPtr asize);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Node_Unref(IntPtr node, IntPtr manager);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FTC_Manager_RemoveFaceID(IntPtr manager, IntPtr face_id);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_CMapCache_New(IntPtr manager, out IntPtr acache);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FTC_CMapCache_Lookup(IntPtr cache, IntPtr face_id, int cmap_index, uint char_code);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_ImageCache_New(IntPtr manager, out IntPtr acache);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_ImageCache_Lookup(IntPtr cache, IntPtr type, uint gindex, out IntPtr aglyph, out IntPtr anode);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_ImageCache_LookupScaler(IntPtr cache, IntPtr scaler, uint load_flags, uint gindex, out IntPtr aglyph, out IntPtr anode);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_SBitCache_New(IntPtr manager, out IntPtr acache);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_SBitCache_Lookup(IntPtr cache, IntPtr type, uint gindex, out IntPtr sbit, out IntPtr anode);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FTC_SBitCache_LookupScaler(IntPtr cache, IntPtr scaler, uint load_flags, uint gindex, out IntPtr sbit, out IntPtr anode);
        

        #endregion

        #region Miscellaneous

        #region OpenType Validation

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_OpenType_Validate(IntPtr face, uint validation_flags, out IntPtr base_table, out IntPtr gdef_table, out IntPtr gpos_table, out IntPtr gsub_table, out IntPtr jsft_table);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_OpenType_Free(IntPtr face, IntPtr table);
        

        #endregion

        #region The TrueType Engine

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_TrueTypeEngineType FT_Get_TrueType_Engine_Type(IntPtr library);
        

        #endregion

        #region TrueTypeGX/AAT Validation

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_TrueTypeGX_Validate(IntPtr face, uint validation_flags, ref byte[] tables, uint tableLength);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_TrueTypeGX_Free(IntPtr face, IntPtr table);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_ClassicKern_Validate(IntPtr face, uint validation_flags, out IntPtr ckern_table);
        

        [DllImport(FreeTypeLibaryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_Error FT_ClassicKern_Free(IntPtr face, IntPtr table);
        

        #endregion

        #endregion

    }
}
