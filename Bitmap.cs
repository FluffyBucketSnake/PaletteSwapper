namespace PaletteSwapper
{
    /// <summary>
    /// Represents the pixel data of a bitmap image.
    /// </summary>
    public class Bitmap
    {
        // A 2D-array holding the data of each pixel. (x, y) pixel indexed as [y, x].
        private Colour[,] _data;

        private int _width;

        private int _height;

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.Bitmap"/> from an already existing colour
        /// buffer.
        /// The colour data must be stored as a sequence of rows.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="data">The source pixel buffer from which the data will be copied.</param>
        /// <exception cref="System.ArgumentException">Thrown when 
        /// <paramref name="data"/> length is smaller than <paramref name="width"/>
        ///  * <paramref name="height"/>, or if either <paramref name="width"/> or
        /// <paramref name="height"/> are smaller or equal to zero.</exception>
        public Bitmap(int width, int height, Colour[] data)
        {
            // Null checking.
            if (data == null)
            {
                throw new System.ArgumentNullException(nameof(data));
            }

            // Parameter validation.
            if (width <= 0 | height <= 0)
            {
                throw new System.ArgumentException("Width or height cannot be smaller or equal to zero.");
            }
            if (data.Length < width * height)
            {
                throw new System.ArgumentException("The data buffer is too small.");
            }

            // Set fields.
            this._width = width;
            this._height = height;

            // Fill internal data buffer.
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    this._data[y, x] = data[(y * width) + x];
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.Bitmap"/> filled with a single colour.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="colour">The fill colour.</param>
        /// <exception cref="System.ArgumentException">Thrown when either 
        /// <paramref name="width"/> or <paramref name="height"/> are smaller or equal 
        /// to zero.</exception>
        public Bitmap(int width, int height, Colour colour)
        {
            // Parameter validation.
            if (width <= 0 | height <= 0)
            {
                throw new System.ArgumentException("Width or height cannot be smaller or equal to zero.");
            }

            // Set fields.
            this._width = width;
            this._height = height;

            // Fill internal data buffer.
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    this._data[y, x] = colour;
                }
            }
        }

        /// <summary>
        /// Gets or sets the colour at the pixel in the specified xy coordinates of this bitmap.
        /// </summary>
        public Colour this[int x, int y]
        {
            get => GetPixel(x, y);
            set => SetPixel(x, y, value);
        }

        /// <summary>
        /// Returns the colour at the pixel in the specified xy coordinates of this bitmap.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public Colour GetPixel(int x, int y)
        {
            return _data[y, x];
        }

        /// <summary>
        /// Sets the colour at the pixel in the specified xy coordinates of this bitmap.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="colour">The colour to set.</param>
        public void SetPixel(int x, int y, Colour colour)
        {
            _data[y, x] = colour;
        }
    }
}