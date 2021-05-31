namespace FreeTypeSharp.Native
{
    static partial class FT
    {
        // face flags
        public const int FT_FACE_FLAG_SCALABLE = 1 << 0;
        public const int FT_FACE_FLAG_FIXED_SIZES = 1 << 1;
        public const int FT_FACE_FLAG_FIXED_WIDTH = 1 << 2;
        public const int FT_FACE_FLAG_SFNT = 1 << 3;
        public const int FT_FACE_FLAG_HORIZONTAL = 1 << 4;
        public const int FT_FACE_FLAG_VERTICAL = 1 << 5;
        public const int FT_FACE_FLAG_KERNING = 1 << 6;
        public const int FT_FACE_FLAG_FAST_GLYPHS = 1 << 7;
        public const int FT_FACE_FLAG_MULTIPLE_MASTERS = 1 << 8;
        public const int FT_FACE_FLAG_GLYPH_NAMES = 1 << 9;
        public const int FT_FACE_FLAG_EXTERNAL_STREAM = 1 << 10;
        public const int FT_FACE_FLAG_HINTER = 1 << 11;
        public const int FT_FACE_FLAG_CID_KEYED = 1 << 12;
        public const int FT_FACE_FLAG_TRICKY = 1 << 13;
        public const int FT_FACE_FLAG_COLOR = 1 << 14;
        public const int FT_FACE_FLAG_VARIATION = 1 << 15;

        // glyph load flags
        public const int FT_LOAD_DEFAULT = 0x0;
        public const int FT_LOAD_NO_SCALE = (1 << 0);
        public const int FT_LOAD_NO_HINTING = (1 << 1);
        public const int FT_LOAD_RENDER = (1 << 2);
        public const int FT_LOAD_NO_BITMAP = (1 << 3);
        public const int FT_LOAD_VERTICAL_LAYOUT = (1 << 4);
        public const int FT_LOAD_FORCE_AUTOHINT = (1 << 5);
        public const int FT_LOAD_CROP_BITMAP = (1 << 6);
        public const int FT_LOAD_PEDANTIC = (1 << 7);
        public const int FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH = (1 << 9);
        public const int FT_LOAD_NO_RECURSE = (1 << 10);
        public const int FT_LOAD_IGNORE_TRANSFORM = (1 << 11);
        public const int FT_LOAD_MONOCHROME = (1 << 12);
        public const int FT_LOAD_LINEAR_DESIGN = (1 << 13);
        public const int FT_LOAD_NO_AUTOHINT = (1 << 15);
        public const int FT_LOAD_COLOR = (1 << 20);
        public const int FT_LOAD_COMPUTE_METRICS = (1 << 21);
        public const int FT_LOAD_BITMAP_METRICS_ONLY = (1 << 22);
        public const int FT_LOAD_ADVANCE_ONLY = (1 << 8);
        public const int FT_LOAD_SBITS_ONLY = (1 << 14);

        // glyph load target flags
        public const int FT_LOAD_TARGET_NORMAL = (0 & 15) << 16;
        public const int FT_LOAD_TARGET_LIGHT = (1 & 15) << 16;
        public const int FT_LOAD_TARGET_MONO = (2 & 15) << 16;
        public const int FT_LOAD_TARGET_LCD = (3 & 15) << 16;
        public const int FT_LOAD_TARGET_LCD_V = (4 & 15) << 16;

        // opentype validation flags
        public const uint FT_VALIDATE_BASE = 0x0100;
        public const uint FT_VALIDATE_GDEF = 0x0200;
        public const uint FT_VALIDATE_GPOS = 0x0400;
        public const uint FT_VALIDATE_GSUB = 0x0800;
        public const uint FT_VALIDATE_JSTF = 0x1000;
        public const uint FT_VALIDATE_MATH = 0x2000;
        public const uint FT_VALIDATE_OT = (FT_VALIDATE_BASE | FT_VALIDATE_GDEF | FT_VALIDATE_GPOS | FT_VALIDATE_GSUB | FT_VALIDATE_JSTF | FT_VALIDATE_MATH);

        // truetype validation flags
        public const uint FT_VALIDATE_feat = 0x4000 << 0;
        public const uint FT_VALIDATE_mort = 0x4000 << 1;
        public const uint FT_VALIDATE_morx = 0x4000 << 2;
        public const uint FT_VALIDATE_bsln = 0x4000 << 3;
        public const uint FT_VALIDATE_just = 0x4000 << 4;
        public const uint FT_VALIDATE_kern = 0x4000 << 5;
        public const uint FT_VALIDATE_opbd = 0x4000 << 6;
        public const uint FT_VALIDATE_trak = 0x4000 << 7;
        public const uint FT_VALIDATE_prop = 0x4000 << 8;
        public const uint FT_VALIDATE_lcar = 0x4000 << 9;
        public const uint FT_VALIDATE_GX = (FT_VALIDATE_feat | FT_VALIDATE_mort | FT_VALIDATE_morx | FT_VALIDATE_bsln | FT_VALIDATE_just | FT_VALIDATE_kern | FT_VALIDATE_opbd | FT_VALIDATE_trak | FT_VALIDATE_prop | FT_VALIDATE_lcar);

        // classic kern validation flags
        public const uint FT_VALIDATE_MS = 0x4000 << 0;
        public const uint FT_VALIDATE_APPLE = 0x4000 << 1;
        public const uint FT_VALIDATE_CKERN = (FT_VALIDATE_MS | FT_VALIDATE_APPLE);

        // subglyph flags
        public const uint FT_SUBGLYPH_FLAG_ARGS_ARE_WORDS = 1;
        public const uint FT_SUBGLYPH_FLAG_ARGS_ARE_XY_VALUES = 2;
        public const uint FT_SUBGLYPH_FLAG_ROUND_XY_TO_GRID = 4;
        public const uint FT_SUBGLYPH_FLAG_SCALE = 8;
        public const uint FT_SUBGLYPH_FLAG_XY_SCALE = 0x40;
        public const uint FT_SUBGLYPH_FLAG_2X2 = 0x80;
        public const uint FT_SUBGLYPH_FLAG_USE_MY_METRICS = 0x200;

        // embedding types
        public const ushort FT_FSTYPE_INSTALLABLE_EMBEDDING = 0x0000;
        public const ushort FT_FSTYPE_RESTRICTED_LICENSE_EMBEDDING = 0x0002;
        public const ushort FT_FSTYPE_PREVIEW_AND_PRINT_EMBEDDING = 0x0004;
        public const ushort FT_FSTYPE_EDITABLE_EMBEDDING = 0x0008;
        public const ushort FT_FSTYPE_NO_SUBSETTING = 0x0100;
        public const ushort FT_FSTYPE_BITMAP_EMBEDDING_ONLY = 0x0200;
    }
}
