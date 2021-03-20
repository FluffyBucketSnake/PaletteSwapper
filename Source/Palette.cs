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
    }
}