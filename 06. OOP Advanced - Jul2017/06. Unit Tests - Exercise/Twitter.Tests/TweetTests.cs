using System;
using NUnit.Framework;
using Twitter.Problem;

namespace Twitter.Tests
{
    [TestFixture]
    public class TweetTests
    {
        public const int MessageLimit = 255;

        [Test]
        public void ConstructorGeneralMessasge()
        {
            //Arrange
            Tweet tweet = new Tweet("Hello");

            //Assert
            Assert.AreEqual("Hello", tweet.Message);
        }

        [Test]
        public void ConstructorEmptyMessage()
        {
            //Arrange
            string emptyMessage = string.Empty;

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Tweet(emptyMessage));
        }

        [Test]
        public void ConstructorMessageAboveLimit()
        {
            //Arrange
            string longMessage = new string('x', MessageLimit + 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Tweet(longMessage));
        }
    }
}
