namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Size_RequestRec_
    {
        public FT_Size_Request_Type_ type;
        public IntPtr width;
        public IntPtr height;
        public uint horiResolution;
        public uint vertResolution;
    }
}