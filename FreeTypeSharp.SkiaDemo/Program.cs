using System;
using System.IO;
using SkiaSharp;
using SixLabors.Fonts;
using System.Runtime.InteropServices;
using System.Globalization;

namespace FreeTypeSharp.Demo
{
    public class Program
    {
        static string? GetSystemFont(string fontName)
        {
            FontFamily search = new();
            bool found = false;
            foreach (var fontFamily in SystemFonts.Families)
            {
                if (fontFamily.Name == fontName)
                {
                    search = fontFamily;
                    found = true;
                }
                else
                {
                    if (fontFamily.TryGetMetrics(FontStyle.Regular, out var metrics))
                    {
                        if (metrics.Description.FontName(CultureInfo.CurrentCulture) == fontName)
                        {
                            search = fontFamily;
                            found = true;
                        }
                    }
                }
            }

            if (found)
            {
                var font = search.CreateFont(0, FontStyle.Regular);
                if (font.TryGetPath(out var path))
                    return path;
            }

            return null;
        }
        unsafe static void Main(string[] args)
        {
            var library = new FreeTypeLibrary();
            FT_FaceRec_* face;

            var fontPath = GetSystemFont("Microsoft Sans Serif");
            var error = FT.FT_New_Face(library.Native, (byte*)Marshal.StringToHGlobalAnsi(fontPath), 0, &face);
            error = FT.FT_Set_Char_Size(face, 0, 16 * 64, 300, 300);
            var glyphIndex = FT.FT_Get_Char_Index(face, 'я');
            error = FT.FT_Load_Glyph(face, glyphIndex, FT_LOAD.FT_LOAD_DEFAULT);
            error = FT.FT_Render_Glyph(face->glyph, FT_Render_Mode_.FT_RENDER_MODE_NORMAL);
            var bitmap = face->glyph->bitmap;

            var skBitmap = new SKBitmap((int)bitmap.width, (int)bitmap.rows);
            var canvas = new SKCanvas(skBitmap);

            for (var i = 0; i != bitmap.width; i++)
            {
                for (var j = 0; j != bitmap.rows; j++)
                {
                    canvas.DrawPoint(new SKPoint(i, j), new SKColor(bitmap.buffer[j*bitmap.pitch+i], bitmap.buffer[j * bitmap.pitch + i], bitmap.buffer[j * bitmap.pitch + i], bitmap.buffer[j * bitmap.pitch + i]));
                }
            }

            using(var fileStream = File.OpenWrite("Test.jpg"))
            {
                using (var wstream = new SKManagedWStream(fileStream))
                {
                    skBitmap.Encode(wstream, SKEncodedImageFormat.Png, 100);
                }
            }
        }
    }
}