using System;
using System.Collections;
using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace PaletteSwapper
{
    /// <summary>
    /// Represents a collection of colors.
    /// </summary>
    public class Palette : IEnumerable<Color>
    {
        private Color[] _colours;

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
                throw new ArgumentException(nameof(count));
            }

            _colours = new Color[count];
        }

        public Palette(params Color[] colours)
        {
            // Copy array.
            _colours = (Color[])colours.Clone();
        }

        /// <summary>
        /// Gets the number of colours in this palette.
        /// </summary>
        public int Count => _colours.Length;

        /// <summary>
        /// Indexes each colour in this palette.
        /// </summary>
        /// <value>The colour in the specified index.</value>
        public Color this[int index]
        {
            get => GetColor(index);
            set => SetColor(index, value);
        }
        
        public Color GetColor(int index)
        {
            return _colours[index];
        }

        public void SetColor(int index, Color colour)
        {
            _colours[index] = colour;
        }

        public IEnumerator<Color> GetEnumerator()
        {
            return (IEnumerator<Color>)_colours.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _colours.GetEnumerator();
        }
    }
}