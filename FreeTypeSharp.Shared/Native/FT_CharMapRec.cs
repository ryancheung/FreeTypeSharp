using System;
using System.Runtime.InteropServices;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_CharMapRec
    {
        public FT_FaceRec* face;
        public FT_Encoding encoding;
        public ushort platform_id;
        public ushort encoding_id;
    }
}
