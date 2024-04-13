using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static FreeTypeSharp.FT_FACE_FLAG;

namespace FreeTypeSharp
{
    public unsafe class FreeTypeFaceFacade
    {
        // A pointer to the wrapped FreeType2 face object.
        private readonly FT_FaceRec_* _FaceRec;
        private readonly FreeTypeLibrary _Library;

        /// <summary>
        /// Initialize a FreeTypeFaceFacade instance with a pointer to the Face instance.
        /// </summary>
        public FreeTypeFaceFacade(FreeTypeLibrary library, FT_FaceRec_* face)
        {
            _Library = library;
            _FaceRec = face;
        }

        /// <summary>
        /// Initialize a FreeTypeFaceFacade instance with font data.
        /// </summary>
        public FreeTypeFaceFacade(FreeTypeLibrary library, IntPtr fontData, int dataLength, int faceIndex = 0)
        {
            _Library = library;

            FT_FaceRec_* face;

            var err = FT.FT_New_Memory_Face(_Library.Native, (byte*)fontData, (IntPtr)dataLength, (IntPtr)faceIndex, &face);
            if (err != FT_Error.FT_Err_Ok)
                throw new FreeTypeException(err);

            _FaceRec = face;
        }

        #region Properties

        public FT_FaceRec_* FaceRec { get { return _FaceRec; } }

        /// <summary>
        /// Gets a value indicating whether the face has the FT_FACE_FLAG_SCALABLE flag set.
        /// </summary>
        /// <returns><see langword="true"/> if the face has the FT_FACE_FLAG_SCALABLE flag defined; otherwise, <see langword="false"/>.</returns>
        public bool HasScalableFlag { get { return HasFaceFlag(FT_FACE_FLAG_SCALABLE); } }

        /// <summary>
        /// Gets a value indicating whether the face has the FT_FACE_FLAG_FIXED_SIZES flag set.
        /// </summary>
        /// <returns><see langword="true"/> if the face has the FT_FACE_FLAG_FIXED_SIZES flag defined; otherwise, <see langword="false"/>.</returns>
        public bool HasFixedSizes { get { return HasFaceFlag(FT_FACE_FLAG_FIXED_SIZES); } }

        /// <summary>
        /// Gets a value indicating whether the face has the FT_FACE_FLAG_COLOR flag set.
        /// </summary>
        /// <returns><see langword="true"/> if the face has the FT_FACE_FLAG_COLOR flag defined; otherwise, <see langword="false"/>.</returns>
        public bool HasColorFlag { get { return HasFaceFlag(FT_FACE_FLAG_COLOR); } }

        /// <summary>
        /// Gets a value indicating whether the face has the FT_FACE_FLAG_KERNING flag set.
        /// </summary>
        /// <returns><see langword="true"/> if the face has the FT_FACE_FLAG_KERNING flag defined; otherwise, <see langword="false"/>.</returns>
        public bool HasKerningFlag { get { return HasFaceFlag(FT_FACE_FLAG_KERNING); } }

        /// <summary>
        /// Gets a value indicating whether the face has any bitmap strikes with fixed sizes.
        /// </summary>
        public bool HasBitmapStrikes { get { return (_FaceRec->num_fixed_sizes) > 0; } }

        /// <summary>
        /// Gets the current glyph bitmap.
        /// </summary>
        public FT_Bitmap_ GlyphBitmap { get { return _FaceRec->glyph->bitmap; } }
        public FT_Bitmap_* GlyphBitmapPtr { get { return &_FaceRec->glyph->bitmap; } }

        /// <summary>
        /// Gets the left offset of the current glyph bitmap.
        /// </summary>
        public int GlyphBitmapLeft { get { return _FaceRec->glyph->bitmap_left; } }

        /// <summary>
        /// Gets the right offset of the current glyph bitmap.
        /// </summary>
        public int GlyphBitmapTop { get { return _FaceRec->glyph->bitmap_top; } }

        /// <summary>
        /// Gets the width in pixels of the current glyph.
        /// </summary>
        public int GlyphMetricWidth { get { return (int)_FaceRec->glyph->metrics.width >> 6; } }

        /// <summary>
        /// Gets the height in pixels of the current glyph.
        /// </summary>
        public int GlyphMetricHeight { get { return (int)_FaceRec->glyph->metrics.height >> 6; } }

        /// <summary>
        /// Gets the horizontal advance of the current glyph.
        /// </summary>
        public int GlyphMetricHorizontalAdvance { get { return (int)_FaceRec->glyph->metrics.horiAdvance >> 6; } }

        /// <summary>
        /// Gets the vertical advance of the current glyph.
        /// </summary>
        public int GlyphMetricVerticalAdvance { get { return (int)_FaceRec->glyph->metrics.vertAdvance >> 6; } }

        /// <summary>
        /// Gets the face's ascender size in pixels.
        /// </summary>
        public int Ascender { get { return (int)_FaceRec->size->metrics.ascender >> 6; } }

        /// <summary>
        /// Gets the face's descender size in pixels.
        /// </summary>
        public int Descender { get { return (int)_FaceRec->size->metrics.descender >> 6; } }

        /// <summary>
        /// Gets the face's line spacing in pixels.
        /// </summary>
        public int LineSpacing { get { return (int)_FaceRec->size->metrics.height >> 6; } }

        /// <summary>
        /// Gets the face's underline position.
        /// </summary>
        public int UnderlinePosition { get { return _FaceRec->underline_position >> 6; } }

