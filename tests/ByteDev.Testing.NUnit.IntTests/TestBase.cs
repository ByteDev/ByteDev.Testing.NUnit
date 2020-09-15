using System.IO;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit.IntTests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected const string ExistingDirectoryPath = @"C:\Temp\ByteDev.Testing.NUnit.IntTests";

        protected readonly DirectoryInfo ExistingDirectory = new DirectoryInfo(ExistingDirectoryPath);
        
        protected readonly DirectoryInfo DoesNotExistDirectory = new DirectoryInfo(@"C:\DoesNotExist");
        protected readonly FileInfo DoesNotExistFile = new FileInfo(Path.Combine(ExistingDirectoryPath, "DoesNotExist.txt"));

        protected DirHelper BaseDir;

        protected TestBase()
        {
            BaseDir = new DirHelper(ExistingDirectory);
        }

        [SetUp]
        public void SetUp()
        {            
            ExistingDirectory.Create();
        }

        [TearDown]
        public void TearDown()
        {
            ExistingDirectory.Delete(true);            
        }
    }
}