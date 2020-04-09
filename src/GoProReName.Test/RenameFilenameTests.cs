using NUnit.Framework;

namespace GoProReName.Test
{
    public class RenameFilenameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RenameSingleFilename()
        {
            var filename = "GOPR0001.MP4";
            var newFilename = Program.GetNewFilename(filename);
            Assert.AreEqual("000101.MP4", newFilename);
        }

        [Test]
        public void RenameChapteredFilename()
        {
            var filename = "GP010001.MP4";
            var newFilename = Program.GetNewFilename(filename);
            Assert.AreEqual("000102.MP4", newFilename);
        }
    }
}