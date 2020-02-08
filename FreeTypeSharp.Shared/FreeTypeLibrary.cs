using System;
using static FreeTypeSharp.Native.FreeTypeNative;
using static FreeTypeSharp.Native.FT_Error;

namespace FreeTypeSharp
{
    /// <summary>
    /// Encapsulates the native FreeType2 library object.
    /// </summary>
    public sealed unsafe class FreeTypeLibrary : IDisposable
    {
        private Boolean disposed;

        /// <summary>
        /// Gets a value indicating whether the object has been disposed.
        /// </summary>
        public Boolean Disposed
        {
            get { return disposed; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FreeTypeLibrary"/> class.
        /// </summary>
        public FreeTypeLibrary()
        {
            var lib = default(IntPtr);
            var err = FT_Init_FreeType((IntPtr)(&lib));
            if (err != FT_Err_Ok)
                throw new FreeTypeException(err);

            Native = lib;
        }

        /// <summary>
        /// Gets the native pointer to the FreeType2 library object.
        /// </summary>
        public IntPtr Native { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        void Dispose(Boolean disposing)
        {
            if (Native != IntPtr.Zero)
            {
                var err = FT_Done_FreeType(Native);
                if (err != FT_Err_Ok)
                    throw new FreeTypeException(err);

                Native = IntPtr.Zero;
            }

            disposed = true;
        }
    }
}
