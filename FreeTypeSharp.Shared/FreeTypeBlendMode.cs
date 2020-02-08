namespace FreeTypeSharp
{
    /// <summary>
    /// Represents the blending modes which can be used to blit glyphs onto a surface.
    /// </summary>
    public enum FreeTypeBlendMode
    {
        /// <summary>
        /// The glyph data should be treated as opaque.
        /// </summary>
        Opaque,

        /// <summary>
        /// The glyph data should be alpha blended onto the surface.
        /// </summary>
        Blend,
    }
}
