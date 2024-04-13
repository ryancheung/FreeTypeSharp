namespace FreeTypeSharp
{
    public enum FT_FACE_FLAG : int
    {
        FT_FACE_FLAG_SCALABLE = (1 << 0),
        FT_FACE_FLAG_FIXED_SIZES = (1 << 1),
        FT_FACE_FLAG_FIXED_WIDTH = (1 << 2),
        FT_FACE_FLAG_SFNT = (1 << 3),
        FT_FACE_FLAG_HORIZONTAL = (1 << 4),
        FT_FACE_FLAG_VERTICAL = (1 << 5),
        FT_FACE_FLAG_KERNING = (1 << 6),
        FT_FACE_FLAG_FAST_GLYPHS = (1 << 7),
        FT_FACE_FLAG_MULTIPLE_MASTERS = (1 << 8),
        FT_FACE_FLAG_GLYPH_NAMES = (1 << 9),
        FT_FACE_FLAG_EXTERNAL_STREAM = (1 << 10),
        FT_FACE_FLAG_HINTER = (1 << 11),
        FT_FACE_FLAG_CID_KEYED = (1 << 12),
        FT_FACE_FLAG_TRICKY = (1 << 13),
        FT_FACE_FLAG_COLOR = (1 << 14),
        FT_FACE_FLAG_VARIATION = (1 << 15),
        FT_FACE_FLAG_SVG = (1 << 16),
        FT_FACE_FLAG_SBIX = (1 << 17),
        FT_FACE_FLAG_SBIX_OVERLAY = (1 << 18)}
}