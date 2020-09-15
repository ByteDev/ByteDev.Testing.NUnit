using System;
using System.Drawing;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit.UnitTests
{
    [TestFixture]
    public class AssertImageTests
    {
        [TestFixture]
        public class WidthEquals : AssertImageTests
        {
            [Test]
            public void WhenImageIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => AssertImage.WidthEquals(null as Image, 200));
            }
        }

        [TestFixture]
        public class HeightEquals : AssertImageTests
        {
            [Test]
            public void WhenImageIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => AssertImage.HeightEquals(null as Image, 200));
            }
        }
    }
}