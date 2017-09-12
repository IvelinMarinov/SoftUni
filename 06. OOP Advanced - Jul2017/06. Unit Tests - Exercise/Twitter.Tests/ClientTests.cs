using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Twitter.Problem;

namespace Twitter.Tests
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void ConstructorTest()
        {
            //Arrange
            Client client = new Client();

            //Assert
            Assert.AreEqual(0, client.Tweets.Count);
        }

        [Test]
        public void MakeTweet()
        {
            //Arrange
            Client client = new Client();

            //Act
            client.Tweet(new Tweet("Hi"));

            //Assert
            Assert.AreEqual(1, client.Tweets.Count);
        }

        [Test]
        public void ShowLastTweetWhenNoTweets()
        {
            //Arrange
            Client client = new Client();
            
            //Assert
            Assert.Throws<InvalidOperationException>(() => client.ShowLastTweet());
        }
    }
}
