using System.IO;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit.IntTests
{
    [TestFixture]
    [NonParallelizable]
    public class AssertDirTests : TestBase
    {
        [TestFixture]
        public class Exists : AssertDirTests
        {
            [Test]
            public void WhenDirectoryDoesNotExist_ThenAssertFalse()
            {
                Assert.Throws<AssertionException>(() => AssertDir.Exists(DoesNotExistDirectory));
            }

            [Test]
            public void WhenDirectoryExists_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertDir.Exists(ExistingDirectory));
            }
        }

        [TestFixture]
        public class NotExists : AssertDirTests
        {
            [Test]
            public void WhenDirectoryExists_ThenAssertFalse()
            {
                Assert.Throws<AssertionException>(() => AssertDir.NotExists(ExistingDirectory));
            }

            [Test]
            public void WhenDirectoryDoesNotExist_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertDir.NotExists(DoesNotExistDirectory));
            }
        }

        [TestFixture]
        public class IsEmpty : AssertDirTests
        {
            [Test]
            public void WhenDirectoryIsEmpty_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertDir.IsEmpty(ExistingDirectory));
            }

            [Test]
            public void WhenDirectoryHasFiles_ThenAssertFalse()
            {
                BaseDir.CreateFile(Path.Combine(ExistingDirectory.FullName, "TestFile1.txt"));

                Assert.Throws<AssertionException>(() => AssertDir.IsEmpty(ExistingDirectory));
            }

            [Test]
            public void WhenDirectoryHasDirectories_ThenAssertFalse()
            {
                BaseDir.CreateDirectory("Test-IsEmpty");

                Assert.Throws<AssertionException>(() => AssertDir.IsEmpty(ExistingDirectory));
            }
        }

        [TestFixture]
        public class HasNoFiles : AssertDirTests
        {
            [Test]
            public void WhenDirectoryHasNoFiles_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertDir.HasNoFiles(ExistingDirectory));
            }

            [Test]
            public void WhenDirectoryHasFiles_ThenAssertFalse()
            {
                BaseDir.CreateFile("Test-HasNoFiles.txt");

                Assert.Throws<AssertionException>(() => AssertDir.HasNoFiles(ExistingDirectory));
            }
        }

        [TestFixture]
        public class HasNoDirectories : AssertDirTests
        {
            [Test]
            public void WhenDirectoryHasNoDirectories_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertDir.HasNoDirectories(ExistingDirectory));
            }

            [Test]
            public void WhenDirectoryHasDirectories_ThenAssertFalse()
            {
                BaseDir.CreateDirectory("Test-HasNoDirectories");

                Assert.Throws<AssertionException>(() => AssertDir.HasNoDirectories(ExistingDirectory));
            }
        }

        [TestFixture]
        public class ContainsFiles : AssertDirTests
        {
            [Test]
            public void WhenDirectoryHasFiles_ThenAssertTrue()
            {
                BaseDir.CreateFile("Test-ContainsFiles1.txt");
                BaseDir.CreateFile("Test-ContainsFiles2.txt");

                Assert.DoesNotThrow(() => AssertDir.ContainsFiles(ExistingDirectory, 2));
            }
        }

        [TestFixture]
        public class ContainsDirectories : AssertDirTests
        {
            [Test]
            public void WhenDirectoryHasDirectories_ThenAssertTrue()
            {
                BaseDir.CreateDirectory("Test-ContainsDir1");
                BaseDir.CreateDirectory("Test-ContainsDir2");

                Assert.DoesNotThrow(() => AssertDir.ContainsDirectories(ExistingDirectory, 2));
            }
        }
    }
}