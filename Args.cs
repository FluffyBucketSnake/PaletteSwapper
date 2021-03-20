namespace PaletteSwapper
{
    /// <summary>
    /// Represents the collection of formatted command-line arguments of the program.
    /// </summary>
    public class Args
    {
        /// <summary>
        /// The file path to the source image.
        /// </summary>
        public string SourcePath;

        /// <summary>
        /// The file path to the palette table file.
        /// </summary>
        public string PaletteTablePath;

        /// <summary>
        /// The palette index of the source image.
        /// </summary>
        public int SourcePaletteIndex;

        /// <summary>
        /// The palette index of the destination image.
        /// </summary>
        public int TargetPaletteIndex;

        /// <summary>
        /// The file path of the output image.
        /// </summary>
        public string DestinationPath;

        
        /// <summary>
        /// Creates an <see cref="PaletteSwapper.Args"/> instance from parsing a collection of 
        /// tokens.
        /// </summary>
        /// <param name="startIndex">The index of the first token to read.</param>
        /// <param name="tokens">An array of string, each representing a token.</param>
        public static Args Parse(int startIndex, string[] tokens)
        {
            Args results = new Args();

            // Validate length.
            int length = tokens.Length - startIndex;
            if (length < 4 || length > 5)
            {
                throw new System.ArgumentException();
            }

            // Parse tokens.
            int i = 0;
            results.SourcePath = tokens[startIndex + i++];
            results.PaletteTablePath = tokens[startIndex + i++];
            if (length == 5)
            {
                results.SourcePaletteIndex = int.Parse(tokens[startIndex + i++]);
            }
            results.TargetPaletteIndex = int.Parse(tokens[startIndex + i++]);
            results.DestinationPath = tokens[startIndex + i++];

            return results;
        }
    }
}