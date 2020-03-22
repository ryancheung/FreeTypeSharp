using System;
using FreeTypeSharp.Native;

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
            IntPtr lib;
            var err = FT.FT_Init_FreeType(out lib);
            if (err != FT_Error.FT_Err_Ok)
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
                var err = FT.FT_Done_FreeType(Native);
                if (err != FT_Error.FT_Err_Ok)
                    throw new FreeTypeException(err);

                Native = IntPtr.Zero;
            }

            disposed = true;
        }
    }
}
