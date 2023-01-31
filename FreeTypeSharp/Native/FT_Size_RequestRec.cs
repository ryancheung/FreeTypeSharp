using System;
using System.Runtime.InteropServices;
using FT_Long = System.UInt64;
using FT_UInt = System.UInt32;

namespace FreeTypeSharp.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Size_RequestRec
    {
        public FT_Size_Request_Type type;
        public FT_Long width;
        public FT_Long height;
        public FT_UInt horiResolution;
        public FT_UInt vertResolution; 
    }
}
