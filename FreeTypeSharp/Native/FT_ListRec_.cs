namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_ListRec_
    {
        public FT_ListNodeRec_* head;
        public FT_ListNodeRec_* tail;
    }
}