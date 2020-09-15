using System.IO;

namespace ByteDev.Testing.NUnit.IntTests
{
    public class DirHelper
    {
        private readonly DirectoryInfo _baseDirPath;

        public DirHelper(DirectoryInfo baseDirPath)
        {
            _baseDirPath = baseDirPath;
        }

        public FileInfo CreateFile(string fileName, string content = "test")
        {
            var path = Path.Combine(_baseDirPath.FullName, fileName);

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(content);
            }

            return new FileInfo(path);
        }

        public DirectoryInfo CreateDirectory(string dirName)
        {
            var path = Path.Combine(_baseDirPath.FullName, dirName);

            return Directory.CreateDirectory(path);
        }
    }
}