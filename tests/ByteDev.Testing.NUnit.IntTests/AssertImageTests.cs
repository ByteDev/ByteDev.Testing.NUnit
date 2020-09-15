using NUnit.Framework;

namespace ByteDev.Testing.NUnit.IntTests
{
    [TestFixture]
    [NonParallelizable]
    public class AssertImageTests : TestBase
    {
        [TestFixture]
        public class WidthEquals : AssertImageTests
        {
            [TestCase(TestFiles.PngImage)]
            [TestCase(TestFiles.JpgImage)]
            [TestCase(TestFiles.GifImage)]
            public void WhenImageIsExpectedWidth_ThenAssertTrue(string filePath)
            {
                Assert.DoesNotThrow(() => AssertImage.WidthEquals(filePath, 200));
            }

            [TestCase(TestFiles.PngImage)]
            [TestCase(TestFiles.JpgImage)]
            [TestCase(TestFiles.GifImage)]
            public void WhenImageIsNotExpectedWidth_ThenAssertFalse(string filePath)
            {
                Assert.Throws<AssertionException>(() => AssertImage.WidthEquals(filePath, 201));
            }
        }

        [TestFixture]
        public class HeightEquals : AssertImageTests
        {
            [TestCase(TestFiles.PngImage)]
            [TestCase(TestFiles.JpgImage)]
            [TestCase(TestFiles.GifImage)]
            public void WhenImageIsExpectedHeight_ThenAssertTrue(string filePath)
            {
                Assert.DoesNotThrow(() => AssertImage.HeightEquals(filePath, 100));
            }

            [TestCase(TestFiles.PngImage)]
            [TestCase(TestFiles.JpgImage)]
            [TestCase(TestFiles.GifImage)]
            public void WhenImageIsNotExpectedHeight_ThenAssertFalse(string filePath)
            {
                Assert.Throws<AssertionException>(() => AssertImage.HeightEquals(filePath, 101));
            }
        }
    }
}