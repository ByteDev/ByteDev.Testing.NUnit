using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace ByteDev.Testing.NUnit
{
    /// <summary>
    /// Represents assertions relating to images.
    /// </summary>
    public static class AssertImage
    {
        /// <summary>
        /// Assert a image file has a certain width.
        /// </summary>
        /// <param name="imageFilePath">Path of image file to check.</param>
        /// <param name="expectedWidth">Expected width in pixels.</param>
        public static void WidthEquals(string imageFilePath, int expectedWidth)
        {
            var image = LoadImage(imageFilePath);

            WidthEquals(image, expectedWidth);
        }

        /// <summary>
        /// Assert a image has a certain width.
        /// </summary>
        /// <param name="image">Image to check.</param>
        /// <param name="expectedWidth">Expected width in pixels.</param>
        public static void WidthEquals(Image image, int expectedWidth)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var actualwith = image.Width;

            Assert.That(actualwith, Is.EqualTo(expectedWidth), $"Width of image was expected to be {expectedWidth} but actual {actualwith}.");
        }

        /// <summary>
        /// Assert a image file has a certain height.
        /// </summary>
        /// <param name="imageFilePath">Path of image file to check.</param>
        /// <param name="expectedHeight">Expected height in pixels.</param>
        public static void HeightEquals(string imageFilePath, int expectedHeight)
        {
            var image = LoadImage(imageFilePath);

            HeightEquals(image, expectedHeight);
        }

        /// <summary>
        /// Assert a image has a certain height.
        /// </summary>
        /// <param name="image">Image to check.</param>
        /// <param name="expectedHeight">Expected height in pixels.</param>
        public static void HeightEquals(Image image, int expectedHeight)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var actualHeight = image.Height;
            
            Assert.That(actualHeight, Is.EqualTo(expectedHeight), $"Height of image was expected to be {expectedHeight} but actual {actualHeight}.");
        }
        
        private static Image LoadImage(string imageFilePath)
        {
            var stream = new MemoryStream(File.ReadAllBytes(imageFilePath));

            return Image.FromStream(stream);
        }
    }
}