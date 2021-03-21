using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaletteSwapper.UnitTest
{
    [TestClass]
    public class BitmapTest
    {
        public static Colour[] bitmap0Data = new Colour[] 
        {
            Colour.White,
            Colour.Red,
            Colour.Green,
            Colour.Blue
        };

        [TestMethod]
        [DeploymentItem("bitmap0.png")]
        public void Load()
        {
            {
                ImageBitmap bitmap = ImageBitmap.Load("bitmap0.png");
                CollectionAssert.AreEqual(bitmap0Data, bitmap.GetData());
            }
        }
    }
}