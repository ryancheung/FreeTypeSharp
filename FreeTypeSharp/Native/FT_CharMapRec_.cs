namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_CharMapRec_
    {
        public FT_FaceRec_* face;
        public FT_Encoding_ encoding;
        public ushort platform_id;
        public ushort encoding_id;
    }
}