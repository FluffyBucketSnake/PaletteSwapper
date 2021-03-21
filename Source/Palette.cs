using System;
using System.Collections;
using System.Collections.Generic;

namespace PaletteSwapper
{
    /// <summary>
    /// Represents a collection of colors.
    /// </summary>
    public class Palette : IEnumerable<Colour>
    {
        private Colour[] _colours;

        /// <summary>
        /// Creates a new palette with <paramref name="count"/> colours.
        /// </summary>
        /// <param name="count">The number of colours that the palette supports.</param>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="count"/> is
        /// negative.</exception>
        public Palette(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("The amount of colours cannot be negative.");
            }

            _colours = new Colour[count];
        }

        public Palette(params Colour[] colours)
        {
            // Copy array.
            _colours = (Colour[])colours.Clone();
        }

        /// <summary>
        /// Gets the number of colours in this palette.
        /// </summary>
        public int Count => _colours.Length;

        /// <summary>
        /// Indexes each colour in this palette.
        /// </summary>
        /// <value>The colour in the specified index.</value>
        public Colour this[int index]
        {
            get => GetColour(index);
            set => SetColour(index, value);
        }

        public Colour GetColour(int index)
        {
            return _colours[index];
        }

        public void SetColour(int index, Colour colour)
        {
            _colours[index] = colour;
        }

        public IEnumerator<Colour> GetEnumerator()
        {
            return (IEnumerator<Colour>)_colours.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _colours.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            // Chech if obj is a Palette instance.
            if (obj is Palette other)
            {
                // Check if they have the same amount of colours.
                if (this.Count != other.Count)
                {
                    return false;
                }
                
                // Compare each colour from both palettes. Order matters.
                for (int i = 0; i < this.Count; i++)
                {
                    if (this._colours[i] != other._colours[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Loads a set of palettes from a file. Each column is a distinct palette.
        /// </summary>
        /// <param name="path">The file path to the palette file.</param>
        /// <returns>An array of palettes.</returns>
        public static Palette[] Load(string path)
        {
            var source = ImageBitmap.Load(path);

            int pcount = source.Width;
            int ccount = source.Height;

            var palettes = new Palette[pcount];
            for (int x = 0; x < pcount; x++)
            {
                Palette palette = new(ccount);
                for (int y = 0; y < ccount; y++)
                {
                    palette[y] = source[x, y];
                }
                palettes[x] = palette;
            }

            return palettes;
        }
    }
}