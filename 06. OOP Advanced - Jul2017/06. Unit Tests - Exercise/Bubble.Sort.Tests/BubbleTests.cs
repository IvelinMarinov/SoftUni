using Bubble.Sort;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bubble.Sort.Tests
{
    [TestFixture]
    public class BubbleTests
    {
        [Test]
        public void CreateBubbleList()
        {
            //Arrange & Act
            Bubble<int> bubble = new Bubble<int>(5, 3, 4, 1, 2);
            List<int> expectedOutput = new List<int>() { 1, 2, 3, 4, 5};

            //Assert
            Assert.AreEqual(expectedOutput, bubble);
        }

        [Test]
        public void SortOneItemList()
        {
            //Arrange & Act
            Bubble<int> bubble = new Bubble<int>(10);
            List<int> expectedOutput = new List<int>() { 10 };

            //Assert
            Assert.AreEqual(expectedOutput, bubble);
        }

        [Test]
        public void CreateBubbleAddElementAndSort()
        {
            //Arrange & Act
            Bubble<int> bubble = new Bubble<int>(5, 3, 4, 6, 2);
            
            //Act
            bubble.Add(1);
            List<int> expectedOutput = new List<int>() {1, 2, 3, 4, 5, 6};

            //Assert
            Assert.AreEqual(expectedOutput, bubble);

        }
    }
}
