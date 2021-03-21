namespace PaletteSwapper
{
    /// <summary>
    /// Represents a generic bitmap data structure. Useful for storing raw image data.
    /// </summary>
    public class Bitmap<T>
    {
        // A 2D-array holding the data of each pixel. (x, y) pixel indexed as [y, x].
        private T[,] _data;

        private int _width;

        private int _height;

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.Bitmap"/> from an already existing buffer.
        /// The buffer data must be in the form of a sequence of rows.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="data">The source buffer from which the data will be copied.</param>
        /// <exception cref="System.ArgumentException">Thrown when 
        /// <paramref name="data"/> length is smaller than <paramref name="width"/>
        ///  * <paramref name="height"/>, or if either <paramref name="width"/> or
        /// <paramref name="height"/> are smaller or equal to zero.</exception>
        public Bitmap(int width, int height, T[] data)
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
            this._data = new T[_height, _width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    this._data[y, x] = data[(y * width) + x];
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.Bitmap"/> filled with copies of a single
        /// value.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="value">The value used to fill the buffer.</param>
        /// <exception cref="System.ArgumentException">Thrown when either 
        /// <paramref name="width"/> or <paramref name="height"/> are smaller or equal 
        /// to zero.</exception>
        public Bitmap(int width, int height, T value)
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
            this._data = new T[_height, _width];
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    this._data[y, x] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data at the specified xy coordinates of this bitmap.
        /// </summary>
        public T this[int x, int y]
        {
            get => GetValue(x, y);
            set => SetValue(x, y, value);
        }

        /// <summary>
        /// Returns the width of the bitmap.
        /// </summary>
        public int Width => _width;

        /// <summary>
        /// Returns the height of the bitmap.
        /// </summary>
        public int Height => _height;

        /// <summary>
        /// Gets the value at the specified xy coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public T GetValue(int x, int y)
        {
            return _data[y, x];
        }

        /// <summary>
        /// Sets the value at the specified xy coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="value">The new value.</param>
        public void SetValue(int x, int y, T value)
        {
            _data[y, x] = value;
        }

        /// <summary>
        /// Returns a copy of the internal bitmap data. The bitmap data is stored as an
        /// sequence of scanlines.
        /// </summary>
        public T[] GetData()
        {
            var data = new T[_width * _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    data[(y * _width) + x] = GetValue(x, y);
                }
            }

            return data;
        }
    }
}