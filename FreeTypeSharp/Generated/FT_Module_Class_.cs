namespace FreeTypeSharp
{
    using System.Runtime.InteropServices;
    using System;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Module_Class_
    {
        public UIntPtr module_flags;
        public IntPtr module_size;
        public byte* module_name;
        public IntPtr module_version;
        public IntPtr module_requires;
        public void* module_interface;
        public void* module_init;
        public void* module_done;
        public void* get_interface;
    }
}