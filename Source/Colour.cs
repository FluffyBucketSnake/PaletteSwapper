namespace PaletteSwapper
{
    /// <summary>
    /// Represents a 32-bit RGBA colour.
    /// </summary>
    public struct Colour
    {
        private uint _data;

        /// <summary>
        /// Initializes a new instance of <see cref="PaletteSwapper.Colour"> struct.
        /// </summary>
        /// <param name="raw_data">An unsigned 32-bit integer representing the colour
        /// in the RGBA format.</param>
        public Colour(uint raw_data)
        {
            _data = raw_data;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PaletteSwapper.Colour"> struct.
        /// </summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha component.</param>
        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            _data = ((uint)red << 24) | ((uint)green << 16) | ((uint)blue << 8) | (uint)alpha;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PaletteSwapper.Colour"> struct.
        /// </summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha component.</param>
        public Colour(float red, float green, float blue, float alpha)
            : this((byte)(red * 255), (byte)(green * 255), (byte)(blue * 255), (byte)(alpha * 255))
        {
        }

        /// <summary>
        /// Gets or sets the red component.
        /// </summary>
        public byte R
        {
            get => (byte)(this._data >> 24);
            set => this._data = (this._data & 0x00FFFFFF) | ((uint)value << 24);
        }


        /// <summary>
        /// Gets or sets the green component.
        /// </summary>
        public byte G
        {
            get => (byte)(this._data >> 16);
            set => this._data = (this._data & 0xFF00FFFF) | ((uint)value << 24);
        }


        /// <summary>
        /// Gets or sets the blue component.
        /// </summary>
        public byte B
        {
            get => (byte)(this._data >> 8);
            set => this._data = (this._data & 0xFFFF00FF) | ((uint)value << 8);
        }


        /// <summary>
        /// Gets or sets the alpha component.
        /// </summary>
        public byte A
        {
            get => (byte)this._data;
            set => this._data = (this._data & 0xFFFFFF00) | (uint)value;
        }

        /// <summary>
        /// (R: 255, G: 255, B: 255, A: 255)
        /// <summary>
        public static readonly Colour White = new(0xFFFFFFFF);

        /// <summary>
        /// (R: 0, G: 0, B: 0, A: 255)
        /// <summary>
        public static readonly Colour Black = new(0x000000FF);

        /// <summary>
        /// (R: 255, G: 0, B: 0, A: 255)
        /// <summary>
        public static readonly Colour Red = new(0xFF0000FF);

        /// <summary>
        /// (R: 0, G: 255, B: 0, A: 255)
        /// <summary>
        public static readonly Colour Green = new(0x00FF00FF);

        /// <summary>
        /// (R: 0, G: 0, B: 255, A: 255)
        /// <summary>
        public static readonly Colour Blue = new(0x0000FFFF);

        public static bool operator==(Colour a, Colour b)
        {
            return a._data == b._data;
        }

        public static bool operator!=(Colour a, Colour b)
        {
            return a._data != b._data;
        }

        public override bool Equals(object obj)
        {
            if (obj is Colour other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this._data.GetHashCode();
        }
    }
}