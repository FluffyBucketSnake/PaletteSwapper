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
            set => this._palette = value ?? throw new System.ArgumentNullException();
        }

        /// <summary>
        /// Gets the indexed data at the specified xy coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The data represented by the index.</returns>
        public Colour GetIndexedData(int x, int y)
        {
            return this._palette[(int)this[x, y]];
        }
    }
}