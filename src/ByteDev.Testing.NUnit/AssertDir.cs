using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit
{
    /// <summary>
    /// Represents assertions relatng to directories.
    /// </summary>
    public static class AssertDir
    {
        /// <summary>
        /// Asserts a directory exists.
        /// </summary>
        /// <param name="dirInfo">Directory to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void Exists(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));

            Exists(dirInfo.FullName);
        }

        /// <summary>
        /// Asserts a directory exists.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        public static void Exists(string path)
        {
            Assert.That(Directory.Exists(path), Is.True, $"'{path}' does not exist.");
        }

        /// <summary>
        /// Asserts a directory does not exist.
        /// </summary>
        /// <param name="dirInfo">Directory to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void NotExists(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));
            
            NotExists(dirInfo.FullName);
        }

        /// <summary>
        /// Asserts a directory does not exist.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        public static void NotExists(string path)
        {
            Assert.That(Directory.Exists(path), Is.False, $"'{path}' does exist.");
        }

        /// <summary>
        /// Asserts a directory is empty.
        /// </summary>
        /// <param name="dirInfo">Directory to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void IsEmpty(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));

            IsEmpty(dirInfo.FullName);
        }

        /// <summary>
        /// Asserts a directory is empty.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        public static void IsEmpty(string path)
        {
            Assert.That(Directory.EnumerateFileSystemEntries(path).Any(), Is.False, $"'{path}' is not empty (it has files and/or directories).");
        }

        /// <summary>
        /// Asserts a directory has no sub directories.
        /// </summary>
        /// <param name="dirInfo">Directory to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void HasNoDirectories(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));

            ContainsDirectories(dirInfo, 0);
        }

        /// <summary>
        /// Asserts a directory has no sub directories.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        public static void HasNoDirectories(string path)
        {
            ContainsDirectories(path, 0);
        }
        
        /// <summary>
        /// Asserts a directory contains sub directories.
        /// </summary>
        /// <param name="dirInfo">Directory to check</param>
        /// <param name="expectedNumberOfDirs">Expected number of sub directories.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void ContainsDirectories(DirectoryInfo dirInfo, int expectedNumberOfDirs)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));

            var actualNumberOfDirectories = dirInfo.GetDirectories().Length;

            Assert.That(actualNumberOfDirectories, Is.EqualTo(expectedNumberOfDirs), $"'{dirInfo.FullName}' has {actualNumberOfDirectories} directories but was expecting {expectedNumberOfDirs}.");
        }

        /// <summary>
        /// Asserts a directory contains sub directories.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        /// <param name="expectedNumberOfDirs">Expected number of sub directories.</param>
        public static void ContainsDirectories(string path, int expectedNumberOfDirs)
        {
            ContainsDirectories(new DirectoryInfo(path), expectedNumberOfDirs);
        }
        
        /// <summary>
        /// Asserts a directory contains no files.
        /// </summary>
        /// <param name="dirInfo">Directory to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void HasNoFiles(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));

            ContainsFiles(dirInfo, 0);
        }

        /// <summary>
        /// Asserts a directory contains no files.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        public static void HasNoFiles(string path)
        {
            ContainsFiles(path, 0);
        }
        
        /// <summary>
        /// Asserts a directory contains files.
        /// </summary>
        /// <param name="dirInfo">Directory to check.</param>
        /// <param name="expectedNumberOfFiles">Expected number of files.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dirInfo" /> is null.</exception>
        public static void ContainsFiles(DirectoryInfo dirInfo, int expectedNumberOfFiles)
        {
            if (dirInfo == null)
                throw new ArgumentNullException(nameof(dirInfo));

            var actualNumberOfFiles = dirInfo.GetFiles().Length;

            Assert.That(actualNumberOfFiles, Is.EqualTo(expectedNumberOfFiles), $"'{dirInfo.FullName}' has {actualNumberOfFiles} files but was expected {expectedNumberOfFiles}.");
        }

        /// <summary>
        /// Asserts a directory contains files.
        /// </summary>
        /// <param name="path">Directory path to check.</param>
        /// <param name="expectedNumberOfFiles">Expected number of files.</param>
        public static void ContainsFiles(string path, int expectedNumberOfFiles)
        {
            ContainsFiles(new DirectoryInfo(path), expectedNumberOfFiles);
        }
    }
}