        /// <summary>
        /// Gets a pointer to the face's glyph slot.
        /// </summary>
        public FT_GlyphSlotRec_* GlyphSlot { get { return _FaceRec->glyph; } }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a value indicating whether the face has the specified flag defined.
        /// </summary>
        /// <param name="flag">The flag to evaluate.</param>
        /// <returns><see langword="true"/> if the face has the specified flag defined; otherwise, <see langword="false"/>.</returns>
        public bool HasFaceFlag(FT_FACE_FLAG flag) { return (((int)_FaceRec->face_flags) & (int)flag) != 0; }

        /// <summary>
        /// Selects the specified character size for the font face.
        /// </summary>
        /// <param name="sizeInPoints">The size in points to select.</param>
        /// <param name="dpiX">The horizontal pixel density.</param>
        /// <param name="dpiY">The vertical pixel density.</param>
        public void SelectCharSize(int sizeInPoints, uint dpiX, uint dpiY)
        {
            var size = (IntPtr)(sizeInPoints << 6);
            var err = FT.FT_Set_Char_Size(_FaceRec, size, size, dpiX, dpiY);
            if (err != FT_Error.FT_Err_Ok)
                throw new FreeTypeException(err);
        }

        /// <summary>
        /// Selects the specified fixed size for the font face.
        /// </summary>
        /// <param name="ix">The index of the fixed size to select.</param>
        public void SelectFixedSize(int ix)
        {
            var err = FT.FT_Select_Size(_FaceRec, ix);
            if (err != FT_Error.FT_Err_Ok)
                throw new FreeTypeException(err);
        }

        /// <summary>
        /// Gets the glyph index of the specified character, if it is defined by this face.
        /// </summary>
        /// <param name="charCode">The character code for which to retrieve a glyph index.</param>
        /// <returns>The glyph index of the specified character, or 0 if the character is not defined by this face.</returns>
        public uint GetCharIndex(uint charCode) { return FT.FT_Get_Char_Index(_FaceRec, (UIntPtr)charCode); }

        /// <summary>
        /// Marshals the face's family name to a C# string.
        /// </summary>
        /// <returns>The marshalled string.</returns>
        public string MarshalFamilyName() { return Marshal.PtrToStringAnsi((IntPtr)_FaceRec->family_name); }

        /// <summary>
        /// Marshals the face's style name to a C# string.
        /// </summary>
        /// <returns>The marshalled string.</returns>
        public string MarshalStyleName() { return Marshal.PtrToStringAnsi((IntPtr)_FaceRec->style_name); }

        /// <summary>
        /// Returns the specified character if it is defined by this face; otherwise, returns <see langword="null"/>.
        /// </summary>
        /// <param name="c">The character to evaluate.</param>
        /// <returns>The specified character, if it is defined by this face; otherwise, <see langword="null"/>.</returns>
        public char? GetCharIfDefined(char c) { return FT.FT_Get_Char_Index(_FaceRec, (UIntPtr)c) > 0 ? c : (char?)null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetFixedSizeInPixels(FT_FaceRec_* face, int ix)
        {
            return face->available_sizes[ix].height;
        }

        /// <summary>
        /// Returns the index of the fixed size which is the closest match to the specified pixel size.
        /// </summary>
        /// <param name="sizeInPixels">The desired size in pixels.</param>
        /// <param name="requireExactMatch">A value indicating whether to require an exact match.</param>
        /// <returns>The index of the closest matching fixed size.</returns>
        public int FindNearestMatchingPixelSize(int sizeInPixels, bool requireExactMatch = false)
        {
            var numFixedSizes = _FaceRec->num_fixed_sizes;
            if (numFixedSizes == 0)
                throw new InvalidOperationException("FONT_DOES_NOT_HAVE_BITMAP_STRIKES");

            var bestMatchIx = 0;
            var bestMatchDiff = Math.Abs(GetFixedSizeInPixels(_FaceRec, 0) - sizeInPixels);

            for (int i = 0; i < numFixedSizes; i++)
            {
                var size = GetFixedSizeInPixels(_FaceRec, i);
                var diff = Math.Abs(size - sizeInPixels);
                if (diff < bestMatchDiff)
                {
                    bestMatchDiff = diff;
                    bestMatchIx = i;
                }
            }

            if (bestMatchDiff != 0 && requireExactMatch)
                throw new InvalidOperationException(string.Format("NO_MATCHING_PIXEL_SIZE: {0}", sizeInPixels));

            return bestMatchIx;
        }

        public bool EmboldenGlyphBitmap(int xStrength, int yStrength)
        {
            var err = FT.FT_Bitmap_Embolden(_Library.Native, GlyphBitmapPtr, (IntPtr)xStrength, (IntPtr)yStrength);
            if (err != FT_Error.FT_Err_Ok)
                return false;

            if ((int)_FaceRec->glyph->advance.x > 0)
                _FaceRec->glyph->advance.x += xStrength;
            if ((int)_FaceRec->glyph->advance.y > 0)
                _FaceRec->glyph->advance.x += yStrength;
            _FaceRec->glyph->metrics.width += xStrength;
            _FaceRec->glyph->metrics.height += yStrength;
            _FaceRec->glyph->metrics.horiBearingY += yStrength;
            _FaceRec->glyph->metrics.horiAdvance += xStrength;
            _FaceRec->glyph->metrics.vertBearingX -= xStrength / 2;
            _FaceRec->glyph->metrics.vertBearingY += yStrength;
            _FaceRec->glyph->metrics.vertAdvance += yStrength;

            _FaceRec->glyph->bitmap_top += (yStrength >> 6);

            return true;
        }

        #endregion
    }
}