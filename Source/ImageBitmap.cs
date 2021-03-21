using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PaletteSwapper
{
    /// <summary>
    /// Represents the bitmap data of an image.
    /// </summary>
    public class ImageBitmap : Bitmap<Colour>
    {
        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.ImageBitmap"/> from an already existing buffer.
        /// The buffer data must be in the form of a sequence of rows.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="data">The source buffer from which the data will be copied.</param>
        /// <exception cref="System.ArgumentException">Thrown when 
        /// <paramref name="data"/> length is smaller than <paramref name="width"/>
        ///  * <paramref name="height"/>, or if either <paramref name="width"/> or
        /// <paramref name="height"/> are smaller or equal to zero.</exception>
        public ImageBitmap(int width, int height, Colour[] data) : base(width, height, data)
        {
        }

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.ImageBitmap"/> filled with copies of a single
        /// value.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="value">The value used to fill the buffer.</param>
        /// <exception cref="System.ArgumentException">Thrown when either 
        /// <paramref name="width"/> or <paramref name="height"/> are smaller or equal 
        /// to zero.</exception>
        public ImageBitmap(int width, int height, Colour value) : base(width, height, value)
        {
        }

        /// <summary>
        /// Loads the bitmap data from a image file.
        /// </summary>
        /// <param name="path">The file path to the image file.</param>
        /// <returns>Returns the loaded bitmap data.</returns>
        public static ImageBitmap Load(string path)
        {
            int width, height;
            Colour[] data;
            using (Image<Rgba32> image = Image.Load(path).CloneAs<Rgba32>())
            {
                // Get metadata.
                width = image.Width;
                height = image.Height;

                // Initilize and fill buffer.
                data = new Colour[width * height];
                for (int y = 0; y < height; y++)
                {
                    var row = image.GetPixelRowSpan(y);
                    for (int x = 0; x < width; x++)
                    {
                        // Convert ImageSharp Rgba32 struct into a Colour struct.
                        Rgba32 source = row[x];
                        data[(y * width) + x] = new Colour(source.R, source.G, source.B, source.A);
                    }
                }
            }

            return new ImageBitmap(width, height, data);
        }

        public void Save(string path)
        {
            // Convert Colour array into a Rgba32 array.
            Colour[] srcData = this.GetData();
            Rgba32[] destData = new Rgba32[Width * Height];
            for (int i = 0; i < srcData.Length; i++)
            {
                Colour src = srcData[i];
                Rgba32 dest = new(src.R, src.G, src.B, src.A);
                destData[i] = dest;
            }
            
            // Create a new ImageSharp Image and save it.
            var image = Image.LoadPixelData(destData, Width, Height);
            image.Save(path);
        }
    }
}