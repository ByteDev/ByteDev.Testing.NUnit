using System;
using System.IO;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit.UnitTests
{
    [TestFixture]
    public class AssertFileTests
    {
        [TestFixture]
        public class Exists : AssertImageTests
        {
            [Test]
            public void WhenFileIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => AssertFile.Exists(null as FileInfo));
            }
        }

        [TestFixture]
        public class NotExists : AssertImageTests
        {
            [Test]
            public void WhenFileIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => AssertFile.NotExists(null as FileInfo));
            }
        }
    }
}