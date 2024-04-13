using System;

namespace FreeTypeSharp
{
    /// <summary>
    /// Encapsulates the native FreeType2 library object.
    /// </summary>
    public sealed unsafe class FreeTypeLibrary : IDisposable
    {
        private bool disposed;

        /// <summary>
        /// Gets a value indicating whether the object has been disposed.
        /// </summary>
        public bool Disposed
        {
            get { return disposed; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FreeTypeLibrary"/> class.
        /// </summary>
        public FreeTypeLibrary()
        {
            FT_LibraryRec_* lib;
            var err = FT.FT_Init_FreeType(&lib);
            if (err != FT_Error.FT_Err_Ok)
                throw new FreeTypeException(err);

            Native = lib;
        }

        /// <summary>
        /// Gets the native pointer to the FreeType2 library object.
        /// </summary>
        public FT_LibraryRec_* Native { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        void Dispose(bool disposing)
        {
            if (Native != default)
            {
                var err = FT.FT_Done_FreeType(Native);
                if (err != FT_Error.FT_Err_Ok)
                    throw new FreeTypeException(err);

                Native = default;
            }

            disposed = true;
        }
    }
}
