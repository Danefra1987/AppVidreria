using PdfSharpCore.Fonts;
using System.Reflection;

namespace AppVidreria.Utilities
{
    public class FileFontResolver : IFontResolver
    {
        public FileFontResolver()
        {
        }

        public string DefaultFontName => "OpenSans-Semibold.ttf";

        public byte[] GetFont(string faceName)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var directory = $"AppVidreria.Resources.Fonts.{faceName}.ttf";
            var stream = assembly.GetManifestResourceStream(directory);

            using (var reader = new StreamReader(stream))
            {
                var bytes = default(byte[]);

                using (var ms = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                return bytes;
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            return new FontResolverInfo(familyName);
        }
    }
}
