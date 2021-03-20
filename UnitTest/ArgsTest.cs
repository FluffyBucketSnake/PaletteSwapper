using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaletteSwapper;

namespace PaletteSwapper.UnitTest
{
    [TestClass]
    public class ArgsTest
    {
        [TestMethod]
        public void ParseFrom()
        {
            // Source-Palette-TargetIndex-Destination
            {
                var args = new string[] { "a/b.png", "a/c.png", "1", "a/d.png" };
                var result = Args.Parse(0, args);
                Assert.AreEqual(result.SourcePath, "a/b.png");
                Assert.AreEqual(result.PaletteTablePath, "a/c.png");
                Assert.AreEqual(result.SourcePaletteIndex, 0);
                Assert.AreEqual(result.TargetPaletteIndex, 1);
                Assert.AreEqual(result.DestinationPath, "a/d.png");
            }
            
            // Source-Palette-SourceIndex-TargetIndex-Destination
            {
                var args = new string[] { "a/b.png", "a/c.png", "2", "1", "a/d.png" };
                var result = Args.Parse(0, args);
                Assert.AreEqual(result.SourcePath, "a/b.png");
                Assert.AreEqual(result.PaletteTablePath, "a/c.png");
                Assert.AreEqual(result.SourcePaletteIndex, 2);
                Assert.AreEqual(result.TargetPaletteIndex, 1);
                Assert.AreEqual(result.DestinationPath, "a/d.png");
            }
            
            // Different start index.
            {
                var args = new string[] { "palswp", "a/b.png", "a/c.png", "1", "a/d.png" };
                var result = Args.Parse(1, args);
                Assert.AreEqual(result.SourcePath, "a/b.png");
                Assert.AreEqual(result.PaletteTablePath, "a/c.png");
                Assert.AreEqual(result.SourcePaletteIndex, 0);
                Assert.AreEqual(result.TargetPaletteIndex, 1);
                Assert.AreEqual(result.DestinationPath, "a/d.png");
            }

            // Few args.
            Assert.ThrowsException<System.ArgumentException>(() => 
            {
                var args = new string[] { "a", "b", "0" };
                Args.Parse(0, args);
            });

            // Few args. with different start index.
            Assert.ThrowsException<System.ArgumentException>(() => 
            {
                var args = new string[] { "a", "b", "0", "c" };
                Args.Parse(1, args);
            });

            // Too many arguments.
            Assert.ThrowsException<System.ArgumentException>(() => 
            {
                var args = new string[] { "a", "b", "0", "1", "c", "d" };
                Args.Parse(0, args);
            });

            // Invalid arguments.
            Assert.ThrowsException<System.FormatException>(() => 
            {
                var args = new string[] { "a", "b", "c", "d" };
                Args.Parse(0, args);
            });

            Assert.ThrowsException<System.FormatException>(() => 
            {
                var args = new string[] { "a", "b", "0", "c", "d" };
                Args.Parse(0, args);
            });
        }
    }
}
