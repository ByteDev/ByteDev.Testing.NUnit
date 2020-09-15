using System.IO;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit.IntTests
{
    [TestFixture]
    [NonParallelizable]
    public class AssertFileTests : TestBase
    {
        [TestFixture]
        public class AreSame : AssertFileTests
        {
            [Test]
            public void WhenTwoFilesAreEqual_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertFile.AreSame(TestFiles.GifImage, TestFiles.GifImage));
            }

            [Test]
            public void WhenTwoFilesAreNotEqual_ThenAssertFalse()
            {
                Assert.Throws<AssertionException>(() => AssertFile.AreSame(TestFiles.GifImage, TestFiles.PngImage));
            }
        }

        [TestFixture]
        public class Exists : AssertFileTests
        {
            [Test]
            public void WhenFileDoesNotExist_ThenAssertFalse()
            {
                Assert.Throws<AssertionException>(() => AssertFile.Exists(DoesNotExistFile));
            }

            [Test]
            public void WhenFileExists_ThenAssertTrue()
            {
                const string file1 = "Exists-File1.txt";

                BaseDir.CreateFile(file1);

                Assert.DoesNotThrow(() => AssertFile.Exists(Path.Combine(ExistingDirectoryPath, file1)));
            }
        }

        [TestFixture]
        public class NotExists : AssertFileTests
        {
            [Test]
            public void WhenFileExists_ThenAssertFalse()
            {
                const string file1 = "NotExists-File1.txt";

                BaseDir.CreateFile(file1);

                Assert.Throws<AssertionException>(() => AssertFile.NotExists(Path.Combine(ExistingDirectoryPath, file1)));
            }

            [Test]
            public void WhenFileDoesNotExist_ThenAssertTrue()
            {
                Assert.DoesNotThrow(() => AssertFile.NotExists(DoesNotExistFile));
            }
        }

        [TestFixture]
        public class HasMoved : AssertFileTests
        {
            [Test]
            public void WhenOriginalFileDoesNotExist_AndTargetExists_ThenAssertTrue()
            {
                const string file1 = "HasMoved-File1.txt";

                BaseDir.CreateFile(file1);

                Assert.DoesNotThrow(() => AssertFile.HasMoved(DoesNotExistFile.FullName, Path.Combine(ExistingDirectoryPath, file1)));
            }
        }

        [TestFixture]
        public class SizeEquals : AssertFileTests
        {
            [Test]
            public void WhenSizeIsEqual_ThenAssertTrue()
            {
                var file1 = BaseDir.CreateFile("SizeEquals-Test1.txt");
                var file2 = BaseDir.CreateFile("SizeEquals-Test2.txt");

                Assert.DoesNotThrow(() => AssertFile.SizeEquals(file1, file2));
            }

            [Test]
            public void WhenSizeIsNotEqual_ThenAssertFalse()
            {
                var file1 = BaseDir.CreateFile("SizeEquals-Test1.txt", "test1");
                var file2 = BaseDir.CreateFile("SizeEquals-Test2.txt", "test12");

                Assert.Throws<AssertionException>(() => AssertFile.SizeEquals(file1, file2));
            }

            [Test]
            public void WhenSizeIsEqualNumber_ThenAssertTrue()
            {
                var file1 = BaseDir.CreateFile("SizeEquals-Test1.txt", "test1");

                Assert.DoesNotThrow(() => AssertFile.SizeEquals(file1, 5));
            }

            [Test]
            public void WhenSizeIsNotEqualNumber_ThenAssertFalse()
            {
                var file1 = BaseDir.CreateFile("SizeEquals-Test1.txt", "test1");

                Assert.Throws<AssertionException>(() => AssertFile.SizeEquals(file1, 6));
            }
        }
    }
}