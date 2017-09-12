using System;
using System.Collections.Generic;
using NUnit.Framework;
using ListIterator_Problem;

namespace ListIterator.Tests
{
    [TestFixture]
    public class ListIteratorTests
    {
        [Test]
        public void ConstructorTestCreateCollection()
        {
            //Arrange
            List<int> collection = new List<int>() { 1, 2, 3 };

            //Act
            ListIterator<int> listIterator = new ListIterator<int>(collection);

            //Assert
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3 }, listIterator.Collection);
        }

        [Test]
        public void ConstructorTestCurrentIndexAfterCollectionCreated()
        {
            //Arrange
            List<int> collection = new List<int>() { 1, 2, 3 };

            //Act
            ListIterator<int> listIterator = new ListIterator<int>(collection);

            //Assert
            Assert.AreEqual(0, listIterator.CurrentIndex);
        }

        [Test]
        public void ConstructorTestCreateCollectionWithNullParameter()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ListIterator<int>(null));
        }

        [Test]
        public void MoveNextBoolResult()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() {1, 2, 3});

            //Act
            bool result = listIterator.MoveNext();
            
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void MoveNextCurrentIndex()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            bool result = listIterator.MoveNext();

            //Assert
            Assert.AreEqual(1, listIterator.CurrentIndex);
        }

        [Test]
        public void MoveNextFromEndOfCollectionBoolResult()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            listIterator.MoveNext();
            listIterator.MoveNext();
            bool result = listIterator.MoveNext();

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ResetTest()
        {
            //Arrange & Act
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            listIterator.MoveNext();
            listIterator.MoveNext();
            listIterator.Reset();

            //Assert
            Assert.AreEqual(0, listIterator.CurrentIndex);
        }

        [Test]
        public void HasNextTest()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            bool result = listIterator.HasNext();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HasNextTestFromSecondLastElement()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            listIterator.MoveNext();
            bool result = listIterator.HasNext();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HasNextTestFromEndOfCollection()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            listIterator.MoveNext();
            listIterator.MoveNext();
            listIterator.MoveNext();
            bool result = listIterator.HasNext();

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void HasNextEmptyCollection()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>());

            //Act
            bool result = listIterator.HasNext();

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PrintTestGeneral()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>() { 1, 2, 3 });

            //Act
            string result = listIterator.Print();

            //Assert
            Assert.AreEqual("1", result);
        }

        [Test]
        public void PrintFromEmptyCollection()
        {
            //Arrange
            ListIterator<int> listIterator = new ListIterator<int>(new List<int>());
            
            //Assert
            Assert.Throws<ArgumentException>(() => listIterator.Print());
        }
    }
}
