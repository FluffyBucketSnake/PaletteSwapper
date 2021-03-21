using System.Collections.Generic;

namespace PaletteSwapper
{
    /// <summary>
    /// Represents a bitmap of indexes, with an associated palette for colour lookup.
    /// </summary>
    public class IndexedBitmap : Bitmap<int>
    {
        private Palette _palette;

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.IndexedBitmap"/> filled with copies of a 
        /// single value.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="palette">The associated palette for data lookup.</param>
        /// <param name="value">The value used to fill the buffer.</param>
        /// <exception cref="System.ArgumentException">Thrown when either 
        /// <paramref name="width"/> or <paramref name="height"/> are smaller or equal 
        /// to zero.</exception>
        public IndexedBitmap(int width, int height, Palette palette, int value)
            : base(width, height, value)
        {
            this.Palette = palette;
        }

        /// <summary>
        /// Creates a new <see cref="PaletteSwapper.IndexedBitmap"/> from an already existing 
        /// index buffer.
        /// The buffer data must be in the form of a sequence of rows.
        /// </summary>
        /// <param name="width">The width of the bitmap.</param>
        /// <param name="height">The height of the bitmap.</param>
        /// <param name="palette">The associated palette for data lookup.</param>
        /// <param name="data">The source buffer from which the data will be copied.</param>
        /// <exception cref="System.ArgumentException">Thrown when 
        /// <paramref name="data"/> length is smaller than <paramref name="width"/>
        ///  * <paramref name="height"/>, or if either <paramref name="width"/> or
        /// <paramref name="height"/> are smaller or equal to zero.</exception>
        public IndexedBitmap(int width, int height, Palette palette, int[] data)
            : base(width, height, data)
        {
            this.Palette = palette;
        }

        /// <summary>
        /// The palette used for data lookup.
        /// </summary>
        public Palette Palette
        {
            get => this._palette;
            set => this._palette = value ?? throw new System.ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the dereferenced value at the specified xy coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The unindexed value located at the coordinates.</returns>
        public Colour GetDerefValue(int x, int y)
        {
            return this._palette[(int)this[x, y]];
        }

        /// <summary>
        /// Creates a copy of this bitmap with unindexed values.
        /// </summary>
        public ImageBitmap Dereference()
        {
            int width = this.Width;
            int height = this.Height;
            var data = new Colour[width * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    data[(y * width) + x] = this.GetDerefValue(x, y);
                }
            }

            return new ImageBitmap(width, height, data);
        }

        public static IndexedBitmap FromBitmap(ImageBitmap bitmap, Palette palette)
        {
            // Null-check.
            if (bitmap == null)
            {
                throw new System.ArgumentNullException(nameof(bitmap));
            }
            if (palette == null)
            {
                throw new System.ArgumentNullException(nameof(palette));
            }

            // Initialize data array.
            int width = bitmap.Width;
            int height = bitmap.Height;
            var data = new int[width * height];

            // Create lookup table for palette colours. 
            // Prioritize colours with lower indexes.
            var table = new Dictionary<Colour, int>();
            for (int i = palette.Count - 1; i >= 0; i--)
            {
                Colour colour = palette[i];
                if (!table.ContainsKey(colour))
                {
                    table.Add(colour, i);
                }
            }

            // Fill data array with indexes from the dictionary.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    data[(y * width) + x] = table[bitmap.GetValue(x, y)];
                }
            }

            return new IndexedBitmap(width, height, palette, data);
        }
    }
}