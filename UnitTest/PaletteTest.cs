using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaletteSwapper.UnitTest
{
    [TestClass]
    public class PaletteTest
    {
        [TestMethod]
        [DeploymentItem("bitmap1.png")]
        public void Load()
        {
            {
                Palette expected0 = new(Colour.White, Colour.Red, Colour.Green, Colour.Blue);
                Palette expected1 = new(Colour.Black, Colour.Blue, Colour.Red, Colour.Green);
                Palette[] loaded = Palette.Load("bitmap1.png");
                Assert.AreEqual(expected0, loaded[0]);
                Assert.AreEqual(expected1, loaded[1]);
            }
        }
    }
}