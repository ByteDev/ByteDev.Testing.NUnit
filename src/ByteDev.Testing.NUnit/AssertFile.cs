﻿using System;
using System.IO;
using ByteDev.Crypto;
using ByteDev.Crypto.Hashing;
using ByteDev.Crypto.Hashing.Algorithms;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit
{
    /// <summary>
    /// Represents assertions relating to files.
    /// </summary>
    public static class AssertFile
    {
        /// <summary>
        /// Asserts two file have the same contents (does not check the file
        /// names are the same).
        /// </summary>
        /// <param name="actualFile">Actual file in the comparison.</param>
        /// <param name="expectedFile">Expected file in the comparison.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expectedFile" /> is null.</exception>
        public static void AreSame(FileInfo actualFile, FileInfo expectedFile)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            if (expectedFile == null)
                throw new ArgumentNullException(nameof(expectedFile));

            AreSame(actualFile.FullName, expectedFile.FullName);
        }

        /// <summary>
        /// Asserts two file have the same contents (does not check the file
        /// names are the same).
        /// </summary>
        /// <param name="actualFilePath">Path to actual file in the comparison.</param>
        /// <param name="expectedFilePath">Path to expected file in the comparison.</param>
        public static void AreSame(string actualFilePath, string expectedFilePath)
        {
            var service = new FileChecksumService(new Md5Algorithm(), EncodingType.Base64);
            
            var actualHash = service.Calculate(actualFilePath);
            var expectedHash = service.Calculate(expectedFilePath);

            Assert.That(actualHash, Is.EqualTo(expectedHash));
        }

        /// <summary>
        /// Asserts a file exists.
        /// </summary>
        /// <param name="actualFile">File to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void Exists(FileInfo actualFile)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            Exists(actualFile.FullName);
        }

        /// <summary>
        /// Asserts a file exists.
        /// </summary>
        /// <param name="actualFilePath">Path of file to check.</param>
        public static void Exists(string actualFilePath)
        {
            Assert.That(File.Exists(actualFilePath), Is.True, $"'{actualFilePath}' does not exist.");
        }
        
        /// <summary>
        /// Asserts a file does not exist.
        /// </summary>
        /// <param name="actualFile">File to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void NotExists(FileInfo actualFile)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            NotExists(actualFile.FullName);
        }

        /// <summary>
        /// Asserts a file does not exist.
        /// </summary>
        /// <param name="actualFilePath">Path of file to check.</param>
        public static void NotExists(string actualFilePath)
        {
            Assert.That(File.Exists(actualFilePath), Is.False, $"'{actualFilePath}' does exist.");
        }

        /// <summary>
        /// Asserts a file exists in one location and not another.
        /// </summary>
        /// <param name="originalFile">File to check does not exist.</param>
        /// <param name="targetFile">File to check does exist.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="originalFile" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="targetFile" /> is null.</exception>
        public static void HasMoved(FileInfo originalFile, FileInfo targetFile)
        {
            NotExists(originalFile);
            Exists(targetFile);
        }

        /// <summary>
        /// Assert a file exists in one location and not another.
        /// </summary>
        /// <param name="originalPath">Path of file to check does not exist.</param>
        /// <param name="targetPath">Path of file to check does exist.</param>
        public static void HasMoved(string originalPath, string targetPath)
        {
            NotExists(originalPath);
            Exists(targetPath);
        }

        /// <summary>
        /// Assert a file is empty.
        /// </summary>
        /// <param name="actualFilePath">Path of file to check.</param>
        public static void IsEmpty(string actualFilePath)
        {
            SizeEquals(actualFilePath, 0);
        }

        /// <summary>
        /// Assert a file is empty.
        /// </summary>
        /// <param name="actualFile">File to check.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void IsEmpty(FileInfo actualFile)
        {
            SizeEquals(actualFile, 0);
        }

        /// <summary>
        /// Assert two files are equal in size.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file in comparison.</param>
        /// <param name="expectedFilePath">Path of expected file in comparison.</param>
        public static void SizeEquals(string actualFilePath, string expectedFilePath)
        {
            SizeEquals(new FileInfo(actualFilePath), new FileInfo(expectedFilePath));
        }

        /// <summary>
        /// Assert two files are equal in size.
        /// </summary>
        /// <param name="actualFile">Actual file in comparison.</param>
        /// <param name="expectedFile">Expected file in comparison.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expectedFile" /> is null.</exception>
        public static void SizeEquals(FileInfo actualFile, FileInfo expectedFile)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            if (expectedFile == null)
                throw new ArgumentNullException(nameof(expectedFile));

            Assert.That(actualFile.Length, Is.EqualTo(expectedFile.Length), $"File1: '{actualFile.FullName}' and File2: '{expectedFile.FullName}' are not the same size.");
        }

        /// <summary>
        /// Assert a file is of a certain size.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file to check.</param>
        /// <param name="expectedSize">Expected size in bytes.</param>
        public static void SizeEquals(string actualFilePath, long expectedSize)
        {
            SizeEquals(new FileInfo(actualFilePath), expectedSize);
        }

        /// <summary>
        /// Assert a file is of a certain size.
        /// </summary>
        /// <param name="actualFile">File to check.</param>
        /// <param name="expectedSize">Expected size in bytes.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void SizeEquals(FileInfo actualFile, long expectedSize)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            var actualSize = actualFile.Length;

            Assert.That(actualSize, Is.EqualTo(expectedSize), $"File: '{actualFile.FullName}' was expected to be {expectedSize} bytes but was actually {actualSize} bytes.");
        }

        /// <summary>
        /// Assert a file is smaller than another file.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file in comparison.</param>
        /// <param name="expectedFilePath">Path of expected file in comparison.</param>
        public static void SizeLessThan(string actualFilePath, string expectedFilePath)
        {
            SizeLessThan(new FileInfo(actualFilePath), new FileInfo(expectedFilePath));
        }

        /// <summary>
        /// Assert a file is smaller than another file.
        /// </summary>
        /// <param name="actualFile">Actual file in comparison.</param>
        /// <param name="expectedFile">Expected file in comparison.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expectedFile" /> is null.</exception>
        public static void SizeLessThan(FileInfo actualFile, FileInfo expectedFile)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            if (expectedFile == null)
                throw new ArgumentNullException(nameof(expectedFile));

            Assert.That(actualFile.Length, Is.LessThan(expectedFile.Length), $"File: '{actualFile.FullName}' was expected to be smaller than file: '{expectedFile.FullName}'.");
        }

        /// <summary>
        /// Assert a file is smaller than a certain size.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file to check.</param>
        /// <param name="expectedSize">Size in bytes.</param>
        public static void SizeLessThan(string actualFilePath, long expectedSize)
        {
            SizeLessThan(new FileInfo(actualFilePath), expectedSize);
        }

        /// <summary>
        /// Assert a file is smaller than a certain size.
        /// </summary>
        /// <param name="actualFile">Actual file to check.</param>
        /// <param name="expectedSize">Size in bytes.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void SizeLessThan(FileInfo actualFile, long expectedSize)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            var actualSize = actualFile.Length;

            Assert.That(actualSize, Is.LessThan(expectedSize), $"File: '{actualFile.FullName}' was expected to be less than {expectedSize} bytes but was actually {actualSize} bytes.");
        }
        
        /// <summary>
        /// Assert a file is greater than another file.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file in comparison.</param>
        /// <param name="expectedFilePath">Path of expected file in comparison.</param>
        public static void SizeGreaterThan(string actualFilePath, string expectedFilePath)
        {
            SizeGreaterThan(new FileInfo(actualFilePath), new FileInfo(expectedFilePath));
        }

        /// <summary>
        /// Assert a file is greater than another file.
        /// </summary>
        /// <param name="actualFile">Actual file in comparison.</param>
        /// <param name="expectedFile">Expected file in comparison.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expectedFile" /> is null.</exception>
        public static void SizeGreaterThan(FileInfo actualFile, FileInfo expectedFile)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            if (expectedFile == null)
                throw new ArgumentNullException(nameof(expectedFile));

            Assert.That(actualFile.Length, Is.GreaterThan(expectedFile.Length), $"File: '{actualFile.FullName}' was expected to be larger than file: '{expectedFile.FullName}'.");
        }
        
        /// <summary>
        /// Assert a file is greater than a certain size.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file to check.</param>
        /// <param name="expectedSize">Size in bytes.</param>
        public static void SizeGreaterThan(string actualFilePath, long expectedSize)
        {
            SizeGreaterThan(new FileInfo(actualFilePath), expectedSize);
        }

        /// <summary>
        /// Assert a file is greater than a certain size.
        /// </summary>
        /// <param name="actualFile">Actual file to check.</param>
        /// <param name="expectedSize">Size in bytes.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void SizeGreaterThan(FileInfo actualFile, long expectedSize)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            var actualSize = actualFile.Length;

            Assert.That(actualSize, Is.GreaterThan(expectedSize), $"File: '{actualFile.FullName}' was expected to be greater than {expectedSize} bytes but was actually {actualSize} bytes.");
        }

        /// <summary>
        /// Assert a file's contents equals a given string.
        /// </summary>
        /// <param name="actualFile">Actual file to check.</param>
        /// <param name="expectedContent">Expected content.</param>
        /// <param name="encoding">Text encoding.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void ContentEquals(FileInfo actualFile, string expectedContent, System.Text.Encoding encoding = null)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            ContentEquals(actualFile.FullName, expectedContent, encoding);
        }

        /// <summary>
        /// Assert a file's contents equals a given string.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file to check.</param>
        /// <param name="expectedContent">Expected content.</param>
        /// <param name="encoding">Text encoding.</param>
        public static void ContentEquals(string actualFilePath, string expectedContent, System.Text.Encoding encoding = null)
        {
            if (encoding == null)
                encoding = System.Text.Encoding.UTF8;

            using (var sr = new StreamReader(actualFilePath, encoding))
            {
                var actualContents = sr.ReadToEnd();
                Assert.That(actualContents, Is.EqualTo(expectedContent), $"File: '{actualFilePath}' does not contain the expected contents.");
            }
        }

        /// <summary>
        /// Assert a file has been modfied since a given DateTime.
        /// </summary>
        /// <param name="actualFilePath">Path of actual file to check.</param>
        /// <param name="since">DateTime since.</param>
        public static void ModifiedSince(string actualFilePath, DateTime since)
        {
            ModifiedSince(new FileInfo(actualFilePath), since);
        }

        /// <summary>
        /// Assert a file has been modfied since a given DateTime.
        /// </summary>
        /// <param name="actualFile">Actual file to check.</param>
        /// <param name="since">DateTime since.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="actualFile" /> is null.</exception>
        public static void ModifiedSince(FileInfo actualFile, DateTime since)
        {
            if (actualFile == null)
                throw new ArgumentNullException(nameof(actualFile));

            Assert.That(actualFile.LastWriteTime, Is.GreaterThan(since));
        }
    }
}
