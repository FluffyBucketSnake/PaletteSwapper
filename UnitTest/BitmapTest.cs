using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaletteSwapper.UnitTest
{
    [TestClass]
    public class BitmapTest
    {
        public static Colour[] bitmap0Data0 = new Colour[]
        {
            Colour.White,
            Colour.Red,
            Colour.Green,
            Colour.Blue
        };

        public static Colour[] bitmap0Data1 = new Colour[]
        {
            Colour.Black,
            Colour.Blue,
            Colour.Red,
            Colour.Green
        };

        [TestMethod]
        [DeploymentItem("bitmap0.png")]
        public void Load()
        {
            {
                ImageBitmap bitmap = ImageBitmap.Load("bitmap0.png");
                CollectionAssert.AreEqual(bitmap0Data0, bitmap.GetData());
            }
        }

        [TestMethod]
        [DeploymentItem("bitmap0.png")]
        [DeploymentItem("bitmap1.png")]
        public void ToIndexedBitmap()
        {
            Palette[] palettes = Palette.Load("bitmap1.png");
            ImageBitmap source = ImageBitmap.Load("bitmap0.png");

            IndexedBitmap result = IndexedBitmap.FromBitmap(source, palettes[0]);
            CollectionAssert.AreEqual(result.GetData(), new int[] { 0, 1, 2, 3 });

            Assert.ThrowsException<System.Collections.Generic.KeyNotFoundException>(() =>
            {
                IndexedBitmap.FromBitmap(source, palettes[1]);
            });
        }

        [TestMethod]
        [DeploymentItem("bitmap0.png")]
        [DeploymentItem("bitmap1.png")]
        public void SwapPalette()
        {
            Palette[] palettes = Palette.Load("bitmap1.png");
            ImageBitmap source = ImageBitmap.Load("bitmap0.png");

            IndexedBitmap intermidiate = IndexedBitmap.FromBitmap(source, palettes[0]);
            intermidiate.Palette = palettes[1];

            ImageBitmap result = intermidiate.Dereference();
            CollectionAssert.AreEqual(result.GetData(), bitmap0Data1);
        }
    }
}