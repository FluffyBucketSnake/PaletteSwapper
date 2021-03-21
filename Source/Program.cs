using SixLabors.ImageSharp;
using System;

namespace PaletteSwapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Args _args = null;
            try
            {
                _args = Args.Parse(0, args);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Argument error: {0}", e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Argument format error: {0}", e.Message);
            }
            if (_args == null) return;

            // Load source bitmap.
            ImageBitmap source = null;
            try
            {
                source = ImageBitmap.Load(_args.SourcePath);
            }
            catch (UnknownImageFormatException e)
            {
                Console.WriteLine("Can't load source image: unknown image format.");
                Console.WriteLine("Details: {0}", e.Message);
            }
            catch (InvalidImageContentException e)
            {
                Console.WriteLine("Can't load source image: file has invalid content.");
                Console.WriteLine("Details: {0}", e.Message);
            }
            if (source == null) return;

            // Load palettes.
            Palette[] palettes = null;
            try
            {
                palettes = Palette.Load(_args.PaletteTablePath);
            }
            catch (UnknownImageFormatException e)
            {
                Console.WriteLine("Can't load palettes: unknown format.");
                Console.WriteLine("Details: {0}", e.Message);
            }
            catch (InvalidImageContentException e)
            {
                Console.WriteLine("Can't load palettes: file has invalid content.");
                Console.WriteLine("Details: {0}", e.Message);
            }
            if (palettes == null) return;

            // Palette swapping code
            var indexed = IndexedBitmap.FromBitmap(source, palettes[_args.SourcePaletteIndex]);
            indexed.Palette = palettes[_args.TargetPaletteIndex];
            var output = indexed.Dereference();

            // Save output.
            output.Save(_args.DestinationPath);
        }
    }
}
